using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System.Text.Json;
using Web_Api.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CargoController : Controller
    {
        public readonly ClinicaMedicaContext db;
        public CargoController(ClinicaMedicaContext context)
        {
            db = context;
        }
        // GET: api/<CargoController>
        [Route("Listado")]
        [HttpGet]
        public async Task<IActionResult> ListadoCargos()
        {
            
                
                return Ok(await db.TblCargos.ToListAsync());
            
        }
        [Route("Empleados/Listado")]
        [HttpGet]
        public JsonResult ListadoEmpleados()
        {
            
            
                var oEmpleados = db.TblEmpleados.ToList()
                   .Join(db.TblCargos.ToList(),
                   e => e.IdCargo,
                   c => c.IdCargo,
                   (e, c) => new tblEmpleadosViewModel
                   {
                       IdEmpleado = e.IdEmpleado,
                       CodigoEmpleado=e.CodigoEmpleado,
                       Nombre = e.Nombre,
                       Apellido = e.Apellido,
                       Direccion = e.Direccion,
                       Telefono = (int)e.Telefono,
                       IdCargo = c.IdCargo,
                       IdClinica = e.IdClinica,
                       Cargo=c.Cargo
                   }).ToList();
                return Json(oEmpleados);
            
        }

        
    }
}
