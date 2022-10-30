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
    public class PacientesController : Controller
    {
        //recibir una lista de una api 
<<<<<<< HEAD
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Pacientes";
        public async Task<ActionResult> Index()

        {
            using (var http = new HttpClient())
            {
                var responsePaciente = await http.GetAsync(_url);
                if (responsePaciente.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await responsePaciente.Content.ReadAsStringAsync();
                var listadoPacientes = JsonConvert.DeserializeObject<List<TblPaciente>>(responseString);
=======
        private readonly string _url = "https://63572b429243cf412f942721.mockapi.io/prueba3/Paciente";
        public async Task<ActionResult> Index()

        {

            //https://63572b429243cf412f942721.mockapi.io/prueba3/Paciente
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoPacientes = JsonConvert.DeserializeObject<List<Pacientes>>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(listadoPacientes);
            }



        }
        public ActionResult newPaciente()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
<<<<<<< HEAD
        public async Task<ActionResult> agregarPacientes(TblPaciente model)
=======
        public async Task<ActionResult> agregarPacientes(Pacientes model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var pacienteSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(pacienteSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }

        //trae la vista con los datos cargados
<<<<<<< HEAD

=======
        [HttpGet]
        [Route("modificar/(id)")]
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<ActionResult> modificarPaciente(int id)
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
                var pacientes = JsonConvert.DeserializeObject<TblPaciente>(responseString);
=======
                var pacientes = JsonConvert.DeserializeObject<Pacientes>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(pacientes);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> modificarPaciente(TblPaciente model)
=======
        public async Task<ActionResult> modificarPaciente(Pacientes model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            using (var http = new HttpClient())
            {
                var pacienteSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(pacienteSerializada, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = await http.PutAsync(_url + "/" + model.IdPaciente, content);
=======
                var response = await http.PutAsync(_url + "/" + model.idPaciente, content);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }

        }
        //elimina los datos de la bd
<<<<<<< HEAD
=======
        [HttpGet]
        [Route("eliminar/(id)")]
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<string> eliminarPaciente(int id)
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