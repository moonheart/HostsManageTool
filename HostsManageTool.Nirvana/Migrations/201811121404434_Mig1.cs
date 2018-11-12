namespace HostsManageTool.Nirvana.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hosts",
                c => new
                    {
                        HostName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.HostName);
            
            CreateTable(
                "dbo.Ips",
                c => new
                    {
                        IpAddress = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.IpAddress);
            
            CreateTable(
                "dbo.IpHosts",
                c => new
                    {
                        Ip_IpAddress = c.String(nullable: false, maxLength: 128),
                        Host_HostName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Ip_IpAddress, t.Host_HostName })
                .ForeignKey("dbo.Ips", t => t.Ip_IpAddress, cascadeDelete: true)
                .ForeignKey("dbo.Hosts", t => t.Host_HostName, cascadeDelete: true)
                .Index(t => t.Ip_IpAddress)
                .Index(t => t.Host_HostName);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IpHosts", "Host_HostName", "dbo.Hosts");
            DropForeignKey("dbo.IpHosts", "Ip_IpAddress", "dbo.Ips");
            DropIndex("dbo.IpHosts", new[] { "Host_HostName" });
            DropIndex("dbo.IpHosts", new[] { "Ip_IpAddress" });
            DropTable("dbo.IpHosts");
            DropTable("dbo.Ips");
            DropTable("dbo.Hosts");
        }
    }
}
