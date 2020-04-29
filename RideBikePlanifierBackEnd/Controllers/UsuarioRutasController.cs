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
    public class UsuarioRutasController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public UsuarioRutasController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/UsuarioRutas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRuta>>> GetusuarioRutas()
        {
            return await _context.usuarioRutas.ToListAsync();
        }

        // GET: api/UsuarioRutas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioRuta>> GetUsuarioRuta(int id)
        {
            var usuarioRuta = await _context.usuarioRutas.FindAsync(id);

            if (usuarioRuta == null)
            {
                return NotFound();
            }

            return usuarioRuta;
        }

        // PUT: api/UsuarioRutas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioRuta(int id, UsuarioRuta usuarioRuta)
        {
            if (id != usuarioRuta.ruta)
            {
                return BadRequest();
            }

            _context.Entry(usuarioRuta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioRutaExists(id))
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

        // POST: api/UsuarioRutas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<UsuarioRuta>> PostUsuarioRuta(UsuarioRuta usuarioRuta)
        {
            _context.usuarioRutas.Add(usuarioRuta);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuarioRutaExists(usuarioRuta.ruta))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarioRuta", new { id = usuarioRuta.ruta }, usuarioRuta);
        }

        // DELETE: api/UsuarioRutas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioRuta>> DeleteUsuarioRuta(int id)
        {
            var usuarioRuta = await _context.usuarioRutas.FindAsync(id);
            if (usuarioRuta == null)
            {
                return NotFound();
            }

            _context.usuarioRutas.Remove(usuarioRuta);
            await _context.SaveChangesAsync();

            return usuarioRuta;
        }

        private bool UsuarioRutaExists(int id)
        {
            return _context.usuarioRutas.Any(e => e.ruta == id);
        }
    }
}
