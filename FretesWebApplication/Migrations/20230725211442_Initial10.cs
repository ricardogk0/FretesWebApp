using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FretesWebApplication.Migrations
{
    public partial class Initial10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "senha",
                table: "usuario",
                type: "text",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<string>(
                name: "salt",
                table: "usuario",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "usuario");

            migrationBuilder.AlterColumn<byte[]>(
                name: "senha",
                table: "usuario",
                type: "bytea",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
