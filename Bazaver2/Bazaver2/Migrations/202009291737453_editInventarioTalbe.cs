namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editInventarioTalbe : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Inventarios", "Stock", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Inventarios", "Stock", c => c.Int(nullable: false));
        }
    }
}
