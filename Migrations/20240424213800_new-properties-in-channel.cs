using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class newpropertiesinchannel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CircuitId",
                table: "Channels",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Number",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Channels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Channels_CircuitId",
                table: "Channels",
                column: "CircuitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Channels_Circuits_CircuitId",
                table: "Channels",
                column: "CircuitId",
                principalTable: "Circuits",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Channels_Circuits_CircuitId",
                table: "Channels");

            migrationBuilder.DropIndex(
                name: "IX_Channels_CircuitId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "CircuitId",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Channels");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Channels");
        }
    }
}
