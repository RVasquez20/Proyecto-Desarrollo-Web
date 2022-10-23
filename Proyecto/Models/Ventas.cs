using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Venta
    {
        public int? idVenta { get; set; }
        public string serie { get; set; }
        public string numero { get; set; }
        public DateTime? fecha { get; set; }
    }
}