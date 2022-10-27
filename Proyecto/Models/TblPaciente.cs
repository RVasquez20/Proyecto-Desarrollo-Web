using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TblPaciente
    {
        public int IdPaciente { get; set; }
        public int NoAfiliacion { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; } 
        public int Telefono { get; set; }

    }
}
