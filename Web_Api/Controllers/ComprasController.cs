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
    public class ComprasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ComprasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCompra>>> GetTblCompras()
        {
            return Ok(await _context.TblCompras.ToListAsync());
        }

        // POST: api/Compras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCompra>> PostTblCompra(TblCompra tblCompra)
        {
            _context.TblCompras.Add(tblCompra);
            await _context.SaveChangesAsync();

            return Ok(tblCompra);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompra>> GetTblCompras(int id)
        {
            var Compra = await _context.TblCompras.FindAsync(id);

            if (Compra == null)
            {
                return NotFound();
            }

            return Ok(Compra);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCompra(int id)
        {
            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            _context.TblCompras.Remove(tblCompra);
            await _context.SaveChangesAsync();

            return Ok(tblCompra);
        }

        private bool TblCompraExists(int id)
        {
            return _context.TblCompras.Any(e => e.IdCompras == id);
        }
    }
}
