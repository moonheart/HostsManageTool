using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HostsManageTool.Winform
{
    public static class ExtentionClass
    {
        /// <summary>
        /// 获取应用程序路径
        /// </summary>
        public static readonly string ApplicationPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

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
                var path = ApplicationPath;
                return string.Format(conn, path);
            }
        }

        /// <summary>
        /// 是否是Ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string ip)
        {
            return Regex.IsMatch(ip,
                @"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
        }

        /// <summary>
        /// Ip开头字符串
        /// </summary>
        public static readonly char[] IpStartStrings = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        /// <summary>
        /// 启用控件
        /// </summary>
        /// <param name="s"></param>
        public static void EnableControl(object s)
        {
            var sender = s as Control;
            if (sender != null)
            {
                if (sender.InvokeRequired)
                {
                    sender.Invoke(new MethodInvoker(() =>
                    {
                        sender.Enabled = true;
                    }));
                }
                else
                {
                    sender.Enabled = true;
                }
            }
        }

        /// <summary>
        /// IsNullOrWhiteSpace
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        /// <summary>
        /// 现在远程hosts到字典
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static Dictionary<string, string> DownloaHosts(string url)
        {
            if (url.IsNullOrWhiteSpace())
                return null;

            var request = (HttpWebRequest)WebRequest.Create(url);

            try
            {
                using (var response = request.GetResponse())
                {
                    var rs = response.GetResponseStream();
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
            }
            catch (WebException ex)
            {
                var exc = new HostSourceFalseException(url, ex.Message);
                throw exc;
            }
            return null;
        }

        /// <summary>
        /// 写入二进制文件到对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="data">要写入的对象</param>
        /// <param name="path">路径</param>
        public static void WriteBinary<T>(T data, string path)
            where T : ISerializable
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        IFormatter formatter = new BinaryFormatter();
                        formatter.Serialize(ms, data);
                        bw.Write(ms.GetBuffer());
                        bw.Flush();
                    }
                }
            }
        }

        /// <summary>
        /// 读取二进制文件到对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="path">路径</param>
        /// <returns></returns>
        public static T ReadBinary<T>(string path)
            where T : ISerializable
        {
            if (!File.Exists(path))
                return default(T);
            var b = File.ReadAllBytes(path);
            using (MemoryStream ms = new MemoryStream(b))
            {
                IFormatter formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(ms);
            }
        }
    }
}
