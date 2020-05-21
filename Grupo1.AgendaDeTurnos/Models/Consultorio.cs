using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Consultorio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Za-z áéíóú]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
        public List<Turno> Turnos { get; set; }

        public Consultorio(string nombre)
        {
            Nombre = nombre;
            Disponibilidades = new List<Disponibilidad>();
            Turnos = new List<Turno>();
        }

    }
}
