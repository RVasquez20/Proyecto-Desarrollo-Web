using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class VentaController : Controller
    {
        // GET: VentaI
      /*  public ActionResult Index()
        {
            var lista = new List<Venta>()
            {
                new Venta()
                {
                    idVenta = 1,
                    serie = "AA",
                    numero = "001",
                    fecha = DateTime.Now
                },
                new Venta()
                {
                    idVenta = 1,
                    serie = "AA",
                    numero = "001",
                    fecha = DateTime.Now
                }
            };
            return View(lista);
        }

        public ActionResult newVenta()
        {
            return View();
        }*/
    }
}