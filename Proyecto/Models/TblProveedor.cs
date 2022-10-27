using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblProveedor
    {
       
        public int IdProveedor { get; set; }
        public string Nombre { get; set; }
        public string Nit { get; set; }
        public string Direccion { get; set; }
        public int? Telefono { get; set; }
    }
}
