using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Administrador : Usuario
    {

        public Administrador(string nombre, string apellido, string dni, Rol rol) : base(nombre, apellido, dni, rol) { }
        public Paciente CrearPaciente(string nombre, string apellido, string dni, Rol rol)
        {
            Paciente p = new Paciente(nombre, apellido, dni, rol);
            return p;
        }

        public void BajaPaciente(Paciente p)
        {
        }

        public Centro CrearCentro(string nombre, string direccion, string telefono)
        {
            Centro c = new Centro(nombre, direccion, telefono);
            return c;
        }

        public void BajaCentro()
        {
        }

        public Turno CrearTurno(DateTime fecha, int hora, bool estado, Paciente paciente, Profesional profesional, Consultorio consultorio)
        {
            Turno t = new Turno(fecha, hora, estado, paciente, profesional, consultorio);
            return t;
        }


        public void BajaTurno()
        {
        }

    }


}
