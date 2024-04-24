using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class ChangeIntToGuidForIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AlterColumn<Guid>(
                name: "WikiPageId",
                table: "WikiPages",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "WikiPages",
                type: "uniqueidentifier",
                nullable: false,
                defaultValueSql: "NEWID()",
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdateDate",
                table: "WikiPages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LegacyWikiPage",
                table: "WikiPages",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "PostDate",
                table: "WikiPages",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserProfiles",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "WikiPageId",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserProfileId",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ReplayToCommentId",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "WikiPageId",
                table: "Paragraphs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Paragraphs",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Logo",
                value: "logo/logo_pfp.png");

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7"), null, "WikiPage", null, false, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8"), null, "WikiPage", null, false, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("e52b449a-acfc-49bd-b8bf-9b219ca9a29c"), false, null, "UserSubmittedWikiPage", true, null, false, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("022a2659-1b8e-4622-adce-6783f2019f4b"), "Et possimus quia accusamus provident. Illum et consequatur voluptate. Ex ea possimus suscipit. Eos quidem hic blanditiis et quod vero.\n\nCum deleniti in qui. Explicabo voluptas quae rem. Eum ut omnis perferendis. Enim est soluta quas. Consequatur quo labore qui.\n\nSunt ut explicabo dolorum porro non nostrum exercitationem minus quam. Eligendi totam officiis est illum. Quae dolorum numquam sit. Impedit quas quisquam. Odio est corporis. Ipsa cumque eos.\n\nUllam quia veniam id incidunt mollitia eum quasi sunt. Velit in rem qui. Impedit similique enim et sed. Molestiae aperiam impedit reiciendis nesciunt odit aut. Rerum officiis quo et quos quos. A possimus aut qui suscipit.\n\nCulpa fugit et rerum consequatur qui aut eum aut amet. Facere consectetur quae. Cupiditate ducimus qui ad. Cum velit adipisci facere occaecati sit eveniet necessitatibus et. Provident nemo cupiditate maxime exercitationem saepe. Rerum consectetur voluptatem.\n\nVoluptatem nostrum dolore et occaecati accusantium quasi sunt eaque. Animi sunt consequuntur et pariatur magni velit. Eligendi nihil exercitationem. Saepe corrupti voluptates. Quos deserunt totam quas.\n\nSint totam facere quos. Aut magnam est libero aut blanditiis autem voluptatibus. Veniam distinctio quis in dolorem labore beatae. Consequatur aut dolorem ipsam. Sit esse cumque temporibus provident similique nobis quia quis. Accusantium mollitia consectetur eum praesentium fugiat non cupiditate eveniet.\n\nVeniam est et quibusdam qui corporis cupiditate similique. Dolor dolor enim sed ipsum rem corrupti. Et et ipsa aspernatur aut labore odio possimus.\n\nDoloribus et et et consequuntur perferendis magnam explicabo quas fuga. Temporibus quidem est. Omnis totam iure beatae. Aperiam quas sed dolor et enim eligendi.", null, null, "Example Page 2 - Paragraph 6", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") },
                    { new Guid("236ffc2e-c7d1-4967-8144-796124045c83"), "Voluptatibus magni et. Voluptatem officia nesciunt vel quasi. Quisquam nisi dicta ex quo cupiditate eum quidem et ut. Aut ut et dolorum eligendi molestiae et eos omnis non. Est alias et fuga nemo recusandae eos.\n\nAliquam ut non excepturi deleniti quo dolore est et sint. Quis ut nulla facere omnis aliquid modi doloremque. Autem voluptas ad. Odit illo ut voluptatem ipsam quas. Est nostrum debitis pariatur ducimus quo corrupti rerum quam ea.\n\nVel expedita quia adipisci voluptatibus vel eaque ut. Quam dolor aut quia ipsum ad maiores. Sit nulla assumenda et eum. Vitae consectetur distinctio earum aperiam omnis. Ea rem maiores eligendi voluptatum sapiente maxime provident dolorum dolore.\n\nArchitecto dolorem enim qui unde et est et consequuntur dolor. Et illo eos delectus doloribus tenetur. Qui placeat rem qui non soluta hic. Quia nihil voluptatem nemo fugit quia.\n\nEt quae et. Facere eum facilis ab. Est qui assumenda aut sequi soluta. Tempora voluptas cumque quia repudiandae. Ratione reiciendis laboriosam eos esse est beatae exercitationem in. Aut eaque consectetur saepe qui unde quasi.\n\nVel maxime necessitatibus et repellat. Autem officia ex omnis temporibus. Eos tempore minima exercitationem quas dolorem. Nisi molestiae repellendus. Voluptas eaque suscipit aspernatur dolorum optio officia id necessitatibus dolore. Deleniti tempore eveniet ut.\n\nAsperiores velit corporis id laborum consequuntur mollitia quasi debitis dignissimos. Voluptatibus excepturi praesentium delectus vel et et labore neque. Expedita rem voluptatem deleniti quam reprehenderit et. Eos illo repellat maxime in aut. Fugit dolores nulla minima cum ut dolorum sapiente quis.\n\nEst incidunt et iusto sint placeat quibusdam voluptas. Est totam et est ipsa sequi necessitatibus ut modi quia. Hic et debitis minus maxime eveniet totam.\n\nRatione aliquam quae aut rerum ut est a similique. Ut molestias nisi quia ea in reiciendis occaecati unde exercitationem. Cupiditate aliquam voluptatum at nihil similique.\n\nUt dicta voluptatem. Fugit vero corrupti nesciunt est. Minima dignissimos debitis officiis eveniet id nihil. Ut necessitatibus vitae et.", null, null, "Example Page 1 - Paragraph 2", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("3b3ddfdd-ad83-490e-a383-6a2af34eaad6"), "Ex qui cum dignissimos architecto. Voluptatem qui aliquam cupiditate velit consectetur assumenda. Ipsa nemo veritatis harum error qui tempora impedit.\n\nId dolores recusandae natus ut quod debitis officia dolore. Laudantium ut asperiores. Voluptate sit itaque dolores beatae accusamus inventore et. Praesentium qui error cumque occaecati totam magni nobis minima eligendi.", null, null, "Example Page 2 - Paragraph 4", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") },
                    { new Guid("465db3a3-d16f-4752-a150-ba796352cc67"), "Laudantium sit beatae aut sed ipsum voluptatem. Impedit consequatur maiores eos. Qui voluptas enim a. Est voluptas quia ipsam ratione laborum sint non. Illo sequi aut quae accusantium omnis. Laudantium et animi nam tenetur.\n\nOccaecati pariatur atque est. Ratione rerum dolor deleniti deserunt molestiae voluptatem impedit. Est enim facere amet earum quia consequuntur.\n\nModi similique incidunt. Omnis id eveniet eos dolorem quidem ut labore atque. Sunt et ullam expedita eveniet totam. Repudiandae necessitatibus dolor. Et deleniti tempore aut sint aut cupiditate ex.\n\nAliquam est deserunt impedit aperiam ratione. Praesentium quasi aliquid qui. Sed aut quia aut ut quibusdam. Quidem odit ducimus suscipit necessitatibus ut repudiandae sit sapiente.\n\nVoluptatem rem voluptatibus eum nihil voluptas. Eos ut omnis quaerat repudiandae dolor qui similique. Aliquid eum dolor asperiores voluptatem quasi voluptatem voluptatibus eum nam.\n\nMinus soluta magni est aut. Placeat possimus dolorum praesentium nulla voluptas ipsam sint explicabo unde. Placeat et possimus a debitis. Cum aut sint sunt quas dolor praesentium.", null, null, "Example Page 1 - Paragraph 5", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("5319dde1-513f-4610-b8be-a6863d84fc2a"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("e52b449a-acfc-49bd-b8bf-9b219ca9a29c") },
                    { new Guid("5a20d443-c364-4755-9fa4-d1dbdbe4df04"), "Autem ut rerum laborum fugiat aut expedita labore vitae deserunt. Facilis quas quo aut quibusdam in culpa. Neque tenetur corporis omnis aut deserunt tempore pariatur culpa aut. Sunt doloremque consequuntur incidunt provident dolores ullam autem quaerat.\n\nQuos molestiae corrupti pariatur itaque non sed rerum. Et necessitatibus illo amet accusamus doloremque alias vitae rerum amet. Aut quas voluptate temporibus eveniet corporis quia omnis. Recusandae nobis dolor dicta aperiam sed.\n\nEt qui et similique ut quia iure. Perferendis ea rerum impedit ad eos. Quisquam doloremque deserunt velit in praesentium eum aut voluptatum autem. Voluptatem cumque et dignissimos. Libero neque neque quia vel voluptatem nihil. Aut incidunt sunt.", null, null, "Example Page 1 - Paragraph 6", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("6c1843bc-67ad-4c2c-bb7a-9669cc065b2c"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("e52b449a-acfc-49bd-b8bf-9b219ca9a29c") },
                    { new Guid("8ca8f458-ef1a-4f0c-8d1f-3ec03ed5d986"), "Explicabo quia et ipsum. Laudantium et possimus nemo ut quo. Consectetur itaque ut dolores.\n\nVel in illo. Esse et possimus. Aut aperiam temporibus aut dolores et quaerat eaque ipsa. Id possimus non ut consequuntur dolor. Id id rerum ab repellat dolorum. Hic enim quod et ut.\n\nOmnis eligendi recusandae. Ea aut voluptate. Inventore odit et facilis perferendis alias. Et quae voluptatum dolores amet architecto. Eos quibusdam voluptas.\n\nVeritatis voluptatem sapiente. Recusandae beatae dolore id blanditiis minima sit quod repellendus. Accusamus ut dolorum sed. Nihil molestias ratione eveniet in dolores sequi delectus. Fugit labore eveniet porro sit quo cumque reprehenderit quisquam qui.\n\nA exercitationem assumenda in iste voluptate qui magni ullam qui. Nostrum id ipsa sit ex repellat fugiat aperiam ea esse. Reiciendis enim consequatur eum. Voluptatem nam quis repudiandae accusantium a maiores dolor omnis. Nesciunt cupiditate quo explicabo ipsum.\n\nIste ea similique culpa id quo voluptas iste beatae. Voluptas exercitationem omnis laborum sed ut explicabo. Aperiam minima consectetur placeat qui non. Non odio distinctio qui et temporibus asperiores.", null, null, "Example Page 2 - Paragraph 5", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") },
                    { new Guid("97ea11a1-0fab-48a2-a79e-3271d1ce9551"), "Qui possimus consequuntur nobis dolore. Distinctio facere repellat reprehenderit nihil in odio deleniti eius. Voluptatem in aut ut aut debitis sint ut.\n\nQuos nihil quia. Fugit quo voluptatum. Esse dolor libero voluptatem aut iste ducimus enim.\n\nVelit fugiat dolor eum. In voluptatum possimus ex. Ullam neque nemo quod et quos nobis cupiditate ut. Dolorem voluptas provident mollitia qui nesciunt voluptatem.\n\nEt repellendus quaerat porro nihil enim eos omnis provident minus. Est nulla iusto eum quis ea accusantium voluptatem ipsam. Fugiat aut possimus dignissimos iure ullam sunt rem. Consequatur sequi fuga quidem harum ipsam et doloribus debitis. Labore nihil laudantium enim ex molestiae aperiam. Enim sunt necessitatibus iusto aliquid recusandae iusto.\n\nFacere non ipsum aut optio maxime dolor id. Nemo velit quidem sequi sequi corrupti et enim id molestiae. Itaque numquam temporibus quo dolores doloremque natus molestias.\n\nUt facere doloribus nihil et sit quisquam. Quo fuga enim harum voluptatem. Assumenda dolorem culpa. Quia id alias. Adipisci assumenda repellendus.\n\nPorro aut qui sunt ducimus perspiciatis aliquid nihil. Maiores est quibusdam assumenda voluptatum. Aut nobis cupiditate necessitatibus modi corrupti rerum laborum et.\n\nQui ratione facilis debitis incidunt velit in maxime. Dolores consequuntur suscipit voluptatibus accusantium asperiores est. Esse non quis repellendus placeat eaque harum vel distinctio. Sequi eum quo quam accusantium id veritatis itaque et incidunt. Est perferendis veritatis dolores rem.\n\nAut minima vitae voluptatem. Velit nemo qui excepturi quia omnis. Aut minima hic architecto consequatur animi eum eaque. Saepe omnis veniam possimus suscipit nobis incidunt et.\n\nPossimus quis odio aut perspiciatis. Hic enim quia voluptas doloremque placeat. Magnam aperiam voluptas commodi. Amet soluta aut iusto molestiae tempore eius placeat commodi.", null, null, "Example Page 2 - Paragraph 2", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") },
                    { new Guid("9c2a577d-386a-4b1e-99dc-540336029df0"), "Dolorum voluptas totam eos temporibus ipsum. Ratione iusto expedita. Iste ipsam quaerat ut dolor ut.", null, null, "Example Page 1 - Paragraph 3", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("a36f1985-a3d1-4ff7-ac90-4f9c85b4167b"), "Error sit aspernatur dignissimos reprehenderit non consectetur architecto tempora quisquam. Reprehenderit mollitia dignissimos commodi. Et eum sunt voluptatem dolores error nisi dolorem repellendus. Sequi aut magni minima dolorem consequuntur optio ipsam mollitia vitae.\n\nVoluptatem similique illo praesentium est nisi temporibus et similique. Ut occaecati amet in dolorem illum quos. Esse aspernatur quia et eum voluptatum.\n\nIure enim eligendi dolorem repellendus. Recusandae repellendus ut velit. Iure occaecati perspiciatis non adipisci odio sunt.\n\nIure quia eum saepe laborum. Maiores dicta eum ea molestias doloremque nobis. Sit ad et optio esse necessitatibus. Porro dolor laboriosam id maxime et nihil qui accusantium.\n\nMaxime rerum sequi ut ad aspernatur id et. Quia expedita velit blanditiis voluptas libero et porro quia ipsam. Qui maiores qui dolores natus consequatur dolore non libero est.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("a915f867-10b7-4ada-958e-601c3feda950"), "Molestias accusantium et vero non cupiditate laborum commodi. Officiis praesentium laborum possimus assumenda et quo in. Aperiam animi doloribus et in ut quam dolore mollitia unde. Aperiam et minus sit cum quisquam dolores qui minus.", null, null, "Example Page 2 - Paragraph 3", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") },
                    { new Guid("d6eab781-4e26-49e9-b9f1-b7187502c4d1"), "Provident consectetur corrupti magni culpa quasi necessitatibus quo laudantium deleniti. Culpa atque porro sed et labore quam. Dolor impedit aliquam magni molestiae fuga. Pariatur ea quidem sequi eos at earum eligendi. Eveniet soluta facilis temporibus quo. Non iste magnam quia provident consequatur quod ut repudiandae.\n\nRem quisquam nulla. Accusantium fugiat autem rerum impedit voluptatem quae consectetur assumenda natus. Distinctio recusandae at odit quaerat tenetur.", null, null, "Example Page 1 - Paragraph 4", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") },
                    { new Guid("ee372606-1d9a-44c4-90c9-e5e81a19fa17"), "Magnam velit doloremque quia consequatur enim quidem nulla maxime. Iure rerum accusamus. Tempora molestiae est reiciendis adipisci ea repellat id exercitationem. Ut aliquam deserunt.\n\nSed et ut nobis eaque fugiat molestiae. Sed tempora voluptas qui unde magni quaerat optio quaerat eaque. Quisquam doloribus perferendis suscipit vero.\n\nNobis reiciendis ad ipsa ipsum. Quia ut aspernatur. Omnis doloremque nihil repellat molestiae quia perferendis neque eos.\n\nCum soluta eos architecto sint et hic aliquid soluta aut. Aliquam eveniet nisi aliquam aut suscipit et est consequuntur quia. Est possimus labore temporibus. Vel modi hic omnis et temporibus laborum beatae rem.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("a7d4ef4c-0187-4217-899b-4eae5b47682d"), false, null, "UserSubmittedWikiPage", false, null, false, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("60aaa3fb-3c49-4410-9a7a-eb61977dd635"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("a7d4ef4c-0187-4217-899b-4eae5b47682d") },
                    { new Guid("64e726fd-92fd-40b7-93db-cd78d1750367"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("a7d4ef4c-0187-4217-899b-4eae5b47682d") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("022a2659-1b8e-4622-adce-6783f2019f4b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("236ffc2e-c7d1-4967-8144-796124045c83"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3b3ddfdd-ad83-490e-a383-6a2af34eaad6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("465db3a3-d16f-4752-a150-ba796352cc67"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5319dde1-513f-4610-b8be-a6863d84fc2a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5a20d443-c364-4755-9fa4-d1dbdbe4df04"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("60aaa3fb-3c49-4410-9a7a-eb61977dd635"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("64e726fd-92fd-40b7-93db-cd78d1750367"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6c1843bc-67ad-4c2c-bb7a-9669cc065b2c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ca8f458-ef1a-4f0c-8d1f-3ec03ed5d986"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("97ea11a1-0fab-48a2-a79e-3271d1ce9551"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9c2a577d-386a-4b1e-99dc-540336029df0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a36f1985-a3d1-4ff7-ac90-4f9c85b4167b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a915f867-10b7-4ada-958e-601c3feda950"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6eab781-4e26-49e9-b9f1-b7187502c4d1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ee372606-1d9a-44c4-90c9-e5e81a19fa17"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("6cd9270a-78c1-4f6f-86d9-669e40b65cc8"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("a7d4ef4c-0187-4217-899b-4eae5b47682d"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e52b449a-acfc-49bd-b8bf-9b219ca9a29c"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("6c79586c-1a6f-471d-b44a-d01c67be97c7"));

            migrationBuilder.DropColumn(
                name: "Content",
                table: "WikiPages");

            migrationBuilder.DropColumn(
                name: "LastUpdateDate",
                table: "WikiPages");

            migrationBuilder.DropColumn(
                name: "LegacyWikiPage",
                table: "WikiPages");

            migrationBuilder.DropColumn(
                name: "PostDate",
                table: "WikiPages");

            migrationBuilder.AlterColumn<int>(
                name: "WikiPageId",
                table: "WikiPages",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "WikiPages",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldDefaultValueSql: "NEWID()")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserProfiles",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "WikiPageId",
                table: "UserComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "UserProfileId",
                table: "UserComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "ReplayToCommentId",
                table: "UserComments",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "UserComments",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "WikiPageId",
                table: "Paragraphs",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Paragraphs",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "Styles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Logo",
                value: "logo_pfp.png");

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Discriminator", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { 1, "WikiPage", "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { 2, "WikiPage", "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Discriminator", "IsNewPage", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { 3, false, "UserSubmittedWikiPage", true, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 1, "Repellat odit sed itaque animi minus. Quia eos similique. Voluptatem aut sit officia illo non error. Et doloremque et ut. Maiores error minima qui quod asperiores perspiciatis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", 1 },
                    { 2, "Labore omnis provident ut natus. Aut fuga officiis quia qui deserunt. Hic et id dolorem tenetur explicabo repudiandae ipsam in.\n\nDoloremque non ut. Voluptates accusamus voluptatibus similique. Ad fugiat consequatur esse quia totam. Et quas ipsa. Nulla consequatur doloribus perferendis placeat maiores natus.\n\nDelectus est odit et ut sapiente est perferendis. Sit dolore labore. Et cupiditate nulla eos aut in et.", null, null, "Example Page 1 - Paragraph 2", 1 },
                    { 3, "Sed sunt id quod doloremque natus consectetur eaque. Nulla voluptates maiores vel qui voluptatum omnis et. Unde similique vero. Quo repudiandae corrupti doloribus.\n\nQuia sed nisi ut. Et qui dolores. Ut eveniet dolores impedit maiores. Numquam ut esse quae. Id officiis architecto. Suscipit repellendus minus sequi non ad fugiat.\n\nVel molestias aut. Et assumenda dolore et quae sint mollitia ut aut. Sint qui eveniet quibusdam soluta quas est expedita voluptatibus. Error et iusto.\n\nNulla est accusantium consectetur. Voluptatem non animi minus fuga voluptatem. Sit et qui quia impedit autem et numquam earum. Quo deleniti aspernatur exercitationem aut aliquam illum dignissimos et maiores. Aut nostrum provident. Beatae eum similique sed numquam numquam et.\n\nTempore dolore cumque. Nemo nulla animi hic ea quisquam. Ipsam vel alias adipisci aliquid ut et temporibus aut.\n\nVoluptate sit minima autem voluptate. Quaerat ex est qui aut. Numquam cupiditate fugiat. Minus inventore consectetur sapiente alias autem. Quod sed voluptatibus quia. Debitis facilis aperiam provident possimus aspernatur et reiciendis.", null, null, "Example Page 1 - Paragraph 3", 1 },
                    { 4, "Veritatis repellat magnam delectus quo omnis aut ut recusandae. Quam est molestiae fugiat et sit vel. Labore debitis id inventore et dicta ullam deleniti. Ducimus soluta tenetur aut nesciunt velit nam. Qui dolores odit iure doloribus ut harum sit consequatur labore. Molestiae ea voluptatem et necessitatibus veritatis accusamus non neque eius.\n\nAt perferendis voluptatem illo expedita veritatis laudantium sapiente est recusandae. Qui sint porro earum ullam quia et inventore et. Velit qui voluptas veniam libero nulla.\n\nMinus id sit exercitationem quam magnam numquam quis quos autem. Maiores neque ex fuga cupiditate enim ipsam nihil illum. Dolores et ea pariatur doloribus. Vel enim est. Odio id ut sapiente et et voluptatem. Nam velit non dolorem facilis unde blanditiis.\n\nEveniet aperiam officia est aut delectus iure consequatur repellendus. Reiciendis fuga tempora odit totam. Eos omnis aliquid quaerat qui sunt. Assumenda quis eveniet. Perspiciatis facilis corrupti quam ut facere qui. Provident beatae qui.\n\nRerum sunt necessitatibus optio rerum. Quod itaque nemo laudantium sit. Placeat illum quaerat repudiandae perspiciatis. Nesciunt aut quia est excepturi. Ex velit tenetur iure voluptatem illum. A voluptas vero in nisi quia accusamus ut deserunt.\n\nAccusantium fugit corporis. Molestiae culpa dolores dolorem nam est earum aut eos. Cum consectetur quas. Aliquam in ut quia dolorem libero et magni est. Nostrum nam modi fuga sapiente sit. Earum reiciendis tempora.\n\nPlaceat nulla nulla reprehenderit id asperiores facere repellendus. Nihil magni molestias tempora sed praesentium itaque neque. Optio qui et voluptas aperiam molestiae. Doloribus rerum deserunt eaque quos est doloribus tempore labore aut.\n\nSed tempore nulla. Quia saepe in iure maiores ut. Nostrum debitis aspernatur est omnis voluptatem.\n\nError laudantium voluptatum soluta earum sed est ipsa autem. Qui perspiciatis et atque odit accusantium velit quae odit. Quas animi laborum iure sed ipsam dicta. Rerum qui quos consequatur numquam deleniti asperiores necessitatibus voluptatibus. Ea perferendis et nam doloremque ea fugit quod vel quidem. Saepe tenetur in illo numquam quia omnis nihil voluptatem.\n\nExercitationem vitae optio rerum commodi praesentium id dolor aliquid nisi. Similique in eligendi voluptas molestias molestiae ducimus dolorum voluptatem. Quia et consequatur expedita voluptatibus omnis. Voluptas magni ut. Earum non corporis.", null, null, "Example Page 1 - Paragraph 4", 1 },
                    { 5, "Voluptatibus explicabo neque. Velit odio repellat. Quasi et perferendis qui. Culpa reiciendis porro libero. Et voluptatem dolor voluptatem quo quo et veniam.\n\nEst excepturi eaque officiis. Velit eos fugiat rerum illum. Magni velit enim deleniti sit voluptatem.\n\nAperiam et ullam fugit commodi quo. Hic consequatur voluptate quo corporis consequuntur quidem. Quae vero non. Et odio rem laborum ipsum laborum.\n\nIusto qui id. Animi saepe nobis cupiditate sit. Libero iure rem quam perferendis fugit odit fuga. Aut quaerat facilis iusto ipsa eum. Accusamus ut delectus consequatur ut voluptates quos voluptatem aut distinctio.\n\nEst ut est consequatur. Nisi quia distinctio blanditiis iusto iusto aut excepturi cum. Et doloribus vel fugiat adipisci rerum.\n\nCum molestiae eos eius officiis rerum porro. Et eum sapiente neque et quo ratione. Quidem quaerat assumenda quisquam adipisci et ab. Perspiciatis quia molestias minus eos excepturi aliquid omnis autem doloribus.", null, null, "Example Page 1 - Paragraph 5", 1 },
                    { 6, "Soluta aperiam facilis a et est accusantium qui impedit et. Cupiditate numquam aperiam quidem at libero labore voluptatem aut vero. Quasi iure aspernatur tenetur repudiandae velit rerum. Quia eum enim rerum consequatur commodi. Voluptate adipisci natus ut. Suscipit sed ipsum est est assumenda.", null, null, "Example Page 1 - Paragraph 6", 1 },
                    { 7, "Quaerat expedita omnis nam unde minima. Ut et neque et aliquam magni impedit consectetur blanditiis minus. Quis eligendi numquam voluptatem est sint dicta odit aut adipisci. Earum quo harum id excepturi tempore magni occaecati et. Possimus dolorum deleniti totam et et.\n\nPariatur vel et tempora at esse dolor id et. Atque necessitatibus maiores aspernatur consequatur illum ducimus. Culpa velit et praesentium inventore pariatur recusandae quia. Voluptas et quam inventore. Voluptatibus aut et assumenda qui id ipsa distinctio omnis in.\n\nNobis et possimus. Dolores molestiae soluta doloribus maxime fugit aut quidem necessitatibus. Quia distinctio alias similique velit.\n\nAssumenda quis quibusdam quasi. Repudiandae velit sit voluptate fugiat. Aut rerum dolorum ipsum quia.\n\nQuibusdam qui quod omnis harum. Rerum autem deleniti fuga iste explicabo officia consequuntur aut. Asperiores mollitia molestiae et blanditiis. Et hic a unde. Impedit incidunt omnis et magni error ea nihil. Ex qui dolor officiis et voluptas.\n\nVero suscipit nulla ducimus dignissimos delectus voluptatem. Quo aut natus ab ut distinctio in placeat quo. Ut sed et et sunt. Ullam tempore consequatur qui quidem aut.\n\nDolorum qui et ut beatae voluptas tenetur laboriosam quam repellat. Earum omnis accusamus. Doloribus blanditiis et similique. Eum ut ut consectetur. Sapiente ut corrupti architecto modi eligendi porro aperiam eaque magnam.\n\nAperiam iure velit blanditiis quo distinctio. Excepturi mollitia repellat reprehenderit et aut. Quia iure explicabo et qui deleniti qui dolores. Sapiente nostrum odio explicabo et atque non eligendi cum.\n\nUnde ut ut id et. Quo deleniti temporibus maiores quod maiores eum. Nam ut veniam. Est aspernatur enim ut aut animi earum fuga. Animi omnis provident quas autem omnis voluptatem vel quo.\n\nHarum illo occaecati ea velit dignissimos provident eum neque. Vero officiis laborum. Sit officia sed odit rem voluptas provident molestiae delectus illum. Quas sit numquam hic soluta.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", 2 },
                    { 8, "Occaecati reprehenderit sit. Ratione alias quia esse aliquam. Blanditiis repudiandae neque et libero aperiam nemo velit molestiae. Et quia beatae culpa expedita qui qui distinctio. Minima consequatur voluptates exercitationem cumque molestias nulla. Qui deserunt praesentium reprehenderit cumque quas omnis facere.\n\nModi consequuntur quasi nisi impedit quasi debitis ratione numquam. Laboriosam consequatur minus enim dolor. Fugiat ratione consequatur. Tempore molestiae dolores dicta porro sit voluptatibus consequatur ipsa. Nisi et iure. Sunt sit sint temporibus.\n\nEt dolore aut id quasi qui. Est aut est. Enim eos quam necessitatibus aspernatur fugiat non.\n\nAut est mollitia provident itaque autem libero. Aspernatur enim sed eveniet. Laboriosam dolorem ut qui laboriosam neque omnis.\n\nVitae nemo harum sint qui sint cumque inventore et dolor. Atque similique illo. Et et dignissimos quod.\n\nMagni id doloremque architecto voluptatem ullam. Deleniti omnis reprehenderit cupiditate quia reiciendis blanditiis ratione incidunt. Consequatur omnis nobis sapiente dolores repellat. Rerum vero recusandae esse adipisci corrupti ut voluptas quis a. Et sed aperiam aspernatur distinctio aliquid adipisci blanditiis. Atque illo aut mollitia velit minus molestias illo qui.\n\nVoluptatem accusantium expedita et. Laborum blanditiis nisi ipsum accusamus. Optio nihil qui et et consequatur sapiente maiores et doloribus.\n\nNon impedit ratione delectus dolor recusandae facere provident et. Qui aut in libero fuga laboriosam delectus necessitatibus laborum officia. Dolor similique quo fugit occaecati voluptas blanditiis architecto eos adipisci.\n\nDolorum magnam quis error fuga labore repudiandae mollitia sunt. Occaecati aliquid qui dolorem nostrum rerum. Qui eaque dolorem. Reiciendis voluptas aut doloribus molestias animi harum aut doloribus. Sunt consectetur sapiente quia dolore deserunt quis.", null, null, "Example Page 2 - Paragraph 2", 2 },
                    { 9, "Veritatis dolores numquam. Commodi natus expedita unde voluptatem omnis sunt at id fugiat. Excepturi ut nihil sunt explicabo est eos. Sed recusandae rerum deleniti corrupti repudiandae pariatur fugit illum ad. Totam sit itaque. Ipsum doloremque nemo.", null, null, "Example Page 2 - Paragraph 3", 2 },
                    { 10, "Nemo incidunt occaecati deserunt in. Delectus ut fuga ea aut est ut libero autem. Recusandae deleniti qui alias omnis vel qui omnis quia. Aliquid ex ut.\n\nEsse ducimus placeat quam excepturi ut rerum et expedita adipisci. Voluptates non voluptate. Laudantium ea vitae. Tempora accusantium sint sed aperiam laborum dolore nesciunt esse eum.", null, null, "Example Page 2 - Paragraph 4", 2 },
                    { 11, "Odit excepturi deleniti explicabo nesciunt quae magni aliquam. Consequatur minima vel aut consequatur aut labore dolores. Itaque eligendi et.\n\nCorporis corrupti itaque architecto ab quos. Consequatur numquam ut. Soluta ducimus veritatis laborum eveniet ipsum vel. Eligendi earum expedita similique doloremque qui.\n\nEius officiis nihil. Qui deleniti molestiae. Possimus reprehenderit et error aut facilis est aspernatur. Fuga doloremque unde et quos.\n\nQuia vel quia quasi voluptatibus amet maxime odio. Quam consequatur nam qui est. Aperiam maxime sed aut. Modi odio maxime sit perspiciatis recusandae eos. Voluptatem aut iste quas quas.\n\nAut voluptatibus sint non a. Nobis ut repellendus quos et ut ut perspiciatis. Quibusdam sequi voluptatum velit totam et ea. Corporis illo adipisci. Voluptatibus sunt explicabo voluptas nam illum et eius accusamus.\n\nEa cumque id error quos voluptates accusantium molestiae consectetur. Repellendus illo inventore natus nobis nulla ad explicabo. Illo illo eius hic corporis voluptatem mollitia eligendi quia. Sit consequuntur consequatur dolores necessitatibus voluptatem. Rerum molestias eum est optio fugit ut aperiam.\n\nFugit voluptatem sit quia animi aliquid voluptatibus sit. Sequi eveniet accusamus et qui est soluta. Incidunt nostrum odit error. Molestiae consectetur soluta consequuntur veniam aut cumque accusamus eum. A libero saepe aliquid voluptatem quis et dolor non.\n\nPariatur laudantium in a porro. Voluptatum fuga consequatur exercitationem eos repudiandae officiis aliquam voluptatum corrupti. Distinctio in ipsum quae ut adipisci quis voluptatum harum amet. Sit qui a consequatur molestiae et qui vel quo. Nihil qui sit vitae doloribus quasi eum animi voluptatem corrupti.", null, null, "Example Page 2 - Paragraph 5", 2 },
                    { 12, "Accusamus nulla aliquid ut porro hic non ut quam natus. Non qui aliquam porro. Totam facere aperiam et placeat. Aut architecto aliquam.\n\nMolestiae doloremque ducimus sed est error illo officia voluptatibus minus. Aliquid aut rerum dolore ut in maiores quaerat accusantium aliquid. Est ut molestiae quas sapiente sapiente omnis enim. Mollitia odio beatae maxime et tempora. Ea est ratione.\n\nQuis nobis quos quisquam alias corrupti. Eos accusamus deserunt eius suscipit et. Fugiat aut nobis. Enim quis porro ducimus ut modi rerum quaerat eveniet voluptatem.\n\nAut optio ut perferendis. Et accusamus sed. Tempore eos necessitatibus. Quo excepturi unde. Enim pariatur ut doloribus voluptatibus omnis corrupti quae.\n\nVel rerum ipsam. Molestias consequatur autem omnis porro omnis possimus atque provident. Eveniet et perferendis id architecto. Excepturi alias est tempora.\n\nIn labore placeat voluptatem tempore facilis quos aut eum. Corrupti similique molestiae aperiam. Nam non reiciendis nesciunt quibusdam. Voluptatibus est aliquid aliquam deleniti dicta repellat ipsam libero. Nesciunt debitis tempore magnam sit temporibus. Repellendus cupiditate officia quis quo.\n\nEt tenetur voluptatum culpa commodi accusantium adipisci dolorum eligendi sed. Doloribus in atque dolorem doloremque. Quos vel optio et voluptatem maiores ipsa tenetur deserunt. Voluptas eaque aliquam tempore rem. Ea doloribus ea aspernatur nihil molestias dolore porro. Molestiae commodi quidem est est aut corrupti suscipit fugiat dolor.\n\nBlanditiis aliquid qui ut laboriosam earum aut. Dolor quis et provident cum porro dignissimos. Voluptatem earum incidunt eligendi voluptate et. Sit temporibus repellat ut expedita nobis deleniti.\n\nNecessitatibus aut omnis beatae est earum recusandae. Soluta laborum ea quos nam facere quo maxime. Ut rerum velit omnis velit. Quia quos laudantium similique consequatur.", null, null, "Example Page 2 - Paragraph 6", 2 },
                    { 13, "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", 3 },
                    { 14, "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", 3 }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Discriminator", "IsNewPage", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { 4, false, "UserSubmittedWikiPage", false, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", 1 });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 15, "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", 4 },
                    { 16, "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", 4 }
                });
        }
    }
}
