using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FretesWebApplication.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "senha",
                table: "usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "senha",
                table: "usuario");
        }
    }
}
