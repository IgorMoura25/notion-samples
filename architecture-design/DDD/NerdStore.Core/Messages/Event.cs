using System;
using MediatR;

namespace NerdStore.Core.Messages
{
    // A superclass for an Event, which is a Message
    public abstract class Event : Message, INotification // The attribute interface of MediatR for notification only
    {
        public DateTime DataHora { get; private set; }

        public Event()
        {
            DataHora = DateTime.Now;
        }
    }
}
