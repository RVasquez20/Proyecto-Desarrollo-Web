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
    public class ClinicaController : Controller
    {
        // GET: ClinicaI
        public ActionResult Index()
        {
            // llamada a la api
            var lista = new List<ClinicaViewModel>()
            {
                new ClinicaViewModel() 
                {
                    idClinica = 1,
                    nombre = "Clinica 1",
                    direccion = "Direccion 1"
                },
                new ClinicaViewModel()
                {
                    idClinica = 2,
                    nombre = "Clinica 2",
                    direccion = "Direccion 2"
                }
            };
            //
            return View(lista);
        }

        public ActionResult newClinic()
        {          
            return View();
        }
    }
}