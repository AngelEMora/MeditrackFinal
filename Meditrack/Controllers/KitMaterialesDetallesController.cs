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
    public class KitMaterialesDetallesController : Controller
    {
        private readonly MeditrackContext _context;

        public KitMaterialesDetallesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: KitMaterialesDetalles
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.KitMaterialesDetalles.Include(k => k.IdKitsCirugiasNavigation).Include(k => k.IdMaterialNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: KitMaterialesDetalles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitMaterialesDetalles == null)
            {
                return NotFound();
            }

            var kitMaterialesDetalle = await _context.KitMaterialesDetalles
                .Include(k => k.IdKitsCirugiasNavigation)
                .Include(k => k.IdMaterialNavigation)
                .FirstOrDefaultAsync(m => m.KitDetalleId == id);
            if (kitMaterialesDetalle == null)
            {
                return NotFound();
            }

            return View(kitMaterialesDetalle);
        }

        // GET: KitMaterialesDetalles/Create
        public IActionResult Create()
        {
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias");
            ViewData["IdMaterial"] = new SelectList(_context.MaterialesQuirurgicos, "IdMaterial", "IdMaterial");
            return View();
        }

        // POST: KitMaterialesDetalles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KitDetalleId,IdMaterial,IdKitsCirugias,Notas,Cantidad")] KitMaterialesDetalle kitMaterialesDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitMaterialesDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", kitMaterialesDetalle.IdKitsCirugias);
            ViewData["IdMaterial"] = new SelectList(_context.MaterialesQuirurgicos, "IdMaterial", "IdMaterial", kitMaterialesDetalle.IdMaterial);
            return View(kitMaterialesDetalle);
        }

        // GET: KitMaterialesDetalles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitMaterialesDetalles == null)
            {
                return NotFound();
            }

            var kitMaterialesDetalle = await _context.KitMaterialesDetalles.FindAsync(id);
            if (kitMaterialesDetalle == null)
            {
                return NotFound();
            }
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", kitMaterialesDetalle.IdKitsCirugias);
            ViewData["IdMaterial"] = new SelectList(_context.MaterialesQuirurgicos, "IdMaterial", "IdMaterial", kitMaterialesDetalle.IdMaterial);
            return View(kitMaterialesDetalle);
        }

        // POST: KitMaterialesDetalles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KitDetalleId,IdMaterial,IdKitsCirugias,Notas,Cantidad")] KitMaterialesDetalle kitMaterialesDetalle)
        {
            if (id != kitMaterialesDetalle.KitDetalleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitMaterialesDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitMaterialesDetalleExists(kitMaterialesDetalle.KitDetalleId))
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
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", kitMaterialesDetalle.IdKitsCirugias);
            ViewData["IdMaterial"] = new SelectList(_context.MaterialesQuirurgicos, "IdMaterial", "IdMaterial", kitMaterialesDetalle.IdMaterial);
            return View(kitMaterialesDetalle);
        }

        // GET: KitMaterialesDetalles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitMaterialesDetalles == null)
            {
                return NotFound();
            }

            var kitMaterialesDetalle = await _context.KitMaterialesDetalles
                .Include(k => k.IdKitsCirugiasNavigation)
                .Include(k => k.IdMaterialNavigation)
                .FirstOrDefaultAsync(m => m.KitDetalleId == id);
            if (kitMaterialesDetalle == null)
            {
                return NotFound();
            }

            return View(kitMaterialesDetalle);
        }

        // POST: KitMaterialesDetalles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitMaterialesDetalles == null)
            {
                return Problem("Entity set 'MeditrackContext.KitMaterialesDetalles'  is null.");
            }
            var kitMaterialesDetalle = await _context.KitMaterialesDetalles.FindAsync(id);
            if (kitMaterialesDetalle != null)
            {
                _context.KitMaterialesDetalles.Remove(kitMaterialesDetalle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitMaterialesDetalleExists(int id)
        {
          return (_context.KitMaterialesDetalles?.Any(e => e.KitDetalleId == id)).GetValueOrDefault();
        }
    }
}
