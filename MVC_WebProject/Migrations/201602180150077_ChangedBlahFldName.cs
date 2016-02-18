namespace MVC_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedBlahFldName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "Comments", c => c.String());
            DropColumn("dbo.Movies", "blah");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "blah", c => c.String());
            DropColumn("dbo.Movies", "Comments");
        }
    }
}
