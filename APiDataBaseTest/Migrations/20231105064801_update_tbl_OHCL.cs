using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class update_tbl_OHCL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Volume",
                table: "OHCLs",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Volume",
                table: "OHCLs");
        }
    }
}
