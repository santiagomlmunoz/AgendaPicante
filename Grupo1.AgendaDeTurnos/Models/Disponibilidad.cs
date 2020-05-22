using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Disponibilidad
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe ingresar una fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public string Dia { get; set; }

        [Required(ErrorMessage = "Debe ingresar un horario de Inicio de cita")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public string HoraDesde { get; set; }

        [Required(ErrorMessage = "Debe ingresar un horario de fin de cita")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}")]
        public string HoraHasta { get; set; }

      //  public Disponibilidad(DateTime dia, int horaDesde, int horaHasta)
      //  {
      //      this.Dia = dia;
      //      this.HoraDesde = horaDesde;
      //      this.HoraHasta = horaHasta;
      //  }
    }
}
