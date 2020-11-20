namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class QuitarColores : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Productos", "Color_ColorId", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color_ColorId1", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color2_ColorId", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color3_ColorId", "dbo.Colors");
            DropForeignKey("dbo.Productos", "Color4_ColorId", "dbo.Colors");
            DropIndex("dbo.Productos", new[] { "Color_ColorId" });
            DropIndex("dbo.Productos", new[] { "Color_ColorId1" });
            DropIndex("dbo.Productos", new[] { "Color2_ColorId" });
            DropIndex("dbo.Productos", new[] { "Color3_ColorId" });
            DropIndex("dbo.Productos", new[] { "Color4_ColorId" });
            //DropColumn("dbo.Productos", "ColorId1");
            //DropColumn("dbo.Productos", "ColorId2");
            //DropColumn("dbo.Productos", "ColorId3");
            //DropColumn("dbo.Productos", "ColorId4");
            //DropColumn("dbo.Productos", "Color_ColorId");
            //DropColumn("dbo.Productos", "Color_ColorId1");
            //DropColumn("dbo.Productos", "Color2_ColorId");
            //DropColumn("dbo.Productos", "Color3_ColorId");
            //DropColumn("dbo.Productos", "Color4_ColorId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Productos", "Color4_ColorId", c => c.Int());
            AddColumn("dbo.Productos", "Color3_ColorId", c => c.Int());
            AddColumn("dbo.Productos", "Color2_ColorId", c => c.Int());
            AddColumn("dbo.Productos", "Color_ColorId1", c => c.Int());
            AddColumn("dbo.Productos", "Color_ColorId", c => c.Int());
            AddColumn("dbo.Productos", "ColorId4", c => c.Int(nullable: false));
            AddColumn("dbo.Productos", "ColorId3", c => c.Int(nullable: false));
            AddColumn("dbo.Productos", "ColorId2", c => c.Int(nullable: false));
            AddColumn("dbo.Productos", "ColorId1", c => c.Int(nullable: false));
            CreateIndex("dbo.Productos", "Color4_ColorId");
            CreateIndex("dbo.Productos", "Color3_ColorId");
            CreateIndex("dbo.Productos", "Color2_ColorId");
            CreateIndex("dbo.Productos", "Color_ColorId1");
            CreateIndex("dbo.Productos", "Color_ColorId");
            AddForeignKey("dbo.Productos", "Color4_ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color3_ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color2_ColorId", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color_ColorId1", "dbo.Colors", "ColorId");
            AddForeignKey("dbo.Productos", "Color_ColorId", "dbo.Colors", "ColorId");
        }
    }
}
