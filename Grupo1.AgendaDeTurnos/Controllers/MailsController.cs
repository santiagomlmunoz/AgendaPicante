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
    public class MailsController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public MailsController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        // GET: Mails
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Mails.Include(m => m.Usuario);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }

        // GET: Mails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mail == null)
            {
                return NotFound();
            }

            return View(mail);
        }

        // GET: Mails/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido");
            return View();
        }

        // POST: Mails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion,IdUsuario")] Mail mail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", mail.IdUsuario);
            return View(mail);
        }

        // GET: Mails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails.FindAsync(id);
            if (mail == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", mail.IdUsuario);
            return View(mail);
        }

        // POST: Mails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion,IdUsuario")] Mail mail)
        {
            if (id != mail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MailExists(mail.Id))
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
            ViewData["IdUsuario"] = new SelectList(_context.Set<Usuario>(), "Id", "Apellido", mail.IdUsuario);
            return View(mail);
        }

        // GET: Mails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mail = await _context.Mails
                .Include(m => m.Usuario)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mail == null)
            {
                return NotFound();
            }

            return View(mail);
        }

        // POST: Mails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mail = await _context.Mails.FindAsync(id);
            _context.Mails.Remove(mail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MailExists(int id)
        {
            return _context.Mails.Any(e => e.Id == id);
        }
    }
}
