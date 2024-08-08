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
    public class KitsMaterialesQuirurgicoesController : Controller
    {
        private readonly MeditrackContext _context;

        public KitsMaterialesQuirurgicoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: KitsMaterialesQuirurgicoes
        public async Task<IActionResult> Index()
        {
              return _context.KitsMaterialesQuirurgicos != null ? 
                          View(await _context.KitsMaterialesQuirurgicos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.KitsMaterialesQuirurgicos'  is null.");
        }

        // GET: KitsMaterialesQuirurgicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitsMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var kitsMaterialesQuirurgico = await _context.KitsMaterialesQuirurgicos
                .FirstOrDefaultAsync(m => m.IdKitsCirugias == id);
            if (kitsMaterialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(kitsMaterialesQuirurgico);
        }

        // GET: KitsMaterialesQuirurgicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KitsMaterialesQuirurgicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKitsCirugias,NombreKit,Descripcion,CantidadKits")] KitsMaterialesQuirurgico kitsMaterialesQuirurgico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitsMaterialesQuirurgico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kitsMaterialesQuirurgico);
        }

        // GET: KitsMaterialesQuirurgicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitsMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var kitsMaterialesQuirurgico = await _context.KitsMaterialesQuirurgicos.FindAsync(id);
            if (kitsMaterialesQuirurgico == null)
            {
                return NotFound();
            }
            return View(kitsMaterialesQuirurgico);
        }

        // POST: KitsMaterialesQuirurgicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKitsCirugias,NombreKit,Descripcion,CantidadKits")] KitsMaterialesQuirurgico kitsMaterialesQuirurgico)
        {
            if (id != kitsMaterialesQuirurgico.IdKitsCirugias)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitsMaterialesQuirurgico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitsMaterialesQuirurgicoExists(kitsMaterialesQuirurgico.IdKitsCirugias))
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
            return View(kitsMaterialesQuirurgico);
        }

        // GET: KitsMaterialesQuirurgicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitsMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var kitsMaterialesQuirurgico = await _context.KitsMaterialesQuirurgicos
                .FirstOrDefaultAsync(m => m.IdKitsCirugias == id);
            if (kitsMaterialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(kitsMaterialesQuirurgico);
        }

        // POST: KitsMaterialesQuirurgicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitsMaterialesQuirurgicos == null)
            {
                return Problem("Entity set 'MeditrackContext.KitsMaterialesQuirurgicos'  is null.");
            }
            var kitsMaterialesQuirurgico = await _context.KitsMaterialesQuirurgicos.FindAsync(id);
            if (kitsMaterialesQuirurgico != null)
            {
                _context.KitsMaterialesQuirurgicos.Remove(kitsMaterialesQuirurgico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitsMaterialesQuirurgicoExists(int id)
        {
          return (_context.KitsMaterialesQuirurgicos?.Any(e => e.IdKitsCirugias == id)).GetValueOrDefault();
        }
    }
}
