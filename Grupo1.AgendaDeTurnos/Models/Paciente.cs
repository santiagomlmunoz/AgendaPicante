using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Paciente
    {
        public List<Turno> turnos { get; set; }

        public Paciente(string nombre, string apellido, string dni, Rol rol)
        {
            turnos = new List<Turno>();
        }
        public void solicitarTurno()
        {

        }
    }

}
