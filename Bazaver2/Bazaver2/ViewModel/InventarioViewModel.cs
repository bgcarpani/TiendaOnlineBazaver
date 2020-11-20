using Bazaver2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bazaver2.ViewModel
{
    public class InventarioViewModel
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
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

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Index("IX_Products_Codigo", Order = 1, IsUnique = true)]
        [StringLength(100, ErrorMessage = "El campo debe estar entre {2} y {1} caracteres")]
        public string Codigo { get; set; }

        public List<Inventario> InventarioList { get; set; }

        public virtual Categoria Categoria { get; set; }
        public int ColorId { get; set; }

        public double Stock { get; set; }

        public Color Color { get; set; }
        public Productos Productos { get; set; }
    }
}