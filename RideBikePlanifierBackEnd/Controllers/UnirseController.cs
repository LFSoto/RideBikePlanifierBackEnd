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
    public class UnirseController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public UnirseController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Unirse/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<Ruta>>> GetUnirse(string id)
        {
            List<Amigo> amigos = await _context.amigos
                .Where(x => x.usuario == id)
                .ToListAsync();
            List<string> list = new List<string>();
            foreach (var amigo in amigos)
            {
                list.Add(amigo.amigo);
            }

            List<Ruta> rutas = await _context.rutas.Where(x => x.fechaSalida > DateTime.Now).ToListAsync();
            List<Ruta> finales = new List<Ruta>();

            foreach(var ruta in rutas)
            {
                if((ruta.isPublica == true || list.Exists(x => x.Equals(ruta.creador))) && ruta.creador != id)
                {
                    finales.Add(ruta);
                }
            }
            return finales;
        }

        [HttpGet("/api/UnirseUsuario/{id}")]
        public async Task<ActionResult<List<int>>> GetUnirseUsuario(string id)
        {
            List<UsuarioRuta> usuarioRutas = await _context.usuarioRutas
                .Where(x => x.usuario == id).ToListAsync();

            List<int> rutas = new List<int>();

            foreach(var usuarioRuta in usuarioRutas)
            {
                rutas.Add(usuarioRuta.ruta);
            }

            return rutas;
        }

        // GET: api/Unirse/5/1
        [HttpGet("{ruta:int}/{usuario}")]
        public async Task<ActionResult<UsuarioRuta>> GetUsuarioRuta(int ruta, string usuario)
        {
            var usuarioRuta = await _context.usuarioRutas
                .FirstOrDefaultAsync(x => x.ruta == ruta && x.usuario == usuario);

            if (usuarioRuta == null)
            {
                return NotFound();
            }

            return usuarioRuta;
        }

        // POST: api/Unirse
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

            return CreatedAtAction("GetUsuarioRuta", new { ruta = usuarioRuta.ruta, usuario = usuarioRuta.usuario }, usuarioRuta);
        }

        // DELETE: api/Unirse/5
        [HttpDelete("{ruta:int}/{usuario}")]
        public async Task<ActionResult<UsuarioRuta>> DeleteUsuarioRuta(int ruta, string usuario)
        {
            var usuarioRuta = await _context.usuarioRutas
                .FirstOrDefaultAsync(x => x.ruta == ruta && x.usuario == usuario);
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
