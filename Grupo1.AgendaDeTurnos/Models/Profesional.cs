using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Profesional : Usuario
    {
        public List<Disponibilidad> Disponibilidades { get; set; }
        public Prestacion Prestacion { get; set; }
        public List<Turno> Turnos { get; set; }

        public Profesional(string nombre, string apellido, string dni, Rol rol, Prestacion prestacion) : base(nombre, apellido, dni, rol)
        {
            this.Prestacion = prestacion;
            this.Turnos = new List<Turno>();
        }


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
