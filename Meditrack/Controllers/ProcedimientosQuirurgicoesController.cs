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
    public class ProcedimientosQuirurgicoesController : Controller
    {
        private readonly MeditrackContext _context;

        public ProcedimientosQuirurgicoesController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: ProcedimientosQuirurgicoes
        public async Task<IActionResult> Index()
        {
              return _context.ProcedimientosQuirurgicos != null ? 
                          View(await _context.ProcedimientosQuirurgicos.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.ProcedimientosQuirurgicos'  is null.");
        }

        // GET: ProcedimientosQuirurgicoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.ProcedimientosQuirurgicos == null)
            {
                return NotFound();
            }

            var procedimientosQuirurgico = await _context.ProcedimientosQuirurgicos
                .FirstOrDefaultAsync(m => m.IdProcedimiento == id);
            if (procedimientosQuirurgico == null)
            {
                return NotFound();
            }

            return View(procedimientosQuirurgico);
        }

        // GET: ProcedimientosQuirurgicoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcedimientosQuirurgicoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProcedimiento,NombreProcedimiento,Descripcion,RiesgosComplicaciones,DuracionEstimada")] ProcedimientosQuirurgico procedimientosQuirurgico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(procedimientosQuirurgico);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(procedimientosQuirurgico);
        }

        // GET: ProcedimientosQuirurgicoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.ProcedimientosQuirurgicos == null)
            {
                return NotFound();
            }

            var procedimientosQuirurgico = await _context.ProcedimientosQuirurgicos.FindAsync(id);
            if (procedimientosQuirurgico == null)
            {
                return NotFound();
            }
            return View(procedimientosQuirurgico);
        }

        // POST: ProcedimientosQuirurgicoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProcedimiento,NombreProcedimiento,Descripcion,RiesgosComplicaciones,DuracionEstimada")] ProcedimientosQuirurgico procedimientosQuirurgico)
        {
            if (id != procedimientosQuirurgico.IdProcedimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(procedimientosQuirurgico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcedimientosQuirurgicoExists(procedimientosQuirurgico.IdProcedimiento))
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
            return View(procedimientosQuirurgico);
        }

        // GET: ProcedimientosQuirurgicoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.ProcedimientosQuirurgicos == null)
            {
                return NotFound();
            }

            var procedimientosQuirurgico = await _context.ProcedimientosQuirurgicos
                .FirstOrDefaultAsync(m => m.IdProcedimiento == id);
            if (procedimientosQuirurgico == null)
            {
                return NotFound();
            }

            return View(procedimientosQuirurgico);
        }

        // POST: ProcedimientosQuirurgicoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.ProcedimientosQuirurgicos == null)
            {
                return Problem("Entity set 'MeditrackContext.ProcedimientosQuirurgicos'  is null.");
            }
            var procedimientosQuirurgico = await _context.ProcedimientosQuirurgicos.FindAsync(id);
            if (procedimientosQuirurgico != null)
            {
                _context.ProcedimientosQuirurgicos.Remove(procedimientosQuirurgico);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcedimientosQuirurgicoExists(int id)
        {
          return (_context.ProcedimientosQuirurgicos?.Any(e => e.IdProcedimiento == id)).GetValueOrDefault();
        }
    }
}
