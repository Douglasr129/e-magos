namespace Core.DomainObjects.ValueObjects
{
    /// <summary>
    /// Representa o usuário autenticado no contexto da requisição.
    /// </summary>
    public record UsuarioContexto
    {
        public Guid Id { get; init; }
        public string? Email { get; init; }
        public string? Nome { get; init; }

        public bool IsAutenticado => Id != Guid.Empty;
    }

}
