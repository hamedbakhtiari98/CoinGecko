using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class _update_ohlc_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeStamp",
                table: "OHCLs");

            migrationBuilder.AddColumn<string>(
                name: "dateTime",
                table: "OHCLs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "dateTime",
                table: "OHCLs");

            migrationBuilder.AddColumn<double>(
                name: "TimeStamp",
                table: "OHCLs",
                type: "float",
                nullable: true);
        }
    }
}
