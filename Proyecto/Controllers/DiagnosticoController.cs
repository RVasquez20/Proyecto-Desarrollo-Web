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
    public class DiagnosticoController : Controller
    {
        // GET: DiagosticoI
        public ActionResult Index()
        {
            var lista = new List<Diagnosticos>()
            {
                new Diagnosticos()
                {
                    idDiagnostico = 1,
                    titulo = "General",
                    descripcion = "General"
                },
                new Diagnosticos()
                {
                    idDiagnostico = 2,
                    titulo = "Interno",
                    descripcion = "Interno"
                }
            };
            return View(lista);
        }

        public ActionResult newDiagnostico()
        {
            return View();
        }
    }
}