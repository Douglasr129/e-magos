using Core.DomainObjects.DomainEvents;
using Core.DomainObjects.Interfaces;
using Core.DomainObjects.Models;

namespace Core.DomainObjects.Services
{
    /// <summary>
    /// Classe base abstrata para a Raiz de Agregado (Aggregate Root) no Domain-Driven Design (DDD).
    /// Implementa a interface <see cref="IAggregateRoot"/> e gerencia <see cref="DomainEvent"/>s.
    /// </summary>
    public abstract class AggregateRoot : Entity, IAggregateRoot // Implementando IAggregateRoot
    {
        private readonly List<IDomainEvent> _events = new();

        /// <summary>
        /// Obtém uma coleção de Eventos de Domínio que foram acumulados durante a execução
        /// de operações no Aggregate Root.
        /// </summary>
        public IReadOnlyCollection<IDomainEvent> Events => _events.AsReadOnly();

        /// <summary>
        /// Adiciona um Evento de Domínio à lista de eventos acumulados.
        /// As classes filhas (Agregados específicos) devem usar este método para registrar
        /// que algo relevante aconteceu no domínio.
        /// </summary>
        /// <param name="evt">O Evento de Domínio a ser adicionado.</param>
        protected void AddEvent(IDomainEvent evt) => _events.Add(evt);

        /// <summary>
        /// Limpa a lista de Eventos de Domínio acumulados.
        /// Este método deve ser chamado *após* a publicação bem-sucedida dos eventos,
        /// geralmente pela camada de Aplicação ou Infraestrutura (por exemplo, após o commit da transação).
        /// </summary>
        public void ClearEvents() => _events.Clear();
    }
}
