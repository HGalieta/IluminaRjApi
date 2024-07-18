using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IluminaRJApi.Migrations
{
    public partial class AddContatoFundos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Contato",
                table: "Fundos",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Contato",
                table: "Fundos");
        }
    }
}
