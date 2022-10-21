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
    public class ExamenController : Controller
    {
        
        // GET: Pacientes
        public ActionResult Index()
        {
            var lista = new List<Examen>()
            {
                new Examen()
                {
                    idExamen = 1,
                    nombre = "Juana Maria",
                    descripcion= "examen de orina",
                    precio = 50
                    
                },
                 new Examen()
                {
                    idExamen = 2,
                    nombre = "Raul",
                    descripcion= "examen de orina",
                    precio = 50

                }
            };
            return View(lista);
        }

        public ActionResult newExamen()
        {
            return View();
        }

    }
}