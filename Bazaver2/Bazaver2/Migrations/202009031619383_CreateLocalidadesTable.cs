namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateLocalidadesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Localidads",
                c => new
                    {
                        LocalidadId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ProvinciaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LocalidadId)
                .ForeignKey("dbo.Provincias", t => t.ProvinciaId)
                .Index(t => new { t.ProvinciaId, t.Name }, unique: true, name: "IX_Localidads_ProvinciaId_Name");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Localidads", "ProvinciaId", "dbo.Provincias");
            DropIndex("dbo.Localidads", "IX_Localidads_ProvinciaId_Name");
            DropTable("dbo.Localidads");
        }
    }
}
