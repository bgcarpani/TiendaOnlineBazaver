using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class FormaDePago
    {
        [Key]
        public int FormaDePagoId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, ErrorMessage = "El campo desbe estar entre {2} y {1} caracteres", MinimumLength = 3)]
        [Index("XI_FormaDePagos_Descripcion", IsUnique = true)]
        [Display(Name = "Provincia")]
        public string Descripcion { get; set; }
    }
}