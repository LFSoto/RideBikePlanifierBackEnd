using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class UsuarioRuta
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public int ruta { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public string usuario { get; set; }
        public int? dificultad { get; set; }
        public int? ambiente { get; set; }
        public int? evaluacionFinal { get; set; }
        public string comentariosEvaluacion { get; set; }
        public bool isCalificada { get; set; }
        [ForeignKey("ruta")]
        public Ruta rutaNavigation { get; set; }
        [ForeignKey("usuario")]
        public Usuario usuarioNavigation { get; set; }
    }
}
