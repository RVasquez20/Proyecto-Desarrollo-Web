using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.permisos;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class ExamenController : Controller
    {
        //recibir una lista de una api 
<<<<<<< HEAD
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Examenes";
        public async Task<ActionResult> Index()

        {
=======
        private readonly string _url = "https://63572b429243cf412f942721.mockapi.io/prueba3/Examen";
        public async Task<ActionResult> Index()

        {

            //https://63572b429243cf412f942721.mockapi.io/prueba3/Examen
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
<<<<<<< HEAD
                var listadoExamenes = JsonConvert.DeserializeObject<List<TblExamene>>(responseString);
=======
                var listadoExamenes = JsonConvert.DeserializeObject<List<Examen>>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(listadoExamenes);
            }



        }
        public ActionResult newExamen()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
<<<<<<< HEAD
        public async Task<ActionResult> agregarExamen(TblExamene model)
=======
        public async Task<ActionResult> agregarExamen(Examen model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var examenSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(examenSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

<<<<<<< HEAD
        
=======
        //trae la vista con los datos cargados
        [HttpGet]
        [Route("modificar/(id)")]
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<ActionResult> modificarExamen(int id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
<<<<<<< HEAD
                var examen = JsonConvert.DeserializeObject<TblExamene>(responseString);
=======
                var examen = JsonConvert.DeserializeObject<Examen>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(examen);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> modificarExamen(TblExamene model)
=======
        public async Task<ActionResult> modificarexamen(Examen model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            using (var http = new HttpClient())
            {
                var examenSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(examenSerializada, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = await http.PutAsync(_url + "/" + model.IdExamen, content);
=======
                var response = await http.PutAsync(_url + "/" + model.idExamen, content);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
<<<<<<< HEAD
        
=======
        //elimina los datos de la bd
        [HttpGet]
        [Route("eliminar/(id)")]
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<string> eliminarExamen(int id)
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
