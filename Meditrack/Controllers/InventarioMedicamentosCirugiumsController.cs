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
    public class InventarioMedicamentosCirugiumsController : Controller
    {
        private readonly MeditrackContext _context;

        public InventarioMedicamentosCirugiumsController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: InventarioMedicamentosCirugiums
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.InventarioMedicamentosCirugia.Include(i => i.IdCirugiaNavigation).Include(i => i.IdKitsMedicamentosNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: InventarioMedicamentosCirugiums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InventarioMedicamentosCirugia == null)
            {
                return NotFound();
            }

            var inventarioMedicamentosCirugium = await _context.InventarioMedicamentosCirugia
                .Include(i => i.IdCirugiaNavigation)
                .Include(i => i.IdKitsMedicamentosNavigation)
                .FirstOrDefaultAsync(m => m.IdInventarioMedicamento == id);
            if (inventarioMedicamentosCirugium == null)
            {
                return NotFound();
            }

            return View(inventarioMedicamentosCirugium);
        }

        // GET: InventarioMedicamentosCirugiums/Create
        public IActionResult Create()
        {
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia");
            ViewData["IdKitsMedicamentos"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos");
            return View();
        }

        // POST: InventarioMedicamentosCirugiums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInventarioMedicamento,IdCirugia,CantidadUtilizadaMedicamentoCirugia,IdKitsMedicamentos")] InventarioMedicamentosCirugium inventarioMedicamentosCirugium)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventarioMedicamentosCirugium);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMedicamentosCirugium.IdCirugia);
            ViewData["IdKitsMedicamentos"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", inventarioMedicamentosCirugium.IdKitsMedicamentos);
            return View(inventarioMedicamentosCirugium);
        }

        // GET: InventarioMedicamentosCirugiums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InventarioMedicamentosCirugia == null)
            {
                return NotFound();
            }

            var inventarioMedicamentosCirugium = await _context.InventarioMedicamentosCirugia.FindAsync(id);
            if (inventarioMedicamentosCirugium == null)
            {
                return NotFound();
            }
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMedicamentosCirugium.IdCirugia);
            ViewData["IdKitsMedicamentos"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", inventarioMedicamentosCirugium.IdKitsMedicamentos);
            return View(inventarioMedicamentosCirugium);
        }

        // POST: InventarioMedicamentosCirugiums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdInventarioMedicamento,IdCirugia,CantidadUtilizadaMedicamentoCirugia,IdKitsMedicamentos")] InventarioMedicamentosCirugium inventarioMedicamentosCirugium)
        {
            if (id != inventarioMedicamentosCirugium.IdInventarioMedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventarioMedicamentosCirugium);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventarioMedicamentosCirugiumExists(inventarioMedicamentosCirugium.IdInventarioMedicamento))
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
            ViewData["IdCirugia"] = new SelectList(_context.CalendarioCirugias, "IdCirugia", "IdCirugia", inventarioMedicamentosCirugium.IdCirugia);
            ViewData["IdKitsMedicamentos"] = new SelectList(_context.KitsMedicamentos, "IdKitsMedicamentos", "IdKitsMedicamentos", inventarioMedicamentosCirugium.IdKitsMedicamentos);
            return View(inventarioMedicamentosCirugium);
        }

        // GET: InventarioMedicamentosCirugiums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InventarioMedicamentosCirugia == null)
            {
                return NotFound();
            }

            var inventarioMedicamentosCirugium = await _context.InventarioMedicamentosCirugia
                .Include(i => i.IdCirugiaNavigation)
                .Include(i => i.IdKitsMedicamentosNavigation)
                .FirstOrDefaultAsync(m => m.IdInventarioMedicamento == id);
            if (inventarioMedicamentosCirugium == null)
            {
                return NotFound();
            }

            return View(inventarioMedicamentosCirugium);
        }

        // POST: InventarioMedicamentosCirugiums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InventarioMedicamentosCirugia == null)
            {
                return Problem("Entity set 'MeditrackContext.InventarioMedicamentosCirugia'  is null.");
            }
            var inventarioMedicamentosCirugium = await _context.InventarioMedicamentosCirugia.FindAsync(id);
            if (inventarioMedicamentosCirugium != null)
            {
                _context.InventarioMedicamentosCirugia.Remove(inventarioMedicamentosCirugium);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventarioMedicamentosCirugiumExists(int id)
        {
          return (_context.InventarioMedicamentosCirugia?.Any(e => e.IdInventarioMedicamento == id)).GetValueOrDefault();
        }
    }
}
