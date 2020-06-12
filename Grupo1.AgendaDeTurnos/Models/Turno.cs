using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Turno
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La propiedad Fecha es requerida")]
        [DataType(DataType.Date)]
        public DateTime Fecha { set; get; }

        [ForeignKey("Paciente")]
        [Display(Name = "Paciente")]
        public int IdPaciente { set; get; }
        public Paciente Paciente { set; get; }

        [ForeignKey("Profesional")]
        [Display(Name = "Profesional")]
        public int IdProfesional { set; get; }
        public Profesional Profesional { set; get; }

        [ForeignKey("Centro")]
        [Display(Name = "Centro")]
        public int IdCentro { set; get; }
        public Centro Centro { set; get; }

    }

}
