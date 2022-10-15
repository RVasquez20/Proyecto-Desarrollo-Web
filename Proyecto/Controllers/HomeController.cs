using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            ViewBag.Message = "Menu";

            return View();
        }

        public ActionResult Consulta()
        {
            ViewBag.Message = "Consult";

            return View();
        }

        public ActionResult Empleado()
        {
            ViewBag.Message = "Employee";

            return View();
        }

        public  ActionResult Farmacia()
        {
            ViewBag.Message = "Farmacy";

            return View();
        }
    }
}