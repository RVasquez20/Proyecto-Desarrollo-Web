using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblDiagnostico
    {
        public int IdDiagnostico { get; set; }
        public string Nombre { get; set; } = null!;
        public string Descricpion { get; set; } = null!;

        public virtual TblConsulta IdDiagnosticoNavigation { get; set; } = null!;
    }
}
