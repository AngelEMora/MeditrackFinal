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
    public class EstadosCirugiasController : Controller
    {
        private readonly MeditrackContext _context;

        public EstadosCirugiasController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: EstadosCirugias
        public async Task<IActionResult> Index()
        {
              return _context.EstadosCirugias != null ? 
                          View(await _context.EstadosCirugias.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.EstadosCirugias'  is null.");
        }

        // GET: EstadosCirugias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosCirugias == null)
            {
                return NotFound();
            }

            var estadosCirugia = await _context.EstadosCirugias
                .FirstOrDefaultAsync(m => m.IdEstadoCirugias == id);
            if (estadosCirugia == null)
            {
                return NotFound();
            }

            return View(estadosCirugia);
        }

        // GET: EstadosCirugias/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosCirugias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoCirugias,NombreEstadosCirugia")] EstadosCirugia estadosCirugia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosCirugia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosCirugia);
        }

        // GET: EstadosCirugias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadosCirugias == null)
            {
                return NotFound();
            }

            var estadosCirugia = await _context.EstadosCirugias.FindAsync(id);
            if (estadosCirugia == null)
            {
                return NotFound();
            }
            return View(estadosCirugia);
        }

        // POST: EstadosCirugias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoCirugias,NombreEstadosCirugia")] EstadosCirugia estadosCirugia)
        {
            if (id != estadosCirugia.IdEstadoCirugias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosCirugia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosCirugiaExists(estadosCirugia.IdEstadoCirugias))
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
            return View(estadosCirugia);
        }

        // GET: EstadosCirugias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosCirugias == null)
            {
                return NotFound();
            }

            var estadosCirugia = await _context.EstadosCirugias
                .FirstOrDefaultAsync(m => m.IdEstadoCirugias == id);
            if (estadosCirugia == null)
            {
                return NotFound();
            }

            return View(estadosCirugia);
        }

        // POST: EstadosCirugias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosCirugias == null)
            {
                return Problem("Entity set 'MeditrackContext.EstadosCirugias'  is null.");
            }
            var estadosCirugia = await _context.EstadosCirugias.FindAsync(id);
            if (estadosCirugia != null)
            {
                _context.EstadosCirugias.Remove(estadosCirugia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosCirugiaExists(int id)
        {
          return (_context.EstadosCirugias?.Any(e => e.IdEstadoCirugias == id)).GetValueOrDefault();
        }
    }
}
