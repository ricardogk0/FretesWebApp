using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FretesWebApplication.Migrations
{
    public partial class Inital3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Produto_ProdutoIdProduto",
                table: "Frete");

            migrationBuilder.DropForeignKey(
                name: "FK_Frete_Veiculo_VeiculoIdVeiculo",
                table: "Frete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Produto",
                table: "Produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Frete",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_ProdutoIdProduto",
                table: "Frete");

            migrationBuilder.DropIndex(
                name: "IX_Frete_VeiculoIdVeiculo",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "ProdutoIdProduto",
                table: "Frete");

            migrationBuilder.DropColumn(
                name: "VeiculoIdVeiculo",
                table: "Frete");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "veiculo");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "usuario");

            migrationBuilder.RenameTable(
                name: "Produto",
                newName: "produto");

            migrationBuilder.RenameTable(
                name: "Frete",
                newName: "frete");

            migrationBuilder.RenameColumn(
                name: "Denominacao",
                table: "veiculo",
                newName: "denominacao");

            migrationBuilder.RenameColumn(
                name: "TipoVeiculo",
                table: "veiculo",
                newName: "tipo_veiculo");

            migrationBuilder.RenameColumn(
                name: "PesoVeiculo",
                table: "veiculo",
                newName: "peso_veiculo");

            migrationBuilder.RenameColumn(
                name: "IdVeiculo",
                table: "veiculo",
                newName: "id_veiculo");

            migrationBuilder.RenameColumn(
                name: "TipoUsuario",
                table: "usuario",
                newName: "tipo_usuario");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "usuario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Denominacao",
                table: "produto",
                newName: "denominacao");

            migrationBuilder.RenameColumn(
                name: "PesoProduto",
                table: "produto",
                newName: "peso_produto");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "produto",
                newName: "id_produto");

            migrationBuilder.RenameColumn(
                name: "IdVeiculo",
                table: "frete",
                newName: "id_veiculo");

            migrationBuilder.RenameColumn(
                name: "IdProduto",
                table: "frete",
                newName: "id_produto");

            migrationBuilder.RenameColumn(
                name: "IdFrete",
                table: "frete",
                newName: "id_frete");

            migrationBuilder.AddPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo",
                column: "id_veiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuario",
                table: "usuario",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_produto",
                table: "produto",
                column: "id_produto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_frete",
                table: "frete",
                column: "id_frete");

            migrationBuilder.CreateIndex(
                name: "IX_frete_id_produto",
                table: "frete",
                column: "id_produto");

            migrationBuilder.CreateIndex(
                name: "IX_frete_id_veiculo",
                table: "frete",
                column: "id_veiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_frete_produto_id_produto",
                table: "frete",
                column: "id_produto",
                principalTable: "produto",
                principalColumn: "id_produto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_frete_veiculo_id_veiculo",
                table: "frete",
                column: "id_veiculo",
                principalTable: "veiculo",
                principalColumn: "id_veiculo",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_frete_produto_id_produto",
                table: "frete");

            migrationBuilder.DropForeignKey(
                name: "FK_frete_veiculo_id_veiculo",
                table: "frete");

            migrationBuilder.DropPrimaryKey(
                name: "PK_veiculo",
                table: "veiculo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuario",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_produto",
                table: "produto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_frete",
                table: "frete");

            migrationBuilder.DropIndex(
                name: "IX_frete_id_produto",
                table: "frete");

            migrationBuilder.DropIndex(
                name: "IX_frete_id_veiculo",
                table: "frete");

            migrationBuilder.RenameTable(
                name: "veiculo",
                newName: "Veiculo");

            migrationBuilder.RenameTable(
                name: "usuario",
                newName: "Usuario");

            migrationBuilder.RenameTable(
                name: "produto",
                newName: "Produto");

            migrationBuilder.RenameTable(
                name: "frete",
                newName: "Frete");

            migrationBuilder.RenameColumn(
                name: "denominacao",
                table: "Veiculo",
                newName: "Denominacao");

            migrationBuilder.RenameColumn(
                name: "tipo_veiculo",
                table: "Veiculo",
                newName: "TipoVeiculo");

            migrationBuilder.RenameColumn(
                name: "peso_veiculo",
                table: "Veiculo",
                newName: "PesoVeiculo");

            migrationBuilder.RenameColumn(
                name: "id_veiculo",
                table: "Veiculo",
                newName: "IdVeiculo");

            migrationBuilder.RenameColumn(
                name: "tipo_usuario",
                table: "Usuario",
                newName: "TipoUsuario");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Usuario",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "denominacao",
                table: "Produto",
                newName: "Denominacao");

            migrationBuilder.RenameColumn(
                name: "peso_produto",
                table: "Produto",
                newName: "PesoProduto");

            migrationBuilder.RenameColumn(
                name: "id_produto",
                table: "Produto",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "id_veiculo",
                table: "Frete",
                newName: "IdVeiculo");

            migrationBuilder.RenameColumn(
                name: "id_produto",
                table: "Frete",
                newName: "IdProduto");

            migrationBuilder.RenameColumn(
                name: "id_frete",
                table: "Frete",
                newName: "IdFrete");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoIdProduto",
                table: "Frete",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VeiculoIdVeiculo",
                table: "Frete",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "IdVeiculo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "IdUsuario");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Produto",
                table: "Produto",
                column: "IdProduto");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Frete",
                table: "Frete",
                column: "IdFrete");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_ProdutoIdProduto",
                table: "Frete",
                column: "ProdutoIdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_Frete_VeiculoIdVeiculo",
                table: "Frete",
                column: "VeiculoIdVeiculo");

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Produto_ProdutoIdProduto",
                table: "Frete",
                column: "ProdutoIdProduto",
                principalTable: "Produto",
                principalColumn: "IdProduto",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Frete_Veiculo_VeiculoIdVeiculo",
                table: "Frete",
                column: "VeiculoIdVeiculo",
                principalTable: "Veiculo",
                principalColumn: "IdVeiculo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
