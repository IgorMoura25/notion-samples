using System;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Communication.Mediator;

namespace NerdStore.Catalogo.Domain
{
    // Domain Service
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatorHandler _bus;

        public EstoqueService(IProdutoRepository produtoRepository, IMediatorHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }

        // Implements business logic as workflows
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;

            if (!produto.PossuiEstoque(quantidade)) return false;

            produto.DebitarEstoque(quantidade);

            // TODO: Parametrizar a quantidade de estoque baixo
            if (produto.QuantidadeEstoque < 10)
            {
                // Use the bus to publish an event
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produto.Id, produto.QuantidadeEstoque));
            }

            _produtoRepository.Atualizar(produto);
            // return await _produtoRepository.UnitOfWork.Commit();

            return true;
        }

        // Implements business logic as workflows
        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null) return false;
            produto.ReporEstoque(quantidade);

            _produtoRepository.Atualizar(produto);
            // return await _produtoRepository.UnitOfWork.Commit();

            return true;
        }

        public void Dispose()
        {
            _produtoRepository.Dispose();
        }
    }
}