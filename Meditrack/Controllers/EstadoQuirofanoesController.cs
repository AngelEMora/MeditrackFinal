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
    public class EstadoQuirofanoesController : Controller
    {
        private readonly MeditrackContext _context;

        public EstadoQuirofanoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: EstadoQuirofanoes
        public async Task<IActionResult> Index()
        {
              return _context.EstadoQuirofanos != null ? 
                          View(await _context.EstadoQuirofanos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.EstadoQuirofanos'  is null.");
        }

        // GET: EstadoQuirofanoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadoQuirofanos == null)
            {
                return NotFound();
            }

            var estadoQuirofano = await _context.EstadoQuirofanos
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoQuirofano == null)
            {
                return NotFound();
            }

            return View(estadoQuirofano);
        }

        // GET: EstadoQuirofanoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoQuirofanoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstado,DescripcionEstado,FechaCreacion,Activo")] EstadoQuirofano estadoQuirofano)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoQuirofano);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoQuirofano);
        }

        // GET: EstadoQuirofanoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadoQuirofanos == null)
            {
                return NotFound();
            }

            var estadoQuirofano = await _context.EstadoQuirofanos.FindAsync(id);
            if (estadoQuirofano == null)
            {
                return NotFound();
            }
            return View(estadoQuirofano);
        }

        // POST: EstadoQuirofanoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstado,DescripcionEstado,FechaCreacion,Activo")] EstadoQuirofano estadoQuirofano)
        {
            if (id != estadoQuirofano.IdEstado)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoQuirofano);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoQuirofanoExists(estadoQuirofano.IdEstado))
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
            return View(estadoQuirofano);
        }

        // GET: EstadoQuirofanoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadoQuirofanos == null)
            {
                return NotFound();
            }

            var estadoQuirofano = await _context.EstadoQuirofanos
                .FirstOrDefaultAsync(m => m.IdEstado == id);
            if (estadoQuirofano == null)
            {
                return NotFound();
            }

            return View(estadoQuirofano);
        }

        // POST: EstadoQuirofanoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadoQuirofanos == null)
            {
                return Problem("Entity set 'MeditrackContext.EstadoQuirofanos'  is null.");
            }
            var estadoQuirofano = await _context.EstadoQuirofanos.FindAsync(id);
            if (estadoQuirofano != null)
            {
                _context.EstadoQuirofanos.Remove(estadoQuirofano);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoQuirofanoExists(int id)
        {
          return (_context.EstadoQuirofanos?.Any(e => e.IdEstado == id)).GetValueOrDefault();
        }
    }
}
