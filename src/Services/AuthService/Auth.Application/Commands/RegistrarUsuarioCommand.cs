using MediatR;

namespace Auth.Application.Commands
{
    /// <summary>
    /// Command para registrar um novo usuário.
    /// </summary>
    public class RegistrarUsuarioCommand : IRequest<Guid>
    {
        /// <summary>Nome do usuário.</summary>
        public required string Nome { get; set; }

        /// <summary>Email do usuário.</summary>
        public required string Email { get; set; }

        /// <summary>Senha do usuário.</summary>
        public required string Senha { get; set; }
    }

}
