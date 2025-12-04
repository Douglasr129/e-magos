using Auth.Domain.Entities;
using Auth.Domain.Interfaces;
using Auth.Domain.ValueObjects;
using MediatR;

namespace Auth.Application.Commands
{
    /// <summary>
    /// Handler responsável por registrar um novo usuário.
    /// </summary>
    public class RegistrarUsuarioHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<RegistrarUsuarioCommand, Guid>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<Guid> Handle(RegistrarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = new Usuario(
                request.Nome,
                new Email(request.Email),
                new Senha(request.Senha)
            );

            await _usuarioRepository.AdicionarAsync(usuario);

            return usuario.Id;
        }
    }

}
