using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class EmpleadoMenuController : Controller
    {
        // GET: EmpleadoI
        public ActionResult Index()
        {
            return View();
        }
    }
}