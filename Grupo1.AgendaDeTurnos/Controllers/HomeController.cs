using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Grupo1.AgendaDeTurnos.Models;
using Grupo1.AgendaDeTurnos.Database;

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
            if (!_context.Prestaciones.Any()) 
            {
                var prestacion = new Prestacion
                {
                    Nombre = "Odontologia General",
                    DuracionMinutos = "45",
                    Monto = 500
                };

                _context.Add(prestacion);
                _context.SaveChanges();

            }
        }

    }
}
