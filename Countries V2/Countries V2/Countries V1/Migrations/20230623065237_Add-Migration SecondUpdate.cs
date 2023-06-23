using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Countries_V1.Migrations
{
    /// <inheritdoc />
    public partial class AddMigrationSecondUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Anthem",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Leader",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Anthem",
                table: "Countries");

            migrationBuilder.DropColumn(
                name: "Leader",
                table: "Countries");
        }
    }
}
