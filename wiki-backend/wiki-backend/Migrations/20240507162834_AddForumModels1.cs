using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddForumModels1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("19c4077a-e6bb-4489-a3a0-44ff0e5f4083"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("19ec408c-cb09-4ab4-84f4-4abff52c68e1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1b3669bf-2028-4b03-b47a-0bf7de5ae76e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("272b5711-b21b-48f9-a5e2-9f37f076e598"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3908eded-bc9d-4e9e-a5c5-8712042d36dc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a4be4270-7bfb-4c10-94a0-8d445d38665d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8243405-5fcd-4c20-8da2-1dadbfded3bd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d7a411b0-6b2f-4070-8f15-ae932718d358"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("08466df0-dc50-484a-8547-87bb499924db"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("08baf736-6b15-45e3-90d1-a7309ef05eba"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("22d34b68-edd9-466a-b5a6-317e16084781"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3f1e48ba-a931-4a4b-917e-a6b28a295f83"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("60ac5e69-34ed-436f-bbf5-e34d5f3a74bd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("70cfa0bd-2697-4529-ab78-3b32b30d5705"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a29307b9-6d25-409b-ad16-0c9f2c73d5b1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("bb470934-f6de-4140-bc35-2df9cb285f79"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c4bde50c-680e-40c5-8b7f-aa3279cb1500"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c614d0ce-77ff-4cad-b4e5-318c6badb9c4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cd8d24dc-854a-463e-9584-5acfb6676961"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ddbdaf30-1c10-4f0c-9d66-01298a86b02b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("df93b5b4-59fe-44a4-b612-e1345f1051b5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e0608fb0-9b25-4016-a758-15ca5630c420"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("edb16cbc-160a-4ee8-b296-362c8bd9570f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f902cebf-fea2-44b4-a91c-3349e4ff9e2c"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("02296446-cfc4-438b-9f19-91d7fbbd46f0"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("650a9022-7ad9-478a-b178-768ef017b36f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("00915953-6c7b-4a3c-b134-de4e4b606ea4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("112f76e0-9c50-4b53-b653-5896641151c7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a350914b-0878-4a3f-a881-a19987d02b8e"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("74f028aa-fbc0-4367-916c-0a3594f0fef2"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForumPostId",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ForumTopics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumTopics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ForumPosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForumTopicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumPosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                        column: x => x.ForumTopicId,
                        principalTable: "ForumTopics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ForumPostId",
                table: "UserComments",
                column: "ForumPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_ForumPosts_ForumPostId",
                table: "UserComments",
                column: "ForumPostId",
                principalTable: "ForumPosts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_ForumPosts_ForumPostId",
                table: "UserComments");

            migrationBuilder.DropTable(
                name: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumTopics");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_ForumPostId",
                table: "UserComments");

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

            migrationBuilder.DropColumn(
                name: "ForumPostId",
                table: "UserComments");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("00915953-6c7b-4a3c-b134-de4e4b606ea4"), "Stories" },
                    { new Guid("112f76e0-9c50-4b53-b653-5896641151c7"), "Events" },
                    { new Guid("19c4077a-e6bb-4489-a3a0-44ff0e5f4083"), "Food and Drink" },
                    { new Guid("19ec408c-cb09-4ab4-84f4-4abff52c68e1"), "Technologies" },
                    { new Guid("1b3669bf-2028-4b03-b47a-0bf7de5ae76e"), "Arts and Entertainment" },
                    { new Guid("272b5711-b21b-48f9-a5e2-9f37f076e598"), "Science and Technology" },
                    { new Guid("3908eded-bc9d-4e9e-a5c5-8712042d36dc"), "Concepts" },
                    { new Guid("74f028aa-fbc0-4367-916c-0a3594f0fef2"), "Characters" },
                    { new Guid("a350914b-0878-4a3f-a881-a19987d02b8e"), "Locations" },
                    { new Guid("a4be4270-7bfb-4c10-94a0-8d445d38665d"), "Organizations" },
                    { new Guid("b8243405-5fcd-4c20-8da2-1dadbfded3bd"), "Sports and Recreation" },
                    { new Guid("d7a411b0-6b2f-4070-8f15-ae932718d358"), "History and Culture" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("02296446-cfc4-438b-9f19-91d7fbbd46f0"), false, new Guid("a350914b-0878-4a3f-a881-a19987d02b8e"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 2, 19, 5, 14, 237, DateTimeKind.Local).AddTicks(1639), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032"), new Guid("74f028aa-fbc0-4367-916c-0a3594f0fef2"), null, "WikiPage", null, true, new DateTime(2024, 5, 2, 19, 5, 14, 237, DateTimeKind.Local).AddTicks(1461), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506"), new Guid("00915953-6c7b-4a3c-b134-de4e4b606ea4"), null, "WikiPage", null, true, new DateTime(2024, 5, 2, 19, 5, 14, 237, DateTimeKind.Local).AddTicks(1504), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("08466df0-dc50-484a-8547-87bb499924db"), "Pariatur esse repellat. Sed nulla alias ex saepe officia. Vitae quae eligendi ullam quisquam excepturi accusantium debitis. Ut voluptates delectus consequatur. Qui nostrum a animi adipisci. Harum est omnis nobis ad est quia eum sit laboriosam.\n\nEsse omnis sint libero deserunt sapiente. Expedita omnis et. Placeat sunt pariatur dicta et quibusdam dolore sapiente maxime. Explicabo iusto nihil similique tempore. Harum molestiae blanditiis.", null, null, "Example Page 2 - Paragraph 2", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("08baf736-6b15-45e3-90d1-a7309ef05eba"), "Voluptatibus sed asperiores enim ipsa voluptatem ipsam in recusandae perspiciatis. Id qui molestias ipsum voluptatem dolorem odio quia animi dolor. Assumenda officiis et eligendi cupiditate molestiae. Quo consequatur ut. Sit sed reprehenderit sed eaque est aliquid.\n\nConsequatur officiis debitis. Sit est corrupti voluptas sequi. Voluptas a modi. Dolores nulla enim deleniti provident a commodi eos. Non facilis ratione facere molestiae eum. Numquam molestias quisquam rerum magni voluptatem sed.\n\nQuam inventore consectetur porro excepturi voluptate corrupti dicta molestias animi. Nisi aliquid consequatur est. Doloribus odio nostrum amet dolores delectus rerum ea. Architecto saepe non minima velit suscipit itaque.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") },
                    { new Guid("22d34b68-edd9-466a-b5a6-317e16084781"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("02296446-cfc4-438b-9f19-91d7fbbd46f0") },
                    { new Guid("3f1e48ba-a931-4a4b-917e-a6b28a295f83"), "Illum aliquam necessitatibus dolor. Ex natus fugiat deserunt quaerat. Molestiae aut enim nostrum explicabo.", null, null, "Example Page 1 - Paragraph 2", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") },
                    { new Guid("60ac5e69-34ed-436f-bbf5-e34d5f3a74bd"), "Iste voluptas aperiam. Distinctio molestiae architecto dolorem vero explicabo. Suscipit sunt mollitia id in ratione.\n\nVoluptates voluptas vel atque ratione minima et maiores. Quo libero ea officiis vero nostrum sed est. Et possimus et commodi corporis quas quia. Distinctio dolor corporis et repellendus vel quia atque aut. Vitae et nam qui. Eaque tempora asperiores magnam vel enim officiis.\n\nFacere ut sunt. Ad voluptas est suscipit eos et tempore perferendis aut. Non commodi placeat expedita quam autem hic amet sed. Sit nobis iusto et aut consequuntur doloribus provident excepturi. Et et eum a corporis debitis ipsa assumenda excepturi non. Quae ab nihil autem perspiciatis nesciunt ad omnis provident.\n\nSaepe aut assumenda. Vel hic quam ut in quod. Dolor labore et quo provident ipsum iusto delectus natus.\n\nVoluptas deserunt tenetur dolor incidunt et quasi temporibus velit. Ratione voluptate vero vitae harum velit sed. Odit blanditiis et modi maxime est est ut. Possimus voluptatem et. Beatae ipsum assumenda accusamus non aut quisquam mollitia esse accusantium. Corrupti est nihil eveniet.\n\nHarum et eos est. Maiores ex asperiores id consequatur. Velit tenetur in et assumenda dolores eum cupiditate qui debitis. Expedita quisquam adipisci iste nam.\n\nOdit velit impedit accusamus. Nisi autem sint temporibus sit quo praesentium. Minima est sunt et consequuntur.\n\nNeque sed molestiae amet quia temporibus ea voluptatibus. Aut nesciunt quos eveniet numquam officia voluptatibus est laudantium. Quaerat rerum magni voluptas et aliquid asperiores. Fugiat aut sed dolorem nihil temporibus et est voluptas.", null, null, "Example Page 1 - Paragraph 6", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") },
                    { new Guid("a29307b9-6d25-409b-ad16-0c9f2c73d5b1"), "Aut recusandae sunt incidunt. Nobis a libero similique inventore. Dolor velit ratione libero molestiae et et. Eos et eos voluptatibus praesentium dolorem. Ducimus minima qui sapiente rerum est ut.\n\nTotam ut fugit quam iste minima ipsa. Ratione est neque voluptates magni mollitia nihil minus. Et velit quod repellendus illo ad qui.\n\nHarum odit libero. Aut quia quaerat id expedita quod dolorem quibusdam labore. Sint doloribus ipsam id ea id ducimus natus quod exercitationem. Minus dolores deserunt enim aut velit quis.\n\nNostrum vel dicta et dolor culpa repellat exercitationem. Quia ea ea delectus temporibus iste ipsum culpa voluptatem. Et enim aut consequuntur id molestiae non. Tempore magnam necessitatibus a earum maiores eum laborum. Aperiam quasi voluptatem architecto velit non quo quo vitae explicabo.\n\nDolor vel omnis. Delectus fuga blanditiis assumenda sit dolorum qui iusto. Veniam atque sint aut maxime maiores non temporibus sapiente sapiente.\n\nNecessitatibus asperiores est. Est rem beatae excepturi facilis laborum. Facilis aspernatur quia porro qui. Et quia omnis fuga totam rerum sit aut soluta.\n\nIpsam et eligendi repudiandae pariatur magni voluptates. Sint nulla error. Corporis voluptatem aut rerum.\n\nAb nisi quia dolorem laboriosam. Tempora consequuntur at voluptatem ullam dignissimos. Voluptatem quam et omnis vero suscipit accusamus. Voluptatem eligendi itaque et voluptatem iure dolorum.", null, null, "Example Page 2 - Paragraph 4", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("bb470934-f6de-4140-bc35-2df9cb285f79"), "Et sit corporis fugit soluta odit eaque. Iure ut aliquid impedit sit iusto inventore assumenda earum aspernatur. Accusantium porro illo ducimus. Quo ut quod perspiciatis illum eius eaque in.\n\nConsequatur inventore sunt voluptatem debitis saepe officia aut est. Omnis cupiditate molestiae qui reprehenderit aliquam. Deserunt corrupti distinctio rerum dolor consequatur.", null, null, "Example Page 2 - Paragraph 3", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("c4bde50c-680e-40c5-8b7f-aa3279cb1500"), "Qui suscipit sit. Molestias voluptas beatae. Sint et ad aut. Quisquam rerum exercitationem explicabo possimus unde qui minus architecto cumque. In quisquam sit quas consequatur laborum.\n\nDolores praesentium soluta et atque tenetur. Consectetur fuga perspiciatis ipsum hic illo. Sint exercitationem velit cupiditate ullam alias. Aut doloribus minima error debitis quod dicta molestiae.\n\nQui et eos. Itaque quidem sit provident eos aliquid. Aut repellat similique unde atque quam aliquid vel et nulla. Consequuntur enim et soluta.\n\nDoloribus hic qui quis delectus dolor assumenda. Officiis ut error ab quia omnis accusantium. Architecto fuga esse ipsam repellat reprehenderit.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("c614d0ce-77ff-4cad-b4e5-318c6badb9c4"), "Cum et libero cupiditate fuga nisi eveniet qui minus. Voluptates in velit odit voluptas sapiente at. Eos enim est deserunt.\n\nQuis quae natus enim qui vero recusandae iste. Occaecati dignissimos rerum ex expedita beatae earum occaecati. Ut saepe expedita hic ratione omnis assumenda iure laboriosam. Nihil quidem fugiat. Magnam quia voluptatum voluptate repudiandae perspiciatis ut.\n\nAliquam tenetur laborum nostrum at suscipit repellat est ipsa. Voluptatem nostrum voluptas repellendus quas nobis minima aliquam. Et et ullam optio qui. Quae beatae vitae odio et ab voluptas porro alias in.\n\nDucimus et ducimus iste expedita sint odio exercitationem blanditiis corporis. Quia adipisci sunt asperiores officiis est qui autem ipsum. Incidunt nulla molestiae.\n\nEt cum vel id. Dicta eum illo. Beatae eos praesentium et incidunt provident perspiciatis. A ut quod mollitia sit. Sint vel quibusdam.\n\nAut quos deleniti. Sequi rerum aut. Sint ducimus est vel est expedita. Voluptatem et aut voluptates aut tenetur quae.\n\nIste dolores eos est doloremque reiciendis quia. Laboriosam architecto in unde quia molestiae molestiae itaque rerum. Quod consequatur et.\n\nSed illo perspiciatis nam. Nemo rerum aliquam ea. Iusto in consequatur quia laboriosam aut voluptate.\n\nSint sed ullam laudantium sed minima maiores aut laboriosam. Nisi aut porro. Et blanditiis sed sed ut. Ad et aspernatur et consequatur vero cupiditate et et.", null, null, "Example Page 2 - Paragraph 5", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("cd8d24dc-854a-463e-9584-5acfb6676961"), "Suscipit perferendis repudiandae libero et. Fugit facere repudiandae cupiditate omnis suscipit fugit. Ut cumque aliquam. Laborum voluptatem in iure. Excepturi officiis et et commodi minus cumque voluptatem.\n\nDeleniti quisquam voluptas sit. Fugiat dolore culpa id. Exercitationem hic omnis rerum temporibus saepe enim. Eos voluptas cum rem voluptas est. Rerum at nisi voluptatem reprehenderit iste voluptates voluptate. Iste qui reprehenderit ut nam qui.\n\nOccaecati aut id odit voluptate et asperiores excepturi. Et quo illo quos ea omnis velit. Ut dolorem facere hic qui. Rem ipsa rerum et. Quo praesentium neque ipsa voluptatem quasi ducimus perspiciatis ullam veniam.\n\nEius voluptas pariatur ipsa sit amet numquam amet in. Et porro quia maiores sunt. Impedit aliquid repudiandae omnis rerum aut maxime et error. Illo qui molestiae fuga aut quis sunt. Voluptatem labore dicta.\n\nEum officiis quibusdam qui. Impedit adipisci repellendus. Qui aliquam praesentium deserunt sed quia quia. Et adipisci rerum ad quia quia.", null, null, "Example Page 2 - Paragraph 6", new Guid("3bef0ff7-8486-46a5-aac8-5c801b656506") },
                    { new Guid("ddbdaf30-1c10-4f0c-9d66-01298a86b02b"), "Enim placeat sunt sed labore sapiente. Pariatur qui sed quia voluptates quasi. Cum ab provident incidunt.\n\nLaudantium similique asperiores fugit possimus velit deserunt neque debitis. Earum aut ipsum. Blanditiis maiores et sit tempore similique libero sed repellendus laudantium. Vero harum amet non occaecati dicta.\n\nNon optio vitae non aliquid. Eos quia dolorem dolorem illo culpa dicta. Molestiae vero velit et facilis dolor facilis quo ut et. Asperiores laborum non in laboriosam doloribus officia odit quo. Eum omnis ipsa sint numquam et vero assumenda enim. Aliquid illo occaecati.\n\nVoluptas dignissimos accusamus non deleniti sed officiis quis dolorum. Voluptatem perferendis amet laudantium dolorem voluptatum aut sit rerum quas. Nihil suscipit aut. Incidunt qui molestiae occaecati.\n\nNon perspiciatis vel ut occaecati dolores quaerat. Nobis deleniti ipsam id consequatur sed nam. Explicabo id error ipsam. Neque sit optio beatae nulla qui molestias eligendi ut.\n\nDolores reiciendis tempora ad perspiciatis nemo ex. Fuga voluptas repellat. Debitis eum alias recusandae amet eos error nisi.", null, null, "Example Page 1 - Paragraph 5", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") },
                    { new Guid("df93b5b4-59fe-44a4-b612-e1345f1051b5"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("02296446-cfc4-438b-9f19-91d7fbbd46f0") },
                    { new Guid("e0608fb0-9b25-4016-a758-15ca5630c420"), "Voluptas sint qui est reiciendis maxime. Tempore soluta quibusdam odit earum molestiae cumque modi. Omnis provident quia et vitae sit. Assumenda eligendi placeat officia et dolores. Laboriosam qui voluptatem debitis sunt quasi sunt quis.\n\nVoluptate perferendis culpa excepturi voluptatem alias est suscipit ducimus. Voluptas possimus aliquid quia et dicta impedit eos error molestias. Voluptatem dolor quia voluptatem nisi consectetur nostrum mollitia nihil asperiores. A exercitationem vero eligendi labore enim. Molestiae cumque eligendi unde ipsam. Quo placeat atque eveniet quisquam.\n\nEos numquam excepturi sed consequatur nihil est consequuntur et. Et voluptatem laborum ducimus molestiae. Itaque temporibus nihil dolorum placeat.\n\nEnim sit unde dolores molestiae eum. Fugiat consequatur et ipsa repellat mollitia eum quas. Rerum illo et repellendus dolores qui doloribus odit. Ea molestiae rerum modi nostrum sit temporibus id.\n\nSunt placeat cupiditate sit ea ullam sed dolorum labore. Consequatur aperiam culpa quo ipsum dignissimos illo omnis. Non sit ipsa accusamus sed.\n\nEa numquam et non voluptatum dolor ipsam neque ea assumenda. Numquam quasi eaque. Amet et exercitationem.\n\nSed id architecto assumenda ipsam nesciunt quaerat. Quia omnis laborum voluptatem. Dicta labore suscipit soluta qui quis illum nesciunt cum in. Pariatur occaecati eaque illo quo aut. Doloribus ut quos consequatur. Delectus et consequatur.\n\nAsperiores possimus debitis non libero aut. Ipsam voluptatem consequatur aut ipsa tempore. Fugit est cum est autem et est. Rerum ex vitae qui iure illo sunt maiores. Eum et incidunt sint.\n\nEnim vel officiis qui et libero consectetur. Aut voluptatibus porro ratione modi iusto laborum. Est nisi rem. Voluptatem ex provident sit eum temporibus ipsa. Modi architecto et minus rerum omnis accusantium doloremque voluptatem debitis. Quia vel velit rem ut et enim beatae cum ea.\n\nDolorum eum quae ut libero quaerat ipsum reiciendis qui assumenda. Sed autem nihil cumque corporis perferendis ut rerum. Ex voluptatem qui ea inventore quia. Cupiditate veritatis iure sit. Autem fuga et. Non et earum aut quis nihil voluptatem.", null, null, "Example Page 1 - Paragraph 4", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") },
                    { new Guid("edb16cbc-160a-4ee8-b296-362c8bd9570f"), "Libero et qui consequatur ab consequatur iusto. Et voluptatem perspiciatis. Voluptates non dolorem.\n\nDelectus alias omnis consequatur sunt quia ut eius voluptatibus. Qui recusandae ex aut aliquam rerum nulla. Dolor quis quasi asperiores modi magnam minima suscipit.\n\nPerspiciatis ratione voluptas amet modi quia autem voluptatem dolor amet. Nostrum harum similique dicta. Totam ea itaque asperiores ut aperiam ut.\n\nQuod qui similique beatae aut et. Atque explicabo vero. Officiis reprehenderit qui sit atque. Deserunt qui nihil possimus minus consequatur corrupti.\n\nEst quia voluptatum laborum nihil officiis odit qui omnis quo. Hic est aut dolores qui doloribus voluptas est facere atque. Consequatur et distinctio. Voluptatem soluta dicta quaerat omnis aut asperiores.", null, null, "Example Page 1 - Paragraph 3", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("650a9022-7ad9-478a-b178-768ef017b36f"), false, new Guid("112f76e0-9c50-4b53-b653-5896641151c7"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 2, 19, 5, 14, 237, DateTimeKind.Local).AddTicks(1643), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("1178b9f4-0fa9-4a5e-a462-36adcedb4032") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("70cfa0bd-2697-4529-ab78-3b32b30d5705"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("650a9022-7ad9-478a-b178-768ef017b36f") },
                    { new Guid("f902cebf-fea2-44b4-a91c-3349e4ff9e2c"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("650a9022-7ad9-478a-b178-768ef017b36f") }
                });
        }
    }
}
