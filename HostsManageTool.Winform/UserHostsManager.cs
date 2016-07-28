using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool
{
    public class UserHostsManager
    {

        /// <summary>
        /// 插入一条hosts
        /// </summary>
        /// <param name="hosts"></param>
        /// <returns></returns>
        public static int InsertUserHosts(UserHosts hosts)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 插入多条hosts
        /// </summary>
        /// <param name="hostsList"></param>
        /// <returns></returns>
        public static int InsertUserHostsList(List<UserHosts> hostsList)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 删除一条hosts
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int DeleteUserHosts(int id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 通过主机名查找hosts
        /// </summary>
        /// <param name="hostName"></param>
        /// <returns></returns>
        public static List<UserHosts> FindHostsListByHostName(string hostName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取所有用户Hosts
        /// </summary>
        /// <returns></returns>
        public static List<UserHosts> GetAllHosts()
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 将一条hosts设置为使用中
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static int SetHostsInUse(int id)
        {
            throw new NotImplementedException();
        }

        public static List<UserHosts> DownloadHosts(string url)
        {
            throw new NotImplementedException();
        }

    }
}
