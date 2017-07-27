namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUserEvents", "AspNetUser_Id", "dbo.AspNetUsers1");
            DropForeignKey("dbo.AspNetUserEvents", "Event_Id", "dbo.Events");
            DropIndex("dbo.AspNetUserEvents", new[] { "AspNetUser_Id" });
            DropIndex("dbo.AspNetUserEvents", new[] { "Event_Id" });
            DropTable("dbo.AspNetUsers1");
            DropTable("dbo.AspNetUserEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AspNetUserEvents",
                c => new
                    {
                        AspNetUser_Id = c.String(nullable: false, maxLength: 128),
                        Event_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.AspNetUser_Id, t.Event_Id });
            
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
            
            CreateIndex("dbo.AspNetUserEvents", "Event_Id");
            CreateIndex("dbo.AspNetUserEvents", "AspNetUser_Id");
            AddForeignKey("dbo.AspNetUserEvents", "Event_Id", "dbo.Events", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AspNetUserEvents", "AspNetUser_Id", "dbo.AspNetUsers1", "Id", cascadeDelete: true);
        }
    }
}
