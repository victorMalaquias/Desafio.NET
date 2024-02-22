using Desafio.NET.Entities;

namespace Desafio.NET.Services.Interfaces
{
    public interface IPixService
    {
        Task<Transacao> RealizarPix(PixRequest pixRequest);
        Task<List<Transacao>> ObterTransacoes();
        Task<Pagador> ObterPagadorPorId(int pagadorId);
        Task<Recebedor> ObterRecebedorPorId(int recebedorId);
    }
}
