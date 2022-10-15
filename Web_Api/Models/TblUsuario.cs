using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblUsuario
    {
        public int IdUsuario { get; set; }
        public int? IdEmpleado { get; set; }
        public int? IdRol { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual TblEmpleado? IdEmpleadoNavigation { get; set; }
        public virtual TblRole? IdRolNavigation { get; set; }
    }
}
