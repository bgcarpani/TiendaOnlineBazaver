namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProductsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Productos",
                c => new
                    {
                        ProductoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 100),
                        CategoriaId = c.Int(nullable: false),
                        ColorId = c.Int(nullable: false),
                        PrecioMin = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PrecioMay = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Image = c.String(),
                        Stock = c.Double(nullable: false),
                        Codigo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductoId)
                .ForeignKey("dbo.Categorias", t => t.CategoriaId)
                .ForeignKey("dbo.Colors", t => t.ColorId)
                .Index(t => t.CategoriaId)
                .Index(t => t.ColorId)
                .Index(t => t.Codigo, unique: true, name: "IX_Products_Codigo");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "ColorId", "dbo.Colors");
            DropForeignKey("dbo.Productos", "CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Productos", "IX_Products_Codigo");
            DropIndex("dbo.Productos", new[] { "ColorId" });
            DropIndex("dbo.Productos", new[] { "CategoriaId" });
            DropTable("dbo.Productos");
        }
    }
}
