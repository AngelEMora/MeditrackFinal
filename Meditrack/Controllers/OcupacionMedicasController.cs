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
    public class OcupacionMedicasController : Controller
    {
        private readonly MeditrackContext _context;

        public OcupacionMedicasController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: OcupacionMedicas
        public async Task<IActionResult> Index()
        {
              return _context.OcupacionMedicas != null ? 
                          View(await _context.OcupacionMedicas.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.OcupacionMedicas'  is null.");
        }

        // GET: OcupacionMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.OcupacionMedicas == null)
            {
                return NotFound();
            }

            var ocupacionMedica = await _context.OcupacionMedicas
                .FirstOrDefaultAsync(m => m.IdOcupacion == id);
            if (ocupacionMedica == null)
            {
                return NotFound();
            }

            return View(ocupacionMedica);
        }

        // GET: OcupacionMedicas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OcupacionMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdOcupacion,NombreOcupacion,DescripcionOcupacion")] OcupacionMedica ocupacionMedica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocupacionMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocupacionMedica);
        }

        // GET: OcupacionMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.OcupacionMedicas == null)
            {
                return NotFound();
            }

            var ocupacionMedica = await _context.OcupacionMedicas.FindAsync(id);
            if (ocupacionMedica == null)
            {
                return NotFound();
            }
            return View(ocupacionMedica);
        }

        // POST: OcupacionMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdOcupacion,NombreOcupacion,DescripcionOcupacion")] OcupacionMedica ocupacionMedica)
        {
            if (id != ocupacionMedica.IdOcupacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocupacionMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OcupacionMedicaExists(ocupacionMedica.IdOcupacion))
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
            return View(ocupacionMedica);
        }

        // GET: OcupacionMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.OcupacionMedicas == null)
            {
                return NotFound();
            }

            var ocupacionMedica = await _context.OcupacionMedicas
                .FirstOrDefaultAsync(m => m.IdOcupacion == id);
            if (ocupacionMedica == null)
            {
                return NotFound();
            }

            return View(ocupacionMedica);
        }

        // POST: OcupacionMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.OcupacionMedicas == null)
            {
                return Problem("Entity set 'MeditrackContext.OcupacionMedicas'  is null.");
            }
            var ocupacionMedica = await _context.OcupacionMedicas.FindAsync(id);
            if (ocupacionMedica != null)
            {
                _context.OcupacionMedicas.Remove(ocupacionMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OcupacionMedicaExists(int id)
        {
          return (_context.OcupacionMedicas?.Any(e => e.IdOcupacion == id)).GetValueOrDefault();
        }
    }
}
