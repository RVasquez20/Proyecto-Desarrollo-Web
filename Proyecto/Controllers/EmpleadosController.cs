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
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            //llamada a la api
            var lista = new List<EmpleadosViewModel>()
            {
                new EmpleadosViewModel()
                {
                    idEmpleado=1,
                    Nombre="Pepito",
                    Apellido="Perez",
                    IdCargo=1,
                    Cargo="Medico"
                },
                 new EmpleadosViewModel()
                {
                    idEmpleado=2,
                    Nombre="Pepito2",
                    Apellido="Perez2",
                    IdCargo=2,
                    Cargo="Administrador"
                }
            };
            
            //
            return View(lista);
        }
        
        public ActionResult newEmployee()
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
            var listadoCargos = dataCargos.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.Cargo,
                    Value = r.IdCargo.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoCargos = listadoCargos;
            return View();
        }
    }
}