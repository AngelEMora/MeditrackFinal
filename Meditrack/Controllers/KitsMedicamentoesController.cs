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
    public class KitsMedicamentoesController : Controller
    {
        private readonly MeditrackContext _context;

        public KitsMedicamentoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: KitsMedicamentoes
        public async Task<IActionResult> Index()
        {
              return _context.KitsMedicamentos != null ? 
                          View(await _context.KitsMedicamentos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.KitsMedicamentos'  is null.");
        }

        // GET: KitsMedicamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KitsMedicamentos == null)
            {
                return NotFound();
            }

            var kitsMedicamento = await _context.KitsMedicamentos
                .FirstOrDefaultAsync(m => m.IdKitsMedicamentos == id);
            if (kitsMedicamento == null)
            {
                return NotFound();
            }

            return View(kitsMedicamento);
        }

        // GET: KitsMedicamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KitsMedicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdKitsMedicamentos,NombreKit,Descripcion,CantidadKits")] KitsMedicamento kitsMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kitsMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kitsMedicamento);
        }

        // GET: KitsMedicamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KitsMedicamentos == null)
            {
                return NotFound();
            }

            var kitsMedicamento = await _context.KitsMedicamentos.FindAsync(id);
            if (kitsMedicamento == null)
            {
                return NotFound();
            }
            return View(kitsMedicamento);
        }

        // POST: KitsMedicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdKitsMedicamentos,NombreKit,Descripcion,CantidadKits")] KitsMedicamento kitsMedicamento)
        {
            if (id != kitsMedicamento.IdKitsMedicamentos)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kitsMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KitsMedicamentoExists(kitsMedicamento.IdKitsMedicamentos))
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
            return View(kitsMedicamento);
        }

        // GET: KitsMedicamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KitsMedicamentos == null)
            {
                return NotFound();
            }

            var kitsMedicamento = await _context.KitsMedicamentos
                .FirstOrDefaultAsync(m => m.IdKitsMedicamentos == id);
            if (kitsMedicamento == null)
            {
                return NotFound();
            }

            return View(kitsMedicamento);
        }

        // POST: KitsMedicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KitsMedicamentos == null)
            {
                return Problem("Entity set 'MeditrackContext.KitsMedicamentos'  is null.");
            }
            var kitsMedicamento = await _context.KitsMedicamentos.FindAsync(id);
            if (kitsMedicamento != null)
            {
                _context.KitsMedicamentos.Remove(kitsMedicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KitsMedicamentoExists(int id)
        {
          return (_context.KitsMedicamentos?.Any(e => e.IdKitsMedicamentos == id)).GetValueOrDefault();
        }
    }
}
