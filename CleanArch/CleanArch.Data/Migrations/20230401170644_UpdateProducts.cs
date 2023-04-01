using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArch.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: " A laptop can be easily transported and used in temporary spaces such as on airplanes, in libraries, temporary offices and at meetings");

            migrationBuilder.UpdateData(
                table: "Product",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: " a portable telephone that can make and receive calls over a radio frequency link while the user is moving within a telephone service area,");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");
        }
    }
}
