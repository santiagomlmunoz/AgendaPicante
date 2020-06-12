using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Telefono
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Usuario")]
        [Display(Name = "Usuario")]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }

        [Display(Name = "Celular")]
        [Required]
        [MinLength(12, ErrorMessage = "El celular tiene diez números")]
        [MaxLength(12, ErrorMessage = "El celular tiene diez números")]
        [RegularExpression(@"[1]{1}[1]{1}[-]{1}[0-9]{4}[-]{1}[0-9]{4}", ErrorMessage = "El número de celular debe tener el formato 11-1234-5678 o 15-1234-5678")]
        public string NumeroCelular { get; set; }

        [Display(Name = "Celular Alternativo")]
        [MinLength(10, ErrorMessage = "El celular tiene diez números")]
        [MaxLength(10, ErrorMessage = "El celular tiene diez números")]
        public string TelefonoAlternativo { get; set; }

    }
}