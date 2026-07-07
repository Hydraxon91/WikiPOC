using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddMultiEraThemeEngine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgMeshGradient",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BorderRadius",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BorderStyle",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GlassBgOpacity",
                table: "Styles",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GlassBlurRadius",
                table: "Styles",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "GlassBorderReflection",
                table: "Styles",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InterfaceEra",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Styles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSystemPreset",
                table: "Styles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ThemeName",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "ForumTopics",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgMeshGradient",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "BorderRadius",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "BorderStyle",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBgOpacity",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBlurRadius",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "GlassBorderReflection",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "InterfaceEra",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "IsSystemPreset",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "ThemeName",
                table: "Styles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Styles");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "ForumTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
