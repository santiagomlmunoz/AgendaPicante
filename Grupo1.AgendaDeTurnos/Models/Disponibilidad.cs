using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Disponibilidad
    {
        private int idDisponibilidad;
        public int horaDesde { get; set; }
        public int horaHasta { get; set; }
        public Dia dia { get; set; }

        public Disponibilidad(Dia dia, int horaDesde, int horaHasta)
        {
            this.dia = dia;
            this.horaDesde = horaDesde;
            this.horaHasta = horaHasta;
        }
    }
}
