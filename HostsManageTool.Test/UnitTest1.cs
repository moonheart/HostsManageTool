using System;
using System.Data.SQLite;
using HostsManageTool.Winform;
using HostsManageTool.Winform.Sqlite;
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
            var sql = @"insert into hostname (name) values('ccccccccccccc');
insert into hostname(name) values('ddddddddddddd'); ";
            var conn = new SQLiteConnection(ExtentionClass.ConnectinString);
            conn.Open();

            var sqlh = new SQLiteHelper(new SQLiteCommand(conn));
            sqlh.Execute(sql);
        }
    }
}
