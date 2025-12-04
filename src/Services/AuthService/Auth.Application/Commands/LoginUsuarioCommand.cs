using Auth.Application.DTOs;
using MediatR;

namespace Auth.Application.Commands
{
    /// <summary>
    /// Command para autenticar um usuário.
    /// </summary>
    public class LoginUsuarioCommand : IRequest<AuthResultDTO>
    {
        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Senha do usuário.
        /// </summary>
        public required string Senha { get; set; }
    }

}
