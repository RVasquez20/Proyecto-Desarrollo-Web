using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Empleados
    {
        private int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdCargo { get;set; }
    }
    public class EmpleadosViewModel
    {
        public int idEmpleado { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int IdCargo { get; set; }
        public string Cargo { get; set; }
    }
}