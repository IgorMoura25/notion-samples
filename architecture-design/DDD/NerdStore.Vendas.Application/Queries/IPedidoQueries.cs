﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NerdStore.Vendas.Application.Queries.ViewModels;

namespace NerdStore.Vendas.Application.Queries
{
    // Query Facade
    public interface IPedidoQueries
    {
        Task<CarrinhoViewModel> ObterCarrinhoCliente(Guid clienteId);
        Task<IEnumerable<PedidoViewModel>> ObterPedidosCliente(Guid clienteId);
    }
}
