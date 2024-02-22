using Desafio.NET.Database.Map;
using Desafio.NET.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.NET.Database
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Transacao> Transacoes { get; set; }
        public DbSet<Chave> Chaves { get; set; }
        public DbSet<Pagador> Pagadores { get; set; }
        public DbSet<Recebedor> Recebedores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChaveMap());
            modelBuilder.ApplyConfiguration(new PagadorMap());
            modelBuilder.ApplyConfiguration(new RecebedorMap());
            modelBuilder.ApplyConfiguration(new TransacaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}
