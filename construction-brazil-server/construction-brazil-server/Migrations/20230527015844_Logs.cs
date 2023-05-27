using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace construction_brazil_server.Migrations
{
    /// <inheritdoc />
    public partial class Logs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "ExceptionLoggings",
                schema: "dbo",
                columns: table => new
                {
                    ExceptionLoggingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "varchar(max)", nullable: false),
                    InnerExceptionMessage = table.Column<string>(type: "varchar(max)", nullable: false),
                    StackTrace = table.Column<string>(type: "varchar(max)", nullable: false),
                    Source = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Type = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExceptionLoggings", x => x.ExceptionLoggingId);
                });

            migrationBuilder.CreateTable(
                name: "LoggingTypes",
                schema: "dbo",
                columns: table => new
                {
                    LoggingTypeId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(max)", nullable: false),
                    Description = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoggingTypes", x => x.LoggingTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationLoggings",
                schema: "dbo",
                columns: table => new
                {
                    ApplicationLoggingId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoggingTypeId = table.Column<long>(type: "bigint", nullable: true),
                    ExceptionLoggingId = table.Column<long>(type: "bigint", nullable: true),
                    Message = table.Column<string>(type: "varchar(max)", nullable: false),
                    ControllerName = table.Column<string>(type: "varchar(128)", maxLength: 128, nullable: false),
                    MethodName = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTimeOffset>(type: "datetimeoffset(7)", nullable: false, defaultValueSql: "(getutcdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationLoggings", x => x.ApplicationLoggingId);
                    table.ForeignKey(
                        name: "FK_ApplicationLoggings_ExceptionLoggings_ExceptionLoggingId",
                        column: x => x.ExceptionLoggingId,
                        principalSchema: "dbo",
                        principalTable: "ExceptionLoggings",
                        principalColumn: "ExceptionLoggingId");
                    table.ForeignKey(
                        name: "FK_ApplicationLoggings_LoggingTypes_LoggingTypeId",
                        column: x => x.LoggingTypeId,
                        principalSchema: "dbo",
                        principalTable: "LoggingTypes",
                        principalColumn: "LoggingTypeId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_CreatedOn",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_ExceptionLoggingId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "ExceptionLoggingId");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationLoggings_LoggingTypeId",
                schema: "dbo",
                table: "ApplicationLoggings",
                column: "LoggingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ExceptionLoggings_Type_CreatedOn",
                schema: "dbo",
                table: "ExceptionLoggings",
                columns: new[] { "Type", "CreatedOn" });

            migrationBuilder.CreateIndex(
                name: "IX_LoggingTypes_CreatedOn",
                schema: "dbo",
                table: "LoggingTypes",
                column: "CreatedOn");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationLoggings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExceptionLoggings",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "LoggingTypes",
                schema: "dbo");
        }
    }
}
