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
    public class ProveedorsController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ProveedorsController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Proveedors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProveedor>>> GetTblProveedors()
        {
            return Ok(await _context.TblProveedors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblProveedor>> GetTblProveedors(int id)
        {
            var Proveedores = await _context.TblProveedors.FindAsync(id);

            if (Proveedores == null)
            {
                return NotFound("No se encontro el Registro");
            }

            return Ok(Proveedores);
        }

        // PUT: api/Proveedors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProveedor(int id, TblProveedor tblProveedor)
        {
            if (id != tblProveedor.IdProveedor)
            {
                return BadRequest();
            }

            _context.Entry(tblProveedor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProveedorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblProveedor);
        }

        // POST: api/Proveedors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProveedor>> PostTblProveedor(TblProveedor tblProveedor)
        {
            _context.TblProveedors.Add(tblProveedor);
            await _context.SaveChangesAsync();

            return Ok(tblProveedor);
        }

        // DELETE: api/Proveedors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProveedor(int id)
        {
            var tblProveedor = await _context.TblProveedors.FindAsync(id);
            if (tblProveedor == null)
            {
                return NotFound();
            }

            _context.TblProveedors.Remove(tblProveedor);
            await _context.SaveChangesAsync();

            return Ok(tblProveedor);
        }

        private bool TblProveedorExists(int id)
        {
            return _context.TblProveedors.Any(e => e.IdProveedor == id);
        }
    }
}
