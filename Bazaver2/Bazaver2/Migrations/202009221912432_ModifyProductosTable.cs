namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyProductosTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productos", "Color_ColorId1", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color_ColorId2", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color_ColorId3", "dbo.Colors");
            DropIndex("dbo.Productos", new[] { "Color_ColorId2" });
            DropIndex("dbo.Productos", new[] { "Color_ColorId3" });
            DropIndex("dbo.Productos", new[] { "Color_ColorId4" });
       
        
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Color_ColorId3", c => c.Int());
            AddColumn("dbo.Productos", "Color_ColorId2", c => c.Int());
            RenameColumn(table: "dbo.Productos", name: "Color_ColorId1", newName: "Color_ColorId4");
            AddColumn("dbo.Productos", "Color_ColorId1", c => c.Int());
            CreateIndex("dbo.Productos", "Color_ColorId4");
            CreateIndex("dbo.Productos", "Color_ColorId3");
            CreateIndex("dbo.Productos", "Color_ColorId2");
            AddForeignKey("dbo.Productos", "Color_ColorId3", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color_ColorId2", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color_ColorId1", "dbo.Colors", "ColorId");
        }
    }
}
