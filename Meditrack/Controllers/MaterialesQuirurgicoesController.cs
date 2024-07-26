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
    public class MaterialesQuirurgicoesController : Controller
    {
        private readonly MeditrackContext _context;

        public MaterialesQuirurgicoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: MaterialesQuirurgicoes
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.MaterialesQuirurgicos.Include(m => m.IdTipoMaterialQuirurgicoNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: MaterialesQuirurgicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var materialesQuirurgico = await _context.MaterialesQuirurgicos
                .Include(m => m.IdTipoMaterialQuirurgicoNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (materialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(materialesQuirurgico);
        }

        // GET: MaterialesQuirurgicoes/Create
        public IActionResult Create()
        {
            ViewData["IdTipoMaterialQuirurgico"] = new SelectList(_context.TipodeMaterialQuirurgicos, "IdTipoMaterialQuirurgico", "IdTipoMaterialQuirurgico");
            return View();
        }

        // POST: MaterialesQuirurgicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMaterial,NombreMaterial,Descripcion,Movimiento,CantidadDisponibleMaterialQuirurgico,IdTipoMaterialQuirurgico")] MaterialesQuirurgico materialesQuirurgico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialesQuirurgico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdTipoMaterialQuirurgico"] = new SelectList(_context.TipodeMaterialQuirurgicos, "IdTipoMaterialQuirurgico", "IdTipoMaterialQuirurgico", materialesQuirurgico.IdTipoMaterialQuirurgico);
            return View(materialesQuirurgico);
        }

        // GET: MaterialesQuirurgicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var materialesQuirurgico = await _context.MaterialesQuirurgicos.FindAsync(id);
            if (materialesQuirurgico == null)
            {
                return NotFound();
            }
            ViewData["IdTipoMaterialQuirurgico"] = new SelectList(_context.TipodeMaterialQuirurgicos, "IdTipoMaterialQuirurgico", "IdTipoMaterialQuirurgico", materialesQuirurgico.IdTipoMaterialQuirurgico);
            return View(materialesQuirurgico);
        }

        // POST: MaterialesQuirurgicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMaterial,NombreMaterial,Descripcion,Movimiento,CantidadDisponibleMaterialQuirurgico,IdTipoMaterialQuirurgico")] MaterialesQuirurgico materialesQuirurgico)
        {
            if (id != materialesQuirurgico.IdMaterial)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialesQuirurgico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialesQuirurgicoExists(materialesQuirurgico.IdMaterial))
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
            ViewData["IdTipoMaterialQuirurgico"] = new SelectList(_context.TipodeMaterialQuirurgicos, "IdTipoMaterialQuirurgico", "IdTipoMaterialQuirurgico", materialesQuirurgico.IdTipoMaterialQuirurgico);
            return View(materialesQuirurgico);
        }

        // GET: MaterialesQuirurgicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var materialesQuirurgico = await _context.MaterialesQuirurgicos
                .Include(m => m.IdTipoMaterialQuirurgicoNavigation)
                .FirstOrDefaultAsync(m => m.IdMaterial == id);
            if (materialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(materialesQuirurgico);
        }

        // POST: MaterialesQuirurgicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MaterialesQuirurgicos == null)
            {
                return Problem("Entity set 'MeditrackContext.MaterialesQuirurgicos'  is null.");
            }
            var materialesQuirurgico = await _context.MaterialesQuirurgicos.FindAsync(id);
            if (materialesQuirurgico != null)
            {
                _context.MaterialesQuirurgicos.Remove(materialesQuirurgico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialesQuirurgicoExists(int id)
        {
          return (_context.MaterialesQuirurgicos?.Any(e => e.IdMaterial == id)).GetValueOrDefault();
        }
    }
}
