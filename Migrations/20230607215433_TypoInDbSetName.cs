using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicoriceBack.Migrations
{
    /// <inheritdoc />
    public partial class TypoInDbSetName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Cubes_CubeId",
                table: "Cars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_CubeId",
                table: "Cards",
                newName: "IX_Cards_CubeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Cubes_CubeId",
                table: "Cards",
                column: "CubeId",
                principalTable: "Cubes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Cubes_CubeId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_CubeId",
                table: "Cars",
                newName: "IX_Cars_CubeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Cubes_CubeId",
                table: "Cars",
                column: "CubeId",
                principalTable: "Cubes",
                principalColumn: "Id");
        }
    }
}
