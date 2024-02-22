using Desafio.NET.Database;
using Desafio.NET.Entities;
using Desafio.NET.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio.NET.Services
{
    public class RecebedorServices : IRecebedorServices
    {
        #region Propriedades
        private readonly SqlContext _context;
        #endregion

        #region Construtores
        public RecebedorServices(SqlContext context)
        {
            _context = context;
        }
        #endregion

        #region Métodos
        public async Task<Recebedor> CriarRecebedor(Recebedor recebedor)
        {
            try
            {
                _context.Recebedores.Add(recebedor);
                await _context.SaveChangesAsync();

                return recebedor;
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro ao criar recebedor: {ex.Message}. Detalhes: {ex.InnerException?.Message}");
            }
        }

        public async Task<Recebedor> ObterRecebedor(int id)
        {
            var recebedor = await _context.Recebedores.FirstOrDefaultAsync(r => r.Id == id);

            if (recebedor == null)
            {
                throw new Exception("Recebedor não encontrado");
            }

            return recebedor;
        }

        public async Task<List<Recebedor>> ObterRecebedores()
        {
            var recebedores = await _context.Recebedores.Include(p => p.Chave).ToListAsync();

            if (recebedores == null || recebedores.Count == 0)
            {
                throw new Exception("Nenhum recebedor encontrado");
            }

            return recebedores;
        }


        public async Task<bool> VerificarChaveExistente(string descricaoChave)
        {
            return await _context.Chaves.AnyAsync(c => c.Descricao == descricaoChave);
        }
        #endregion
    }
}
