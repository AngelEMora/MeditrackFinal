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
    public class InventarioMaterialesCirugiumsController : Controller
    {
        private readonly MeditrackContext _context;

        public InventarioMaterialesCirugiumsController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: InventarioMaterialesCirugiums
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.InventarioMaterialesCirugia.Include(i => i.IdCirugiaNavigation).Include(i => i.IdKitsCirugiasNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: InventarioMaterialesCirugiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioMaterialesCirugia == null)
            {
                return NotFound();
            }

            var inventarioMaterialesCirugium = await _context.InventarioMaterialesCirugia
                .Include(i => i.IdCirugiaNavigation)
                .Include(i => i.IdKitsCirugiasNavigation)
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventarioMaterialesCirugium == null)
            {
                return NotFound();
            }

            return View(inventarioMaterialesCirugium);
        }

        // GET: InventarioMaterialesCirugiums/Create
        public IActionResult Create()
        {
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia");
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias");
            return View();
        }

        // POST: InventarioMaterialesCirugiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInventario,IdCirugia,CantidadUtilizadaMaterialCirugia,IdKitsCirugias")] InventarioMaterialesCirugium inventarioMaterialesCirugium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioMaterialesCirugium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMaterialesCirugium.IdCirugia);
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", inventarioMaterialesCirugium.IdKitsCirugias);
            return View(inventarioMaterialesCirugium);
        }

        // GET: InventarioMaterialesCirugiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioMaterialesCirugia == null)
            {
                return NotFound();
            }

            var inventarioMaterialesCirugium = await _context.InventarioMaterialesCirugia.FindAsync(id);
            if (inventarioMaterialesCirugium == null)
            {
                return NotFound();
            }
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMaterialesCirugium.IdCirugia);
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", inventarioMaterialesCirugium.IdKitsCirugias);
            return View(inventarioMaterialesCirugium);
        }

        // POST: InventarioMaterialesCirugiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInventario,IdCirugia,CantidadUtilizadaMaterialCirugia,IdKitsCirugias")] InventarioMaterialesCirugium inventarioMaterialesCirugium)
        {
            if (id != inventarioMaterialesCirugium.IdInventario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioMaterialesCirugium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioMaterialesCirugiumExists(inventarioMaterialesCirugium.IdInventario))
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
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMaterialesCirugium.IdCirugia);
            ViewData["IdKitsCirugias"] = new SelectList(_context.KitsMaterialesQuirurgicos, "IdKitsCirugias", "IdKitsCirugias", inventarioMaterialesCirugium.IdKitsCirugias);
            return View(inventarioMaterialesCirugium);
        }

        // GET: InventarioMaterialesCirugiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioMaterialesCirugia == null)
            {
                return NotFound();
            }

            var inventarioMaterialesCirugium = await _context.InventarioMaterialesCirugia
                .Include(i => i.IdCirugiaNavigation)
                .Include(i => i.IdKitsCirugiasNavigation)
                .FirstOrDefaultAsync(m => m.IdInventario == id);
            if (inventarioMaterialesCirugium == null)
            {
                return NotFound();
            }

            return View(inventarioMaterialesCirugium);
        }

        // POST: InventarioMaterialesCirugiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioMaterialesCirugia == null)
            {
                return Problem("Entity set 'MeditrackContext.InventarioMaterialesCirugia'  is null.");
            }
            var inventarioMaterialesCirugium = await _context.InventarioMaterialesCirugia.FindAsync(id);
            if (inventarioMaterialesCirugium != null)
            {
                _context.InventarioMaterialesCirugia.Remove(inventarioMaterialesCirugium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioMaterialesCirugiumExists(int id)
        {
          return (_context.InventarioMaterialesCirugia?.Any(e => e.IdInventario == id)).GetValueOrDefault();
        }
    }
}
