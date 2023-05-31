using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construction_brazil_server.Migrations
{
    /// <inheritdoc />
    public partial class RemovedIndexesForFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profissionals_ProfissionalTypeId_ContatoId_EnderecoId_Criado",
                schema: "dbo",
                table: "Profissionals");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId_Criado",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_Criado",
                schema: "dbo",
                table: "Profissionals",
                column: "Criado");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_ProfissionalTypeId",
                schema: "dbo",
                table: "Profissionals",
                column: "ProfissionalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_Criado",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "Criado");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "LoggingTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Profissionals_Criado",
                schema: "dbo",
                table: "Profissionals");

            migrationBuilder.DropIndex(
                name: "IX_Profissionals_ProfissionalTypeId",
                schema: "dbo",
                table: "Profissionals");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_Criado",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings");

            migrationBuilder.CreateIndex(
                name: "IX_Profissionals_ProfissionalTypeId_ContatoId_EnderecoId_Criado",
                schema: "dbo",
                table: "Profissionals",
                columns: new[] { "ProfissionalTypeId", "ContatoId", "EnderecoId", "Criado" });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId_Criado",
                schema: "dbo",
                table: "ApplicationLoggings",
                columns: new[] { "LoggingTypeId", "Criado" });
        }
    }
}
