using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Data
{
    // where T : IAggregateRoot => this ensure that there is only one repository per aggregation
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
    }
}
