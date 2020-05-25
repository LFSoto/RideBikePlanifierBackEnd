using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RideBikePlanifierBackEnd.Models;

namespace RideBikePlanifierBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmigosController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public AmigosController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Amigos
        [HttpGet]
        public async Task<ActionResult<List<string>>> Getamigos()
        {
            //return await _context.amigos.ToListAsync();
            List<Amigo> amigos = await _context.amigos
                .ToListAsync();
            List<string> list = new List<string>();
            foreach (var amigo in amigos)
            {
                list.Add(amigo.amigo);
            }
            return list;
        }

        // GET: api/Amigos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<List<string>>> GetAmigo(string id)
        {
            List<Amigo> amigos = await _context.amigos
                .Where(x => x.usuario == id)
                .ToListAsync();
            List<string> list = new List<string>();
            foreach(var amigo in amigos)
            {
                list.Add(amigo.amigo);
            }
            return list;
        }

        // PUT: api/Amigos/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmigo(string id, Amigo amigo)
        {
            if (id != amigo.usuario)
            {
                return BadRequest();
            }

            _context.Entry(amigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmigoExists(id))
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

        // POST: api/Amigos
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Amigo>> PostAmigo(Amigo amigo)
        {
            _context.amigos.Add(amigo);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AmigoExists(amigo.usuario))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetAmigo", new { id = amigo.usuario }, amigo);
        }

        // DELETE: api/Amigos/5
        [HttpDelete("{usuario}/{amigo}")]
        public async Task<ActionResult<Amigo>> DeleteAmigo(string usuario, string amigo)
        {
            var obj = await _context.amigos
                .FirstOrDefaultAsync(x => x.usuario == usuario && x.amigo == amigo);
            if (amigo == null)
            {
                return NotFound();
            }

            _context.amigos.Remove(obj);
            await _context.SaveChangesAsync();

            return obj;
        }

        private bool AmigoExists(string id)
        {
            return _context.amigos.Any(e => e.usuario == id);
        }
    }
}
