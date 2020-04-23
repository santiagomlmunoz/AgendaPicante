using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Turno
{
    private int idTurno;
    public DateTime fecha { set; get; }
    public int hora { set; get; }
    public bool estado { set; get; }
    public Paciente paciente { set; get; }
    public Profesional profesional { set; get; }
    public Consultorio consultorio { set; get; }

    public Turno(DateTime fecha, int hora, bool estado, Paciente paciente, Profesional profesional, Consultorio consultorio)
    {
        this.fecha = fecha;
        this.hora = hora;
        this.estado = estado;
        this.paciente = paciente;
        this.profesional = profesional;
        this.consultorio = consultorio;
    }
}
