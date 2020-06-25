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
    public class CentrosController : Controller
    {
        private readonly AgendaDeTurnosDbContext _context;

        public CentrosController(AgendaDeTurnosDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var agendaDeTurnosDbContext = _context.Centros.Include(c => c.Direccion);
            return View(await agendaDeTurnosDbContext.ToListAsync());
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nombre")] Centro centro, string calle, int altura, string localidad, string provincia )
        {
            Direccion direccion = new Direccion()
            {
                Calle = calle,
                Altura = altura,
                Localidad = localidad,
                Provincia = provincia
            };
            _context.Direcciones.Add(direccion);

            centro.Direccion = direccion;
            if (ModelState.IsValid)
            {
                _context.Add(centro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
           return View(centro);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var centro = await _context.Centros
                .Include(c =>c.Direccion)
                .FirstOrDefaultAsync(c =>c.Id == id);
            if (centro == null)
            {
                return NotFound();
            }
            ViewBag.calle = centro.Direccion.Calle;
            ViewBag.altura = centro.Direccion.Altura;
            ViewBag.localidad = centro.Direccion.Localidad;
            ViewBag.provincia = centro.Direccion.Provincia;
            return View(centro);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nombre, Id")] Centro centro, string calle, string localidad, int altura, string provincia)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Direccion direccion = new Direccion()
                    {
                        Calle = calle,
                        Altura = altura,
                        Localidad = localidad,
                        Provincia = provincia
                    };
                    centro.Direccion = direccion;
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
            return View(centro);
        }

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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

        [Authorize(Roles = nameof(RolesEnum.ADMINISTRADOR))]
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
