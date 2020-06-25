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
    public class AdministradoresController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public AdministradoresController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Administradores.ToListAsync());
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Rol,Username")] Administrador administrador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(administrador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administrador);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores.FindAsync(id);
            if (administrador == null)
            {
                return NotFound();
            }
            return View(administrador);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Rol,Username")] Administrador administrador)
        {
            if (id != administrador.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(administrador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradorExists(administrador.Id))
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
            return View(administrador);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var administrador = await _context.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var administrador = await _context.Administradores.FindAsync(id);
            _context.Administradores.Remove(administrador);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradorExists(int id)
        {
            return _context.Administradores.Any(e => e.Id == id);
        }
    }
}
