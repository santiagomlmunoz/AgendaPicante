using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Disponibilidad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        public DiasEnum Dia { get; set; }

        [Required(ErrorMessage = "Debe ingresar un horario de Inicio de cita")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public int HoraDesde { get; set; }

        [Required(ErrorMessage = "Debe ingresar un horario de fin de cita")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public int HoraHasta { get; set; }

        public string Descripcion { get; set; }

        [ForeignKey("Profesional")]
        [Display(Name = "Profesional")]
        public int IdProfesional { get; set; }
        public Profesional Profesional { get; set; }

        public Disponibilidad()
        {

        }
        public Disponibilidad(int horaDesde, int horaHasta, DiasEnum dia)
        {
            HoraDesde = horaDesde;
            HoraHasta = horaHasta;
            Dia = dia;

            Descripcion = dia.ToString() + " de " + horaDesde + " a " + horaHasta;
        }

    }
}
