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
        [MaxLength(3, ErrorMessage = "La longitud máxima del campo es de 3 caracteres")]
        [RegularExpression("[1-9]*", ErrorMessage = "El campo solo admite números")]
        [Display(Name = "Duracion en minutos")]
        public string DuracionMinutos { get; set; }


        [Required(ErrorMessage = "El campo es requerido")]
        [Range(0,99999)]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }


        //public Prestacion(string nombre, int duracionMinutos)
        //{
        //    this.Nombre = nombre;
        //    this.DuracionMinutos = duracionMinutos;
        //}
    }

}
