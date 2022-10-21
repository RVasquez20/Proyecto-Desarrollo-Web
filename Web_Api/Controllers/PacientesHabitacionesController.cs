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
    public class PacientesHabitacionesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public PacientesHabitacionesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/PacientesHabitaciones
        [HttpGet]
        public async Task<ActionResult> GetTblPacientesHabitaciones()
        {
                var listado = _context.TblPacientesHabitaciones.ToList().Join(_context.TblPacientes,
                    PacientesHabitaciones => PacientesHabitaciones.IdPaciente,
                    Paciente => Paciente.IdPaciente,
                    (PacientesHabitaciones, Paciente) => new
                    {
                        IdPacHab=PacientesHabitaciones.IdPacHab,
                        IdPaciente = PacientesHabitaciones.IdPaciente,
                        IdHabitacion = PacientesHabitaciones.IdHabitacion,
                        Paciente = Paciente.Nombre

                    }).ToList().Join(_context.TblHabitaciones,
                    PacientesHabitaciones => PacientesHabitaciones.IdHabitacion,
                    Habitaciones => Habitaciones.IdHabitacion,
                    (PacientesHabitaciones, Habitaciones) => new
                    {
                        IdPacHab = PacientesHabitaciones.IdPacHab,
                        IdPaciente = PacientesHabitaciones.IdPaciente,
                        IdHabitacion = PacientesHabitaciones.IdHabitacion,
                        Paciente = PacientesHabitaciones.Paciente,
                        NumHabitacion = Habitaciones.NoHabitacion
                    }).ToList();


                return Ok(listado);

           
        }

        // PUT: api/PacientesHabitaciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblPacientesHabitacione(int id, TblPacientesHabitacione tblPacientesHabitacione)
        {
            if (id != tblPacientesHabitacione.IdPacHab)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblPacientesHabitacione).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblPacientesHabitacioneExists(id))
                {
                    return NotFound("No se encontro la clinica");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblPacientesHabitacione);
        }

        // POST: api/PacientesHabitaciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblPacientesHabitacione>> PostTblPacientesHabitacione(TblPacientesHabitacione tblPacientesHabitacione)
        {
            _context.TblPacientesHabitaciones.Add(tblPacientesHabitacione);
            await _context.SaveChangesAsync();

            return Ok(tblPacientesHabitacione);
        }

        // DELETE: api/PacientesHabitaciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblPacientesHabitacione(int id)
        {
            var tblPacientesHabitacione = await _context.TblPacientesHabitaciones.FindAsync(id);
            if (tblPacientesHabitacione == null)
            {
                return NotFound("No se encontro la clinica");
            }

            _context.TblPacientesHabitaciones.Remove(tblPacientesHabitacione);
            await _context.SaveChangesAsync();

            return Ok("Se elimino correctamente");
        }

        private bool TblPacientesHabitacioneExists(int id)
        {
            return _context.TblPacientesHabitaciones.Any(e => e.IdPacHab == id);
        }
    }
}
