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
    public class ExamenesConsultasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ExamenesConsultasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/ExamenesConsultas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblExamenesConsulta>>> GetTblExamenesConsultas()
        {
            return Ok(await _context.TblExamenesConsultas.ToListAsync());
        }

        // GET: api/ExamenesConsultas/5
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTblExamenesConsulta(int id)
        {
            var listadoExamenesConsulta = _context.TblExamenesConsultas
               .Where(x => x.IdConsulta == id)
               .Join(_context.TblExamenes,
               vd => vd.IdExamen,
               v => v.IdExamen,
               (vd, v) => new
               {
                   IdExamenConsulta = vd.IdExamenConsulta,
                   IdExamen = vd.IdExamen,
                   IdConsulta = vd.IdConsulta,
                   Nombre = v.Nombre
               }
               ).ToList();

            if (listadoExamenesConsulta == null)
            {
                return NotFound("No se encontro el Registro");
            }

            return Ok(listadoExamenesConsulta);
        }



        // PUT: api/ExamenesConsultas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblExamenesConsulta(int id, TblExamenesConsulta tblExamenesConsulta)
        {
            if (id != tblExamenesConsulta.IdExamenConsulta)
            {
                return BadRequest("No se encontro el Registro");
            }

            _context.Entry(tblExamenesConsulta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblExamenesConsultaExists(id))
                {
                    return NotFound("No se encontro el Registro");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/ExamenesConsultas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTblExamenesConsulta(TblExamenesConsulta tblExamenesConsulta)
        {
            _context.TblExamenesConsultas.Add(tblExamenesConsulta);
            await _context.SaveChangesAsync();
            var listadoExamenConsulta = _context.TblExamenesConsultas
                .Where(x=>x.IdExamenConsulta==tblExamenesConsulta.IdExamenConsulta)
                .Join(_context.TblExamenes,
                ec => ec.IdExamen,
                e => e.IdExamen,
                (ec, e) => new
                {
                    IdExamenConsulta = ec.IdExamenConsulta,
                    IdExamen = ec.IdExamen,
                    IdConsulta = ec.IdConsulta,
                    Nombre = e.Nombre,
                    Descripcion = e.Descripcion,
                    Precio = e.Precio
                });

            return Ok(listadoExamenConsulta);
        }

        // DELETE: api/ExamenesConsultas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblExamenesConsulta(int id)
        {
            var tblExamenesConsulta = await _context.TblExamenesConsultas.FindAsync(id);
            if (tblExamenesConsulta == null)
            {
                return NotFound("No se encontro el Registro");
            }

            _context.TblExamenesConsultas.Remove(tblExamenesConsulta);
            await _context.SaveChangesAsync();

            return Ok("Registro Eliminado");
        }

        private bool TblExamenesConsultaExists(int id)
        {
            return _context.TblExamenesConsultas.Any(e => e.IdExamenConsulta == id);
        }
    }
}
