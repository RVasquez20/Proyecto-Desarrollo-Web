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
    public class LoteProductoController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public LoteProductoController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/LoteProducto
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblLoteProducto>>> GetTblLoteProductos()
        {
            return Ok(await _context.TblLoteProductos.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TblLoteProducto>> GetTblHabitaciones(int id)
        {
            var LoteProductos = await _context.TblLoteProductos.FindAsync(id);

            if (LoteProductos == null)
            {
                return NotFound("No se encontro el Registro");
            }

            return Ok(LoteProductos);
        }


        // PUT: api/LoteProducto/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblLoteProducto(int id, TblLoteProducto tblLoteProducto)
        {
            if (id != tblLoteProducto.IdLoteProducto)
            {
                return BadRequest();
            }

            _context.Entry(tblLoteProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblLoteProductoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblLoteProducto);
        }

        // POST: api/LoteProducto
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblLoteProducto>> PostTblLoteProducto(TblLoteProducto tblLoteProducto)
        {
            _context.TblLoteProductos.Add(tblLoteProducto);
            await _context.SaveChangesAsync();

            return Ok(tblLoteProducto);
        }

        // DELETE: api/LoteProducto/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblLoteProducto(int id)
        {
            var tblLoteProducto = await _context.TblLoteProductos.FindAsync(id);
            if (tblLoteProducto == null)
            {
                return NotFound();
            }

            _context.TblLoteProductos.Remove(tblLoteProducto);
            await _context.SaveChangesAsync();

            return Ok(tblLoteProducto);
        }

        private bool TblLoteProductoExists(int id)
        {
            return _context.TblLoteProductos.Any(e => e.IdLoteProducto == id);
        }
    }
}
