﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool.Nirvana.Models
{
    /// <summary>
    /// 主机名
    /// </summary>
    public class Host
    {
        /// <inheritdoc />
        public Host()
        {
        }

        /// <inheritdoc />
        public Host(string hostName)
        {
            HostName = hostName;
        }

        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string HostName { get; set; }

        public virtual Ip TargetIp { get; set; }
    }

}
