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
    public class CargoController : Controller
    {
        // GET: CargoI
        public ActionResult Index()
        {
            //api
            var dataCargos = new List<Cargos>()
            {
                new Cargos()
                {
                    IdCargo=1,
                    Cargo="Medico"
                },
                new Cargos()
                {
                    IdCargo=2,
                    Cargo="Administrador"
                }
            };
            ///
            return View(dataCargos);
        }
        public ActionResult newCargo()
        {
            return View();
        }
    }
}