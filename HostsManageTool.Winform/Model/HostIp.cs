using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HostsManageTool.Winform.Model
{
    public class HostIp
    {
        public int Id { get; set; }

        public string IpAddress { get; set; }
    }
}
