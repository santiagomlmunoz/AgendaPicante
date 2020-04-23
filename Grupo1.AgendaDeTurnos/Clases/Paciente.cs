using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

public class Paciente
{
    public List<Turno> turnos { get; set; }

    public Paciente(string nombre, string apellido, string dni, Rol rol) : base(nombre, apellido, dni, rol)
    {
        turnos = new List<Turno>();
    }
    public void solicitarTurno()
    {

    }
}
