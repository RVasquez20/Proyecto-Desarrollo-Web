using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblDiagnostico
    {
        public int IdDiagnostico { get; set; }
        public string Titulo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;

        public virtual TblConsulta IdDiagnosticoNavigation { get; set; } = null!;
    }
}
