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
    public class DiagnosticoController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public DiagnosticoController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Diagnostico
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblDiagnostico>>> GetTblDiagnosticos()
        {
            return Ok(await _context.TblDiagnosticos.ToListAsync());
        }

        // GET: api/Diagnostico/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TblDiagnostico>> GetTblDiagnostico(int id)
        {
            var tblDiagnostico = await _context.TblDiagnosticos.FindAsync(id);

            if (tblDiagnostico == null)
            {
                return NotFound();
            }

            return Ok(tblDiagnostico);
        }

        // PUT: api/Diagnostico/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblDiagnostico(int id, TblDiagnostico tblDiagnostico)
        {
            if (id != tblDiagnostico.IdDiagnostico)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblDiagnostico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblDiagnosticoExists(id))
                {
                    return NotFound("No se encontro el registro");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Se actualizo correctamente");
        }

        // POST: api/Diagnostico
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblDiagnostico>> PostTblDiagnostico(TblDiagnostico tblDiagnostico)
        {
            _context.TblDiagnosticos.Add(tblDiagnostico);
            await _context.SaveChangesAsync();

            return Ok(tblDiagnostico);
        }

        // DELETE: api/Diagnostico/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblDiagnostico(int id)
        {
            var tblDiagnostico = await _context.TblDiagnosticos.FindAsync(id);
            if (tblDiagnostico == null)
            {
                return NotFound("No se encontro el diagnostico");
            }

            _context.TblDiagnosticos.Remove(tblDiagnostico);
            await _context.SaveChangesAsync();

            return Ok("Registro eliminado");
        }

        private bool TblDiagnosticoExists(int id)
        {
            return _context.TblDiagnosticos.Any(e => e.IdDiagnostico == id);
        }
    }
}
