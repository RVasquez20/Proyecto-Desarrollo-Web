using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblVentasDetalle
    {
        public int IdVentasDetalle { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdVenta { get; set; }

        public virtual TblProducto IdProductoNavigation { get; set; }
        public virtual TblVenta IdVentaNavigation { get; set; }
    }
}
