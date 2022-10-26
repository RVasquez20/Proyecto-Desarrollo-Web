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

        // GET: api/VentasDetalle
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblVentasDetalle>>> GetTblVentasDetalles()
        {
            return Ok(await _context.TblVentasDetalles.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TblVentasDetalle>> GetTblVentas(int id)
        {
            var VentasDetalles = await _context.TblVentasDetalles.FindAsync(id);

            if (VentasDetalles == null)
            {
                return NotFound("No se encontro el registro");
            }

            return Ok(VentasDetalles);

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
