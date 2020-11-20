namespace Bazaver2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateVentasTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ventas",
                c => new
                    {
                        VentaId = c.Int(nullable: false, identity: true),
                        NombreCliente = c.String(nullable: false, maxLength: 50),
                        ApellidoCliente = c.String(nullable: false, maxLength: 50),
                        LocalidadId = c.Int(nullable: false),
                        Direccion = c.String(nullable: false, maxLength: 50),
                        Comentarios = c.String(),
                        Telefono = c.String(nullable: false, maxLength: 50),
                        Correo = c.String(),
                        Fecha = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VentaId)
                .ForeignKey("dbo.Localidads", t => t.LocalidadId)
                .Index(t => t.LocalidadId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ventas", "LocalidadId", "dbo.Localidads");
            DropIndex("dbo.Ventas", new[] { "LocalidadId" });
            DropTable("dbo.Ventas");
        }
    }
}
