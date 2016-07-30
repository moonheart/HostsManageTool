using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using HostsManageTool.Winform.Model;
using HostsManageTool.Winform.Sqlite;

namespace HostsManageTool.Winform.Bll
{
    public class HostsSourceManager
    {
        private SQLiteHelper Helper
        {
            get
            {
                var conn = new SQLiteCommand(new SQLiteConnection(ExtentionClass.ConnectinString));
                conn.Connection.Open();
                return new SQLiteHelper(conn);
            }
        }
        private static HostsSourceManager _in = new HostsSourceManager();
        public static HostsSourceManager Instance { get { return _in; } }
        private HostsSourceManager()
        {

        }

        /// <summary>
        /// 交换顺序
        /// </summary>
        /// <param name="now"></param>
        /// <param name="alter"></param>
        /// <exception cref="ItemNotFoundException"></exception>
        /// <returns></returns>
        public int ChangeSequence(int now, int alter)
        {
            var sourceNow = FindById(now);
            var sourceAlter = FindById(alter);
            if (sourceNow == null || sourceAlter == null)
            {
                throw new ItemNotFoundException();
            }
            var sql1 = $"update hostssource set Name='{sourceNow.Name}',Url = '{sourceNow.Url}',isenabled = '{sourceNow.IsEnabled}' where id = {sourceAlter.Id};";
            var sql2 = $"update hostssource set Name='{sourceAlter.Name}',Url = '{sourceAlter.Url}',isenabled = '{sourceAlter.IsEnabled}' where id = {sourceNow.Id};";
            var n = Helper.Execute(sql1 + sql2);
            return n;
        }

        /// <summary>
        /// 添加source
        /// </summary>
        /// <param name="source"></param>
        /// <exception cref="ItemAlreadyExitedException"></exception>
        /// <exception cref="ItemOperationFaildException"></exception>
        /// <returns></returns>
        public HostsSource AddHostSource(HostsSource source)
        {
            var s = FindByUrl(source.Url);
            if (s != null)
            {
                throw new ItemAlreadyExitedException();
            }
            var conn = new SQLiteConnection(ExtentionClass.ConnectinString);
            conn.Open();
            var h = new SQLiteHelper(new SQLiteCommand(conn));

            var sql = $"insert into hostssource (name,url) values('{source.Name}','{source.Url}')";
            var n = h.Execute(sql);
            if (n > 0)
            {
                sql = "select last_insert_rowid() as Id from hostssource;";
                var obj = h.ExecuteScalar(sql);
                int id;
                int.TryParse(obj + "", out id);
                return FindById(id);
            }
            throw new ItemOperationFaildException();
        }


        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="source"></param>
        /// <exception cref="ItemNotFoundException"></exception>
        /// <returns></returns>
        public int UpdateHostsSource(HostsSource source)
        {
            var s = FindById(source.Id);
            if (s == null)
            {
                throw new ItemNotFoundException();
            }
            var sql = $"update hostssource set url = '{source.Url}',name='{source.Name}' where id ={source.Id}";
            return Helper.Execute(sql);
        }

        public HostsSource FindByUrl(string url)
        {
            var sql = $"select * from hostssource where Url = '{url}'";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostsSource).FirstOrDefault();
        }

        /// <summary>
        /// 通过Id查找
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HostsSource FindById(int id)
        {
            var sql = $"select * from hostssource where id = {id}";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostsSource).FirstOrDefault();
        }

        /// <summary>
        /// 删除一条hosts源
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DeleteHostsSource(int id)
        {
            var source = FindById(id);
            if (source == null)
            {
                throw new ItemNotFoundException();
            }
            var sql = $"delete from hostssource where id = {source.Id}";
            return Helper.Execute(sql);
            //throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有hosts源
        /// </summary>
        /// <returns></returns>
        public List<HostsSource> GetAllHostsSource()
        {
            var sql = "select * from hostssource";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostsSource).ToList();

            //throw new NotImplementedException();
        }


        /// <summary>
        /// 切换状态
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ItemNotFoundException"></exception>
        /// <returns></returns>
        public int DisbaleEnable(int id)
        {
            var source = FindById(id);
            if (source == null)
            {
                throw new ItemNotFoundException();
            }

            var sql = $"update hostssource set Isenabled ={(source.IsEnabled == 1 ? 0 : 1)} where id={id} ";
            return Helper.Execute(sql);
        }



        public HostsSource DataRowToHostsSource(DataRow row)
        {
            var source = new HostsSource();
            source.Id = int.Parse(row["Id"] + "");
            source.IsEnabled = int.Parse(row["IsEnabled"] + "");
            source.Name = row["Name"] + "";
            source.Url = row["Url"] + "";
            return source;
        }

        public Dictionary<string, string> GetRemoteDictionary()
        {
            var dic = new Dictionary<string, string>();
            var list = GetAllHostsSource();
            if (list != null)
            {
                list = list.Where(d => d.IsEnabled == 1).OrderBy(d => d.Id).ToList();
                foreach (var hostsSource in list)
                {
                    var d = ExtentionClass.DownloaHosts(hostsSource.Url);
                    foreach (KeyValuePair<string, string> pair in d)
                    {
                        if (!dic.ContainsKey(pair.Key))
                        {
                            dic.Add(pair.Key, pair.Value);
                        }
                    }

                }
            }
            return dic;
        }

        /// <summary>
        /// 写入远程hosts配置缓存
        /// </summary>
        /// <param name="dictionary"></param>
        public void WriteRemoteDicBak(Dictionary<string, string> dictionary)
        {
            ExtentionClass.WriteBinary(dictionary, ExtentionClass.ApplicationPath + "remote.bak");
        }

        /// <summary>
        /// 读取缓存的远程hosts配置
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> ReadRemoteDicBak()
        {
            return ExtentionClass.ReadBinary<Dictionary<string, string>>(ExtentionClass.ApplicationPath + "remote.bak");
        }
    }
}
