using Microsoft.VisualStudio.TestTools.UnitTesting;
using 照片整理专家;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace 照片整理专家.Tests
{
    [TestClass()]
    public class HelperTests
    {
        [TestMethod()]
        public void ProcessFileNameTest()
        {
            Assert.AreEqual("file", Helper.PurgeFileName("file (1)"));
            Assert.AreEqual("file", Helper.PurgeFileName("  file (2)"));
            Assert.AreEqual("file", Helper.PurgeFileName("  file (1) (3)  "));
        }
    }
}