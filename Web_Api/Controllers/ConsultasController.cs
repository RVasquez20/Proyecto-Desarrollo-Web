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
    public class ConsultasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ConsultasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Consultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblConsulta>>> GetTblConsultas()
        {
            return Ok(await _context.TblConsultas.ToListAsync());
        }


        // PUT: api/Consultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblConsulta(int id, TblConsulta tblConsulta)
        {
            if (id != tblConsulta.IdConsulta)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblConsulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblConsultaExists(id))
                {
                    return NotFound("No existe el registro");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblConsulta);
        }

        // POST: api/Consultas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblConsulta>> PostTblConsulta(TblConsulta tblConsulta)
        {
            try
            {
                _context.TblConsultas.Add(tblConsulta);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(tblConsulta);
        }

        // DELETE: api/Consultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblConsulta(int id)
        {
            var tblConsulta = await _context.TblConsultas.FindAsync(id);
            if (tblConsulta == null)
            {
                return NotFound("No existe el registro");
            }

            _context.TblConsultas.Remove(tblConsulta);
            await _context.SaveChangesAsync();

            return Ok("Registro eliminado");
        }

        private bool TblConsultaExists(int id)
        {
            return _context.TblConsultas.Any(e => e.IdConsulta == id);
        }
    }
}
