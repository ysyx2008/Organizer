using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 照片整理专家
{
    /// <summary>
    /// 待整理的文件类
    /// </summary>
    internal class OFile
    {
        /// <summary>
        /// 原始地址
        /// </summary>
        public string srcPath = "";

        /// <summary>
        /// 目地址
        /// </summary>
        public string destPath = "";

        /// <summary>
        /// 待整理文件的类型
        /// </summary>
        public OType type;

        /// <summary>
        /// 整理文件的方法
        /// </summary>
        public OMethod Method;
    }

    /// <summary>
    /// 描述文件类型。
    /// Photo：照片
    /// Video：视频
    /// </summary>
    enum OType{ Photo,Video }

    /// <summary>
    /// 描述整理文件的方法
    /// Move：移动
    /// Copy：复制
    /// </summary>
    enum OMethod { Move, Copy}
}
