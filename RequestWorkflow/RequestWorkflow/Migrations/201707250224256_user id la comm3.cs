namespace RequestWorkflow.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridlacomm3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "EmailComm", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "EmailComm");
        }
    }
}
