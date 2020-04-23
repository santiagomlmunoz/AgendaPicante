using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Administrador : Usuario
{
    public Administrador(string nombre, string apellido, string dni, Rol rol) : base(nombre, apellido, dni, rol) { }
    public Paciente crearPaciente(string nombre, string apellido, string dni, Rol rol)
    {
        Paciente p = new Paciente(nombre, apellido, dni, rol);
        return p;
    }

    public void bajaPaciente(Paciente p)
    {
    }

    public Centro crearCentro(string nombre, string direccion, string telefono)
    {
        Centro c = new Centro(nombre, direccion, telefono);
        return c;
    }

    public void bajaCentro()
    {
    }

    public Turno crearTurno(DateTime fecha, int hora, bool estado, Paciente paciente, Profesional profesional, Consultorio consultorio)
    {
        Turno t = new Turno(fecha, hora, estado, paciente, profesional, consultorio);
        return t;
    }


    public void bajaTurno()
    {
    }

}

