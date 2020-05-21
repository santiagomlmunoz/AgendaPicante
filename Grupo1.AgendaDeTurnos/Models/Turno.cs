using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Turno
    {
        public int Id { get; set; }
        public DateTime Fecha { set; get; }
        public int Hora { set; get; }
        public bool Estado { set; get; }
        public Paciente Paciente { set; get; }
        public Profesional Profesional { set; get; }
        public Consultorio Consultorio { set; get; }

        public Turno(DateTime fecha, int hora, bool estado, Paciente paciente, Profesional profesional, Consultorio consultorio)
        {
            this.Fecha = fecha;
            this.Hora = hora;
            this.Estado = estado;
            this.Paciente = paciente;
            this.Profesional = profesional;
            this.Consultorio = consultorio;
        }
    }

}
