using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public async Task<ActionResult<List<Ruta>>> getTops(int id)
        {
            object obj = await _context.usuarioRutas
                        .GroupBy(x => x.ruta)
                        .Select(g => new
                        {
                            ruta = g.Key,
                            dificultad = g.Average(y => y.dificultad),
                            ambiente = g.Average(y => y.ambiente),
                            evaluacionFinal = g.Average(y => y.evaluacionFinal)
                        }).ToListAsync();

            //List<Top> lista = JsonConvert.DeserializeObject<List<Top>>(obj.ToString());
            List<Top> lista = obj as List<Top>;
            List<Ruta> rutas = new List<Ruta>();

            switch (id)
            {
                case 1:
                    lista.OrderByDescending(x => x.dificultad);
                    foreach(var list in lista)
                    {
                        Ruta ruta = await _context.rutas.FirstOrDefaultAsync(x => x.id == list.ruta);
                        rutas.Add(ruta);
                        if(rutas.Count == 10)
                        {
                            return rutas;
                        }
                    }
                    return rutas;

                case 2:
                    lista.OrderByDescending(x => x.ambiente);
                    foreach (var list in lista)
                    {
                        Ruta ruta = await _context.rutas.FirstOrDefaultAsync(x => x.id == list.ruta);
                        rutas.Add(ruta);
                        if (rutas.Count == 10)
                        {
                            return rutas;
                        }
                    }
                    return rutas;

                default:
                    lista.OrderByDescending(x => x.evaluacionFinal);
                    foreach (var list in lista)
                    {
                        Ruta ruta = await _context.rutas.FirstOrDefaultAsync(x => x.id == list.ruta);
                        rutas.Add(ruta);
                        if (rutas.Count == 10)
                        {
                            return rutas;
                        }
                    }
                    return rutas;
            }
        }
    }
}
