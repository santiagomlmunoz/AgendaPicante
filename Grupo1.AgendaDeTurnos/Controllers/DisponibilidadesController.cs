using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Models;
using Microsoft.AspNetCore.Authorization;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class DisponibilidadesController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;


        public DisponibilidadesController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }


        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disponibilidades.ToListAsync());
        }
        public IActionResult AgregarDisponibilidad(int desde, int hasta, DiasEnum dia, string rol)
        {
            Disponibilidad dis = new Disponibilidad(desde, hasta, dia);
            _context.Disponibilidades.Add(dis);
            _context.SaveChanges();

            ViewData["Disponibilidades"] = new MultiSelectList(_context.Disponibilidades, "Id", "Descripcion");
            return RedirectToAction("Create", "Profesionales");
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // GET: Disponibilidads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidades.FindAsync(id);
            if (disponibilidad == null)
            {
                return NotFound();
            }
            return View(disponibilidad);
        }

        // POST: Disponibilidads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Dia,HoraDesde,HoraHasta,IdProfesional")] Disponibilidad disponibilidad)
        {
            if (id != disponibilidad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disponibilidad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisponibilidadExists(disponibilidad.Id))
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
            return View(disponibilidad);
        }

        // GET: Disponibilidads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disponibilidad = await _context.Disponibilidades
                .FirstOrDefaultAsync(m => m.Id == id);
            if (disponibilidad == null)
            {
                return NotFound();
            }

            return View(disponibilidad);
        }

        // POST: Disponibilidads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var disponibilidad = await _context.Disponibilidades.FindAsync(id);
            _context.Disponibilidades.Remove(disponibilidad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisponibilidadExists(int id)
        {
            return _context.Disponibilidades.Any(e => e.Id == id);
        }
    }
}
