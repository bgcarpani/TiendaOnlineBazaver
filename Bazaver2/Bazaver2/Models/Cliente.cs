using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazaver2.Models
{
    public class Cliente
    {

        public string NombreCliente { get; set; }

  
        public string ApellidoCliente { get; set; }


        public int LocalidadId { get; set; }

        public Localidad Localidad { get; set; }

        public string Direccion { get; set; }

  
        public string Comentarios { get; set; }


        public string Telefono { get; set; }


        public DateTime Fecha { get; set; }

        public string Correo { get; set; }
    }
}