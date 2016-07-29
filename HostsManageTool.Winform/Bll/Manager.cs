using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HostsManageTool.Winform.Model;

namespace HostsManageTool.Winform.Bll
{
    public class Manager
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

        private static Manager _in = new Manager();
        public static Manager Instance { get { return _in; } }
        private Manager()
        {

        }

        #region 主机名

        public HostName FindHostNameById(int id)
        {
            var sql = $"select * from hostname where id = {id}";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).FirstOrDefault();
        }

        public HostIp FindRedirectByHostName(HostName hostName)
        {
            var sql = $"select t2.* from HostToIp t1, HostIp t2 where t1.IpId=t2.Id and t1.NameId={hostName.Id} ";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
        }

        /// <summary>
        /// 添加Ip指向主机
        /// </summary>
        /// <param name="hostName"></param>
        /// <param name="ip"></param>
        /// <exception cref="ItemNotFoundException">未找到</exception>
        /// <exception cref="ItemOperationFaildException">操作失败</exception>
        /// <returns></returns>
        public int AddHostIpToHostName(HostName hostName, string ip)
        {
            hostName = FindHostNameById(hostName.Id);
            if (hostName == null)
            {
                throw new ItemNotFoundException();
            }
            var hostip = AddHostIp(new HostIp() { IpAddress = ip });
            if (hostip == null)
            {
                throw new ItemOperationFaildException();
            }
            return AddHostDirect(hostName, hostip);
        }

        /// <summary>
        /// 添加主机名
        /// </summary>
        /// <param name="name"></param>
        /// <exception cref="ItemAlreadyExitedException">已存在相同的主机名</exception>
        /// <returns></returns>
        public HostName AddHostName(HostName name)
        {
            var sql1 = string.Format("select Id from hostname where name='{0}' limit 1", name.Name);
            var obj = Helper.ExecuteScalar(sql1);
            int id;
            int.TryParse(obj + "", out id);
            if (id > 0)
            {
                throw new ItemAlreadyExitedException();
            }
            var sql = $"insert into hostname(Name) values('{name.Name}')";
            var n = Helper.Execute(sql);
            if (n < 0)
            {
                return null;
            }
            sql = $"select * from hostname where name='{name.Name}'";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).FirstOrDefault();
        }

        /// <summary>
        /// 移除主机名(如果有指向同时移除指向)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int RemoveHostName(HostName name)
        {
            var sql = $"delete from hostname where id={name.Id};" +
                      $"delete from hosttoip where nameid={name.Id}";
            return Helper.Execute(sql);
        }

        /// <summary>
        /// 获取所有主机名
        /// </summary>
        /// <returns></returns>
        public List<HostName> GetAllHostNames()
        {
            var sql = "select * from hostname";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).ToList();
        }

        #endregion

        #region 指向

        /// <summary>
        /// 添加或更新host指向
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ip"></param>
        /// <returns></returns>
        public int AddHostDirect(HostName name, HostIp ip)
        {
            //先查找
            var sql = string.Format("select * from HostToIp where NameId={0}", name.Id);
            var dt = Helper.Select(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                sql = string.Format("update hosttoip set Ipid={0} where NameId={1}", ip.Id, name.Id);
            }
            else
            {
                sql = string.Format("insert into HostToIp(NameId,IpId) values({0},{1})", name.Id, ip.Id);
            }
            return Helper.Execute(sql);
        }

        /// <summary>
        /// 移除host指向
        /// </summary>
        /// <param name="hostName"></param>
        public void RemoveHostDirect(HostName hostName)
        {
            var sql = string.Format("delete from HostToIp where NameId={0}", hostName.Id);
            var n = Helper.Execute(sql);
        }

        #endregion

        #region Ip

        /// <summary>
        /// 获取所有Ip
        /// </summary>
        /// <returns></returns>
        public List<HostIp> GetAllHostIps()
        {
            var sql = "select * from hostip";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).ToList();
        }

        /// <summary>
        /// 添加ip地址
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public HostIp AddHostIp(HostIp ip)
        {
            var conn = new SQLiteCommand(new SQLiteConnection(ExtentionClass.ConnectinString));
            conn.Connection.Open();
            var h = new SQLiteHelper(conn);

            var sql = string.Format("insert into hostip(IpAddress) values('{0}')", ip.IpAddress);
            var n = h.Execute(sql);
            if (n > 0)
            {
                sql = "select last_insert_rowid() as Id from hostip;";
                var id = h.ExecuteScalar<int>(sql);

                sql = string.Format("select * from hostip where id = {0}", id);
                var dt = h.Select(sql);
                return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
            }
            return null;
        }

        #endregion


        public HostName DataRowToHostName(DataRow row)
        {
            var name = new HostName();
            name.Id = int.Parse(row["Id"] + "");
            name.Name = row["Name"] + "";
            return name;
        }
        public HostIp DataRowToHostIp(DataRow row)
        {
            var ip = new HostIp();
            ip.Id = int.Parse(row["Id"] + "");
            ip.IpAddress = row["IpAddress"] + "";
            return ip;
        }
        public HostToIp DataRowToHostToIp(DataRow row)
        {
            var ip = new HostToIp();
            ip.IpId = int.Parse(row["IpId"] + "");
            ip.NameId = int.Parse(row["NameId"] + "");
            return ip;
        }
    }
}
