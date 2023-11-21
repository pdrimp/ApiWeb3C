using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiWeb3C.Server.Migrations
{
    /// <inheritdoc />
    public partial class con_tabla_clasificaciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClasificacionId",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Clasificaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clasificaciones", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Personas_ClasificacionId",
                table: "Personas",
                column: "ClasificacionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Clasificaciones_ClasificacionId",
                table: "Personas",
                column: "ClasificacionId",
                principalTable: "Clasificaciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Clasificaciones_ClasificacionId",
                table: "Personas");

            migrationBuilder.DropTable(
                name: "Clasificaciones");

            migrationBuilder.DropIndex(
                name: "IX_Personas_ClasificacionId",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "ClasificacionId",
                table: "Personas");
        }
    }
}
