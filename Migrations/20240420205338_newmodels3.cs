using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class newmodels3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circuits_Channel_ChannelId",
                table: "Circuits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Channel",
                table: "Channel");

            migrationBuilder.DropColumn(
                name: "AssociatedChannels",
                table: "Circuits");

            migrationBuilder.RenameTable(
                name: "Channel",
                newName: "Channels");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channels",
                table: "Channels",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CircuitChannels",
                columns: table => new
                {
                    CircuitId = table.Column<int>(type: "int", nullable: false),
                    ChannelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircuitChannels", x => new { x.CircuitId, x.ChannelId });
                    table.ForeignKey(
                        name: "FK_CircuitChannels_Channels_ChannelId",
                        column: x => x.ChannelId,
                        principalTable: "Channels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CircuitChannels_Circuits_CircuitId",
                        column: x => x.CircuitId,
                        principalTable: "Circuits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircuitChannels_ChannelId",
                table: "CircuitChannels",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circuits_Channels_ChannelId",
                table: "Circuits",
                column: "ChannelId",
                principalTable: "Channels",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circuits_Channels_ChannelId",
                table: "Circuits");

            migrationBuilder.DropTable(
                name: "CircuitChannels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Channels",
                table: "Channels");

            migrationBuilder.RenameTable(
                name: "Channels",
                newName: "Channel");

            migrationBuilder.AddColumn<string>(
                name: "AssociatedChannels",
                table: "Circuits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Channel",
                table: "Channel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Circuits_Channel_ChannelId",
                table: "Circuits",
                column: "ChannelId",
                principalTable: "Channel",
                principalColumn: "Id");
        }
    }
}
