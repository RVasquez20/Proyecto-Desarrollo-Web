using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoteProductos
    {
        public int? IdLoteProductos { get; set; }
        public string Descripcion { get; set; }
        public int? noLote { get; set; }
        public DateTime? FechaExpiracion { get; set; }
    }
}