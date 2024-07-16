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
    public class QuirofanosController : Controller
    {
        private readonly MeditrackContext _context;

        public QuirofanosController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Quirofanos
        public async Task<IActionResult> Index(string searchString, int pageNumber = 1, int pageSize = 10)
        {
            var quirofanos = from p in _context.Quirofanos
                           select p;

            // Filtrado por búsqueda
            if (!String.IsNullOrEmpty(searchString))
            {
                quirofanos = quirofanos.Where(p => p.NombreQuirofano.Contains(searchString));
            }

            // Paginación
            int totalRecords = await quirofanos.CountAsync();
            var quirofanosList = await quirofanos.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();

            ViewBag.PageNumber = pageNumber;
            ViewBag.PageSize = pageSize;
            ViewBag.TotalRecords = totalRecords;
            ViewBag.SearchString = searchString;

            return View(quirofanosList);
        }

        // GET: Quirofanos/Details/5
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

        // GET: Quirofanos/Create
        public IActionResult Create()
        {
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "DescripcionEstado");
            return View();
        }

        // POST: Quirofanos/Create
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
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "DescripcionEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // GET: Quirofanos/Edit/5
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
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "DescripcionEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // POST: Quirofanos/Edit/5
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
            ViewData["EstadoQuirofano"] = new SelectList(_context.EstadoQuirofanos, "IdEstado", "DescripcionEstado", quirofano.EstadoQuirofano);
            return View(quirofano);
        }

        // GET: Quirofanos/Delete/5
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

        // POST: Quirofanos/Delete/5
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
