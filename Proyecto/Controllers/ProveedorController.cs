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
    public class ProveedorController : Controller
    {
        // GET: ProveedorI
        public ActionResult Index()
        {
            var lista = new List<Proveedores>()
            {
                new Proveedores()
                {
                    idProveedor = 1,
                    nombre = "Americas Health",
                    nit = "25415K",
                    direccion = "Estados Unidos",
                    telefono = 55412321
                },
                new Proveedores()
                {
                    idProveedor = 2,
                    nombre = "Royal Medicine",
                    nit = "336524E",
                    direccion = "Inglaterra",
                    telefono = 33200145
                }
            };
            return View(lista);
        }
        public ActionResult newProveedor()
        {
            return View();
        }
    }
}