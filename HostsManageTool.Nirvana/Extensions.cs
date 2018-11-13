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

namespace HostsManageTool.Nirvana
{
    public static class Extensions
    {
        /// <summary>
        /// 获取应用程序路径
        /// </summary>
        public static readonly string ApplicationPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;

        private static Random random = new Random();
        public static string GetRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(
                Enumerable.Repeat(chars, length)
                    .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GetRandomStringLength10()
        {
            return GetRandomString(10);
        }

        /// <summary>
        /// 是否是Ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string ip)
        {
            return IPAddress.TryParse(ip, out _);
        }

        /// <summary>
        /// Ip开头字符串
        /// </summary>
        public static readonly char[] IpStartStrings = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

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
