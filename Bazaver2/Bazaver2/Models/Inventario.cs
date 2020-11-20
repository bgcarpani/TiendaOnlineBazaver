using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Inventario
    {
        [Key]
        [Column(Order = 1)]
        [Required(ErrorMessage = "Campo requerido")]
        public int InventarioId { get; set; }

        [Column(Order=2)]
        [Required(ErrorMessage = "Campo requerido")]
        public int ProductoId { get; set; }

        [Column(Order = 3)]
        [Required(ErrorMessage = "Campo requerido")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public double Stock { get; set; }


        public virtual Productos Productos { get; set; }

        public virtual Color Color { get; set; }
    }
}