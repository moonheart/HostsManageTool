using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool
{
    /// <summary>
    /// 用户自定义Hosts
    /// </summary>
    public class UserHosts
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 主机名
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Ip地址
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// 当前hosts是否使用
        /// 1 表示使用中
        /// </summary>
        public int IsInUse { get; set; }
    }
}
