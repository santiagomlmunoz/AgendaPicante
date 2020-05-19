using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Disponibilidad
    {
        public int IdDisponibilidad;
        public int HoraDesde { get; set; }
        public int HoraHasta { get; set; }
        public DateTime Dia { get; set; }

        public Disponibilidad(DateTime dia, int horaDesde, int horaHasta)
        {
            this.Dia = dia;
            this.HoraDesde = horaDesde;
            this.HoraHasta = horaHasta;
        }
    }
}
