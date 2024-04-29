using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToWikiPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("151154a1-fc85-402a-aee0-bdb883ba72b7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("27e21529-90dd-4ee6-a7ab-d3c2c9feabb4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2a87a6e8-dd49-466f-aff6-1e4997fa77ff"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("466a5f54-f096-41fa-8235-20389310b3f8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("62a0ad9a-61d7-4d3c-90c4-64ed6b7623d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6cfbf0e0-93d6-407e-97f9-4cb2f5c0909d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("75cf41f2-2481-466d-b4fc-b3a66282892b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7ad64171-6741-4a11-b397-059943d22f48"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8df9f4c2-9928-43e6-867f-78f4a3eaef28"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ac56ad23-9a4e-42dc-ba7e-679e8ecd0af4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b2f6b699-348e-4f7b-be74-94e7ce444734"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cf8f3d15-b006-4661-8e07-6b859d32a71a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d14aeeff-0cff-46b6-a1d3-e92d49e6a7c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d48cdea2-13e6-43d3-b383-426b3cb226b5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e8b5d234-f16d-4796-b2b9-a1a830eb2c4f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ee94ff3a-7674-447b-9094-21f63d33f1f1"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c347206a-8624-43be-a6f8-e0d919b21c59"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e1f8e464-9845-4211-b637-9c2fe038b528"));

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3"), null, null, "WikiPage", null, false, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852"), null, null, "WikiPage", null, false, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2"), false, null, null, "UserSubmittedWikiPage", true, null, false, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0e0c6726-246f-4ff4-9a71-c8949b703d1d"), "Consequatur doloribus non eum esse earum ipsam repudiandae accusamus. Perspiciatis hic itaque consectetur sunt. Enim rerum quos rerum quia consequuntur et.\n\nMagnam veniam mollitia et molestiae ad delectus iure laborum omnis. Quisquam error nisi. Eligendi iure ullam sed quasi. Et ut animi ipsum quos error molestiae officiis vero. Et unde culpa in sit sunt nam et quia omnis.", null, null, "Example Page 2 - Paragraph 3", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("421f2788-5c4d-4f13-bc1b-375604aa6f51"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2") },
                    { new Guid("4dc130e1-50b0-455e-b314-c9edaed9cec2"), "Veniam natus in qui odit reiciendis sunt. Soluta aliquam sed maxime. Placeat reiciendis cumque quia qui eos modi ut.\n\nQuis repudiandae est quae quidem qui nemo pariatur omnis. Tenetur et incidunt aspernatur itaque ut quidem velit. Consequatur at magnam et eius facilis perferendis ab sunt officia. Doloremque quia iste sapiente magni sunt harum libero aperiam veniam. Culpa facere harum facere et quaerat quibusdam. Eveniet sed sunt quia.\n\nSit in eveniet dolore quam quia. Qui nemo doloremque a itaque vero molestias molestiae asperiores consequatur. Vel minus libero qui inventore voluptates voluptatum impedit molestiae minima. Eos laborum architecto tenetur corrupti non sunt rerum et.\n\nUllam molestiae alias aliquam aut illum maxime et quas. Distinctio occaecati esse omnis ea ipsum dolorem et eveniet. At aperiam velit ut non necessitatibus est omnis fugit. Doloribus autem voluptatum culpa aut dignissimos. Temporibus consequatur quo tenetur numquam quam perspiciatis quia iusto. Repudiandae neque consequatur ad dolores nobis.\n\nRerum architecto sit ea omnis id suscipit sed doloribus. Ducimus earum ad facere eos voluptatem iste eligendi expedita. Ipsum rem ipsam quam excepturi possimus. Sapiente voluptas vitae optio sit qui harum perferendis dolore.\n\nEt hic illo maiores quos illum distinctio excepturi est. Cumque explicabo praesentium et accusantium. Quae quis ut. Magnam nulla atque modi.\n\nIste aut maxime sint. Similique et nihil aliquid excepturi. Quos quia unde. In aut qui optio.\n\nConsequuntur omnis est iusto magnam est quae tempora qui modi. Nisi id maxime eaque aut. Cupiditate magnam nam quo.", null, null, "Example Page 1 - Paragraph 2", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("610fb6b7-f06d-4f15-bd22-a8a77c5675e9"), "Expedita maxime dolor animi voluptatum voluptatum facere quisquam vero est. Aut praesentium quo voluptatibus animi pariatur iure voluptatem perferendis quisquam. Iusto perspiciatis qui ullam necessitatibus.\n\nEst voluptates est aliquam. Rerum neque molestiae. Voluptas amet mollitia quae dolorem qui temporibus quasi nihil. Qui aliquid sit sed tempore rerum. Laudantium autem rerum dignissimos voluptatem ab et. Fugiat soluta ut consequatur consequatur eos est.\n\nError perspiciatis et ad mollitia libero rerum. Et ut aut id. Quaerat repudiandae dolores mollitia nihil aspernatur eos modi iusto praesentium. Expedita veniam dolor nostrum dicta eius. Exercitationem libero qui temporibus deleniti occaecati deserunt hic aut.\n\nCupiditate sapiente alias inventore. Sed quod expedita voluptas. Veniam aliquid est blanditiis minima repellat numquam.\n\nOmnis reiciendis doloribus quo eos. Rerum et ut laborum quasi qui sunt. Dolorem expedita ullam sit corrupti et non nobis labore. Quia voluptatem provident explicabo iure. Ut sunt dolorem et modi cum.\n\nNeque aut omnis dolorem sunt accusamus illo dignissimos. Dignissimos reprehenderit officia delectus similique nam consectetur officiis quisquam explicabo. Aut quis sint autem ratione. Quaerat quo harum non at minus eligendi. Veritatis est ut repudiandae. Sed officiis quis nihil autem rerum et quis.", null, null, "Example Page 1 - Paragraph 4", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("69e33080-6f04-4265-8d30-e2e808731ca7"), "Minima voluptas atque ipsam necessitatibus veritatis pariatur labore facere placeat. Adipisci dolorem amet corrupti magni voluptatem qui deserunt aspernatur recusandae. Similique voluptas quia porro fugiat quos placeat. Amet quod fugiat ut aspernatur. Autem repellendus omnis est dolor dignissimos quia. Earum voluptatem quia ut reprehenderit iure sunt.\n\nA ut tempore provident. Qui soluta et sit culpa delectus sit rem voluptas non. Ullam beatae dolorem laborum quis dolorem animi velit nam nesciunt. Enim reprehenderit eos et.\n\nDoloremque alias et aut culpa magni. Sit debitis officia qui officia temporibus fuga. Recusandae corporis non sit nesciunt at molestiae voluptatibus ut nam.\n\nAspernatur consequatur optio. In aspernatur quibusdam sed illum exercitationem ullam rerum repudiandae qui. Dolore magni a quidem. Et eum amet quo quae consequatur. Inventore est nam. Ut vitae possimus sunt ipsam minus eligendi harum fuga eum.\n\nQuisquam suscipit voluptate officia excepturi tenetur asperiores quaerat corrupti qui. Quis sit ratione illo sunt consequatur dolores dignissimos rem. Exercitationem aut aliquam et nesciunt est praesentium sit. Incidunt ab qui saepe ratione molestiae aspernatur.\n\nNumquam illum consequatur facilis doloribus quidem. Possimus provident et quis quidem eos porro magnam et. Et dignissimos quia. Pariatur alias ipsum voluptates.\n\nEst non aut quo molestiae. Accusamus voluptas et doloribus et voluptates distinctio voluptatem. Nihil nesciunt reiciendis minima numquam qui dolore blanditiis incidunt. Voluptatem quis commodi iste dolor aut asperiores dolores deleniti.\n\nExplicabo recusandae sed officia. Ut magni excepturi facilis sequi quas consequuntur non recusandae. Fugit magnam non consequatur aut et et illo voluptatem.", null, null, "Example Page 2 - Paragraph 6", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("6e5b9624-3cf9-4055-8f5a-5d519e02dc17"), "Laborum quia quas. Neque modi voluptas quos qui enim mollitia blanditiis iste. Eos quod culpa saepe. Perferendis alias eius sed aspernatur. Ut porro est dolor beatae deserunt laborum maxime minima.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("75af8125-ffad-4913-8f02-c0bb6fad1523"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2") },
                    { new Guid("89e10715-3a5f-4a5d-9d43-134b36cb6c2a"), "Ut in enim provident iste. Consequatur non modi harum natus aut. Similique voluptas et officiis porro qui repellendus eum itaque provident. Ipsum harum totam maiores minus voluptatem illum repellendus rerum. Temporibus nostrum et. Quo quasi saepe neque id saepe doloribus.\n\nLibero non ratione qui harum et consequatur. Voluptas quas cum. Velit voluptas aut est labore illo. Vitae impedit dolore quasi molestias assumenda sint velit quia.\n\nNihil quasi aut assumenda omnis harum modi autem omnis labore. Autem repellendus saepe ipsum. Molestias sint quibusdam pariatur ullam quia aliquam odio iste non. Placeat voluptas reprehenderit. Facere harum amet est et explicabo ducimus dolore omnis itaque.\n\nSoluta voluptate nostrum ut dolor voluptatem exercitationem qui. Temporibus qui commodi. Ipsam et ea reprehenderit unde voluptas ut molestias sit. Porro nisi maiores.", null, null, "Example Page 2 - Paragraph 4", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("8ed161aa-c781-49e6-a208-b34854b41d67"), "Saepe veritatis illum assumenda eos dolore doloribus ullam ea. Inventore possimus quibusdam dolores qui autem pariatur. Voluptas labore laudantium sed eos et rerum architecto. Sed aut ut nam porro libero consequatur repellat beatae. Eos in placeat culpa et harum sint. Vel aut quae dolorem omnis voluptatem sed velit minima.\n\nMolestiae at reiciendis doloribus ratione labore laudantium. Consectetur quas omnis blanditiis ipsum. Exercitationem fugit qui amet tempore nobis sunt. Eveniet sapiente qui rem et doloribus. Tenetur non reiciendis. Atque qui quos dolorum.\n\nNihil et rem ea ex accusamus est temporibus consequatur. Odit in ullam. Perspiciatis repellendus totam et aut facilis quo. Asperiores ex nihil praesentium rem quia.\n\nRerum voluptatibus sequi. Suscipit in amet et sit consequatur. Aut labore aliquam quas enim. Molestiae ipsam voluptate mollitia inventore fuga.\n\nAut non omnis et. Nihil distinctio quibusdam molestiae ut enim dolor. Repellat et non libero ex a ut adipisci nulla et. Tempora ipsam officiis animi ullam minus voluptate. Quia et laboriosam ut quo corrupti voluptas assumenda voluptatem. Provident dolor repellat voluptas accusamus iste eos recusandae.\n\nCupiditate provident ipsam voluptates. Itaque autem ducimus sit vitae ab commodi dolorem provident aut. In vel et voluptatem accusantium aut.", null, null, "Example Page 1 - Paragraph 3", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("b624386b-c477-42ae-9e6f-aac1805d4e26"), "Sint quae aut dolores reprehenderit omnis asperiores iusto voluptas. Esse non aut expedita molestias. Aperiam numquam labore quis quam sunt.\n\nCupiditate eveniet blanditiis rerum inventore exercitationem. Voluptatem vero sit sequi quia voluptate. Et est dolores facere nobis ipsum ut ex. Ut cupiditate omnis voluptas ut. Eligendi sed voluptatem est consequatur.", null, null, "Example Page 1 - Paragraph 6", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("cf9c7a49-3fee-446e-9d34-05c2c65e93d2"), "Sed et quia. Mollitia est minus magnam possimus doloribus reiciendis quos sit. Reprehenderit laudantium possimus deserunt atque.\n\nVoluptatem dicta suscipit doloremque asperiores et omnis. Distinctio voluptas quod et dicta sint quidem est quis cumque. Laudantium ea asperiores accusantium neque molestiae repellat. Natus enim delectus nihil laudantium eum eveniet. Molestiae qui repellendus qui repellendus rerum qui.\n\nEt distinctio nesciunt maiores eligendi veniam dolorum et sunt. Debitis iste omnis. Architecto harum odio consequatur perspiciatis libero perferendis beatae aut quia.", null, null, "Example Page 2 - Paragraph 2", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("d228e3c2-63fb-4e91-ba58-465aeb809767"), "Dolores eos sit qui odit maiores cum. Suscipit et molestiae ut. Eius id molestiae deleniti. Inventore doloremque sunt sit repellat.\n\nSunt et ullam ea et. Veritatis enim voluptatem magni id fuga eius. Minima sit qui quia ut accusamus error et cumque. In aspernatur nihil magni. Velit sunt recusandae voluptas.\n\nIpsum quo quo a repudiandae ipsum. Nam qui voluptatem quia consequatur consequatur. Fugit quod quis et id ea itaque unde ut. Et quia quod beatae. Qui sapiente deserunt et unde.\n\nPossimus mollitia eum est fugiat facilis deleniti suscipit doloribus est. Id voluptas sint in sed et tenetur ut temporibus. Iste corporis est. Placeat et doloremque. Laborum accusamus est amet et qui voluptatem aperiam.\n\nDelectus vel cum mollitia voluptatem autem. Vel ut fuga atque delectus aut error. Id amet nemo molestias ea laudantium expedita.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("d86c5c5e-5826-459b-9f90-6c33328d2b30"), "Minima consequatur et magnam ipsa est qui vero rerum laboriosam. Veritatis est ducimus delectus nostrum inventore culpa vero ut. Doloribus accusantium laborum ratione assumenda fugit perferendis aut.\n\nTotam ut neque minus sequi consequuntur asperiores debitis. Asperiores ab quis aut numquam quo omnis id aut qui. Ut sunt nihil numquam. Quis provident in et exercitationem facere eligendi et. Minima aut soluta illo ullam ut est est aliquid.\n\nSit inventore non consequatur autem. Sed dolorem repellendus voluptas reprehenderit mollitia consequatur laudantium eos ea. Et nihil voluptates occaecati omnis iste repudiandae doloribus soluta accusamus. Dolorem quo hic. Recusandae magnam tempore hic assumenda laborum id aut ea.\n\nRepudiandae vel in quaerat placeat vel. Pariatur eos mollitia ad ut. Nesciunt quod aliquid incidunt qui. Sint beatae illum sit.", null, null, "Example Page 2 - Paragraph 5", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("fa4578a8-d6f2-4043-b10c-62faae9459cc"), "Et quam eaque nihil illo beatae vitae aut esse eius. Mollitia temporibus animi qui rerum quia est ab. Cum facere debitis placeat magnam nobis et at.\n\nMinus quis voluptatem rerum corrupti. Beatae sint tempore ratione error consectetur optio. A incidunt aliquid.", null, null, "Example Page 1 - Paragraph 5", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f"), false, null, null, "UserSubmittedWikiPage", false, null, false, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("d277735e-cb54-4881-afef-7366d861f827"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f") },
                    { new Guid("ec8e2978-7158-4909-b616-70c9e3244e18"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0e0c6726-246f-4ff4-9a71-c8949b703d1d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("421f2788-5c4d-4f13-bc1b-375604aa6f51"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4dc130e1-50b0-455e-b314-c9edaed9cec2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("610fb6b7-f06d-4f15-bd22-a8a77c5675e9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("69e33080-6f04-4265-8d30-e2e808731ca7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6e5b9624-3cf9-4055-8f5a-5d519e02dc17"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("75af8125-ffad-4913-8f02-c0bb6fad1523"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("89e10715-3a5f-4a5d-9d43-134b36cb6c2a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ed161aa-c781-49e6-a208-b34854b41d67"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b624386b-c477-42ae-9e6f-aac1805d4e26"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cf9c7a49-3fee-446e-9d34-05c2c65e93d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d228e3c2-63fb-4e91-ba58-465aeb809767"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d277735e-cb54-4881-afef-7366d861f827"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d86c5c5e-5826-459b-9f90-6c33328d2b30"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ec8e2978-7158-4909-b616-70c9e3244e18"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fa4578a8-d6f2-4043-b10c-62faae9459cc"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852"));

            migrationBuilder.DropColumn(
                name: "Category",
                table: "WikiPages");

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5"), null, "WikiPage", null, false, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("c347206a-8624-43be-a6f8-e0d919b21c59"), false, null, "UserSubmittedWikiPage", true, null, false, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("e1f8e464-9845-4211-b637-9c2fe038b528"), null, "WikiPage", null, false, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("151154a1-fc85-402a-aee0-bdb883ba72b7"), "Nihil ab nulla laborum asperiores consequatur delectus ratione ab. Modi voluptas accusamus nihil eos. Qui esse porro. Provident itaque laudantium.\n\nRerum error incidunt et molestiae animi ad qui. Ea voluptatibus hic. Repudiandae et distinctio rem amet. Dolores atque tempora cumque velit similique expedita expedita ipsam.\n\nMolestiae quod ducimus non fugiat. Sapiente iste dolores illo. Illo eos soluta autem. Temporibus velit qui. Facilis modi quia nobis ex autem eum omnis. Iste quia possimus porro molestias autem iusto.\n\nVelit blanditiis deleniti. Recusandae ex et dolorem accusamus doloribus. Optio qui sunt hic voluptatem dicta quam ipsa accusantium eaque.\n\nAut libero aut omnis non vel nesciunt quidem. Eum similique illo rem impedit error id alias dicta. Rem mollitia consectetur amet dolor. Nisi quos exercitationem.\n\nA aperiam distinctio aspernatur voluptates a. Natus explicabo accusamus voluptatem. Maiores sint voluptatem minima sunt sed quaerat aut est. Qui assumenda ipsa totam et porro quasi rerum quo.\n\nEius ipsum voluptatibus mollitia qui maiores voluptas. Dignissimos dolores consequatur modi vel quia voluptas. Quidem quo et aut odit. Doloremque deserunt et in incidunt enim.", null, null, "Example Page 2 - Paragraph 2", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("27e21529-90dd-4ee6-a7ab-d3c2c9feabb4"), "Rerum reprehenderit aut consequatur in quod saepe assumenda nulla aut. Nemo ut voluptas exercitationem velit delectus neque qui unde temporibus. Voluptatibus eveniet consectetur.\n\nVoluptatem dolorum vero. Esse illo et vel voluptas voluptatem aspernatur. Sed quis et in voluptate. Culpa minus quas ut.\n\nCum est dolores perspiciatis. Fuga qui quas sit voluptates et voluptas assumenda. Soluta ducimus in beatae eligendi eos quas consequatur sint repellendus.\n\nNihil quia id sunt sit eum nulla. Assumenda et earum neque ex asperiores. Minima et non minus in eaque sed. Sapiente possimus magni similique. Qui error placeat soluta saepe. Fugiat voluptas consectetur molestiae excepturi.\n\nCorporis et perferendis. Qui iusto suscipit aut omnis. Libero soluta quidem eos. Voluptatum iste non ut labore aliquid et rerum. Libero cupiditate dolorem perferendis.\n\nDelectus autem dolor. Recusandae sit a. Nostrum possimus consequatur et quis pariatur accusamus vel. Qui incidunt consectetur et sint temporibus eos ut sint. Enim officiis et eveniet vero laudantium ut molestiae est. Accusantium quis perferendis.\n\nOfficiis tempora vero. Veritatis deleniti quidem vel qui ut eveniet at quisquam. In dolores minus at quaerat.\n\nEt error non illo quia eos ratione quos architecto. Sed et aut totam a quaerat ullam vel illum. Beatae inventore sequi nisi autem minus explicabo neque. Ratione quod qui voluptas eos est distinctio.\n\nEsse pariatur amet natus et voluptatem. Laborum tenetur quisquam debitis. Culpa animi praesentium velit laborum excepturi. Ex explicabo dicta mollitia. Deserunt deleniti natus quas dolorem aliquam nostrum.\n\nTemporibus quas excepturi aperiam enim sapiente eaque qui dolorem. Error corrupti aut accusamus fuga fugit velit. Odit maiores ipsa sit quo. Sed corporis temporibus ut. Eligendi ut tenetur magni molestiae praesentium inventore placeat. Soluta provident at facilis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("466a5f54-f096-41fa-8235-20389310b3f8"), "Aut numquam soluta soluta suscipit laborum laudantium ipsa consequatur. Voluptatem culpa esse delectus temporibus delectus neque delectus nostrum quaerat. Vero est et. Odio laboriosam cum. Ab soluta consequatur nisi expedita. Enim sed est earum eos minus.\n\nOdio ullam nam ut adipisci provident et labore. Voluptatem aliquid eum quibusdam cumque ut et ipsa cumque. Veniam quibusdam animi inventore dolor omnis eum.", null, null, "Example Page 1 - Paragraph 4", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("62a0ad9a-61d7-4d3c-90c4-64ed6b7623d2"), "Sint dolorum nihil asperiores atque repellat non ipsam. Quia esse iusto et quae distinctio est. Aut quia ad praesentium unde odio esse. Quam sed dolorem dolores voluptas cum delectus incidunt qui rem. Eum dolores eveniet omnis. Deserunt perspiciatis veritatis voluptatem porro.\n\nOptio magni et sunt vel iusto nam aliquam impedit repellendus. Repellendus facilis libero. Sequi debitis aut dolor sapiente. Est quidem sit veritatis. Perferendis vel non voluptatum unde. Dolore nulla labore earum exercitationem sequi quo impedit corporis.\n\nTempore inventore asperiores qui occaecati dolores sed ullam eos. Nisi cum minus corrupti tempora quia molestiae autem. Dolor eum eos a. Alias omnis similique ipsa rerum qui similique qui tenetur tenetur.\n\nBlanditiis commodi consequatur asperiores ab. Et veritatis et expedita et quaerat at aliquid sit eum. Laborum ut aut odio debitis est quo et libero.\n\nPerferendis reiciendis deserunt minus ipsa modi sunt odio ipsum. Eligendi a rem repellat corrupti quis. Ea in molestiae neque quo et laborum consectetur. Sit corrupti eius doloribus porro alias. Iure nisi occaecati facilis quam quia cupiditate neque cumque.\n\nAut numquam voluptatum voluptatem qui. Et voluptas consequatur in blanditiis error voluptatem neque. Unde corrupti et modi tempora quasi.\n\nAccusantium itaque laudantium laudantium id laudantium minus recusandae. Aliquam soluta repellat esse nulla eligendi enim. Inventore excepturi laboriosam animi.\n\nDolorum dignissimos molestiae iste accusantium enim harum omnis sapiente est. Consequatur a amet expedita dolorem eveniet. Molestiae totam sapiente molestias ut ut aut aliquam iste. Animi quia distinctio sit facilis corrupti omnis aut. Facilis necessitatibus quod incidunt cupiditate quis. Culpa cumque sapiente perspiciatis ut ea.", null, null, "Example Page 1 - Paragraph 6", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("6cfbf0e0-93d6-407e-97f9-4cb2f5c0909d"), "Praesentium consectetur quo. Recusandae fugit facilis dolorum illo ut ipsam saepe eum repudiandae. Nam animi ratione qui maxime aperiam.\n\nAut aut ipsam laborum impedit quasi dicta animi quasi. Sint reiciendis sed est et adipisci. Non eum aut quasi sunt rem. Voluptates nulla voluptatem laboriosam omnis non sunt tempore quis. Illo culpa consequuntur expedita ratione ab qui reiciendis occaecati. Reiciendis distinctio totam est natus dolorem iste excepturi consectetur sed.\n\nAssumenda excepturi perferendis aperiam officia sit ut saepe delectus. Qui quidem iste est asperiores quia qui est consequatur est. Alias ea dicta id repellendus in qui voluptatum qui. Aperiam unde qui maxime est et dolorem sit qui nisi.\n\nEst commodi et quis placeat est harum dolor molestiae perferendis. Tempore vero est nihil et sapiente enim id. Et est provident. Labore dolores ipsam ex quibusdam cumque.\n\nVoluptatibus dolores repellat ipsa. Quia amet et exercitationem occaecati dolore unde qui. Aut nam aliquid vitae harum ipsum dolores in.\n\nEt consequatur non qui eos. Eum temporibus soluta. Quidem ea rerum id molestias ipsam. Commodi nobis omnis repellat modi eveniet voluptatibus rerum nihil tenetur. Corrupti et ut delectus reprehenderit asperiores. Atque placeat explicabo itaque ea architecto.\n\nOfficiis sed soluta ipsum et aperiam assumenda magnam. Aut autem iure velit qui at. Quis quo blanditiis id doloribus consequatur qui omnis. Ex quia deleniti aut.\n\nAutem mollitia inventore. Voluptas et dolores officia ea. Qui earum voluptatem repudiandae aut ut labore nihil reprehenderit.\n\nProvident qui et enim odio eius expedita porro. Qui consequatur eaque debitis. Omnis nisi maiores sit unde illo aut maxime ut perferendis. Soluta aspernatur voluptatem suscipit quasi.", null, null, "Example Page 2 - Paragraph 6", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("75cf41f2-2481-466d-b4fc-b3a66282892b"), "Tenetur nam ut odit doloribus fuga debitis sit qui. Numquam aperiam quas sit qui dolores et commodi. Inventore explicabo voluptas dolore et quasi illo amet. Odio dicta repellendus enim sed sit. Quia nobis facilis. Eius placeat provident dolorem voluptate illum.\n\nTempore sit et numquam vel alias autem exercitationem totam quia. Voluptas voluptatem distinctio sint ea. Sunt enim amet. Corrupti esse id et. Esse in sint aut sit velit atque magnam est. Sunt porro molestiae explicabo quia repudiandae.\n\nPossimus consequuntur dolore eaque. Omnis voluptatem sequi animi. Et vitae dolorum quod aut et dolorum sed officiis enim. Voluptas veritatis laborum fugit ea sunt dolore sint nisi. Consequuntur doloremque culpa.", null, null, "Example Page 1 - Paragraph 3", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("7ad64171-6741-4a11-b397-059943d22f48"), "Mollitia asperiores eaque ullam quas sapiente maiores rerum quod. Officia veritatis repellendus ipsa. Consequatur quia id officia officiis quidem et deserunt. Et voluptatem qui deserunt numquam aspernatur consectetur. Consectetur corrupti et aliquid officia est et. Aspernatur officia modi sit error architecto nihil fugit ut.\n\nExpedita omnis molestiae et provident neque. Eos vel aut quo aut magni. Autem quod similique sed ipsa quaerat. Modi ipsa animi qui illo sit aut vitae.", null, null, "Example Page 1 - Paragraph 5", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("8df9f4c2-9928-43e6-867f-78f4a3eaef28"), "Reiciendis temporibus aut id ut. Consequatur eum necessitatibus facere. Sed maiores id vero laboriosam autem. Tenetur est deserunt animi ea omnis qui quae exercitationem molestiae.\n\nVel est dolores sed sit maxime ipsa cupiditate suscipit eos. Laboriosam dolorem natus similique quae et. Voluptas assumenda eaque alias nesciunt odio quia. Quasi possimus qui exercitationem iste aut.\n\nAutem optio ipsa ipsam. Blanditiis et et. Consequatur quo velit inventore voluptatem natus. Ut sint praesentium aut voluptatem commodi at aut qui. Similique consectetur qui voluptatem molestias id. Itaque officia eaque eius sunt quo quod.\n\nBlanditiis qui consequatur. Nesciunt eum voluptates eius. Velit labore alias et autem quod laudantium. Qui quisquam dolor ut quaerat et nostrum. A voluptatem non dolores porro ut. Quis in nemo doloremque nobis.\n\nAutem aut doloremque nesciunt omnis quam et enim. Voluptas voluptatibus tenetur nemo numquam enim deserunt. Optio enim doloribus est ut quae et optio est. Modi iusto illum quo at ipsum nobis perspiciatis.\n\nEx et voluptatibus aliquid. Recusandae architecto tempore blanditiis magni. Recusandae quia ut ab optio voluptatem quaerat. Placeat nulla error voluptate. Dolore excepturi eligendi ab a ut. Aperiam aut doloremque quidem.", null, null, "Example Page 2 - Paragraph 3", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("ac56ad23-9a4e-42dc-ba7e-679e8ecd0af4"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("c347206a-8624-43be-a6f8-e0d919b21c59") },
                    { new Guid("cf8f3d15-b006-4661-8e07-6b859d32a71a"), "Maiores suscipit voluptatem voluptas inventore. Deleniti et quasi voluptas minus. Incidunt et labore. Voluptatem ad provident.\n\nQuam tenetur et odit non ea accusamus occaecati nam. Exercitationem molestias et. Nostrum expedita sed harum dolores. Dignissimos amet tempora. Repellat suscipit aut corporis quia dolorem ratione nemo qui.\n\nAut libero aut blanditiis quidem reprehenderit quia aut enim architecto. Possimus rem delectus ipsam quo libero et et. Non minima nisi perferendis atque. Qui et sit quisquam quaerat. Consequatur commodi corrupti.\n\nHarum iste exercitationem eos laboriosam quas nesciunt. Minima quibusdam eos natus harum et excepturi. Expedita qui error maxime nostrum ullam ut eum ratione. Maiores soluta et qui natus delectus sit voluptatum quidem neque.\n\nDolorum eos beatae qui quia aut. Dolores maiores alias numquam expedita. Nisi aspernatur sunt. Excepturi earum ut. Assumenda aut expedita maiores repudiandae dolorem sit modi.\n\nEt soluta nam quisquam quia nemo maxime fuga aliquam. Rerum sed ea fuga esse. Voluptate velit sequi tempora aut dolor quae rerum labore repellendus. Nisi quaerat impedit. Cum et quo vel. Temporibus est eum aut voluptas nam architecto a ad autem.", null, null, "Example Page 2 - Paragraph 5", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("d14aeeff-0cff-46b6-a1d3-e92d49e6a7c0"), "Et aut dolore voluptatibus fugit aliquam. Corporis blanditiis libero. Rerum quia voluptatem quas. Enim rem doloribus omnis minus magnam alias quia modi repudiandae. Alias quidem a enim voluptatum est voluptate nobis aliquam repellat.\n\nFugiat sint voluptatem molestiae similique. Asperiores repellendus rem iusto dolore sit doloribus. Ut culpa saepe est quia. Corporis est expedita expedita. Est sed dolorem sunt molestiae repudiandae placeat repellendus repellendus.\n\nLaboriosam nihil qui aperiam similique voluptatem sint et. Sed vel minima necessitatibus voluptate vel voluptatem facere dignissimos. Sequi adipisci est mollitia in debitis voluptas qui omnis odit. Repellendus assumenda est quod pariatur.", null, null, "Example Page 2 - Paragraph 4", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("d48cdea2-13e6-43d3-b383-426b3cb226b5"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("c347206a-8624-43be-a6f8-e0d919b21c59") },
                    { new Guid("e8b5d234-f16d-4796-b2b9-a1a830eb2c4f"), "Commodi similique fugit sapiente repellendus sunt qui sunt quis quod. Consequuntur doloribus ad numquam voluptatem enim temporibus voluptas. Magni et aut ducimus officia.\n\nAut iste molestias. Quasi ad vitae et. Ratione laboriosam libero.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("ee94ff3a-7674-447b-9094-21f63d33f1f1"), "Et aut quos rem porro asperiores. Sit deleniti eligendi aspernatur iste cum et ad amet. Asperiores temporibus eveniet qui. Culpa et iure excepturi inventore non qui qui sunt nobis. Natus tempore cumque exercitationem eum reprehenderit et omnis quam ipsa.\n\nIncidunt dolorem id sit vel officiis magnam quia perferendis voluptas. Illum odit dolor impedit veniam voluptatum. Nam cumque quidem qui eos. Qui in modi sapiente. Velit inventore voluptatem omnis deleniti ipsam.\n\nNam ipsa commodi excepturi necessitatibus sapiente nobis sit. Sint et voluptatem sit voluptates voluptatum. Vel atque molestias qui molestias dolores architecto veniam id reprehenderit. Consequatur adipisci pariatur est voluptas. Vel commodi ab.\n\nVel aut non ut fugiat distinctio nesciunt sunt reiciendis. Laudantium ut amet commodi eum expedita sed quidem. Adipisci sequi voluptatum nesciunt vel sapiente rerum dolores et.\n\nMinima illo doloribus labore est veniam labore. Quo aut saepe nulla omnis tempore cumque assumenda pariatur. Velit eos recusandae eos porro. Error voluptatum placeat corrupti et voluptates dicta. Quia qui autem eum illum velit in quas consequatur. Nihil culpa eius omnis sunt modi vel.\n\nIusto excepturi aut et eaque exercitationem quibusdam omnis. Doloremque consequatur magnam aliquam nostrum et. Error voluptatem quasi vel eveniet nihil nulla inventore. At vitae debitis eos. Et est dicta aut ipsa.\n\nEx soluta quam non. Minus dicta porro nihil labore eum rerum. A a eaque quas omnis iusto. Eum occaecati est et adipisci et quo suscipit.\n\nInventore itaque eveniet rem blanditiis. Adipisci praesentium accusantium illum sit. Maxime vitae aut nihil.\n\nOmnis quo dolorem quos qui. Explicabo dignissimos aperiam officia. Ut eligendi dolores cum nihil. Molestiae eum reiciendis vitae perspiciatis qui nihil. Minima vel et est.", null, null, "Example Page 1 - Paragraph 2", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f"), false, null, "UserSubmittedWikiPage", false, null, false, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("2a87a6e8-dd49-466f-aff6-1e4997fa77ff"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f") },
                    { new Guid("b2f6b699-348e-4f7b-be74-94e7ce444734"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f") }
                });
        }
    }
}
