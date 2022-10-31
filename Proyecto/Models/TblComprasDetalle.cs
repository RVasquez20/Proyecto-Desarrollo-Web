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

    public class ComprasDetalleViewDetails
    {
        public int IdVentasDetalle { get; set; }
        public int IdProducto { get; set; }
        public int? Cantidad { get; set; }
        public int IdCompras { get; set; }
        public int NoOrden { get; set; }
        public string Producto { get; set; }
    }
}
