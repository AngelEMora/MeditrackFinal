using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meditrack.Models;

namespace Meditrack.Controllers
{
    public class EspecialidadesMedicasController : Controller
    {
        private readonly MeditrackContext _context;

        public EspecialidadesMedicasController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: EspecialidadesMedicas
        public async Task<IActionResult> Index()
        {
              return _context.EspecialidadesMedicas != null ? 
                          View(await _context.EspecialidadesMedicas.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.EspecialidadesMedicas'  is null.");
        }

        // GET: EspecialidadesMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EspecialidadesMedicas == null)
            {
                return NotFound();
            }

            var especialidadesMedica = await _context.EspecialidadesMedicas
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidadesMedica == null)
            {
                return NotFound();
            }

            return View(especialidadesMedica);
        }

        // GET: EspecialidadesMedicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EspecialidadesMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEspecialidad,NombreEspecialidad")] EspecialidadesMedica especialidadesMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(especialidadesMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidadesMedica);
        }

        // GET: EspecialidadesMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EspecialidadesMedicas == null)
            {
                return NotFound();
            }

            var especialidadesMedica = await _context.EspecialidadesMedicas.FindAsync(id);
            if (especialidadesMedica == null)
            {
                return NotFound();
            }
            return View(especialidadesMedica);
        }

        // POST: EspecialidadesMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEspecialidad,NombreEspecialidad")] EspecialidadesMedica especialidadesMedica)
        {
            if (id != especialidadesMedica.IdEspecialidad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(especialidadesMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EspecialidadesMedicaExists(especialidadesMedica.IdEspecialidad))
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
            return View(especialidadesMedica);
        }

        // GET: EspecialidadesMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EspecialidadesMedicas == null)
            {
                return NotFound();
            }

            var especialidadesMedica = await _context.EspecialidadesMedicas
                .FirstOrDefaultAsync(m => m.IdEspecialidad == id);
            if (especialidadesMedica == null)
            {
                return NotFound();
            }

            return View(especialidadesMedica);
        }

        // POST: EspecialidadesMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EspecialidadesMedicas == null)
            {
                return Problem("Entity set 'MeditrackContext.EspecialidadesMedicas'  is null.");
            }
            var especialidadesMedica = await _context.EspecialidadesMedicas.FindAsync(id);
            if (especialidadesMedica != null)
            {
                _context.EspecialidadesMedicas.Remove(especialidadesMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EspecialidadesMedicaExists(int id)
        {
          return (_context.EspecialidadesMedicas?.Any(e => e.IdEspecialidad == id)).GetValueOrDefault();
        }
    }
}
