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
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            var dataMarcas = new List<Marcas>()
            {
                new Marcas()
                {
                    IdMarca=1,
                    Marca="Pto el que lo lea"
                },
                new Marcas()
                {
                    IdMarca=2,
                    Marca="Pto el que lo lea"
                },
                new Marcas()
                {
                    IdMarca=3,
                    Marca="Pto el que lo lea"
                }
            };
            return View(dataMarcas);
        }

        public ActionResult newMarcas()
        {
            return View();
        }
    }
}