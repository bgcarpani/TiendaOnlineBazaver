using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class CajaMensual:CajaTotal
    {
        public int Mes { get; set; }

        public int Año { get; set; }

    }
}