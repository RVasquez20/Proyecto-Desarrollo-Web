using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblCompra
    {
     

        public int IdCompras { get; set; }
        public int? NoOrden { get; set; }
        public DateTime? FechaOrden { get; set; }
        public DateTime? Fecha { get; set; }
        public int IdProveedor { get; set; }
    }
}
