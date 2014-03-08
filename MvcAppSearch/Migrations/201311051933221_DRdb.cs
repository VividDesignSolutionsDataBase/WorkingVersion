namespace MvcAppSearch.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DRdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inmate",
                c => new
                    {
                        InmateID = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Location = c.String(),
                        FloorNo = c.Int(nullable: false),
                        ReportDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InmateID);
            
            CreateTable(
                "dbo.Report",
                c => new
                    {
                        ReportNo = c.Int(nullable: false, identity: true),
                        InmateID = c.Int(nullable: false),
                        OfficerID = c.Int(nullable: false),
                        Status = c.Int(),
                    })
                .PrimaryKey(t => t.ReportNo)
                .ForeignKey("dbo.Officer", t => t.OfficerID, cascadeDelete: true)
                .ForeignKey("dbo.Inmate", t => t.InmateID, cascadeDelete: true)
                .Index(t => t.OfficerID)
                .Index(t => t.InmateID);
            
            CreateTable(
                "dbo.Officer",
                c => new
                    {
                        OfficerID = c.Int(nullable: false),
                        LastName = c.String(),
                        FirstName = c.String(),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.OfficerID);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Report", new[] { "InmateID" });
            DropIndex("dbo.Report", new[] { "OfficerID" });
            DropForeignKey("dbo.Report", "InmateID", "dbo.Inmate");
            DropForeignKey("dbo.Report", "OfficerID", "dbo.Officer");
            DropTable("dbo.Officer");
            DropTable("dbo.Report");
            DropTable("dbo.Inmate");
        }
    }
}
