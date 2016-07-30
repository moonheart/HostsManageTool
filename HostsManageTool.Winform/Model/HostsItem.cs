using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool.Winform.Model
{
    public class HostsItem
    {
        public string IpAddress { get; set; }

        public string HostName { get; set; }

        public static HostsItem DataRowToHostsItem(DataRow row)
        {
            var item = new HostsItem();
            item.IpAddress = row["IpAddress"] + "";
            item.HostName = row["HostName"] + "";
            return item;
        }
    }
}
