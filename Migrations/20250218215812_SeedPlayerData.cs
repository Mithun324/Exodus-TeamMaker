using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TeamMaker_WebApp.Migrations
{
    /// <inheritdoc />
    public partial class SeedPlayerData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Number", "PlayerName", "Position", "TeamId" },
                values: new object[,]
                {
                    { 1, 19, "Mark Himel", "Defender", null },
                    { 2, 20, "Clamat", "Forward", null },
                    { 3, 30, "Nipun", "Defender", null },
                    { 4, 17, "AlexRH", "Forward", null },
                    { 5, 27, "Ronald", "Forward", null },
                    { 6, 11, "Protik", "Midfielder", null },
                    { 7, 9, "Dhrubo", "Forward", null },
                    { 8, 14, "Chris", "Forward", null },
                    { 9, 26, "JWH (Joy Da)", "Midfielder", null },
                    { 10, 7, "O.T. Roy", "Midfielder", null },
                    { 11, 1, "Stanley", "Goalkeeper", null },
                    { 12, 18, "Hriday", "Goalkeeper", null },
                    { 13, 43, "Tanay D.TH", "Defender", null },
                    { 14, 6, "Mithun", "Forward", null },
                    { 15, 10, "Edward", "Midfielder", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Players",
                keyColumn: "PlayerId",
                keyValue: 15);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "TeamId",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
