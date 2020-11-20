namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateColorsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colors",
                c => new
                    {
                        ColorId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ColorId)
                .Index(t => t.Nombre, unique: true, name: "XI_Colors_Nombre");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Colors", "XI_Colors_Nombre");
            DropTable("dbo.Colors");
        }
    }
}
