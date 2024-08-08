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
    public class TiposdeMedicamentoesController : Controller
    {
        private readonly MeditrackContext _context;

        public TiposdeMedicamentoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: TiposdeMedicamentoes
        public async Task<IActionResult> Index()
        {
              return _context.TiposdeMedicamentos != null ? 
                          View(await _context.TiposdeMedicamentos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.TiposdeMedicamentos'  is null.");
        }

        // GET: TiposdeMedicamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TiposdeMedicamentos == null)
            {
                return NotFound();
            }

            var tiposdeMedicamento = await _context.TiposdeMedicamentos
                .FirstOrDefaultAsync(m => m.IdTipoMedicamento == id);
            if (tiposdeMedicamento == null)
            {
                return NotFound();
            }

            return View(tiposdeMedicamento);
        }

        // GET: TiposdeMedicamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TiposdeMedicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipoMedicamento,NombreTipoMedicamento,DescripcionTipoMedicamento,Restricciones")] TiposdeMedicamento tiposdeMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tiposdeMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tiposdeMedicamento);
        }

        // GET: TiposdeMedicamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TiposdeMedicamentos == null)
            {
                return NotFound();
            }

            var tiposdeMedicamento = await _context.TiposdeMedicamentos.FindAsync(id);
            if (tiposdeMedicamento == null)
            {
                return NotFound();
            }
            return View(tiposdeMedicamento);
        }

        // POST: TiposdeMedicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipoMedicamento,NombreTipoMedicamento,DescripcionTipoMedicamento,Restricciones")] TiposdeMedicamento tiposdeMedicamento)
        {
            if (id != tiposdeMedicamento.IdTipoMedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tiposdeMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiposdeMedicamentoExists(tiposdeMedicamento.IdTipoMedicamento))
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
            return View(tiposdeMedicamento);
        }

        // GET: TiposdeMedicamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TiposdeMedicamentos == null)
            {
                return NotFound();
            }

            var tiposdeMedicamento = await _context.TiposdeMedicamentos
                .FirstOrDefaultAsync(m => m.IdTipoMedicamento == id);
            if (tiposdeMedicamento == null)
            {
                return NotFound();
            }

            return View(tiposdeMedicamento);
        }

        // POST: TiposdeMedicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TiposdeMedicamentos == null)
            {
                return Problem("Entity set 'MeditrackContext.TiposdeMedicamentos'  is null.");
            }
            var tiposdeMedicamento = await _context.TiposdeMedicamentos.FindAsync(id);
            if (tiposdeMedicamento != null)
            {
                _context.TiposdeMedicamentos.Remove(tiposdeMedicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiposdeMedicamentoExists(int id)
        {
          return (_context.TiposdeMedicamentos?.Any(e => e.IdTipoMedicamento == id)).GetValueOrDefault();
        }
    }
}
