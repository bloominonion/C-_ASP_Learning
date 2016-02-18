namespace MVC_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBlahField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "blah", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "blah");
        }
    }
}
