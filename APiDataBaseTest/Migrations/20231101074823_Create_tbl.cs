using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class Create_tbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "Cryptos",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CryptoId = table.Column<int>(type: "int", nullable: false),
                    symbol = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cryptos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CryptoInfos",
                columns: table => new
                {
                    CryptoInfoid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    current_price = table.Column<double>(type: "float", nullable: true),
                    market_cap = table.Column<double>(type: "float", nullable: true),
                    total_volume = table.Column<double>(type: "float", nullable: true),
                    last_updated = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CryptoId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CryptoInfos", x => x.CryptoInfoid);
                    table.ForeignKey(
                        name: "FK_CryptoInfos_Cryptos_CryptoId",
                        column: x => x.CryptoId,
                        principalTable: "Cryptos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CryptoInfos_CryptoId",
                table: "CryptoInfos",
                column: "CryptoId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "CryptoInfos");

            migrationBuilder.DropTable(
                name: "Cryptos");
        }
    }
}
