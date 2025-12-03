using Core.DomainObjects.DomainEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Events
{
    public record UsuarioAutenticadoEvent(Guid UsuarioId, string Email) : IDomainEvent
    {
        public DateTime OccurredOn { get; } = DateTime.UtcNow;
    }

}
