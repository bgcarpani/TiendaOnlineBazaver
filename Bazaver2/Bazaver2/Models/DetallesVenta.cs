using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class DetallesVenta
    {
        [Key]
        public int DetallesVentaId { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        [Display(Name = "Producto")]
        public string Descripcion { get; set; }


        [Required(ErrorMessage = "El camapo {0} es requerido")]
        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = false)]
        [Range(0, Int32.MaxValue, ErrorMessage = "Debe ingresar un {0} entre {2} y {1}")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        //[DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = false)]
        [Range(0, Int32.MaxValue, ErrorMessage = "Debe ingresar una {0} entre {2} y {1}")]
        public double Cantidad { get; set; }

        public virtual Productos Productos { get; set; }

        public virtual Venta Venta { get; set; }

        public virtual Color Color { get; set; }

        public decimal ValorTotal { get { return Precio * (decimal)Cantidad; } }
    }
}