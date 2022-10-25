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
    public class ClinicasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ClinicasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Clinicas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblClinica>>> GetTblClinicas()
        {
            return Ok(await _context.TblClinicas.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblClinica>> GetTblClinicas(int id)
        {
            var Clinica = await _context.TblClinicas.FindAsync(id);

            if (Clinica == null)
            {
                return NotFound();
            }

            return Ok(Clinica);
        }


        // PUT: api/Clinicas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblClinica(int id, TblClinica tblClinica)
        {
            if (id != tblClinica.IdClinica)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblClinica).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblClinicaExists(id))
                {
                    return NotFound("No se encontro la clinica");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblClinica);
        }

        // POST: api/Clinicas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblClinica>> PostTblClinica(TblClinica tblClinica)
        {
            _context.TblClinicas.Add(tblClinica);
            await _context.SaveChangesAsync();

            return Ok(tblClinica);
        }

        // DELETE: api/Clinicas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblClinica(int id)
        {
            var tblClinica = await _context.TblClinicas.FindAsync(id);
            if (tblClinica == null)
            {
                return NotFound("No se encontro la clinica");
            }

            _context.TblClinicas.Remove(tblClinica);
            await _context.SaveChangesAsync();

            return Ok("Clinica eliminada");
        }

        private bool TblClinicaExists(int id)
        {
            return _context.TblClinicas.Any(e => e.IdClinica == id);
        }
    }
}
