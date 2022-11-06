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
using WebApplication1.Hubs;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class PacienteHabitacionController : Controller
    {
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/PacientesHabitaciones";
        private readonly string _urlHabitacionesDisponibles = "https://apiclinica.azurewebsites.net/api/Habitaciones/HabitacionesDisponibles";
        private readonly string _urlPacientes = "https://apiclinica.azurewebsites.net/api/Pacientes";

        // GET: PacienteHabitacionI
        public async Task<ActionResult> Index()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoPacHabitacion = JsonConvert.DeserializeObject<List<PacientesHabitacionesViewModel>>(responseString);
                return View(listadoPacHabitacion);
            }
        }

        public async Task<ActionResult> newPacienteHab()
        {
            using (var http = new HttpClient())
            {
                var responsePaciente = await http.GetAsync(_urlPacientes);
                if (responsePaciente.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringPaciente = await responsePaciente.Content.ReadAsStringAsync();
                var listadoPac = JsonConvert.DeserializeObject<List<TblPaciente>>(responseStringPaciente);


                var responseHabitaciones= await http.GetAsync(_urlHabitacionesDisponibles);
                if (responseHabitaciones.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringHabDispo= await responseHabitaciones.Content.ReadAsStringAsync();
                var listadoHabDisp = JsonConvert.DeserializeObject<List<HabitacionesViewModel>>(responseStringHabDispo);
                var listadoPacientes = listadoPac.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdPaciente.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoPacientes = listadoPacientes;
                var listadoHabDisponibles = listadoHabDisp.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = (r.NoHabitacion.ToString()+", "+r.Clinica),
                        Value = r.IdHabitacion.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoHabDisponibles = listadoHabDisponibles;
                return View();
            }
            
        }
        public async Task<ActionResult> modificarPacienteHabitacion(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responsePaciente = await http.GetAsync(_urlPacientes);
                if (responsePaciente.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringPaciente = await responsePaciente.Content.ReadAsStringAsync();
                var listadoPac = JsonConvert.DeserializeObject<List<TblPaciente>>(responseStringPaciente);


                var responseHabitaciones = await http.GetAsync(_urlHabitacionesDisponibles);
                if (responseHabitaciones.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringHabDispo = await responseHabitaciones.Content.ReadAsStringAsync();
                var listadoHabDisp = JsonConvert.DeserializeObject<List<HabitacionesViewModel>>(responseStringHabDispo);
                var listadoPacientes = listadoPac.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdPaciente.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoPacientes = listadoPacientes;
                var listadoHabDisponibles = listadoHabDisp.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = (r.NoHabitacion.ToString() + ", " + r.Clinica),
                        Value = r.IdHabitacion.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoHabDisp = listadoHabDisponibles;
                var responseString = await response.Content.ReadAsStringAsync();
                var pacienteHabitacion = JsonConvert.DeserializeObject<TblPacientesHabitacione>(responseString);
                return View(pacienteHabitacion);
            }
        }
        [HttpPost]
        public async Task<ActionResult> modificarPacientesHabitaciones(TblPacientesHabitacione model)
        {
            using (var http=new HttpClient())
            {
                var responsePacienteHabitacion = await http.GetAsync(_url + "/" + model.IdPacHab);
                if (responsePacienteHabitacion.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringPaciente = await responsePacienteHabitacion.Content.ReadAsStringAsync();
                var pacienteHabitacion = JsonConvert.DeserializeObject<TblPacientesHabitacione>(responseStringPaciente);
                if (model.IdHabitacion != null)
                {
                    pacienteHabitacion.IdHabitacion = model.IdHabitacion;
                    pacienteHabitacion.IdPaciente = model.IdPaciente;
                }
                else
                {
                    pacienteHabitacion.IdPaciente = model.IdPaciente;
                }
                //Modificar TblPAcientesHabitaciones
                var pacHabitacionSerializada = JsonConvert.SerializeObject(pacienteHabitacion);
                var content = new StringContent(pacHabitacionSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.IdPacHab, content);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
                
            }
        }
        

            [HttpPost]
        public async Task<ActionResult> newPacHab(TblPacientesHabitacione model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var pacHabitacionSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(pacHabitacionSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                HabitacionesHub.BroadcastData();
                return RedirectToAction("Index");
            }
        }

        public async Task<string> EliminarPacienteHabitacion(int? id)
        {
            using (var _http = new HttpClient())
            {
                var response = await _http.DeleteAsync(_url + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                HabitacionesHub.BroadcastData();
                return "Exito";
            }
        }
    }
}