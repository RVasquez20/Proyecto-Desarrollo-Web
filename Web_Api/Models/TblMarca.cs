using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblMarca
    {
        public TblMarca()
        {
            TblProductos = new HashSet<TblProducto>();
        }

        public int IdMarca { get; set; }
        public string Marca { get; set; }

        public virtual ICollection<TblProducto> TblProductos { get; set; }
    }
}
