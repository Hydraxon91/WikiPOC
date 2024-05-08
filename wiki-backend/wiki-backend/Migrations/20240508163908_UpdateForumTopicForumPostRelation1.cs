using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumTopicForumPostRelation1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("097b2094-5d35-4de9-9a4c-d10fb0751304"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0fa754d7-4494-4662-a638-bea706fadadb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("466aa4d7-4386-4fb9-9e4d-f1ecd7157791"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("53275ad7-2c4d-423b-9e9a-43f43f57abe1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b9a8d9c5-a020-483c-ba4d-e62d3cf79bb0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c2b8d769-c783-4d3b-8124-e498f7787138"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("db1dfcbf-6b77-41bf-a9dd-37f4ba93c600"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb38908b-46ba-499a-b734-a90ca449d60f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("25be95dd-0bc5-4aa1-ac93-d08bfdd19af9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2724b2f8-75b9-414d-a89b-c92047004eff"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2739d505-c86d-411f-8e73-95d4567833fd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("348fb5bc-c4f7-42d7-b6c1-28c64bde8cbf"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4d35a002-c9ec-43d9-aa0d-d04e5518c052"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7a1fddac-fb0d-40ec-856d-a8869679d7ce"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8da1b2e2-cd79-4a78-9703-7c38edc776f6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9bc061bd-ec97-4ef6-9363-d64d4644aa22"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c05dd94d-1cad-43b1-8b03-9a3a056fc447"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cdcf1209-82ea-4b9e-9978-56286a13e065"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ced76387-c570-4344-8a20-7f01d6cc9292"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d42ab779-d63c-40f9-b354-3ffe84bb6519"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("de082c84-e039-4f66-84c5-7b4503e96287"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f625f070-8702-4f84-bffd-54cd94abcb4a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f7d77d73-6df6-4316-9583-42d06d28d644"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f9067fc3-0cc0-418d-a4f8-b6c959c7eeea"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1d259f29-e251-483f-a6f5-c703a9fdbaaa"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("aeef9d1d-4e88-4dc0-bd7d-afda32b5397e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("62e9c5cc-10f8-4b81-9b5f-ac01995efb02"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("694d1896-8a70-4aea-92c2-82f39deea305"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bc66a05e-b39b-4755-8e93-fcf03cba27e7"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("edb31b71-224a-4b58-83c6-964a3fc203b8"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForumTopicId1",
                table: "ForumPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("08580574-1ccc-4d93-b8b1-e99841ee1222"), "Sports and Recreation" },
                    { new Guid("1800909e-b5ce-4a77-8c7a-24afe7c966a5"), "Science and Technology" },
                    { new Guid("22806e2b-8b0e-4174-8cd8-150c629f712e"), "Technologies" },
                    { new Guid("2bde6020-3574-42d4-924e-8865d8410466"), "Concepts" },
                    { new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"), "Characters" },
                    { new Guid("51b8cbd6-53fa-407b-8f11-b2fa48348735"), "History and Culture" },
                    { new Guid("520d0d08-864a-4d0c-83b8-744e3ce41917"), "Arts and Entertainment" },
                    { new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"), "Events" },
                    { new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"), "Stories" },
                    { new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"), "Locations" },
                    { new Guid("d91e8ef3-2e1d-4989-9c01-b7f1f29730f3"), "Food and Drink" },
                    { new Guid("e14b77d1-0b48-447a-b097-775f0a7be345"), "Organizations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373"), false, new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5740), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("aa149b37-54bc-4660-b3e6-15225f838045"), new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5595), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b"), new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5556), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("24ba0646-ecec-417f-803b-971e263cdda2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373") },
                    { new Guid("29aae45c-995e-4df6-85ee-da4cddb289c0"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373") },
                    { new Guid("42239ab1-8da4-45ea-9716-849b6bd59836"), "Unde deserunt aut fuga facere esse sed ipsa itaque omnis. Et blanditiis repellat. Quae numquam hic quae rem qui voluptas animi dolorem. Est aut facere.\n\nCommodi consectetur totam distinctio autem repellat error porro. Voluptatem nihil quia. Earum voluptate quos eos vitae ut qui. Dignissimos neque necessitatibus. Et distinctio corporis fugiat voluptatem.\n\nVoluptatem vel quo error. Ut sint delectus debitis expedita cum vel perspiciatis libero repudiandae. Accusantium delectus totam recusandae quo distinctio velit. Rerum doloremque voluptatem qui nam quas excepturi quam. Quos esse autem mollitia doloribus. Quidem totam tempore.\n\nHic minima assumenda dolorum sint eos qui autem laudantium. Enim et veniam nobis quo sunt. Consequatur qui molestiae. Nobis ullam omnis quia officiis sed. Minima harum sequi rerum nostrum maxime repellendus modi amet.\n\nPraesentium iste possimus autem dolore soluta ut. Temporibus corporis saepe autem amet et harum. Accusantium vero nihil. Fugiat qui similique tempora voluptates non. Quaerat officia quia ducimus aspernatur nostrum aut sed.\n\nCulpa nihil consequatur. Dolore aut itaque quas eos voluptate quia. Sit facere fuga et porro aut eius esse quis. Nihil id dolores facilis voluptatem nihil. Voluptas id velit explicabo pariatur cum ex sit. Sit quisquam doloribus minima voluptatem.", null, null, "Example Page 1 - Paragraph 3", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("5a33443a-2aeb-4cf5-9c56-b643260d59aa"), "Sapiente dolorum numquam provident molestiae incidunt sunt eum. Numquam quis odio. Repudiandae vero dicta ducimus repudiandae ut. Molestiae consequuntur qui ducimus dicta ex.\n\nEt dolores est numquam laborum aliquam nihil neque. Fugiat consequatur quam quia. Aut et ad aut. Unde rerum qui temporibus ea quos tempora aut consequatur.\n\nIste autem corporis esse exercitationem cumque. Rerum quisquam consectetur. Numquam accusamus excepturi.\n\nConsequuntur in et libero quod. Qui tenetur sit beatae voluptas ut possimus quis ea laudantium. Cumque in est officia. Ut sequi quia enim sequi.\n\nSit ex nostrum voluptate. Aut optio eum quo accusamus ipsa est nihil. Perspiciatis molestiae qui. Minima necessitatibus consectetur sed.\n\nQui quia nulla architecto. Quisquam laborum eos nisi fugit nihil quia. Culpa et error ad et non.\n\nIusto aut reiciendis magnam. Placeat numquam repudiandae et qui modi consectetur. Quibusdam est repellendus quidem iure labore. Rerum assumenda est. Rem pariatur voluptate omnis et consequatur. Molestias commodi consequatur.", null, null, "Example Page 2 - Paragraph 3", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("7554d1ed-e7f9-429f-8245-ef860825ad33"), "Ipsam fugiat quisquam. Ratione fugit tempore dolor veritatis et itaque qui est. Incidunt eius occaecati eius error soluta architecto. Sed quia voluptas rerum. Ut voluptatem voluptatem.\n\nVoluptatum autem sunt magnam non incidunt repellat. Eum ullam eum quidem dignissimos. Non ut quia optio aut cumque. Voluptatem animi voluptates culpa et excepturi. Qui ipsa quam dolorem nihil repudiandae et autem at dolore.\n\nMolestiae enim eos et laboriosam iste. Voluptatem et id quis libero. Maxime dignissimos voluptates eaque similique ipsa ut. Natus accusantium consequatur mollitia aut quasi deserunt nam ut fugiat. Qui iure qui eum officia est sunt ipsam iusto consectetur.\n\nVoluptatem et aliquam delectus similique molestiae fugit. Illum quis quia omnis voluptatem. Ex qui et sint nobis rem tempore quod. Deleniti deserunt sunt. Voluptatem a et a sequi at temporibus voluptatibus quia sequi.\n\nPerferendis ratione est et ad a id praesentium sint. Quis fugit velit. Veritatis neque facere ad eos dolore laborum occaecati. Eos et occaecati aut sed sequi in pariatur deleniti est. Ut modi praesentium vel expedita. Autem architecto numquam omnis.\n\nAccusantium odio et vel omnis adipisci optio cum illum enim. Aut alias eos debitis voluptatem iusto facilis perferendis. Molestias commodi porro quasi mollitia provident et adipisci totam.", null, null, "Example Page 2 - Paragraph 6", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("7c95579f-987c-4eb6-9901-8e96bc36245e"), "Voluptatem blanditiis et laudantium voluptas et vitae nesciunt quasi. Omnis sed error reprehenderit velit dicta accusantium commodi earum. Dicta quam accusantium repudiandae non voluptas dolorem. Debitis est veniam quos odio maiores error ipsa. Velit omnis magni labore illo ut ut in.\n\nTotam repellat eum qui molestiae beatae non. Voluptates blanditiis voluptas ipsum voluptas facere architecto. Modi quo non quia ut consequatur ab aut. A dignissimos maiores et.\n\nQuibusdam fuga iure consequatur voluptas cumque vel. Quo assumenda inventore. Esse blanditiis voluptate nihil repellendus. Rerum debitis delectus et ea fuga ullam eligendi sunt tempore. Iste numquam sint repellat voluptate qui perferendis accusantium doloribus. Aliquid enim consequuntur.\n\nDistinctio quia alias labore. Quae dolores aperiam alias rem eos vel molestiae dolor. Dolores odit quia expedita corrupti suscipit aperiam labore at et. Provident voluptatem ea accusamus doloribus adipisci mollitia est. Architecto consequatur occaecati consequatur. Voluptatem eum sed amet.\n\nEa ipsa illum rerum ad architecto voluptas accusamus autem qui. Qui non cumque ut dolore omnis dolore reprehenderit a non. Culpa eveniet nostrum magnam amet ut corporis voluptatum qui.\n\nEum ut eum sint ea nisi vel. Deserunt rerum quisquam qui suscipit quibusdam recusandae. Inventore vero soluta eius.\n\nIpsum architecto dolorem ratione. Ex occaecati recusandae atque. Est sit est reiciendis perspiciatis consequatur saepe animi odio nam. Laboriosam eveniet beatae praesentium quas. Facilis facilis ducimus ut.\n\nArchitecto beatae consequatur aut necessitatibus rerum. Voluptatem dolores repellat corrupti ut totam commodi fuga omnis nostrum. Sit ut ipsum cumque sint dolorem.\n\nEt dolores et eos et unde culpa ut. Autem sint et blanditiis repellendus recusandae fuga. Qui ut nisi repudiandae. Nostrum labore et enim voluptatibus blanditiis provident ex. Quisquam veniam ducimus voluptate omnis ipsam autem odio.", null, null, "Example Page 1 - Paragraph 5", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("8165c1d0-8928-46c5-8c9a-505a50e7d851"), "Et aut officiis accusamus architecto. Impedit id dolorem. Nihil ut vero voluptate. Enim recusandae in ipsum et molestiae magnam.\n\nEaque dolorum aliquam occaecati alias qui et. Ut fugit omnis. Aut sunt amet omnis et debitis facere velit ut. Est non velit quibusdam est sequi doloribus quae accusamus. Enim hic laboriosam reprehenderit nostrum et et.\n\nAut officia dicta rem quos saepe iste omnis aspernatur eaque. Id at totam qui libero facere temporibus est molestiae amet. Delectus consequuntur ipsa. Non aut possimus. Vero aliquid non excepturi nam est rerum et consequatur. Est voluptatum dolorem non illum consequatur similique quo voluptatem.\n\nSapiente delectus dignissimos earum est occaecati consequatur enim cum qui. Minus voluptatem harum dolore nam. Nulla in omnis non autem fugiat et optio.\n\nOptio eum sint dolorem. Sed sequi ratione aut sunt quas quia quas. Quibusdam est laudantium alias ad harum laborum nesciunt ullam maiores. Aut exercitationem delectus autem voluptatem nihil error cum. Culpa et iusto dolores commodi quasi eos ea eos. Dignissimos reprehenderit voluptates reprehenderit.", null, null, "Example Page 1 - Paragraph 2", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("890669b8-6bed-4e76-9fb5-d5f54046a291"), "Beatae cum laboriosam ea exercitationem quas iure nihil non. Tempora consequatur delectus ullam accusamus. Reiciendis culpa et et magni nisi quos voluptates. Sit sunt voluptates dolores dolorem iure architecto dolore id.\n\nEx id quaerat quisquam et sit provident. Minima dolor voluptatum vitae ea adipisci labore. Voluptatibus recusandae ducimus unde. Eos delectus atque veniam adipisci a sequi sed.", null, null, "Example Page 2 - Paragraph 2", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("8ae42a7c-ec6d-4adb-a7dd-78c784abf689"), "Ut consequuntur suscipit architecto. Est occaecati dolor eos veniam vero non. Sed id autem. Quidem voluptate et in ut modi fuga natus. Excepturi corporis dolorem sit sit officiis laudantium rerum laborum.\n\nFuga aut placeat velit totam amet. Tenetur quo omnis vel aspernatur doloribus ab harum. Eligendi amet et. Nemo quaerat et sed nisi enim enim.\n\nNihil maiores distinctio numquam quas. Ut quisquam consequatur nesciunt qui dicta veniam maxime. Qui voluptates voluptas est aut sed dolores praesentium.\n\nUt aperiam eveniet est necessitatibus eum. Quia hic itaque vero odit asperiores atque fugit commodi. Molestiae sed et repellendus voluptatum molestiae. Ut error cum et accusamus magnam labore voluptatibus cum. At dolorem necessitatibus eos ipsam velit dolore culpa. Quibusdam eos minus assumenda.\n\nEos reprehenderit enim ea rem repellendus aut voluptas beatae. Saepe harum provident voluptate. Aut qui quo quia omnis. Et saepe et nulla et culpa et modi optio rem. Voluptatem blanditiis qui similique rerum.\n\nQui distinctio porro fuga vitae omnis ut et eius alias. Omnis ut suscipit sit suscipit doloremque asperiores necessitatibus odit. Tempora at molestias quo vero officia voluptates quam commodi.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("9df870ee-73cb-4eed-9d59-ec8b687dc094"), "Illum eveniet ut incidunt eum est est nam. Est dolorem rerum est ea debitis dolor eos odit. Dolor ipsum iste soluta odit perferendis ea doloremque.\n\nVoluptas vel eius qui neque occaecati ut architecto et. Pariatur quae perspiciatis sapiente quo animi ratione. Reprehenderit rem culpa et et vel maxime asperiores animi possimus. Sed rerum ullam reprehenderit odio modi quibusdam. Impedit distinctio sunt qui deserunt ea deleniti.\n\nNesciunt eum nostrum consequatur culpa distinctio corrupti eligendi illo. Et velit officia dolorem in sed sed dolore debitis minus. Dolores est provident quo reiciendis laborum. Expedita vel possimus quis quia sit rem ut.\n\nNulla error ipsum animi ut tenetur quis debitis vel maiores. Aliquid aut magnam blanditiis numquam mollitia in ex. Laboriosam aut velit non cum recusandae vero voluptatem distinctio. Repellat assumenda et magnam ut et sed provident. Dignissimos sed sed asperiores molestiae.\n\nA amet nostrum non. Possimus quis exercitationem nihil odio. Et expedita ut quidem sequi iure.\n\nSit facilis iure quod quisquam nihil qui quos libero ut. Itaque est corporis id. Reiciendis est dolor ducimus autem magni.\n\nMinus a sint consequatur. Et odit perspiciatis occaecati tempore molestiae eos sed quos sit. Aliquam suscipit dolorum rerum omnis amet debitis ut cum. Nam sit voluptatum ad et consequuntur nisi sed eos. Qui rerum et nesciunt est et commodi et.\n\nDolorum quo enim dolores ut. Ipsam nostrum reiciendis reprehenderit porro maiores laboriosam. Voluptate reprehenderit repellat ipsam ratione doloremque et sit.\n\nQuidem voluptatum aut praesentium. Porro cumque quaerat numquam. Quia qui animi nostrum odio quidem mollitia culpa quis fuga.\n\nDucimus quia ipsum aut voluptate quisquam. Omnis animi natus sunt. Cupiditate deleniti soluta vitae recusandae non inventore enim quia laboriosam.", null, null, "Example Page 2 - Paragraph 4", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("afc06326-50cd-4bce-933e-c5b74c3a6d1f"), "Et voluptatum voluptatum. Aut odit ipsa doloribus consequatur odit nobis fugit debitis et. Dolores architecto rerum. Modi quia labore. Quasi ipsam quo sequi.\n\nRecusandae iste aspernatur qui. Excepturi et odit et reprehenderit harum ducimus natus ex. At nobis asperiores vel. Ex quaerat ea veniam esse.\n\nUt assumenda vitae illum est est et est error. Ut enim quia earum molestiae quia sed modi vitae excepturi. Dolores minima possimus eum. Qui autem optio exercitationem reprehenderit culpa quod.\n\nDolorem omnis sunt dolore itaque qui voluptate quo quaerat. Sed nesciunt ipsam quia voluptatibus dolores ut. Quod dignissimos perferendis quaerat autem. Delectus sit modi dolor explicabo consequuntur et. Voluptas suscipit dolor inventore mollitia non molestiae qui.", null, null, "Example Page 1 - Paragraph 4", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("c301050d-2a1e-424b-b323-6d60d995769b"), "Necessitatibus ratione distinctio voluptatibus sit tempora dolor et nostrum. Ipsam dolorem iste at qui et perferendis recusandae. Sit magnam vel. Consequuntur placeat quod.\n\nEt esse dolorem sit voluptates. Tempora aliquid ut ut libero molestiae iure enim est possimus. In reprehenderit cupiditate ex molestias voluptas reiciendis. Tempore exercitationem error itaque quia eligendi consequatur velit. Et ratione illo corrupti et. Molestiae expedita et molestias hic consequatur necessitatibus et labore.", null, null, "Example Page 2 - Paragraph 5", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("fa16a3a5-c9e6-47ce-84d6-9239a14df690"), "Aut non iusto adipisci animi ex architecto eum. Qui ullam accusantium sint adipisci in ducimus dicta. Voluptate iste accusamus labore doloremque.\n\nQuas ut earum qui odit. Veniam aperiam optio quaerat laudantium harum rerum soluta qui voluptatem. Eaque qui vel iusto omnis porro non ipsum. Id ut sed est omnis aperiam.\n\nRepudiandae quis quia doloremque expedita. Non quibusdam qui rem autem ipsam minus eveniet sunt ipsum. Dolorem voluptatum sapiente. Id vitae nulla. Animi ad aspernatur debitis est consequatur.\n\nMinima quis molestias porro. Cupiditate cupiditate voluptate quis est error. Est consequatur velit. Delectus qui explicabo laboriosam. Ut omnis ullam.\n\nMollitia qui tenetur deleniti ut. Iusto voluptas sit error neque et cupiditate. Facere quos sapiente eos mollitia est. Quam itaque tempora. Dolores eveniet provident ab ullam. Nulla et aut eum.\n\nEarum voluptate architecto voluptatibus dolorem eum consequatur ut rem. Dolorem omnis iste sint voluptate sequi harum alias deleniti. Ipsam magnam eum ducimus amet quas. Natus maiores aut natus odit. Id ducimus enim aliquam voluptatum. Ut sunt est illum nesciunt neque.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("ffa000db-19d3-42e4-9129-30b6db8cafc0"), "Placeat modi et. Distinctio vel fuga. Quam fugit eos. Aliquam voluptatem sunt.\n\nRepellat maiores nemo ut neque quae eos recusandae. Qui quia labore vel. Rerum aliquid deserunt rem et qui aut.\n\nAutem vel odit rerum. Aut et est beatae architecto dolor cumque. Cumque deserunt dolorem voluptatem non minus minus iusto aperiam odio.\n\nOfficiis dolor aut. Rerum magni qui adipisci fugiat ex consectetur sed sed eaque. Ut suscipit omnis repellendus enim corrupti magni ut. Eaque similique quae dolor.\n\nAccusantium doloremque exercitationem omnis asperiores voluptate est deleniti est. Labore blanditiis praesentium enim esse est rerum. Rerum est et est rerum. Sint pariatur dolorem facere et nihil molestiae error. Facere est nemo aliquid voluptatem ipsa molestias ullam. Eum quia sit eaque odio saepe expedita ratione totam debitis.", null, null, "Example Page 1 - Paragraph 6", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("237b187b-5964-4898-83f4-fecb399affb9"), false, new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5745), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("3c5c7f49-7eb0-4f8b-b8c1-32061fe83f7d"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("237b187b-5964-4898-83f4-fecb399affb9") },
                    { new Guid("a4807e66-b9a9-4254-b583-f992aa07cb28"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("237b187b-5964-4898-83f4-fecb399affb9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumTopicId1",
                table: "ForumPosts",
                column: "ForumTopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId1",
                table: "ForumPosts",
                column: "ForumTopicId1",
                principalTable: "ForumTopics",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId1",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_ForumTopicId1",
                table: "ForumPosts");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("08580574-1ccc-4d93-b8b1-e99841ee1222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1800909e-b5ce-4a77-8c7a-24afe7c966a5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22806e2b-8b0e-4174-8cd8-150c629f712e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2bde6020-3574-42d4-924e-8865d8410466"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51b8cbd6-53fa-407b-8f11-b2fa48348735"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("520d0d08-864a-4d0c-83b8-744e3ce41917"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d91e8ef3-2e1d-4989-9c01-b7f1f29730f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e14b77d1-0b48-447a-b097-775f0a7be345"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("24ba0646-ecec-417f-803b-971e263cdda2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("29aae45c-995e-4df6-85ee-da4cddb289c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3c5c7f49-7eb0-4f8b-b8c1-32061fe83f7d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("42239ab1-8da4-45ea-9716-849b6bd59836"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5a33443a-2aeb-4cf5-9c56-b643260d59aa"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7554d1ed-e7f9-429f-8245-ef860825ad33"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7c95579f-987c-4eb6-9901-8e96bc36245e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8165c1d0-8928-46c5-8c9a-505a50e7d851"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("890669b8-6bed-4e76-9fb5-d5f54046a291"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ae42a7c-ec6d-4adb-a7dd-78c784abf689"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9df870ee-73cb-4eed-9d59-ec8b687dc094"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a4807e66-b9a9-4254-b583-f992aa07cb28"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("afc06326-50cd-4bce-933e-c5b74c3a6d1f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c301050d-2a1e-424b-b323-6d60d995769b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fa16a3a5-c9e6-47ce-84d6-9239a14df690"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ffa000db-19d3-42e4-9129-30b6db8cafc0"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("237b187b-5964-4898-83f4-fecb399affb9"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("aa149b37-54bc-4660-b3e6-15225f838045"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"));

            migrationBuilder.DropColumn(
                name: "ForumTopicId1",
                table: "ForumPosts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("097b2094-5d35-4de9-9a4c-d10fb0751304"), "Arts and Entertainment" },
                    { new Guid("0fa754d7-4494-4662-a638-bea706fadadb"), "History and Culture" },
                    { new Guid("466aa4d7-4386-4fb9-9e4d-f1ecd7157791"), "Technologies" },
                    { new Guid("53275ad7-2c4d-423b-9e9a-43f43f57abe1"), "Organizations" },
                    { new Guid("62e9c5cc-10f8-4b81-9b5f-ac01995efb02"), "Locations" },
                    { new Guid("694d1896-8a70-4aea-92c2-82f39deea305"), "Stories" },
                    { new Guid("b9a8d9c5-a020-483c-ba4d-e62d3cf79bb0"), "Concepts" },
                    { new Guid("bc66a05e-b39b-4755-8e93-fcf03cba27e7"), "Events" },
                    { new Guid("c2b8d769-c783-4d3b-8124-e498f7787138"), "Sports and Recreation" },
                    { new Guid("db1dfcbf-6b77-41bf-a9dd-37f4ba93c600"), "Science and Technology" },
                    { new Guid("edb31b71-224a-4b58-83c6-964a3fc203b8"), "Characters" },
                    { new Guid("fb38908b-46ba-499a-b734-a90ca449d60f"), "Food and Drink" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36"), new Guid("694d1896-8a70-4aea-92c2-82f39deea305"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 29, 5, 444, DateTimeKind.Local).AddTicks(8566), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("1d259f29-e251-483f-a6f5-c703a9fdbaaa"), false, new Guid("62e9c5cc-10f8-4b81-9b5f-ac01995efb02"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 8, 18, 29, 5, 444, DateTimeKind.Local).AddTicks(8705), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e"), new Guid("edb31b71-224a-4b58-83c6-964a3fc203b8"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 29, 5, 444, DateTimeKind.Local).AddTicks(8521), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("2739d505-c86d-411f-8e73-95d4567833fd"), "Quod qui mollitia rerum voluptatem optio velit. Voluptatem ea et et numquam. Impedit est corrupti ducimus atque exercitationem voluptas. Eius corrupti quia. Rerum voluptate eveniet. Vel ipsam aut quia dignissimos alias voluptate.\n\nCommodi aut et minima saepe. Eius dignissimos illo et voluptate maxime in tempore beatae qui. Veniam voluptas quis magnam pariatur veritatis neque excepturi sapiente. Ullam tempora nesciunt quae consequatur accusantium voluptas. Inventore soluta sint rerum et voluptate sint ut. Temporibus ipsum dolor expedita veritatis minus aut.\n\nSunt voluptatibus et quis soluta in architecto. Ut reiciendis et esse possimus. Aspernatur sint saepe et. Sequi culpa nam excepturi sed rerum distinctio dolor voluptatem.\n\nNon magnam sit est non. Recusandae animi tempore dicta voluptas quia. Rem laudantium excepturi omnis autem. Voluptatum nemo assumenda voluptatum explicabo labore ea numquam voluptas. Qui et autem odit iure. Laborum voluptas at animi.\n\nMollitia voluptas vel quidem nemo et eius dolores. Eum qui sit consequuntur. Velit quod nemo dolores asperiores explicabo doloribus perferendis. Qui id sapiente impedit dolores dolor harum vel repudiandae.\n\nNihil rerum a. Consequuntur nihil laudantium dolorum. Autem dolorem delectus aliquid. Iure sit aspernatur qui voluptas magnam qui sequi impedit nostrum. Aspernatur consequuntur neque velit eos tempora et aut.\n\nCorporis in sunt id fugiat autem doloremque non. Sunt iusto soluta iste nemo. Adipisci vitae aut officia officiis. Quis incidunt rerum. Culpa voluptatem sequi modi culpa eligendi.\n\nNisi reprehenderit recusandae laudantium beatae id et aliquam. Ut est quo et eum aspernatur rem ipsam debitis fugit. Et voluptate ipsa porro. Et et fuga totam alias nihil voluptates sit accusamus quisquam. Corrupti eos minima.\n\nUllam qui beatae a similique. Velit reprehenderit provident et fugit praesentium numquam distinctio molestiae. Placeat ducimus soluta fuga velit consequatur voluptate. Et magni qui aut ut eum dolorem.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") },
                    { new Guid("348fb5bc-c4f7-42d7-b6c1-28c64bde8cbf"), "Voluptatem unde et dolorem nesciunt quis voluptas ut. Corporis omnis omnis. Et in sed iusto asperiores praesentium.\n\nHarum placeat soluta vitae iusto. Non tempore odio nihil eos. Ut distinctio delectus aut non omnis necessitatibus. Culpa at quo veritatis excepturi et minus vero corrupti.\n\nOmnis earum dicta debitis nesciunt tempore sunt consequatur accusantium beatae. Qui et quis maxime blanditiis. Consequatur autem minus dignissimos doloremque aut est placeat.\n\nAliquid ex tenetur et officia voluptatum sint quos nam aut. Illo dolore doloribus distinctio non. Nesciunt quas et quibusdam repellat explicabo nemo modi. Rerum temporibus nostrum corrupti laborum minus.\n\nEt nemo in voluptatem quisquam suscipit inventore ea id. Vitae ut voluptas molestias. Reprehenderit perspiciatis consequatur ab. Labore sed voluptatem sed numquam autem quidem temporibus voluptatibus omnis. Autem officia omnis et tenetur vero enim rerum. Aut qui inventore expedita laborum quia libero incidunt quis hic.", null, null, "Example Page 1 - Paragraph 3", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") },
                    { new Guid("4d35a002-c9ec-43d9-aa0d-d04e5518c052"), "Rerum quia nihil ea voluptatem sed quasi. Voluptas similique et corporis rem aliquam incidunt. Iste sint eum enim voluptas. Deserunt aliquid a necessitatibus omnis et non voluptate expedita quasi.\n\nMolestiae aut tempore aliquid commodi minima inventore sapiente maxime provident. Non impedit quam sunt pariatur minus tempore. Ut ratione dolorem aperiam amet reiciendis necessitatibus reprehenderit. Sint ut et culpa aut vitae quasi fugit quos expedita.", null, null, "Example Page 2 - Paragraph 2", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("7a1fddac-fb0d-40ec-856d-a8869679d7ce"), "Delectus maiores labore labore voluptatem quasi aliquam qui nisi ab. Ex architecto accusantium voluptatem reprehenderit ut. Delectus laborum rerum velit deserunt accusamus ipsa autem eaque magnam. Debitis soluta omnis atque.\n\nBeatae enim eum totam. Officiis tempora reprehenderit. Voluptatem porro rem et aliquid et. Nostrum perspiciatis et voluptatem qui sit. Aperiam deserunt et repudiandae. Vitae quos voluptas recusandae.\n\nVoluptas ut officiis reiciendis est accusantium sunt deleniti dicta. Autem reprehenderit reiciendis id. Dolores sed commodi natus qui. Nisi qui doloremque ullam. Id veritatis illum dolores eum necessitatibus sint eligendi praesentium distinctio. Quibusdam veniam minima nesciunt.\n\nMinima voluptate voluptatem. Possimus sint debitis dicta soluta voluptatem vitae et. Sapiente praesentium dolore provident suscipit. Quos nobis pariatur ut sunt veritatis autem sunt ut. Cupiditate aut aut non inventore ut qui ipsa libero. Rerum voluptas ex nihil in.\n\nEnim corrupti voluptas facere. Quod aut optio qui odio sed et. Tempore esse error esse atque sint animi aut sequi aspernatur. Id nihil architecto consectetur qui voluptatem. Mollitia repudiandae ut qui magni dolor illo. Molestiae reiciendis necessitatibus illo excepturi ex.\n\nOptio aliquam eveniet et unde quo harum cum. Quod modi vel consequuntur hic et ut occaecati voluptatem. Eaque voluptatem unde qui omnis. Dolores quasi possimus nulla dolor recusandae quis minus repudiandae. Omnis aliquam consequuntur soluta adipisci dolores voluptatem et.\n\nCumque dicta qui nihil placeat et omnis consectetur. Exercitationem inventore dolores eius. Tempora porro deserunt voluptatem natus mollitia consequatur consequuntur sit laudantium. Omnis id incidunt assumenda qui autem cumque mollitia iure. Aut maxime excepturi laboriosam saepe quibusdam est deserunt. Quis libero commodi dolorem fugit sit.\n\nPossimus cupiditate repellendus voluptatibus provident quia neque quia. Dolore possimus quod asperiores doloribus nobis ea. Sint sequi placeat repellat est consequatur aut cumque ut.\n\nQuisquam necessitatibus itaque ut iste asperiores. Quo vel reiciendis in qui rerum qui. Fugiat omnis et a saepe. Esse et quia. Corporis aperiam exercitationem repudiandae eligendi ea.", null, null, "Example Page 1 - Paragraph 5", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") },
                    { new Guid("8da1b2e2-cd79-4a78-9703-7c38edc776f6"), "Saepe at et reprehenderit fugit in sunt error. Quos voluptatem facilis aut. Molestiae aspernatur aut eos distinctio et a. Voluptatem in quis qui enim totam dolor necessitatibus. Culpa voluptatibus nihil quam fugiat. Odio numquam reiciendis omnis sint dicta eius omnis.\n\nAut consequuntur porro cumque libero labore fugiat architecto et. Numquam consequatur ab dolores fugiat explicabo consequatur molestiae. Harum sint et odit et corrupti nostrum qui quam. Ut suscipit sunt placeat. Et modi ut dolor ad distinctio sapiente qui aut.\n\nEt doloribus aliquid consectetur. Est aliquid eius mollitia nam quos dolor laborum. Amet eum laudantium consequatur adipisci eius temporibus neque. Quos sint suscipit. Rerum deserunt ipsam.\n\nNesciunt et rerum alias. Non iste cupiditate quis veritatis ea. Quos et et laboriosam asperiores qui.\n\nMolestiae dolorem qui rerum non amet velit ducimus. Neque laudantium est eaque. Delectus minus a asperiores. Recusandae qui sed nesciunt ea. Rem iste nulla neque sint aliquam. Cum excepturi ipsa ea voluptas omnis similique et aut.\n\nVel aut nesciunt neque eum. Accusamus deleniti iusto sint animi aut quia. Unde iusto explicabo assumenda omnis dolorum est omnis iste. Commodi impedit qui rerum aut et blanditiis.\n\nVoluptatem esse omnis nemo sint blanditiis tempora odio eum perferendis. Laborum explicabo quia iste ipsa ea eaque. Ab est quos fugit mollitia. Est provident blanditiis et omnis dolores repudiandae consequatur nulla.\n\nIncidunt eligendi voluptas. Corporis ut veniam velit qui iusto amet fuga fugit sint. Et a perferendis a. Omnis ratione est nostrum neque necessitatibus. Nulla velit dolore et minus.\n\nVoluptate distinctio qui tempore qui voluptatem velit voluptas consequatur dolores. Enim blanditiis id voluptas sint ea quaerat. Alias et officia ad similique. Eaque laborum quis nihil. Sint voluptas nihil voluptate atque atque ut vero.\n\nEx saepe ipsum eius quasi ad atque ut eos. Ducimus quia doloribus modi libero soluta. Quis et omnis ullam. Error dolor numquam qui corporis veniam. Tenetur consequatur aliquid sint quo. Est numquam quae et delectus sunt velit delectus sapiente.", null, null, "Example Page 1 - Paragraph 4", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") },
                    { new Guid("9bc061bd-ec97-4ef6-9363-d64d4644aa22"), "Dolores similique dolorem illo dolor doloribus quaerat voluptatem. Consequatur perspiciatis distinctio. Provident suscipit consectetur quos error eum delectus ea tempora aut. Qui rerum nam maxime quia tempore officia vero.\n\nOfficiis maxime enim sed quisquam. Est consequatur non in commodi et. Rerum et iste maiores nobis fugiat. Nulla reprehenderit atque maiores rerum laborum rem. Eaque sunt laboriosam. Qui beatae et.\n\nLibero doloremque fugiat dolor a occaecati id dolore eum. Quidem dolore nemo aspernatur. Et maxime exercitationem culpa numquam sunt vel quis ab.\n\nSapiente perferendis dicta. Quis fugiat quis sed quam repudiandae ratione eius vel occaecati. Officiis blanditiis esse ullam. Corporis nesciunt ut autem veritatis sit alias natus quia. Perferendis doloribus non ut et laudantium placeat explicabo.\n\nMinus iusto omnis inventore non eligendi enim illo amet est. Recusandae ratione nihil eveniet ipsam. Non nihil nam in nihil eligendi et. Voluptatem delectus laborum porro veniam non veniam. Voluptatem similique autem minus praesentium qui in possimus.\n\nQui ducimus accusamus. Reiciendis at in nulla odit. Quam aut fugiat qui soluta voluptatem cumque. Eveniet temporibus rem placeat omnis. Est ducimus et optio sit.\n\nFugit voluptatem at beatae incidunt soluta repellendus. Est maxime voluptatibus sit autem blanditiis nesciunt. Distinctio aliquid iure blanditiis fugiat accusantium est. Rem voluptas beatae perspiciatis commodi sint.\n\nAb sint voluptas possimus omnis aut in repellendus cumque. Ullam veritatis qui. Sunt aut tenetur soluta quam aperiam qui officia dolores. Aut illum id. Cum ducimus voluptatum quia vel. Et tempore blanditiis nulla harum.\n\nAssumenda et consequatur et molestiae autem doloremque tenetur. Voluptatem est rerum est magni. Laboriosam aut dolorem. Iusto temporibus asperiores facilis perspiciatis voluptatem odit. Rerum dolores repellat iusto assumenda ut voluptas. Et ea impedit voluptas.", null, null, "Example Page 2 - Paragraph 6", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("c05dd94d-1cad-43b1-8b03-9a3a056fc447"), "Optio placeat aut occaecati accusantium qui in qui reiciendis. Minima dolorem asperiores laborum fugiat nisi. Aut pariatur perspiciatis nemo rerum odio et est est. Ut officia sapiente dignissimos dolores harum aliquam fugit aut.\n\nVoluptatem corrupti ut est ut. Qui nam labore. Et esse sunt aut ipsum consequuntur similique. Similique modi sunt soluta quaerat eum eligendi. Suscipit aliquid officia. Corrupti rerum esse.\n\nQuibusdam laborum dolorum et eos. Quis officia perspiciatis doloremque atque. Asperiores veniam dignissimos asperiores assumenda quae ea quasi. Blanditiis at ut.\n\nCorrupti culpa expedita qui in sit consectetur voluptatem possimus. Voluptas ipsa nihil ea quia laudantium dolor debitis voluptatibus a. Inventore quidem ipsa nostrum corporis. Pariatur culpa ducimus est quo amet et nobis numquam. Nulla exercitationem rerum eveniet laborum eveniet magni fuga consequatur. Quia voluptatum rerum et nesciunt labore.\n\nMaiores quia quo quos minima ipsum sed unde. Impedit et deleniti consequatur qui ducimus vitae fugit incidunt soluta. Reiciendis et laboriosam ut.\n\nAliquam vel tempore quas optio et. Consequatur quibusdam et doloremque in. Incidunt expedita accusantium. Ut quo eveniet vel. Nostrum voluptatem qui dolores.\n\nOccaecati explicabo repellat suscipit ut corporis fuga accusamus sed at. Recusandae quibusdam et cum at. Ab minus aperiam laudantium dolore neque molestiae. Cum maxime dolor quia. Veritatis necessitatibus consequatur ad incidunt dolorum ea.\n\nEt exercitationem architecto maiores recusandae accusantium autem ut hic excepturi. Deleniti in laboriosam cupiditate facilis dicta deleniti recusandae. Fugit quam illum minima aut. Non voluptas soluta consectetur delectus dolorum optio molestias.", null, null, "Example Page 2 - Paragraph 4", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("cdcf1209-82ea-4b9e-9978-56286a13e065"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("1d259f29-e251-483f-a6f5-c703a9fdbaaa") },
                    { new Guid("ced76387-c570-4344-8a20-7f01d6cc9292"), "Quo deleniti ducimus excepturi officiis. Et atque velit ea repudiandae sunt culpa sit. Et doloremque asperiores.\n\nNihil cupiditate voluptatem iste fuga quis a libero deserunt. Nemo soluta autem. Est provident dolorem quia dolores consequatur vel. Assumenda veniam illum velit voluptas. Deserunt sed dolorum sint suscipit sunt unde repellendus aut. Illo consequatur quaerat laborum atque maxime.\n\nDolor atque voluptatem. Vitae voluptatibus et sit in est doloribus et earum omnis. Corporis consequuntur molestiae tempore.\n\nVoluptas commodi sunt tempora. Ipsa alias ad quae exercitationem velit. Culpa nobis delectus.\n\nAliquam odio optio consectetur qui ea enim ut. Sequi velit assumenda aut. Optio magnam architecto dolor blanditiis.\n\nVoluptatibus velit beatae nostrum ut corrupti voluptates adipisci in commodi. Qui nesciunt sint. Et est sit provident odit omnis. Omnis autem ipsam non illo expedita dolor eos ipsa. Corrupti impedit dolor tenetur unde eaque natus placeat occaecati ratione.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("d42ab779-d63c-40f9-b354-3ffe84bb6519"), "Natus quam maxime. Dolore ipsa voluptatem omnis commodi. Cum non fugit aut debitis delectus veniam. Voluptatem iure omnis explicabo ut. Rerum qui ut nostrum molestiae.\n\nLaudantium enim ducimus repellat aut. Consectetur nihil a quia et aspernatur quos quo ex. Ratione quos excepturi ut possimus facere.\n\nSint ipsum possimus. Maiores sequi qui tempora totam. Ab voluptas perspiciatis. Facilis voluptas ipsam quis ex natus beatae corrupti necessitatibus voluptatem.\n\nUllam non nemo et eaque dolor commodi est. Culpa aliquid minus molestiae et nam id iusto a ea. Quia nulla voluptatem.\n\nUt eaque quasi sed laborum qui. Perferendis pariatur consectetur sint maiores. Ratione ut fugiat quisquam enim ratione atque dolorem similique. Eos quod asperiores pariatur. Explicabo ipsam ut sed.\n\nQuo quidem iste dolor aut vel. Voluptatem repellendus distinctio non. Nemo aut dolorum consectetur incidunt laborum et voluptas minus et.\n\nEnim odio numquam. Nobis ipsum quia in cum sapiente iusto harum laboriosam. Suscipit autem quos quidem voluptates suscipit.", null, null, "Example Page 2 - Paragraph 3", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("de082c84-e039-4f66-84c5-7b4503e96287"), "Dolores eius sint ea quo modi veniam magnam. Libero blanditiis aliquid doloremque aut quis temporibus qui. Eligendi qui eos vel quo. Ratione quo non quis voluptatem sit ipsa veritatis consectetur ducimus.\n\nAliquam ipsam quae qui consequatur harum et perferendis dolorem nostrum. Ex incidunt consequatur nihil nihil. Amet ut adipisci magnam atque incidunt placeat minima quisquam.\n\nExcepturi et ducimus. Hic commodi ut est reprehenderit aut perspiciatis quo. Excepturi incidunt et laudantium laudantium sit consectetur nesciunt.\n\nEst sit reprehenderit aliquam ipsa alias. Voluptatem iusto consequatur fugiat quod est eius et dicta. Aliquid numquam ea. Maiores sed amet aperiam quidem qui magnam facilis facilis. Quia hic beatae est qui. Quis aut placeat.\n\nVel id necessitatibus qui sapiente est quisquam autem quibusdam consequatur. Distinctio tempora quo molestias qui quia fuga cupiditate sint. Aut est repellat tempora ut consequatur veritatis qui optio. Et molestiae nostrum aut. Laudantium et dolorum ea error sed.\n\nRem dolor officiis. Nesciunt excepturi vel provident harum dignissimos qui consectetur. Eos aut nobis alias aut eos deserunt. Vero qui alias. Ut officiis dolores enim quia mollitia et nulla odio ea.\n\nQuia qui dolorem tenetur asperiores est ut hic deserunt. Atque qui consequatur modi. Minima molestiae similique veniam. Et et magni quas temporibus enim. Id perspiciatis quod porro voluptatem est officia ipsam eligendi. Voluptate exercitationem ut amet sint.", null, null, "Example Page 2 - Paragraph 5", new Guid("0063dabf-29d8-4bf9-a24a-84557e5d7f36") },
                    { new Guid("f625f070-8702-4f84-bffd-54cd94abcb4a"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("1d259f29-e251-483f-a6f5-c703a9fdbaaa") },
                    { new Guid("f7d77d73-6df6-4316-9583-42d06d28d644"), "Vel amet a quaerat. Ut sequi doloribus sit cumque repellat dolores. Sit odio perspiciatis perferendis quia corporis aut occaecati. Est ipsa aspernatur. Perferendis aspernatur quisquam consequatur aut in laudantium voluptatem cupiditate dolores. Doloribus cupiditate sed est illum cum dolores dolores praesentium aliquam.\n\nLaboriosam nam eos voluptatem ut dicta voluptas officiis. Distinctio hic temporibus labore iure veritatis voluptas alias. Quaerat necessitatibus culpa ipsam consequatur sit. Esse sed unde quo modi eum ut magni. Voluptas aspernatur odio sunt ullam et sit id a. Sit ut nihil dolorem voluptate accusamus.\n\nSapiente optio esse magnam aut. Optio doloribus unde magni voluptatum nihil voluptatum sit. Ab rerum ad voluptatem iste qui adipisci dignissimos et sequi. Alias quo sed vero ex illum. Nobis sed accusamus ipsam perspiciatis odit et sit. Molestiae qui alias deleniti deleniti.", null, null, "Example Page 1 - Paragraph 6", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") },
                    { new Guid("f9067fc3-0cc0-418d-a4f8-b6c959c7eeea"), "Perspiciatis consectetur quia dolorum rerum. Eveniet maiores a id minus ut. Autem numquam ut tenetur doloremque ipsum doloribus cum a.\n\nMaiores cum debitis quibusdam repellat doloremque non labore et. Ut autem voluptates quod sit quia reprehenderit et reprehenderit. Natus non et deserunt numquam explicabo. Odio iste qui minima amet.\n\nQui culpa recusandae illum earum. Non mollitia non impedit. Ut assumenda ut deleniti ipsum cupiditate vitae sed.\n\nDolores quia quia necessitatibus. Iste sunt et quam sint sunt. Ipsum est veniam. Rerum id sunt ut rem.\n\nEa nulla sunt omnis officiis quia consequatur vero. Hic rerum quia cumque in rem reiciendis nisi est. Ut natus nemo non quis velit. Nulla sint possimus quasi placeat nostrum iusto molestiae. Optio consequatur error a neque blanditiis. Ut doloremque quo nihil vel ducimus.\n\nOfficiis et sit vero vero ut et corporis. Minus illum nobis commodi sint et velit aut. Aspernatur quidem sequi eos sed accusamus vel eum voluptates assumenda. Et et qui ipsa. Odit placeat sequi et ullam omnis nihil et deleniti doloremque.\n\nSuscipit quia laborum natus repudiandae corporis. Veniam accusamus qui voluptas consequatur debitis pariatur ipsam molestiae labore. Consequatur consequatur minima ad sint consequuntur ad. Necessitatibus est totam voluptatem hic. Earum nihil suscipit non impedit.", null, null, "Example Page 1 - Paragraph 2", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("aeef9d1d-4e88-4dc0-bd7d-afda32b5397e"), false, new Guid("bc66a05e-b39b-4755-8e93-fcf03cba27e7"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 8, 18, 29, 5, 444, DateTimeKind.Local).AddTicks(8733), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("71c11506-82ab-490b-8c04-35ca897bfb2e") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("25be95dd-0bc5-4aa1-ac93-d08bfdd19af9"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("aeef9d1d-4e88-4dc0-bd7d-afda32b5397e") },
                    { new Guid("2724b2f8-75b9-414d-a89b-c92047004eff"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("aeef9d1d-4e88-4dc0-bd7d-afda32b5397e") }
                });
        }
    }
}
