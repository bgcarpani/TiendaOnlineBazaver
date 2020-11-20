namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitoUsoCodigo : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Productos", "IX_Products_Codigo");
            AlterColumn("dbo.Productos", "Codigo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Productos", "Codigo", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Productos", "Codigo", unique: true, name: "IX_Products_Codigo");
        }
    }
}
