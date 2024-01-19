using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph");

            migrationBuilder.AlterColumn<int>(
                name: "WikiPageId",
                table: "Paragraph",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImageText",
                table: "Paragraph",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImage",
                table: "Paragraph",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph",
                column: "WikiPageId",
                principalTable: "WikiPages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph");

            migrationBuilder.AlterColumn<int>(
                name: "WikiPageId",
                table: "Paragraph",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImageText",
                table: "Paragraph",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ParagraphImage",
                table: "Paragraph",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paragraph_WikiPages_WikiPageId",
                table: "Paragraph",
                column: "WikiPageId",
                principalTable: "WikiPages",
                principalColumn: "Id");
        }
    }
}
