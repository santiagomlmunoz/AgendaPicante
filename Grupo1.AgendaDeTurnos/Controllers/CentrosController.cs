using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Grupo1.AgendaDeTurnos.Database;
using Grupo1.AgendaDeTurnos.Models;

namespace Grupo1.AgendaDeTurnos.Controllers
{
    public class CentrosController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public CentrosController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        // GET: Centros
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Centros.Include(c => c.Direccion);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }

        // GET: Centros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centro == null)
            {
                return NotFound();
            }

            return View(centro);
        }

        // GET: Centros/Create
        public IActionResult Create()
        {
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Altura");
            return View();
        }

        // POST: Centros/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,DireccionId")] Centro centro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(centro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Altura", centro.DireccionId);
            return View(centro);
        }

        // GET: Centros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros.FindAsync(id);
            if (centro == null)
            {
                return NotFound();
            }
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Altura", centro.DireccionId);
            return View(centro);
        }

        // POST: Centros/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,DireccionId")] Centro centro)
        {
            if (id != centro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(centro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CentroExists(centro.Id))
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
            ViewData["DireccionId"] = new SelectList(_context.Direcciones, "Id", "Altura", centro.DireccionId);
            return View(centro);
        }

        // GET: Centros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros
                .Include(c => c.Direccion)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (centro == null)
            {
                return NotFound();
            }

            return View(centro);
        }

        // POST: Centros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var centro = await _context.Centros.FindAsync(id);
            _context.Centros.Remove(centro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CentroExists(int id)
        {
            return _context.Centros.Any(e => e.Id == id);
        }
    }
}
