using System;
using FluentValidation.Results;
using MediatR;

namespace NerdStore.Core.Messages
{
    // A superclass for a CQRS Command, which is a Message
    public abstract class Command : Message, IRequest<bool> // The attribute interface of MediatR for request only
    {
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command()
        {
            Timestamp = DateTime.Now;
        }

        public virtual bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
