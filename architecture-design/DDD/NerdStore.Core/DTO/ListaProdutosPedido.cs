using System;
using System.Collections.Generic;
using System.Text;

namespace NerdStore.Core.DTO
{
    // DTO objects that all contexts can use
    public class ListaProdutosPedido
    {
        public Guid PedidoId { get; set; }
        public ICollection<Item> Itens { get; set; }
    }

    public class Item
    {
        public Guid Id { get; set; }
        public int Quantidade { get; set; }
    }
}
