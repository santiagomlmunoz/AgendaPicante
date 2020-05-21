using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Mail
    {
        [Key]
        public int Id { get; set; }

        [Required (ErrorMessage = "Debe ingresar un email valido")]
        public string Descripcion { get; set; }
    }
}