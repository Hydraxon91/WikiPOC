using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class StyleModelSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "ArticleColor", "ArticleRightColor", "ArticleRightInnerColor", "BodyColor", "FooterListLinkTextColor", "FooterListTextColor", "Logo", "WikiName" },
                values: new object[] { 1, "#526cad", "#3c5fb8", "#2b4ea6", "red", "#1d305e", "#233a71", "/img/logo.png", "Your Wiki" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
