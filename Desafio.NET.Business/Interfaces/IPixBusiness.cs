using Desafio.NET.Entities;

namespace Desafio.NET.Business.Interfaces
{
    public interface IPixBusiness
    {
        Task<Transacao> RealizarPix(PixRequest pixRequest);
        Task<List<Transacao>> ObterTransacoes();
    }
}
