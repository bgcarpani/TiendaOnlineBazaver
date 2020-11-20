using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Bazaver2DbContext:DbContext
    {
        public Bazaver2DbContext() : base("DefaultConnection")
        {

        }

        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<FormaDePago> FormaDePagos { get; set; }
        public DbSet<Localidad> Localidads { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Productos> Productos { get; set; }

        public DbSet<Venta> Ventas  { get; set; }
        public DbSet<DetallesVenta> DetallesVentas { get; set; }

        public DbSet<DetallesVentaTMP> DetallesVentaTMPs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}