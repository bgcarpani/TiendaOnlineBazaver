namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modifyDetallesVentasTMP : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DetallesVentaTMPs", "CartId", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DetallesVentaTMPs", "CartId");
        }
    }
}
