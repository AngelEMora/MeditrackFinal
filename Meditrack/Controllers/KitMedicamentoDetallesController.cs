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
    public class KitMedicamentoDetallesController : Controller
    {
        private readonly MeditrackContext _context;

        public KitMedicamentoDetallesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: KitMedicamentoDetalles
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.KitMedicamentoDetalles.Include(k => k.IdKitsMedicamentoNavigation).Include(k => k.IdMedicamentoNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: KitMedicamentoDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitMedicamentoDetalles == null)
            {
                return NotFound();
            }

            var kitMedicamentoDetalle = await _context.KitMedicamentoDetalles
                .Include(k => k.IdKitsMedicamentoNavigation)
                .Include(k => k.IdMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.KitMedicamentoId == id);
            if (kitMedicamentoDetalle == null)
            {
                return NotFound();
            }

            return View(kitMedicamentoDetalle);
        }

        // GET: KitMedicamentoDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdKitsMedicamento"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos");
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "IdMedicamento");
            return View();
        }

        // POST: KitMedicamentoDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitMedicamentoId,IdMedicamento,IdKitsMedicamento,NotasMedicMedicamento,CantidadMedicamento")] KitMedicamentoDetalle kitMedicamentoDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitMedicamentoDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKitsMedicamento"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", kitMedicamentoDetalle.IdKitsMedicamento);
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "IdMedicamento", kitMedicamentoDetalle.IdMedicamento);
            return View(kitMedicamentoDetalle);
        }

        // GET: KitMedicamentoDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitMedicamentoDetalles == null)
            {
                return NotFound();
            }

            var kitMedicamentoDetalle = await _context.KitMedicamentoDetalles.FindAsync(id);
            if (kitMedicamentoDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdKitsMedicamento"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", kitMedicamentoDetalle.IdKitsMedicamento);
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "IdMedicamento", kitMedicamentoDetalle.IdMedicamento);
            return View(kitMedicamentoDetalle);
        }

        // POST: KitMedicamentoDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitMedicamentoId,IdMedicamento,IdKitsMedicamento,NotasMedicMedicamento,CantidadMedicamento")] KitMedicamentoDetalle kitMedicamentoDetalle)
        {
            if (id != kitMedicamentoDetalle.KitMedicamentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitMedicamentoDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitMedicamentoDetalleExists(kitMedicamentoDetalle.KitMedicamentoId))
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
            ViewData["IdKitsMedicamento"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", kitMedicamentoDetalle.IdKitsMedicamento);
            ViewData["IdMedicamento"] = new SelectList(_context.Medicamentos, "IdMedicamento", "IdMedicamento", kitMedicamentoDetalle.IdMedicamento);
            return View(kitMedicamentoDetalle);
        }

        // GET: KitMedicamentoDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitMedicamentoDetalles == null)
            {
                return NotFound();
            }

            var kitMedicamentoDetalle = await _context.KitMedicamentoDetalles
                .Include(k => k.IdKitsMedicamentoNavigation)
                .Include(k => k.IdMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.KitMedicamentoId == id);
            if (kitMedicamentoDetalle == null)
            {
                return NotFound();
            }

            return View(kitMedicamentoDetalle);
        }

        // POST: KitMedicamentoDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitMedicamentoDetalles == null)
            {
                return Problem("Entity set 'MeditrackContext.KitMedicamentoDetalles'  is null.");
            }
            var kitMedicamentoDetalle = await _context.KitMedicamentoDetalles.FindAsync(id);
            if (kitMedicamentoDetalle != null)
            {
                _context.KitMedicamentoDetalles.Remove(kitMedicamentoDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitMedicamentoDetalleExists(int id)
        {
          return (_context.KitMedicamentoDetalles?.Any(e => e.KitMedicamentoId == id)).GetValueOrDefault();
        }
    }
}
