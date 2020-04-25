using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Models
{

    public class Usuario
    {
        private int idUsuario;
        private string nombre;
        private string apellido;
        private string dni;
        private List<string> direcciones;
        private List<string> telefonos;
        private List<string> mails;
        private Rol rol;

        public Usuario(string nombre, string apellido, string dni, Rol rol)
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.dni = dni;
            this.rol = rol;
            this.direcciones = new List<string>();
            this.telefonos = new List<string>();
            this.mails = new List<string>();
        }
    }

}
