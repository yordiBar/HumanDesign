using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class gateproperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CircuitId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiftId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReactiveId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepressiveId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShadowId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SiddhiId",
                table: "Gates",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Circuits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Circuits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reactives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reactives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repressives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repressives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shadows",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shadows", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Siddhis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Siddhis", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gates_CircuitId",
                table: "Gates",
                column: "CircuitId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_GiftId",
                table: "Gates",
                column: "GiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_LocationId",
                table: "Gates",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_ReactiveId",
                table: "Gates",
                column: "ReactiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_RepressiveId",
                table: "Gates",
                column: "RepressiveId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_ShadowId",
                table: "Gates",
                column: "ShadowId");

            migrationBuilder.CreateIndex(
                name: "IX_Gates_SiddhiId",
                table: "Gates",
                column: "SiddhiId");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Circuits_CircuitId",
                table: "Gates",
                column: "CircuitId",
                principalTable: "Circuits",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Gifts_GiftId",
                table: "Gates",
                column: "GiftId",
                principalTable: "Gifts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Locations_LocationId",
                table: "Gates",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Reactives_ReactiveId",
                table: "Gates",
                column: "ReactiveId",
                principalTable: "Reactives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Repressives_RepressiveId",
                table: "Gates",
                column: "RepressiveId",
                principalTable: "Repressives",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Shadows_ShadowId",
                table: "Gates",
                column: "ShadowId",
                principalTable: "Shadows",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Gates_Siddhis_SiddhiId",
                table: "Gates",
                column: "SiddhiId",
                principalTable: "Siddhis",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Circuits_CircuitId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Gifts_GiftId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Locations_LocationId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Reactives_ReactiveId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Repressives_RepressiveId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Shadows_ShadowId",
                table: "Gates");

            migrationBuilder.DropForeignKey(
                name: "FK_Gates_Siddhis_SiddhiId",
                table: "Gates");

            migrationBuilder.DropTable(
                name: "Circuits");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Reactives");

            migrationBuilder.DropTable(
                name: "Repressives");

            migrationBuilder.DropTable(
                name: "Shadows");

            migrationBuilder.DropTable(
                name: "Siddhis");

            migrationBuilder.DropIndex(
                name: "IX_Gates_CircuitId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_GiftId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_LocationId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_ReactiveId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_RepressiveId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_ShadowId",
                table: "Gates");

            migrationBuilder.DropIndex(
                name: "IX_Gates_SiddhiId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "CircuitId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "GiftId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "ReactiveId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "RepressiveId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "ShadowId",
                table: "Gates");

            migrationBuilder.DropColumn(
                name: "SiddhiId",
                table: "Gates");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Gates",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
