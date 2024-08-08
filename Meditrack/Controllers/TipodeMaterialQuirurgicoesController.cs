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
    public class TipodeMaterialQuirurgicoesController : Controller
    {
        private readonly MeditrackContext _context;

        public TipodeMaterialQuirurgicoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: TipodeMaterialQuirurgicoes
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.TipodeMaterialQuirurgicos.Include(t => t.EstadoMaterialNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: TipodeMaterialQuirurgicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TipodeMaterialQuirurgicos == null)
            {
                return NotFound();
            }

            var tipodeMaterialQuirurgico = await _context.TipodeMaterialQuirurgicos
                .Include(t => t.EstadoMaterialNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoMaterialQuirurgico == id);
            if (tipodeMaterialQuirurgico == null)
            {
                return NotFound();
            }

            return View(tipodeMaterialQuirurgico);
        }

        // GET: TipodeMaterialQuirurgicoes/Create
        public IActionResult Create()
        {
            ViewData["EstadoMaterial"] = new SelectList(_context.EstadosdelosMaterialesQuirurgicos, "IdEstadoMaterialQuirurico", "IdEstadoMaterialQuirurico");
            return View();
        }

        // POST: TipodeMaterialQuirurgicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMaterialQuirurgico,NombreTipoMaterialQuirurgico,DescripcionTipoMaterialQuirurgico,EstadoMaterial")] TipodeMaterialQuirurgico tipodeMaterialQuirurgico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipodeMaterialQuirurgico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EstadoMaterial"] = new SelectList(_context.EstadosdelosMaterialesQuirurgicos, "IdEstadoMaterialQuirurico", "IdEstadoMaterialQuirurico", tipodeMaterialQuirurgico.EstadoMaterial);
            return View(tipodeMaterialQuirurgico);
        }

        // GET: TipodeMaterialQuirurgicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TipodeMaterialQuirurgicos == null)
            {
                return NotFound();
            }

            var tipodeMaterialQuirurgico = await _context.TipodeMaterialQuirurgicos.FindAsync(id);
            if (tipodeMaterialQuirurgico == null)
            {
                return NotFound();
            }
            ViewData["EstadoMaterial"] = new SelectList(_context.EstadosdelosMaterialesQuirurgicos, "IdEstadoMaterialQuirurico", "IdEstadoMaterialQuirurico", tipodeMaterialQuirurgico.EstadoMaterial);
            return View(tipodeMaterialQuirurgico);
        }

        // POST: TipodeMaterialQuirurgicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMaterialQuirurgico,NombreTipoMaterialQuirurgico,DescripcionTipoMaterialQuirurgico,EstadoMaterial")] TipodeMaterialQuirurgico tipodeMaterialQuirurgico)
        {
            if (id != tipodeMaterialQuirurgico.IdTipoMaterialQuirurgico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipodeMaterialQuirurgico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipodeMaterialQuirurgicoExists(tipodeMaterialQuirurgico.IdTipoMaterialQuirurgico))
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
            ViewData["EstadoMaterial"] = new SelectList(_context.EstadosdelosMaterialesQuirurgicos, "IdEstadoMaterialQuirurico", "IdEstadoMaterialQuirurico", tipodeMaterialQuirurgico.EstadoMaterial);
            return View(tipodeMaterialQuirurgico);
        }

        // GET: TipodeMaterialQuirurgicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TipodeMaterialQuirurgicos == null)
            {
                return NotFound();
            }

            var tipodeMaterialQuirurgico = await _context.TipodeMaterialQuirurgicos
                .Include(t => t.EstadoMaterialNavigation)
                .FirstOrDefaultAsync(m => m.IdTipoMaterialQuirurgico == id);
            if (tipodeMaterialQuirurgico == null)
            {
                return NotFound();
            }

            return View(tipodeMaterialQuirurgico);
        }

        // POST: TipodeMaterialQuirurgicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TipodeMaterialQuirurgicos == null)
            {
                return Problem("Entity set 'MeditrackContext.TipodeMaterialQuirurgicos'  is null.");
            }
            var tipodeMaterialQuirurgico = await _context.TipodeMaterialQuirurgicos.FindAsync(id);
            if (tipodeMaterialQuirurgico != null)
            {
                _context.TipodeMaterialQuirurgicos.Remove(tipodeMaterialQuirurgico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipodeMaterialQuirurgicoExists(int id)
        {
          return (_context.TipodeMaterialQuirurgicos?.Any(e => e.IdTipoMaterialQuirurgico == id)).GetValueOrDefault();
        }
    }
}
