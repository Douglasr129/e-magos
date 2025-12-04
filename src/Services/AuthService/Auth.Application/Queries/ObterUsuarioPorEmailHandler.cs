using Auth.Application.DTOs;
using Auth.Domain.Interfaces;
using MediatR;

namespace Auth.Application.Queries
{
    /// <summary>
    /// Handler responsável por consultar usuário pelo e-mail.
    /// </summary>
    public class ObterUsuarioPorEmailHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<ObterUsuarioPorEmailQuery, UsuarioDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<UsuarioDTO> Handle(ObterUsuarioPorEmailQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario is null)
#pragma warning disable CS8603 // Possível retorno de referência nula.
                return null; // ou lançar uma exceção customizada
#pragma warning restore CS8603 // Possível retorno de referência nula.

            return new UsuarioDTO
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Email = usuario.Email.ToString()
            };
        }
    }

}
