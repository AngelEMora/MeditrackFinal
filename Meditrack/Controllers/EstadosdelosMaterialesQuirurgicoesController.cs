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
    public class EstadosdelosMaterialesQuirurgicoesController : Controller
    {
        private readonly MeditrackContext _context;

        public EstadosdelosMaterialesQuirurgicoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: EstadosdelosMaterialesQuirurgicoes
        public async Task<IActionResult> Index()
        {
              return _context.EstadosdelosMaterialesQuirurgicos != null ? 
                          View(await _context.EstadosdelosMaterialesQuirurgicos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.EstadosdelosMaterialesQuirurgicos'  is null.");
        }

        // GET: EstadosdelosMaterialesQuirurgicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadosdelosMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var estadosdelosMaterialesQuirurgico = await _context.EstadosdelosMaterialesQuirurgicos
                .FirstOrDefaultAsync(m => m.IdEstadoMaterialQuirurico == id);
            if (estadosdelosMaterialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(estadosdelosMaterialesQuirurgico);
        }

        // GET: EstadosdelosMaterialesQuirurgicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadosdelosMaterialesQuirurgicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoMaterialQuirurico,NombreEstadoMaterialQuirurgico")] EstadosdelosMaterialesQuirurgico estadosdelosMaterialesQuirurgico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadosdelosMaterialesQuirurgico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadosdelosMaterialesQuirurgico);
        }

        // GET: EstadosdelosMaterialesQuirurgicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadosdelosMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var estadosdelosMaterialesQuirurgico = await _context.EstadosdelosMaterialesQuirurgicos.FindAsync(id);
            if (estadosdelosMaterialesQuirurgico == null)
            {
                return NotFound();
            }
            return View(estadosdelosMaterialesQuirurgico);
        }

        // POST: EstadosdelosMaterialesQuirurgicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoMaterialQuirurico,NombreEstadoMaterialQuirurgico")] EstadosdelosMaterialesQuirurgico estadosdelosMaterialesQuirurgico)
        {
            if (id != estadosdelosMaterialesQuirurgico.IdEstadoMaterialQuirurico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadosdelosMaterialesQuirurgico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadosdelosMaterialesQuirurgicoExists(estadosdelosMaterialesQuirurgico.IdEstadoMaterialQuirurico))
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
            return View(estadosdelosMaterialesQuirurgico);
        }

        // GET: EstadosdelosMaterialesQuirurgicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadosdelosMaterialesQuirurgicos == null)
            {
                return NotFound();
            }

            var estadosdelosMaterialesQuirurgico = await _context.EstadosdelosMaterialesQuirurgicos
                .FirstOrDefaultAsync(m => m.IdEstadoMaterialQuirurico == id);
            if (estadosdelosMaterialesQuirurgico == null)
            {
                return NotFound();
            }

            return View(estadosdelosMaterialesQuirurgico);
        }

        // POST: EstadosdelosMaterialesQuirurgicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadosdelosMaterialesQuirurgicos == null)
            {
                return Problem("Entity set 'MeditrackContext.EstadosdelosMaterialesQuirurgicos'  is null.");
            }
            var estadosdelosMaterialesQuirurgico = await _context.EstadosdelosMaterialesQuirurgicos.FindAsync(id);
            if (estadosdelosMaterialesQuirurgico != null)
            {
                _context.EstadosdelosMaterialesQuirurgicos.Remove(estadosdelosMaterialesQuirurgico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadosdelosMaterialesQuirurgicoExists(int id)
        {
          return (_context.EstadosdelosMaterialesQuirurgicos?.Any(e => e.IdEstadoMaterialQuirurico == id)).GetValueOrDefault();
        }
    }
}
