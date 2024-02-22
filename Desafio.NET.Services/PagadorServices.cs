using Desafio.NET.Database;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.NET.Services
{
    public class PagadorService : IPagadorService
    {
        #region Propriedades
        private readonly SqlContext _context;
        #endregion

        #region Construtores 
        public PagadorService(SqlContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<Pagador> CriarPagador(Pagador pagador)
        {
            _context.Pagadores.Add(pagador);
            await _context.SaveChangesAsync();

            return pagador;
        }

        public async Task<Pagador> ObterPagador(int id)
        {
            var pagador = await _context.Pagadores.FirstOrDefaultAsync(p => p.Id == id);

            if (pagador == null)
            {
                throw new Exception("Pagador não encontrado");
            }

            return pagador;
        }

        public async Task<List<Pagador>> ObterPagadores()
        {
            var pagadores = await _context.Pagadores.Include(p => p.Chave).ToListAsync();

            if (pagadores == null || pagadores.Count == 0)
            {
                throw new Exception("Nenhum pagador encontrado");
            }

            return pagadores;
        }

        public async Task<bool> VerificarChaveExistente(string descricaoChave)
        {
            return await _context.Chaves.AnyAsync(c => c.Descricao == descricaoChave);
        }
        #endregion
    }
}
