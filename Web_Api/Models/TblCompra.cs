using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblCompra
    {
        public TblCompra()
        {
            TblComprasDetalles = new HashSet<TblComprasDetalle>();
        }

        public int IdCompras { get; set; }
        public int? NoOrden { get; set; }
        public DateTime? FechaOrden { get; set; }
        public int IdProveedor { get; set; }

        public virtual TblProveedor IdProveedorNavigation { get; set; }
        public virtual ICollection<TblComprasDetalle> TblComprasDetalles { get; set; }
    }
}
