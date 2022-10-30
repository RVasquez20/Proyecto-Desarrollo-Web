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
    public class HabitacionController : Controller
    {
<<<<<<< HEAD
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Habitaciones";
        private readonly string _urlClinica = "https://apiclinica.azurewebsites.net/api/Clinicas";
        private readonly string _urlHabsDispo= "https://apiclinica.azurewebsites.net/api/Habitaciones/HabitacionesDisponibles";
        public async Task<ActionResult> Index()

        {
=======
        //recibir una lista de una api 
        private readonly string _url = "https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4/LoteProducto";
        public async Task<ActionResult> Index()

        {

            //https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoHabitacion = JsonConvert.DeserializeObject<List<HabitacionesViewModel>>(responseString);
                return View(listadoHabitacion);
            }



<<<<<<< HEAD
        }
        public async Task<ActionResult> HabitacionesDisponibles()

        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlHabsDispo);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoHabitacion = JsonConvert.DeserializeObject<List<TblHabitacione>>(responseString);
                return View(listadoHabitacion);
            }



        }
        [HttpGet]
        public async Task<ActionResult> GetAllData()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlHabsDispo);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoHabitacion = JsonConvert.DeserializeObject<List<TblHabitacione>>(responseString);
                return PartialView("_DataList", listadoHabitacion);
            }
        }

=======
        }

        
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<ActionResult> newHabitaciones()
        {


            using (var http = new HttpClient())
            {
<<<<<<< HEAD
                var response = await http.GetAsync(_urlClinica);
=======
                var response = await http.GetAsync(_url);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
<<<<<<< HEAD
                var listadoClinicas = JsonConvert.DeserializeObject<List<TblClinica>>(responseString);

               var listadoClinica = listadoClinicas.ConvertAll(r =>
               {
                   return new SelectListItem()
                   {
                       Text = r.Nombre,
                       Value = r.IdClinica.ToString(),
=======
                var listadoHabitacion = JsonConvert.DeserializeObject<List<HabitacionesViewModel>>(responseString);

               var listadoClinica = listadoHabitacion.ConvertAll(r =>
               {
                   return new SelectListItem()
                   {
                       Text = r.nombre,
                       Value = r.idClinica.ToString(),
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                       Selected = false
                   };
               });
                ViewBag.listadoClinica = listadoClinica;

                return View();
            }        
            }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
<<<<<<< HEAD
        public async Task<ActionResult> agregarHabitacion(TblHabitacione model)
=======
        public async Task<ActionResult> agregarHabitacion(HabitacionesViewModel model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var habitacionSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(habitacionSerializada, Encoding.UTF8, "application/json");
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
        public async Task<ActionResult> modificarHabitacion(int id)
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
                var habitacion = JsonConvert.DeserializeObject<TblHabitacione>(responseString);
=======
                var habitacion = JsonConvert.DeserializeObject<HabitacionesViewModel>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(habitacion);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> modificarHabitacion(TblHabitacione model)
=======
        public async Task<ActionResult> modificarHabitacion(HabitacionesViewModel model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            using (var http = new HttpClient())
            {
                var habitacionSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(habitacionSerializada, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = await http.PutAsync(_url + "/" + model.IdHabitacion, content);
=======
                var response = await http.PutAsync(_url + "/" + model.idHabitacion, content);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
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
        public async Task<string> eliminarHabitacion(int id)
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