﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using construction_brazil_server.DataStores;

#nullable disable

namespace construction_brazil_server.Migrations
{
    [DbContext(typeof(ConstructionBrazil_Context))]
    [Migration("20230529031816_ProfissionalKey")]
    partial class ProfissionalKey
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.ApplicationLogging", b =>
                {
                    b.Property<long>("ApplicationLoggingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ApplicationLoggingId"));

                    b.Property<string>("ControllerName")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("varchar(128)");

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<long?>("ExceptionLoggingId")
                        .HasColumnType("bigint");

                    b.Property<long>("LoggingTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("MethodName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("ApplicationLoggingId");

                    b.HasIndex("ExceptionLoggingId");

                    b.HasIndex("LoggingTypeId", "Criado");

                    b.ToTable("ApplicationLoggings", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Contato", b =>
                {
                    b.Property<long>("ContatoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ContatoId"));

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<DateTimeOffset>("DataDeNascimento")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<long>("DddId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("Modificado")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Profissao")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<long>("SexoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.HasKey("ContatoId");

                    b.HasIndex("DddId");

                    b.HasIndex("SexoId");

                    b.HasIndex("Cpf", "Nome", "Sobrenome", "DataDeNascimento", "Criado");

                    b.ToTable("Contatos", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Endereco", b =>
                {
                    b.Property<long>("EnderecoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EnderecoId"));

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("varchar(9)");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasMaxLength(85)
                        .HasColumnType("varchar(85)");

                    b.Property<string>("Complemento")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<long>("EstadoId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("Modificado")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("varchar(64)");

                    b.HasKey("EnderecoId");

                    b.HasIndex("EstadoId");

                    b.HasIndex("Cep", "Criado");

                    b.ToTable("Enderecos", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.ExceptionLogging", b =>
                {
                    b.Property<long>("ExceptionLoggingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ExceptionLoggingId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("InnerExceptionMessage")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("StackTrace")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.HasKey("ExceptionLoggingId");

                    b.HasIndex("Type", "Criado");

                    b.ToTable("ExceptionLoggings", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Profissional", b =>
                {
                    b.Property<long>("ProfissionalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProfissionalId"));

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<long>("ContatoId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset?>("Modificado")
                        .HasColumnType("datetimeoffset(7)");

                    b.Property<string>("Observacoes")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Pis")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Pix")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<Guid>("ProfissionalKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("(NEWID())");

                    b.Property<long>("ProfissionalTypeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Rg")
                        .IsRequired()
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<bool>("Sindicalizado")
                        .HasColumnType("bit");

                    b.HasKey("ProfissionalId");

                    b.HasIndex("ContatoId");

                    b.HasIndex("EnderecoId");

                    b.HasIndex("ProfissionalTypeId", "ContatoId", "EnderecoId", "Criado");

                    b.ToTable("Profissionals", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Static.Ddd", b =>
                {
                    b.Property<long>("DddId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("DddId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<int>("NumeroDeDdd")
                        .HasColumnType("int");

                    b.HasKey("DddId");

                    b.HasIndex("NumeroDeDdd", "Criado");

                    b.ToTable("Ddds", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Static.Estado", b =>
                {
                    b.Property<long>("EstadoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("EstadoId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Uf")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("EstadoId");

                    b.HasIndex("Nome", "Uf", "Criado");

                    b.ToTable("Estados", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Static.LoggingType", b =>
                {
                    b.Property<long>("LoggingTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("LoggingTypeId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("varchar(256)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(max)");

                    b.HasKey("LoggingTypeId");

                    b.HasIndex("Criado");

                    b.ToTable("LoggingTypes", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Static.ProfissionalType", b =>
                {
                    b.Property<long>("ProfissionalTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("ProfissionalTypeId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("ProfissionalTypeId");

                    b.HasIndex("Tipo", "Criado");

                    b.ToTable("ProfissionalTypes", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Static.Sexo", b =>
                {
                    b.Property<long>("SexoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("SexoId"));

                    b.Property<DateTimeOffset>("Criado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetimeoffset(7)")
                        .HasDefaultValueSql("(getutcdate())");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.HasKey("SexoId");

                    b.HasIndex("Tipo", "Criado");

                    b.ToTable("Sexos", "dbo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.ApplicationLogging", b =>
                {
                    b.HasOne("construction_brazil_server.Entities.Logs.ExceptionLogging", "ExceptionLogging")
                        .WithMany()
                        .HasForeignKey("ExceptionLoggingId");

                    b.HasOne("construction_brazil_server.Entities.Static.LoggingType", "LoggingType")
                        .WithMany()
                        .HasForeignKey("LoggingTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ExceptionLogging");

                    b.Navigation("LoggingType");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Contato", b =>
                {
                    b.HasOne("construction_brazil_server.Entities.Static.Ddd", "Ddd")
                        .WithMany()
                        .HasForeignKey("DddId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("construction_brazil_server.Entities.Static.Sexo", "Sexo")
                        .WithMany()
                        .HasForeignKey("SexoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ddd");

                    b.Navigation("Sexo");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Endereco", b =>
                {
                    b.HasOne("construction_brazil_server.Entities.Static.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("construction_brazil_server.Entities.Logs.Profissional", b =>
                {
                    b.HasOne("construction_brazil_server.Entities.Logs.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("construction_brazil_server.Entities.Logs.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("construction_brazil_server.Entities.Static.ProfissionalType", "ProfissionalType")
                        .WithMany()
                        .HasForeignKey("ProfissionalTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Contato");

                    b.Navigation("Endereco");

                    b.Navigation("ProfissionalType");
                });
#pragma warning restore 612, 618
        }
    }
}
