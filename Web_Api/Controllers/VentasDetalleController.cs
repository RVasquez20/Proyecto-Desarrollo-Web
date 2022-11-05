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
    public class VentasDetalleController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public VentasDetalleController(ClinicaMedicaContext context)
        {
            _context = context;
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTblVentas(int id)
        {
            var listadoVentasDetalle = _context.TblVentasDetalles
               .Where(x => x.IdVenta == id)
               .Join(_context.TblVentas,
               vd => vd.IdVenta,
               v => v.IdVentas,
               (vd, v) => new
               {

                   IdVentasDetalle = vd.IdVentasDetalle,
                   IdProducto = vd.IdProducto,
                   Cantidad = vd.Cantidad,
                   IdVenta = vd.IdVenta,
                   Numero = v.Numero
               }
               ).Join(_context.TblProductos,

               vd => vd.IdProducto,
               p => p.IdProducto,
               (vd, p) => new
               {
                   IdVentasDetalle = vd.IdVentasDetalle,
                   IdProducto = vd.IdProducto,
                   Cantidad = vd.Cantidad,
                   IdVenta = vd.IdVenta,
                   Numero = vd.Numero,
                   Producto = p.Nombre,
                   Precio = p.Precio
               }).ToList();

            if (listadoVentasDetalle == null)
            {
                return NotFound("No se encontro el registro");
            }

            return Ok(listadoVentasDetalle);

        }


        // POST: api/VentasDetalle
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblVentasDetalle>> PostTblVentasDetalle(TblVentasDetalle tblVentasDetalle)
        {
            _context.TblVentasDetalles.Add(tblVentasDetalle);
            await _context.SaveChangesAsync();

            return Ok(tblVentasDetalle);
        }

        private bool TblVentasDetalleExists(int id)
        {
            return _context.TblVentasDetalles.Any(e => e.IdVentasDetalle == id);
        }
    }
}
