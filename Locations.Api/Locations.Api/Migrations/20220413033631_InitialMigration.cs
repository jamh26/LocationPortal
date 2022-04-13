using Microsoft.EntityFrameworkCore.Migrations;

namespace Locations.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PhysicalAddress = table.Column<string>(maxLength: 250, nullable: false),
                    ZipCode = table.Column<string>(maxLength: 5, nullable: false),
                    City = table.Column<string>(maxLength: 250, nullable: false),
                    State = table.Column<string>(maxLength: 250, nullable: false),
                    Country = table.Column<string>(maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
