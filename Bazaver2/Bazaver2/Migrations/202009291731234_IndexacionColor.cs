namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IndexacionColor : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.DetallesVentas", "ColorId");
            CreateIndex("dbo.DetallesVentaTMPs", "ColorId");
            AddForeignKey("dbo.DetallesVentas", "ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.DetallesVentaTMPs", "ColorId", "dbo.Colors", "ColorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesVentaTMPs", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.DetallesVentas", "ColorId", "dbo.Colors");
            DropIndex("dbo.DetallesVentaTMPs", new[] { "ColorId" });
            DropIndex("dbo.DetallesVentas", new[] { "ColorId" });
        }
    }
}
