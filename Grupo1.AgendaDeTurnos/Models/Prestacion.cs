using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Prestacion
    {
        public int IdPrestacion;
        public string Nombre { get; set; }
        public int DuracionMinutos { get; set; }

        public Prestacion(string nombre, int duracionMinutos)
        {
            this.Nombre = nombre;
            this.DuracionMinutos = duracionMinutos;
        }
    }

}
