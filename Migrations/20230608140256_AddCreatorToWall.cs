using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LicoriceBack.Migrations
{
    /// <inheritdoc />
    public partial class AddCreatorToWall : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Creator",
                table: "Walls",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Creator",
                table: "Walls");
        }
    }
}
