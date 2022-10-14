using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClinicasController : Controller
    {
       public readonly ClinicaMedicaContext _context;

        public ClinicasController(ClinicaMedicaContext context)
        {
            _context = context;
        }
        // GET: ClinicasController
        [Route("Listado/{id}")]
        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            return Ok(Json(await _context.TblClinicas.FindAsync(id)));
        }

    }
}
