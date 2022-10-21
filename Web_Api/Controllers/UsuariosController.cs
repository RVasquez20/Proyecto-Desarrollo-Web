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
        public async Task<ActionResult> GetTblUsuarios()
        {
            var listadoUsuarios = _context.TblUsuarios.ToList()
                .Join(_context.TblRoles,
                usuario=>usuario.IdRol,
                rol=>rol.IdRol,
                (usuario, rol) => new
                {
                    IdUsuario=usuario.IdUsuario,
                    IdEmpleado=usuario.IdEmpleado,
                    IdRol = usuario.IdRol,
                    Username=usuario.Username,
                    Password = usuario.Password,
                    Rol=rol.Rol
                }).ToList().Join(_context.TblEmpleados,
                usuario=>usuario.IdEmpleado,
                empleado=>empleado.IdEmpleado,
                (usuario, empleado) => new
                {
                    IdUsuario = usuario.IdUsuario,
                    IdEmpleado = usuario.IdEmpleado,
                    IdRol = usuario.IdRol,
                    Username = usuario.Username,
                    Password = usuario.Password,
                    Rol = usuario.Rol,
                    Empleado=empleado.Nombre
                }).ToList();
            return Ok(listadoUsuarios);
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

        [HttpGet]
        [Route("ListaAccesos/{id}")]
        public async Task<IActionResult> ListadoAccesos(int id)
        {

            var listaAccesos = _context.TblUsuarios.Where(user => user.IdUsuario == id).Join(_context.TblRoles,
                usuario => usuario.IdRol,
                rol => rol.IdRol,
                (usuario, rol) => new
                {
                    Id_rol=rol.IdRol
                }).ToList().Join(_context.TblAccessRoles,
                rol=>rol.Id_rol,
                acc=>acc.IdRol,
                (rol, acc) => new
                {
                    IdAccess=acc.IdAccess
                }).ToList().Join(_context.TblAccesses,
                acc=>acc.IdAccess,
                accesos=>accesos.IdAccess,
                (acc, accesos) =>new TblAccess
                {
                    IdAccess=accesos.IdAccess,
                    Name=accesos.Name,
                    Url=accesos.Url
                }).ToList();

            return Ok(listaAccesos);
        }

    }
}
