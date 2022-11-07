using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblEmpleado
    {
        public TblEmpleado()
        {
            TblConsulta = new HashSet<TblConsulta>();
        }

        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int? IdCargo { get; set; }
        public int? IdClinica { get; set; }

        public virtual TblCargo? IdCargoNavigation { get; set; }
        public virtual TblClinica? IdClinicaNavigation { get; set; }
        public virtual TblUsuario? TblUsuario { get; set; }
        public virtual ICollection<TblConsulta>? TblConsulta { get; set; }
    }
}
