using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Grupo1.AgendaDeTurnos.Models
{

    public abstract class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public List<Direccion> Direcciones { get; set; }
        public List<Telefono> Telefonos { get; set; }
        public List<Mail> Mails { get; set; }
        public Rol Rol { get; set; }

        public Usuario(string nombre, string apellido, string dni, Rol rol)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Dni = dni;
            this.Rol = rol;
            this.Direcciones = new List<Direccion>();
            this.Telefonos = new List<Telefono>();
            this.Mails = new List<Mail>();
        }
    }

}
