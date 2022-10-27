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
                var listadoHabDisp = JsonConvert.DeserializeObject<List<TblHabitacione>>(responseStringHabDispo);
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
                        Text = r.NoHabitacion.ToString(),
                        Value = r.IdHabitacion.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoHabDisponibles = listadoHabDisponibles;
                return View();
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
    }
}