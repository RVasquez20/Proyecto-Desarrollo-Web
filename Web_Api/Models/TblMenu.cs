using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblMenu
    {
        public TblMenu()
        {
            TblRoles = new HashSet<TblRole>();
        }

        public int IdMenu { get; set; }
        public string Pacientes { get; set; } = null!;
        public string Inventario { get; set; } = null!;
        public string Empleados { get; set; } = null!;
        public string Habitaciones { get; set; } = null!;
        public string Historial { get; set; } = null!;

        public virtual ICollection<TblRole> TblRoles { get; set; }
    }
}
