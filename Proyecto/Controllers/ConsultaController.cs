using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;
using static System.Net.WebRequestMethods;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class ConsultaController : Controller
    {
        private readonly string _urlConsultas= "https://apiclinica.azurewebsites.net/api/Consultas";
        private readonly string _urlPacientes= "https://apiclinica.azurewebsites.net/api/Pacientes";
        private readonly string _urlExamenes = "https://apiclinica.azurewebsites.net/api/Examenes";
        public async Task<ActionResult> Index()
        {
            using (var _http = new HttpClient())
            {
                var response = await _http.GetAsync(_urlConsultas);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoConsultas = JsonConvert.DeserializeObject<List<ConsultasViewModel>>(responseString);
                return View(listadoConsultas);
            }
        }
        public async Task<ActionResult> ConsultasPorPaciente()
        {
            using (var _http = new HttpClient())
            {
                var responsePacientes = await _http.GetAsync(_urlPacientes);
                if (responsePacientes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseStringPacientes = await responsePacientes.Content.ReadAsStringAsync();
                var listPacientes = JsonConvert.DeserializeObject<List<TblPaciente>>(responseStringPacientes);
                var listadoPaciente = listPacientes.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdPaciente.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoPacientes = listadoPaciente;
                return View();
            }
        }

        public async Task<ActionResult> newConsulta()
        {
            using (var _http = new HttpClient())
            {
                var responsePacientes = await _http.GetAsync(_urlPacientes);
                if (responsePacientes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }

                var responseExamenes = await _http.GetAsync(_urlExamenes);
                if (responseExamenes.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }

                var responseStringPacientes = await responsePacientes.Content.ReadAsStringAsync();
                var listPacientes = JsonConvert.DeserializeObject<List<TblPaciente>>(responseStringPacientes);

                var responseStringExamenes = await responseExamenes.Content.ReadAsStringAsync();
                var listExamenes = JsonConvert.DeserializeObject<List<TblExamene>>(responseStringExamenes);

                var listadoPaciente = listPacientes.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdPaciente.ToString(),
                        Selected = false
                    };
                });
                var listadoExamenes = listExamenes.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdExamen.ToString(),
                        Selected = false
                    };
                });

                ViewBag.listadoPacientes = listadoPaciente;
                ViewBag.listadoExamenes = listadoExamenes;
                return View();
            }
        }

        [HttpPost]
        public async Task<JsonResult> agregarConsulta(TblConsulta model)

        {
            if (!ModelState.IsValid)
            {
                return Json(null);
            }
            using (var http = new HttpClient())
            {
                var consultaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(consultaSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_urlConsultas, content);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var consulta = JsonConvert.DeserializeObject<TblConsulta>(responseString);
                return Json(consulta);
            }
            
        }
        
        [HttpPost]
        public async Task<JsonResult> consultasPaciente(int Paciente)

        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlConsultas+"/"+Paciente);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                
                    var responseString = await response.Content.ReadAsStringAsync();
                    var consulta = JsonConvert.DeserializeObject<List<ConsultasViewModel>>(responseString);
                    return Json(consulta);
            }

        }
    }
}