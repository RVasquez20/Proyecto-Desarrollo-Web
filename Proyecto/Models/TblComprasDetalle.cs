using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblComprasDetalle
    {
        public int IdComprasDetalle { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdCompra { get; set; }
    }
}
