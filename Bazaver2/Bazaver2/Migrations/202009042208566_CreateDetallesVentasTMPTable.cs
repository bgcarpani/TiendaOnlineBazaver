namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDetallesVentasTMPTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DetallesVentaTMPs",
                c => new
                    {
                        DetallesVentaTmpId = c.Int(nullable: false, identity: true),
                        ProductoId = c.Int(nullable: false),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Cantidad = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DetallesVentaTmpId)
                .ForeignKey("dbo.Productos", t => t.ProductoId)
                .Index(t => t.ProductoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DetallesVentaTMPs", "ProductoId", "dbo.Productos");
            DropIndex("dbo.DetallesVentaTMPs", new[] { "ProductoId" });
            DropTable("dbo.DetallesVentaTMPs");
        }
    }
}
