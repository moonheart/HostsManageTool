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

        public List<HostIp> GetAllHostIps()
        {
            var sql = "select * from hostip";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).ToList();
        }

        public HostName FindHostNameById(int id)
        {
            var sql = string.Format("select * from hostname where id = {0}", id);
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).FirstOrDefault();
        }

        public List<HostIp> FindHostIpListByHostName(HostName hostname)
        {
            var sql = string.Format("select t2.* from HostToIp t1, HostIp t2 where t1.IpId=t2.Id and t1.NameId={0}",
                hostname.Id);
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).ToList();
        }

        public HostIp FindEnabledForHostName(HostName hostName)
        {
            var sql =
                string.Format(
                    "select t2.* from HostToIp t1, HostIp t2 where t1.IpId=t2.Id and t1.NameId={0} and t1.IsEnabled = 1 "
                    , hostName.Id);
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
        }

        public int AddHostIpToHostName(HostName hostName, string ip)
        {
            hostName = FindHostNameById(hostName.Id);
            if (hostName == null)
            {
                throw new Exception("请选择需要指向的主机名");
            }
            var hostip = AddHostIp(new HostIp() { IpAddress = ip });
            if (hostip == null)
            {
                throw new Exception("添加Ip失败");
            }

            return AddHostToIp(hostName, hostip);
        }

        public int AddHostToIp(HostName name, HostIp ip)
        {
            //todo 先查找
            DisableAllDirect(name);

            var sql = string.Format("insert into HostToIp(NameId,IpId,IsEnabled) values({0},{1},{2})",
                name.Id, ip.Id, 1);
            return Helper.Execute(sql);
        }

        public void DisableAllDirect(HostName hostName)
        {
            var sql = string.Format("update HostToIp set IsEnabled=0 where NameId={0}", hostName.Id);
            var n = Helper.Execute(sql);
        }

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

        public int AddHostName(HostName name)
        {
            var sql1 = string.Format("select Id from hostname where name='{0}' limit 1", name.Name);
            var obj = Helper.ExecuteScalar(sql1);
            int id;
            int.TryParse(obj + "", out id);
            if (id > 0)
            {
                throw new Exception("已存在相同的主机名");
            }
            var sql = string.Format("insert into hostname(Name) values('{0}')", name.Name);
            return Helper.Execute(sql);
        }
        public List<HostName> GetAllHostNames()
        {
            var sql = "select * from hostname";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).ToList();
        }

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
            ip.IsEnabled = int.Parse(row["IsEnabled"] + "");
            return ip;
        }
    }
}
