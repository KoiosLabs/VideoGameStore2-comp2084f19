using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VideoGameStore2.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Developer",
                columns: table => new
                {
                    DeveloperId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Developer", x => x.DeveloperId);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    MinimumRequirements = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    DeveloperId = table.Column<int>(nullable: false),
                    GenreId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Game_Developer_DeveloperId",
                        column: x => x.DeveloperId,
                        principalTable: "Developer",
                        principalColumn: "DeveloperId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Game_Genre_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genre",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Developer",
                columns: new[] { "DeveloperId", "City", "Name", "StreetAddress", "Telephone" },
                values: new object[,]
                {
                    { 1, "Tokyo", "Konami", "A road in Japan", "123456789" },
                    { 2, "Mexico City", "Squad", "Probably poorly defined", "0987654321" },
                    { 3, "Montreal", "Uber Entertainment", "some french road", "83798273489" }
                });

            migrationBuilder.InsertData(
                table: "Genre",
                columns: new[] { "GenreId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Games where you shoot things with guns", "First Person Shooters" },
                    { 2, "Pretending to be real life, but not", "Simulation" }
                });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "DeveloperId", "GenreId", "MinimumRequirements", "Name", "Price" },
                values: new object[] { 3, "Sneak a lot", 1, 1, "PS4", "Metal Gear Solid", 59.99m });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "DeveloperId", "GenreId", "MinimumRequirements", "Name", "Price" },
                values: new object[] { 4, "Science the shit out stuff", 2, 2, "A Computer", "Kerbal Space Program", 6.99m });

            migrationBuilder.InsertData(
                table: "Game",
                columns: new[] { "Id", "Description", "DeveloperId", "GenreId", "MinimumRequirements", "Name", "Price" },
                values: new object[] { 5, "Science the shit out stuff, Harder", 3, 2, "A Computer", "Kerbal Space Program 2", 69.99m });

            migrationBuilder.CreateIndex(
                name: "IX_Game_DeveloperId",
                table: "Game",
                column: "DeveloperId");

            migrationBuilder.CreateIndex(
                name: "IX_Game_GenreId",
                table: "Game",
                column: "GenreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Developer");

            migrationBuilder.DropTable(
                name: "Genre");
        }
    }
}
