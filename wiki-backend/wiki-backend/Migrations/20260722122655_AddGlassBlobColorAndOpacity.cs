using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddGlassBlobColorAndOpacity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GlassBaseColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob1Color",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob1ColorOuter",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob2Color",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob2ColorOuter",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob3Color",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GlassBlob3ColorOuter",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GlassBlob3Opacity",
                table: "Styles",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GlassBaseColor",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob1Color",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob1ColorOuter",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob2Color",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob2ColorOuter",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob3Color",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob3ColorOuter",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlob3Opacity",
                table: "Styles");
        }
    }
}
