using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OptionsPattern.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "errorlogs",
                columns: table => new
                {
                    log_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    logged_at = table.Column<DateTime>(type: "datetime", nullable: false),
                    error_message = table.Column<string>(type: "varchar(max)", nullable: false),
                    method_name = table.Column<string>(type: "varchar(20)", nullable: false),
                    source = table.Column<string>(type: "varchar(20)", nullable: false),
                    details = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errorlogs", x => x.log_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "errorlogs");
        }
    }
}
