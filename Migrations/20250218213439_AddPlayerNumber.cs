using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeamMaker_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class AddPlayerNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Players",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Players");
        }
    }
}
