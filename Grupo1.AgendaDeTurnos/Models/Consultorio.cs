using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Consultorio
    {
        public int IdConsultorio;
        public string Nombre { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; };
        public List<Turno> Turnos { get; set; }

        public Consultorio(string nombre)
        {
            Nombre = nombre;
            Disponibilidades = new List<Disponibilidad>();
            Turnos = new List<Turno>();
        }

    }
}
