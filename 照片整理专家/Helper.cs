using MetadataExtractor;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace 照片整理专家
{
    public class Helper
    {

        #region 通过metadata-extractor获取照片参数

        //参考文献
        //官网: https://drewnoakes.com/code/exif/
        //nuget 官网:https://www.nuget.org/
        //nuget 使用: http://www.cnblogs.com/chsword/archive/2011/09/14/NuGet_Install_OperatePackage.html
        //nuget MetadataExtractor: https://www.nuget.org/packages/MetadataExtractor/

        /// <summary>
        /// 通过MetadataExtractor获取照片参数
        /// </summary>
        /// <param name="imgPath">照片绝对路径</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetExifByMe(string imgPath)
        {
            var rmd = ImageMetadataReader.ReadMetadata(imgPath);
            var rt = new Dictionary<string, string>();
            foreach (var rd in rmd)
            {
                foreach (var tag in rd.Tags)
                {
                    var caption = EngToChs(tag.Name);
                    if (caption == "其他")
                    {
                        continue;
                    }
                    if (!rt.ContainsKey(caption))
                    {
                        rt.Add(caption, tag.Description);
                    }
                }
            }
            return rt;
        }

        /// <summary>筛选参数并将其名称转换为中文
        /// </summary>
        /// <param name="caption">参数名称</param>
        /// <returns>参数中文名</returns>
        private static string EngToChs(string caption)
        {
            var chineseCaption = "其他";
            switch (caption)
            {
                case "Exif Version":
                    chineseCaption = "Exif版本";
                    break;
                case "Make":
                    chineseCaption = "设备制造商";
                    break;
                case "Model":
                    chineseCaption = "设备型号";
                    break;
                case "Lens Model":
                    chineseCaption = "镜头类型";
                    break;
                case "File Name":
                    chineseCaption = "文件名";
                    break;
                case "File Size":
                    chineseCaption = "文件大小";
                    break;
                case "Date/Time Original":
                    chineseCaption = "拍摄时间";
                    break;
                case "Created":
                    chineseCaption = "创建时间";
                    break;
                case "File Modified Date":
                    chineseCaption = "修改时间";
                    break;
                case "Image Height":
                    chineseCaption = "照片高度";
                    break;
                case "Image Width":
                    chineseCaption = "照片宽度";
                    break;
                case "X Resolution":
                    chineseCaption = "水平分辨率";
                    break;
                case "Y Resolution":
                    chineseCaption = "垂直分辨率";
                    break;
                case "Color Space":
                    chineseCaption = "色彩空间";
                    break;
                case "Shutter Speed Value":
                    chineseCaption = "快门速度";
                    break;
                case "F-Number":
                    chineseCaption = "光圈";//Aperture Value也表示光圈
                    break;
                case "ISO Speed Ratings":
                    chineseCaption = "ISO";
                    break;
                case "Exposure Bias Value":
                    chineseCaption = "曝光补偿";
                    break;
                case "Focal Length":
                    chineseCaption = "焦距";
                    break;
                case "Exposure Program":
                    chineseCaption = "曝光程序";
                    break;
                case "Metering Mode":
                    chineseCaption = "测光模式";
                    break;
                case "Flash Mode":
                    chineseCaption = "闪光灯";
                    break;
                case "White Balance Mode":
                    chineseCaption = "白平衡";
                    break;
                case "Exposure Mode":
                    chineseCaption = "曝光模式";
                    break;
                case "Continuous Drive Mode":
                    chineseCaption = "驱动模式";
                    break;
                case "Focus Mode":
                    chineseCaption = "对焦模式";
                    break;
            }
            return chineseCaption;
        }

        #endregion

        /// <summary>
        /// 读入到字节数组中比较(while循环比较字节数组)
        /// </summary>
        /// <param name="file1"></param>
        /// <param name="file2"></param>
        /// <returns></returns>
        public static bool CompareByByteArray(string file1, string file2, int blockSize = 1024 * 1024)
        {
            {
                using (var fs1 = new FileStream(file1, FileMode.Open))
                using (var fs2 = new FileStream(file2, FileMode.Open))
                {
                    if (fs1.Length != fs2.Length)
                    {
                        return false;
                    }

                    var buffer1 = new byte[blockSize];
                    var buffer2 = new byte[blockSize];
                    var bytesRead1 = 0;
                    var bytesRead2 = 0;

                    while ((bytesRead1 = fs1.Read(buffer1, 0, buffer1.Length)) > 0 &&
                           (bytesRead2 = fs2.Read(buffer2, 0, buffer2.Length)) > 0)
                    {
                        if (bytesRead1 != bytesRead2)
                        {
                            return false;
                        }

                        for (var i = 0; i < bytesRead1; i++)
                        {
                            if (buffer1[i] != buffer2[i])
                            {
                                return false;
                            }
                        }
                    }

                    return true;
                }
            }
        }


        /// <summary>
        /// 使用哈希算法比较文件是否一致
        /// </summary>
        /// <param name="filePath1"></param>
        /// <param name="filePath2"></param>
        /// <returns></returns>
        public static bool CompareByHash(string filePath1, string filePath2)
        {
            // 创建一个哈希算法对象
            using (HashAlgorithm hash = HashAlgorithm.Create())
            {
                using (FileStream file1 = new FileStream(filePath1, FileMode.Open), file2 = new FileStream(filePath2, FileMode.Open))
                {
                    byte[] hashByte1 = hash.ComputeHash(file1); // 根据文件内容计算哈希值
                    byte[] hashByte2 = hash.ComputeHash(file2);
                    return StructuralComparisons.StructuralEqualityComparer.Equals(hashByte1, hashByte2); // 比较两个哈希值是否相等
                }
            }
        }

        /// <summary>
        /// 计算文件的MD5值
        /// 待验证
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetMD5HashFromFile(string filePath)
        {
            using (FileStream file = new FileStream(filePath, FileMode.Open))
            {
                using (MD5 md5 = new MD5CryptoServiceProvider())
                {
                    byte[] retVal = md5.ComputeHash(file);
                    ASCIIEncoding enc = new ASCIIEncoding();
                    return enc.GetString(retVal);
                }
            }
        }

        /// <summary>
        /// 获取一个与现有文件不冲突的文件名，新名称包括完整路径
        /// </summary>
        /// <param name="dest">目标文件夹</param>
        /// <param name="file">文件信息</param>
        /// <returns>包含完整路径的新文件名</returns>
        public static string getUnionName(string dest, FileInfo file)
        {
            string fullname = Path.Combine(dest, file.Name);
            if (!File.Exists(fullname))
            {
                return fullname;
            }

            int i = 1;
            string newName = "";
            while (true)
            {
                if (file.Extension.Length > 0)
                {
                    newName = Path.Combine(dest, file.Name.Remove(file.Name.Length - file.Extension.Length) + "_" + i.ToString() + file.Extension);
                }
                else
                {
                    newName = Path.Combine(dest, file.Name + "_" + i.ToString());
                }

                if (!File.Exists(newName))
                {
                    return newName;
                }
                i++;
            }
        }

        /// <summary>
        /// 将字节值转换为可阅读的值
        /// </summary>
        /// <param name="size">字节值</param>
        /// <returns></returns>
        public static String HumanReadableFilesize(double size)
        {
            String[] units = new String[] { "B", "KB", "MB", "GB", "TB", "PB" };
            double mod = 1024.0;
            int i = 0;
            while (size >= mod)
            {
                size /= mod;
                i++;
            }
            return Math.Round(size, 2) + units[i];
        }

        /// <summary>
        /// 加载目录下的文件列表
        /// </summary>
        /// <param name="root">目录路径</param>
        /// <param name="isIncludeSubDirectories">是否包含子目录</param>
        /// <param name="minFileSize">最小文件大小。单位为字节</param>
        /// <param name="ignoreKeyWord">忽略关键字</param>
        public static List<FileInfo> LoadFiles(string root, bool isIncludeSubDirectories = false,int minFileSize = 0, string ignoreKeyWord = "")
        {
            List<FileInfo> list = new List<FileInfo>();

            DirectoryInfo di = new DirectoryInfo(root);

            if ((di.Attributes & FileAttributes.System) == FileAttributes.System)
            {
                if (di.FullName != System.IO.Directory.GetDirectoryRoot(di.FullName))
                {
                    return list;
                }
            }

            if ((di.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
            {
                if (di.FullName != System.IO.Directory.GetDirectoryRoot(di.FullName))
                {
                    return list;
                }
            }

            FileInfo[] files = di.GetFiles();
            foreach (FileInfo file in files)
            {
                if ((file.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                {
                    // 跳过隐藏文件
                    continue;
                }
                else if ((file.Attributes & FileAttributes.System) == FileAttributes.System)
                {
                    // 跳过系统文件
                    continue;
                }
                else if (file.Length < minFileSize)
                {
                    // 跳过小文件
                    continue;
                }
                else if (ignoreKeyWord != "" && file.Name.Contains(ignoreKeyWord))
                {
                    // 跳过特定关键字的文件
                    continue;
                }
                else
                {
                    list.Add(file);
                }
            }

            if (isIncludeSubDirectories)//如果选择包括子目录
            {
                DirectoryInfo[] dis = di.GetDirectories();//目录下的子目录
                foreach (DirectoryInfo item in dis)
                {
                    list.AddRange(LoadFiles(item.FullName, isIncludeSubDirectories, minFileSize, ignoreKeyWord));
                }
            }

            return list;
        }

        /// <summary>
        /// 读取Exif，判断是否存在拍摄时间信息
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static bool haveExif(FileInfo file)
        {
            try
            {
                Dictionary<string, string> exif = readExif(file.FullName);
                if (exif.ContainsKey("拍摄时间") == false)
                {
                    return false;
                }
                else
                {
                    DateTime dtime = DateTime.ParseExact(exif["拍摄时间"], "yyyy:MM:dd HH:mm:ss", CultureInfo.CurrentCulture);
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static Dictionary<string, string> readExif(string file)
        {
            // 读取Exif信息
            Dictionary<string, string> exif = new Dictionary<string, string>();
            try
            {
                return GetExifByMe(file);
            }
            catch (Exception)
            {
                // 无法判断文件类型时
                throw new Exception(file + "读取Exif信息时发生异常");
                // isIgnore = true;
            }
        }

        public enum exifCompareResult
        {
            一致 = 1,
            不一致 = 0,
            都没有 = -1
        }

        public static exifCompareResult CompareByExif(string file1, string file2)
        {
            try
            {
                Dictionary<string, string> exif1;
                Dictionary<string, string> exif2;
                try
                {
                    exif1 = readExif(file1);
                }
                catch (Exception)
                {
                    throw new Exception(file1 + " 的Exif信息读取失败");
                }

                try
                {
                    exif2 = readExif(file2);
                }
                catch (Exception)
                {
                    throw new Exception(file2 + " 的Exif信息读取失败");
                }

                List<string> keys = new List<string>();
                keys.Add("相机型号");
                keys.Add("拍摄时间");
                keys.Add("快门速度");
                keys.Add("光圈");
                keys.Add("ISO");

                #region 检测是否包含用于对比的Exif信息
                bool hasExif = false;
                foreach (string key in keys)
                {
                    if (exif1.ContainsKey(key) || exif2.ContainsKey(key))
                    {
                        hasExif = true;
                    }
                }
                if (hasExif == false)
                {
                    return exifCompareResult.都没有;
                }
                #endregion

                foreach (string key in keys)
                {
                    if (exif1.ContainsKey(key) && exif2.ContainsKey(key))
                    {
                        if (exif1[key] != exif2[key])
                        {
                            // logger.Debug("{0} 与 {1} 的Exif信息 {2} 不相同，分别是{3} 和 {4}", file1, file2, key, exif1[key].ToString(), exif2[key].ToString());
                            return exifCompareResult.不一致;
                        }
                    }
                    else
                    {
                        if (exif1.ContainsKey(key) == true && exif2.ContainsKey(key) == false)
                        {
                            throw new Exception(file1 + " 包含Exif信息：" + key + " 但 " + file2 + "不包含");
                        }
                        else if (exif1.ContainsKey(key) == false && exif2.ContainsKey(key) == true)
                        {
                            throw new Exception(file1 + " 不包含Exif信息：" + key + " 但 " + file2 + "包含");
                        }
                        else
                        {
                            throw new Exception(file1 + " 和 " + file2 + " 都不包含特定的Exif信息：" + key);
                        }
                    }
                }
                return exifCompareResult.一致;
            }
            catch (Exception)
            {
                //logger.info("Exif信息不一致：" + ex.Message);
                return exifCompareResult.不一致;
            }
        }

        public static bool CompareByPixel(FileInfo file1, FileInfo file2)
        {
            Image img1;
            Image img2;

            try
            {
                img1 = Image.FromFile(file1.FullName);
            }
            catch (OutOfMemoryException)
            {
                throw new Exception(file1.FullName + "不是有效的图片");
            }
            try
            {
                img2 = Image.FromFile(file2.FullName);
            }
            catch (OutOfMemoryException)
            {
                throw new Exception(file2.FullName + "不是有效的图片");
            }

            try
            {
                if (isPicture(img1) == false)
                {
                    throw new Exception(file1.FullName + "不支持的图片格式，不能进行像素比对");
                }

                if (isPicture(img2) == false)
                {
                    throw new Exception(file2.FullName + "不支持的图片格式，不能进行像素比对");
                }

                Bitmap bitmapSource = new Bitmap(img1);
                Bitmap bitmapTarget = new Bitmap(img2);

                // 长宽不同时判定为不一致。
                if (bitmapSource.Width != bitmapTarget.Width || bitmapSource.Height != bitmapTarget.Height)
                {
                    //throw new Exception(file1.FullName + "和" + file2.FullName + "的长宽不相同");
                    return false;
                }

                // 照片尺寸相同时逐个像素比对
                for (int i = 0; i < bitmapTarget.Width; i++)
                {
                    for (int j = 0; j < bitmapTarget.Height; j++)
                    {
                        if (bitmapSource.GetPixel(i, j).Equals(bitmapTarget.GetPixel(i, j)) == false)
                        {
                            return false;
                        }
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                img1.Dispose();
                img2.Dispose();
            }
        }

        /// <summary>
        /// 判断文件是否是有效的图片类型
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static bool isPicture(Image img)
        {
            if (img.RawFormat.Guid == ImageFormat.Bmp.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Emf.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Exif.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Gif.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Icon.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Jpeg.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.MemoryBmp.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Png.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Tiff.Guid)
            {
                return true;
            }
            if (img.RawFormat.Guid == ImageFormat.Wmf.Guid)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 检查文件名是否合法
        /// </summary>
        /// <param name="name">文件名</param>
        /// <returns></returns>
        public static bool IsValidFileName(string name)
        {
            // 检查是否为空或过长
            if (string.IsNullOrWhiteSpace(name) || name.Length > 255)
            {
                return false;
            }

            // 检查是否包含非法字符
            foreach (char c in Path.GetInvalidFileNameChars())
            {
                if (name.Contains(c))
                {
                    return false;
                }
            }

            // 检查是否是Windows保留的文件名
            string[] reservedNames = new string[] { "CON", "PRN", "AUX", "NUL", "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "LPT1", "LPT2", "LPT3", "LPT4", "LPT5", "LPT6", "LPT7", "LPT8", "LPT9" };
            foreach (string reserved in reservedNames)
            {
                if (name.Equals(reserved, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// 清理文件名中的无意义字符。
        /// 如果文件名没有修改，则返回空白字符串。
        /// </summary>
        /// <param name="filename">文件名，不能有扩展名</param>
        /// <param name="removeSuffix">是否移除文件名后缀中类似“(1)、(2)”的编号</param>
        /// <param name="trimWhitespace">是否移除空白字符</param>
        /// <returns></returns>
        public static string PurgeFileName(string filename, bool removeSuffix=true, bool trimWhitespace=true)
        {
            string originalFileName = filename;
            string newFileName = originalFileName;

            // Remove trailing numbers in parentheses from the filename if required
            if (removeSuffix)
            {
                newFileName = Regex.Replace(originalFileName, @"\(\d+\)+$", "");
            }
            
            // Trim whitespace from the start and end of the filename if required
            if (trimWhitespace)
            {
                newFileName = newFileName.Trim();
            }

            if(newFileName == originalFileName)
            {
                return "";
            }
            else
            {
                return newFileName;
            }
        }

        public static string PurgeFileName(FileInfo file, bool removeSuffix = true, bool trimWhitespace = true)
        {
            return PurgeFileName(file.Name, removeSuffix, trimWhitespace);
        }
    }
}
