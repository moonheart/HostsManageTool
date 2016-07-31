using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using HostsManageTool.Winform.Model;
using HostsManageTool.Winform.Sqlite;

namespace HostsManageTool.Winform.Bll
{
    public class UserHostManager
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

        /// <summary>
        /// 获取单例
        /// </summary>
        public static UserHostManager Instance { get; } = new UserHostManager();

        private UserHostManager()
        {

        }

        #region 主机名
        
        /// <summary>
        /// 通过Id查找主机名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HostName FindHostNameById(int id)
        {
            var sql = $"select * from hostname where id = {id}";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostName).FirstOrDefault();
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
            var sql1 = $"select Id from hostname where name='{name.Name}' limit 1";
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
            var sql = $"select * from HostToIp where NameId={name.Id}";
            var dt = Helper.Select(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                sql = $"update hosttoip set Ipid={ip.Id} where NameId={name.Id}";
            }
            else
            {
                sql = $"insert into HostToIp(NameId,IpId) values({name.Id},{ip.Id})";
            }
            return Helper.Execute(sql);
        }

        /// <summary>
        /// 移除host指向
        /// </summary>
        /// <param name="hostName"></param>
        public int RemoveHostDirect(HostName hostName)
        {
            var sql = $"delete from HostToIp where NameId={hostName.Id}";
            return Helper.Execute(sql);
        }

        #endregion

        #region Ip

        /// <summary>
        /// 通过主机名查找Ip
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public HostIp FindRedirectByHostName(HostName hostName)
        {
            var sql = $"select t2.* from HostToIp t1, HostIp t2 where t1.IpId=t2.Id and t1.NameId={hostName.Id} ";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
        }
        /// <summary>
        /// 通过Id查找Ip
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public HostIp FindHostIpById(int id)
        {
            var sql = $"select * from hostip where id= {id}";
            var dt = Helper.Select(sql);
            return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
        }

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

            var sql = $"insert into hostip(IpAddress) values('{ip.IpAddress}')";
            var n = h.Execute(sql);
            if (n > 0)
            {
                sql = "select last_insert_rowid() as Id from hostip;";
                var id = h.ExecuteScalar<int>(sql);

                sql = $"select * from hostip where id = {id}";
                var dt = h.Select(sql);
                return dt?.AsEnumerable().Select(DataRowToHostIp).FirstOrDefault();
            }
            return null;
        }

        /// <summary>
        /// 删除Ip
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ItemNotFoundException"></exception>
        /// <returns></returns>
        public int RemoveHostIp(int id)
        {
            var hostip = FindHostIpById(id);
            if (hostip == null)
            {
                throw new ItemNotFoundException();
            }
            var sql = $"delete from hostip where id = {hostip.Id};";
            sql += $"delete from hosttoip where IpId={hostip.Id};";
            return Helper.Execute(sql);
        }


        #endregion


        public HostName DataRowToHostName(DataRow row)
        {
            var name = new HostName
            {
                Id = int.Parse(row["Id"] + ""),
                Name = row["Name"] + ""
            };
            return name;
        }

        public HostIp DataRowToHostIp(DataRow row)
        {
            var ip = new HostIp
            {
                Id = int.Parse(row["Id"] + ""),
                IpAddress = row["IpAddress"] + ""
            };
            return ip;
        }

        public HostToIp DataRowToHostToIp(DataRow row)
        {
            var ip = new HostToIp
            {
                IpId = int.Parse(row["IpId"] + ""),
                NameId = int.Parse(row["NameId"] + "")
            };
            return ip;
        }

        /// <summary>
        /// 获取用户hosts指向字典
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> GetUserDictionary()
        {
            var dic = new Dictionary<string, string>();
            var sql =
@"SELECT t3.IpAddress as IpAddress,
       t2.Name as HostName
  FROM HostToIp t1
       LEFT OUTER JOIN
       HostName t2 ON t1.NameId = t2.Id
       LEFT OUTER JOIN
       HostIp t3 ON t1.IpId = t3.Id;
 ";
            var dt = Helper.Select(sql);
            var list = dt?.AsEnumerable().Select(HostsItem.DataRowToHostsItem);
            if (list != null)
            {
                foreach (var hostsItem in list)
                {
                    if (!dic.ContainsKey(hostsItem.HostName))
                        dic.Add(hostsItem.HostName, hostsItem.IpAddress);
                }
            }
            return dic;
        }


    }
}
