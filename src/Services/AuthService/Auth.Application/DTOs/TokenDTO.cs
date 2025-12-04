namespace Auth.Application.DTOs
{
    /// <summary>
    /// DTO para representar resultado de autenticação.
    /// </summary>
    public class AuthResultDTO
    {
        public Guid UsuarioId { get; set; }
        public required string Email { get; set; }
        public required string Token { get; set; }
    }

}
