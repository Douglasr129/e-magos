using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Infrastructure.Data;
using Core.Data;
using Microsoft.EntityFrameworkCore;


namespace Auth.Infrastructure.Repository
{
    /// <summary>
    /// Repositório de usuários com EF Core.
    /// </summary>
    public class UsuarioRepository(AuthDbContext context) : IUsuarioRepository
    {
        private readonly AuthDbContext _context = context;

        public IUnitOfWork UnitOfWork => _context;

        public async Task<Usuario?> ObterPorEmailAsync(string email)
        {
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email.Address == email);
        }

        public async Task<Usuario?> ObterPorIdAsync(Guid id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task AtualizarAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }

}
