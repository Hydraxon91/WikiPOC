using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiPageSlug : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments");

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "WikiPages",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WikiPages_Slug",
                table: "WikiPages",
                column: "Slug",
                unique: true,
                filter: "[Slug] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments",
                column: "ReplyToCommentId",
                principalTable: "UserComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_WikiPages_Slug",
                table: "WikiPages");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "WikiPages");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments",
                column: "ReplyToCommentId",
                principalTable: "UserComments",
                principalColumn: "Id");
        }
    }
}
