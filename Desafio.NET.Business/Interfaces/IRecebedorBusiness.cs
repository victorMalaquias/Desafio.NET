using Desafio.NET.Entities;

namespace Desafio.NET.Business.Interfaces
{
    public interface IRecebedorBusiness
    {
        Task<List<Recebedor>> ObterRecebedores();
        Task<Recebedor> ObterRecebedor(int id);
        Task<Recebedor> CriarRecebedor(Recebedor recebedor);
    }
}
