using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class EmpleadosController : Controller
    {
        private readonly string _urlEmpleados = "https://apiclinica.azurewebsites.net/api/Empleados";
        private readonly string _urlCargos = "https://apiclinica.azurewebsites.net/api/Cargo";
        private readonly string _urlClinica = "https://apiclinica.azurewebsites.net/api/Clinicas";
        // GET: Empleados
        public async Task<ActionResult> Index()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlEmpleados);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoEmpleados = JsonConvert.DeserializeObject<List<EmpleadosViewModel>>(responseString);
                return View(listadoEmpleados);
            }
        }
        //vista
        public async Task<ActionResult> newEmployee()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlCargos);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoCargo = JsonConvert.DeserializeObject<List<TblCargo>>(responseString);
                var listadoCargos = listadoCargo.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Cargo,
                        Value = r.IdCargo.ToString(),
                        Selected = false
                    };
                });

                var responseClinica = await http.GetAsync(_urlClinica);
                if (responseClinica.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringClinicas = await responseClinica.Content.ReadAsStringAsync();
                var listadoClinicas = JsonConvert.DeserializeObject<List<TblClinica>>(responseStringClinicas);
                var listadoClinica = listadoClinicas.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdClinica.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoCargos = listadoCargos;
                ViewBag.listadoClinicas = listadoClinica;

                return View();
            }

        }

        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
        public async Task<ActionResult> AgregarEmpleado(TblEmpleado model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var EmpleadoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(EmpleadoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_urlEmpleados, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

        //trae la vista con los datos cargados

        public async Task<ActionResult> modificarEmpleado(int id)
        {
            using (var http = new HttpClient())
            {
                var responseEmpleado = await http.GetAsync(_urlEmpleados + "/" + id);
                if (responseEmpleado.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringEmpleado = await responseEmpleado.Content.ReadAsStringAsync();
                var Empleado = JsonConvert.DeserializeObject<TblEmpleado>(responseStringEmpleado);

                var response = await http.GetAsync(_urlCargos);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoCargo = JsonConvert.DeserializeObject<List<TblCargo>>(responseString);
                var listadoCargos = listadoCargo.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Cargo,
                        Value = r.IdCargo.ToString(),
                        Selected = false
                    };
                });

                var responseClinica = await http.GetAsync(_urlClinica);
                if (responseClinica.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringClinicas = await responseClinica.Content.ReadAsStringAsync();
                var listadoClinicas = JsonConvert.DeserializeObject<List<TblClinica>>(responseStringClinicas);
                var listadoClinica = listadoClinicas.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdClinica.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoCargos = listadoCargos;
                ViewBag.listadoClinicas = listadoClinica;
                return View(Empleado);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarEmpleado(TblEmpleado model)
        {
            using (var http = new HttpClient())
            {
                var empleadoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(empleadoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_urlEmpleados + "/" + model.IdEmpleado, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd
        public async Task<string> eliminarEmpleado(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.DeleteAsync(_urlEmpleados + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
        }


    }
}