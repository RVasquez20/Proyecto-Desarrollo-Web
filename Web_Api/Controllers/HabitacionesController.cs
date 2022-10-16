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
    public class HabitacionesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public HabitacionesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Habitaciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblHabitacione>>> GetTblHabitaciones()
        {
            return Ok(await _context.TblHabitaciones.ToListAsync());
        }


        // PUT: api/Habitaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblHabitacione(int id, TblHabitacione tblHabitacione)
        {
            if (id != tblHabitacione.IdHabitacion)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblHabitacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblHabitacioneExists(id))
                {
                    return NotFound("No se encontro la habitacion");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblHabitacione);
        }

        // POST: api/Habitaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblHabitacione>> PostTblHabitacione(TblHabitacione tblHabitacione)
        {
            _context.TblHabitaciones.Add(tblHabitacione);
            await _context.SaveChangesAsync();

            return Ok(tblHabitacione);
        }

        // DELETE: api/Habitaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblHabitacione(int id)
        {
            var tblHabitacione = await _context.TblHabitaciones.FindAsync(id);
            if (tblHabitacione == null)
            {
                return NotFound("No se encontro la habitacion");
            }

            _context.TblHabitaciones.Remove(tblHabitacione);
            await _context.SaveChangesAsync();

            return Ok("Se elimino la habitacion");
        }

        private bool TblHabitacioneExists(int id)
        {
            return _context.TblHabitaciones.Any(e => e.IdHabitacion == id);
        }
    }
}
