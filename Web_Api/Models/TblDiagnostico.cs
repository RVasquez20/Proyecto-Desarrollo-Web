using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblDiagnostico
    {
        public int IdDiagnostico { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public virtual TblConsulta IdDiagnosticoNavigation { get; set; }
    }
}
