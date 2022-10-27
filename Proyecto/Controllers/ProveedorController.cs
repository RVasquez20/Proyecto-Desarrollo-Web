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
        private readonly string _url = "https://63572b429243cf412f942721.mockapi.io/prueba3/Proveedor";
        public async Task<ActionResult> Index()

        {

            //https://63572b429243cf412f942721.mockapi.io/prueba3/
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_url);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoProveedores = JsonConvert.DeserializeObject<List<Proveedores>>(responseString);
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
        public async Task<ActionResult> agregarProveedor(Proveedores model)
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
        [HttpGet]
        [Route("modificar/(id)")]
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
                var proveedor = JsonConvert.DeserializeObject<Proveedores>(responseString);
                return View(proveedor);
            }

        }

        //modifica los datos de la bd
        [HttpPost]
        public async Task<ActionResult> modificarProveedor(Proveedores model)
        {
            using (var http = new HttpClient())
            {
                var proveedorSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(proveedorSerializada, Encoding.UTF8, "application/json");
                var response = await http.PutAsync(_url + "/" + model.idProveedor, content);
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