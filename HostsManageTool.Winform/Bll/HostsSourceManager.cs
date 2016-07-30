using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using HostsManageTool.Winform.Model;

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
        /// 插入一条hosts源
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public int InsertHostsSource(HostsSource source)
        {
            var sql =
                $"insert into hostssource (name,url,isenabled,order) values('{source.Name}','{source.Url}',{source.IsEnabled},{source.Order})";
            return Helper.Execute(sql);

            //throw new NotImplementedException();
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
        public List<HostsSource> GetHostsSourceList()
        {
            var sql = "select * from hostssource";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostsSource).ToList();

            //throw new NotImplementedException();
        }

        /// <summary>
        /// 启用项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int EnableSource(int id)
        {
            var source = FindById(id);
            if (source == null)
            {
                throw new ItemNotFoundException();
            }
            var sql = $"update hostssource set Isenabled =1 where id={id} ";
            return Helper.Execute(sql);
        }

        /// <summary>
        /// 禁用项目
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DisableSource(int id)
        {
            var source = FindById(id);
            if (source == null)
            {
                throw new ItemNotFoundException();
            }
            var sql = $"update hostssource set Isenabled =0 where id={id} ";
            return Helper.Execute(sql);
        }

        
        public HostsSource DataRowToHostsSource(DataRow row)
        {
            var source = new HostsSource();
            source.Id = int.Parse(row["Id"] + "");
            source.IsEnabled = int.Parse(row["IsEnabled"] + "");
            source.Name = row["Name"] + "";
            source.Url = row["Url"] + "";
            source.Order = int.Parse(row["Order"] + "");
            return source;
        }

    }
}
