using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class IntroductionParagraph2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroductionParagraph",
                table: "WikiPages");

            migrationBuilder.AddColumn<bool>(
                name: "IntroductionParagraph",
                table: "Paragraphs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroductionParagraph",
                value: true);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroductionParagraph",
                value: false);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                column: "IntroductionParagraph",
                value: false);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                column: "IntroductionParagraph",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroductionParagraph",
                table: "Paragraphs");

            migrationBuilder.AddColumn<string>(
                name: "IntroductionParagraph",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 1,
                column: "IntroductionParagraph",
                value: "Introduction Paragraph 1");

            migrationBuilder.UpdateData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 2,
                column: "IntroductionParagraph",
                value: "Introduction Paragraph 2");
        }
    }
}
