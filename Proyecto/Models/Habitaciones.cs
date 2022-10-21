using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Habitacion
    {
        public int? idHabitacion { get; set; }
        public int? no_habitacion { get; set; }
        public int? idClinica { get; set; }
        public int? CantidadPacientes { get; set; }
    }
    public class HabitacionesViewModel
    {
        public int? idHabitacion { get; set; }
        public int no_habitacion { get; set; }
        public int idClinica { get; set; }
        public string Clinica { get; set; }
        public int CantidadPacientes { get; set; }
    }
}