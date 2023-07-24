using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace FretesWebApplication.Migrations
{
    public partial class Inital1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frete",
                columns: table => new
                {
                    IdFrete = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    distancia = table.Column<double>(type: "double precision", nullable: false),
                    IdVeiculo = table.Column<int>(type: "integer", nullable: false),
                    VeiculoIdVeiculo = table.Column<int>(type: "integer", nullable: false),
                    IdProduto = table.Column<int>(type: "integer", nullable: false),
                    ProdutoIdProduto = table.Column<int>(type: "integer", nullable: false),
                    Taxa = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frete", x => x.IdFrete);
                    table.ForeignKey(
                        name: "FK_Frete_Produto_ProdutoIdProduto",
                        column: x => x.ProdutoIdProduto,
                        principalTable: "Produto",
                        principalColumn: "IdProduto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frete_Veiculo_VeiculoIdVeiculo",
                        column: x => x.VeiculoIdVeiculo,
                        principalTable: "Veiculo",
                        principalColumn: "IdVeiculo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frete_ProdutoIdProduto",
                table: "Frete",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_VeiculoIdVeiculo",
                table: "Frete",
                column: "VeiculoIdVeiculo");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frete");
        }
    }
}
