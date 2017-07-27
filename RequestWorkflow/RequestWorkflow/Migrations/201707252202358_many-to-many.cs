namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class manytomany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetUsers1",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        FirstName = c.String(name: "First Name"),
                        LastName = c.String(name: "Last Name"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserEvents",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.Event_Id })
                .ForeignKey("dbo.AspNetUsers1", t => t.AspNetUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.Event_Id, cascadeDelete: true)
                .Index(t => t.AspNetUser_Id)
                .Index(t => t.Event_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserEvents", "Event_Id", "dbo.Events");
            DropForeignKey("dbo.AspNetUserEvents", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropIndex("dbo.AspNetUserEvents", new[] { "Event_Id" });
            DropIndex("dbo.AspNetUserEvents", new[] { "AspNetUser_Id" });
            DropTable("dbo.AspNetUserEvents");
            DropTable("dbo.AspNetUsers1");
        }
    }
}
