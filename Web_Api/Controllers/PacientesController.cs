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
    public class PacientesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public PacientesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Pacientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblPaciente>>> GetTblPacientes()
        {
            return Ok(await _context.TblPacientes.ToListAsync());
        }

        // PUT: api/Pacientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPaciente(int id, TblPaciente tblPaciente)
        {
            if (id != tblPaciente.IdPaciente)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblPaciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPacienteExists(id))
                {
                    return NotFound("No se encontro la clinica");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblPaciente);
        }

        // POST: api/Pacientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPaciente>> PostTblPaciente(TblPaciente tblPaciente)
        {
            _context.TblPacientes.Add(tblPaciente);
            await _context.SaveChangesAsync();
            
            return Ok(tblPaciente);
        }

        // DELETE: api/Pacientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPaciente(int id)
        {
            var tblPaciente = await _context.TblPacientes.FindAsync(id);
            if (tblPaciente == null)
            {
                return NotFound("No se encontro el paciente");
            }

            _context.TblPacientes.Remove(tblPaciente);
            await _context.SaveChangesAsync();

            return Ok("Paciente eliminado");
        }

        private bool TblPacienteExists(int id)
        {
            return _context.TblPacientes.Any(e => e.IdPaciente == id);
        }
    }
}
