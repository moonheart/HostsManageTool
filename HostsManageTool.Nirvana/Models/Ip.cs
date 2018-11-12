using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool.Nirvana.Models
{
    /// <summary>
    /// Ip地址
    /// </summary>
    public class Ip
    {
        [Key]
        public string IpAddress { get; set; }
        public virtual ICollection<Host> Hosts { get; set; }
    }
}
