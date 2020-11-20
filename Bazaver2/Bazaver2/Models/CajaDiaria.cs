using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class CajaDiaria:CajaTotal
    {
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }


    }
}