using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblExamenesConsulta
    {
        public int IdExamenConsulta { get; set; }
        public int? IdExamen { get; set; }
        public int? IdConsulta { get; set; }

        public virtual TblConsulta? IdConsultaNavigation { get; set; }
        public virtual TblExamene? IdExamenNavigation { get; set; }
    }
}
