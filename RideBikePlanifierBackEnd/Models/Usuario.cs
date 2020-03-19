using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RideBikePlanifierBackEnd.Models
{
    public class Usuario
    {
        [Key]
        public string correoElectronico { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellido1 { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime fechaNacimiento { get; set; }
        [Required]
        public string contrasenia { get; set; }
        public string descripcion { get; set; }
        public string numeroEmergencia { get; set; }
        public string padecimientos { get; set; }
    }
}
