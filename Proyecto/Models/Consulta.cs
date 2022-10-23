using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Consulta
    {
        public int idConsulta { get; set; }
        public int idPaciente { get; set; }
        public int idEmpleado { get; set; }
        public int idClinica { get; set; }
        public int idDiagnostico { get; set; }
        public int idReceta { get; set; }
    }

    public class ConsultaViewModel
    {
        public int idConsulta { get; set; }
        public string nombre { get; set; }
        public int idPaciente { get; set; }
        public string Paciente { get; set; }
        public int idEmpleado { get; set; }
        public string Empleado { get; set; }
        public int idClinica { get; set; }
        public string Clinica { get; set; }
        public int idDiagnostico { get; set; }
        public string Diagnostico { get; set; }
        public int idReceta { get; set; }
        public string Receta { get; set; }
    }
}