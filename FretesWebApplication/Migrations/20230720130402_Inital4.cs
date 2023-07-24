using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FretesWebApplication.Migrations
{
    public partial class Inital4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "valor_total",
                table: "frete",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "valor_total",
                table: "frete");
        }
    }
}
