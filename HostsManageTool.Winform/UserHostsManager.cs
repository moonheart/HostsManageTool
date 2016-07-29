//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.SQLite;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using HostsManageTool.Winform;

//namespace HostsManageTool
//{
//    public class UserHostsManager
//    {

//        /// <summary>
//        /// 插入一条hosts
//        /// </summary>
//        /// <param name="hosts"></param>
//        /// <returns></returns>
//        public static int InsertUserHosts(UserHosts hosts)
//        {
//            var sql1 = string.Format("select Id from hosts where hostname = '{0}' LIMIT 1", hosts.HostName);
//            var obj = ExtentionClass.SqLiteHelper.ExecuteScalar(sql1);
//            int id;
//            int.TryParse(obj + "", out id);
//            if (id > 0)
//            {
//                throw new Exception("该主机名已存在");
//            }
//            var sql = string.Format("insert into hosts (HostName,Ip,IsInUse) values('{0}','{1}',{2})"
//                , hosts.HostName, hosts.Ip, hosts.IsInUse);
//            return ExtentionClass.SqLiteHelper.Execute(sql);
//            //throw new NotImplementedException();
//        }

//        public static UserHosts FindById(int id)
//        {
//            var sql = string.Format("select * from hosts where Id = {0} limit 1", id);
//            var dt = ExtentionClass.SqLiteHelper.Select(sql);
//            return dt?.AsEnumerable().Select(ExtentionClass.DataRowToUserHosts).FirstOrDefault();
//        }

//        /// <summary>
//        /// 插入多条hosts
//        /// </summary>
//        /// <param name="hostsList"></param>
//        /// <returns></returns>
//        public static int InsertUserHostsList(List<UserHosts> hostsList)
//        {
//            throw new NotImplementedException();
//        }


//        /// <summary>
//        /// 删除一条hosts
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public static int DeleteUserHosts(int id)
//        {
//            throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 通过主机名查找hosts
//        /// </summary>
//        /// <param name="hostName"></param>
//        /// <returns></returns>
//        public static List<UserHosts> FindHostsListByHostName(string hostName)
//        {
//            var sql = string.Format("select * from hosts where hostname = '{0}'", hostName);
//            var dt = ExtentionClass.SqLiteHelper.Select(sql);
//            return dt?.AsEnumerable().Select(ExtentionClass.DataRowToUserHosts).ToList();
//            //throw new NotImplementedException();
//        }

//        /// <summary>
//        /// 获取所有用户Hosts
//        /// </summary>
//        /// <returns></returns>
//        public static List<UserHosts> GetAllHosts()
//        {
//            var sql = "select * from Hosts";
//            var dt = ExtentionClass.SqLiteHelper.Select(sql);
//            return dt?.AsEnumerable().Select(ExtentionClass.DataRowToUserHosts).ToList();
//            //throw new NotImplementedException();
//        }


//        /// <summary>
//        /// 将一条hosts设置为使用中
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public static int SetHostsInUse(int id)
//        {
//            throw new NotImplementedException();
//        }

//        public static List<UserHosts> DownloadHosts(string url)
//        {
//            throw new NotImplementedException();
//        }

//    }
//}
