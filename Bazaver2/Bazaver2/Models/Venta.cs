using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Venta
    {
        [Key]
        public int VentaId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string NombreCliente { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string ApellidoCliente { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You must select a {0}")]
        [Display(Name = "Localidad")]
        public int LocalidadId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Direccion")]
        public string Direccion { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Comentarios extra")]
        public string Comentarios { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0: dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }

        public string Estado { get; set; }

        public virtual Localidad Localidad { get; set; }

        public virtual ICollection<DetallesVenta> DetallesVentas { get; set; }


    }
}