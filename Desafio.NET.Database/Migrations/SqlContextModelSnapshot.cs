﻿// <auto-generated />
using System;
using Desafio.NET.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Desafio.NET.Database.Migrations
{
    [DbContext(typeof(SqlContext))]
    partial class SqlContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Desafio.NET.Entities.Chave", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<int>("TipoChave")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Chaves");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Pagador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChaveId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChaveId");

                    b.ToTable("Pagadores");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Recebedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChaveId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(1000)");

                    b.Property<decimal>("Saldo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ChaveId");

                    b.ToTable("Recebedores");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Transacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataTransacao")
                        .HasColumnType("date");

                    b.Property<int>("PagadorId")
                        .HasColumnType("int");

                    b.Property<int>("RecebedorId")
                        .HasColumnType("int");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("PagadorId");

                    b.HasIndex("RecebedorId");

                    b.ToTable("Transacoes");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Pagador", b =>
                {
                    b.HasOne("Desafio.NET.Entities.Chave", "Chave")
                        .WithMany()
                        .HasForeignKey("ChaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chave");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Recebedor", b =>
                {
                    b.HasOne("Desafio.NET.Entities.Chave", "Chave")
                        .WithMany()
                        .HasForeignKey("ChaveId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Chave");
                });

            modelBuilder.Entity("Desafio.NET.Entities.Transacao", b =>
                {
                    b.HasOne("Desafio.NET.Entities.Pagador", "Pagador")
                        .WithMany()
                        .HasForeignKey("PagadorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Desafio.NET.Entities.Recebedor", "Recebedor")
                        .WithMany()
                        .HasForeignKey("RecebedorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Pagador");

                    b.Navigation("Recebedor");
                });
#pragma warning restore 612, 618
        }
    }
}
