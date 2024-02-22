using Desafio.NET.Entities;

namespace Desafio.NET.Business.Interfaces
{
    public interface IPagadorBusiness
    {
        Task<List<Pagador>> ObterPagadores();
        Task<Pagador> ObterPagador(int id);
        Task<Pagador> CriarPagador(Pagador pagador);
    }
}
