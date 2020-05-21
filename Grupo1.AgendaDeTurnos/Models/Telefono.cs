using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Telefono
    {
        public int Id { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "El celular tiene diez números")]
        [MaxLength(10, ErrorMessage = "El celular tiene diez números")]
        [RegularExpression(@"[1]{1}[1]|[5]{1}\-[0-9]{4}\-[0-9]{4}", ErrorMessage = "El número de celular debe tener el formato 11-1234-5678 o 15-1234-5678")]
        public string NumeroCelular { get; set; }

        [MinLength(10, ErrorMessage = "El celular tiene diez números")]
        [MaxLength(10, ErrorMessage = "El celular tiene diez números")]
        public string TelefonoAlternativo { get; set; }

    }
}