using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblCargo
    {
        public TblCargo()
        {
            TblEmpleados = new HashSet<TblEmpleado>();
        }

        public int IdCargo { get; set; }
        public string Cargo { get; set; }

        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
    }
}
