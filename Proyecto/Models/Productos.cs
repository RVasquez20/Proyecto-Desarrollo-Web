using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Productos
    {
        public int idProductos { get; set; }
        public int idLote_Producto { get; set; }
        public int idClinica { get; set; }
        public string nombre { get; set; }
        public int idMarca { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int existencia { get; set; }
    }

    public class ProductosViewModel
    {
        public int idProductos { get; set; }
        public int idLote_Producto { get; set; }
        public string Lote_Producto { get; set; }
        public int idClinica { get; set; }
        public string Clinica { get; set; }
        public string nombre { get; set; }
        public int idMarca { get; set; }
        public string Marca { get; set; }
        public string descripcion { get; set; }
        public int precio { get; set; }
        public int existencia { get; set; }
    }

    
}