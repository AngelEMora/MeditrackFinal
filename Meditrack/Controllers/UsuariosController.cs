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
    public class UsuariosController : Controller
    {
        private readonly MeditrackContext _context;

        public UsuariosController(MeditrackContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var meditrackContext = _context.Usuarios.Include(u => u.IdDoctorNavigation).Include(u => u.IdEstadoUsuarioNavigation).Include(u => u.NombreRolNavigation).Include(u => u.Rol);
            return View(await meditrackContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdDoctorNavigation)
                .Include(u => u.IdEstadoUsuarioNavigation)
                .Include(u => u.NombreRolNavigation)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor");
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuarios, "IdEstadoUsuario", "IdEstadoUsuario");
            ViewData["NombreRol"] = new SelectList(_context.Roles, "Nombre", "Nombre");
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "Nombre");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdUsuario,NombreUsuario,Contrasena,RolId,FechaDeRegistro,IdEstadoUsuario,NombreRol,IdDoctor")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", usuario.IdDoctor);
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuarios, "IdEstadoUsuario", "IdEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["NombreRol"] = new SelectList(_context.Roles, "Nombre", "Nombre", usuario.NombreRol);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", usuario.IdDoctor);
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuarios, "IdEstadoUsuario", "IdEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["NombreRol"] = new SelectList(_context.Roles, "Nombre", "Nombre", usuario.NombreRol);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdUsuario,NombreUsuario,Contrasena,RolId,FechaDeRegistro,IdEstadoUsuario,NombreRol,IdDoctor")] Usuario usuario)
        {
            if (id != usuario.IdUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.IdUsuario))
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
            ViewData["IdDoctor"] = new SelectList(_context.Doctores, "IdDoctor", "IdDoctor", usuario.IdDoctor);
            ViewData["IdEstadoUsuario"] = new SelectList(_context.EstadoUsuarios, "IdEstadoUsuario", "IdEstadoUsuario", usuario.IdEstadoUsuario);
            ViewData["NombreRol"] = new SelectList(_context.Roles, "Nombre", "Nombre", usuario.NombreRol);
            ViewData["RolId"] = new SelectList(_context.Roles, "IdRol", "Nombre", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .Include(u => u.IdDoctorNavigation)
                .Include(u => u.IdEstadoUsuarioNavigation)
                .Include(u => u.NombreRolNavigation)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.IdUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'MeditrackContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuarios?.Any(e => e.IdUsuario == id)).GetValueOrDefault();
        }
    }
}
