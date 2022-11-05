using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblAccess
    {
        public TblAccess()
        {
            TblAccessRoles = new HashSet<TblAccessRole>();
        }

        public int IdAccess { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public virtual ICollection<TblAccessRole> TblAccessRoles { get; set; }
    }
}
