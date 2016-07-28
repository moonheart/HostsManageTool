using System;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Text;

namespace HostsManageTool
{
    public class HttpRequestHelper
    {
        static HttpWebRequest _request;
        static HttpWebResponse _response;

        public static string Post_Data_xml(string url, string postdata, CookieContainer cc, string refer)
        {
            string temp = null;
            try
            {
                byte[] byteArray = Encoding.UTF8.GetBytes(postdata); // 转化
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.Method = "POST";
                if (refer != "")
                {
                    _request.Referer = refer;
                }
                _request.ProtocolVersion = new Version("1.0");
                _request.ContentType = "application/x-www-form-urlencoded";
                _request.ContentLength = byteArray.Length;
                Stream newStream = _request.GetRequestStream();
                // Send the data.
                newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
                newStream.Close();
                _response = (HttpWebResponse)_request.GetResponse();
                StreamReader str = new StreamReader(_response.GetResponseStream(), Encoding.UTF8);
                temp = str.ReadToEnd();
            }
            catch (Exception ex)
            {

            }
            return temp;
        }

        public static string Post_Data(string url, string postdata, CookieContainer cc, string encoding, string refer)
        {
            string temp = null;
            Encoding encod = Encoding.GetEncoding(encoding);
            try
            {
                byte[] byteArray = encod.GetBytes(postdata); // 转化
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; InfoPath.1)";
                _request.Method = "POST";
                if (refer != "")
                {
                    _request.Referer = refer;
                }
                _request.ContentType = "application/x-www-form-urlencoded";
                _request.ContentLength = byteArray.Length;
                Stream newStream = _request.GetRequestStream();
                // Send the data.
                newStream.Write(byteArray, 0, byteArray.Length);    //写入参数
                newStream.Close();
                _response = (HttpWebResponse)_request.GetResponse();
                StreamReader str = new StreamReader(_response.GetResponseStream(), encod);
                temp = str.ReadToEnd();
            }
            catch (Exception ex)
            {
                temp = ex.ToString();
            }
            return temp;
        }
        public static string Get_Data(string url, CookieContainer cc, string encoding, string refer)
        {
            string temp = null;
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.Method = "GET";
                _request.UserAgent =
                    " Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/49.0.2623.87 Safari/537.36";
                if (refer != "")
                {
                    _request.Referer = refer;
                }
                _request.ProtocolVersion = new Version("1.0");
                _response = (HttpWebResponse)_request.GetResponse();
                StreamReader str = new StreamReader(_response.GetResponseStream(), Encoding.GetEncoding(encoding));
                temp = str.ReadToEnd();
            }
            catch (Exception ex)
            {

            }
            return temp;
        }
        public static WebHeaderCollection Get_Header(string url, CookieContainer cc, string encoding, string refer)
        {
            WebHeaderCollection temp = null;
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.Accept = "*/*";
                _request.Method = "GET";
                if (refer != "")
                {
                    _request.Referer = refer;
                }
                _request.ProtocolVersion = new Version("1.0");
                _response = (HttpWebResponse)_request.GetResponse();
                StreamReader str = new StreamReader(_response.GetResponseStream(), Encoding.GetEncoding(encoding));
                temp = _request.Headers;
            }
            catch (Exception ex)
            {

            }
            return temp;
        }

        public static Stream Get_ImgStream(string url, CookieContainer cc)
        {
            Stream temp = null;
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.Method = "GET";
                _response = (HttpWebResponse)_request.GetResponse();
                temp = _response.GetResponseStream();

            }
            catch (Exception ex)
            {

            }
            return temp;
        }
        public static Stream Get_ImgStream_refer(string url, CookieContainer cc, string refer)
        {
            Stream temp = null;
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(new Uri(url));
                _request.CookieContainer = cc;
                _request.Referer = refer;
                _request.Method = "GET";
                _response = (HttpWebResponse)_request.GetResponse();
                temp = _response.GetResponseStream();
            }
            catch (Exception ex)
            {

            }
            return temp;
        }
        /// <summary>
        /// 解压数据 - 此方法可以避免一些乱码出现
        /// </summary>
        /// <param name="strea">数据流</param>
        /// <returns>解压后的数据流</returns>
        public static Stream Decompress_GZIP(Stream stream)
        {
            GZipStream gstream = new GZipStream(stream, CompressionMode.Decompress);
            return gstream;
        }
        /// <summary>
        /// 压缩数据
        /// </summary>
        /// <param name="strea">数据流</param>
        /// <returns>压缩后的数据流</returns>
        public static Stream Compress_GZIP(Stream stream)
        {
            GZipStream gstream = new GZipStream(stream, CompressionMode.Compress);
            return gstream;
        }

        public static Image DownLoadImge(string Url, bool OpenProxy = false)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(Url));
            if (!OpenProxy)//代理
            {
                req.Proxy = null;
            }
            HttpWebResponse res = (HttpWebResponse)req.GetResponse();
            Stream stream = res.GetResponseStream();
            Image img = Image.FromStream(stream);
            stream.Close();
            stream.Dispose();
            req.Abort();
            return img;
        }
    }
}
