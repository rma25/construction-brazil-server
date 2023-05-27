using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construction_brazil_server.Migrations
{
    /// <inheritdoc />
    public partial class LotsOfTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationLoggings_LoggingTypes_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_CreatedOn",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Description",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "Criado");

            migrationBuilder.RenameIndex(
                name: "IX_LoggingTypes_CreatedOn",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "IX_LoggingTypes_Criado");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "ExceptionLoggings",
                newName: "Criado");

            migrationBuilder.RenameIndex(
                name: "IX_ExceptionLoggings_Type_CreatedOn",
                schema: "dbo",
                table: "ExceptionLoggings",
                newName: "IX_ExceptionLoggings_Type_Criado");

            migrationBuilder.RenameColumn(
                name: "Message",
                schema: "dbo",
                table: "ApplicationLoggings",
                newName: "Mensagem");

            migrationBuilder.RenameColumn(
                name: "CreatedOn",
                schema: "dbo",
                table: "ApplicationLoggings",
                newName: "Criado");

            migrationBuilder.AlterColumn<long>(
                name: "LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Ddds",
                schema: "dbo",
                columns: table => new
                {
                    DddId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDeDdd = table.Column<int>(type: "int", nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ddds", x => x.DddId);
                });

            migrationBuilder.CreateTable(
                name: "Estados",
                schema: "dbo",
                columns: table => new
                {
                    EstadoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    Uf = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.EstadoId);
                });

            migrationBuilder.CreateTable(
                name: "ProfissionalTypes",
                schema: "dbo",
                columns: table => new
                {
                    ProfissionalTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfissionalTypes", x => x.ProfissionalTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Sexos",
                schema: "dbo",
                columns: table => new
                {
                    SexoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexos", x => x.SexoId);
                });

            migrationBuilder.CreateTable(
                name: "Enderecos",
                schema: "dbo",
                columns: table => new
                {
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rua = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Complemento = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    Bairro = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Cidade = table.Column<string>(type: "varchar(85)", maxLength: 85, nullable: false),
                    EstadoId = table.Column<long>(type: "bigint", nullable: false),
                    Cep = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())"),
                    Modificado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enderecos", x => x.EnderecoId);
                    table.ForeignKey(
                        name: "FK_Enderecos_Estados_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "dbo",
                        principalTable: "Estados",
                        principalColumn: "EstadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contatos",
                schema: "dbo",
                columns: table => new
                {
                    ContatoId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Sobrenome = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    Cpf = table.Column<string>(type: "varchar(14)", maxLength: 14, nullable: false),
                    DataDeNascimento = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false),
                    Telefone = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false),
                    Profissao = table.Column<string>(type: "varchar(64)", maxLength: 64, nullable: false),
                    SexoId = table.Column<long>(type: "bigint", nullable: false),
                    DddId = table.Column<long>(type: "bigint", nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())"),
                    Modificado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contatos", x => x.ContatoId);
                    table.ForeignKey(
                        name: "FK_Contatos_Ddds_DddId",
                        column: x => x.DddId,
                        principalSchema: "dbo",
                        principalTable: "Ddds",
                        principalColumn: "DddId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contatos_Sexos_SexoId",
                        column: x => x.SexoId,
                        principalSchema: "dbo",
                        principalTable: "Sexos",
                        principalColumn: "SexoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Profissionals",
                schema: "dbo",
                columns: table => new
                {
                    ProfissionalId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfissionalTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ContatoId = table.Column<long>(type: "bigint", nullable: false),
                    EnderecoId = table.Column<long>(type: "bigint", nullable: false),
                    Observacoes = table.Column<string>(type: "varchar(500)", maxLength: 500, nullable: false),
                    Pis = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    Rg = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Pix = table.Column<string>(type: "varchar(32)", maxLength: 32, nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Sindicalizado = table.Column<bool>(type: "bit", nullable: false),
                    Criado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())"),
                    Modificado = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profissionals", x => x.ProfissionalId);
                    table.ForeignKey(
                        name: "FK_Profissionals_Contatos_ContatoId",
                        column: x => x.ContatoId,
                        principalSchema: "dbo",
                        principalTable: "Contatos",
                        principalColumn: "ContatoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profissionals_Enderecos_EnderecoId",
                        column: x => x.EnderecoId,
                        principalSchema: "dbo",
                        principalTable: "Enderecos",
                        principalColumn: "EnderecoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Profissionals_ProfissionalTypes_ProfissionalTypeId",
                        column: x => x.ProfissionalTypeId,
                        principalSchema: "dbo",
                        principalTable: "ProfissionalTypes",
                        principalColumn: "ProfissionalTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId_Criado",
                schema: "dbo",
                table: "ApplicationLoggings",
                columns: new[] { "LoggingTypeId", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_Cpf_Nome_Sobrenome_DataDeNascimento_Criado",
                schema: "dbo",
                table: "Contatos",
                columns: new[] { "Cpf", "Nome", "Sobrenome", "DataDeNascimento", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_DddId",
                schema: "dbo",
                table: "Contatos",
                column: "DddId");

            migrationBuilder.CreateIndex(
                name: "IX_Contatos_SexoId",
                schema: "dbo",
                table: "Contatos",
                column: "SexoId");

            migrationBuilder.CreateIndex(
                name: "IX_Ddds_NumeroDeDdd_Criado",
                schema: "dbo",
                table: "Ddds",
                columns: new[] { "NumeroDeDdd", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_Cep_Criado",
                schema: "dbo",
                table: "Enderecos",
                columns: new[] { "Cep", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EstadoId",
                schema: "dbo",
                table: "Enderecos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estados_Nome_Uf_Criado",
                schema: "dbo",
                table: "Estados",
                columns: new[] { "Nome", "Uf", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_ContatoId",
                schema: "dbo",
                table: "Profissionals",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_EnderecoId",
                schema: "dbo",
                table: "Profissionals",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_ProfissionalTypeId_ContatoId_EnderecoId_Criado",
                schema: "dbo",
                table: "Profissionals",
                columns: new[] { "ProfissionalTypeId", "ContatoId", "EnderecoId", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_ProfissionalTypes_Tipo_Criado",
                schema: "dbo",
                table: "ProfissionalTypes",
                columns: new[] { "Tipo", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_Sexos_Tipo_Criado",
                schema: "dbo",
                table: "Sexos",
                columns: new[] { "Tipo", "Criado" });

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationLoggings_LoggingTypes_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "LoggingTypeId",
                principalSchema: "dbo",
                principalTable: "LoggingTypes",
                principalColumn: "LoggingTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationLoggings_LoggingTypes_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.DropTable(
                name: "Profissionals",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Contatos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Enderecos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ProfissionalTypes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Ddds",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Sexos",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Estados",
                schema: "dbo");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId_Criado",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.RenameColumn(
                name: "Nome",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Criado",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "CreatedOn");

            migrationBuilder.RenameIndex(
                name: "IX_LoggingTypes_Criado",
                schema: "dbo",
                table: "LoggingTypes",
                newName: "IX_LoggingTypes_CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Criado",
                schema: "dbo",
                table: "ExceptionLoggings",
                newName: "CreatedOn");

            migrationBuilder.RenameIndex(
                name: "IX_ExceptionLoggings_Type_Criado",
                schema: "dbo",
                table: "ExceptionLoggings",
                newName: "IX_ExceptionLoggings_Type_CreatedOn");

            migrationBuilder.RenameColumn(
                name: "Mensagem",
                schema: "dbo",
                table: "ApplicationLoggings",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "Criado",
                schema: "dbo",
                table: "ApplicationLoggings",
                newName: "CreatedOn");

            migrationBuilder.AlterColumn<long>(
                name: "LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_CreatedOn",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "LoggingTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationLoggings_LoggingTypes_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "LoggingTypeId",
                principalSchema: "dbo",
                principalTable: "LoggingTypes",
                principalColumn: "LoggingTypeId");
        }
    }
}
