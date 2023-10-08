namespace NerdStore.Pagamentos.Business
{
    // This facade will abstract all the specifics of the external application, so it will not break your Pagamento Context
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Pedido pedido, Pagamento pagamento);
    }
}