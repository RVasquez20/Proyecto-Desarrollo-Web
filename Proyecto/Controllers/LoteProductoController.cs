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
    public class LoteProductoController : Controller
    {
        // GET: LoteProductoI
        public ActionResult Index()
        {
            var dataLotes = new List<LoteProductos>()
            {
                new LoteProductos(){
                    IdLoteProductos =1,
                    Descripcion ="Lote 1",
                    noLote = 1,
                    FechaExpiracion=DateTime.Now
                },
                 new LoteProductos(){
                    IdLoteProductos =2,
                    Descripcion ="Lote 2",
                    noLote = 2,
                    FechaExpiracion=DateTime.Now
                },
                  new LoteProductos(){
                    IdLoteProductos =3,
                    Descripcion ="Lote 3",
                    noLote = 3,
                    FechaExpiracion=DateTime.Now
                }
            };
            return View(dataLotes);
        }
        public ActionResult newLoteProductos()
        {
            return View();
        }
    }
}