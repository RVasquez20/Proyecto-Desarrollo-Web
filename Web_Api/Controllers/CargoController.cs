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
    public class CargoController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public CargoController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Cargo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblCargo>>> GetTblCargos()
        {
            return Ok(await _context.TblCargos.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCargo>> GetTblCargos(int id)
        {
            var Cargo = await _context.TblCargos.FindAsync(id);

            if (Cargo == null)
            {
                return NotFound();
            }

            return Ok(Cargo);
        }



        // PUT: api/Cargo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblCargo(int id, TblCargo tblCargo)
        {
            if (id != tblCargo.IdCargo)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblCargo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblCargoExists(id))
                {
                    return NotFound("No se encontro el cargo");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblCargo);
        }

        // POST: api/Cargo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCargo>> PostTblCargo(TblCargo tblCargo)
        {
            _context.TblCargos.Add(tblCargo);
            await _context.SaveChangesAsync();

            return Ok(tblCargo);
        }

        // DELETE: api/Cargo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCargo(int id)
        {
            var tblCargo = await _context.TblCargos.FindAsync(id);
            if (tblCargo == null)
            {
                return NotFound("No se encontro el cargo");
            }

            _context.TblCargos.Remove(tblCargo);
            await _context.SaveChangesAsync();

            return Ok("Cargo eliminado");
        }

        private bool TblCargoExists(int id)
        {
            return _context.TblCargos.Any(e => e.IdCargo == id);
        }
    }
}
