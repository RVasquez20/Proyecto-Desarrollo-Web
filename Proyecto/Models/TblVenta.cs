using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class TblVenta
    {     

        public int IdVentas { get; set; }
        public string Serie { get; set; }
        public int? Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPaciente { get; set; }
    }
    public class VentaViewModel
    {

        public int IdVentas { get; set; }
        public string Serie { get; set; }
        public int? Numero { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdPaciente { get; set; }
        public string Paciente { get; set; }
    }
}
