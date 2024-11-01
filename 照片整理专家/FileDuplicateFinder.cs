using System;
using System.Collections.Generic;
using System.Drawing; // 需要在项目中添加对 System.Drawing 的引用
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using NLog;

namespace 照片整理专家
{
    /// <summary>
    /// 定义文件保留的选项枚举
    /// </summary>
    public enum KeepOption
    {
        EarliestModificationTime, // 保留修改时间最早的文件
        EarliestCreationTime,     // 保留创建时间最早的文件
        LargestFileSize,          // 保留文件大小最大的文件
        SmallestFileSize,         // 保留文件大小最小的文件
        FirstEncountered          // 保留首次遇到的文件
    }

    /// <summary>
    /// 文件重复查找器类，用于检测目标文件夹中的重复文件并处理
    /// </summary>
    public class FileDuplicateFinder
    {
        // 私有字段
        private readonly string targetFolder;               // 目标文件夹路径
        private readonly string recycleFolder;              // 回收文件夹路径
        private readonly KeepOption keepOption;             // 文件保留选项
        private readonly bool compareImagePixels;           // 是否进行图片像素比较
        private readonly Logger logger;                     // NLog 日志记录器
        private CancellationTokenSource cancellationTokenSource; // 任务取消令牌源

        /// <summary>
        /// 进度更新事件，参数为当前处理的文件索引和文件名
        /// </summary>
        public event Action<int, string> ProgressChanged;

        /// <summary>
        /// 构造函数，初始化 FileDuplicateFinder 类的新实例
        /// </summary>
        /// <param name="targetFolder">目标文件夹路径</param>
        /// <param name="recycleFolder">回收文件夹路径</param>
        /// <param name="keepOption">文件保留选项</param>
        /// <param name="compareImagePixels">是否进行图片像素比较，默认为 false</param>
        public FileDuplicateFinder(
            string targetFolder,
            string recycleFolder,
            KeepOption keepOption,
            bool compareImagePixels = false)
        {
            // 获取完整路径
            this.targetFolder = Path.GetFullPath(targetFolder);
            this.recycleFolder = Path.GetFullPath(recycleFolder);
            this.keepOption = keepOption;
            this.compareImagePixels = compareImagePixels;
            this.logger = LogManager.GetCurrentClassLogger();
            this.cancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>
        /// 开始检测和处理重复文件
        /// </summary>
        public void Start()
        {
            var cancellationToken = cancellationTokenSource.Token;

            try
            {
                // 获取目标文件夹中的所有文件，排除回收文件夹内的文件
                var files = Directory.EnumerateFiles(targetFolder, "*.*", SearchOption.AllDirectories);
                var fileList = new List<string>();

                foreach (var file in files)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        logger.Info("任务已被用户中止。");
                        return;
                    }

                    // 排除回收文件夹内的文件
                    if (IsFileInRecycleFolder(file))
                        continue;

                    fileList.Add(file);
                }

                var totalFiles = fileList.Count;
                logger.Info($"总共找到 {totalFiles} 个文件需要处理。");

                // 按文件大小分组，减少哈希计算次数
                var sizeGroups = new Dictionary<long, List<string>>();

                for (int i = 0; i < totalFiles; i++)
                {
                    if (cancellationToken.IsCancellationRequested)
                    {
                        logger.Info("任务已被用户中止。");
                        return;
                    }

                    var file = fileList[i];
                    var fileInfo = new FileInfo(file);
                    long size = fileInfo.Length;

                    if (!sizeGroups.ContainsKey(size))
                    {
                        sizeGroups[size] = new List<string>();
                    }

                    sizeGroups[size].Add(file);

                    // 触发进度更新事件
                    ProgressChanged?.Invoke(i + 1, file);
                    logger.Debug($"文件 {file} 已分入大小为 {size} 字节的组。");
                }

                int processedFiles = 0;

                // 对每个大小组进行哈希比较
                foreach (var group in sizeGroups)
                {
                    var filesWithSameSize = group.Value;

                    // 如果组内只有一个文件，跳过处理
                    if (filesWithSameSize.Count < 2)
                    {
                        processedFiles += filesWithSameSize.Count;
                        continue;
                    }

                    // 创建哈希到文件列表的映射
                    var fileHashes = new Dictionary<string, List<string>>();

                    foreach (var file in filesWithSameSize)
                    {
                        if (cancellationToken.IsCancellationRequested)
                        {
                            logger.Info("任务已被用户中止。");
                            return;
                        }

                        // 计算文件的哈希值
                        string hash = ComputeFileHash(file);

                        if (fileHashes.TryGetValue(hash, out var duplicateList))
                        {
                            duplicateList.Add(file);
                        }
                        else
                        {
                            fileHashes[hash] = new List<string> { file };
                        }

                        processedFiles++;
                        // 触发进度更新事件
                        ProgressChanged?.Invoke(processedFiles, file);
                        logger.Debug($"正在处理文件 {file} ({processedFiles}/{totalFiles})");
                    }

                    // 处理哈希相同的文件
                    foreach (var kvp in fileHashes)
                    {
                        var duplicates = kvp.Value;
                        if (duplicates.Count > 1)
                        {
                            // 如果启用了图片像素比较，进一步验证图片内容
                            if (compareImagePixels)
                            {
                                duplicates = CompareImages(duplicates);
                            }

                            if (duplicates.Count > 1)
                            {
                                // 根据保留选项选择要保留的文件
                                string fileToKeep = SelectFileToKeep(duplicates);

                                // 将其他文件视为重复文件
                                duplicates.Remove(fileToKeep);

                                // 移动重复文件到回收文件夹
                                foreach (var duplicateFile in duplicates)
                                {
                                    if (cancellationToken.IsCancellationRequested)
                                    {
                                        logger.Info("任务已被用户中止。");
                                        return;
                                    }

                                    var destinationPath = GetUniqueDestinationPath(duplicateFile);
                                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath)); // 确保目标文件夹存在
                                    File.Move(duplicateFile, destinationPath);
                                    logger.Info($"移动重复文件 {duplicateFile} 到 {destinationPath}");
                                }
                            }
                        }
                    }

