using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddForumcommentModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_ForumPosts_ForumPostId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_UserComments_ForumPostId",
                table: "UserComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("010769ea-556e-404b-80c3-224d8a6b07c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35b9abd1-a90b-4937-954d-0f85878280eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4806b03d-98ee-4165-8735-4869da345e4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("485dbdb3-e99d-4b98-b6a9-9304f9e6dedf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ad443ff-eaeb-4a6d-88c6-40e1f068a1ec"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b59976ed-8541-467d-8597-197313c1e157"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc1e2d6-72d7-4134-b3d2-35883fb1d231"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f355aa0a-fdde-4fdd-9ae8-a0bfec415ae7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0f6695c3-ca31-4259-b71e-735ff20dd52d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("23b34c79-d9d2-45fa-b7e3-8c9d0faf08a2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("297cb09d-fd05-48ff-bf1a-fc5041ce191d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("646d80ef-119f-46ec-91f5-da85835053c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6b66515a-c3d3-4f1d-b663-13cf3831e1d3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("73bd4cb3-140c-4ea5-8ecc-f0d1c9fa4b90"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("802e90c8-2cef-4aff-8f0a-58b65587b501"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("865063f5-849b-4c5a-8f3c-d01c5d268ce3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ab6fc0a-1285-43dd-b207-84b0c96eaf56"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8d960016-a7e8-4d33-a76f-2a9a9d0efcf9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9c4523dc-78bb-47b9-8ab8-9ddcb7f34ff6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a055dceb-15cc-416b-8ea5-772755b6543a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c30d6625-7089-4ccd-9003-5f42189b3910"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e09e6c36-f0ed-4c9b-8e33-9a21c0e405a5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e8bcbc63-d15a-4017-842a-8c105cbaa344"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f14363a4-fb3f-40a6-9013-24b01665b994"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3010d17b-550e-45fd-b081-1d10f60af13b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"));

            migrationBuilder.DropColumn(
                name: "ForumPostId",
                table: "UserComments");

            migrationBuilder.CreateTable(
                name: "ForumComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ForumPostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    ReplyToCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ForumComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ForumComments_ForumComments_ReplyToCommentId",
                        column: x => x.ReplyToCommentId,
                        principalTable: "ForumComments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumComments_ForumPosts_ForumPostId",
                        column: x => x.ForumPostId,
                        principalTable: "ForumPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ForumComments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("110f12c6-ff22-4bfa-957d-263647d694ff"), "Science and Technology" },
                    { new Guid("1e214b9a-d844-4b19-8746-a3e0d8ab092f"), "Food and Drink" },
                    { new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"), "Characters" },
                    { new Guid("45c103d5-e4e2-42a6-b2e2-5c7ab00b8b0d"), "History and Culture" },
                    { new Guid("548f3468-e506-44d6-9b2f-d31154f76d01"), "Organizations" },
                    { new Guid("5d4277e6-d9a3-4798-8ff0-6605fdcb5f84"), "Sports and Recreation" },
                    { new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"), "Events" },
                    { new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"), "Stories" },
                    { new Guid("84ff1ff6-75c8-4ef4-80dd-bf1d353ee56e"), "Concepts" },
                    { new Guid("a0184cf6-bb20-40be-ac48-359c42ee4d7f"), "Arts and Entertainment" },
                    { new Guid("aaecda94-0ca1-48bc-8eef-c7f12b5d6f19"), "Technologies" },
                    { new Guid("c87ac71d-1af4-4635-9c34-def734e10438"), "Locations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7"), new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6339), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9"), false, new Guid("c87ac71d-1af4-4635-9c34-def734e10438"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6524), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4"), new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6383), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("00ec6c8d-8632-449a-b9d9-2dab8d597e57"), "Iusto quod similique ad debitis ducimus qui reprehenderit quam. Nobis voluptas sint. Placeat porro ad ipsam in molestiae. Laborum consectetur quia mollitia sed sequi tempora repellat ea.\n\nEt deleniti vel voluptates earum maxime aut temporibus sint velit. Omnis et minus aut maiores rerum alias. Modi in est omnis ad ut ut quae rerum. Consequatur ullam vero incidunt ducimus quod aliquid eum maiores est.", null, null, "Example Page 2 - Paragraph 5", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("1bfaf53d-0130-4713-a132-1045e6b72f3d"), "Eveniet maiores sunt autem. Est atque quam. Quas quia facere quisquam ratione ut aliquid est corporis. Voluptatem fugit aspernatur quia perspiciatis repudiandae cupiditate quia sint accusantium.", null, null, "Example Page 2 - Paragraph 6", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("2f7f430c-e1ed-4b12-b3eb-e6ba96327206"), "Nulla vero consectetur est a eos voluptates. Pariatur nobis eum. In enim non. Non consequatur qui reprehenderit quis aut dignissimos. Fugiat reprehenderit sed perspiciatis consectetur id ut. Rem molestias omnis sed.\n\nVoluptas placeat sit officiis officiis. Quo qui officia. Commodi quia rem sed repellendus ex voluptas. Rerum nam nemo aliquid.\n\nDebitis itaque molestias aut odit voluptatem fugit et consequatur. Repellat et debitis perspiciatis aliquam autem et non. Voluptatem sapiente architecto ut. Sit adipisci animi et molestias consequatur. Eum quia assumenda. Tempora tenetur consequatur consectetur vitae tempore.\n\nEst numquam natus nulla sequi voluptate in doloremque. Ut qui rem delectus itaque fuga itaque eum ea. Est aut error est suscipit. Est necessitatibus id et modi incidunt suscipit nulla asperiores voluptatum. Voluptatem dolorum itaque nesciunt.\n\nDolor facere fugiat omnis excepturi ut alias perspiciatis quos. Veniam perferendis ullam dolores aliquid sunt laboriosam. Quidem nobis quo eius expedita. Veniam enim ratione quas repudiandae. Et odit et.\n\nAutem et voluptates sapiente officiis sit autem qui omnis. Magnam tempore excepturi minus. Natus mollitia rerum voluptate placeat hic culpa consequatur.\n\nRerum nam molestiae qui iusto earum quae possimus consequatur. Ab sed porro mollitia. Quis deserunt nam nihil. Quae sit consectetur quos et ut.", null, null, "Example Page 1 - Paragraph 4", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("471d27b8-b7b4-40dd-a594-644d0bb07dc2"), "Qui esse cupiditate consequatur molestias. Voluptatum ea quam. Et saepe dolor autem a modi rerum laborum.\n\nSimilique ratione beatae velit suscipit eius voluptatibus in minus. Esse dicta doloremque hic corporis nam temporibus repellendus recusandae in. Distinctio et minus dolore.\n\nQuia voluptatem vel odit non eligendi. Ab molestiae deserunt explicabo autem fuga amet accusamus. Aperiam sit praesentium aut tempora voluptas temporibus aut optio. Illum laboriosam laboriosam vero perspiciatis officia et consequuntur odio ea. Suscipit vitae velit repudiandae asperiores. Totam voluptatum officia aspernatur.\n\nMagni est ut velit minima. Sed deserunt quae et ex quidem tempora. Expedita est et eos consectetur eum doloremque quia. Numquam itaque repudiandae. Quas aliquam non odit hic placeat autem. Quos harum iste.\n\nAb rerum facere excepturi consequuntur. Ut voluptatum sunt ut. Ut vitae id est facilis. Similique dicta est nesciunt veniam accusantium ipsum consequuntur quas est.\n\nEt consequatur recusandae. Et ut cupiditate accusantium reiciendis sunt beatae vel officia. Quibusdam et nam fugiat et quo recusandae id ut.\n\nExercitationem non nesciunt. Unde possimus odio quia iste et. Nostrum asperiores ex corporis quo a unde ea.\n\nSuscipit amet reprehenderit tenetur ut incidunt. Esse temporibus repellendus qui ipsum. Et id cum aperiam explicabo aliquid laudantium quia adipisci. Voluptas iusto reiciendis necessitatibus sit.", null, null, "Example Page 1 - Paragraph 5", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("846abb6a-adb7-45ee-b850-9e27afb0849c"), "Autem id impedit molestiae vero nesciunt. Qui assumenda dignissimos. Quam et suscipit qui. Sit ut aut suscipit labore error rerum voluptatem voluptate facere.\n\nNobis eligendi consequatur omnis ut dolorem exercitationem eum. Et atque qui rem explicabo libero eaque occaecati. Minima labore repellendus nihil repudiandae aliquam dolorum unde ut distinctio. Necessitatibus in sed veniam ut.", null, null, "Example Page 2 - Paragraph 4", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("908209b8-7c27-4781-80d2-34066f150aed"), "Minus a qui in reiciendis eum sed vel occaecati nihil. Ducimus molestias velit molestias nostrum sint et soluta. Nihil et sed nihil impedit incidunt. Quasi ab et maiores non inventore quos. Laboriosam eum natus eaque fuga reiciendis. Eveniet quod quidem.\n\nNihil velit esse ipsam rerum voluptatem ullam sequi aut consequatur. Natus cum eaque voluptates qui molestiae aut dolor corporis. Sed veniam quisquam ut at est iure amet.\n\nConsequatur impedit totam. Harum neque quisquam saepe consectetur ipsa. Qui praesentium voluptatem quae voluptas optio expedita. Nihil consequatur debitis hic ut ducimus unde illum.\n\nDicta itaque et eaque. Saepe at assumenda commodi praesentium consequuntur voluptates distinctio perferendis possimus. Delectus iusto ea a facere et.", null, null, "Example Page 1 - Paragraph 2", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("975a93b7-f3f1-4485-b46f-6e09fec883fb"), "Dignissimos nemo porro dignissimos est accusamus aperiam accusantium et eligendi. Ut incidunt nihil dicta aut. Quia facilis tenetur aliquid rerum eligendi sapiente debitis qui cumque.\n\nMolestias esse perspiciatis reiciendis sed sunt velit distinctio consequuntur. Iure sapiente fugit veniam sequi praesentium soluta. Quo hic minus quia id itaque sint molestiae. Neque enim natus ducimus ut voluptatem nam repellat nihil illo.\n\nEx sit veritatis rerum repellendus libero repudiandae iusto atque illo. Non sint necessitatibus optio. Optio totam molestias ullam placeat id blanditiis ut in beatae. Alias quibusdam mollitia sed est quibusdam aliquid dignissimos nihil. Dolor inventore alias eligendi quia accusamus blanditiis ut totam. Et eligendi ut in fugit rerum adipisci rerum in sapiente.\n\nId et facilis dolorum nulla sed magnam. Sed dolorem recusandae similique aut odio necessitatibus dolorem. Aperiam quia nihil eligendi eveniet exercitationem quas. Cupiditate nihil omnis voluptatum in labore.\n\nSint fugit ut et nihil quas voluptas minima. Qui doloribus at ut eum quaerat omnis reprehenderit ipsam. Exercitationem veniam et vitae sit quas ea nobis placeat. Et ea sed perferendis est omnis.\n\nNam est quam et. Dolorem odio rem sint qui. Sit ab velit. Voluptatem eaque qui et id voluptatem iure quia. Eum excepturi amet ipsa voluptas veritatis esse beatae. Voluptatem aut dolorem magnam aut laboriosam est similique commodi molestiae.", null, null, "Example Page 1 - Paragraph 3", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("9821227c-5345-41a5-b6ad-7e636a9b2b1c"), "Quia odit illo qui qui quia adipisci laboriosam. Assumenda commodi magni quis provident rerum hic accusamus voluptas. Natus enim quo expedita eveniet. Explicabo odit sequi qui voluptatem.\n\nSed quas perspiciatis et velit. Ipsum placeat nostrum cupiditate sint. Rerum exercitationem nam. Provident quos vel voluptatem sit aliquam. Deserunt vel porro odio rem impedit quia accusantium ipsam sapiente. Inventore perferendis laboriosam ullam ut dolor quis cum maiores placeat.\n\nConsequatur distinctio numquam recusandae. Sequi omnis ipsa. Debitis nam eveniet corrupti quod. Est et dolorem et inventore architecto iste rerum perferendis quo. Odit sed quidem voluptate tempora sunt.\n\nSit sit magnam repellat. Ab sed autem. Voluptas laborum totam sed officiis quasi consectetur consequatur.\n\nSit et soluta doloremque maiores minus eum. Occaecati blanditiis delectus excepturi qui sed. Facilis nam nesciunt aut commodi quod ab officiis fugit. Ut enim delectus. Corrupti ipsum qui et dolorum saepe laboriosam dolor reprehenderit.\n\nAt odit natus aut. Magni voluptatem et voluptate omnis odit. Aut et dolores repellat.\n\nQuae cupiditate beatae eos est voluptatem. Et voluptates eaque. Reiciendis rerum quam voluptates laudantium dignissimos. Autem inventore eos sunt occaecati reprehenderit nisi nemo et voluptatem. Odio sed incidunt laudantium expedita quis eligendi enim enim et. Dignissimos culpa hic cumque in.", null, null, "Example Page 2 - Paragraph 3", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("a27c0532-92c5-4b39-a897-bd2ce00f2c6f"), "Voluptatem a itaque laboriosam mollitia aliquam eos perspiciatis. Debitis incidunt sit quidem quasi qui voluptate iusto eum. Ipsa deserunt vel labore eius. Natus eum sint et veritatis explicabo unde. Aut et officiis placeat. Rerum eum est doloribus.\n\nEt blanditiis velit et voluptatem autem. Voluptatem modi quibusdam doloribus voluptatem odit ut cupiditate unde. Architecto delectus eligendi dolores occaecati aspernatur. Molestiae voluptatem non molestias enim doloribus explicabo corporis id.\n\nSunt et natus. Et vero consectetur quis veritatis. Consequatur incidunt et consequatur nemo dolorem.\n\nVelit perspiciatis nesciunt voluptate velit ratione itaque perspiciatis. Aspernatur neque aut nobis iste voluptatem ex. Voluptatem unde libero rem aut. Enim saepe excepturi veritatis voluptatibus. Ullam occaecati perspiciatis illum dolor ut eius qui.\n\nVoluptas ullam deleniti nobis quis et similique voluptatem. Voluptate et dolor non. Nihil optio est dicta ducimus qui consequuntur sit velit.\n\nConsectetur aut dolorem rerum. Eaque et eveniet doloremque deleniti maxime aliquid et a non. Soluta deserunt inventore sunt commodi consectetur.", null, null, "Example Page 2 - Paragraph 2", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("b2a39f1a-b60b-4f0e-af27-82886d305e57"), "Maiores quis impedit. Omnis hic quia voluptatem commodi repellendus minus. Est doloremque quos. Et culpa rem. Dolor aliquam occaecati est. Ipsum nam sapiente iusto.\n\nEt quos culpa et. Quam eveniet officiis adipisci illo rerum et temporibus. Consectetur alias corporis voluptas alias nulla. Velit dolor hic necessitatibus quos harum officiis et. Reiciendis voluptatem voluptatem sunt. Consequuntur dolor qui quia consequatur officia placeat maxime.\n\nNihil deserunt molestiae distinctio velit dolores iste et commodi. Dolorum fugit dolores dignissimos maiores. Beatae et velit. Possimus in provident vel.\n\nCupiditate reprehenderit vero ipsa. Facere placeat et recusandae. Incidunt qui saepe. Sequi aut dicta sit perferendis.\n\nHic et et mollitia recusandae ut fugiat earum exercitationem est. Dolorum qui molestiae quidem molestiae rem molestias explicabo. Velit corrupti delectus. Et ipsa sapiente.\n\nConsectetur totam sit. Ab perferendis quas est optio suscipit vel voluptas id. Suscipit fuga voluptatem iure aperiam tenetur perferendis.\n\nA non molestiae possimus impedit id aliquid quibusdam velit. Impedit qui voluptatibus quas vero molestiae. Voluptas ea quaerat minus nulla. Rem quos inventore nemo. Autem eligendi aut harum molestias quis veniam numquam. Id ipsa maxime deserunt et aut dolor culpa.\n\nEt quia id eos. Tenetur laudantium autem quo. Quo quisquam et. Rerum quidem provident consectetur quae. Voluptatem itaque ea ea eaque ullam officiis.\n\nQuaerat quas qui sunt architecto sint. Tenetur dolorem praesentium fugit dolores. Quia voluptatem nostrum. Corrupti ab vitae harum id repudiandae voluptatibus. Odio laborum in fugit aspernatur exercitationem blanditiis quia quasi.", null, null, "Example Page 1 - Paragraph 6", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("b59a74e2-6f6c-4715-b26d-229c3f5cae1c"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9") },
                    { new Guid("c1e98e1a-b8ec-4d9d-a5e4-0f5402863f2d"), "Ad incidunt odit eveniet et voluptatum a labore. Eveniet assumenda in consequatur voluptas porro odio sint explicabo placeat. Perspiciatis reiciendis similique blanditiis voluptas consequatur quaerat.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("dad5179d-ee12-46f7-8e81-cd8a5bb41b14"), "Impedit vero nesciunt dicta. Dicta sint voluptates nisi voluptatum dolorem accusamus eum libero velit. Autem officiis consequatur numquam sapiente. Perferendis ipsum voluptas aliquam facere illo similique consequatur ut repellat.\n\nIn rerum deleniti et. Occaecati ab omnis omnis impedit distinctio ut ipsam et dolor. Et nihil harum saepe dolor facilis. Minus reprehenderit eos velit.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("e849bed8-972e-4c8e-bc8f-61f46ff292d6"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b"), false, new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6528), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0805951f-90b1-457b-85ef-7c8f39996d88"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b") },
                    { new Guid("852ac18a-7c71-4317-b502-344d01edceab"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumComments_ForumPostId",
                table: "ForumComments",
                column: "ForumPostId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumComments_ReplyToCommentId",
                table: "ForumComments",
                column: "ReplyToCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ForumComments_UserProfileId",
                table: "ForumComments",
                column: "UserProfileId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId",
                principalTable: "ForumTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts");

            migrationBuilder.DropTable(
                name: "ForumComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("110f12c6-ff22-4bfa-957d-263647d694ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e214b9a-d844-4b19-8746-a3e0d8ab092f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45c103d5-e4e2-42a6-b2e2-5c7ab00b8b0d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("548f3468-e506-44d6-9b2f-d31154f76d01"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d4277e6-d9a3-4798-8ff0-6605fdcb5f84"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("84ff1ff6-75c8-4ef4-80dd-bf1d353ee56e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a0184cf6-bb20-40be-ac48-359c42ee4d7f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaecda94-0ca1-48bc-8eef-c7f12b5d6f19"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("00ec6c8d-8632-449a-b9d9-2dab8d597e57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0805951f-90b1-457b-85ef-7c8f39996d88"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1bfaf53d-0130-4713-a132-1045e6b72f3d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2f7f430c-e1ed-4b12-b3eb-e6ba96327206"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("471d27b8-b7b4-40dd-a594-644d0bb07dc2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("846abb6a-adb7-45ee-b850-9e27afb0849c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("852ac18a-7c71-4317-b502-344d01edceab"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("908209b8-7c27-4781-80d2-34066f150aed"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("975a93b7-f3f1-4485-b46f-6e09fec883fb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9821227c-5345-41a5-b6ad-7e636a9b2b1c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a27c0532-92c5-4b39-a897-bd2ce00f2c6f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b2a39f1a-b60b-4f0e-af27-82886d305e57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b59a74e2-6f6c-4715-b26d-229c3f5cae1c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c1e98e1a-b8ec-4d9d-a5e4-0f5402863f2d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("dad5179d-ee12-46f7-8e81-cd8a5bb41b14"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e849bed8-972e-4c8e-bc8f-61f46ff292d6"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c87ac71d-1af4-4635-9c34-def734e10438"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"));

            migrationBuilder.AddColumn<Guid>(
                name: "ForumPostId",
                table: "UserComments",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("010769ea-556e-404b-80c3-224d8a6b07c6"), "Sports and Recreation" },
                    { new Guid("35b9abd1-a90b-4937-954d-0f85878280eb"), "Organizations" },
                    { new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"), "Events" },
                    { new Guid("4806b03d-98ee-4165-8735-4869da345e4b"), "Science and Technology" },
                    { new Guid("485dbdb3-e99d-4b98-b6a9-9304f9e6dedf"), "Technologies" },
                    { new Guid("4ad443ff-eaeb-4a6d-88c6-40e1f068a1ec"), "Concepts" },
                    { new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"), "Stories" },
                    { new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"), "Locations" },
                    { new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"), "Characters" },
                    { new Guid("b59976ed-8541-467d-8597-197313c1e157"), "History and Culture" },
                    { new Guid("bcc1e2d6-72d7-4134-b3d2-35883fb1d231"), "Arts and Entertainment" },
                    { new Guid("f355aa0a-fdde-4fdd-9ae8-a0bfec415ae7"), "Food and Drink" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091"), new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6216), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8"), new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6264), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("3010d17b-550e-45fd-b081-1d10f60af13b"), false, new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6494), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0f6695c3-ca31-4259-b71e-735ff20dd52d"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("3010d17b-550e-45fd-b081-1d10f60af13b") },
                    { new Guid("23b34c79-d9d2-45fa-b7e3-8c9d0faf08a2"), "Explicabo in est earum in et sunt maxime. Excepturi excepturi occaecati et non est aut. Asperiores unde est ut quasi ad in iusto quidem quaerat. Voluptatem numquam quo quas. Facere corporis facilis ullam et. Quia et eum in quis incidunt expedita dolorum.\n\nEnim sit aut quasi earum molestiae. Officia error aut. Ut aperiam earum consequatur eum officiis iure suscipit est qui. Neque delectus est facilis fugit sunt at nemo quam. Aut ut consequatur iure voluptates commodi non.\n\nVoluptas itaque velit consequatur repudiandae repellendus. Sed repellat beatae. Necessitatibus assumenda pariatur ab sit fugiat minus.", null, null, "Example Page 1 - Paragraph 2", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("297cb09d-fd05-48ff-bf1a-fc5041ce191d"), "Iusto iste officiis mollitia voluptatibus voluptates dignissimos. Aut aut facere vitae dolorem libero illum beatae. Repellendus impedit aspernatur non nostrum in tenetur aut quasi. Vitae maiores aliquam.\n\nSed magni cumque tempora ut eligendi ad odio alias nihil. Natus id autem consectetur aspernatur. Qui nihil quis quis.\n\nUnde incidunt sint inventore ad exercitationem repellat ut. Nisi voluptatem dolores consequatur dolor libero. Quia aut earum nam et cumque ipsa et. Nobis qui enim natus aut dolores. Voluptatem est enim iusto sit rerum est molestias itaque quis.\n\nQuia facilis dolore adipisci qui dolor cumque tempora. Quia quia sunt soluta sint reiciendis. Reprehenderit et quisquam animi enim tenetur quis.\n\nQui eos et ut ut fugiat et. Voluptas rem aliquam quidem doloribus assumenda. Quibusdam consequatur inventore odio tempora esse. Voluptas est quaerat sunt maxime est totam et. Odit minima quia nihil culpa porro nulla laudantium sed.\n\nSit nihil harum quia debitis occaecati numquam similique quisquam. Et provident nulla occaecati voluptatem rerum asperiores esse. Laborum vero sed aut non facere laboriosam consequatur optio. Quos quia accusamus harum consequatur et dolores. Cupiditate fuga harum reiciendis aut odio et ex nulla tempore. Non sunt dolore ipsa.\n\nQui fugiat at illo. Ut possimus qui at fugit. Atque non architecto cumque. Sint veniam porro. Ea in unde natus nulla. Omnis veniam qui sunt porro ut ipsam quo magnam nemo.\n\nFacilis nesciunt aut omnis rerum facere quia. Et asperiores dolorum sed sit et omnis qui vero. Accusamus eveniet velit consequatur enim et consequatur voluptatem sunt.\n\nAccusamus rerum id. Sapiente atque velit mollitia tempora ut voluptas. Deserunt rerum et amet ipsum sint et.", null, null, "Example Page 1 - Paragraph 4", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("646d80ef-119f-46ec-91f5-da85835053c0"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("3010d17b-550e-45fd-b081-1d10f60af13b") },
                    { new Guid("73bd4cb3-140c-4ea5-8ecc-f0d1c9fa4b90"), "Eum quis atque nemo quod. Vel sit et repellendus. Earum velit rem a molestias ut voluptatem officiis dolore. Est praesentium ab ut delectus amet architecto hic voluptas est. Aliquam occaecati saepe veritatis autem laboriosam perferendis nostrum ut quam.\n\nVoluptas qui est pariatur soluta amet incidunt aut ad. Consequatur eius quia autem et. Neque aut commodi libero odio perspiciatis omnis est sed. Animi quia pariatur enim animi sint.", null, null, "Example Page 1 - Paragraph 6", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("802e90c8-2cef-4aff-8f0a-58b65587b501"), "Hic quam numquam odio labore aut quo. A iste et est officiis aut alias natus voluptas et. Ea recusandae laboriosam voluptatem iusto non ad saepe. Eius quos sunt blanditiis minima vitae fugiat sit. Facere est numquam. Facilis sed quod inventore dolor corrupti dolore est accusantium eius.\n\nNihil voluptatem autem et. Perferendis fugiat vero deserunt nostrum quo. Sunt delectus nostrum. Non deleniti culpa sequi incidunt voluptate enim. Aut enim possimus qui nulla. Necessitatibus saepe nihil est eveniet commodi nemo laboriosam voluptates voluptatum.", null, null, "Example Page 2 - Paragraph 4", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("865063f5-849b-4c5a-8f3c-d01c5d268ce3"), "Aut reiciendis est earum maiores totam. Odio sint doloribus autem et autem dolorem aut quos. Eaque tempore voluptatem fugiat maiores in explicabo dolorum.\n\nPlaceat autem omnis libero eligendi cum sequi eligendi doloribus ullam. Repudiandae ab veniam. Dolore illum tempore rerum cum aliquam voluptates animi omnis. Cupiditate veritatis quia adipisci quisquam nemo incidunt tempora ab.\n\nConsequatur eligendi blanditiis. Consectetur id quaerat qui omnis quo rerum quos molestiae id. Doloribus nostrum id voluptas voluptates non modi fuga.\n\nPorro consequatur illum tempora deleniti dolores voluptate officiis. Veniam quaerat expedita aut natus eum suscipit. Quisquam quis id soluta. Omnis velit esse quo quia quae earum eius suscipit nam.\n\nIure illo beatae nihil possimus illo. Reiciendis voluptas animi aut. Consequatur doloribus amet pariatur voluptatem necessitatibus ut nisi. Eaque dolores aliquid excepturi.\n\nNobis non accusantium voluptas voluptatem rerum ea provident quia minima. Nesciunt iure voluptas sed qui. Deserunt omnis id vel fugit veniam accusamus ex atque voluptatem.\n\nEst tenetur asperiores quibusdam molestias. Inventore occaecati excepturi possimus. Illo magnam quia.\n\nSuscipit voluptatibus cum. Autem veritatis dolor reprehenderit amet eligendi quia ea eum provident. Et consequuntur dolorem.", null, null, "Example Page 1 - Paragraph 3", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("8ab6fc0a-1285-43dd-b207-84b0c96eaf56"), "Quae ut quod. Quam asperiores et et maiores temporibus enim dicta expedita. Quis consequatur ad. Unde rerum dolorem error animi et ea dolorum. Earum accusamus et ex et. Ea corrupti est nisi ullam ea illum temporibus.\n\nVelit nesciunt eos molestiae voluptatem sint ab soluta voluptate. Cumque rerum explicabo vel. In molestias ut beatae recusandae nisi ex saepe. Ipsam animi non architecto facere. Inventore aperiam nihil.\n\nId laboriosam ut occaecati doloremque omnis quibusdam facilis. Sit veniam earum at occaecati cum. Culpa molestiae voluptas. Delectus mollitia pariatur corporis ut rerum earum aliquam. Explicabo facere sit et quos. Rerum architecto modi quas molestiae harum quia aut itaque.\n\nEt accusantium illum mollitia est et perferendis doloribus vel. Sit ut fugiat vel animi ipsam voluptas aut. Quibusdam labore temporibus.\n\nSunt et quia ipsum est inventore non molestiae reiciendis nisi. Inventore porro beatae repellat illo qui temporibus eligendi. Voluptas aliquam ea dolore odio id consequatur vel tenetur.\n\nLaudantium sit fugit similique fugit nihil eius ea itaque. Exercitationem sunt rerum repellat officia est vero asperiores. Ratione nihil error incidunt et minima ratione ut adipisci est.\n\nEius et ut ut. Ullam et et itaque consectetur. Id at sed. Vero labore at soluta.\n\nAliquam natus commodi minus et repudiandae. Minima amet officiis et expedita quia quis quia eos. Ut et aliquam sit et quidem perferendis quam dolore quo.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("8d960016-a7e8-4d33-a76f-2a9a9d0efcf9"), "Explicabo temporibus facere qui numquam consectetur error. In consectetur aut. Rem et reprehenderit corporis voluptas repudiandae assumenda optio reiciendis. Eius ea atque ut corrupti. Consectetur aliquid veritatis vero beatae quia voluptatem aliquid iure.\n\nAut autem aliquid ad velit corporis possimus repudiandae. Labore repudiandae rerum ab perferendis consequatur possimus est. Et libero non quo nesciunt dolorem rerum accusantium. Necessitatibus autem alias doloribus dignissimos magnam ut. Explicabo aut quia ratione omnis. Inventore ullam ut dicta distinctio temporibus itaque.", null, null, "Example Page 1 - Paragraph 5", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("a055dceb-15cc-416b-8ea5-772755b6543a"), "Voluptas dignissimos quam deserunt maiores dignissimos explicabo cupiditate rem voluptatibus. Porro ipsam ea culpa. Placeat id eum omnis velit fuga voluptatem et maxime. Impedit quaerat quod quos et qui sed.\n\nMinima quia corrupti odio officiis. Nisi saepe qui. Laudantium reprehenderit rerum qui porro consectetur. Ipsa distinctio perferendis optio repellendus libero. Voluptatem nemo accusantium voluptatum ut.\n\nEt dolorum voluptates et cumque. Est ut ipsam itaque sit et officia occaecati. Fugiat consequatur alias placeat laboriosam ut quia corrupti sunt id. Ipsam et consectetur maxime veritatis voluptatem repellendus ut.\n\nEst at sit iste maxime deserunt facere voluptatem. Iste quia minima temporibus perspiciatis voluptatibus voluptatum doloremque. Architecto omnis nostrum voluptatibus. Voluptas eius voluptates est quia quis nemo.\n\nDucimus nemo voluptatem. Provident blanditiis maxime. Ut repellat ratione voluptatem occaecati. Delectus qui dolor aut tempora ex veniam et dolores sunt.\n\nQuo fugit molestiae repudiandae consequatur veritatis qui harum. Commodi voluptatibus saepe ipsa nemo placeat soluta itaque laboriosam. Ratione ad expedita omnis. Atque aspernatur et voluptatem sequi asperiores veniam.\n\nPariatur quam culpa eos et. Enim rem earum inventore et quaerat consequatur et. Odio omnis esse rem. Cumque voluptas qui est quo. Id harum exercitationem rem accusamus dolorem quam deleniti in. Commodi aliquam soluta ducimus repellendus at iure iure odio.", null, null, "Example Page 2 - Paragraph 6", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("c30d6625-7089-4ccd-9003-5f42189b3910"), "Ipsum iure optio accusamus quam. Quo cumque delectus facilis voluptatem aut perspiciatis. Eligendi assumenda ut et. Dolores qui molestiae.\n\nCum aut rerum et. Perspiciatis veritatis et. Cum qui odit delectus est ad quibusdam cumque quia aliquid. Recusandae hic dolorem ut minima praesentium a nostrum assumenda dolor. Blanditiis quidem exercitationem non similique repudiandae quia. Voluptas voluptas quis voluptatem.\n\nHarum aut id facere excepturi quia et et. Rerum id eligendi totam nemo temporibus eum quia. Et rem odit. Delectus sint reiciendis. Nihil reprehenderit sed ad sed eius consequatur amet mollitia rerum. Sunt maiores ipsam maxime ad occaecati quas.\n\nNon accusamus soluta ut quia harum a ut voluptates. Aut aut non reiciendis. Tempore voluptatum qui natus eos minus nobis laborum.\n\nDolorem porro illum quibusdam. Temporibus accusantium non laudantium. Est vel numquam distinctio tenetur accusamus consequatur. Autem voluptatem aperiam.\n\nAut corrupti magni iure eos nisi voluptatem nisi sint. Culpa laudantium molestiae nostrum error deserunt nam dolor qui inventore. Placeat porro et aut. Consectetur ipsa aperiam. Rerum dolores neque omnis iusto consequuntur quos.\n\nA consectetur delectus aut qui. Sed ut sed in quidem. Ea explicabo earum. Laboriosam sit veniam voluptates exercitationem ipsum dicta quia quia fugiat. Aperiam provident veritatis doloribus.", null, null, "Example Page 2 - Paragraph 2", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("e09e6c36-f0ed-4c9b-8e33-9a21c0e405a5"), "Unde veritatis saepe voluptate non libero accusantium. Possimus libero repellat sed autem et. Autem inventore quisquam.\n\nEa esse et placeat. Nam velit et praesentium. Nam voluptas veniam quisquam.\n\nCumque ea repellat qui voluptas illum. Labore ut aut atque vitae. Quaerat nobis accusamus atque.\n\nLabore non ipsa aut nihil dolorem molestiae aliquid. Aut mollitia repellendus unde voluptas voluptas voluptas modi. Aliquid est id ut porro qui error occaecati. Necessitatibus nobis rerum similique libero laborum aspernatur ipsam ex. Quia est voluptatem quo error molestiae. Tempora libero voluptatibus.\n\nItaque sit distinctio aut quia voluptatum magnam laboriosam illo. Culpa distinctio consequatur. Iusto alias consequatur. Fugiat nisi velit nihil. Est non dolor maiores qui adipisci et.\n\nCulpa explicabo consequatur voluptatem quo harum necessitatibus odio. Est voluptatem omnis nulla libero quis voluptate. Et voluptate culpa assumenda asperiores molestias a non. Rerum numquam velit adipisci enim animi molestias.\n\nAsperiores impedit in tenetur sequi earum. Eos doloremque et est molestias veniam delectus id dolores soluta. Incidunt magnam error reprehenderit aliquam esse totam a eius odit. Et non aperiam et aut consectetur. Recusandae et rem earum est modi. Nesciunt at facilis beatae aliquid.\n\nQuaerat occaecati sequi rerum consequatur. Eaque quod non sed nemo odio eos eos autem. Voluptates repellat error culpa consequatur. Rerum et aut sequi laudantium sed minima quia temporibus quis.\n\nNisi id alias qui. Et odit cum porro eligendi pariatur deserunt ratione minima. Nisi fugit reprehenderit. Ab deleniti ea. Odit a corrupti sed voluptas aut.", null, null, "Example Page 2 - Paragraph 3", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("e8bcbc63-d15a-4017-842a-8c105cbaa344"), "Tempore quia autem voluptatibus exercitationem architecto nulla. Enim reiciendis dolorum. Cumque sunt dolores molestiae molestiae. Maxime nesciunt et animi nihil totam omnis est delectus.\n\nSaepe aut quia fugiat. Molestiae illum autem quas eos exercitationem rem dolores. Ut maxime enim maiores exercitationem distinctio eaque porro occaecati sit. In et doloremque quia. Non nostrum culpa illo aperiam facere unde ipsum. Nobis non explicabo quia et aut ducimus perferendis.\n\nHarum consectetur necessitatibus. Error rerum hic voluptates harum harum inventore. Aperiam sapiente excepturi doloremque placeat voluptatibus quos.\n\nQui laboriosam consequatur explicabo ut id voluptas. Consequatur voluptatibus odio in quia. Non dolor quaerat facere tempora atque officiis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("f14363a4-fb3f-40a6-9013-24b01665b994"), "Quo dolorum architecto nihil dolorem est ducimus maiores voluptatem. Quos laboriosam molestiae consequatur magnam. Vitae atque molestiae sed aspernatur similique porro enim.\n\nVoluptatem voluptates nostrum aspernatur id ut perspiciatis. Dolorem quia numquam sapiente. Non reiciendis ea vel eum dolorum possimus autem. Nesciunt voluptatem iste sed sit sunt est ex.\n\nVel delectus id voluptatem fuga. Quia vitae cumque maxime praesentium sunt sint consequuntur sit officiis. Laudantium ullam perferendis repellendus sint similique odio.\n\nAutem est repellat quibusdam dolore sed. Ducimus unde quis assumenda nihil. Vero et rem voluptatem neque molestiae sed.", null, null, "Example Page 2 - Paragraph 5", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585"), false, new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6500), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("6b66515a-c3d3-4f1d-b663-13cf3831e1d3"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585") },
                    { new Guid("9c4523dc-78bb-47b9-8ab8-9ddcb7f34ff6"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ForumPostId",
                table: "UserComments",
                column: "ForumPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId",
                table: "ForumPosts",
                column: "ForumTopicId",
                principalTable: "ForumTopics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_UserProfiles_UserId",
                table: "ForumPosts",
                column: "UserId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_ForumPosts_ForumPostId",
                table: "UserComments",
                column: "ForumPostId",
                principalTable: "ForumPosts",
                principalColumn: "Id");
        }
    }
}
