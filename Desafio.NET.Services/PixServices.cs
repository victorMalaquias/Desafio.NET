using Desafio.NET.Database;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.NET.Services
{
    public class PixService : IPixService
    {
        #region Propriedades
        private readonly SqlContext _context;
        #endregion

        #region Construtores
        public PixService(SqlContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<Transacao> RealizarPix(PixRequest pixRequest)
        {
            var pagador = await ObterPagadorPorId(pixRequest.PagadorId);
            var recebedor = await ObterRecebedorPorId(pixRequest.RecebedorId);

            if (pagador == null || recebedor == null)
            {
                throw new Exception("Pagador ou recebedor não encontrado");
            }

            var transacao = new Transacao
            {
                DataTransacao = DateTime.Now,
                Pagador = pagador,
                Recebedor = recebedor,
                Valor = pixRequest.Valor
            };

            _context.Transacoes.Add(transacao);
            await _context.SaveChangesAsync();

            return transacao;
        }

        public async Task<List<Transacao>> ObterTransacoes()
        {
            var transacoes = await _context.Transacoes
                .Include(t => t.Pagador)
                    .ThenInclude(p => p.Chave) 
                .Include(t => t.Recebedor)
                    .ThenInclude(r => r.Chave) 
                .ToListAsync();

            return transacoes;
        }

        public async Task<Pagador> ObterPagadorPorId(int pagadorId)
        {
            return await _context.Pagadores.FindAsync(pagadorId);
        }
        public async Task<Recebedor> ObterRecebedorPorId(int recebedorId)
        {
            return await _context.Recebedores.FindAsync(recebedorId);
        }
        #endregion
    }
}
