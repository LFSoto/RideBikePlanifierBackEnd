using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideBikePlanifierBackEnd.Models;

namespace RideBikePlanifierBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public RutasController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Rutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ruta>>> Getrutas()
        {
            return await _context.rutas.ToListAsync();
        }

        // GET: api/Rutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ruta>> GetRuta(int id)
        {
            var ruta = await _context.rutas.FindAsync(id);

            if (ruta == null)
            {
                return NotFound();
            }

            return ruta;
        }

        // PUT: api/Rutas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRuta(int id, Ruta ruta)
        {
            if (id != ruta.id)
            {
                return BadRequest();
            }

            _context.Entry(ruta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RutaExists(id))
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

        // POST: api/Rutas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Ruta>> PostRuta(Ruta ruta)
        {
            _context.rutas.Add(ruta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRuta", new { id = ruta.id }, ruta);
        }

        // DELETE: api/Rutas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Ruta>> DeleteRuta(int id)
        {
            var ruta = await _context.rutas.FindAsync(id);
            if (ruta == null)
            {
                return NotFound();
            }

            _context.rutas.Remove(ruta);
            await _context.SaveChangesAsync();

            return ruta;
        }

        private bool RutaExists(int id)
        {
            return _context.rutas.Any(e => e.id == id);
        }
    }
}
