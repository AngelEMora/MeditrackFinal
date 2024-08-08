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
    public class EstadoUsuariosController : Controller
    {
        private readonly MeditrackContext _context;

        public EstadoUsuariosController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: EstadoUsuarios
        public async Task<IActionResult> Index()
        {
              return _context.EstadoUsuarios != null ? 
                          View(await _context.EstadoUsuarios.ToListAsync()) :
                          Problem("Entity set 'MeditrackContext.EstadoUsuarios'  is null.");
        }

        // GET: EstadoUsuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EstadoUsuarios == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios
                .FirstOrDefaultAsync(m => m.IdEstadoUsuario == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EstadoUsuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdEstadoUsuario,NombreEstadoUsuario,Descripcion,FechaCreacion,UltimaModificacion,Activo")] EstadoUsuario estadoUsuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(estadoUsuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EstadoUsuarios == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }
            return View(estadoUsuario);
        }

        // POST: EstadoUsuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdEstadoUsuario,NombreEstadoUsuario,Descripcion,FechaCreacion,UltimaModificacion,Activo")] EstadoUsuario estadoUsuario)
        {
            if (id != estadoUsuario.IdEstadoUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estadoUsuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstadoUsuarioExists(estadoUsuario.IdEstadoUsuario))
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
            return View(estadoUsuario);
        }

        // GET: EstadoUsuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EstadoUsuarios == null)
            {
                return NotFound();
            }

            var estadoUsuario = await _context.EstadoUsuarios
                .FirstOrDefaultAsync(m => m.IdEstadoUsuario == id);
            if (estadoUsuario == null)
            {
                return NotFound();
            }

            return View(estadoUsuario);
        }

        // POST: EstadoUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EstadoUsuarios == null)
            {
                return Problem("Entity set 'MeditrackContext.EstadoUsuarios'  is null.");
            }
            var estadoUsuario = await _context.EstadoUsuarios.FindAsync(id);
            if (estadoUsuario != null)
            {
                _context.EstadoUsuarios.Remove(estadoUsuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EstadoUsuarioExists(int id)
        {
          return (_context.EstadoUsuarios?.Any(e => e.IdEstadoUsuario == id)).GetValueOrDefault();
        }
    }
}
