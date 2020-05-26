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
    public class TopsController : ControllerBase
    {
        private readonly RideBikePlanifierContext _context;

        public TopsController(RideBikePlanifierContext context)
        {
            _context = context;
        }

        // GET: api/Tops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioRuta>>> GetusuarioRutas()
        {
            return await _context.usuarioRutas.ToListAsync();
        }

        // GET: api/Tops/5
        [HttpGet("{id}")]
        //1: Dificultad
        //2: Ambiente
        //3: Evaluación Final
        public async Task<ActionResult<List<UsuarioRuta>>> getTops(int id)
        {
            switch (id)
            {
                case 1:
                    return await _context.usuarioRutas
                        .Include(x => x.rutaNavigation).ThenInclude(i => i.usuarioNavigation)
                        .OrderBy(x => x.dificultad).Distinct()
                        .Take(10).ToListAsync();

                case 2:
                    return await _context.usuarioRutas
                        .Include(x => x.rutaNavigation).ThenInclude(i => i.usuarioNavigation)
                        .OrderBy(x => x.ambiente).Distinct()
                        .Take(10).ToListAsync();

                //case 3:
                //    List<UsuarioRuta> usuarioRutas = await _context.usuarioRutas
                //        .Include(x => x.rutaNavigation).ThenInclude(i => i.usuarioNavigation)
                //        .OrderBy(x => x.evaluacionFinal).ToListAsync();
                //    List<UsuarioRuta> salida = new List<UsuarioRuta>(); 
                //    usuarioRutas.GroupBy(x => x.usuario).OrderBy(x => x.Average(g => g.evaluacionFinal)).Take(10);
                //    foreach(var obj in usuarioRutas)
                //    {
                //        if(salida.Exists(x => x.usuario != obj.usuario) && salida.Count < 10)
                //        {
                //            salida.Add(obj);
                //        }
                //    }

                //    return salida;

                default:
                    return await _context.usuarioRutas
                        .Include(x => x.rutaNavigation).ThenInclude(i => i.usuarioNavigation)
                        .OrderBy(x => x.evaluacionFinal)
                        .Take(10).ToListAsync();
            }
        }
    }
}
