using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoClientes.Migrations
{
    public partial class SegundoMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Cliente");
        }
    }
}
