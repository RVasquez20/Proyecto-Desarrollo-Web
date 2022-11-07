using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblConsulta
    {
        public TblConsulta()
        {
            TblExamenesConsulta = new HashSet<TblExamenesConsulta>();
        }

        public int IdConsulta { get; set; }
        public int? IdPaciente { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdClinica { get; set; }
        public int? IdDiagnostico { get; set; }
        public int? IdReceta { get; set; }

        public virtual TblClinica? IdClinicaNavigation { get; set; }
        public virtual TblEmpleado? IdEmpleadoNavigation { get; set; }
        public virtual TblPaciente? IdPacienteNavigation { get; set; }
        public virtual TblDiagnostico? TblDiagnostico { get; set; }
        public virtual TblReceta? TblReceta { get; set; }
        public virtual ICollection<TblExamenesConsulta>? TblExamenesConsulta { get; set; }
    }
}
