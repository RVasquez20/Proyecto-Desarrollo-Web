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

        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Clinicas";

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

                var listadoClinica = JsonConvert.DeserializeObject<List<TblClinica>>(responseString);

                return View(listadoClinica);
            }



        }
        public ActionResult newClinic()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]

        public async Task<ActionResult> agregarClinica(TblClinica model)

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

                var clinica = JsonConvert.DeserializeObject<TblClinica>(responseString);

                return View(clinica);
            }

        }

        //modifica los datos de la bd
        [HttpPost]

        public async Task<ActionResult> modificarClinica(TblClinica model)

        {
            using (var http = new HttpClient())
            {
                var clinicaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(clinicaSerializada, Encoding.UTF8, "application/json");

                var response = await http.PutAsync(_url + "/" + model.IdClinica, content);

                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

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