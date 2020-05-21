using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Rol
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Descripcion")]
        [Required(ErrorMessage = "La propiedad Descripcion es requerida")]
        [MaxLength(100, ErrorMessage = "La longitud máxima de Apellido es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima de Nombre es de 2 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "La propiedad Descripcion solo admite letras")]
        public string Descripcion { get; set; }
    }
}
