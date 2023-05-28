using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Actividad18.Server.Contexto;
using Actividad18.Shared.Modelos;

namespace Actividad18.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly CotextoTienda _context;

        public VentasController(CotextoTienda context)
        {
            _context = context;
        }

        // GET: api/Ventas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ventas>>> GetVentas()
        {
            var ventas = await _context.Ventas.Include(v => v.Productos).ToListAsync();

            if (ventas.Count == 0)
            {
                return NotFound();
            }

            return ventas;
        }

        // GET: api/Ventas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ventas>> GetVentas(int id)
        {
            var ventas = await _context.Ventas.Include(v => v.Productos).FirstOrDefaultAsync(v => v.Id == id);

            if (ventas == null)
            {
                return NotFound();
            }

            return ventas;
        }

        // PUT: api/Ventas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentas(int id, Ventas ventas)
        {
            if (id != ventas.Id)
            {
                return BadRequest();
            }

            _context.Entry(ventas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Ventas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ventas>> PostVentas(Ventas ventas)
        {
            if (_context.Ventas == null)
            {
                return Problem("Entity set 'CotextoTienda.Ventas' is null.");
            }

            _context.Ventas.Add(ventas);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentas", new { id = ventas.Id }, ventas);
        }

        // DELETE: api/Ventas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentas(int id)
        {
            if (_context.Ventas == null)
            {
                return NotFound();
            }

            var ventas = await _context.Ventas.FindAsync(id);

            if (ventas == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(ventas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VentasExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }
}
