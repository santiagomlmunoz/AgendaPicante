using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{
    public class Turno
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        [Required(ErrorMessage = "La propiedad Fecha es requerida")]
        [DataType(DataType.Date)]
        public string Fecha { set; get; }

        [Display(Name = "Hora")]
        [Required(ErrorMessage = "La propiedad Hora es requerida")]
        [DataType(DataType.Time)]
        public string Hora { set; get; }

        [Display(Name = "Activo?")]
        [Required(ErrorMessage = "La propiedad Estado es requerida")]

        public bool Estado { set; get; }


        public Paciente Paciente { set; get; }
        public Profesional Profesional { set; get; }
        public Consultorio Consultorio { set; get; }

        //public Turno(DateTime fecha, int hora, bool estado, Paciente paciente, Profesional profesional, Consultorio consultorio)
        //{
        //    this.Fecha = fecha;
        //    this.Hora = hora;
        //    this.Estado = estado;
        //    this.Paciente = paciente;
        //    this.Profesional = profesional;
        //    this.Consultorio = consultorio;
        //}
    }

}
