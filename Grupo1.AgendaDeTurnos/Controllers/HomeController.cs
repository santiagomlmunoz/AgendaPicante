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
            Seed();
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
                DuracionMinutos = "45",
                Monto = 500
            };
            var rol1 = new Rol
            {
                Descripcion = "ADMINISTRADOR"
            };
            var rol2 = new Rol
            {
                Descripcion = "PACIENTE"
            };
            var rol3 = new Rol
            {
                Descripcion = "PROFESIONAL"
            };
            var direCentro = new Direccion
            {
                Calle = "Aristobulo del valle2",
                Altura = "285",
                Localidad = "CABA",
                Provincia = "BUENOS AIRES"
            };
            var centro = new Centro
            {
                Nombre = "Centro Odontlogico",
                Direccion = direCentro,
                Pacientes = new List<Paciente>(),
                Profesionales = new List<Profesional>(),
                Telefonos = new List<Telefono>(),
                Disponibilidades = new List<Disponibilidad>()
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
            var paciente3 = new Paciente
            {
                Nombre = "Pepe3",
                Apellido = "Paciente3",
                Dni = "123123123",
                Rol = RolesEnum.CLIENTE,
                Direcciones = new List<Direccion>(),
                Mails = new List<Mail>(),                
                Telefonos = new List<Telefono>(),
                Turnos = new List<Turno>(),
                Username = "DUKI",
                Password = "goku".Encriptar()
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
            var disp1 = new Disponibilidad
            {
                Dia ="LUNES", HoraDesde= "3",HoraHasta = "5"
            };
            var consultorio = new Consultorio
            {
                Disponibilidades = new List<Disponibilidad>(),
                Nombre = "C005",
                Turnos = new List<Turno>()
            };
            var profesional = new Profesional
            {
                Nombre = "Roberto",
                Apellido= "Garcia",
                Centro = centro,
                Dni = "123123123",
                Prestacion = prestacion,
                Rol = RolesEnum.PROFESIONAL,
                Mails = new List<Mail>(),
                Turnos = new List<Turno>(),
                Telefonos = new List<Telefono>(),
                Direcciones = new List<Direccion>(),
                Disponibilidades = new List<Disponibilidad>(),
                Username = "ELPROFE",
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
            var turno = new Turno
            {
                Fecha = "21/05/2020",
                Hora = "15",
                Estado = true,
                Consultorio = consultorio,
                Paciente = paciente2,
                Profesional = profesional
             };
           

            profesional.Mails.Add(mail1);
            profesional.Mails.Add(mail2);
            profesional.Mails.Add(mail3);
            profesional.Turnos.Add(turno);
            profesional.Telefonos.Add(tel2);
            profesional.Telefonos.Add(tel1);            
            profesional.Direcciones.Add(direCentro);
            profesional.Disponibilidades.Add(disp1);

            consultorio.Disponibilidades.Add(disp1);

            paciente.Mails.Add(mail1);
            paciente2.Mails.Add(mail1);
            paciente3.Mails.Add(mail1);

            paciente.Mails.Add(mail2);
            paciente2.Mails.Add(mail2);
            paciente3.Mails.Add(mail2);

            paciente.Mails.Add(mail3);
            paciente2.Mails.Add(mail3);
            paciente3.Mails.Add(mail3);


            _context.Administradores.Add(administrador);
            _context.SaveChanges();

            if (!_context.Prestaciones.Any()) 
            {               

                _context.Add(prestacion);
                _context.SaveChanges();

            }

            if (!_context.Roles.Any())
            {                
                _context.Add(rol1);
                _context.Add(rol2);
                _context.Add(rol3);
                _context.SaveChanges();
            }

            if (!_context.Centros.Any())
            {      
                centro.Pacientes.Add(paciente);
                centro.Pacientes.Add(paciente2);
                centro.Pacientes.Add(paciente3);

                centro.Telefonos.Add(tel1);
                centro.Telefonos.Add(tel2);


                _context.Add(centro);
                _context.SaveChanges();

            }

            if (!_context.Turnos.Any())
            {
                _context.Add(turno);
                _context.SaveChanges();
            }

            if (!_context.Profesionales.Any())
            {
                _context.Add(profesional);
                _context.SaveChanges();
            }
            


        }

    }
}
