namespace HostsManageTool.Nirvana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mg2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IpHosts", "Ip_IpAddress", "dbo.Ips");
            DropForeignKey("dbo.IpHosts", "Host_HostName", "dbo.Hosts");
            DropIndex("dbo.IpHosts", new[] { "Ip_IpAddress" });
            DropIndex("dbo.IpHosts", new[] { "Host_HostName" });
            AddColumn("dbo.Hosts", "TargetIp_IpAddress", c => c.String(maxLength: 128));
            CreateIndex("dbo.Hosts", "TargetIp_IpAddress");
            AddForeignKey("dbo.Hosts", "TargetIp_IpAddress", "dbo.Ips", "IpAddress");
            DropTable("dbo.IpHosts");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IpHosts",
                c => new
                    {
                        Ip_IpAddress = c.String(nullable: false, maxLength: 128),
                        Host_HostName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Ip_IpAddress, t.Host_HostName });
            
            DropForeignKey("dbo.Hosts", "TargetIp_IpAddress", "dbo.Ips");
            DropIndex("dbo.Hosts", new[] { "TargetIp_IpAddress" });
            DropColumn("dbo.Hosts", "TargetIp_IpAddress");
            CreateIndex("dbo.IpHosts", "Host_HostName");
            CreateIndex("dbo.IpHosts", "Ip_IpAddress");
            AddForeignKey("dbo.IpHosts", "Host_HostName", "dbo.Hosts", "HostName", cascadeDelete: true);
            AddForeignKey("dbo.IpHosts", "Ip_IpAddress", "dbo.Ips", "IpAddress", cascadeDelete: true);
        }
    }
}
