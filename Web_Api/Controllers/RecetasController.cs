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
    public class RecetasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public RecetasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Recetas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblReceta>>> GetTblRecetas()
        {
            return Ok(await _context.TblRecetas.ToListAsync());
        }

        // PUT: api/Recetas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblReceta(int id, TblReceta tblReceta)
        {
            if (id != tblReceta.IdReceta)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblReceta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRecetaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblReceta);
        }

        // POST: api/Recetas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblReceta>> PostTblReceta(TblReceta tblReceta)
        {
            _context.TblRecetas.Add(tblReceta);
            await _context.SaveChangesAsync();

            return Ok(tblReceta);
        }

        // DELETE: api/Recetas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblReceta(int id)
        {
            var tblReceta = await _context.TblRecetas.FindAsync(id);
            if (tblReceta == null)
            {
                return NotFound("No se encontro el id");
            }

            _context.TblRecetas.Remove(tblReceta);
            await _context.SaveChangesAsync();

            return Ok("Se elimino correctamente");
        }

        private bool TblRecetaExists(int id)
        {
            return _context.TblRecetas.Any(e => e.IdReceta == id);
        }
    }
}
