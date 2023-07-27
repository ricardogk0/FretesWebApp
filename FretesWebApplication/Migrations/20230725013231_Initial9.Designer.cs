﻿// <auto-generated />
using FretesWebApplication.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FretesWebApplication.Migrations
{
    [DbContext(typeof(FretesWebApplicationContext))]
    [Migration("20230725013231_Initial9")]
    partial class Initial9
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("FretesWebApplication.Models.Frete", b =>
                {
                    b.Property<int>("IdFrete")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_frete");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdFrete"));

                    b.Property<double>("Distancia")
                        .HasColumnType("double precision")
                        .HasColumnName("distancia");

                    b.Property<int>("IdProduto")
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    b.Property<int>("IdVeiculo")
                        .HasColumnType("integer")
                        .HasColumnName("id_veiculo");

                    b.Property<double>("Taxa")
                        .HasColumnType("double precision");

                    b.Property<double>("ValorTotal")
                        .HasColumnType("double precision")
                        .HasColumnName("valor_total");

                    b.HasKey("IdFrete");

                    b.HasIndex("IdProduto");

                    b.HasIndex("IdVeiculo");

                    b.ToTable("frete");
                });

            modelBuilder.Entity("FretesWebApplication.Models.Produto", b =>
                {
                    b.Property<int>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_produto");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdProduto"));

                    b.Property<string>("Denominacao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("denominacao");

                    b.Property<double>("PesoProduto")
                        .HasColumnType("double precision")
                        .HasColumnName("peso_produto");

                    b.HasKey("IdProduto");

                    b.ToTable("produto");
                });

            modelBuilder.Entity("FretesWebApplication.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("senha");

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("integer")
                        .HasColumnName("tipo_usuario");

                    b.HasKey("IdUsuario");

                    b.ToTable("usuario");
                });

            modelBuilder.Entity("FretesWebApplication.Models.Veiculo", b =>
                {
                    b.Property<int>("IdVeiculo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id_veiculo");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("IdVeiculo"));

                    b.Property<string>("Denominacao")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("denominacao");

                    b.Property<double>("PesoVeiculo")
                        .HasColumnType("double precision")
                        .HasColumnName("peso_veiculo");

                    b.Property<int>("TipoVeiculo")
                        .HasColumnType("integer")
                        .HasColumnName("tipo_veiculo");

                    b.HasKey("IdVeiculo");

                    b.ToTable("veiculo");
                });

            modelBuilder.Entity("FretesWebApplication.Models.Frete", b =>
                {
                    b.HasOne("FretesWebApplication.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FretesWebApplication.Models.Veiculo", "Veiculo")
                        .WithMany()
                        .HasForeignKey("IdVeiculo")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");

                    b.Navigation("Veiculo");
                });
#pragma warning restore 612, 618
        }
    }
}
