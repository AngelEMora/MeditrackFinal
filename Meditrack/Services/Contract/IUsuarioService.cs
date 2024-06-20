using Microsoft.EntityFrameworkCore;
using Meditrack.Models;

namespace Meditrack.Services.Contract
{
    public interface IUsuarioService
    {

        Task<Usuario> GetUsuario(string NombreUsuario, string contrasena);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
