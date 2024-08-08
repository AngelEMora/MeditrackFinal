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
    public class DistribuidorsController : Controller
    {
        private readonly MeditrackContext _context;

        public DistribuidorsController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Distribuidors
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.Distribuidors.Include(d => d.IdCasaComercialNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: Distribuidors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Distribuidors == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidors
                .Include(d => d.IdCasaComercialNavigation)
                .FirstOrDefaultAsync(m => m.IdDistribuidor == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // GET: Distribuidors/Create
        public IActionResult Create()
        {
            ViewData["IdCasaComercial"] = new SelectList(_context.CasaComercials, "IdCasaComercial", "IdCasaComercial");
            return View();
        }

        // POST: Distribuidors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDistribuidor,NombreDistribuidor,DireccionDistribuidor,TelefonoDistribuidor,Correo,TipoDistribuidor,IdCasaComercial")] Distribuidor distribuidor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(distribuidor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCasaComercial"] = new SelectList(_context.CasaComercials, "IdCasaComercial", "IdCasaComercial", distribuidor.IdCasaComercial);
            return View(distribuidor);
        }

        // GET: Distribuidors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Distribuidors == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidors.FindAsync(id);
            if (distribuidor == null)
            {
                return NotFound();
            }
            ViewData["IdCasaComercial"] = new SelectList(_context.CasaComercials, "IdCasaComercial", "IdCasaComercial", distribuidor.IdCasaComercial);
            return View(distribuidor);
        }

        // POST: Distribuidors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDistribuidor,NombreDistribuidor,DireccionDistribuidor,TelefonoDistribuidor,Correo,TipoDistribuidor,IdCasaComercial")] Distribuidor distribuidor)
        {
            if (id != distribuidor.IdDistribuidor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(distribuidor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DistribuidorExists(distribuidor.IdDistribuidor))
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
            ViewData["IdCasaComercial"] = new SelectList(_context.CasaComercials, "IdCasaComercial", "IdCasaComercial", distribuidor.IdCasaComercial);
            return View(distribuidor);
        }

        // GET: Distribuidors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Distribuidors == null)
            {
                return NotFound();
            }

            var distribuidor = await _context.Distribuidors
                .Include(d => d.IdCasaComercialNavigation)
                .FirstOrDefaultAsync(m => m.IdDistribuidor == id);
            if (distribuidor == null)
            {
                return NotFound();
            }

            return View(distribuidor);
        }

        // POST: Distribuidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Distribuidors == null)
            {
                return Problem("Entity set 'MeditrackContext.Distribuidors'  is null.");
            }
            var distribuidor = await _context.Distribuidors.FindAsync(id);
            if (distribuidor != null)
            {
                _context.Distribuidors.Remove(distribuidor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DistribuidorExists(int id)
        {
          return (_context.Distribuidors?.Any(e => e.IdDistribuidor == id)).GetValueOrDefault();
        }
    }
}
