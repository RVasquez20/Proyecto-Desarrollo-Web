using System;
using System.Collections.Generic;

namespace Web_Api.Models
{
    public partial class TblExamene
    {
        public TblExamene()
        {
            TblExamenesConsulta = new HashSet<TblExamenesConsulta>();
        }

        public int IdExamen { get; set; }
        public string Nombre { get; set; } 
        public string Descripcion { get; set; }
        public double Precio { get; set; }

        public virtual ICollection<TblExamenesConsulta> TblExamenesConsulta { get; set; }
    }
}
