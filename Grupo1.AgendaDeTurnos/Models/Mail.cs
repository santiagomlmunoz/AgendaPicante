using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Mail")]
        [Required (ErrorMessage = "Debe ingresar un email valido")]
        [EmailAddress(ErrorMessage = "Debe ingresar un email valido")]
        public string Descripcion { get; set; }


        [ForeignKey("Usuario")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}