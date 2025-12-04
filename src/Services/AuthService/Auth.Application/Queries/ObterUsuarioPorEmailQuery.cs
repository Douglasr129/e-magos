using Auth.Application.DTOs;
using MediatR;

namespace Auth.Application.Queries
{
    /// <summary>
    /// Query para obter um usuário pelo e-mail.
    /// </summary>
    public class ObterUsuarioPorEmailQuery(string email) : IRequest<UsuarioDTO>
    {
        /// <summary>
        /// E-mail do usuário a ser consultado.
        /// </summary>
        public string Email { get; set; } = email;
    }

}
