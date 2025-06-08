using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FilmApp.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Film",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AAr = table.Column<int>(type: "int", nullable: false),
                    Poeng = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Film", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Film",
                columns: new[] { "Id", "AAr", "Navn", "Poeng" },
                values: new object[,]
                {
                    { 1, 2016, "How To Be Single", 5 },
                    { 2, 2022, "Senior Year", 3 },
                    { 3, 2020, "The Wrong Missy", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Film");
        }
    }
}
