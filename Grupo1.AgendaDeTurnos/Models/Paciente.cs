using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Paciente : Usuario
    {
    
        public List<Turno> Turnos { get; set; }

        public Paciente(string nombre, string apellido, string dni, Rol rol) : base(nombre,apellido,dni,rol)
        {
            Turnos = new List<Turno>();
        }
        public void SolicitarTurno()
        {

        }
    }

}
