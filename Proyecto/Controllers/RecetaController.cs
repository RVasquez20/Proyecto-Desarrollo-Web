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
    public class RecetaController : Controller
    {

        //recibir una lista de una api 
        private readonly string _url = "https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4/Recetas";
        public async Task<ActionResult> Index()

        {

            //https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4/Recetas
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoRecetas = JsonConvert.DeserializeObject<List<Receta>>(responseString);
                return View(listadoRecetas);
            }



        }
        public ActionResult newReceta()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
        public async Task<ActionResult> agregarReceta(Receta model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var recetaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(recetaSerializada, Encoding.UTF8, "application/json");
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
        public async Task<ActionResult> modificarReceta(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var receta = JsonConvert.DeserializeObject<Receta>(responseString);
                return View(receta);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarReceta(Receta model)
        {
            using (var http = new HttpClient())
            {
                var recetaSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(recetaSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.idReceta, content);
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
        public async Task<string> eliminarReceta(int id)
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