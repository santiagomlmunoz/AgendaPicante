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
            Paciente paciente = await _context.Pacientes.FindAsync(pacienteId);
            int idCentro = turno.IdCentro;
            Centro centro = await _context.Centros
                .Include(p => p.Profesionales)
                .ThenInclude(pre => pre.Prestacion)
                .FirstOrDefaultAsync(p => p.Id == idCentro);

            Prestacion prestacion = await _context.Prestaciones
                                     .Include(p => p.Profesionales)
                                      .FirstOrDefaultAsync(p => p.Id == IdPrestacion);
            int duracionPrestacion = prestacion.DuracionHoras;

            List<Profesional> pr = _context.Profesionales
                                    .Include(p => p.Prestacion)
                                    .Include(c => c.Centro)
                                    .Include(d => d.Disponibilidades)
                                    .Include(t => t.Turnos)
                                    .Where(prof => prof.CentroId == idCentro && prof.PrestacionId == IdPrestacion)
                                    .ToList();
            DateTime fechaDeHoy = DateTime.Now;
            DateTime fechaYHoraDesde = turno.Fecha.AddHours(hora.Hour);
            int horaDesde = hora.Hour;
            DateTime fechaHasta = hora.AddHours(duracionPrestacion);
            DayOfWeek dia = fechaYHoraDesde.DayOfWeek;
            int horaHasta = fechaHasta.Hour;
            if(fechaDeHoy > fechaYHoraDesde)
            {
                ViewBag.Error = "El turno debe ser en el futuro ";
                return View();
            }
            foreach (Profesional p in pr)
            {
                List<Disponibilidad> disponibilidades = p.Disponibilidades;
                bool estaDisponible = false;
                int contadorDisponibilidad = 0;
                while (!estaDisponible && contadorDisponibilidad < disponibilidades.Count)
                {
                    Disponibilidad d = disponibilidades[contadorDisponibilidad];
                    if (d.HoraDesde <= horaDesde && d.HoraHasta >= horaHasta && d.Dia == dia)
                    {

                        estaDisponible = true;

                    }
                    contadorDisponibilidad++;
                }

                if (estaDisponible)
                {
                    List<Turno> turnos = p.Turnos;
                    if (turnos.Count == 0)
                    {
                        Turno turnoReserva = new Turno()
                        {
                            Centro = centro,
                            Profesional = p,
                            Fecha = fechaYHoraDesde,
                            Paciente = paciente,
                        };
                        p.Turnos.Add(turnoReserva);
                        _context.Profesionales.Update(p);
                        _context.SaveChanges();
                        ViewBag.Estado = "Su reserva se realizo exitosamente";
                        ViewBag.Profesional = p.Nombre + " " + p.Apellido;
                        ViewBag.Fecha = fechaYHoraDesde;
                        ViewBag.Hora = fechaYHoraDesde.Hour + " hs";

                        return View();
                    }


                    bool tieneTurnoAEsaHora = false;
                    int contadorTurnos = 0;
                    while (!tieneTurnoAEsaHora && contadorTurnos < turnos.Count)
                    {
                        Turno t = turnos[contadorTurnos];
                        int menorATurno = t.Fecha.Hour - duracionPrestacion;
                        int horaHastDelTurno = t.Fecha.AddHours(duracionPrestacion).Hour;
                        if (horaDesde > menorATurno && horaDesde < horaHastDelTurno && t.Fecha.Date == fechaYHoraDesde.Date)
                        {
                            tieneTurnoAEsaHora = true;
                        }
                        contadorTurnos++;
                    }

                    if (!tieneTurnoAEsaHora)
                    {
                        Turno turnoReserva = new Turno()
                        {
                            Centro = centro,
                            Profesional = p,
                            Fecha = fechaYHoraDesde,
                            Paciente = paciente
                        };
                        _context.Turnos.Add(turnoReserva);
                        _context.SaveChanges();
                        ViewBag.Estado = "Su reserva se realizo exitosamente";
                        ViewBag.Profesional = p.Nombre + " " + p.Apellido;
                        ViewBag.Fecha = fechaYHoraDesde;
                        ViewBag.Hora = fechaYHoraDesde.Hour;
                        return View();
                    }

                }
                contadorDisponibilidad = 0;
                estaDisponible = false;

            }

            ViewBag.Error = "Ese horario NO se encuentra disponible";
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
