﻿// <auto-generated />
using System;
using Grupo1.AgendaDeTurnos.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Grupo1.AgendaDeTurnos.Migrations
{
    [DbContext(typeof(AgendaDeTurnosDbContext))]
    [Migration("20200625195228_mig4")]
    partial class mig4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Centro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DireccionId");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("DireccionId");

                    b.ToTable("Centros");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Direccion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Altura")
                        .HasMaxLength(10);

                    b.Property<string>("Calle")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("IdUsuario");

                    b.Property<string>("Localidad")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Provincia")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Direcciones");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Disponibilidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<int>("Dia");

                    b.Property<int>("HoraDesde");

                    b.Property<int>("HoraHasta");

                    b.Property<int>("IdProfesional");

                    b.HasKey("Id");

                    b.HasIndex("IdProfesional");

                    b.ToTable("Disponibilidades");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired();

                    b.Property<int>("IdUsuario");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Mails");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Prestacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DuracionHoras")
                        .HasMaxLength(2);

                    b.Property<int>("Monto");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Prestaciones");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Telefono", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdUsuario");

                    b.Property<string>("NumeroCelular")
                        .IsRequired()
                        .HasMaxLength(12);

                    b.Property<string>("TelefonoAlternativo")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Turno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion");

                    b.Property<int>("Estado");

                    b.Property<DateTime>("Fecha");

                    b.Property<int>("IdCentro");

                    b.Property<int>("IdPaciente");

                    b.Property<int>("IdProfesional");

                    b.HasKey("Id");

                    b.HasIndex("IdCentro");

                    b.HasIndex("IdPaciente");

                    b.HasIndex("IdProfesional");

                    b.ToTable("Turnos");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Dni");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<byte[]>("Password");

                    b.Property<int>("Rol");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Usuario");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Usuario");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Administrador", b =>
                {
                    b.HasBaseType("Grupo1.AgendaDeTurnos.Models.Usuario");

                    b.HasDiscriminator().HasValue("Administrador");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Paciente", b =>
                {
                    b.HasBaseType("Grupo1.AgendaDeTurnos.Models.Usuario");

                    b.Property<int>("Edad");

                    b.HasDiscriminator().HasValue("Paciente");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Profesional", b =>
                {
                    b.HasBaseType("Grupo1.AgendaDeTurnos.Models.Usuario");

                    b.Property<int>("CentroId");

                    b.Property<int>("PrestacionId");

                    b.HasIndex("CentroId");

                    b.HasIndex("PrestacionId");

                    b.HasDiscriminator().HasValue("Profesional");
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Centro", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Direccion", "Direccion")
                        .WithMany()
                        .HasForeignKey("DireccionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Direccion", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Usuario", "Usuario")
                        .WithMany("Direcciones")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Disponibilidad", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Profesional", "Profesional")
                        .WithMany("Disponibilidades")
                        .HasForeignKey("IdProfesional")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Mail", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Usuario", "Usuario")
                        .WithMany("Mails")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Telefono", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Usuario", "Usuario")
                        .WithMany("Telefonos")
                        .HasForeignKey("IdUsuario")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Turno", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Centro", "Centro")
                        .WithMany("Turnos")
                        .HasForeignKey("IdCentro")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Paciente", "Paciente")
                        .WithMany("Turnos")
                        .HasForeignKey("IdPaciente")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Profesional", "Profesional")
                        .WithMany("Turnos")
                        .HasForeignKey("IdProfesional")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Grupo1.AgendaDeTurnos.Models.Profesional", b =>
                {
                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Centro", "Centro")
                        .WithMany("Profesionales")
                        .HasForeignKey("CentroId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Grupo1.AgendaDeTurnos.Models.Prestacion", "Prestacion")
                        .WithMany("Profesionales")
                        .HasForeignKey("PrestacionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
