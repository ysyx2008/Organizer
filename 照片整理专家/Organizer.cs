using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 照片整理专家
{
    /// <summary>
    /// Todo: 使用面向对象的方法重写程序
    /// </summary>
    class Organizer
    {
        /// <summary>
        /// 整理方法，可选择移动或复制目标文件夹
        /// </summary>
        public enum Method{ Move, Copy }

        /// <summary>
        /// 源文件夹
        /// </summary>
        string source = "";

        /// <summary>
        /// 目标文件夹
        /// </summary>
        string destination = "";

        /// <summary>
        /// 整理方法，默认使用移动操作
        /// </summary>
        Method method = Method.Move;

        public Organizer(string source, string destination, Method method = Method.Move)
        {
            this.source = source;
            this.destination = destination;
            this.method = method;
        }

        /// <summary>
        /// 执行整理
        /// </summary>
        public void Start()
        {
            // 统计需要整理的文件数量
            DirectoryInfo root = new DirectoryInfo(source);

            FileInfo[] fileList = root.GetFiles();



            // 执行整理
            foreach (FileInfo f in fileList)//遍历文件夹下的每个文件
            {
                string filename = source + f.Name;//得到单个文件的filename，自己进行相关操作
            }


        }
    }
}
