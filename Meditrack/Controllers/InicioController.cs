using Microsoft.AspNetCore.Mvc;
using Meditrack.Models;
using Meditrack.Resources;
using Meditrack.Services.Contract;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Meditrack.Controllers
{
    public class InicioController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        public InicioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IActionResult Registrarse()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Registrarse(Usuario modelo)
        {
            modelo.Contrasena = Utilities.EncriptarContra(modelo.Contrasena);

            Usuario usuario_creado = await _usuarioService.SaveUsuario(modelo);

            if (usuario_creado.IdUsuario > 0)
            {
                return RedirectToAction("IniciarSesion", "Inicio");
            }

            ViewData["Mensaje"] = "No se pudo crear el usuario";

            return View();
        }

        // Salida
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio"); // Redirige al inicio de sesión después de salir
        }

        public IActionResult IniciarSesion()
        {
            return View();
        }
        public IActionResult Principal()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> IniciarSesion(string nombreusuario, string contrasena)
        {
            Usuario usuario_encontrado = await _usuarioService.GetUsuario(nombreusuario, Utilities.EncriptarContra(contrasena));


            if (usuario_encontrado == null)
            {
                ViewData["Mensaje"] = "No se encontro el usuario";
                return View();
            }


            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, usuario_encontrado.NombreUsuario)
            };

            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            AuthenticationProperties properties = new AuthenticationProperties()
            {
                AllowRefresh = true
            };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                properties);


            return RedirectToAction("Principal");
        }


    }
}
