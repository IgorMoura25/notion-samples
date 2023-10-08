using System;
using NerdStore.Core.Messages.CommonMessages.DomainEvents;

namespace NerdStore.Catalogo.Domain.Events
{
    // A concrete class for a specifc domain event
    public class ProdutoAbaixoEstoqueEvent : DomainEvent
    {
        public int QuantidadeRestante { get; private set; }
        public ProdutoAbaixoEstoqueEvent(Guid aggregateId, int quantidadeRestante) : base(aggregateId)
        {
            QuantidadeRestante = quantidadeRestante;
        }
    }
}
