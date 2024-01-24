using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImageText",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImage",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { 1, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { 2, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 1, "Example content 1", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Paragraph 1", 1 },
                    { 2, "Example content 2", null, null, "Example Paragraph 2", 1 },
                    { 3, "Example content 3", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText3", "Example Paragraph 3", 2 },
                    { 4, "Example content 4", null, null, "Example Paragraph 4", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImageText",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImage",
                table: "Paragraphs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
