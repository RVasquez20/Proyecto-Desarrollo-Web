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
        public async Task<ActionResult> GetTblHabitaciones()
        {
            var listadoHabitacion = _context.TblHabitaciones.Join(_context.TblClinicas,
                h => h.IdClinica,
                c => c.IdClinica,
                (h,c) => new
                {     
                    IdHabitacion = h.IdHabitacion,
                    NoHabitacion = h.NoHabitacion,
                    IdClinica = h.IdClinica,
                    Clinica = c.Nombre,
                    CantidadMaxPacientes = h.CantidadMaxPacientes
                }
                ).ToList();
            return Ok(listadoHabitacion);
        }
        //Habitaciones Disponibles

        [HttpGet]
        [Route("HabitacionesDisponibles")]
        public async Task<IActionResult> getHabitacionesDisponibles()
        {
            
            var habs = _context.TblHabitaciones.Select(x=>x.IdHabitacion).ToList();
            var listadoHab = _context.TblHabitaciones.Join(_context.TblPacientesHabitaciones,
                h => h.IdHabitacion,
                p => p.IdHabitacion,
                (h, p) => new
                {
                    IdHabitacion = h.IdHabitacion
                }).GroupBy(x=>x.IdHabitacion).Select(y=>y.Key).ToList();

            var listDetail = _context.TblHabitaciones.Join(_context.TblPacientesHabitaciones,
                h => h.IdHabitacion,
                p => p.IdHabitacion,
                (h, p) => new
                {
                    IdHabitacion = h.IdHabitacion,
                    NoHabitacion = h.NoHabitacion,
                    IdClinica = h.IdClinica,
                    CantidadMaxPacientes = h.CantidadMaxPacientes

                }).Join(_context.TblClinicas,
                h => h.IdClinica,
                c => c.IdClinica,
                (h, c) => new
                {
                    IdHabitacion = h.IdHabitacion,
                    NoHabitacion = h.NoHabitacion,
                    IdClinica = h.IdClinica,
                    Clinica = c.Nombre,
                    CantidadMaxPacientes = h.CantidadMaxPacientes
                }).GroupBy(
                hab => hab.IdHabitacion,
                (b, h) => new
                {
                    Key = b,
                    Count = h.Count()
                });
            var listAllDetail = _context.TblHabitaciones.Join(_context.TblClinicas,
              h => h.IdClinica,
              c => c.IdClinica,
              (h, c) => new
              {
                  IdHabitacion = h.IdHabitacion,
                  NoHabitacion = h.NoHabitacion,
                  IdClinica = h.IdClinica,
                  Clinica = c.Nombre,
                  CantidadMaxPacientes = h.CantidadMaxPacientes
              }).ToList();

          IDictionary<int,int> keyCount=new Dictionary<int,int>();
            foreach (var resultado in listDetail) {  
                keyCount.Add(resultado.Key, resultado.Count);
            }    


            var result = new List<object>();
            foreach (var h in habs)
                {
                   if (listadoHab.Contains(h))
                    {
                        if (keyCount[h] < 4)
                        {
                            result.Add(listAllDetail.Where(x => x.IdHabitacion == h).FirstOrDefault());
                        }
                   }
                    else
                    {
                        result.Add(listAllDetail.Where(x => x.IdHabitacion == h).FirstOrDefault());
                    }
                }
                return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TblHabitacione>> GetTblHabitaciones(int id)
        {
            var Habitaciones = await _context.TblHabitaciones.FindAsync(id);

            if (Habitaciones == null)
            {
                return NotFound("No se encontro el Registro");
            }

            return Ok(Habitaciones);
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
