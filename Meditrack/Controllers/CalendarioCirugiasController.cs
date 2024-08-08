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
    public class CalendarioCirugiasController : Controller
    {
        private readonly MeditrackContext _context;

        public CalendarioCirugiasController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: CalendarioCirugias
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.CalendarioCirugias.Include(c => c.IdDoctorNavigation).Include(c => c.IdEstadoCirugiasNavigation).Include(c => c.IdPacienteNavigation).Include(c => c.IdProcedimientoNavigation).Include(c => c.IdQuirofanoNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: CalendarioCirugias/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CalendarioCirugias == null)
            {
                return NotFound();
            }

            var calendarioCirugia = await _context.CalendarioCirugias
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdEstadoCirugiasNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdProcedimientoNavigation)
                .Include(c => c.IdQuirofanoNavigation)
                .FirstOrDefaultAsync(m => m.IdCirugia == id);
            if (calendarioCirugia == null)
            {
                return NotFound();
            }

            return View(calendarioCirugia);
        }

        // GET: CalendarioCirugias/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor");
            ViewData["IdEstadoCirugias"] = new SelectList(_context.EstadosCirugias, "IdEstadoCirugias", "IdEstadoCirugias");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente");
            ViewData["IdProcedimiento"] = new SelectList(_context.ProcedimientosQuirurgicos, "IdProcedimiento", "IdProcedimiento");
            ViewData["IdQuirofano"] = new SelectList(_context.Quirofanos, "IdQuirofano", "IdQuirofano");
            return View();
        }

        // POST: CalendarioCirugias/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCirugia,IdPaciente,IdProcedimiento,IdDoctor,IdQuirofano,FechaHoraCirugia,IdEstadoCirugias,Observaciones")] CalendarioCirugia calendarioCirugia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calendarioCirugia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", calendarioCirugia.IdDoctor);
            ViewData["IdEstadoCirugias"] = new SelectList(_context.EstadosCirugias, "IdEstadoCirugias", "IdEstadoCirugias", calendarioCirugia.IdEstadoCirugias);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", calendarioCirugia.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.ProcedimientosQuirurgicos, "IdProcedimiento", "IdProcedimiento", calendarioCirugia.IdProcedimiento);
            ViewData["IdQuirofano"] = new SelectList(_context.Quirofanos, "IdQuirofano", "IdQuirofano", calendarioCirugia.IdQuirofano);
            return View(calendarioCirugia);
        }

        // GET: CalendarioCirugias/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CalendarioCirugias == null)
            {
                return NotFound();
            }

            var calendarioCirugia = await _context.CalendarioCirugias.FindAsync(id);
            if (calendarioCirugia == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", calendarioCirugia.IdDoctor);
            ViewData["IdEstadoCirugias"] = new SelectList(_context.EstadosCirugias, "IdEstadoCirugias", "IdEstadoCirugias", calendarioCirugia.IdEstadoCirugias);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", calendarioCirugia.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.ProcedimientosQuirurgicos, "IdProcedimiento", "IdProcedimiento", calendarioCirugia.IdProcedimiento);
            ViewData["IdQuirofano"] = new SelectList(_context.Quirofanos, "IdQuirofano", "IdQuirofano", calendarioCirugia.IdQuirofano);
            return View(calendarioCirugia);
        }

        // POST: CalendarioCirugias/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCirugia,IdPaciente,IdProcedimiento,IdDoctor,IdQuirofano,FechaHoraCirugia,IdEstadoCirugias,Observaciones")] CalendarioCirugia calendarioCirugia)
        {
            if (id != calendarioCirugia.IdCirugia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calendarioCirugia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalendarioCirugiaExists(calendarioCirugia.IdCirugia))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", calendarioCirugia.IdDoctor);
            ViewData["IdEstadoCirugias"] = new SelectList(_context.EstadosCirugias, "IdEstadoCirugias", "IdEstadoCirugias", calendarioCirugia.IdEstadoCirugias);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "IdPaciente", calendarioCirugia.IdPaciente);
            ViewData["IdProcedimiento"] = new SelectList(_context.ProcedimientosQuirurgicos, "IdProcedimiento", "IdProcedimiento", calendarioCirugia.IdProcedimiento);
            ViewData["IdQuirofano"] = new SelectList(_context.Quirofanos, "IdQuirofano", "IdQuirofano", calendarioCirugia.IdQuirofano);
            return View(calendarioCirugia);
        }

        // GET: CalendarioCirugias/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CalendarioCirugias == null)
            {
                return NotFound();
            }

            var calendarioCirugia = await _context.CalendarioCirugias
                .Include(c => c.IdDoctorNavigation)
                .Include(c => c.IdEstadoCirugiasNavigation)
                .Include(c => c.IdPacienteNavigation)
                .Include(c => c.IdProcedimientoNavigation)
                .Include(c => c.IdQuirofanoNavigation)
                .FirstOrDefaultAsync(m => m.IdCirugia == id);
            if (calendarioCirugia == null)
            {
                return NotFound();
            }

            return View(calendarioCirugia);
        }

        // POST: CalendarioCirugias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CalendarioCirugias == null)
            {
                return Problem("Entity set 'MeditrackContext.CalendarioCirugias'  is null.");
            }
            var calendarioCirugia = await _context.CalendarioCirugias.FindAsync(id);
            if (calendarioCirugia != null)
            {
                _context.CalendarioCirugias.Remove(calendarioCirugia);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalendarioCirugiaExists(int id)
        {
          return (_context.CalendarioCirugias?.Any(e => e.IdCirugia == id)).GetValueOrDefault();
        }
    }
}
