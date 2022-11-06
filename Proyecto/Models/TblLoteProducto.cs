using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TblLoteProducto
    {

        public int IdLoteProducto { get; set; }
        public string Descripcion { get; set; }
        public int NoLote { get; set; }
        public DateTime FechaExpiracion { get; set; }
        
    }
}
