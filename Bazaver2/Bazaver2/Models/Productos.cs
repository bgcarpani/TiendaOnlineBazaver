using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bazaver2.Models
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(100, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Range(1, Int32.MaxValue, ErrorMessage = "Debe seleccionar una categoria")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioMin { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        //[DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal PrecioMay { get; set; }

        [DataType(DataType.ImageUrl)]
        public string Image { get; set; }


        [StringLength(100, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres")]
        public string Codigo { get; set; }

        public virtual Categoria Categoria { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> ColorId { get; set; }

        public virtual ICollection<Inventario> Inventarios { get; set; }

        public virtual ICollection<DetallesVenta> DetallesVentas { get; set; }
        public virtual ICollection<DetallesVentaTMP> DetallesVentasTmp { get; set; }
       
    }
}
