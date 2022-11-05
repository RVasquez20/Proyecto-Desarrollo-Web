using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblLoteProducto
    {
        public TblLoteProducto()
        {
            TblProductos = new HashSet<TblProducto>();
        }

        public int IdLoteProducto { get; set; }
        public string Descripcion { get; set; }
        public int NoLote { get; set; }
        public DateTime FechaExpiracion { get; set; }

        public virtual ICollection<TblProducto> TblProductos { get; set; }
    }
}
