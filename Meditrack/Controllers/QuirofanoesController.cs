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
    public class QuirofanoesController : Controller
    {
        private readonly MeditrackContext _context;

        public QuirofanoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Quirofanoes
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.Quirofanos.Include(q => q.EstadoQuirofanoNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: Quirofanoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Quirofanos == null)
            {
                return NotFound();
            }

            var quirofano = await _context.Quirofanos
                .Include(q => q.EstadoQuirofanoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuirofano == id);
            if (quirofano == null)
            {
                return NotFound();
            }

            return View(quirofano);
        }

        // GET: Quirofanoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "IdEstado");
            return View();
        }

        // POST: Quirofanoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdQuirofano,NombreQuirofano,Ubicacion,EstadoQuirofano,DescripcionEstado,DescripcionEstadoQuirofano")] Quirofano quirofano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quirofano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "IdEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // GET: Quirofanoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Quirofanos == null)
            {
                return NotFound();
            }

            var quirofano = await _context.Quirofanos.FindAsync(id);
            if (quirofano == null)
            {
                return NotFound();
            }
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "IdEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // POST: Quirofanoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdQuirofano,NombreQuirofano,Ubicacion,EstadoQuirofano,DescripcionEstado,DescripcionEstadoQuirofano")] Quirofano quirofano)
        {
            if (id != quirofano.IdQuirofano)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quirofano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuirofanoExists(quirofano.IdQuirofano))
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
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "IdEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // GET: Quirofanoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Quirofanos == null)
            {
                return NotFound();
            }

            var quirofano = await _context.Quirofanos
                .Include(q => q.EstadoQuirofanoNavigation)
                .FirstOrDefaultAsync(m => m.IdQuirofano == id);
            if (quirofano == null)
            {
                return NotFound();
            }

            return View(quirofano);
        }

        // POST: Quirofanoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Quirofanos == null)
            {
                return Problem("Entity set 'MeditrackContext.Quirofanos'  is null.");
            }
            var quirofano = await _context.Quirofanos.FindAsync(id);
            if (quirofano != null)
            {
                _context.Quirofanos.Remove(quirofano);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuirofanoExists(int id)
        {
          return (_context.Quirofanos?.Any(e => e.IdQuirofano == id)).GetValueOrDefault();
        }
    }
}
