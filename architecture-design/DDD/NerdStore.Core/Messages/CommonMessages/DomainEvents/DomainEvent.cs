using System;
using NerdStore.Core.Messages;

namespace NerdStore.Core.Messages.CommonMessages.DomainEvents
{
    // A superclass that represents the Domain Event
    public abstract class DomainEvent : Event
    {
        public DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
        }
    }
}
