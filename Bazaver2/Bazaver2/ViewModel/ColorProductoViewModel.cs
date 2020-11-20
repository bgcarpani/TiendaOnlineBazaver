using Bazaver2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.ViewModel
{
    public class ColorProductoViewModel
    {

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ProductoId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int ColorId { get; set; }


        [Required(ErrorMessage = "El campo {0} es requerido")]
        public double Stock { get; set; }

        public List<Inventario> InventarioList { get; set; }

        public List<Productos> ProductsList { get; set; }

        public List<Color> ColorsList { get; set; }

        public Color Color { get; set; }
        public Productos Productos { get; set; }
    }
}