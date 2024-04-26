using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HumanDesign.Migrations
{
    /// <inheritdoc />
    public partial class planets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Planets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MainTheme = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Concious = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unconcious = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PearlSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoleInPearlSequence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planets", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planets");
        }
    }
}
