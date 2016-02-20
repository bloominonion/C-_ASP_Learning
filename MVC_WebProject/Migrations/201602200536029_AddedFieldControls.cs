namespace MVC_WebProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFieldControls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FieldControls",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ControlName = c.String(),
                        Control1 = c.String(),
                        Control2 = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FieldControls");
        }
    }
}
