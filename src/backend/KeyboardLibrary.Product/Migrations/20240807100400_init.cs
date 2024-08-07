using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyboardLibrary.Product.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Keycaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SourceUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keycaps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KeycapImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KeycapId = table.Column<int>(type: "int", nullable: true),
                    KeycapEntityId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeycapImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeycapImages_Keycaps_KeycapEntityId",
                        column: x => x.KeycapEntityId,
                        principalTable: "Keycaps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeycapImages_Keycaps_KeycapId",
                        column: x => x.KeycapId,
                        principalTable: "Keycaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeycapImages_KeycapEntityId",
                table: "KeycapImages",
                column: "KeycapEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_KeycapImages_KeycapId",
                table: "KeycapImages",
                column: "KeycapId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeycapImages");

            migrationBuilder.DropTable(
                name: "Keycaps");
        }
    }
}
