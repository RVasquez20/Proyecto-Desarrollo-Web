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
    public class CompraController : Controller
    {
        private readonly string _url = "https://apiclinica.azurewebsites.net/api/Compras";
        private readonly string _urlProductos = "https://apiclinica.azurewebsites.net/api/Productos";
        private readonly string _urlProveedor = "https://apiclinica.azurewebsites.net/api/Proveedors";
        private readonly string _urlCd = "https://apiclinica.azurewebsites.net/api/ComprasDetalle";
        //GET: CompraI
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
                var listadoCompras = JsonConvert.DeserializeObject<List<CompraViewModel>>(responseString);
                return View(listadoCompras);
            }

        }

        public async Task<ActionResult> newCompra()
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlProveedor);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var listadoProveedor = JsonConvert.DeserializeObject<List<TblProveedor>>(responseString);
                var listadoProveedores = listadoProveedor.ConvertAll(r =>
                {
                    return new SelectListItem()
                    {
                        Text = r.Nombre,
                        Value = r.IdProveedor.ToString(),
                        Selected = false
                    };
                });
                ViewBag.listadoProveedor = listadoProveedores;
                return View();
            }
        }
        
        [HttpPost]
        public async Task<ActionResult> AddCompra(TblCompra model)
        {
            model.FechaOrden = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            using (var http = new HttpClient())
            {
                var CompraSerializada = JsonConvert.SerializeObject(model);
                var content = new StringContent(CompraSerializada, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(_url, content);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var compra = JsonConvert.DeserializeObject<TblCompra>(responseString);
                return RedirectToAction("CompraDetalle", "Compra", new { data = compra.IdCompras });
            }

        }

        public async Task<ActionResult> CompraDetalle(int? data)
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
        // addventasdetalle
        [HttpPost]
        public async Task<JsonResult> AddComprasDetalle(TblComprasDetalle model)
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
                var compraDetalle = JsonConvert.SerializeObject(model);
                var content = new StringContent(compraDetalle, Encoding.UTF8, "application/json");
                var respuesta = await http.PostAsync(_urlCd, content);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                //Actualizar
                var actualizacion = new ActualizarExistencias()
                {
                    
                    Id = model.IdProducto,
                    Cantidad = (int)model.Cantidad,
                    Venta_Compra = "Compra"
                };
                var ActualizacionExistencias = JsonConvert.SerializeObject(actualizacion);
                var contentActualizacion = new StringContent(ActualizacionExistencias, Encoding.UTF8, "application/json");
                var respuestaActualizacion = await http.PostAsync(_urlProductos + "/Actualizar", contentActualizacion);
                if (!respuesta.IsSuccessStatusCode)
                {
                    return Json(null);
                }
                return Json(responseData);
            }
        }
        //
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
        [HttpGet]
        public async Task<ActionResult> Details(int? id)
        {
            using (var http = new HttpClient())
            {
                var response = await http.GetAsync(_urlCd + "/" + id);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return View("Error");
                }
                var responseString = await response.Content.ReadAsStringAsync();
                var Detalles = JsonConvert.DeserializeObject<List<ComprasDetalleViewDetails>>(responseString);
                ViewBag.data = Detalles[0].NoOrden;
                int total = 0;
                foreach (var item in Detalles)
                {
                    total += (int)(item.Precio*item.Cantidad);
                }
                ViewBag.total = total;
                return View(Detalles);
            }
        }




    }
}