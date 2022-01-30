using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ClientesNetCore5.Models
{
    public class Cliente
    {
        [Key]
        public int Identificacion { get; set; }

        [Required(ErrorMessage = "Nombre obligatorio.")]
        [StringLength(50, ErrorMessage = "Longitud maxima PrimerNombre 50 y minima 3.",MinimumLength = 3)]
        [Display(Name = "Nombre")]
        public string PrimerNombre { get; set; }

        [Required(ErrorMessage = "Apellido obligatorio.")]
        [StringLength(50, ErrorMessage = "Longitud maxima PrimerApellido 50 y minima 3.", MinimumLength = 3)]
        [Display(Name = "Apellido")]
        public string PrimerApellido { get; set; }

        [Required(ErrorMessage = "Edad obligatoria.")]
        public int Edad { get; set; }

        [Required(ErrorMessage = "Fecha obligatoria.")]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha Creacion")]
        public DateTime FechaDeCreacion { get; set; }
    }
}
