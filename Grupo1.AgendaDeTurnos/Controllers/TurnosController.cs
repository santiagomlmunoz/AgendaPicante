using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Models;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http2.HPack;
using System.Security.Claims;
using System.Linq.Expressions;
using Grupo1.AgendaDeTurnos.Extensions;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class TurnosController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public TurnosController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        // GET: Turnoes
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Turnos.Include(t => t.Centro).Include(t => t.Paciente).Include(t => t.Profesional);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }
        [HttpGet]
        public IActionResult NuevoTurno()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPrestacion"] = new SelectList(_context.Prestaciones, "Id", "Nombre");

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MisTurnos()
        {
            int pacienteId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Paciente paciente = await _context.Pacientes
                .Include(t => t.Turnos)
                .ThenInclude(t => t.Centro)
                .Include(t => t.Turnos)
                .ThenInclude(t => t.Profesional)

                .FirstOrDefaultAsync(p => p.Id == pacienteId);

            return View(paciente.Turnos);
        }



        public async Task<IActionResult> NuevoTurno(Turno turno, int IdPrestacion, DateTime hora)
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPrestacion"] = new SelectList(_context.Prestaciones, "Id", "Nombre");
            int pacienteId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int idCentro = turno.IdCentro;
            List<Profesional> profesionales = _context.Profesionales
                                .Include(x => x.Turnos)
                                .Include(x => x.Prestacion)
                                .Where(prof =>
                                        prof.CentroId == idCentro &&
                                        prof.PrestacionId == IdPrestacion &&
                                        prof.Disponibilidades.Any(disponibilidad =>
                                            disponibilidad.Dia == GetDia.ObtenerDiaPorDayOfWeek(turno.Fecha.DayOfWeek) &&
                                            disponibilidad.HoraDesde <= hora.Hour &&
                                            disponibilidad.HoraHasta >= (hora.Hour + prof.Prestacion.DuracionHoras)))
                                .ToList();

            Profesional profesionalAsignado = null;

            foreach (Profesional profesional in profesionales)
            {
                if (!profesional.Turnos.Any(t =>
                        t.Fecha.DayOfWeek == turno.Fecha.DayOfWeek &&
                        // fin de turno solicitado <= comienzo turno actual
                        (hora.Hour + profesional.Prestacion.DuracionHoras) <= t.Fecha.Hour &&
                        // fin de turno actual <= comienzo turno solicitado
                        (t.Fecha.Hour + profesional.Prestacion.DuracionHoras) <= hora.Hour))
                {

                    profesionalAsignado = profesional;
                    Turno turnoReservado = new Turno()
                    {
                        IdCentro = idCentro,
                        Profesional = profesionalAsignado,
                        Fecha = turno.Fecha.AddHours(hora.Hour),
                        IdPaciente = pacienteId,
                                               
                    };
                    if(profesionalAsignado.Turnos == null)
                    {
                        profesionalAsignado.Turnos = new List<Turno>();
                       
                    }
                    //NO HACE FALTA GUARDAR EL TURNO, SE GUARDA AL RELACIONARLO CON PROFESIONAL
                    profesionalAsignado.Turnos.Add(turnoReservado);
                    _context.Profesionales.Update(profesionalAsignado);
                    _context.SaveChanges();
                    //MENSAJE RETORNO
                    ViewBag.MENSAJE = "Su turno se reservo correctamente";
                    ViewBag.PROFESIONAL = "Se atendera con el profesional " +
                        profesionalAsignado.Nombre
                        + " "
                        + profesionalAsignado.Apellido;
                    ViewBag.HORARIO = GetDia.ObtenerDiaPorDayOfWeek(turno.Fecha.DayOfWeek) + " a las " + hora.Hour + "hs";
                    //------------
                    return View();
                }
            }
            ViewBag.ERROR = "No hay profesionales disponibles en ese horario";
            return View();

        }
        // GET: Turnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Centro)
                .Include(t => t.Paciente)
                .Include(t => t.Profesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // GET: Turnoes/Create
        public IActionResult Create()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Apellido");
            ViewData["IdProfesional"] = new SelectList(_context.Profesionales, "Id", "Apellido");
            return View();
        }
        // POST: Turnoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,IdPaciente,IdProfesional,IdCentro")] Turno turno)
        {
            if (ModelState.IsValid)
            {
                _context.Add(turno);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre", turno.IdCentro);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Apellido", turno.IdPaciente);
            ViewData["IdProfesional"] = new SelectList(_context.Profesionales, "Id", "Apellido", turno.IdProfesional);
            return View(turno);
        }

        // GET: Turnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos.FindAsync(id);
            if (turno == null)
            {
                return NotFound();
            }
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre", turno.IdCentro);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Apellido", turno.IdPaciente);
            ViewData["IdProfesional"] = new SelectList(_context.Profesionales, "Id", "Apellido", turno.IdProfesional);
            return View(turno);
        }

        // POST: Turnoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,IdPaciente,IdProfesional,IdCentro")] Turno turno)
        {
            if (id != turno.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(turno);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TurnoExists(turno.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre", turno.IdCentro);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Apellido", turno.IdPaciente);
            ViewData["IdProfesional"] = new SelectList(_context.Profesionales, "Id", "Apellido", turno.IdProfesional);
            return View(turno);
        }

        // GET: Turnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var turno = await _context.Turnos
                .Include(t => t.Centro)
                .Include(t => t.Paciente)
                .Include(t => t.Profesional)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (turno == null)
            {
                return NotFound();
            }

            return View(turno);
        }

        // POST: Turnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }
    }
}
