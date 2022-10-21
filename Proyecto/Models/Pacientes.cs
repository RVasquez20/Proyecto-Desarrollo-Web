using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Pacientes
    {
        public int idPaciente { get; set; }
        public string no_afiliado { get; set; }
        public string nombre { get; set; }
        public string direccion { get; set; }
        public int telefono { get; set; }
    }
}