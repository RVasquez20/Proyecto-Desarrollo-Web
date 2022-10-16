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
    public class MarcasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public MarcasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Marcas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMarca>>> GetTblMarcas()
        {
            return Ok(await _context.TblMarcas.ToListAsync());
        }

        // PUT: api/Marcas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMarca(int id, TblMarca tblMarca)
        {
            if (id != tblMarca.IdMarca)
            {
                return BadRequest();
            }

            _context.Entry(tblMarca).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMarcaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(PostTblMarca);
        }

        // POST: api/Marcas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMarca>> PostTblMarca(TblMarca tblMarca)
        {
            _context.TblMarcas.Add(tblMarca);
            await _context.SaveChangesAsync();

            return Ok(tblMarca);
        }

        // DELETE: api/Marcas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMarca(int id)
        {
            var tblMarca = await _context.TblMarcas.FindAsync(id);
            if (tblMarca == null)
            {
                return NotFound();
            }

            _context.TblMarcas.Remove(tblMarca);
            await _context.SaveChangesAsync();

            return Ok(tblMarca);
        }

        private bool TblMarcaExists(int id)
        {
            return _context.TblMarcas.Any(e => e.IdMarca == id);
        }
    }
}
