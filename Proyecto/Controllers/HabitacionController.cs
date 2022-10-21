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
    public class HabitacionController : Controller
    {
        // GET: HabitacionI
        public ActionResult Index()
        {
            var lista = new List<HabitacionesViewModel>()
            {
                new HabitacionesViewModel()
                {
                    idHabitacion = 1,
                    no_habitacion = 1,
                    idClinica = 1,
                    Clinica = "Chimaltenango",
                    CantidadPacientes = 1
                },
                new HabitacionesViewModel()
                {
                    idHabitacion = 2,
                    no_habitacion = 2,
                    idClinica = 1,
                    Clinica = "Antigua",
                    CantidadPacientes = 1
                }
            };
            return View(lista);
        }

        public ActionResult newHabitaciones()
        {
            var dataClinica = new List<ClinicaViewModel>()
            {
                new ClinicaViewModel()
                {
                    idClinica=1,
                    nombre="Clinica 1",
                    direccion = "Clinica 1"
                },
                new ClinicaViewModel()
                {
                    idClinica=1,
                    nombre="Clinica 2",
                    direccion = "Clinica 2"
                }
            };
            var listadoClinica = dataClinica.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.nombre+","+r.direccion,
                    Value = r.idClinica.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoClinica = listadoClinica;
            return View();
        }
    }
}