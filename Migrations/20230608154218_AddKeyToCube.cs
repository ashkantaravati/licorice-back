using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicoriceBack.Migrations
{
    /// <inheritdoc />
    public partial class AddKeyToCube : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Cubes",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                table: "Cubes");
        }
    }
}
