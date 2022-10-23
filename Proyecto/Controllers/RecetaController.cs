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
    public class RecetaController : Controller
    {

        // GET: Pacientes
        public ActionResult Index()
        {
            var lista = new List<Receta>()
            {
                new Receta()
                {
                    idReceta = 1,
                    serie_receta = "Juana Maria",
                    fecha_emision = DateTime.Now


                },
                 new Receta()
                {
                    idReceta = 1,
                    serie_receta = "Juana Maria",
                    fecha_emision = DateTime.Now


                }
            };
            return View(lista);
        }

        public ActionResult newReceta()
        {
            return View();
        }

    }
}