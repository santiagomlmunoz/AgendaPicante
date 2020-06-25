using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Prestacion
    {
    
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Z/a-z]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        
        [Display(Name = "Duracion en horas")]
        public int DuracionHoras { get; set; }
        public List<Profesional> Profesionales { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [Display(Name = "Monto")]
        public int Monto { get; set; }
    }

}
