using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblAccessRole
    {
        public int IdAccessRoles { get; set; }
        public int? IdRol { get; set; }
        public int? IdAccess { get; set; }

        public virtual TblAccess? IdAccessNavigation { get; set; }
        public virtual TblRole? IdRolNavigation { get; set; }
    }
}
