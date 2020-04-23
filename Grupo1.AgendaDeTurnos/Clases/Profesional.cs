using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Profesional : Usuario
{
    private List<Disponibilidad> disponibilidades;
    private Prestacion prestacion;
    private List<Turno> turnos;

    public Profesional(string nombre, string apellido, string dni, Rol rol, Prestacion prestacion) : base(nombre, apellido, dni, rol)
    {
        this.prestacion = prestacion;
        this.turnos = new List<Turno>();
    }


    public void agregarDisponibilidad(Disponibilidad disponibilidad)
    {
        this.disponibilidades.Add(disponibilidad);
    }

    public void asignarTurno(Turno turno)
    {
        this.turnos.Add(turno);
    }
}
