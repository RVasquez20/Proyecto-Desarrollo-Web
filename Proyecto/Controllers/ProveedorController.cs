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
    public class ProveedorController : Controller
    {
        //recibir una lista de una api 
<<<<<<< HEAD
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Proveedors";
=======
        private readonly string _url = "https://63572b429243cf412f942721.mockapi.io/prueba3/Proveedor";
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        public async Task<ActionResult> Index()

        {

<<<<<<< HEAD
=======
            //https://63572b429243cf412f942721.mockapi.io/prueba3/
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
                var listadoProveedores = JsonConvert.DeserializeObject<List<TblProveedor>>(responseString);
=======
                var listadoProveedores = JsonConvert.DeserializeObject<List<Proveedores>>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(listadoProveedores);
            }



        }
        public ActionResult newProveedor()
        {
            return View();
        }
        //agregar a el json
        [HttpPost]
        //siempre debe ser un model
<<<<<<< HEAD
        public async Task<ActionResult> agregarProveedor(TblProveedor model)
=======
        public async Task<ActionResult> agregarProveedor(Proveedores model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var proveedorSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(proveedorSerializada, Encoding.UTF8, "application/json");
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
        public async Task<ActionResult> modificarProveedor(int id)
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
                var proveedor = JsonConvert.DeserializeObject<TblProveedor>(responseString);
=======
                var proveedor = JsonConvert.DeserializeObject<Proveedores>(responseString);
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
                return View(proveedor);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
<<<<<<< HEAD
        public async Task<ActionResult> modificarProveedor(TblProveedor model)
=======
        public async Task<ActionResult> modificarProveedor(Proveedores model)
>>>>>>> 18857b6bb0833709fb4ab1c219a7f8f5bc7055d6
        {
            using (var http = new HttpClient())
            {
                var proveedorSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(proveedorSerializada, Encoding.UTF8, "application/json");
<<<<<<< HEAD
                var response = await http.PutAsync(_url + "/" + model.IdProveedor, content);
=======
                var response = await http.PutAsync(_url + "/" + model.idProveedor, content);
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
        public async Task<string> eliminarProveedor(int id)
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