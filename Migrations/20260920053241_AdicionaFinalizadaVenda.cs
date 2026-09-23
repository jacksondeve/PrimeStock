using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrimeStock.API.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaFinalizadaVenda : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Finalizada",
                table: "Vendas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Finalizada",
                table: "Vendas");
        }
    }
}
