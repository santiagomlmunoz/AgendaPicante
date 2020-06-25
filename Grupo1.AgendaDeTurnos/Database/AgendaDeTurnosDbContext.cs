using Grupo1.AgendaDeTurnos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grupo1.AgendaDeTurnos.Database
{
    public class AgendaDeTurnosDbContext : DbContext
    {
        public AgendaDeTurnosDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Administrador> Administradores { get; set; }

        public DbSet<Centro> Centros { get; set; }


        public DbSet<Direccion> Direcciones { get; set; }

        public DbSet<Disponibilidad> Disponibilidades { get; set; }

        //public DbSet<Mail> Mails { get; set; }

        public DbSet<Paciente> Pacientes { get; set; }

        public DbSet<Prestacion> Prestaciones { get; set; }

        public DbSet<Profesional> Profesionales { get; set; }


        //public DbSet<Telefono> Telefonos { get; set; }

        public DbSet<Turno> Turnos { get; set; }

        internal void add(Usuario usuario)
        {
            throw new NotImplementedException();
        }

    }
}
