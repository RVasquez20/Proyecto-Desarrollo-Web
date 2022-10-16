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
    public class UsuariosController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public UsuariosController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUsuario>>> GetTblUsuarios()
        {
            return Ok(await _context.TblUsuarios.ToListAsync());
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblUsuario(int id, TblUsuario tblUsuario)
        {
            if (id != tblUsuario.IdUsuario)
            {
                return BadRequest("Usuario no encontrado");
            }

            _context.Entry(tblUsuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblUsuarioExists(id))
                {
                    return NotFound("Error al actualizar");
                }
                else
                {
                    throw;
                }
            }

            return Ok("Usuario actualizado");
        }

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblUsuario>> PostTblUsuario(TblUsuario tblUsuario)
        {
            _context.TblUsuarios.Add(tblUsuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario creado");
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblUsuario(int id)
        {
            var tblUsuario = await _context.TblUsuarios.FindAsync(id);
            if (tblUsuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            _context.TblUsuarios.Remove(tblUsuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario eliminado");
        }

        private bool TblUsuarioExists(int id)
        {
            return _context.TblUsuarios.Any(e => e.IdUsuario == id);
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> userLogin(TblUsuario user)
        {
            var oUser = await _context.TblUsuarios.Where(u=>u.Username==user.Username&&u.Password==user.Password).FirstOrDefaultAsync();
            if (oUser == null)
                return NotFound("Username o Password No Valido");

            return Ok(oUser);
        }
    }
}
