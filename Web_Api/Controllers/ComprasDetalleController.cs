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
    public class ComprasDetalleController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public ComprasDetalleController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/ComprasDetalle
      

        [HttpGet("{id}")]
        public async Task<ActionResult> GetTblComprasDetalles(int id)
        {
            var listadoCompraDetalle = _context.TblComprasDetalles
                .Where(x=>x.IdCompra==id)
                .Join(_context.TblCompras,
                cd => cd.IdCompra,
                c => c.IdCompras,
                (cd, c) => new
                {

                    IdComprasDetalle = cd.IdComprasDetalle,
                    IdProducto = cd.IdProducto,
                    Cantidad = cd.Cantidad,
                    IdCompra = cd.IdCompra,
                    NoOrden = c.NoOrden
                }
                ).Join(_context.TblProductos,

                cd => cd.IdProducto,
                p => p.IdProducto,
                (cd, p) => new
                {
                    IdComprasDetalle = cd.IdComprasDetalle,
                    IdProducto = cd.IdProducto,
                    Cantidad = cd.Cantidad,
                    IdCompra = cd.IdCompra,
                    NoOrden = cd.NoOrden,
                    Producto = p.Nombre
                }).ToList();

            if (listadoCompraDetalle == null)
            {
                return NotFound();
            }

            return Ok(listadoCompraDetalle);
        }


        // POST: api/ComprasDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblComprasDetalle>> PostTblComprasDetalle(TblComprasDetalle tblComprasDetalle)
        {
            _context.TblComprasDetalles.Add(tblComprasDetalle);
            await _context.SaveChangesAsync();

            return Ok(tblComprasDetalle);
        }

        
        private bool TblComprasDetalleExists(int id)
        {
            return _context.TblComprasDetalles.Any(e => e.IdComprasDetalle == id);
        }
    }
}
