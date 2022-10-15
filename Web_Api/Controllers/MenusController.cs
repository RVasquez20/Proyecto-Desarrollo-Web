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
    public class MenusController : ControllerBase
    {
        private readonly ClinicaMedicaContext _context;

        public MenusController(ClinicaMedicaContext context)
        {
            _context = context;
        }

        // GET: api/Menus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblMenu>>> GetTblMenus()
        {
            return Ok(await _context.TblMenus.ToListAsync());
        }

        // PUT: api/Menus/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTblMenu(int id, TblMenu tblMenu)
        {
            if (id != tblMenu.IdMenu)
            {
                return BadRequest();
            }

            _context.Entry(tblMenu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TblMenuExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(tblMenu);
        }

        // POST: api/Menus ingreso
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblMenu>> PostTblMenu(TblMenu tblMenu)
        {
            _context.TblMenus.Add(tblMenu);
            await _context.SaveChangesAsync();

            return Ok(tblMenu);
        }

        // DELETE: api/Menus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTblMenu(int id)
        {
            var tblMenu = await _context.TblMenus.FindAsync(id);
            if (tblMenu == null)
            {
                return NotFound();
            }

            _context.TblMenus.Remove(tblMenu);
            await _context.SaveChangesAsync();

            return Ok(tblMenu);
        }

        private bool TblMenuExists(int id)
        {
            return _context.TblMenus.Any(e => e.IdMenu == id);
        }
    }
}