using System;
using System.Collections.Generic;
using System.Data;
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
    public class AccessRolesController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public AccessRolesController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/AccessRoles
        [HttpGet]
        public async Task<ActionResult> GetTblAccessRoles()
        {

            var listado = _context.TblAccessRoles.ToList().Join(_context.TblRoles,
               Accesroles => Accesroles.IdRol,
               Roles => Roles.IdRol,
               (Accesroles, Roles) => new
               {
                   IdAccessRoles = Accesroles.IdAccessRoles,
                   IdRol = Accesroles.IdRol,
                   IdAccess = Accesroles.IdAccess,
                   Roles = Roles.IdRol
                   
               }).ToList().Join(_context.TblAccesses,
               Accesroles=>Accesroles.IdAccess,
               Access=>Access.IdAccess,
               (Accesroles, Access) => new
               {
                   IdAccessRole = Accesroles.IdAccessRoles,
                   IdRol = Accesroles.IdRol,
                   IdAccess = Accesroles.IdAccess,
                   Roles = Accesroles.Roles,
                   Access=Access.Name
               }).ToList();
            

            return Ok(listado);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblAccessRole>> GetTblAccessRoles(int id)
        {
            var AccessRole = await _context.TblAccessRoles.FindAsync(id);

            if (AccessRole == null)
            {
                return NotFound();
            }

            return Ok(AccessRole);
        }

        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblAccessRole(int id, TblAccessRole tblAccessRole)
        {
            if (id != tblAccessRole.IdAccessRoles)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblAccessRole).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblAccessRoleExists(id))
                {
                    return NotFound("No se encontro");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblAccessRole);
        }

        // POST: api/AccessRoles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblAccessRole>> PostTblAccessRole(TblAccessRole tblAccessRole)
        {
            _context.TblAccessRoles.Add(tblAccessRole);
            await _context.SaveChangesAsync();

            return Ok(tblAccessRole);
        }

        // DELETE: api/AccessRoles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblAccessRole(int id)
        {
            var tblAccessRole = await _context.TblAccessRoles.FindAsync(id);
            if (tblAccessRole == null)
            {
                return NotFound("No se encontro");
            }

            _context.TblAccessRoles.Remove(tblAccessRole);
            await _context.SaveChangesAsync();

            return Ok("Eliminado");
        }

        private bool TblAccessRoleExists(int id)
        {
            return _context.TblAccessRoles.Any(e => e.IdAccessRoles == id);
        }
    }
}
