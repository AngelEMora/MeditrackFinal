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
    public class MovimientoInventariosController : Controller
    {
        private readonly MeditrackContext _context;

        public MovimientoInventariosController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: MovimientoInventarios
        public async Task<IActionResult> Index()
        {
              return _context.MovimientoInventarios != null ? 
                          View(await _context.MovimientoInventarios.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.MovimientoInventarios'  is null.");
        }

        // GET: MovimientoInventarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovimientoInventarios == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovimientoInventarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMovimiento,NombreMovimiento")] MovimientoInventario movimientoInventario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movimientoInventario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovimientoInventarios == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }
            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMovimiento,NombreMovimiento")] MovimientoInventario movimientoInventario)
        {
            if (id != movimientoInventario.IdMovimiento)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movimientoInventario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovimientoInventarioExists(movimientoInventario.IdMovimiento))
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
            return View(movimientoInventario);
        }

        // GET: MovimientoInventarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovimientoInventarios == null)
            {
                return NotFound();
            }

            var movimientoInventario = await _context.MovimientoInventarios
                .FirstOrDefaultAsync(m => m.IdMovimiento == id);
            if (movimientoInventario == null)
            {
                return NotFound();
            }

            return View(movimientoInventario);
        }

        // POST: MovimientoInventarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovimientoInventarios == null)
            {
                return Problem("Entity set 'MeditrackContext.MovimientoInventarios'  is null.");
            }
            var movimientoInventario = await _context.MovimientoInventarios.FindAsync(id);
            if (movimientoInventario != null)
            {
                _context.MovimientoInventarios.Remove(movimientoInventario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MovimientoInventarioExists(int id)
        {
          return (_context.MovimientoInventarios?.Any(e => e.IdMovimiento == id)).GetValueOrDefault();
        }
    }
}
