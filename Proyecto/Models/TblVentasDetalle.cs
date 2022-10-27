using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TblVentasDetalle
    {
        public int IdVentasDetalle { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdVenta { get; set; }

    }
}
