namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateFormaDePagosTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormaDePagoes",
                c => new
                    {
                        FormaDePagoId = c.Int(nullable: false, identity: true),
                        Descripcion = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.FormaDePagoId)
                .Index(t => t.Descripcion, unique: true, name: "XI_FormaDePagos_Descripcion");
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FormaDePagoes", "XI_FormaDePagos_Descripcion");
            DropTable("dbo.FormaDePagoes");
        }
    }
}
