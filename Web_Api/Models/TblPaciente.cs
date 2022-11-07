using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblPaciente
    {
        public TblPaciente()
        {
            TblConsulta = new HashSet<TblConsulta>();
            TblPacientesHabitaciones = new HashSet<TblPacientesHabitacione>();
        }

        public int IdPaciente { get; set; }
        public int NoAfiliacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }

        public virtual ICollection<TblConsulta>? TblConsulta { get; set; }
        public virtual ICollection<TblPacientesHabitacione>? TblPacientesHabitaciones { get; set; }
    }
}
