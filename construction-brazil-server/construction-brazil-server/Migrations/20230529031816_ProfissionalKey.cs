using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construction_brazil_server.Migrations
{
    /// <inheritdoc />
    public partial class ProfissionalKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProfissionalKey",
                schema: "dbo",
                table: "Profissionals",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "(NEWID())");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfissionalKey",
                schema: "dbo",
                table: "Profissionals");
        }
    }
}
