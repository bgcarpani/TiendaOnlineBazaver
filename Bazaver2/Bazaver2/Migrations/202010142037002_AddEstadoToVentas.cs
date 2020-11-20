namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEstadoToVentas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ventas", "Estado", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ventas", "Estado");
        }
    }
}
