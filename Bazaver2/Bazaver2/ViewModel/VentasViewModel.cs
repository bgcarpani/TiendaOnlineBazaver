using Bazaver2.Models;
using MercadoPago.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.ViewModel
{
    public class VentasViewModel
    {

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
        [Display(Name = "Comentarios")]
        public string Comentarios { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "The field {0} is required")]
        [DataType(DataType.DateTime)]
        public DateTime Fecha { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Correo electrónico")]
        public string Correo { get; set; }

        public List<Cliente> clienteList { get; set; }

        public string PreferenciaId { get; set; }
        public Preference Preference { get; set; }

        public List<Venta> VentasList { get; set; }

        public List<CajaDiaria> cajaDiarias { get; set; }
        public List<CajaMensual> cajaMensuals { get; set; }

        public List<CajaTotal> cajaTotals { get; set; }
        public Localidad Localidad { get; set; }
        public List<DetallesVentaTMP> DetallesVentas2 { get; set; }

        public List<DetallesVenta> DetallesVentas { get; set; }

        public double TotalQuantity { get { return DetallesVentas2 == null ? 0 : DetallesVentas2.Sum(d => d.Cantidad); } }

        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = true)]
        public decimal TotalValue { get { return DetallesVentas2 == null ? 0 : DetallesVentas2.Sum(d => d.ValorTotal); } }

        public decimal TotalValueMay { get { return DetallesVentas2 == null ? 0 : DetallesVentas2.Sum(d => d.ValorTotalMay); } }

        public double TotalQuantity2 { get { return DetallesVentas == null ? 0 : DetallesVentas.Sum(d => d.Cantidad); } }

        //[DisplayFormat(DataFormatString = "{0:C2", ApplyFormatInEditMode = true)]
        public decimal TotalValue2 { get { return DetallesVentas == null ? 0 : DetallesVentas.Sum(d => d.ValorTotal); } }

        //[DisplayFormat(DataFormatString = "{0:N2", ApplyFormatInEditMode = true)]


        /// <summary>
        /// ////////////////////////////////////////////////////////
        /// </summary>

    }
}