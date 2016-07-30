using System;
using HostsManageTool.Winform;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HostsManageTool.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var list = ExtentionClass.DownloaHosts("https://raw.githubusercontent.com/racaljk/hosts/master/hosts");
        }

        [TestMethod]
        public void TTT()
        {
            var s = "http://jsdgfjhdsf";
            var u = new Uri(s);

            
        }
    }
}
