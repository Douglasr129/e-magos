namespace Core.DomainObjects.Interfaces
{
    /// <summary>
    /// Interface marcadora para a Raiz de Agregado (Aggregate Root) no Domain-Driven Design (DDD).
    /// </summary>
    /// <remarks>
    /// Uma <c>Aggregate Root</c> é uma entidade principal que garante a consistência transacional
    /// de um conjunto de entidades e objetos de valor dentro de seus limites.
    /// </remarks>
    public interface IAggregateRoot
    {
        IReadOnlyCollection<DomainEvents.DomainEvent> Events { get; }
        void ClearEvents();
    }
}
