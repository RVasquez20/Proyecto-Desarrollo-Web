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
    public class RolesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public RolesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Roles listado
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblRole>>> GetTblRoles()
        {
            return Ok(await _context.TblRoles.ToListAsync());
        }

        // PUT: api/Roles/5 modificar
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblRole(int id, TblRole tblRole)
        {
            if (id != tblRole.IdRol)
            {
                return BadRequest();
            }

            _context.Entry(tblRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblRoleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblRole);
        }

        // POST: api/Roles insert
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblRole>> PostTblRole(TblRole tblRole)
        {
            _context.TblRoles.Add(tblRole);
            await _context.SaveChangesAsync();

            return Ok(tblRole);
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblRole(int id)
        {
            var tblRole = await _context.TblRoles.FindAsync(id);
            if (tblRole == null)
            {
                return NotFound();
            }

            _context.TblRoles.Remove(tblRole);
            await _context.SaveChangesAsync();

            return Ok(tblRole);
        }

        private bool TblRoleExists(int id)
        {
            return _context.TblRoles.Any(e => e.IdRol == id);
        }
    }
}