using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class DetallesVentaTMP
    {
        public int DetallesVentaTmpId { get; set; }

        public Guid CartId { get; set; }

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
        [Range(0, double.MaxValue, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "El camapo {0} es requerido")]
        //[DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "El campo {0} debe tener un máximo de {1} caracteres")]
        public double Cantidad { get; set; }

 
        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = false)]
        public decimal ValorTotal { get { return Product.PrecioMin * (decimal)Cantidad; } }

        public decimal ValorTotalMay { get { return Product.PrecioMay * (decimal)Cantidad; } }


        public virtual Productos Product { get; set; }

        public virtual Color Color { get; set; }
    }
}