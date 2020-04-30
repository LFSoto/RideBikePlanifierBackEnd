using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class Coordenada
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int ruta { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public float latitud { get; set; }
        [Key]
        [Required]
        [Column(Order = 3)]
        public float longitud { get; set; }
        [ForeignKey("ruta")]
        public Ruta rutaNavigation { get; set; }
    }
}
