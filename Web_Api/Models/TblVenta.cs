using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblVenta
    {
        public TblVenta()
        {
            TblVentasDetalles = new HashSet<TblVentasDetalle>();
        }

        public int IdVentas { get; set; }
        public string? Serie { get; set; }
        public int? Numero { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual ICollection<TblVentasDetalle> TblVentasDetalles { get; set; }
    }
}
