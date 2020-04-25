using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Prestacion
    {
        private int idPrestacion;
        public string nombre { get; set; }
        public int duracionMinutos { get; set; }

        public Prestacion(string nombre, int duracionMinutos)
        {
            this.nombre = nombre;
            this.duracionMinutos = duracionMinutos;
        }
    }

}
