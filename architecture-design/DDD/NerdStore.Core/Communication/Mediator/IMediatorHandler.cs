using System.Threading.Tasks;
using NerdStore.Core.Messages;
using NerdStore.Core.Messages.CommonMessages.Notifications;

namespace NerdStore.Core.Communication.Mediator
{
    // The mediator is not a bus, but it can be used as interface for the bus later...
    // It is not a bus, but it can act as a bus
    public interface IMediatorHandler
    {
        Task PublicarEvento<T>(T evento) where T : Event;
        Task<bool> PublicarComando<T>(T comando) where T : Command;
        Task PublicarNotification<T>(T notificacao) where T : DomainNotification;
    }
}
