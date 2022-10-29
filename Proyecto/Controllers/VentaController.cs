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
using static System.Net.WebRequestMethods;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class VentaController : Controller
    {
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Ventas";
        private readonly string _urlProductos = "https://apiclinica.azurewebsites.net/api/Productos";
        private readonly string _urlPacientes = "https://apiclinica.azurewebsites.net/api/Pacientes";
        private readonly string _urlVd = "https://apiclinica.azurewebsites.net/api/VentasDetalle";
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
                var listadoVentas = JsonConvert.DeserializeObject<List<VentaViewModel>>(responseString);
                return View(listadoVentas);
            }

            
        }

        public async Task<ActionResult> newVenta()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlPacientes);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoPacientes = JsonConvert.DeserializeObject<List<TblPaciente>>(responseString);
                var listadoPaciente = listadoPacientes.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdPaciente.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoPaciente = listadoPaciente;
                return View();
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddVenta(TblVenta model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
             {
                 var VentaSerializada = JsonConvert.SerializeObject(model);
                 var content = new StringContent(VentaSerializada, Encoding.UTF8, "application/json");
                 var response = await http.PostAsync(_url, content);
                 if (!response.IsSuccessStatusCode)
                 {
                     return View("Error");
                 }
                var responseString = await response.Content.ReadAsStringAsync();
                var venta = JsonConvert.DeserializeObject<TblVenta>(responseString);
                return RedirectToAction("VentaDetalle", "Venta", new { data = venta.IdVentas });
            }
            
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
        public async Task<JsonResult> AddVentaDetalle(TblVentasDetalle model)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlProductos);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return Json(null);
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoProductos = JsonConvert.DeserializeObject<List<ProductosViewModel>>(responseString);
                var producto = listadoProductos.Find(r => r.IdProducto == model.IdProducto);
                var responseData = new
                {
                    Producto = producto.Nombre,
                    Cantidad = model.Cantidad
                };

                ///add detalle
                var ventaDetalle = JsonConvert.SerializeObject(model);
                var content = new StringContent(ventaDetalle, Encoding.UTF8, "application/json");
                var respuesta = await http.PostAsync(_urlVd, content);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return Json(null) ;
                }
                //Actualizar
                var actualizacion = new ActualizarExistencias()
                {
                    
                    Id = model.IdProducto,
                    Cantidad = (int)model.Cantidad,
                    Venta_Compra = "Venta"
                };
                var ActualizacionExistencias = JsonConvert.SerializeObject(actualizacion);
                var contentActualizacion = new StringContent(ActualizacionExistencias, Encoding.UTF8, "application/json");
                var respuestaActualizacion = await http.PostAsync(_urlProductos+"/Actualizar", contentActualizacion);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                return Json(responseData);
            }
        }

        [HttpPost]
        public async Task<JsonResult> getPrecios(int id)
        {
            {
                using (var http = new HttpClient())
                {
                    var response = await http.GetAsync(_urlProductos);
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return Json(null);
                    }
                    var responseString = await response.Content.ReadAsStringAsync();
                    var listadoProductos = JsonConvert.DeserializeObject<List<ProductosViewModel>>(responseString);
                    var producto = listadoProductos.Find(r => r.IdProducto == id);
                    var responseData = new
                    {
                        Precio = producto.Precio,
                        Stock = producto.Existencia
                    };
                    return Json(responseData);
                }
            }
        }
    }
}