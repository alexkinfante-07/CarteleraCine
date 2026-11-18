using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarteleraCine.Migrations
{
    /// <inheritdoc />
    public partial class RelacionGeneroPelicula : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GeneroId",
                table: "Pelicula",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Pelicula_GeneroId",
                table: "Pelicula",
                column: "GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pelicula_Genero_GeneroId",
                table: "Pelicula",
                column: "GeneroId",
                principalTable: "Genero",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pelicula_Genero_GeneroId",
                table: "Pelicula");

            migrationBuilder.DropIndex(
                name: "IX_Pelicula_GeneroId",
                table: "Pelicula");

            migrationBuilder.DropColumn(
                name: "GeneroId",
                table: "Pelicula");
        }
    }
}
