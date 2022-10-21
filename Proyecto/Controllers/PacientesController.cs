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
    public class PacientesController : Controller
    {
        // GET: Pacientes
        public ActionResult Index()
        {
            var lista = new List<Pacientes>()
            {
                new Pacientes()
                {
                    idPaciente = 1,
                    no_afiliado = "2541254789654",
                    nombre = "Dayana",
                    direccion = "Ecuador",
                    telefono = 12345678
                },
                new Pacientes()
                {
                    idPaciente = 2,
                    no_afiliado = "547896541254",
                    nombre = "Juan",
                    direccion = "Perez",
                    telefono = 87654321
                }
            };
            return View(lista);
        }

        public ActionResult newPaciente()
        {
            return View();
        }

    }
}