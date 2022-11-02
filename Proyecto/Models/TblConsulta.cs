using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblConsulta
    {

        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdClinica { get; set; }
        public int? IdDiagnostico { get; set; }
        public int? IdReceta { get; set; }
    }
    public class ConsultasViewModel
    {

        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdClinica { get; set; }
        public int? IdDiagnostico { get; set; }
        public int? IdReceta { get; set; }
        public string Paciente { get; set; }
        public string Empleado { get; set; }
        public string Clinica { get; set; }
        public string Diagnostico { get; set; }
        public string Receta { get; set; }
    }
}
