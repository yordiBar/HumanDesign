using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class ManualRemoveChannelId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circuits_Channels_ChannelId",
                table: "Circuits");

            migrationBuilder.DropIndex(
                name: "IX_Circuits_ChannelId",
                table: "Circuits");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Circuits");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Circuits",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Circuits_ChannelId",
                table: "Circuits",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circuits_Channels_ChannelId",
                table: "Circuits",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }
    }
}
