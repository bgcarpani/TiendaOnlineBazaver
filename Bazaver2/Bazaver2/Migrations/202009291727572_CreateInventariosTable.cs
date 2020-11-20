namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInventariosTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productos", "ColorId", "dbo.Colors");
            DropIndex("dbo.Productos", new[] { "ColorId" });
            AddColumn("dbo.DetallesVentas", "ColorId", c => c.Int(nullable: false));
            AddColumn("dbo.DetallesVentaTMPs", "ColorId", c => c.Int(nullable: false));
            DropColumn("dbo.Productos", "ColorId");
            DropColumn("dbo.Productos", "Stock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Stock", c => c.Double(nullable: false));
            AddColumn("dbo.Productos", "ColorId", c => c.Int(nullable: false));
            DropColumn("dbo.DetallesVentaTMPs", "ColorId");
            DropColumn("dbo.DetallesVentas", "ColorId");
            CreateIndex("dbo.Productos", "ColorId");
            AddForeignKey("dbo.Productos", "ColorId", "dbo.Colors", "ColorId");
        }
    }
}
