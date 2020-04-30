using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class Ruta
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        public string creador { get; set; }
        [Required]
        [Range(1, float.MaxValue)]
        public float kilometrosRecorrer { get; set; }
        [Required]
        public bool isPublica { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fechaSalida { get; set; }
        public string comentarios { get; set; }
        [ForeignKey("creador")]
        public Usuario usuarioNavigation { get; set; }
    }
}
