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
    public class LoteProductoController : Controller
    {
        //recibir una lista de una api 
<<<<<<< HEAD
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/LoteProducto";
        public async Task<ActionResult> Index()

        {
=======
        private readonly string _url = " https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4/LoteProducto";
        public async Task<ActionResult> Index()

        {

            //https://63572d5b2712d01e14036ea9.mockapi.io/pruebas4/LoteProducto
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
                var listadoLoteProducto = JsonConvert.DeserializeObject<List<TblLoteProducto>>(responseString);
=======
                var listadoLoteProducto = JsonConvert.DeserializeObject<List<LoteProductos>>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(listadoLoteProducto);
            }



        }
        public ActionResult newLoteProductos()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
<<<<<<< HEAD
        public async Task<ActionResult> agregarLoteProducto(TblLoteProducto model)
=======
        public async Task<ActionResult> agregarLoteProducto(LoteProductos model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var LoteProductoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(LoteProductoSerializada, Encoding.UTF8, "application/json");
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
        public async Task<ActionResult> modificarLoteProducto(int id)
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
                var LoteProducto = JsonConvert.DeserializeObject<TblLoteProducto>(responseString);
=======
                var LoteProducto = JsonConvert.DeserializeObject<LoteProductos>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(LoteProducto);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> modificarLoteProducto(TblLoteProducto model)
=======
        public async Task<ActionResult> modificarLoteProducto(LoteProductos model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            using (var http = new HttpClient())
            {
                var LoteProductoSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(LoteProductoSerializada, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = await http.PutAsync(_url + "/" + model.IdLoteProducto, content);
=======
                var response = await http.PutAsync(_url + "/" + model.IdLoteProductos, content);
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
        public async Task<string> eliminarLoteProducto(int id)
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