using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Direccion
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Z/a-z]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Required]
        [MaxLength(10, ErrorMessage = "El dato debe ser numerico y no ser menor a 1")]
        [MinLength(1, ErrorMessage = "El dato debe ser numerico y no ser mayor a 99999")]
        [RegularExpression("[0-9]*", ErrorMessage = "El dato debe ser númerico.")]
        [Display(Name = "Altura")]
        public int Altura { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Z/a-z]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo es requerido")]
        [MaxLength(100, ErrorMessage = "La longitud máxima del campo es de 100 caracteres")]
        [MinLength(2, ErrorMessage = "La longitud mínima del campo es de 2 caracteres")]
        [RegularExpression("[A-Z/a-z]*", ErrorMessage = "El campo solo admite letras")]
        [Display(Name = "Provincia")]
        public string Provincia { get; set; }

        [ForeignKey("Usuario")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }

        public Usuario Usuario { get; set; }



    }
}