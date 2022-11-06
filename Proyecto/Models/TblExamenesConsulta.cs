using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblExamenesConsulta
    {
        public int IdExamenConsulta { get; set; }
        public int? IdExamen { get; set; }
        public int? IdConsulta { get; set; }
    }
    public class ExamenConsultaViewModel
    {
        public int IdExamenConsulta { get; set; }
        public int? IdExamen { get; set; }
        public int? IdConsulta { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
    }
}
