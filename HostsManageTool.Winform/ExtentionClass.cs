using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Net;
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

        public static char[] IpStartStrings = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };


        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 现在远程hosts到字符串数组
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DownloaHosts(string url)
        {
            if (url.IsNullOrWhiteSpace())
                return null;

            var request = (HttpWebRequest)WebRequest.Create(url);

            Stream rs;
            using (var response = request.GetResponse())
            {
                rs = response.GetResponseStream();
                if (rs != null)
                {
                    string str;
                    using (var sr = new StreamReader(rs))
                    {
                        str = sr.ReadToEnd();
                    }
                    var list = str.Split('\n').Where(d => !d.IsNullOrWhiteSpace() && IpStartStrings.Contains(d[0])).ToList();
                    if (list.Count > 0)
                    {
                        var dic = new Dictionary<string, string>();

                        foreach (string s in list)
                        {
                            var ss = s.Trim().Replace("\t", " ").Split(' ');
                            if (!dic.ContainsKey(ss.Last()))
                                dic.Add(ss.Last(), ss.First());
                        }
                        return dic;
                    }
                    return null;
                }
            }
            return null;
        }
    }
}
