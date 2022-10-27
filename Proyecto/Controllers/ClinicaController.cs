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
    public class ClinicaController : Controller
    {
        //recibir una lista de una api 
        private readonly string _url = "https://63572b429243cf412f942721.mockapi.io/prueba3/Clinica";
        public async Task<ActionResult> Index()

        {

            //https://63572b429243cf412f942721.mockapi.io/prueba3/Clinica
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoClinica = JsonConvert.DeserializeObject<List<Clinica>>(responseString);
                return View(listadoClinica);
            }



        }
        public ActionResult newClinic()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
        public async Task<ActionResult> agregarClinica(Clinica model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var clinicaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(clinicaSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

        //trae la vista con los datos cargados
        [HttpGet]
        [Route("modificar/(id)")]
        public async Task<ActionResult> modificarClinica(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var clinica = JsonConvert.DeserializeObject<Clinica>(responseString);
                return View(clinica);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarClinica(Clinica model)
        {
            using (var http = new HttpClient())
            {
                var clinicaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(clinicaSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.idClinica, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd
        [HttpGet]
        [Route("eliminar/(id)")]
        public async Task<string> eliminarClinica(int id)
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