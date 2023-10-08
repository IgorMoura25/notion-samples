using System.Linq;
using System.Threading.Tasks;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Core.Communication.Mediator
{
    public static class MediatorExtension
    {
        public static async Task PublicarEventos(this IMediatorHandler mediator, Entity entity)
        {
            var tasks = entity.Eventos.Select(async (domainEvent) =>
            {
                await mediator.PublicarEvento(domainEvent);
            });

            await Task.WhenAll(tasks);
        }
    }
}
