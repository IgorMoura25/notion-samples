using System;
using NerdStore.Core.DomainObjects;

namespace NerdStore.Catalogo.Domain
{
    // Domain Model
    public class Produto : Entity, IAggregateRoot
    {
        // This property is here just for the course's sake
        public Guid CategoriaId { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public bool Ativo { get; private set; }
        public decimal Valor { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string Imagem { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public Categoria Categoria { get; private set; }

        public Produto(string nome, string descricao, decimal valor, DateTime dataCadastro, string imagem, Guid categoriaId)
        {
            CategoriaId = categoriaId;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            DataCadastro = dataCadastro;
            Imagem = imagem;

            // Can't allow an instance of a invalid "Produto" object
            Validar();
        }

        #region AdHoc setters
        // Ad Hocs setters
        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void AlterarCategoria(Categoria categoria)
        {
            Categoria = categoria;
            CategoriaId = categoria.Id;
        }

        public void AlterarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void DebitarEstoque(int quantidade)
        {
            if (quantidade < 0)
            {
                quantidade = quantidade * -1; // Invert the sign
            }

            QuantidadeEstoque -= quantidade;
        }

        public void ReporEstoque(int quantidade)
        {
            QuantidadeEstoque += quantidade;
        }

        public bool PossuiEstoque(int quantidade)
        {
            return QuantidadeEstoque >= quantidade;
        }
        #endregion

        public void Validar()
        {
            // Validate it's own state to guarantee the integrity of the class, like checking if the class has a StockAmount minor than zero, etc.
            // Best practice is to have the validations on a AssertionConcern class that will throw an exception

            // AssertionConcern.ValidateIfEmpty(Nome, "Nome não pode ser vazio.");
        }
    }
}
