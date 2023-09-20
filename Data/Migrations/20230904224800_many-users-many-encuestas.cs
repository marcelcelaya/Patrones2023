using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class manyusersmanyencuestas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Encuestas_Usuarios_UsuarioId",
                table: "Encuestas");

            migrationBuilder.DropIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas");

            migrationBuilder.DropColumn(
                name: "UsuarioId",
                table: "Encuestas");

            migrationBuilder.CreateTable(
                name: "EncuestaUsuario",
                columns: table => new
                {
                    EncuestasId = table.Column<int>(type: "int", nullable: false),
                    UsuariosId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaUsuario", x => new { x.EncuestasId, x.UsuariosId });
                    table.ForeignKey(
                        name: "FK_EncuestaUsuario_Encuestas_EncuestasId",
                        column: x => x.EncuestasId,
                        principalTable: "Encuestas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaUsuario_Usuarios_UsuariosId",
                        column: x => x.UsuariosId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaUsuario_UsuariosId",
                table: "EncuestaUsuario",
                column: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncuestaUsuario");

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId",
                table: "Encuestas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Encuestas_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Encuestas_Usuarios_UsuarioId",
                table: "Encuestas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
