using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class DiagnosticoController : Controller
    {
        //recibir una lista de una api 
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Diagnostico";
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
                var listadoDiagnostico = JsonConvert.DeserializeObject<List<TblDiagnostico>>(responseString);
                return View(listadoDiagnostico);
            }



        }
        
        [HttpPost]
        public async Task<JsonResult> agregarDiagnostico(TblDiagnostico model)
        {
            using (var http = new HttpClient())
            {
                var DiagnosticoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(DiagnosticoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var Diagnostico = JsonConvert.DeserializeObject<TblDiagnostico>(responseString);
                return Json(Diagnostico);
            }

        }

      
        public async Task<ActionResult> modificarDiagnostico(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var diagnostico = JsonConvert.DeserializeObject<TblDiagnostico>(responseString);
                return View(diagnostico);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult>modificarDiagnostico(TblDiagnostico model)
        {
            using (var http = new HttpClient())
            {
                var diagnosticoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(diagnosticoSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.IdDiagnostico, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd
        public async Task<string> eliminarDiagnostico(int id)
        {
            using (var http = new HttpClient())

            {
                var response = await http.DeleteAsync(_url + "/" + id);
                if (!response.IsSuccessStatusCode)
                {
                    return "Error";
                }
                return "Exito";
            }
        }

    }
}