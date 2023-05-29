using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construction_brazil_server.Migrations
{
    /// <inheritdoc />
    public partial class Contato_Email : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Ddds_DddId",
                schema: "dbo",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                schema: "dbo",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Pix",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(32)",
                maxLength: 32,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32);

            migrationBuilder.AlterColumn<string>(
                name: "Pis",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(11)",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "dbo",
                table: "LoggingTypes",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<long>(
                name: "EstadoId",
                schema: "dbo",
                table: "Enderecos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(85)",
                maxLength: 85,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(85)",
                oldMaxLength: 85);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(120)",
                maxLength: 120,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "dbo",
                table: "Contatos",
                type: "varchar(9)",
                maxLength: 9,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9);

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                schema: "dbo",
                table: "Contatos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<long>(
                name: "DddId",
                schema: "dbo",
                table: "Contatos",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Contatos",
                type: "varchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Ddds_DddId",
                schema: "dbo",
                table: "Contatos",
                column: "DddId",
                principalSchema: "dbo",
                principalTable: "Ddds",
                principalColumn: "DddId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                schema: "dbo",
                table: "Enderecos",
                column: "EstadoId",
                principalSchema: "dbo",
                principalTable: "Estados",
                principalColumn: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contatos_Ddds_DddId",
                schema: "dbo",
                table: "Contatos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                schema: "dbo",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Contatos");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pix",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldMaxLength: 32,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Pis",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                schema: "dbo",
                table: "Profissionals",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                schema: "dbo",
                table: "LoggingTypes",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rua",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EstadoId",
                schema: "dbo",
                table: "Enderecos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(85)",
                maxLength: 85,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(85)",
                oldMaxLength: 85,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                schema: "dbo",
                table: "Enderecos",
                type: "varchar(120)",
                maxLength: 120,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(120)",
                oldMaxLength: 120,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                schema: "dbo",
                table: "Contatos",
                type: "varchar(9)",
                maxLength: 9,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(9)",
                oldMaxLength: 9,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Profissao",
                schema: "dbo",
                table: "Contatos",
                type: "varchar(64)",
                maxLength: 64,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(64)",
                oldMaxLength: 64,
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DddId",
                schema: "dbo",
                table: "Contatos",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Contatos_Ddds_DddId",
                schema: "dbo",
                table: "Contatos",
                column: "DddId",
                principalSchema: "dbo",
                principalTable: "Ddds",
                principalColumn: "DddId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Estados_EstadoId",
                schema: "dbo",
                table: "Enderecos",
                column: "EstadoId",
                principalSchema: "dbo",
                principalTable: "Estados",
                principalColumn: "EstadoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
