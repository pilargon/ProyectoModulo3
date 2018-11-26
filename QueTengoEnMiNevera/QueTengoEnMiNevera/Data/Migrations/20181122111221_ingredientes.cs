using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QueTengoEnMiNevera.Data.Migrations
{
    public partial class ingredientes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Tiempo",
                table: "Receta",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "IngredientePrincipal",
                table: "Receta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IngredientesSecundarios",
                table: "Receta",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IngredientesTerciarios",
                table: "Receta",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientePrincipal",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "IngredientesSecundarios",
                table: "Receta");

            migrationBuilder.DropColumn(
                name: "IngredientesTerciarios",
                table: "Receta");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Tiempo",
                table: "Receta",
                nullable: false,
                oldClrType: typeof(int));
        }
    }
}
