using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NerdStore.Core.Messages.CommonMessages.IntegrationEvents;

namespace NerdStore.Catalogo.Domain.Events
{
    // A concrete event handler for the "Produto" entity
    public class ProdutoEventHandler : 
        INotificationHandler<ProdutoAbaixoEstoqueEvent>,
        INotificationHandler<PedidoIniciadoEvent>
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoEventHandler(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Handle(ProdutoAbaixoEstoqueEvent mensagem, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.ObterPorId(mensagem.AggregateId);

            // Do something when the stock of the product is below the threshold...
        }

        public Task Handle(PedidoIniciadoEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
