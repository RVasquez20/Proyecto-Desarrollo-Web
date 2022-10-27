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
    public class CompraController : Controller
    {
        // GET: CompraI
      /*  public ActionResult Index()
        {
            var lista = new List<ComprasViewModel>()
            {
                new ComprasViewModel()
                {
                    idCompra = 1,
                    no_orden = 1,
                    fecha_orden = DateTime.Now,
                    fecha = DateTime.Now,
                    idProveedor = 1,
                    proveedor = "Americas Health"
                },
                new ComprasViewModel()
                {
                    idCompra = 2,
                    no_orden = 2,
                    fecha_orden = DateTime.Now,
                    fecha = DateTime.Now,
                    idProveedor = 2,
                    proveedor = "Royal Medicine"
                }
            };
            return View(lista);
        }

        public ActionResult newCompra()
        {
            var dataProveedor = new List<Proveedores>()
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
            var listadoProveedor = dataProveedor.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.nombre + "," + r.direccion,
                    Value = r.idProveedor.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoProveedor = listadoProveedor;
            return View();
        }*/
    }
}