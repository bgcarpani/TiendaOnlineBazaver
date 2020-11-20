using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [StringLength(50, ErrorMessage = "The field must have between {2} and {1} characters", MinimumLength = 3)]
        [Display(Name = "Categoría")]
        [Index("IX_Categorias_Descripcion", Order = 2, IsUnique = true)]
        public string Descripcion { get; set; }

        public virtual ICollection<Productos> Productos { get; set; }
    }
}