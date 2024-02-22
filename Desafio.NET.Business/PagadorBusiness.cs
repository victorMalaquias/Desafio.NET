using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;

namespace Desafio.NET.Business
{
    public class PagadorBusiness : IPagadorBusiness
    {
        #region Propriedades
        private readonly IPagadorService _pagadorService;
        #endregion

        #region Construtores
        public PagadorBusiness(IPagadorService pagadorService)
        {
            _pagadorService = pagadorService;
        }
        #endregion

        #region Métodos
        public async Task<Pagador> CriarPagador(Pagador pagador)
        {
            try
            {
                var chaveExistente = await _pagadorService.VerificarChaveExistente(pagador.Chave.Descricao);

                if (chaveExistente)
                {
                    throw new Exception("Chave PIX já cadastrada para outro usuário");
                }

                return await _pagadorService.CriarPagador(pagador);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar pagador: {ex.Message}");
            }
        }

        public async Task<Pagador> ObterPagador(int id)
        {
            try
            {
                return await _pagadorService.ObterPagador(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter pagador: {ex.Message}");
            }
        }

        public async Task<List<Pagador>> ObterPagadores()
        {
            try
            {
                return await _pagadorService.ObterPagadores();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter pagadores: {ex.Message}");
            }
        }
        #endregion
    }
}
