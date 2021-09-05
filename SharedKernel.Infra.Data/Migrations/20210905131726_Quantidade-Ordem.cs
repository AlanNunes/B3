using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedKernel.Infra.Data.Migrations
{
    public partial class QuantidadeOrdem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Ordens",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Ordens");
        }
    }
}
