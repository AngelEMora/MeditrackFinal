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
    public class CasaComercialsController : Controller
    {
        private readonly MeditrackContext _context;

        public CasaComercialsController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: CasaComercials
        public async Task<IActionResult> Index()
        {
              return _context.CasaComercials != null ? 
                          View(await _context.CasaComercials.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.CasaComercials'  is null.");
        }

        // GET: CasaComercials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CasaComercials == null)
            {
                return NotFound();
            }

            var casaComercial = await _context.CasaComercials
                .FirstOrDefaultAsync(m => m.IdCasaComercial == id);
            if (casaComercial == null)
            {
                return NotFound();
            }

            return View(casaComercial);
        }

        // GET: CasaComercials/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CasaComercials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCasaComercial,NombreCasaComercial,DireccionCasaComercial,TelefonoCasaComercial,CorreoCasaComercial,WebCasaComercial")] CasaComercial casaComercial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casaComercial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casaComercial);
        }

        // GET: CasaComercials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CasaComercials == null)
            {
                return NotFound();
            }

            var casaComercial = await _context.CasaComercials.FindAsync(id);
            if (casaComercial == null)
            {
                return NotFound();
            }
            return View(casaComercial);
        }

        // POST: CasaComercials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCasaComercial,NombreCasaComercial,DireccionCasaComercial,TelefonoCasaComercial,CorreoCasaComercial,WebCasaComercial")] CasaComercial casaComercial)
        {
            if (id != casaComercial.IdCasaComercial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casaComercial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaComercialExists(casaComercial.IdCasaComercial))
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
            return View(casaComercial);
        }

        // GET: CasaComercials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CasaComercials == null)
            {
                return NotFound();
            }

            var casaComercial = await _context.CasaComercials
                .FirstOrDefaultAsync(m => m.IdCasaComercial == id);
            if (casaComercial == null)
            {
                return NotFound();
            }

            return View(casaComercial);
        }

        // POST: CasaComercials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CasaComercials == null)
            {
                return Problem("Entity set 'MeditrackContext.CasaComercials'  is null.");
            }
            var casaComercial = await _context.CasaComercials.FindAsync(id);
            if (casaComercial != null)
            {
                _context.CasaComercials.Remove(casaComercial);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaComercialExists(int id)
        {
          return (_context.CasaComercials?.Any(e => e.IdCasaComercial == id)).GetValueOrDefault();
        }
    }
}
