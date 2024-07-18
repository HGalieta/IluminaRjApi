using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IluminaRJApi.Migrations
{
    public partial class AddCnpjEstadoToEmpresa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Empresas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Empresas",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Empresas");
        }
    }
}
