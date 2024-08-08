﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meditrack.Models;

namespace Meditrack.Controllers
{
    public class DoctoresController : Controller
    {
        private readonly MeditrackContext _context;

        public DoctoresController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Doctores
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.Doctores.Include(d => d.IdEspecialidadNavigation).Include(d => d.IdOcupacionNavigation);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: Doctores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctore = await _context.Doctores
                .Include(d => d.IdEspecialidadNavigation)
                .Include(d => d.IdOcupacionNavigation)
                .FirstOrDefaultAsync(m => m.IdDoctor == id);
            if (doctore == null)
            {
                return NotFound();
            }

            return View(doctore);
        }

        // GET: Doctores/Create
        public IActionResult Create()
        {
            ViewData["IdEspecialidad"] = new SelectList(_context.EspecialidadesMedicas, "IdEspecialidad", "IdEspecialidad");
            ViewData["IdOcupacion"] = new SelectList(_context.OcupacionMedicas, "IdOcupacion", "IdOcupacion");
            return View();
        }

        // POST: Doctores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdDoctor,NombreDoctor,ApellidosDoctor,TelefonoDoctor,EdadDoctor,NacionalidadDoctor,IdentificacionDoctor,SexoDoctor,FechaNacimiento,IdEspecialidad,IdOcupacion")] Doctore doctore)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctore);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdEspecialidad"] = new SelectList(_context.EspecialidadesMedicas, "IdEspecialidad", "IdEspecialidad", doctore.IdEspecialidad);
            ViewData["IdOcupacion"] = new SelectList(_context.OcupacionMedicas, "IdOcupacion", "IdOcupacion", doctore.IdOcupacion);
            return View(doctore);
        }

        // GET: Doctores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctore = await _context.Doctores.FindAsync(id);
            if (doctore == null)
            {
                return NotFound();
            }
            ViewData["IdEspecialidad"] = new SelectList(_context.EspecialidadesMedicas, "IdEspecialidad", "IdEspecialidad", doctore.IdEspecialidad);
            ViewData["IdOcupacion"] = new SelectList(_context.OcupacionMedicas, "IdOcupacion", "IdOcupacion", doctore.IdOcupacion);
            return View(doctore);
        }

        // POST: Doctores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdDoctor,NombreDoctor,ApellidosDoctor,TelefonoDoctor,EdadDoctor,NacionalidadDoctor,IdentificacionDoctor,SexoDoctor,FechaNacimiento,IdEspecialidad,IdOcupacion")] Doctore doctore)
        {
            if (id != doctore.IdDoctor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctore);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctoreExists(doctore.IdDoctor))
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
            ViewData["IdEspecialidad"] = new SelectList(_context.EspecialidadesMedicas, "IdEspecialidad", "IdEspecialidad", doctore.IdEspecialidad);
            ViewData["IdOcupacion"] = new SelectList(_context.OcupacionMedicas, "IdOcupacion", "IdOcupacion", doctore.IdOcupacion);
            return View(doctore);
        }

        // GET: Doctores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctores == null)
            {
                return NotFound();
            }

            var doctore = await _context.Doctores
                .Include(d => d.IdEspecialidadNavigation)
                .Include(d => d.IdOcupacionNavigation)
                .FirstOrDefaultAsync(m => m.IdDoctor == id);
            if (doctore == null)
            {
                return NotFound();
            }

            return View(doctore);
        }

        // POST: Doctores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctores == null)
            {
                return Problem("Entity set 'MeditrackContext.Doctores'  is null.");
            }
            var doctore = await _context.Doctores.FindAsync(id);
            if (doctore != null)
            {
                _context.Doctores.Remove(doctore);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctoreExists(int id)
        {
          return (_context.Doctores?.Any(e => e.IdDoctor == id)).GetValueOrDefault();
        }
    }
}
