using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblPacientesHabitacione
    {
        public int IdPacHab { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdHabitacion { get; set; }

        public virtual TblHabitacione? IdHabitacionNavigation { get; set; }
        public virtual TblPaciente? IdPacienteNavigation { get; set; }
    }
}
