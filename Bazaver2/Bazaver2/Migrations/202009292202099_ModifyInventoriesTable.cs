namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyInventoriesTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Inventarios");
            AddColumn("dbo.Inventarios", "InventarioId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Inventarios", "InventarioId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Inventarios");
            DropColumn("dbo.Inventarios", "InventarioId");
            AddPrimaryKey("dbo.Inventarios", new[] { "ProductoId", "ColorId" });
        }
    }
}
