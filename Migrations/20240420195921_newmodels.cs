using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class newmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssociatedChannels",
                table: "Circuits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChannelId",
                table: "Circuits",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Theme",
                table: "Circuits",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Channel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Channel", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Circuits_ChannelId",
                table: "Circuits",
                column: "ChannelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Circuits_Channel_ChannelId",
                table: "Circuits",
                column: "ChannelId",
                principalTable: "Channel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Circuits_Channel_ChannelId",
                table: "Circuits");

            migrationBuilder.DropTable(
                name: "Channel");

            migrationBuilder.DropIndex(
                name: "IX_Circuits_ChannelId",
                table: "Circuits");

            migrationBuilder.DropColumn(
                name: "AssociatedChannels",
                table: "Circuits");

            migrationBuilder.DropColumn(
                name: "ChannelId",
                table: "Circuits");

            migrationBuilder.DropColumn(
                name: "Theme",
                table: "Circuits");
        }
    }
}
