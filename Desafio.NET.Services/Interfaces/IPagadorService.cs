using Desafio.NET.Entities;

namespace Desafio.NET.Services.Interfaces
{
    public interface IPagadorService
    {
        Task<List<Pagador>> ObterPagadores();
        Task<Pagador> ObterPagador(int id);
        Task<Pagador> CriarPagador(Pagador pagador);
        Task<bool> VerificarChaveExistente(string descricaoChave);

    }
}
