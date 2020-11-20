namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateProvinciasTable : DbMigration
    {
        public override void Up()
        {
           
            CreateTable(
                "dbo.Provincias",
                c => new
                    {
                        ProvinciaId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ProvinciaId)
                .Index(t => t.Nombre, unique: true, name: "XI_Provincias_Nombre");
            
            
        }
        
        public override void Down()
        {
            
            DropIndex("dbo.Provincias", "XI_Provincias_Nombre");
            DropTable("dbo.Provincias");
           
        }
    }
}
