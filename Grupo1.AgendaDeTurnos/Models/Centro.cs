using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Centro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Za-z áéíóú]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "El campo es requerido")]
        //[MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        //[MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        //[RegularExpression("[A-Z/a-z]*", ErrorMessage = "El campo solo admite letras")]
        //[Display(Name = "Direccion")]
        //public string Direccion { get; set; }

        [ForeignKey("Direccion")]
        [Display(Name = "Direccion")]
        public int DireccionId { get; set; }
        public Direccion Direccion { get; set; }




        public List<Telefono> Telefonos { get; set; }
        public List<Profesional> Profesionales { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
        public List<Paciente> Pacientes { get; set; }

    }

}
