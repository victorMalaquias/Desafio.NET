using Desafio.NET.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio.NET.Database.Map
{
    public class ChaveMap : IEntityTypeConfiguration<Chave>
    {
        public void Configure(EntityTypeBuilder<Chave> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasColumnType("varchar(1000)");
        }
    }

    public class PagadorMap : IEntityTypeConfiguration<Pagador>
    {
        public void Configure(EntityTypeBuilder<Pagador> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.Property(x => x.Saldo)
                .IsRequired();


        }
    }


    public class RecebedorMap : IEntityTypeConfiguration<Recebedor>
    {
        public void Configure(EntityTypeBuilder<Recebedor> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnType("varchar(1000)");
            builder.Property(x => x.Saldo)
                .IsRequired();


        }
    }

    public class TransacaoMap : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.DataTransacao)
                .IsRequired()
                .HasColumnType("date");

            builder.HasOne(p => p.Pagador)
                .WithMany()
                .IsRequired();


            builder.HasOne(p => p.Recebedor)
                .WithMany()
                .IsRequired();
        }
    }

}
