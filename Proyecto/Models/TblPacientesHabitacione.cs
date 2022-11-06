using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblPacientesHabitacione
    {
        public int IdPacHab { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdHabitacion { get; set; }
        
    }
    public class PacientesHabitacionesViewModel
    {
        public int IdPacHab { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdHabitacion { get; set; }
        public string Paciente { get; set; }
        public string NumHabitacion { get; set; }
        public string Clinica { get; set; }

    }
}
