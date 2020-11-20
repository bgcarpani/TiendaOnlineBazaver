using Bazaver2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.ViewModel
{
    public class AgregarProdViewModel
    {

        public PagedList.IPagedList<Productos> AgregarProdPagedListVM { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, Int32.MaxValue, ErrorMessage = "You must select a Category")]
        [Display(Name = "Categoria")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, Double.MaxValue, ErrorMessage = "You must select a product")]
        [Display(Name = "Producto")]
        public int ProductoId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [Range(1, Double.MaxValue, ErrorMessage = "You must select a product")]
        [Display(Name = "Color")]
        public int ColorId { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {2} and {1}")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = false)]
        [Range(0, double.MaxValue, ErrorMessage = "You must enter values in {0} between {2} and {1}")]
        public double Cantidad { get; set; }


        //[Required(ErrorMessage = "Campo requerido")]
        //[StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "Nombre")]
        //public string NombreCliente { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        //[StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "Apellido")]
        //public string ApellidoCliente { get; set; }

        //[Required(ErrorMessage = "The field {0} is required")]
        //[Range(1, Int32.MaxValue, ErrorMessage = "You must select a {0}")]
        //[Display(Name = "Localidad")]
        //public int LocalidadId { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        //[StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "Direccion")]
        //public string Direccion { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Display(Name = "Comentarios")]
        //public string Comentarios { get; set; }

        //[Required(ErrorMessage = "Campo requerido")]
        //[StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        //[Display(Name = "Teléfono")]
        //public string Telefono { get; set; }

        //[Required(ErrorMessage = "The field {0} is required")]
        //[DataType(DataType.DateTime)]
        //public DateTime Fecha { get; set; }

        //[DataType(DataType.MultilineText)]
        //[Display(Name = "Correo electrónico")]
        //public string Correo { get; set; }

        public List<ProductoViewModel> ProductViewModels { get; set; }
        public List<Productos> ListaProductos { get; set; }

        public List<DetallesVenta> DetallesVentas { get; set; }

        public List<DetallesVentaTMP> DetallesVentas2 { get; set; }

        public double TotalQuantity { get { return DetallesVentas == null ? 0 : DetallesVentas.Sum(d => d.Cantidad); } }

        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = true)]
        public decimal TotalValue { get { return DetallesVentas2 == null ? 0 : DetallesVentas2.Sum(d => d.ValorTotal); } }

        public decimal TotalValueMay { get { return DetallesVentas2 == null ? 0 : DetallesVentas2.Sum(d => d.ValorTotalMay); } }

        public double TotalQuantity2 { get { return DetallesVentas == null ? 0 : DetallesVentas.Sum(d => d.Cantidad); } }

        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = true)]
        public decimal TotalValue2 { get { return DetallesVentas == null ? 0 : DetallesVentas.Sum(d => d.ValorTotal); } }
    }
}