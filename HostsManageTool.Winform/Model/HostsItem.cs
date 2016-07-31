using System.Data;

namespace HostsManageTool.Winform.Model
{
    /// <summary>
    /// host指向
    /// </summary>
    public class HostsItem
    {
        /// <summary>
        /// Ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 主机名
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// DataRow转实体
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        public static HostsItem DataRowToHostsItem(DataRow row)
        {
            var item = new HostsItem();
            item.IpAddress = row["IpAddress"] + "";
            item.HostName = row["HostName"] + "";
            return item;
        }
    }
}
