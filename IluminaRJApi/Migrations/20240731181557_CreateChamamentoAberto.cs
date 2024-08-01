using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IluminaRJApi.Migrations
{
    public partial class CreateChamamentoAberto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ChamamentoAberto",
                table: "Municipios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChamamentoAberto",
                table: "Municipios");
        }
    }
}
