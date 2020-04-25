using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Consultorio
    {
        private int idConsultorio;
        public string nombre { get; set; }
        private List<Disponibilidad> disponibilidades;
        private List<Turno> turnos;

        public Consultorio(string nombre)
        {
            this.nombre = nombre;
            disponibilidades = new List<Disponibilidad>();
            turnos = new List<Turno>();
        }

    }
}
