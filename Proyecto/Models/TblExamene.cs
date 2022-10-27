using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblExamene
    {
       

        public int IdExamen { get; set; }
        public string Nombre { get; set; } 
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public int? IdConsulta { get; set; }
    }
}
