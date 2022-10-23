using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.permisos;

namespace WebApplication1.Controllers
{
    [ValidateSession]
    public class ProductoController : Controller
    {
        // GET: ProductoI
        public ActionResult Index()
        {
            var lista = new List<ProductosViewModel>()
            {
                new ProductosViewModel()
                {
                    idProductos = 1,
                    idLote_Producto = 1,
                    Lote_Producto = "Lote 1",
                    idClinica = 1,
                    Clinica = "Clinica 1",
                    nombre = "Producto 1",
                    idMarca = 1,
                    Marca = "Marca 1",
                    descripcion = "Descripcion 1",
                    precio = 100,
                    existencia = 10 
                },
                new ProductosViewModel()
                {
                    idProductos = 2,
                    idLote_Producto = 2,
                    Lote_Producto = "Lote 2",
                    idClinica = 2,
                    Clinica = "Clinica 2",
                    nombre = "Producto 2",
                    idMarca = 2,
                    Marca = "Marca 2",
                    descripcion = "Descripcion 2",
                    precio = 200,
                    existencia = 10
                }
            };
            return View(lista);
        }

        public ActionResult newProducto()
        {
            var dataLoteProducto = new List<LoteProductos>()
            {
                new LoteProductos()
                {
                    IdLoteProductos=1,
                    Descripcion="Lote 1",
                    noLote = 1,
                    FechaExpiracion = DateTime.Now
                },
                new LoteProductos()
                {
                    IdLoteProductos=2,
                    Descripcion="Lote 2",
                    noLote = 2,
                    FechaExpiracion = DateTime.Now
                },
                new LoteProductos()
                {
                    IdLoteProductos=3,
                    Descripcion="Lote 3",
                    noLote = 3,
                    FechaExpiracion = DateTime.Now
                }
            };
            var listadoLoteProducto = dataLoteProducto.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.Descripcion,
                    Value = r.IdLoteProductos.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoLoteProducto = listadoLoteProducto;

            var dataClinica = new List<ClinicaViewModel>()
            {
                new ClinicaViewModel()
                {
                    idClinica=1,
                    nombre="Clinica 1",
                    direccion = "Clinica 1"
                },
                new ClinicaViewModel()
                {
                    idClinica=1,
                    nombre="Clinica 2",
                    direccion = "Clinica 2"
                }
            };
            var listadoClinica = dataClinica.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.nombre + "," + r.direccion,
                    Value = r.idClinica.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoClinica = listadoClinica;

            var dataMarca = new List<Marcas>()
            {
                new Marcas()
                {
                    IdMarca=1,
                    Marca="Marca 1"
                },
                new Marcas()
                {
                    IdMarca=2,
                    Marca="Marca 2"
                },
                new Marcas()
                {
                    IdMarca=3,
                    Marca="Marca 3"
                }
            };
            var listadoMarca = dataMarca.ConvertAll(r =>
            {
                return new SelectListItem()
                {
                    Text = r.Marca,
                    Value = r.IdMarca.ToString(),
                    Selected = false
                };
            });
            ViewBag.listadoMarca = listadoMarca;
            return View();
        }
    }
}