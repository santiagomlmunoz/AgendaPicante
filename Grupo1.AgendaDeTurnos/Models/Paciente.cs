using Grupo1.AgendaDeTurnos.EnumList;
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

        public int Edad { get; set; }

    }

}
