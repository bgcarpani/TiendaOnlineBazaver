using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Color
    {
        [Key]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("XI_Colors_Nombre", IsUnique = true)]
        [Display(Name = "Color")]
        public string Nombre { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }

        public virtual ICollection<DetallesVenta> DetallesVentas { get; set; }
        public virtual ICollection<DetallesVentaTMP> DetallesVentaTMPs { get; set; }

    }
}