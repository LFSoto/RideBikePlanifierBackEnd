using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class Amigo
    {
        [Key]
        [Required]
        [Column(Order = 1)]
        public string usuario { get; set; }
        [Key]
        [Required]
        [Column(Order = 2)]
        public string amigo { get; set; }
        [ForeignKey("usuario")]
        public Usuario usuarioNavigation { get; set; }
        [ForeignKey("amigo")]
        public Usuario amigoNavigation { get; set; }
    }
}
