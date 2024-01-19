using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paragraph",
                table: "Paragraph");

            migrationBuilder.RenameTable(
                name: "Paragraph",
                newName: "Paragraphs");

            migrationBuilder.RenameIndex(
                name: "IX_Paragraph_WikiPageId",
                table: "Paragraphs",
                newName: "IX_Paragraphs_WikiPageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraphs_WikiPages_WikiPageId",
                table: "Paragraphs",
                column: "WikiPageId",
                principalTable: "WikiPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraphs_WikiPages_WikiPageId",
                table: "Paragraphs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Paragraphs",
                table: "Paragraphs");

            migrationBuilder.RenameTable(
                name: "Paragraphs",
                newName: "Paragraph");

            migrationBuilder.RenameIndex(
                name: "IX_Paragraphs_WikiPageId",
                table: "Paragraph",
                newName: "IX_Paragraph_WikiPageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Paragraph",
                table: "Paragraph",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph",
                column: "WikiPageId",
                principalTable: "WikiPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
