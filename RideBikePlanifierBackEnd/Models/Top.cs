using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class Top
    {
        public int ruta { get; set; }
        public double? dificultad { get; set; }
        public double? ambiente { get; set; }
        public double? evaluacionFinal { get; set; }
    }
}
