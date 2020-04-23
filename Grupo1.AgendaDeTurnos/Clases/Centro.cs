using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections;

public class Centro
{
    private int idCentro;
    private string nombre;
    private string direccion;
    private string telefono;
    private List<Profesional> profesionales;
    private List<Disponibilidad> disponibilidades;
    private List<Paciente> pacientes;

    public Centro(string nombre, string direccion, string telefono)
    {
        this.nombre = nombre;
        this.direccion = direccion;
        this.telefono = telefono;
        this.profesionales = new List<Profesional>();
        this.disponibilidades = new List<Disponibilidad>();
        this.pacientes = new List<Paciente>();

    }
}
