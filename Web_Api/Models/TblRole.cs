using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblAccessRoles = new HashSet<TblAccessRole>();
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int IdRol { get; set; }
        public string Rol { get; set; } = null!;

        public virtual ICollection<TblAccessRole> TblAccessRoles { get; set; }
        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
