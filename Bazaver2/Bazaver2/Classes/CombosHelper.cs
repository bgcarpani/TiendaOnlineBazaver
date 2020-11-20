using Bazaver2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bazaver2.Classes
{
    public class CombosHelper : IDisposable
    {
        private static Bazaver2DbContext db = new Bazaver2DbContext();

     


        public void Dispose()
        {
            db.Dispose();
        }
    }
}