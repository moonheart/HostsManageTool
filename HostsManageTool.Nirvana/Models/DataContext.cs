using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostsManageTool.Nirvana.Models
{
    public class DataContext : DbContext
    {
        public DataContext() : base("HostManageTool")
        {
            this.Database.Log = s =>
            {
                try
                {
                    File.AppendAllText("database.log", s);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            };
        }

        public DbSet<Ip> Ips { get; set; }
        public DbSet<Host> Hosts { get; set; }
    }
}
