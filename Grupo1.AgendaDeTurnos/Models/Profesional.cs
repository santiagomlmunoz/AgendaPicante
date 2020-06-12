using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Profesional : Usuario
    {
        public List<Disponibilidad> Disponibilidades { get; set; }
        
        public List<Turno> Turnos { get; set; }

        [ForeignKey("Prestacion")]
        [Display(Name = "Prestacion")]
        public int PrestacionId { get; set; }
        public Prestacion Prestacion { get; set; }

        [ForeignKey("Centro")]
        [Display(Name = "Centro")]
        public int CentroId { get; set; }
        public Centro Centro { get; set; }


        public void AgregarDisponibilidad(Disponibilidad disponibilidad)
        {
            this.Disponibilidades.Add(disponibilidad);
        }

        public void AsignarTurno(Turno turno)
        {
            this.Turnos.Add(turno);
        }
    }

}
