using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TblAccessRole
    {
        public int IdAccessRole { get; set; }
        public int? IdRol { get; set; }
        public int? IdAccess { get; set; }

    }
    public class accessRolesViewModel
    {
        public int IdAccessRoles { get; set; }
        public string Name { get; set; }

    }
}
