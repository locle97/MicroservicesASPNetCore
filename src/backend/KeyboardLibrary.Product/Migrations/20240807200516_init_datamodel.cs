using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KeyboardLibrary.Product.Migrations
{
    /// <inheritdoc />
    public partial class init_datamodel : Migration
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
                    KeycapId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeycapImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeycapImages_Keycaps_KeycapId",
                        column: x => x.KeycapId,
                        principalTable: "Keycaps",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_KeycapImages_Keycaps_KeycapId1",
                        column: x => x.KeycapId1,
                        principalTable: "Keycaps",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeycapImages_KeycapId",
                table: "KeycapImages",
                column: "KeycapId");

            migrationBuilder.CreateIndex(
                name: "IX_KeycapImages_KeycapId1",
                table: "KeycapImages",
                column: "KeycapId1");
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
