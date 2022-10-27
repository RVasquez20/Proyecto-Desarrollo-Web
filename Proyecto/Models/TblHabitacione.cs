using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblHabitacione
    {
      

        public int IdHabitacion { get; set; }
        public int NoHabitacion { get; set; }
        public int? IdClinica { get; set; }
        public int CantidadMaxPacientes { get; set; }
    }
}
