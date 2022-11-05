using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblReceta
    {
        public int IdReceta { get; set; }
        public string Serie { get; set; }
        public DateTime FechaEmision { get; set; }

        public virtual TblConsulta IdRecetaNavigation { get; set; }
    }
}
