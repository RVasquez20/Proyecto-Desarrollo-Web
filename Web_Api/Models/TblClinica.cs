using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblClinica
    {
        public TblClinica()
        {
            TblConsulta = new HashSet<TblConsulta>();
            TblEmpleados = new HashSet<TblEmpleado>();
            TblHabitaciones = new HashSet<TblHabitacione>();
            TblProductos = new HashSet<TblProducto>();
        }

        public int IdClinica { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        public virtual ICollection<TblConsulta> TblConsulta { get; set; }
        public virtual ICollection<TblEmpleado> TblEmpleados { get; set; }
        public virtual ICollection<TblHabitacione> TblHabitaciones { get; set; }
        public virtual ICollection<TblProducto> TblProductos { get; set; }
    }
}
