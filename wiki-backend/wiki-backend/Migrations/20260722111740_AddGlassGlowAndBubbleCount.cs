using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGlassGlowAndBubbleCount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BubbleCountDesktop",
                table: "Styles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BubbleCountMobile",
                table: "Styles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GlassGlowIntensity",
                table: "Styles",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BubbleCountDesktop",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "BubbleCountMobile",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassGlowIntensity",
                table: "Styles");
        }
    }
}
