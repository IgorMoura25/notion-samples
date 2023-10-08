using System;
using System.Collections.Generic;
using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects
{
    // Entity SuperClass
    public abstract class Entity
    {
        private List<Event> _events;
        public IReadOnlyCollection<Event> Eventos => _events?.AsReadOnly();

        // Best practice to work with Guid as identification
        public Guid Id { get; private set; }

        protected Entity()
        {
            Id = Guid.NewGuid(); // Generate own Guid
        }

        public void AdicionarEvento(Event evento)
        {
            _events = _events ?? new List<Event>();
            _events.Add(evento);
        }

        public void RemoverEvento(Event eventItem)
        {
            _events?.Remove(eventItem);
        }

        public void LimparEventos()
        {
            _events?.Clear();
        }

        // Comparison criteria is the IDENTIFICATION of both Entities
        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (ReferenceEquals(null, compareTo)) return false;

            return Id.Equals(compareTo.Id);
        }

        // The same for this one, but using the == operator
        public static bool operator ==(Entity a, Entity b)
        {
            // If both are null
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            {
                return true;
            }

            // If only one is null
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            {
                return false;
            }

            // This will already compare using ID
            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        // This is to ensure that the hashcode is NEVER the same
        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }
    }
}
