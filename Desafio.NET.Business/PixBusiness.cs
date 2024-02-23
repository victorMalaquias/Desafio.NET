using Desafio.NET.Business.Interfaces;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;

namespace Desafio.NET.Business
{
    public class PixBusiness : IPixBusiness
    {
        #region Propriedades
        private readonly IPixService _pixService;
        #endregion

        #region Construtores
        public PixBusiness(IPixService pixService)
        {
            _pixService = pixService;
        }
        #endregion

        #region Métodos
        public async Task<Transacao> RealizarPix(PixRequest pixRequest)
        {
            try
            {
                var pagador = await _pixService.ObterPagadorPorId(pixRequest.PagadorId);
                var recebedor = await _pixService.ObterRecebedorPorId(pixRequest.RecebedorId);

                if (pixRequest.PagadorId <= 0 || pixRequest.RecebedorId <= 0)
                {
                    throw new Exception("Campos obrigatórios ausentes ou inválidos.");
                }

                if (pixRequest.Valor <= 0)
                {
                    throw new Exception("O valor da transação deve ser maior que zero.");
                }

                if (pagador.Saldo < pixRequest.Valor)
                {
                    throw new Exception("Saldo insuficiente no pagador");
                }

                pagador.Saldo -= pixRequest.Valor;
                recebedor.Saldo += pixRequest.Valor;

                return await _pixService.RealizarPix(pixRequest);
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao realizar pix: {ex.Message}");
            }
        }

        public async Task<List<Transacao>> ObterTransacoes()
        {
            try
            {
                return await _pixService.ObterTransacoes();
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao obter transações: {ex.Message}");
            }
        }
        #endregion

    }
}
