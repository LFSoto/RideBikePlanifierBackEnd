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
    public class CoordenadasController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public CoordenadasController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Coordenadas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Coordenada>>> Getcoordenadas()
        {
            return await _context.coordenadas.ToListAsync();
        }

        // GET: api/Coordenadas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Coordenada>>> GetCoordenada(int id)
        {
            var coordenada = await _context.coordenadas.Where(x => x.ruta == id).ToListAsync();

            if (coordenada == null)
            {
                return NotFound();
            }

            return coordenada;
        }

        // PUT: api/Coordenadas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCoordenada(int id, Coordenada coordenada)
        {
            if (id != coordenada.ruta)
            {
                return BadRequest();
            }

            _context.Entry(coordenada).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CoordenadaExists(id))
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

        // POST: api/Coordenadas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Coordenada>> PostCoordenada(Coordenada coordenada)
        {
            _context.coordenadas.Add(coordenada);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CoordenadaExists(coordenada.ruta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCoordenada", new { id = coordenada.ruta }, coordenada);
        }

        // DELETE: api/Coordenadas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Coordenada>> DeleteCoordenada(int id)
        {
            var coordenada = await _context.coordenadas.FindAsync(id);
            if (coordenada == null)
            {
                return NotFound();
            }

            _context.coordenadas.Remove(coordenada);
            await _context.SaveChangesAsync();

            return coordenada;
        }

        private bool CoordenadaExists(int id)
        {
            return _context.coordenadas.Any(e => e.ruta == id);
        }
    }
}
