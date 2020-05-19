using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Centro
    {
        public int IdCentro { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public List<Profesional> Profesionales { get; set; }
        public List<Disponibilidad> Disponibilidades { get; set; }
        public List<Paciente> Pacientes { get; set; }

        public Centro(string nombre, string direccion, string telefono)
        {
            this.Nombre = nombre;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Profesionales = new List<Profesional>();
            this.Disponibilidades = new List<Disponibilidad>();
            this.Pacientes = new List<Paciente>();

        }
    }

}
