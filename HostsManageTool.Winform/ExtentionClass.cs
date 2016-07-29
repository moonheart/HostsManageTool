using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HostsManageTool.Winform
{
    public static class ExtentionClass
    {
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectinString
        {
            get
            {
                var conn = ConfigurationManager.AppSettings["Conn"];
                if (conn.IsNullOrWhiteSpace())
                {
                    throw new Exception("连接字符串未配置");
                }
                var path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
                return string.Format(conn, path);
            }
        }

        

        /// <summary>
        /// 获取SqliteHelper
        /// </summary>
        public static SQLiteHelper SqLiteHelper
        {
            get
            {
                var conn = new SQLiteCommand(new SQLiteConnection(ConnectinString));
                conn.Connection.Open();
                return new SQLiteHelper(conn);
            }
        }

        public static bool IsIpAddress(this string ip)
        {
            return Regex.IsMatch(ip,
                @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
        }


        //public static UserHosts DataRowToUserHosts(DataRow row)
        //{
        //    var hosts = new UserHosts();
        //    hosts.Id = int.Parse(row["Id"] + "");
        //    hosts.HostName = row["HostName"] + "";
        //    hosts.Ip = row["Ip"] + "";
        //    hosts.IsInUse = int.Parse(row["IsInUse"] + "");
        //    return hosts;
        //}

        //public static HostsSource DataRowToHostsSource(DataRow row)
        //{
        //    var source = new HostsSource();
        //    source.Id = int.Parse(row["Id"] + "");
        //    source.Name = row["Name"] + "";
        //    source.Url = row["Url"] + "";
        //    source.IsEnabled = int.Parse(row["IsEnabled"] + "");
        //    return source;
        //}


        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }
    }
}
