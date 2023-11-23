using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb3C.Server.Migrations
{
    /// <inheritdoc />
    public partial class con_habitos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Habitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitoPersona",
                columns: table => new
                {
                    HabitosId = table.Column<int>(type: "int", nullable: false),
                    PersonasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitoPersona", x => new { x.HabitosId, x.PersonasId });
                    table.ForeignKey(
                        name: "FK_HabitoPersona_Habitos_HabitosId",
                        column: x => x.HabitosId,
                        principalTable: "Habitos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HabitoPersona_Personas_PersonasId",
                        column: x => x.PersonasId,
                        principalTable: "Personas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HabitoPersona_PersonasId",
                table: "HabitoPersona",
                column: "PersonasId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HabitoPersona");

            migrationBuilder.DropTable(
                name: "Habitos");
        }
    }
}
