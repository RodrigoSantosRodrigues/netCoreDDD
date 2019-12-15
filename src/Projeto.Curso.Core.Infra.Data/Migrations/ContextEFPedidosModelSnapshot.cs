﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projeto.Curso.Core.Infra.Data.Context;

namespace Projeto.Curso.Core.Infra.Data.Migrations
{
    [DbContext(typeof(ContextEFPedidos))]
    partial class ContextEFPedidosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Projeto.Curso.Core.Domain.Pedidos.AgregacaoPedidos.ItensPedidos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdPedido");

                    b.Property<int>("IdProduto");

                    b.Property<int>("Qtd");

                    b.HasKey("Id");

                    b.HasIndex("IdPedido");

                    b.HasIndex("IdProduto");

                    b.ToTable("ItensPedidos");
                });

            modelBuilder.Entity("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Apelido")
                        .IsUnique();

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.AgregacaoPedidos.Pedidoss", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataEntrega")
                        .HasColumnType("DateTime");

                    b.Property<DateTime>("DataPedido")
                        .HasColumnType("DateTime");

                    b.Property<int>("IdCliente");

                    b.Property<string>("Observacao")
                        .HasColumnType("varchar(4000)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Apelido")
                        .IsUnique();

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.Entidades.Produtos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apelido")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<int>("IdFornecedor");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Unidade")
                        .IsRequired()
                        .HasColumnType("varchar(2)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal");

                    b.HasKey("Id");

                    b.HasIndex("IdFornecedor");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("Projeto.Curso.Core.Domain.Pedidos.AgregacaoPedidos.ItensPedidos", b =>
                {
                    b.HasOne("Projeto.Curso.Domain.Pedidos.AgregacaoPedidos.Pedidoss", "Pedido")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("IdPedido")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Projeto.Curso.Domain.Pedidos.Entidades.Produtos", "Produto")
                        .WithMany("ItensPedidos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes", b =>
                {
                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.CpfCnpjVo", "CPFCNPJ", b1 =>
                        {
                            b1.Property<int>("ClientesId");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("CpfCnpj")
                                .HasColumnType("varchar(14)");

                            b1.HasIndex("Numero")
                                .IsUnique();

                            b1.ToTable("Clientes");

                            b1.HasOne("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes")
                                .WithOne("CPFCNPJ")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.CpfCnpjVo", "ClientesId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EmailVo", "Email", b1 =>
                        {
                            b1.Property<int>("ClientesId");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(100)");

                            b1.ToTable("Clientes");

                            b1.HasOne("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes")
                                .WithOne("Email")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.EmailVo", "ClientesId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO", "Endereco", b1 =>
                        {
                            b1.Property<int>("ClientesId");

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Endereco")
                                .HasColumnType("varchar(100)");

                            b1.ToTable("Clientes");

                            b1.HasOne("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes")
                                .WithOne("Endereco")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO", "ClientesId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.CepVO", "CEP", b2 =>
                                {
                                    b2.Property<int>("EnderecoVOClientesId");

                                    b2.Property<string>("Codigo")
                                        .HasColumnName("CEP")
                                        .HasColumnType("varchar(8)");

                                    b2.ToTable("Clientes");

                                    b2.HasOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO")
                                        .WithOne("CEP")
                                        .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.CepVO", "EnderecoVOClientesId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.UfVO", "UF", b2 =>
                                {
                                    b2.Property<int>("EnderecoVOClientesId");

                                    b2.Property<string>("UF")
                                        .HasColumnName("UF")
                                        .HasColumnType("varchar(2)");

                                    b2.ToTable("Clientes");

                                    b2.HasOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO")
                                        .WithOne("UF")
                                        .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.UfVO", "EnderecoVOClientesId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.AgregacaoPedidos.Pedidoss", b =>
                {
                    b.HasOne("Projeto.Curso.Core.Domain.Pedidos.Entidades.Clientes", "Cliente")
                        .WithMany("Pedidos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores", b =>
                {
                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.CpfCnpjVo", "CPFCNPJ", b1 =>
                        {
                            b1.Property<int>("FornecedoresId");

                            b1.Property<string>("Numero")
                                .IsRequired()
                                .HasColumnName("CpfCnpj")
                                .HasColumnType("varchar(14)");

                            b1.HasIndex("Numero")
                                .IsUnique();

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores")
                                .WithOne("CPFCNPJ")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.CpfCnpjVo", "FornecedoresId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EmailVo", "Email", b1 =>
                        {
                            b1.Property<int>("FornecedoresId");

                            b1.Property<string>("Endereco")
                                .IsRequired()
                                .HasColumnName("Email")
                                .HasColumnType("varchar(100)");

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores")
                                .WithOne("Email")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.EmailVo", "FornecedoresId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO", "Endereco", b1 =>
                        {
                            b1.Property<int>("FornecedoresId");

                            b1.Property<string>("Bairro")
                                .HasColumnName("Bairro")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Cidade")
                                .IsRequired()
                                .HasColumnName("Cidade")
                                .HasColumnType("varchar(30)");

                            b1.Property<string>("Logradouro")
                                .IsRequired()
                                .HasColumnName("Endereco")
                                .HasColumnType("varchar(100)");

                            b1.ToTable("Fornecedores");

                            b1.HasOne("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores")
                                .WithOne("Endereco")
                                .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO", "FornecedoresId")
                                .OnDelete(DeleteBehavior.Cascade);

                            b1.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.CepVO", "CEP", b2 =>
                                {
                                    b2.Property<int>("EnderecoVOFornecedoresId");

                                    b2.Property<string>("Codigo")
                                        .HasColumnName("CEP")
                                        .HasColumnType("varchar(8)");

                                    b2.ToTable("Fornecedores");

                                    b2.HasOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO")
                                        .WithOne("CEP")
                                        .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.CepVO", "EnderecoVOFornecedoresId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });

                            b1.OwnsOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.UfVO", "UF", b2 =>
                                {
                                    b2.Property<int>("EnderecoVOFornecedoresId");

                                    b2.Property<string>("UF")
                                        .HasColumnName("UF")
                                        .HasColumnType("varchar(2)");

                                    b2.ToTable("Fornecedores");

                                    b2.HasOne("Projeto.Curso.Core.Domain.Shared.ValueObjects.EnderecoVO")
                                        .WithOne("UF")
                                        .HasForeignKey("Projeto.Curso.Core.Domain.Shared.ValueObjects.UfVO", "EnderecoVOFornecedoresId")
                                        .OnDelete(DeleteBehavior.Cascade);
                                });
                        });
                });

            modelBuilder.Entity("Projeto.Curso.Domain.Pedidos.Entidades.Produtos", b =>
                {
                    b.HasOne("Projeto.Curso.Domain.Pedidos.Entidades.Fornecedores", "Fornecedor")
                        .WithMany("Produtos")
                        .HasForeignKey("IdFornecedor")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
