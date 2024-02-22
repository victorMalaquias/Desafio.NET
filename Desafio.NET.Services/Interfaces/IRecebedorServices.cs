using Desafio.NET.Entities;

namespace Desafio.NET.Services.Interfaces
{
    public interface IRecebedorServices
    {
        Task<List<Recebedor>> ObterRecebedores();
        Task<Recebedor> ObterRecebedor(int id);
        Task<Recebedor> CriarRecebedor(Recebedor recebedor);
        Task<bool> VerificarChaveExistente(string descricaoChave);
    }
}
