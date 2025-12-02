using System.ComponentModel.DataAnnotations.Schema;

namespace Core.DomainObjects.DomainEvents
{
    /// <summary>
    /// Classe base abstrata para todos os Eventos de Domínio (Domain Events) no DDD.
    /// Um Evento de Domínio representa algo que aconteceu no domínio e sobre o qual
    /// outros componentes do sistema (ou microsserviços) podem reagir.
    /// </summary>
    [NotMapped]
    public abstract record DomainEvent(DateTimeOffset OccurredOn)
    {
        // Nota: Um 'record' já gera automaticamente o construtor, 
        // as propriedades, e implementa Equals/GetHashCode (igualdade por valor)
        // com base nos parâmetros do construtor primário (OccurredOn).

        /// <summary>
        /// A data e hora em que o evento ocorreu no sistema, incluindo o offset de fuso horário.
        /// </summary>
        public DateTimeOffset OccurredOn { get; init; } = OccurredOn;

        /// <summary>
        /// ID do evento. Embora não estivesse no código original, é uma boa prática
        /// adicionar um ID exclusivo para rastreamento (tracing).
        /// </summary>
        public Guid EventId { get; init; } = Guid.NewGuid();
    }
}
