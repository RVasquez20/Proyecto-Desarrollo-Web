using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblReceta
    {
        public int IdReceta { get; set; }
        public string Serie { get; set; } = null!;
        public DateTime FechaEmision { get; set; }
        public int IdPaciente { get; set; }
        public int IdExamen { get; set; }

        public virtual TblConsulta IdRecetaNavigation { get; set; } = null!;
    }
}
