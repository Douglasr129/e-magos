namespace Auth.Application.DTOs
{
    /// <summary>
    /// DTO para representar dados de usuário.
    /// </summary>
    public class UsuarioDTO
    {
        public Guid Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
    }

}
