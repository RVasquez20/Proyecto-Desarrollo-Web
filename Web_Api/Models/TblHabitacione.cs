using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblHabitacione
    {
        public TblHabitacione()
        {
            TblPacientesHabitaciones = new HashSet<TblPacientesHabitacione>();
        }

        public int IdHabitacion { get; set; }
        public int NoHabitacion { get; set; }
        public int? IdClinica { get; set; }
        public int CantidadMaxPacientes { get; set; }

        public virtual TblClinica? IdClinicaNavigation { get; set; }
        public virtual ICollection<TblPacientesHabitacione> TblPacientesHabitaciones { get; set; }
    }
}
