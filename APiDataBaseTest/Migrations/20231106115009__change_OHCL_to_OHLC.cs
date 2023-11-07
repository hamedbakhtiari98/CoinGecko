using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class _change_OHCL_to_OHLC : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OHCLs");

            migrationBuilder.CreateTable(
                name: "OHLCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    volume = table.Column<double>(type: "float", nullable: true),
                    O = table.Column<double>(type: "float", nullable: true),
                    H = table.Column<double>(type: "float", nullable: true),
                    L = table.Column<double>(type: "float", nullable: true),
                    C = table.Column<double>(type: "float", nullable: true),
                    CryptoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OHLCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OHLCs_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OHLCs_CryptoId",
                table: "OHLCs",
                column: "CryptoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OHLCs");

            migrationBuilder.CreateTable(
                name: "OHCLs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CryptoId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    C = table.Column<double>(type: "float", nullable: true),
                    H = table.Column<double>(type: "float", nullable: true),
                    L = table.Column<double>(type: "float", nullable: true),
                    O = table.Column<double>(type: "float", nullable: true),
                    dateTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    volume = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OHCLs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OHCLs_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OHCLs_CryptoId",
                table: "OHCLs",
                column: "CryptoId");
        }
    }
}
