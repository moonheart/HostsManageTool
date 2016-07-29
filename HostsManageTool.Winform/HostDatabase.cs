using HostsManageTool.Winform.Model;

namespace HostsManageTool.Winform
{
    using System.Data.Entity;

    public partial class HostDatabase : DbContext
    {
        public HostDatabase()
            : base("name=HostDatabase")
        {
        }

        public virtual DbSet<HostIp> HostIp { get; set; }
        public virtual DbSet<HostName> HostName { get; set; }
        public virtual DbSet<HostsSource> HostsSource { get; set; }

        public virtual DbSet<HostToIp> HostToIp { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HostIp>()
                .Property(e => e.IpAddress)
                .IsUnicode(false);

            modelBuilder.Entity<HostName>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HostsSource>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<HostsSource>()
                .Property(e => e.Url)
                .IsUnicode(false);
        }
    }
}
