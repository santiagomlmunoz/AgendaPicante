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
using Grupo1.AgendaDeTurnos.EnumList;
using Microsoft.AspNetCore.Authorization;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class TurnosController : Controller
    {
        private int RANGO_TOLERANCIA_TURNO_MINUTOS = 15;


        private readonly AgendaDeTurnosDbContext _context;



        public TurnosController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Turnos.Include(t => t.Centro).Include(t => t.Paciente).Include(t => t.Profesional);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }
        [Authorize]
        [HttpGet]
        public IActionResult NuevoTurno()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPrestacion"] = new SelectList(_context.Prestaciones, "Id", "Nombre");

            return View();
        }
        [Authorize(Roles = nameof(RolesEnum.PROFESIONAL))]
        [HttpGet]
        public IActionResult ComenzarConsulta(int Id)
        {
            Turno turno = _context.Turnos
                 .Include(t => t.Paciente)
                 .Where(t => t.Id == Id)
                 .SingleOrDefault();

            return View(turno);
        }

        [Authorize(Roles = nameof(RolesEnum.CLIENTE))]
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

        [Authorize(Roles = nameof(RolesEnum.PROFESIONAL))]
        public  IActionResult FinalizarConsulta(int Id)
        {
            Turno turno = _context.Turnos
                .Where(t => t.Id == Id)
                .SingleOrDefault();
            turno.Estado = EstadoTurnoEnum.FINALIZADO;
            _context.Turnos.Update(turno);
            _context.SaveChanges();
            return RedirectToAction("AgendaDiaria");

        }


        [Authorize(Roles = nameof(RolesEnum.PROFESIONAL))]
        [HttpGet]
        public async Task<IActionResult> AgendaDiaria()
        {
            DateTime fechaDeHoy = DateTime.Now;
            int profesionalId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

            Profesional profesional = await _context.Profesionales
                .Include(p=>p.Centro)
                .Include(p => p.Prestacion)
                .Include(p => p.Turnos)
                    .ThenInclude(t=> t.Paciente)
                .Where(p => p.Id == profesionalId).SingleOrDefaultAsync();

            var listTurnosHoy = new List<Turno>();
            foreach (Turno t in profesional.Turnos)
            {
                DateTime rangoHasta = fechaDeHoy.AddMinutes(RANGO_TOLERANCIA_TURNO_MINUTOS);
                DateTime rangoDesde = fechaDeHoy.AddMinutes(RANGO_TOLERANCIA_TURNO_MINUTOS * -1);

                if (t.Fecha.Day == fechaDeHoy.Day)
                {
                    if(t.Fecha >= rangoDesde && t.Fecha <= rangoHasta && t.Estado != EstadoTurnoEnum.FINALIZADO)
                    {
                        //CAMBIO EL ESTADO PARA QUE DESDE EL FRONT SE PUEDA REALIZAR LA CONSULTA
                        t.Estado = EstadoTurnoEnum.ACTUAL;
                    }
                    listTurnosHoy.Add(t);
                }
            }
            if(listTurnosHoy.Count == 0)
            {
                ViewBag.MENSAJE = "No posee turnos reservados para el dia de hoy"; 
            }
            return View(listTurnosHoy);
        }


        [Authorize]
        public IActionResult NuevoTurno(Turno turno, int IdPrestacion, int hora)
        {

            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPrestacion"] = new SelectList(_context.Prestaciones, "Id", "Nombre");
            DateTime fechaYHoraDesde = turno.Fecha.AddHours(hora);
            //VALIDACION PARA QUE EL TURNO SEA EN EL FUTURO
            if (DateTime.Now > fechaYHoraDesde)
            {
                ViewBag.ERROR = "El turno debe ser en el futuro ";
                return View();
            }
            int pacienteId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            int idCentro = turno.IdCentro;
            List<Profesional> profesionales = _context.Profesionales
                                .Include(x => x.Turnos)
                                .Include(x => x.Prestacion)
                                .Where(prof =>
                                        prof.CentroId == idCentro &&
                                        prof.PrestacionId == IdPrestacion &&
                                        prof.Disponibilidades.Any(disponibilidad =>
                                            disponibilidad.Dia == DateUtil.ObtenerDiaPorDayOfWeek(turno.Fecha.DayOfWeek) &&
                                            disponibilidad.HoraDesde <= hora &&
                                            disponibilidad.HoraHasta >= (hora + prof.Prestacion.DuracionHoras)))
                                .ToList();

            Profesional profesionalAsignado = null;
            foreach (Profesional profesional in profesionales)
            {
                if (!profesional.Turnos.Any(t =>
                        t.Fecha.Day == turno.Fecha.Day
                        &&
                        // fin de turno solicitado <= comienzo turno actual
                        //(hora.Hour + profesional.Prestacion.DuracionHoras) >= t.Fecha.Hour
                         hora > t.Fecha.Hour - profesional.Prestacion.DuracionHoras
                        &&
                        // fin de turno actual <= comienzo turno solicitado
                        (hora < (t.Fecha.Hour + profesional.Prestacion.DuracionHoras))))
                {

                    profesionalAsignado = profesional;
                    turno.IdCentro = idCentro;
                    turno.Profesional = profesionalAsignado;
                    turno.Fecha = turno.Fecha.AddHours(hora);
                    turno.IdPaciente = pacienteId;
                    turno.Estado = EstadoTurnoEnum.PENDIENTE;
                    if(profesionalAsignado.Turnos == null)
                    {
                        profesionalAsignado.Turnos = new List<Turno>();
                       
                    }
                    //NO HACE FALTA GUARDAR EL TURNO, SE GUARDA AL RELACIONARLO CON PROFESIONAL
                    profesionalAsignado.Turnos.Add(turno);
                    _context.Profesionales.Update(profesionalAsignado);
                    _context.SaveChanges();
                    //MENSAJE RETORNO
                    ViewBag.MENSAJE = "Su turno se reservo correctamente";
                    ViewBag.PROFESIONAL = "Se atendera con el profesional " +
                        profesionalAsignado.Nombre
                        + " "
                        + profesionalAsignado.Apellido;
                    ViewBag.DIA = DateUtil.FechaToString(turno.Fecha);
                    ViewBag.HORA = turno.Fecha.Hour + "hs";
                    //------------
                    return View();
                }
            }
            ViewBag.ERROR = "No hay profesionales disponibles en ese horario";
            return View();

        }
        [Authorize]
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

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public IActionResult Create()
        {
            ViewData["IdCentro"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "Id", "Apellido");
            ViewData["IdProfesional"] = new SelectList(_context.Profesionales, "Id", "Apellido");
            return View();
        }
        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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

        [Authorize]
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

        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var turno = await _context.Turnos.FindAsync(id);
            _context.Turnos.Remove(turno);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MisTurnos));
        }

        private bool TurnoExists(int id)
        {
            return _context.Turnos.Any(e => e.Id == id);
        }

        [Authorize(Roles = nameof(RolesEnum.PROFESIONAL))]
        public async Task<IActionResult> MiAgenda()
        {
            int mesActual = DateTime.Now.Month;
            int montoTotal = 0;
            int profesionalId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Profesional profesional = await _context.Profesionales
                 .Include(p=> p.Turnos)
                    .ThenInclude(t=>t.Paciente)
                 .Include(p=> p.Prestacion)
                 .Include(p=> p.Centro)
                .SingleOrDefaultAsync(p => p.Id == profesionalId);

            List<Turno> turnosDelMesActual = new List<Turno>();
            foreach(Turno t in profesional.Turnos)
            {
                if(t.Fecha.Month == mesActual)
                {
                    turnosDelMesActual.Add(t);
                }
            }
            if (profesional !=null && turnosDelMesActual.Count > 0)
            {
                foreach(Turno t in turnosDelMesActual)
                {
                    if(t.Estado == EstadoTurnoEnum.FINALIZADO)
                    {
                        montoTotal = turnosDelMesActual.Count * profesional.Prestacion.Monto;
                    }
                }
               
            }
            ViewBag.Bienvenida = "Turnos para el mes de " + DateUtil.getMesPorNumero(mesActual);
            ViewBag.Monto = montoTotal;
            return View(turnosDelMesActual);
        }

    }

}
