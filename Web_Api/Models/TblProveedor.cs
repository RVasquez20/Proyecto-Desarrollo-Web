using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblProveedor
    {
        public TblProveedor()
        {
            TblCompras = new HashSet<TblCompra>();
        }

        public int IdProveedor { get; set; }
        public string? Nombre { get; set; }
        public string? Nit { get; set; }
        public string? Direccion { get; set; }
        public int? Telefono { get; set; }

        public virtual ICollection<TblCompra> TblCompras { get; set; }
    }
}
