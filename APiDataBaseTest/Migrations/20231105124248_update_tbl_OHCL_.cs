using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APiDataBaseTest.Migrations
{
    /// <inheritdoc />
    public partial class update_tbl_OHCL_ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Volume",
                table: "OHCLs",
                newName: "TimeStamp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TimeStamp",
                table: "OHCLs",
                newName: "Volume");
        }
    }
}
