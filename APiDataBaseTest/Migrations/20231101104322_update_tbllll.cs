using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class update_tbllll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OHCL_Cryptos_CryptoId",
                table: "OHCL");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OHCL",
                table: "OHCL");

            migrationBuilder.RenameTable(
                name: "OHCL",
                newName: "OHCLs");

            migrationBuilder.RenameIndex(
                name: "IX_OHCL_CryptoId",
                table: "OHCLs",
                newName: "IX_OHCLs_CryptoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OHCLs",
                table: "OHCLs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OHCLs_Cryptos_CryptoId",
                table: "OHCLs",
                column: "CryptoId",
                principalTable: "Cryptos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OHCLs_Cryptos_CryptoId",
                table: "OHCLs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OHCLs",
                table: "OHCLs");

            migrationBuilder.RenameTable(
                name: "OHCLs",
                newName: "OHCL");

            migrationBuilder.RenameIndex(
                name: "IX_OHCLs_CryptoId",
                table: "OHCL",
                newName: "IX_OHCL_CryptoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OHCL",
                table: "OHCL",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OHCL_Cryptos_CryptoId",
                table: "OHCL",
                column: "CryptoId",
                principalTable: "Cryptos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
