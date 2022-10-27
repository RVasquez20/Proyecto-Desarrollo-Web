using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Xml.Linq;

namespace WebApplication1.Models
{
    public  class TblProducto
    {
       
        public int IdProducto { get; set; }
        public int? IdLoteProducto { get; set; }
        public int? IdClinica { get; set; }
        public string Nombre { get; set; }
        public int? IdMarca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public string Imagen { get; set; } 
    }
    public class ProductosViewModel
    {

        public int IdProducto { get; set; }
        public int? IdLoteProducto { get; set; }
        public int? IdClinica { get; set; }
        public string Nombre { get; set; }
        public int? IdMarca { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int Existencia { get; set; }
        public HttpPostedFileBase ImagenFile { get; set; }
        [Display(Name = "Imagen Actual")]
        public string Imagen { get; set; }
        public string marca { get; set; }
        public string clinica { get; set; }
        public string lote { get; set; }
        
    }
}
