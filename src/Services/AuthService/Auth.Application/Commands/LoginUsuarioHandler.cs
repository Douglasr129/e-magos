using Auth.Application.DTOs;
using Auth.Application.Interfaces;
using Auth.Domain.Interfaces;
using MediatR;

namespace Auth.Application.Commands
{
    /// <summary>
    /// Handler responsável por autenticar um usuário.
    /// </summary>
    public class LoginUsuarioHandler(IUsuarioRepository usuarioRepository, IAuthService authService) : IRequestHandler<LoginUsuarioCommand, AuthResultDTO>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IAuthService _authService = authService;

        public async Task<AuthResultDTO> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.ObterPorEmailAsync(request.Email);

            if (usuario is null || !usuario.Senha.Validar(request.Senha))
                throw new Exception("Credenciais inválidas.");

            var token = _authService.GerarToken(usuario);

            return new AuthResultDTO
            {
                UsuarioId = usuario.Id,
                Email = usuario.Email.ToString(),
                Token = token
            };
        }
    }
}
