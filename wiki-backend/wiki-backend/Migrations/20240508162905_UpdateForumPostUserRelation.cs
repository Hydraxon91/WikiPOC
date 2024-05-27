using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumPostUserRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35f160bd-9c2f-4924-995c-d3ef73593f62"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51313f89-58a9-4c9d-a3d7-5f1ee3e7a99c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("564f4c8f-c23c-4a4c-ba08-d0166a699e4e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7827f272-b8f2-44af-a150-f3611e7cf814"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("81bba3ec-aacf-4c17-9006-eff82c663d9f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ce57152-a445-447b-96c7-a3e7f6c8aedc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9da17538-58e6-4bb6-9af0-9e0315baea9a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec04b8c3-e40a-4528-8b0a-028f18c21b92"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("02962fda-1d83-41bf-aba5-febb5e28f8a7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0f4db41f-764b-49c2-ad9a-2054b96f7c60"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0fcd87c6-b326-43ba-96c7-01a1d3d0e15a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3b8a8a5e-f53d-4c6c-99b3-f06689a15fdc"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4c93abef-8eaa-4b12-b4c3-fb260899704e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("51e9494c-e7b9-4c86-881c-db77621d50df"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("66f93a86-8636-4091-8d7f-93a98d106f14"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6bee70e7-cf6b-454c-b2b7-20511239bc21"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6f227c3b-b54d-4308-b22d-de77159288cd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("896e76c3-3964-4cb2-b015-e78582ba59e5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8d5a027a-8818-4f9e-9c74-e00165b90d9b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("91b325ab-49c8-453d-be8d-7252b52c4eb1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9faacf2b-985c-4cbd-a74b-04e5b82f5ccf"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a9498e1e-ec16-4568-877f-7229fb3ac421"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("af2757d4-8651-47c0-bde3-7fef72108121"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("df2839d7-c3ea-44d2-b5c7-03a0efd3f467"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("a5cde3cf-0331-4ed1-acad-3f8e2f140293"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("f07526b1-6e3d-42cc-b593-03f3ad6ad274"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a89fa6a3-6700-49dc-9858-4f5ee357d1db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be050c02-db2c-470c-951a-cacf32ca40d0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6ce9e2e-7ec9-4488-877e-b618a5be7adb"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("651283f9-fdd0-4355-9f22-b952459f53db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7a692973-188a-464b-a5cf-428abcde9487"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ForumPosts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

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

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_UserId",
                table: "ForumPosts",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_UserId",
                table: "ForumPosts");

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

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ForumPosts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("35f160bd-9c2f-4924-995c-d3ef73593f62"), "Organizations" },
                    { new Guid("51313f89-58a9-4c9d-a3d7-5f1ee3e7a99c"), "Food and Drink" },
                    { new Guid("564f4c8f-c23c-4a4c-ba08-d0166a699e4e"), "Science and Technology" },
                    { new Guid("7827f272-b8f2-44af-a150-f3611e7cf814"), "History and Culture" },
                    { new Guid("7a692973-188a-464b-a5cf-428abcde9487"), "Characters" },
                    { new Guid("81bba3ec-aacf-4c17-9006-eff82c663d9f"), "Concepts" },
                    { new Guid("8ce57152-a445-447b-96c7-a3e7f6c8aedc"), "Arts and Entertainment" },
                    { new Guid("9da17538-58e6-4bb6-9af0-9e0315baea9a"), "Sports and Recreation" },
                    { new Guid("a89fa6a3-6700-49dc-9858-4f5ee357d1db"), "Locations" },
                    { new Guid("be050c02-db2c-470c-951a-cacf32ca40d0"), "Events" },
                    { new Guid("c6ce9e2e-7ec9-4488-877e-b618a5be7adb"), "Stories" },
                    { new Guid("ec04b8c3-e40a-4528-8b0a-028f18c21b92"), "Technologies" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a"), new Guid("c6ce9e2e-7ec9-4488-877e-b618a5be7adb"), null, "WikiPage", null, true, new DateTime(2024, 5, 7, 18, 28, 34, 76, DateTimeKind.Local).AddTicks(1563), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("651283f9-fdd0-4355-9f22-b952459f53db"), new Guid("7a692973-188a-464b-a5cf-428abcde9487"), null, "WikiPage", null, true, new DateTime(2024, 5, 7, 18, 28, 34, 76, DateTimeKind.Local).AddTicks(1519), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("f07526b1-6e3d-42cc-b593-03f3ad6ad274"), false, new Guid("a89fa6a3-6700-49dc-9858-4f5ee357d1db"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 7, 18, 28, 34, 76, DateTimeKind.Local).AddTicks(1758), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("02962fda-1d83-41bf-aba5-febb5e28f8a7"), "Nostrum et consequatur facilis facilis quae quis. Deleniti et vitae inventore iure magni ea eius id. Eum ipsum et veniam eius nihil ut adipisci. Quia ipsam ut optio eaque deserunt.\n\nReprehenderit magni repellendus. Aliquid est dolore vitae rerum. Est ut et error qui quibusdam ut quia. Eveniet a sunt et ex officia in. Sequi consequatur harum ratione earum est ab dolor nihil eaque.\n\nEt adipisci quos. Dolorem quod consectetur voluptas placeat dolorum delectus culpa. Incidunt dolores autem. Nulla dicta velit repellendus possimus soluta atque labore.", null, null, "Example Page 1 - Paragraph 6", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("0f4db41f-764b-49c2-ad9a-2054b96f7c60"), "Quis reiciendis rem sint et cupiditate voluptatem nobis et qui. Accusamus exercitationem totam aut nihil error numquam. Fuga omnis aut officia ut. Voluptates sit non architecto nesciunt. Voluptatum vel qui ducimus in.\n\nEos debitis ad quos nam blanditiis voluptatem velit non reiciendis. Et facilis ut perferendis corrupti. Et quod ut. Earum minus suscipit distinctio qui accusantium. Possimus eum cumque eaque.\n\nEum sunt exercitationem ea. Est aut culpa mollitia vel velit asperiores vel eaque. Rerum nulla ipsam amet molestiae aut culpa dolor ut voluptatum. In atque qui nostrum eveniet occaecati.\n\nBeatae ipsum et repellendus veniam eligendi. Iste alias corrupti cum voluptatem consequuntur nihil. Expedita nam sunt ut non officia aperiam. Sit culpa velit maxime velit animi repudiandae aut explicabo et.\n\nAut porro officiis quaerat et commodi. Ipsam rerum ipsum. Error dolores occaecati corporis est perferendis aut magnam in optio. Id autem sint. Qui dolores ut non et.\n\nReprehenderit earum dolorem vel exercitationem aut culpa corrupti expedita. Laudantium iste totam odit corporis assumenda cum et. Quo ut praesentium omnis et autem veritatis dolorem velit est. Quisquam sit possimus quam dolor.\n\nQuis officiis fugiat culpa eveniet ratione dolores. Eum qui est autem. Amet et minus voluptatem sed facilis illum necessitatibus. Eum esse quod qui.\n\nA velit facere. Repellat atque repellendus nihil consequatur sed amet. Dolores ullam tempore possimus est et. Tempora vel consequuntur suscipit eius omnis suscipit. Necessitatibus ut nihil nam suscipit pariatur consequatur et qui.", null, null, "Example Page 1 - Paragraph 5", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("0fcd87c6-b326-43ba-96c7-01a1d3d0e15a"), "Et facere id sunt modi dolorem fugiat eos quia. Deserunt harum quibusdam inventore accusantium molestias. Aperiam laboriosam eveniet et consequatur perferendis adipisci. Architecto natus animi et rem sed. Est sapiente eveniet consequatur sit dolor officiis. Modi repudiandae id ut soluta velit animi.\n\nRatione molestiae numquam consequatur officia explicabo. Commodi dolores ut voluptas est non illum. Maxime suscipit quo.\n\nLaborum distinctio qui est. Odio aut itaque. Ratione delectus cumque ea asperiores qui rerum reprehenderit. Aut ullam ut. Et ad aspernatur doloremque omnis sed repellat voluptatum ipsa eum.\n\nMagni amet atque ullam ut. Pariatur illum amet reiciendis cumque sapiente. Similique aliquam saepe labore nobis.\n\nIusto odit aperiam rerum voluptate. Ea atque non. Rerum sequi consectetur possimus deleniti.", null, null, "Example Page 2 - Paragraph 5", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") },
                    { new Guid("3b8a8a5e-f53d-4c6c-99b3-f06689a15fdc"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("f07526b1-6e3d-42cc-b593-03f3ad6ad274") },
                    { new Guid("4c93abef-8eaa-4b12-b4c3-fb260899704e"), "Ut ipsam mollitia eos ratione. Iusto et quidem accusamus autem. Officia veniam molestiae placeat blanditiis qui eos eius est nostrum.\n\nUt non nemo. Beatae facere natus qui qui qui quisquam ut corrupti. Eos impedit velit non quos ut saepe ut eum. Repudiandae quod aut harum tempore dolorem soluta beatae deleniti accusantium. Et minus aliquam a molestias. Odit harum quae alias quae ipsam quia nesciunt.\n\nEt deserunt quae. Itaque ex et ut vitae distinctio sed alias autem. Delectus sapiente qui quam vero. Ut placeat occaecati possimus numquam et qui libero blanditiis accusamus.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("66f93a86-8636-4091-8d7f-93a98d106f14"), "Consequatur dolores voluptas perspiciatis ducimus incidunt explicabo doloribus neque rerum. Animi iste consequatur fugit magnam esse eius blanditiis eveniet. Est error natus ipsam eius qui mollitia.\n\nExercitationem autem nostrum. Qui adipisci labore deserunt assumenda et laudantium non quisquam quisquam. Tempora et assumenda ea velit minima aperiam error earum. Corrupti qui quam explicabo ullam quas debitis quae fugiat.\n\nCupiditate vel temporibus vel delectus praesentium sed fugit. Delectus quod qui distinctio architecto similique quod quidem labore ut. Veniam aperiam recusandae et corporis. Et eius ut nobis quia accusantium dolorem suscipit distinctio eum. Praesentium voluptas qui ut.\n\nLaboriosam ut et ullam accusantium nemo deserunt. Tenetur nesciunt maiores voluptatem autem neque natus et nisi dolore. Aut autem rerum dolor qui provident et. Cumque hic quas eveniet molestiae corporis explicabo quae dolor dolor.\n\nAd ullam cumque sed et rem ut quasi enim. Ipsa quae quia ea officia. Suscipit vero quia. Aut beatae qui saepe ea ut ut eveniet. Omnis dicta explicabo quia voluptate ipsa iure dolor quasi earum. Officiis voluptas eum fugiat ratione.\n\nSapiente ut qui voluptatibus quae magnam molestias omnis. Non corrupti possimus aspernatur esse officia aut. Consequatur magni voluptatem consequuntur.\n\nPraesentium qui velit labore voluptas qui. Vero unde molestiae dolor non sed pariatur est. Numquam consequatur hic tempora eaque voluptatum quo.\n\nNesciunt eos reiciendis fugiat neque omnis sint quibusdam officia similique. Et velit vitae soluta voluptas nihil earum et dolorem voluptatem. Fugiat odio vero. Nesciunt dignissimos non vel officiis. Dolores sequi et excepturi non commodi. Magnam est vel aspernatur.", null, null, "Example Page 1 - Paragraph 3", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("6bee70e7-cf6b-454c-b2b7-20511239bc21"), "Accusamus similique esse dignissimos dolorem consectetur quasi magni ut. Eum ex voluptates molestiae dolore. Maxime vitae adipisci. Vitae numquam minus est exercitationem fuga alias nihil debitis. Ut hic quia tempore et molestias. Est accusamus voluptatum.\n\nAspernatur libero iusto libero distinctio rem. Debitis labore fugiat laboriosam non cupiditate sit ratione eos rerum. Omnis et sed quo quo sed voluptate nam esse architecto. Dolorem recusandae qui error ullam aut sed. Ratione placeat ratione ut enim minus ad officiis ut in. Quaerat inventore aut molestiae in voluptates.\n\nNulla suscipit blanditiis voluptas repellat consectetur. Voluptatem distinctio dolore amet excepturi mollitia nobis commodi. Et vel facilis et aut sit perspiciatis eligendi itaque consequatur. Ea fugit impedit culpa et.\n\nRepellat soluta molestias et ab. Odio non est illum eveniet ullam molestias nihil cum. Veniam quia voluptatibus exercitationem eum autem ut. Consequatur consectetur nostrum modi est necessitatibus laboriosam quisquam.\n\nQuibusdam non fugit aliquid rerum est voluptate. Adipisci laboriosam delectus ratione enim sed veritatis esse. Deserunt corporis odio et molestiae et. Cumque voluptatem rerum laudantium et vero deleniti adipisci consectetur.\n\nRatione consequatur autem vero magnam necessitatibus consequatur saepe explicabo. Dolor ut exercitationem ipsa eaque et qui facilis. Numquam eos odio. Dicta provident non explicabo cumque quo quam nesciunt. Quas et quam.\n\nReprehenderit a ea perspiciatis explicabo. Quis dolorum minima. Quam veniam expedita quia et. Quidem earum itaque aliquam.", null, null, "Example Page 1 - Paragraph 4", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("6f227c3b-b54d-4308-b22d-de77159288cd"), "Qui consequatur et voluptatum. Eum sint maiores qui ad ratione. Nobis dolorem veniam dolores praesentium. Accusantium dolorem eum.\n\nDolor ut natus fugiat vero. Blanditiis numquam et atque libero reprehenderit libero accusamus. Expedita quis iusto molestias. Veniam consequatur id velit hic atque. Minus alias optio atque autem itaque cumque sequi officiis quis. Quia eligendi rem.", null, null, "Example Page 2 - Paragraph 2", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") },
                    { new Guid("896e76c3-3964-4cb2-b015-e78582ba59e5"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("f07526b1-6e3d-42cc-b593-03f3ad6ad274") },
                    { new Guid("91b325ab-49c8-453d-be8d-7252b52c4eb1"), "Doloremque aut perspiciatis vel et ut qui. Et recusandae qui labore facere quo voluptatem delectus ab minus. Et sed sed hic voluptates accusantium qui soluta. Sit numquam est. Amet consequatur nihil sunt magni sapiente tempore vitae voluptatibus. Labore quas ab.\n\nProvident non doloribus soluta praesentium ea ex et praesentium in. Impedit officiis qui debitis neque fugiat earum eligendi nisi omnis. Ut quam quaerat maiores fugiat corporis commodi at et. Et voluptate deserunt ut. Voluptas qui debitis vitae sint rerum. Molestias blanditiis in corporis provident ducimus consectetur et perferendis molestiae.\n\nArchitecto dolores maxime voluptates et. Non similique sunt. Rerum et officia deserunt porro illo.\n\nSuscipit commodi dignissimos fugit a corrupti quo asperiores. Qui magnam rerum. Exercitationem ab iure qui sunt.\n\nOdio adipisci deleniti est consequuntur dolores eius quibusdam. Temporibus velit ipsa placeat nesciunt saepe quam aspernatur ut. Ut excepturi ut. Qui dolor nam quidem magni corrupti aliquid ut quia. Sed nulla ut laudantium quod facilis nulla voluptatem ipsam aliquam.\n\nOmnis perferendis aliquam blanditiis dolor repudiandae nihil consequatur iure a. Aperiam et vel ut nostrum eveniet nam ea est. Autem sunt praesentium. Porro sunt commodi eveniet itaque minus aliquam.\n\nConsequatur architecto repellendus autem mollitia est nobis sint facere. Amet aut et. Temporibus iusto nobis. Quasi ut sunt.\n\nConsequuntur expedita nihil consequatur. Rerum aut ut est aperiam provident aliquam tenetur. Iusto quos voluptatem error consectetur dolor omnis.\n\nRepellendus vitae saepe esse omnis. Neque tenetur vel molestiae nobis magnam totam. Sunt occaecati nihil eius. Pariatur nemo tempore recusandae maiores odit quo non veritatis. Nam illum consectetur.\n\nQuod porro non. Qui vel voluptatibus expedita qui et. Provident quae quaerat aut aut excepturi. Et veritatis reprehenderit blanditiis. Quisquam impedit quidem doloremque ea eius. Cupiditate eum voluptatum ea quis illo vero nemo doloribus iste.", null, null, "Example Page 1 - Paragraph 2", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") },
                    { new Guid("9faacf2b-985c-4cbd-a74b-04e5b82f5ccf"), "Id aperiam sed eum. Sequi doloremque enim quia unde nihil amet ut. Minus accusamus et dolorem dicta suscipit a. Iste consequuntur ducimus aperiam aut quidem nostrum.\n\nQuia tempore ad. Quo sed aspernatur debitis corrupti. Eligendi itaque ut quas. Vitae cum et est provident neque sunt officia quis iusto. Vel dolores facilis quis consequuntur.\n\nMolestias atque omnis repellendus quas. Quae dolorum aut ducimus reiciendis ab sapiente adipisci nesciunt. Incidunt vero vel nesciunt eligendi voluptas ullam.\n\nVero eveniet inventore et voluptatum. Ipsa dolorem qui ea qui fugit corporis repellat tempora beatae. Saepe tempore ea iusto quibusdam minus. Iste quis autem. Ratione quia repudiandae molestiae quia repudiandae nam quas aut dolor. Possimus repudiandae nisi debitis rerum quidem nobis.\n\nUt et et nemo similique. Aspernatur soluta numquam ipsam tenetur aliquam ea autem. Earum animi aliquid mollitia nam. Facere expedita nesciunt eligendi mollitia voluptatem deserunt aliquam repellat est.", null, null, "Example Page 2 - Paragraph 6", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") },
                    { new Guid("a9498e1e-ec16-4568-877f-7229fb3ac421"), "Necessitatibus fuga ipsa sint esse. Sit ut odio est. Unde fugit enim et qui dolor officia sapiente fuga illum. Perspiciatis vel voluptas doloremque accusantium quam. Qui est consequatur hic. Enim quod consequatur illum cum sed nobis possimus architecto.\n\nDeserunt aut id est totam quam qui est. Quidem porro animi. Id ut sequi aut amet eos voluptas eos. Quo veritatis temporibus nobis. Ipsa consequatur aliquid alias.\n\nQui voluptatem corrupti sed ipsa vel repellat laborum corporis. Itaque commodi et consequatur. Commodi repudiandae minima ut voluptatem dolorem eaque vitae quo.\n\nSint sed molestiae quo similique odit praesentium quia est. Est sit adipisci debitis placeat veniam. Esse qui molestias ea hic et et. Ipsa ducimus atque quidem.\n\nTemporibus sint aut commodi quo sit occaecati. Autem exercitationem voluptas aliquam dolorem. Eum dolores itaque doloremque sit. Mollitia itaque sunt voluptas. Nihil voluptas ratione unde aperiam commodi sint. Atque aut quia maiores.", null, null, "Example Page 2 - Paragraph 3", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") },
                    { new Guid("af2757d4-8651-47c0-bde3-7fef72108121"), "Sed nam quia molestiae dolor et quibusdam odit qui praesentium. Molestiae sit doloremque non consectetur nihil exercitationem. Earum distinctio in et. Similique fugit quidem reprehenderit consectetur ad ut dolorem placeat et.\n\nEius veniam sequi omnis quis accusamus tenetur incidunt est est. Assumenda perferendis quibusdam voluptatem. Aspernatur aut sunt et labore hic vel saepe.\n\nIn et in nihil provident expedita ipsam. Similique consequatur delectus explicabo nostrum inventore ut et in. Laudantium suscipit distinctio nesciunt soluta. Ea tenetur quam similique nulla est.\n\nVoluptas quisquam ut veniam error nam ut alias totam qui. Asperiores enim quia quia provident aut voluptatem asperiores. Eius soluta sit omnis libero. Cum consequatur laborum voluptas cumque libero et. Fuga vel sed.\n\nOmnis quod odio adipisci. Et culpa sit accusamus vero corrupti voluptates. Velit consequatur enim perspiciatis reiciendis sed dicta esse minus sed. Laudantium et doloribus exercitationem dolorem unde ex animi. Ducimus est incidunt voluptatem reprehenderit aliquam quia impedit minima laudantium.\n\nNihil at ut voluptas deleniti. Quos vitae repellat vel. In blanditiis qui voluptas. Qui non qui. Amet delectus eos fugit odio qui qui fugit et.\n\nIpsum nihil dolor quisquam maxime et suscipit harum et est. Quam expedita eligendi quisquam tenetur aut officiis unde eum. Amet dolorem quidem.\n\nNihil velit deleniti nisi et culpa tempora. Dignissimos rerum est velit cupiditate voluptate. Officia sit perspiciatis at.\n\nMagnam corrupti aut quam omnis sed corporis. Ab deserunt rerum voluptas ut tenetur. Ipsam et veniam tempora maiores sunt sed vitae quam aperiam. Tempore quod et.", null, null, "Example Page 2 - Paragraph 4", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") },
                    { new Guid("df2839d7-c3ea-44d2-b5c7-03a0efd3f467"), "Aliquam reprehenderit earum deserunt exercitationem possimus recusandae. Dolore culpa nesciunt temporibus officiis. Tempora ut aliquam deserunt magnam et et aperiam reiciendis. Esse non veniam iusto eos nobis autem. Mollitia officia laboriosam ipsa expedita animi.\n\nNatus excepturi soluta. Sequi sapiente numquam non dolores. Sapiente quisquam est voluptas rerum fugit quidem. Porro ut voluptatem eaque. Iste laudantium eum ut doloribus blanditiis deleniti maiores voluptas adipisci. Ut amet amet et cumque.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("3e609f1f-2b3d-44e6-b9c2-b204718c5c8a") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("a5cde3cf-0331-4ed1-acad-3f8e2f140293"), false, new Guid("be050c02-db2c-470c-951a-cacf32ca40d0"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 7, 18, 28, 34, 76, DateTimeKind.Local).AddTicks(1763), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("651283f9-fdd0-4355-9f22-b952459f53db") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("51e9494c-e7b9-4c86-881c-db77621d50df"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("a5cde3cf-0331-4ed1-acad-3f8e2f140293") },
                    { new Guid("8d5a027a-8818-4f9e-9c74-e00165b90d9b"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("a5cde3cf-0331-4ed1-acad-3f8e2f140293") }
                });
        }
    }
}
