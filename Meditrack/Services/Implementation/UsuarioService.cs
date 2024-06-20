using Microsoft.EntityFrameworkCore;
using Meditrack.Models;
using Meditrack.Services.Contract;

namespace Meditrack.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {

        private readonly MeditrackContext _dbContext;

        public UsuarioService(MeditrackContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Usuario> GetUsuario(string NombreUsuario, string contrasena)
        {
            Usuario usuario_encontrado = await _dbContext.Usuarios.Where(u => u.NombreUsuario == NombreUsuario && u.Contrasena == contrasena)
                .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuarios.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
