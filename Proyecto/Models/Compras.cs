using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Compras
    {
        public int? idCompra { get; set; }
        public int? no_orden { get; set; }
        public DateTime? fecha_orden { get; set; }
        public DateTime? fecha { get; set; }
        public int? idProveedor { get; set; }
    }
    
    public class ComprasViewModel
    {
        public int? idCompra { get; set; }
        public int no_orden { get; set; }
        public DateTime fecha_orden { get; set; }
        public DateTime fecha { get; set; }
        public int idProveedor { get; set; }
        public string proveedor { get; set; }
    }
}