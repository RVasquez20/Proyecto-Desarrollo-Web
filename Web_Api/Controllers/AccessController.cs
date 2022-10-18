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
    public class AccessController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public AccessController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Access
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblAccess>>> GetTblAccesses()
        {
            return Ok(await _context.TblAccesses.ToListAsync());
        }


        // PUT: api/Access/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAccess(int id, TblAccess tblAccess)
        {
            if (id != tblAccess.IdAccess)
            {
                return BadRequest("id no coincide");
            }

            _context.Entry(tblAccess).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAccessExists(id))
                {
                    return NotFound("no se encontro el menu");
                }
                else
                {
                    throw;
                }
            }

            return Ok();
        }

        // POST: api/Access
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAccess>> PostTblAccess(TblAccess tblAccess)
        {
            _context.TblAccesses.Add(tblAccess);
            await _context.SaveChangesAsync();

            return Ok(tblAccess);
        }

        // DELETE: api/Access/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAccess(int id)
        {
            var tblAccess = await _context.TblAccesses.FindAsync(id);
            if (tblAccess == null)
            {
                return NotFound("no se encontro el menu");
            }

            _context.TblAccesses.Remove(tblAccess);
            await _context.SaveChangesAsync();

            return Ok(tblAccess);
        }

        private bool TblAccessExists(int id)
        {
            return _context.TblAccesses.Any(e => e.IdAccess == id);
        }
    }
}
