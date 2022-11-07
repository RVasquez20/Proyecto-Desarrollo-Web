using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblComprasDetalle
    {
        public int IdComprasDetalle { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdCompra { get; set; }

        public virtual TblCompra? IdCompraNavigation { get; set; }
        public virtual TblProducto? IdProductoNavigation { get; set; }
    }
}
