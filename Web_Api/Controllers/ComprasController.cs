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
    public class ComprasController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ComprasController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Compras
        [HttpGet]
        public async Task<ActionResult> GetTblCompras()
        {
            var listadoCompras = _context.TblCompras.Join(_context.TblProveedors,
                c => c.IdProveedor,
                p => p.IdProveedor,
                (c,p) =>new
                {
                    IdCompras = c.IdCompras,
                    NoOrden= c.NoOrden,
                    FechaOrden = c.FechaOrden,
                    IdProveedor = c.IdProveedor,
                    Proveedor = p.Nombre
                }).ToList();

            return Ok(listadoCompras);
        }

        // POST: api/Compras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblCompra>> PostTblCompra(TblCompra tblCompra)
        {
            _context.TblCompras.Add(tblCompra);
            await _context.SaveChangesAsync();

            return Ok(tblCompra);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblCompra>> GetTblCompras(int id)
        {
            var Compra = await _context.TblCompras.FindAsync(id);

            if (Compra == null)
            {
                return NotFound();
            }

            return Ok(Compra);
        }

        // DELETE: api/Compras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblCompra(int id)
        {
            var tblCompra = await _context.TblCompras.FindAsync(id);
            if (tblCompra == null)
            {
                return NotFound();
            }

            _context.TblCompras.Remove(tblCompra);
            await _context.SaveChangesAsync();

            return Ok(tblCompra);
        }

        private bool TblCompraExists(int id)
        {
            return _context.TblCompras.Any(e => e.IdCompras == id);
        }
    }
}
