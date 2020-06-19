using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grupo1.AgendaDeTurnos.Models;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Extensions;

namespace Grupo1.AgendaDeTurnos.Controllers
{

    public class HomeController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;
        public HomeController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
          
            //if (!_context.Prestaciones.Any())
            //{
            //   //Seed();
            //    Administrador admin = new Administrador()
            //    {
            //        Nombre = "ElAdmin",
            //        Apellido = "TheBest",
            //        Username = "SOYADMIN2",
            //        Password = "soyadmin".Encriptar(),
            //        Rol = RolesEnum.ADMINISTRADOR,

            //    };
            //    _context.Administradores.Add(admin);
            //    _context.SaveChanges();
            //}
             


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        public void Seed()
            
        {
            
            
                var prestacion = new Prestacion
            {
                Nombre = "Odontologia General",
                Monto = 500,
                DuracionHoras = 1
            };
            var prestacion2 = new Prestacion
            {
                Nombre = "Ortodoncia",
                Monto =1000,
                DuracionHoras = 2
            };
            var disponibilidad = new Disponibilidad(9, 18, DiasEnum.Sabado);

            var direCentro = new Direccion
        {
            Calle = "La famosa",
            Altura = 321,
            Localidad = "Escobar",
            Provincia = "BUENOS AIRES"
        };
            var centro1 = new Centro
            {
                Direccion = direCentro,
                Nombre = "The best centro",
                
            };
            var direPaciente1 = new Direccion
        {
            Calle = "Aristobulo del valle2",
            Altura = 285,
            Localidad = "CABA",
            Provincia = "BUENOS AIRES"
        };
        var direPaciente2 = new Direccion
        {
            Calle = "Calle falsa",
            Altura = 123,
            Localidad = "CABA",
            Provincia = "BUENOS AIRES"
        };
        var direProf = new Direccion
        {
            Calle = "Calle falsedad",
            Altura = 13323,
            Localidad = "CABA",
            Provincia = "BUENOS AIRES"
        };
        var direAdmin = new Direccion
        {
            Calle = "Calle delAdmin",
            Altura = 1323,
            Localidad = "CABA",
            Provincia = "BUENOS AIRES"
        };

        var tel1 = new Telefono
        {
            NumeroCelular = "111122222",
            TelefonoAlternativo = "456456456"
        };
        var tel2 = new Telefono
        {
            NumeroCelular = "1111222223",
            TelefonoAlternativo = "4564564563"
        };
        var tel3 = new Telefono
        {
            NumeroCelular = "1113332223",
            TelefonoAlternativo = "45634564563"
        };
        var tel4 = new Telefono
        {
            NumeroCelular = "1111222223",
            TelefonoAlternativo = "4564564563"
        };
        var mail1 = new Mail
        {
            Descripcion = "abc@abc.com"
        };
        var mail2 = new Mail
        {
            Descripcion = "abc@abc2.com"
        };
        var mail3 = new Mail
        {
            Descripcion = "abc@abc3.com"
        };
        var mail4 = new Mail
        {
            Descripcion = "abc@abc4.com"
        };


        var profesional = new Profesional
        {
            Nombre = "Roberto",
            Apellido = "Garcia",
              Centro = centro1,
            Dni = "123123123",
            Prestacion = prestacion2,
            Rol = RolesEnum.PROFESIONAL,
            Mails = new List<Mail>(),
            Turnos = new List<Turno>(),
            Telefonos = new List<Telefono>(),
            Direcciones = new List<Direccion>(),
            Disponibilidades = new List<Disponibilidad>(),
            Username = "ELPROFE",
            Password = "soyProfe".Encriptar()
        };
            var profesional2 = new Profesional
            {
                Nombre = "Checho",
                Apellido = "Palavecino",
                Centro = centro1,
                Dni = "999999999",
                Prestacion = prestacion,
                Rol = RolesEnum.PROFESIONAL,
                Mails = new List<Mail>(),
                Turnos = new List<Turno>(),
                Telefonos = new List<Telefono>(),
                Direcciones = new List<Direccion>(),
                Disponibilidades = new List<Disponibilidad>(),
                Username = "PROFE2",
                Password = "soyProfe".Encriptar()
            };
            var administrador = new Administrador
        {
            Nombre = "Cristofer",
            Apellido = "Wallace",
            Dni = "00000000001",
            Rol = RolesEnum.ADMINISTRADOR,
            Mails = new List<Mail>(),
            Telefonos = new List<Telefono>(),
            Direcciones = new List<Direccion>(),
            Username = "SOYADMIN",
            Password = "soyAdmin".Encriptar()
        };
        var paciente = new Paciente
        {
            Nombre = "Pepe",
            Apellido = "Paciente",
            Dni = "123123123",
            Rol = RolesEnum.CLIENTE,
            Direcciones = new List<Direccion>(),
            Mails = new List<Mail>(),
            Telefonos = new List<Telefono>(),
            Turnos = new List<Turno>(),
            Username = "ELPEPE",
            Password = "1234".Encriptar()
        };
        var paciente2 = new Paciente
        {
            Nombre = "Pepe2",
            Apellido = "Paciente2",
            Dni = "123123123",
            Rol = RolesEnum.CLIENTE,
            Direcciones = new List<Direccion>(),
            Mails = new List<Mail>(),
            Telefonos = new List<Telefono>(),
            Turnos = new List<Turno>(),
            Username = "ELPACIENT",
            Password = "soyPaciente".Encriptar()
        };
        administrador.Mails.Add(mail4);
         administrador.Telefonos.Add(tel4);
         administrador.Direcciones.Add(direAdmin);

         profesional.Mails.Add(mail1);
         profesional.Telefonos.Add(tel1);            
         profesional.Direcciones.Add(direProf);
            profesional.Disponibilidades.Add(disponibilidad);

         paciente.Telefonos.Add(tel2);
         paciente.Mails.Add(mail2);
         paciente2.Mails.Add(mail3);
         paciente.Direcciones.Add(direPaciente1);
         paciente2.Telefonos.Add(tel3);
         paciente2.Direcciones.Add(direPaciente2);

         _context.Pacientes.Add(paciente);
         _context.Pacientes.Add(paciente2);
         _context.Profesionales.Add(profesional);
          _context.Profesionales.Add(profesional2);
          _context.Administradores.Add(administrador);
        _context.SaveChanges();

      /*      if (!_context.Prestaciones.Any()) 
            {               

                _context.Add(prestacion);
                _context.SaveChanges();

            } */
        }

    }
}
