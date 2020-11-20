using Bazaver2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bazaver2.ViewModel
{
    [NotMapped]
    public class ProductoViewModel : Productos
    {
    
        public HttpPostedFileBase ImageFile { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public int Stock { get; set; }

        public virtual Color Colores { get; set; }
        public SelectList Colors { get; set; }

    }
}