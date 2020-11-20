using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bazaver2.Models
{
    public class Localidad
    {
        [Key]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("IX_Localidads_ProvinciaId_Name", IsUnique = true, Order = 2)]
        [Display(Name = "Localidad")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You must select a department")]
        [Index("IX_Localidads_ProvinciaId_Name", IsUnique = true, Order = 1)]
        [Display(Name = "Provincia")]
        [Range(1, int.MaxValue, ErrorMessage = "You must select a Department")]
        public int ProvinciaId { get; set; }

        public virtual Provincia Provincia { get; set; }
        public virtual ICollection<Venta> Ventas { get; set; }
    }
}