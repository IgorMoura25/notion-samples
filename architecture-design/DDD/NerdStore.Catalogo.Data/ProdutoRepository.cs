using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Catalogo.Domain;

namespace NerdStore.Catalogo.Data
{
    // The concrete class that will interact with database
    public class ProdutoRepository : IProdutoRepository
    {
        public void Adicionar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Adicionar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Produto produto)
        {
            throw new NotImplementedException();
        }

        public void Atualizar(Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Categoria>> ObterCategorias()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterPorCategoria(int codigo)
        {
            throw new NotImplementedException();
        }

        public Task<Produto> ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