                    // 清空哈希字典，释放内存
                    fileHashes.Clear();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex, "处理文件时发生错误。");
            }
        }

        /// <summary>
        /// 中止当前任务
        /// </summary>
        public void Stop()
        {
            cancellationTokenSource.Cancel();
        }

        /// <summary>
        /// 判断文件是否位于回收文件夹内
        /// </summary>
        /// <param name="filePath">文件的完整路径</param>
        /// <returns>如果文件在回收文件夹内，返回 true；否则返回 false</returns>
        private bool IsFileInRecycleFolder(string filePath)
        {
            var recycleFolderFullPath = recycleFolder.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) + Path.DirectorySeparatorChar;
            var fileFullPath = Path.GetFullPath(filePath);
            return fileFullPath.StartsWith(recycleFolderFullPath, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// 计算文件的 SHA256 哈希值
        /// </summary>
        /// <param name="filePath">文件的完整路径</param>
        /// <returns>文件的哈希值字符串</returns>
        private string ComputeFileHash(string filePath)
        {
            using (var stream = File.OpenRead(filePath))
            {
                var sha256 = SHA256.Create();
                byte[] hashBytes = sha256.ComputeHash(stream);
                // 将哈希字节数组转换为十六进制字符串
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// 对图片文件进行逐像素比较，过滤出内容相同的图片
        /// </summary>
        /// <param name="files">可能重复的图片文件列表</param>
        /// <returns>经过比较后确定的重复图片列表</returns>
        private List<string> CompareImages(List<string> files)
        {
            var uniqueImages = new List<string>();
            var imageHashes = new Dictionary<string, string>(); // 图片像素哈希到文件路径的映射

            foreach (var file in files)
            {
                try
                {
                    using (var image = Image.FromFile(file))
                    {
                        string pixelHash = ComputeImagePixelHash(image);

                        if (imageHashes.TryGetValue(pixelHash, out var existingFile))
                        {
                            // 图片内容相同，添加到重复列表
                            uniqueImages.Add(existingFile);
                        }
                        else
                        {
                            imageHashes[pixelHash] = file;
                            uniqueImages.Add(file);
                        }
                    }
                }
                catch (Exception ex)
                {
                    logger.Warn(ex, $"无法处理图片文件 {file}");
                    uniqueImages.Add(file); // 无法处理的文件保留
                }
            }

            return uniqueImages;
        }

        /// <summary>
        /// 计算图片的像素数据哈希值
        /// </summary>
        /// <param name="image">图片对象</param>
        /// <returns>图片像素数据的哈希值字符串</returns>
        private string ComputeImagePixelHash(Image image)
        {
            using (var bitmap = new Bitmap(image))
            {
                var sha256 = SHA256.Create();
                var pixelData = new List<byte>();

                // 遍历图片的每个像素，获取 RGB 和 Alpha 值
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        var pixel = bitmap.GetPixel(x, y);
                        pixelData.Add(pixel.R);
                        pixelData.Add(pixel.G);
                        pixelData.Add(pixel.B);
                        pixelData.Add(pixel.A);
                    }
                }

                // 计算像素数据的哈希值
                byte[] hashBytes = sha256.ComputeHash(pixelData.ToArray());
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// 根据指定的保留选项选择要保留的文件
        /// </summary>
        /// <param name="files">重复文件列表</param>
        /// <returns>选定要保留的文件路径</returns>
        private string SelectFileToKeep(List<string> files)
        {
            string selectedFile = files[0];

            switch (keepOption)
            {
                case KeepOption.EarliestModificationTime:
                    DateTime earliestModTime = File.GetLastWriteTime(selectedFile);
                    foreach (var file in files)
                    {
                        var modTime = File.GetLastWriteTime(file);
                        if (modTime < earliestModTime)
                        {
                            earliestModTime = modTime;
                            selectedFile = file;
                        }
                    }
                    break;

                case KeepOption.EarliestCreationTime:
                    DateTime earliestCreationTime = File.GetCreationTime(selectedFile);
                    foreach (var file in files)
                    {
                        var creationTime = File.GetCreationTime(file);
                        if (creationTime < earliestCreationTime)
                        {
                            earliestCreationTime = creationTime;
                            selectedFile = file;
                        }
                    }
                    break;

                case KeepOption.LargestFileSize:
                    long largestSize = new FileInfo(selectedFile).Length;
                    foreach (var file in files)
                    {
                        var size = new FileInfo(file).Length;
                        if (size > largestSize)
                        {
                            largestSize = size;
                            selectedFile = file;
                        }
                    }
                    break;

                case KeepOption.SmallestFileSize:
                    long smallestSize = new FileInfo(selectedFile).Length;
                    foreach (var file in files)
                    {
                        var size = new FileInfo(file).Length;
                        if (size < smallestSize)
                        {
                            smallestSize = size;
                            selectedFile = file;
                        }
                    }
                    break;

                case KeepOption.FirstEncountered:
                default:
                    // 保留列表中的第一个文件
                    break;
            }

            return selectedFile;
        }

        /// <summary>
        /// 获取重复文件在回收文件夹中的唯一目标路径
        /// </summary>
        /// <param name="originalFilePath">重复文件的原始路径</param>
        /// <returns>回收文件夹中的目标路径</returns>
        private string GetUniqueDestinationPath(string originalFilePath)
        {
            var relativePath = GetRelativePath(targetFolder, originalFilePath);
            var destinationPath = Path.Combine(recycleFolder, relativePath);

            var directoryPath = Path.GetDirectoryName(destinationPath);
            Directory.CreateDirectory(directoryPath);

            if (!File.Exists(destinationPath))
            {
                return destinationPath;
            }

            var fileName = Path.GetFileNameWithoutExtension(destinationPath);
            var extension = Path.GetExtension(destinationPath);
            int count = 1;

            // 如果目标路径已存在同名文件，添加编号避免冲突
            while (File.Exists(destinationPath))
            {
                string tempFileName = $"{fileName}({count++}){extension}";
                destinationPath = Path.Combine(directoryPath, tempFileName);
            }

            return destinationPath;
        }

        /// <summary>
        /// 获取两个路径之间的相对路径
        /// </summary>
        /// <param name="basePath">基路径</param>
        /// <param name="path">目标路径</param>
        /// <returns>相对于基路径的相对路径</returns>
        private static string GetRelativePath(string basePath, string path)
        {
            Uri baseUri = new Uri(AppendDirectorySeparatorChar(basePath));
            Uri pathUri = new Uri(path);

            if (baseUri.Scheme != pathUri.Scheme)
            {
                // 如果不是同一方案（例如，一个是文件路径，一个是 HTTP 路径），无法计算相对路径
                return path;
            }

            Uri relativeUri = baseUri.MakeRelativeUri(pathUri);
            string relativePath = Uri.UnescapeDataString(relativeUri.ToString());

            if (string.Equals(pathUri.Scheme, Uri.UriSchemeFile, StringComparison.OrdinalIgnoreCase))
            {
                // 将 URI 路径中的 '/' 替换为系统的目录分隔符
                relativePath = relativePath.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
            }

            return relativePath;
        }

        /// <summary>
        /// 确保路径以目录分隔符结尾
        /// </summary>
        /// <param name="path">路径字符串</param>
        /// <returns>以目录分隔符结尾的路径</returns>
        private static string AppendDirectorySeparatorChar(string path)
        {
            if (!path.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                return path + Path.DirectorySeparatorChar;
            }
            return path;
        }
    }
}
