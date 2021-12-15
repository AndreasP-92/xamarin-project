using Microsoft.EntityFrameworkCore.Migrations;

namespace XamarinProjectBackend.Migrations
{
    public partial class addNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "importedPlaces",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    lat = table.Column<double>(type: "float", nullable: false),
                    lon = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "importedPlaces");
        }
    }
}
