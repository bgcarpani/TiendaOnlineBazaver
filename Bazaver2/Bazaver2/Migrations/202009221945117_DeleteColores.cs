namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteColores : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Productos", "ColorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Productos", "ColorId");
            AddForeignKey("dbo.Productos", "ColorId", "dbo.Colors", "ColorId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Productos", "ColorId", "dbo.Colors");
            DropIndex("dbo.Productos", new[] { "ColorId" });
            DropColumn("dbo.Productos", "ColorId");
        }
    }
}
