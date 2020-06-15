using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Models;
using Grupo1.AgendaDeTurnos.Extensions;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class ProfesionalesController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public ProfesionalesController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        // GET: Profesionals
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Profesionales.Include(p => p.Centro).Include(p => p.Prestacion);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }

        // GET: Profesionals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .Include(p => p.Centro)
                .Include(p => p.Prestacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // GET: Profesionals/Create
        public IActionResult Create()
        {
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "Nombre");
            ViewData["PrestacionId"] = new SelectList(_context.Prestaciones, "Id", "Nombre");
            return View();
        }

        // POST: Profesionals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PrestacionId,CentroId,Id,Nombre,Apellido,Dni,Rol,Username")] Profesional profesional, string password)
        {
            if (ModelState.IsValid)
            {
                profesional.Username = profesional.Username.ToUpper();
                profesional.Password = password.Encriptar();
                profesional.Rol = RolesEnum.PROFESIONAL;
                _context.Add(profesional);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "Nombre", profesional.CentroId);
            ViewData["PrestacionId"] = new SelectList(_context.Prestaciones, "Id", "Nombre", profesional.PrestacionId);
            return View(profesional);
        }

        // GET: Profesionals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales.FindAsync(id);
            if (profesional == null)
            {
                return NotFound();
            }
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "Nombre", profesional.CentroId);
            ViewData["PrestacionId"] = new SelectList(_context.Prestaciones, "Id", "Nombre", profesional.PrestacionId);
            return View(profesional);
        }

        // POST: Profesionals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PrestacionId,CentroId,Id,Nombre,Apellido,Dni,Rol,Username")] Profesional profesional)
        {
            if (id != profesional.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesional);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfesionalExists(profesional.Id))
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
            ViewData["CentroId"] = new SelectList(_context.Centros, "Id", "Nombre", profesional.CentroId);
            ViewData["PrestacionId"] = new SelectList(_context.Prestaciones, "Id", "Nombre", profesional.PrestacionId);
            return View(profesional);
        }

        // GET: Profesionals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesional = await _context.Profesionales
                .Include(p => p.Centro)
                .Include(p => p.Prestacion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (profesional == null)
            {
                return NotFound();
            }

            return View(profesional);
        }

        // POST: Profesionals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesional = await _context.Profesionales.FindAsync(id);
            _context.Profesionales.Remove(profesional);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesionalExists(int id)
        {
            return _context.Profesionales.Any(e => e.Id == id);
        }
    }
}
