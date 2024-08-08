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
    public class MedicamentoesController : Controller
    {
        private readonly MeditrackContext _context;

        public MedicamentoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Medicamentoes
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.Medicamentos.Include(m => m.IdMovimientoNavigation).Include(m => m.IdTipoMedicamentoNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: Medicamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IdMovimientoNavigation)
                .Include(m => m.IdTipoMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdMedicamento == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // GET: Medicamentoes/Create
        public IActionResult Create()
        {
            ViewData["IdMovimiento"] = new SelectList(_context.MovimientoInventarios, "IdMovimiento", "IdMovimiento");
            ViewData["IdTipoMedicamento"] = new SelectList(_context.TiposdeMedicamentos, "IdTipoMedicamento", "IdTipoMedicamento");
            return View();
        }

        // POST: Medicamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedicamento,NombreMedicamento,IdTipoMedicamento,CantidadDisponibleMedicamentos,IdMovimiento,FechaVencimiento,Distribuidor,PuntosReorden,Lote,FechaFabricacion")] Medicamento medicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMovimiento"] = new SelectList(_context.MovimientoInventarios, "IdMovimiento", "IdMovimiento", medicamento.IdMovimiento);
            ViewData["IdTipoMedicamento"] = new SelectList(_context.TiposdeMedicamentos, "IdTipoMedicamento", "IdTipoMedicamento", medicamento.IdTipoMedicamento);
            return View(medicamento);
        }

        // GET: Medicamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento == null)
            {
                return NotFound();
            }
            ViewData["IdMovimiento"] = new SelectList(_context.MovimientoInventarios, "IdMovimiento", "IdMovimiento", medicamento.IdMovimiento);
            ViewData["IdTipoMedicamento"] = new SelectList(_context.TiposdeMedicamentos, "IdTipoMedicamento", "IdTipoMedicamento", medicamento.IdTipoMedicamento);
            return View(medicamento);
        }

        // POST: Medicamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedicamento,NombreMedicamento,IdTipoMedicamento,CantidadDisponibleMedicamentos,IdMovimiento,FechaVencimiento,Distribuidor,PuntosReorden,Lote,FechaFabricacion")] Medicamento medicamento)
        {
            if (id != medicamento.IdMedicamento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicamentoExists(medicamento.IdMedicamento))
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
            ViewData["IdMovimiento"] = new SelectList(_context.MovimientoInventarios, "IdMovimiento", "IdMovimiento", medicamento.IdMovimiento);
            ViewData["IdTipoMedicamento"] = new SelectList(_context.TiposdeMedicamentos, "IdTipoMedicamento", "IdTipoMedicamento", medicamento.IdTipoMedicamento);
            return View(medicamento);
        }

        // GET: Medicamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Medicamentos == null)
            {
                return NotFound();
            }

            var medicamento = await _context.Medicamentos
                .Include(m => m.IdMovimientoNavigation)
                .Include(m => m.IdTipoMedicamentoNavigation)
                .FirstOrDefaultAsync(m => m.IdMedicamento == id);
            if (medicamento == null)
            {
                return NotFound();
            }

            return View(medicamento);
        }

        // POST: Medicamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Medicamentos == null)
            {
                return Problem("Entity set 'MeditrackContext.Medicamentos'  is null.");
            }
            var medicamento = await _context.Medicamentos.FindAsync(id);
            if (medicamento != null)
            {
                _context.Medicamentos.Remove(medicamento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MedicamentoExists(int id)
        {
          return (_context.Medicamentos?.Any(e => e.IdMedicamento == id)).GetValueOrDefault();
        }
    }
}
