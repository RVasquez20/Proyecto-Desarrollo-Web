using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_Api.Models;

namespace Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public VentasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVenta>>> GetTblVentas()
        {
            return Ok(await _context.TblVentas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblVenta>> GetTblVentas(int id)
        {
            var Ventas = await _context.TblVentas.FindAsync(id);

            if (Ventas == null)
            {
                return NotFound("No se encontro el registro");
            }

            return Ok(Ventas);

        }



        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblVenta>> PostTblVenta(TblVenta tblVenta)
        {
            _context.TblVentas.Add(tblVenta);
            await _context.SaveChangesAsync();

            return Ok(tblVenta);
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblVenta(int id)
        {
            var tblVenta = await _context.TblVentas.FindAsync(id);
            if (tblVenta == null)
            {
                return NotFound();
            }

            _context.TblVentas.Remove(tblVenta);
            await _context.SaveChangesAsync();

            return Ok(tblVenta);
        }

        private bool TblVentaExists(int id)
        {
            return _context.TblVentas.Any(e => e.IdVentas == id);
        }
    }
}
