using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;

namespace Desafio.NET.Business
{
    public class RecebedorBusiness : IRecebedorBusiness
    {
        #region Propriedades
        private readonly IRecebedorServices _recebedorService;
        #endregion

        #region Construtores
        public RecebedorBusiness(IRecebedorServices recebedorService)
        {
            _recebedorService = recebedorService;
        }
        #endregion

        #region Métodos
        public async Task<Recebedor> CriarRecebedor(Recebedor recebedor)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(recebedor.Nome))
                {
                    throw new Exception("O nome do recebedor é obrigatório.");
                }

                var chaveExistente = await _recebedorService.VerificarChaveExistente(recebedor.Chave.Descricao);

                if (chaveExistente)
                {
                    throw new Exception("Chave PIX já cadastrada para outro usuário.");
                }

                return await _recebedorService.CriarRecebedor(recebedor);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar recebedor: {ex.Message}. Detalhes: {ex.InnerException?.Message}");
            }
        }

        public async Task<Recebedor> ObterRecebedor(int id)
        {
            try
            {
                return await _recebedorService.ObterRecebedor(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter recebedor: {ex.Message}. Detalhes: {ex.InnerException?.Message}");
            }
        }

        public async Task<List<Recebedor>> ObterRecebedores()
        {
            try
            {
                return await _recebedorService.ObterRecebedores();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter recebedores: {ex.Message}");
            }
        }
        #endregion
    }
}
