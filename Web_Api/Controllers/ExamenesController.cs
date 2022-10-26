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
    public class ExamenesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ExamenesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Examenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblExamene>>> GetTblExamenes()
        {
            return Ok(await _context.TblExamenes.ToListAsync());
        }

        // PUT: api/Examenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblExamene(int id, TblExamene tblExamene)
        {
            if (id != tblExamene.IdExamen)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblExamene).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblExameneExists(id))
                {
                    return NotFound("No existe el examen");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblExamene);
        }


 
        [HttpGet("{id}")]
        public async Task<ActionResult<TblExamene>> GetTblExamenes(int id)
        {
            var Examenes = await _context.TblExamenes.FindAsync(id);

            if (Examenes == null)
            {
                return NotFound("No se encontro el Registro");
            }

            return Ok(Examenes);
        }



        // POST: api/Examenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblExamene>> PostTblExamene(TblExamene tblExamene)
        {
            _context.TblExamenes.Add(tblExamene);
            await _context.SaveChangesAsync();

            return Ok(tblExamene);
        }

        // DELETE: api/Examenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblExamene(int id)
        {
            var tblExamene = await _context.TblExamenes.FindAsync(id);
            if (tblExamene == null)
            {
                return NotFound("No existe el examen");
            }

            _context.TblExamenes.Remove(tblExamene);
            await _context.SaveChangesAsync();

            return Ok("Examen eliminado");
        }

        private bool TblExameneExists(int id)
        {
            return _context.TblExamenes.Any(e => e.IdExamen == id);
        }
    }
}
