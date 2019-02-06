using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueTengoEnMiNevera.Data.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Tiempo",
                table: "Receta",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Tiempo",
                table: "Receta",
                nullable: true,
                oldClrType: typeof(DateTime));
        }
    }
}
