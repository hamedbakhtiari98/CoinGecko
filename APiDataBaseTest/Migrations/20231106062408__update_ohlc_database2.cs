using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class _update_ohlc_database2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "volume",
                table: "OHCLs",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "volume",
                table: "OHCLs");
        }
    }
}
