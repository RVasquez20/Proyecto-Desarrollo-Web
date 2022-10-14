using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblRole
    {
        public TblRole()
        {
            TblUsuarios = new HashSet<TblUsuario>();
        }

        public int IdRol { get; set; }
        public string Rol { get; set; } = null!;
        public int? IdMenu { get; set; }

        public virtual TblMenu? IdMenuNavigation { get; set; }
        public virtual ICollection<TblUsuario> TblUsuarios { get; set; }
    }
}
