using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Proveedores
    {
        public int? idProveedor { get; set; }
        public string nombre { get; set; }
        public string nit { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
    }
}