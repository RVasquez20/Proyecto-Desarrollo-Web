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
    public class ProductosController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ProductosController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Productoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblProducto>>> GetTblProductos()
        {
            return Ok(await _context.TblProductos.ToListAsync());
        }


        // PUT: api/Productoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblProducto(int id, TblProducto tblProducto)
        {
            if (id != tblProducto.IdProducto)
            {
                return BadRequest("El id no coincide");
            }

            _context.Entry(tblProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblProductoExists(id))
                {
                    return NotFound("No existe el producto");
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblProducto);
        }

        // POST: api/Productoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblProducto>> PostTblProducto(TblProducto tblProducto)
        {
            try
            {
                _context.TblProductos.Add(tblProducto);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok(tblProducto);
        }

        // DELETE: api/Productoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblProducto(int id)
        {
            var tblProducto = await _context.TblProductos.FindAsync(id);
            if (tblProducto == null)
            {
                return NotFound("No existe el producto");
            }

            _context.TblProductos.Remove(tblProducto);
            await _context.SaveChangesAsync();

            return Ok("Producto eliminado");
        }

        private bool TblProductoExists(int id)
        {
            return _context.TblProductos.Any(e => e.IdProducto == id);
        }

        [HttpPost]
        [Route("Actualizar")]
        public async Task<ActionResult<TblProducto>> ActualizarExistencias(ActualizarExistencias data)
        {
            try
            {
                var producto = await _context.TblProductos.FindAsync(data.Id);
                if (producto == null)
                {
                    return NotFound("No existe el producto");
                }
                if (data.Venta_Compra.Equals("Venta"))
                {
                    producto.Existencia -= data.Cantidad;
                }
                else
                {
                    producto.Existencia += data.Cantidad;
                }
                _context.Entry(producto).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(producto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
