using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public  class TblEmpleado
    {
       
        public int IdEmpleado { get; set; }
        public string CodigoEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; } 
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public int? IdCargo { get; set; }
        public int? IdClinica { get; set; }

    }
}
