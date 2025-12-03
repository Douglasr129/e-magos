using Core.DomainObjects.DomainEvents;

namespace Auth.Domain.Events
{
    public record UsuarioRegistradoEvent(Guid UsuarioId, string Email) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

}
