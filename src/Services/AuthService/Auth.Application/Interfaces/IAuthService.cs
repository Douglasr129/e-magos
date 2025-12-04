using Auth.Domain.Entities;

namespace Auth.Application.Interfaces
{
    /// <summary>
    /// Serviço de autenticação responsável por gerar tokens.
    /// </summary>
    public interface IAuthService
    {
        string GerarToken(Usuario usuario);
    }

}
