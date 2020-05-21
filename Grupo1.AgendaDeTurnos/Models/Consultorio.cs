using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Consultorio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
        public List<Turno> Turnos { get; set; }

        public Consultorio(string nombre)
        {
            Nombre = nombre;
            Disponibilidades = new List<Disponibilidad>();
            Turnos = new List<Turno>();
        }

    }
}
