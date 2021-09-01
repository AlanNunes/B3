using Microsoft.EntityFrameworkCore.Migrations;

namespace SharedKernel.Infra.Data.Migrations
{
    public partial class investidor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InvestidorId",
                table: "Ordens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Investidor",
                columns: table => new
                {
                    InvestidorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PrimeiroNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimoNome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Investidor", x => x.InvestidorId);
                });

            migrationBuilder.CreateTable(
                name: "DepositoAcaoInvestidor",
                columns: table => new
                {
                    DepositoAcaoInvestidorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PapelId = table.Column<int>(type: "int", nullable: false),
                    InvestidorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepositoAcaoInvestidor", x => x.DepositoAcaoInvestidorId);
                    table.ForeignKey(
                        name: "FK_DepositoAcaoInvestidor_Investidor_InvestidorId",
                        column: x => x.InvestidorId,
                        principalTable: "Investidor",
                        principalColumn: "InvestidorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepositoAcaoInvestidor_Papel_PapelId",
                        column: x => x.PapelId,
                        principalTable: "Papel",
                        principalColumn: "PapelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordens_InvestidorId",
                table: "Ordens",
                column: "InvestidorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoAcaoInvestidor_InvestidorId",
                table: "DepositoAcaoInvestidor",
                column: "InvestidorId");

            migrationBuilder.CreateIndex(
                name: "IX_DepositoAcaoInvestidor_PapelId",
                table: "DepositoAcaoInvestidor",
                column: "PapelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ordens_Investidor_InvestidorId",
                table: "Ordens",
                column: "InvestidorId",
                principalTable: "Investidor",
                principalColumn: "InvestidorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ordens_Investidor_InvestidorId",
                table: "Ordens");

            migrationBuilder.DropTable(
                name: "DepositoAcaoInvestidor");

            migrationBuilder.DropTable(
                name: "Investidor");

            migrationBuilder.DropIndex(
                name: "IX_Ordens_InvestidorId",
                table: "Ordens");

            migrationBuilder.DropColumn(
                name: "InvestidorId",
                table: "Ordens");
        }
    }
}
