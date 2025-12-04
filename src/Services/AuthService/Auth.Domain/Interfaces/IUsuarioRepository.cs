using Auth.Domain.Entities;
using Core.Data;

namespace Auth.Domain.Interfaces
{
    public interface IUsuarioRepository: IRepository<Usuario>
    {
        Task<Usuario?> ObterPorEmailAsync(string email);
        Task<Usuario?> ObterPorIdAsync(Guid id);
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
    }

}
