namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDetallesVentasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallesVentas",
                c => new
                    {
                        DetallesVentaId = c.Int(nullable: false, identity: true),
                        VentaId = c.Int(nullable: false),
                        ProductoId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesVentaId)
                .ForeignKey("dbo.Productos", t => t.ProductoId)
                .ForeignKey("dbo.Ventas", t => t.VentaId)
                .Index(t => t.VentaId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesVentas", "VentaId", "dbo.Ventas");
            DropForeignKey("dbo.DetallesVentas", "ProductoId", "dbo.Productos");
            DropIndex("dbo.DetallesVentas", new[] { "ProductoId" });
            DropIndex("dbo.DetallesVentas", new[] { "VentaId" });
            DropTable("dbo.DetallesVentas");
        }
    }
}
