using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class VentaController : Controller
    {
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Ventas";
        private readonly string _urlProductos = "https://apiclinica.azurewebsites.net/api/Productos";
        // GET: VentaI
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
                var listadoVentas = JsonConvert.DeserializeObject<List<TblVenta>>(responseString);
                return View(listadoVentas);
            }

            
        }

        public ActionResult newVenta()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddVenta(TblVenta model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            /* using (var http = new HttpClient())
             {
                 var VentaSerializada = JsonConvert.SerializeObject(model);
                 var content = new StringContent(VentaSerializada, Encoding.UTF8, "application/json");
                 var response = await http.PostAsync(_url, content);
                 if (!response.IsSuccessStatusCode)
                 {
                     return View("Error");
                 }
                 return RedirectToAction("VentaDetalle");
             }*/
            return RedirectToAction("VentaDetalle", "Venta", new {data=1});
        }
        public async Task<ActionResult> VentaDetalle(int? data)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlProductos);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoProductos = JsonConvert.DeserializeObject<List<ProductosViewModel>>(responseString);
                var listadoProducto = listadoProductos.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdProducto.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoProducto = listadoProducto;
                ViewBag.data = data;
                return View();
            }
            
        }

        [HttpPost]
        public JsonResult AddVentaDetalle(TblVentasDetalle model)
        {
            return Json(model);
        }
    }
}