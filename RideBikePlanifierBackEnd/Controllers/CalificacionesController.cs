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
    public class CalificacionesController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public CalificacionesController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Calificaciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioRuta>>> GetUsuarioRuta(string id)
        {
            return await _context.usuarioRutas
                .Include(x => x.rutaNavigation)
                .Where(x => x.usuario == id).OrderByDescending(x=>x.rutaNavigation.fechaSalida).ToListAsync();
        }

        // PUT: api/Calificaciones/5
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

        private bool UsuarioRutaExists(int id)
        {
            return _context.usuarioRutas.Any(e => e.ruta == id);
        }
    }
}
