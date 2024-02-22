using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class StyleModelMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WikiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleRightColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleRightInnerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterListLinkTextColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterListTextColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}
