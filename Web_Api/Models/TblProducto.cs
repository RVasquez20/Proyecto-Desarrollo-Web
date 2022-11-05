using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblProducto
    {
        public TblProducto()
        {
            TblComprasDetalles = new HashSet<TblComprasDetalle>();
            TblVentasDetalles = new HashSet<TblVentasDetalle>();
        }

        public int IdProducto { get; set; }
        public int? IdLoteProducto { get; set; }
        public int? IdClinica { get; set; }
        public string? Nombre { get; set; }
        public int? IdMarca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; }

        public virtual TblClinica? IdClinicaNavigation { get; set; }
        public virtual TblLoteProducto? IdLoteProductoNavigation { get; set; }
        public virtual TblMarca? IdMarcaNavigation { get; set; }
        public virtual ICollection<TblComprasDetalle> TblComprasDetalles { get; set; }
        public virtual ICollection<TblVentasDetalle> TblVentasDetalles { get; set; }
    }
}
