using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class IntroductionParagraph : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntroductionParagraph",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BodyColor",
                value: "#507ced");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntroductionParagraph",
                table: "WikiPages");

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                column: "BodyColor",
                value: "red");
        }
    }
}
