using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumTopicModel1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("064a69c6-c22d-4cc0-987a-2215b912e1b8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1a3763ef-66f7-4044-a632-169d762e6956"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3c4a99a7-6b84-4938-90dd-eecbceb03688"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43f84537-1ce0-4894-859f-16aaca3c5d8d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c066abc-a1d5-4072-9dbd-41277e60cbbe"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d12c441b-81ab-4e79-a218-987284307616"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dbee973e-34f6-47f3-ac07-c1921fe157a3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e035155b-6da3-4c04-83ec-20224a8af4d9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0b6bb608-83d5-4da8-8802-6804e5324b20"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0fad8d66-8e8d-4fd3-86b4-3fd70b69f195"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1350da13-da00-49a9-a96f-9f6376a1ca79"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("20186a32-3bd6-4b45-ae78-fef552569cf3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2224f60d-554c-4ea0-98c9-168998737c3a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2bfddf9f-36fb-4e85-b29c-098f63b7559d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2c768fae-72ed-42be-b063-e6f5793eece6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4adcca50-7dd6-453c-967d-5053c52869e9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("59012168-a717-427b-aa4c-1ad876e6cc2f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5910cdef-a239-4533-88d0-59658ea3e0e0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("711cd56d-0117-4686-88f6-927708e32797"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("99ad0bde-c8dc-4181-9946-095c504488b7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ec6c11f3-81e4-4f04-a596-2332c5fa71e0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ed004a11-61c8-4971-a113-4397b04303df"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f1ccdf42-89bd-4714-b8d7-ef4e1913653c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("faecb3d9-254d-4b50-912a-83120af7b634"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("6429a241-f6f5-4964-b4c1-a32a7d176f6b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("f3464d25-401c-4276-a117-399e440f6a74"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0a8e5d4b-a99e-4ef5-b84c-ad152ccc74ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5ae63cb9-43ba-4993-b30a-43af10046f16"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("cadc3bc7-58db-4b9a-b6a2-5ec79c9ddad8"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("9e39a89d-c92e-4ad3-8865-846c91078738"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22be1c9b-a3e9-4dbf-a95c-0381188b4d8f"));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ForumTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("05e7094d-00ac-4950-9746-b97a42978548"), "Concepts" },
                    { new Guid("0645041a-b946-4a96-b4dc-af263ca3a66c"), "Characters" },
                    { new Guid("0efc5f14-4878-4d4c-b73b-05b1ea53744f"), "Events" },
                    { new Guid("2cb74917-1d81-4993-b60a-cc1b5728135e"), "Technologies" },
                    { new Guid("389bb7d6-8184-4979-8de9-5ca4f804de8a"), "Food and Drink" },
                    { new Guid("40513901-e675-405b-abf1-a69ed7e48f24"), "Sports and Recreation" },
                    { new Guid("55b10fb9-3dc8-46c7-a4fe-c7f3743fb484"), "Locations" },
                    { new Guid("67cb3f91-be42-43af-83f7-9d812208f0ad"), "History and Culture" },
                    { new Guid("8ac181e8-69db-40bf-a996-b26f1dc96c2d"), "Science and Technology" },
                    { new Guid("9a194e20-10ec-40bf-8a16-fc8360931391"), "Stories" },
                    { new Guid("a9bdbf20-d22f-42dc-8a0a-0aec28d4c9b4"), "Organizations" },
                    { new Guid("b93cc55b-0388-4d33-9fce-79f574784acd"), "Arts and Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5"), new Guid("9a194e20-10ec-40bf-8a16-fc8360931391"), null, "WikiPage", null, true, new DateTime(2024, 5, 13, 18, 1, 56, 352, DateTimeKind.Local).AddTicks(7921), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("2821b676-c2e9-45e9-86b2-3cf43d398c34"), false, new Guid("55b10fb9-3dc8-46c7-a4fe-c7f3743fb484"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 13, 18, 1, 56, 352, DateTimeKind.Local).AddTicks(8071), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640"), new Guid("0645041a-b946-4a96-b4dc-af263ca3a66c"), null, "WikiPage", null, true, new DateTime(2024, 5, 13, 18, 1, 56, 352, DateTimeKind.Local).AddTicks(7879), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0ef56c50-c044-4964-b0fe-fbc4f7d6233a"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("2821b676-c2e9-45e9-86b2-3cf43d398c34") },
                    { new Guid("3d223e62-5cf2-46b5-bbfc-571f4945dc1e"), "Ut ab aut voluptates. Laudantium velit quibusdam rerum error doloremque accusantium nihil. Incidunt dolores tempore hic nostrum dolores et blanditiis pariatur commodi. Adipisci dolores assumenda voluptas. Dolore ut sit. Et aliquam consequatur et.\n\nAut tenetur et sed omnis. Sapiente aliquid vel et ad quam. Consequatur possimus sit aperiam qui dicta adipisci minima repudiandae tenetur.\n\nDolores autem occaecati deserunt. Dolores minima tenetur eligendi sit blanditiis voluptas. Quo suscipit quia. Sit aliquam autem autem id nostrum ea. Iste et nisi consectetur illo aut asperiores.\n\nEarum reprehenderit a et. Aut expedita id asperiores et architecto ipsum quam. Rerum harum assumenda eaque explicabo ad quam.\n\nMagnam quibusdam repudiandae nemo. Minima nemo excepturi. Eveniet quam in officia rem a voluptas.\n\nHarum facilis voluptas rerum natus distinctio veritatis deleniti fugiat enim. Impedit maiores adipisci nihil aut voluptatibus doloremque. Aliquid praesentium pariatur.\n\nOmnis omnis quidem ad qui ad ea. Est omnis culpa. Sunt et quae. Sapiente necessitatibus nobis ab fugiat. Velit suscipit consequatur voluptatum eos et aut quasi beatae. Aut et consequuntur blanditiis.", null, null, "Example Page 2 - Paragraph 5", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") },
                    { new Guid("40835abe-6300-457a-86b1-2bf9b84b6fd3"), "Fugiat sit perferendis. Quis eaque autem. Saepe possimus ex iste ipsam. Qui iste maxime praesentium consequuntur eveniet unde quaerat voluptas sit.\n\nSit itaque quis in laborum minima blanditiis. Et beatae enim neque totam in. Consequatur nam necessitatibus et sit.\n\nQui architecto quas sed quo. Exercitationem totam non voluptatem iusto quo itaque culpa. Repudiandae aspernatur itaque voluptas illum veniam facilis. Explicabo eum ut minima ipsum culpa officia.\n\nNobis nulla inventore et sed. Nihil rerum aut excepturi repudiandae exercitationem dolores ab. Nihil ipsa sint deleniti qui et non. Exercitationem hic distinctio quibusdam. Aut voluptas saepe sint veritatis et necessitatibus minus ipsam omnis. Voluptatum non dolores sint.\n\nRerum totam debitis hic qui ullam in enim et incidunt. Eum nihil sed atque a. Est impedit sed commodi. Ipsa at omnis assumenda sed.\n\nSint recusandae et ipsa. Qui incidunt omnis fuga sed quo. Deleniti voluptas architecto magnam minima nemo. Ullam quia culpa velit. Laboriosam facilis porro aut ratione.\n\nEum quia et repudiandae omnis dignissimos ad repudiandae in rerum. Sed omnis illo ipsa ex pariatur velit. Accusantium voluptate eius veritatis numquam facere similique. Est delectus iusto. Corrupti consequatur error quos molestiae numquam ipsa.\n\nAt reiciendis quaerat placeat aperiam enim dolores commodi. Vel quod non eum sit expedita et accusantium enim modi. Quo aliquid quia rerum quis. Exercitationem qui laudantium itaque. Omnis veniam rerum eaque nemo.\n\nSimilique fugiat illum cumque libero. Quam voluptates adipisci ipsum. Velit enim officiis tenetur saepe. Magnam est amet molestiae esse blanditiis. Molestiae possimus quia tempore quisquam non et. Porro illum dolores possimus consequatur hic soluta et delectus molestiae.\n\nVoluptatem autem aut. In praesentium quia ex. Eum temporibus ut repellat autem sed.", null, null, "Example Page 1 - Paragraph 6", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("4a54899b-6ada-4b04-9fdc-1ce737ca3ede"), "Quia quia qui odio. Corrupti ducimus nobis quia asperiores quod voluptas rerum quo doloribus. Nihil pariatur ab. Ipsam voluptatem quia laborum excepturi et sed.\n\nTemporibus porro animi quas architecto officia sit eum voluptatem. Voluptas labore possimus enim eveniet qui. Adipisci quo rerum. Consequatur tenetur harum sit qui. Vel dolore temporibus veritatis dicta sed qui rerum omnis.\n\nPariatur aut eum vitae aut accusantium et. Sunt similique sapiente et dolorum quibusdam. Provident cumque inventore quam repellat esse id. Illum doloremque ad sit maiores fugit fugit vel.\n\nMinima consectetur voluptatem. Suscipit atque consequatur explicabo nesciunt illo quia perferendis facilis quasi. Ut et unde.\n\nIure quae molestias molestiae id. Dolorem voluptatibus incidunt asperiores. Dolores explicabo ea ipsa quidem mollitia repellat. Laborum fugiat enim voluptatem beatae. Magni dolore provident minima sit ut voluptatem excepturi eveniet. Aut temporibus aspernatur et distinctio tenetur ratione incidunt consectetur sunt.\n\nExplicabo ut qui asperiores repellendus aliquam quo itaque laboriosam. Commodi est enim dolorum mollitia doloribus. Voluptatem magni corrupti. Eum laudantium et eos ipsa rem sapiente consequuntur et. Dicta officiis quasi voluptatem magnam id amet dolorem. Ullam voluptatem quod exercitationem autem voluptates.\n\nSaepe corporis exercitationem in. Fugiat quo est recusandae voluptate iure nobis sunt. Totam quo ratione cum consequatur natus non. Omnis officia est. Est odit aliquam.\n\nNatus laborum est beatae dolores consequatur cumque. Odit dolores est tempora odit quia harum. Est beatae ea laboriosam blanditiis praesentium sapiente quo voluptas. Reprehenderit dolorem optio corporis hic assumenda ipsa neque maiores. Tenetur repudiandae pariatur autem nostrum blanditiis voluptatem et corporis.\n\nNobis quibusdam asperiores ipsam est tempora voluptates et dolores corporis. Dignissimos illum aperiam eligendi dolor voluptatem. Molestiae eius error.\n\nMollitia dicta cupiditate. Saepe incidunt distinctio quae ratione aut debitis id sint quasi. Dicta saepe est dolorem aut quis enim facere dolores nisi.", null, null, "Example Page 2 - Paragraph 3", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") },
                    { new Guid("636ef31f-6479-4704-9015-dc305220d987"), "Reprehenderit delectus est veritatis. Inventore et quibusdam est aut quos officia veritatis. Nostrum quas pariatur. Esse non est consequuntur sed. Quia molestiae fugiat praesentium et vero sunt. Quis voluptatum iste error quis iusto.\n\nVelit maiores quas recusandae quaerat a suscipit asperiores enim quos. Delectus quia enim facere ut. Et recusandae voluptas possimus voluptate aut.\n\nVoluptatibus repellendus facere animi. Odit nemo eos. Eum ea quae in dolore quaerat dolorem delectus. Saepe repellat voluptatem non incidunt vel quia. Et dicta eveniet et voluptatem et vel omnis velit. Quo ut exercitationem quasi.\n\nSapiente voluptas quo ratione mollitia debitis aliquid quo fugiat velit. Nobis eius iure et dolor consectetur sint quia expedita omnis. Sunt excepturi dignissimos cumque dignissimos maxime in voluptatibus enim iure. Quasi quia dolorem reprehenderit excepturi. Eligendi est ut cupiditate. Debitis et repellat adipisci repellat labore dolorem ea voluptas.", null, null, "Example Page 1 - Paragraph 2", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("82a6c242-66cd-4e16-bc64-52a7b9baaed0"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("2821b676-c2e9-45e9-86b2-3cf43d398c34") },
                    { new Guid("84161510-1773-47e8-8f7f-444ab7204028"), "Provident dignissimos rerum dolores. Sunt vel quis nulla ratione libero. Et commodi sed. Natus et sit temporibus dolore ullam.\n\nNon iure suscipit. Sint labore ut repellat ut eius. Animi facilis est impedit.\n\nCumque aut debitis inventore minus temporibus temporibus. Nesciunt explicabo in. Vitae saepe aut occaecati explicabo quaerat molestias nobis quaerat. Quae labore quia neque et minima impedit pariatur deserunt quis. Quia odit laboriosam eaque harum.\n\nDeserunt rerum fuga itaque et tempora. Doloremque odit qui dolores dignissimos ducimus ut rerum totam tempora. Est nisi illum tenetur et velit aut. Et in ratione aut.\n\nEsse sequi explicabo. Sit qui at nihil eligendi. Reprehenderit provident eius dicta. Rerum eligendi et blanditiis deserunt nihil a aspernatur quaerat qui. Saepe molestias odio aut minima delectus et corporis temporibus. Totam odio et quis eius voluptates eum et.\n\nSed iure omnis quis et vero voluptatibus praesentium. Consequatur delectus autem. Fuga inventore aspernatur eaque est quis occaecati.\n\nQuasi eum voluptate totam excepturi dolore recusandae. Iusto ipsa asperiores molestiae ex et inventore dignissimos suscipit nemo. Odio aliquam velit consequatur ut. Quos aperiam aliquid corrupti sed temporibus iure. Repellendus est eligendi nam doloremque. Sed fugiat est omnis corporis esse non velit.\n\nDoloribus atque inventore nulla sunt et. Earum illum sapiente quia consequuntur dignissimos sint aperiam. Dolor vel quia fugiat consequatur. Tempore delectus aliquid consequatur saepe nam.", null, null, "Example Page 1 - Paragraph 3", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("8827fcbe-2b1f-4cc4-8bd1-be9545f4a5de"), "Ut quae ad corrupti iusto voluptatum. Dolorum voluptatem dolor distinctio fugit nihil. Consequatur aliquam ea rerum rerum aspernatur dolor cum necessitatibus ut. Architecto harum voluptatem eaque libero sapiente excepturi reprehenderit et. Possimus nostrum porro fugiat dolor saepe.\n\nVoluptas ut nulla. Accusamus et sed aut. Molestias fugit quis earum ea quas necessitatibus et est cumque.", null, null, "Example Page 2 - Paragraph 6", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") },
                    { new Guid("a6231715-6939-4957-84ea-209800b23e2f"), "Sit quasi voluptate dolores qui voluptates nihil veniam nam. Sequi quo sit fugiat facere ex magnam aut. Et praesentium eaque omnis iste mollitia et. Quos nulla maxime molestias blanditiis magni architecto quia sint quam. Voluptatem voluptas iure atque aperiam iure.\n\nIncidunt aut consectetur commodi consectetur et fugit rerum. At omnis dolorem ipsa fuga delectus sapiente. Neque sit cumque. Est non non et. Minus id molestiae.", null, null, "Example Page 1 - Paragraph 5", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("ad6fbf07-94fa-4857-af72-c15843979338"), "Sequi rerum odio. Enim deserunt labore at voluptatum cumque quia. Deserunt libero aliquid dolorum nesciunt laborum qui.", null, null, "Example Page 1 - Paragraph 4", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("b587747b-a84d-4152-9fcf-4c01739a4b9e"), "Et est eveniet sed ipsum consequatur assumenda. Deserunt reprehenderit dolore nesciunt. Rem dolorum nulla iure ut maxime quia rerum. Quibusdam consequatur aspernatur earum excepturi voluptas sunt et. Et eveniet provident nihil cupiditate consequatur animi sint ut. Iusto enim placeat consectetur.\n\nQui laborum sapiente ut nostrum ea exercitationem iste. Inventore pariatur delectus amet qui sint illum dicta. Consectetur minima iure et dolorum et et molestias dolor. Illum voluptas minus quidem et harum architecto. Nihil blanditiis quis id est nemo aperiam expedita atque voluptatem. Dolorum ut illum quas enim totam sit rerum.\n\nSequi magni sint aut et occaecati nisi. Aliquid in ex. Sunt quidem perspiciatis iusto et libero cum unde veritatis ex. Saepe qui rerum magnam. Eaque labore ut omnis praesentium earum. Cumque veniam quia quaerat qui asperiores aut.\n\nMaiores itaque ipsam rerum molestiae aliquam eum et id veniam. Sint et officiis est non. Ducimus et officia omnis quo doloremque totam. Explicabo numquam quod sunt in. Nobis velit voluptatem ut totam.\n\nHic et et perferendis. Consequuntur deserunt modi. Vel ratione reiciendis voluptas.\n\nDolores quisquam minima ut vel. Perspiciatis sit ex delectus sit est eos consequatur voluptatem. Atque nihil dolorum sint quia autem. Praesentium perspiciatis ipsa voluptatem voluptatem consectetur. Aut quia est id dolores dicta possimus unde.\n\nFacilis optio iusto dolore nostrum vero est. Beatae accusamus quia maiores a accusamus. Ullam praesentium ea laborum vel voluptas iure. Omnis atque beatae hic.\n\nArchitecto ut facere blanditiis officiis quis eos. Minima ut et quam id nisi quae aut accusamus laudantium. Nemo omnis animi hic odio ipsa sit aut. Saepe perferendis voluptates recusandae harum sunt velit natus doloribus. Accusamus nihil dolorum quia natus exercitationem quaerat commodi exercitationem.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") },
                    { new Guid("c30d14b9-3b2e-47ad-8e82-b3461736d8a7"), "Dolorum facere dolor aut autem nihil et quas nesciunt incidunt. Aut maxime voluptas delectus magni dolores quam occaecati voluptatem incidunt. Accusamus illo sit. Non iure magnam iure ut voluptas ratione fugiat earum repellendus. Ea voluptate eum.", null, null, "Example Page 2 - Paragraph 4", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") },
                    { new Guid("cc894565-a630-4c0f-9d92-aa756017f938"), "Laboriosam optio blanditiis rerum culpa dolores ipsa recusandae. Et nostrum voluptatem accusamus ab explicabo dolore. Maiores sunt dolor expedita dignissimos dolorem repellendus. Quasi laborum nobis ut vitae rerum voluptas facere libero et. Voluptas quisquam aut asperiores et. Vitae voluptatem optio unde sapiente ea voluptatum.\n\nSint et debitis. Eaque iste dolor quam. Animi quia necessitatibus necessitatibus. Sint aut maxime quos ipsum repellendus. Qui et laborum. Excepturi sed qui minima perferendis ut.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") },
                    { new Guid("f39aa1f7-e2e2-4883-b343-38c18b9f6f01"), "Praesentium neque dolor ad dolor. Enim id est porro qui dolores quidem. Voluptatem neque et libero in et vel. Impedit provident sunt nobis.\n\nDucimus sequi molestiae praesentium facere sit fuga ab. Commodi voluptas dignissimos magni praesentium est distinctio sed dolore. Non quo ex nulla pariatur praesentium reiciendis omnis illum. Quos dolorem consequatur mollitia accusantium excepturi rerum voluptatibus autem voluptatum.", null, null, "Example Page 2 - Paragraph 2", new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("dbb6d9a5-dfad-45d1-9f2b-23e0f4132028"), false, new Guid("0efc5f14-4878-4d4c-b73b-05b1ea53744f"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 13, 18, 1, 56, 352, DateTimeKind.Local).AddTicks(8075), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("7540ebb9-6ba4-4f01-a866-1270790e8eb1"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("dbb6d9a5-dfad-45d1-9f2b-23e0f4132028") },
                    { new Guid("8cb0c826-9a41-44be-a0d1-08a224aea362"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("dbb6d9a5-dfad-45d1-9f2b-23e0f4132028") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("05e7094d-00ac-4950-9746-b97a42978548"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2cb74917-1d81-4993-b60a-cc1b5728135e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("389bb7d6-8184-4979-8de9-5ca4f804de8a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("40513901-e675-405b-abf1-a69ed7e48f24"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("67cb3f91-be42-43af-83f7-9d812208f0ad"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8ac181e8-69db-40bf-a996-b26f1dc96c2d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a9bdbf20-d22f-42dc-8a0a-0aec28d4c9b4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b93cc55b-0388-4d33-9fce-79f574784acd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0ef56c50-c044-4964-b0fe-fbc4f7d6233a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3d223e62-5cf2-46b5-bbfc-571f4945dc1e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("40835abe-6300-457a-86b1-2bf9b84b6fd3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4a54899b-6ada-4b04-9fdc-1ce737ca3ede"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("636ef31f-6479-4704-9015-dc305220d987"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7540ebb9-6ba4-4f01-a866-1270790e8eb1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("82a6c242-66cd-4e16-bc64-52a7b9baaed0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("84161510-1773-47e8-8f7f-444ab7204028"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8827fcbe-2b1f-4cc4-8bd1-be9545f4a5de"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8cb0c826-9a41-44be-a0d1-08a224aea362"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a6231715-6939-4957-84ea-209800b23e2f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ad6fbf07-94fa-4857-af72-c15843979338"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b587747b-a84d-4152-9fcf-4c01739a4b9e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c30d14b9-3b2e-47ad-8e82-b3461736d8a7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cc894565-a630-4c0f-9d92-aa756017f938"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f39aa1f7-e2e2-4883-b343-38c18b9f6f01"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("10c4d5af-4d8f-412b-b439-e1aa96dc6fc5"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("2821b676-c2e9-45e9-86b2-3cf43d398c34"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("dbb6d9a5-dfad-45d1-9f2b-23e0f4132028"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0efc5f14-4878-4d4c-b73b-05b1ea53744f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("55b10fb9-3dc8-46c7-a4fe-c7f3743fb484"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a194e20-10ec-40bf-8a16-fc8360931391"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("5a1b4514-22c2-4e12-8706-a5734e7f8640"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0645041a-b946-4a96-b4dc-af263ca3a66c"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "ForumTopics");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("064a69c6-c22d-4cc0-987a-2215b912e1b8"), "Concepts" },
                    { new Guid("0a8e5d4b-a99e-4ef5-b84c-ad152ccc74ad"), "Stories" },
                    { new Guid("1a3763ef-66f7-4044-a632-169d762e6956"), "History and Culture" },
                    { new Guid("22be1c9b-a3e9-4dbf-a95c-0381188b4d8f"), "Characters" },
                    { new Guid("3c4a99a7-6b84-4938-90dd-eecbceb03688"), "Technologies" },
                    { new Guid("43f84537-1ce0-4894-859f-16aaca3c5d8d"), "Arts and Entertainment" },
                    { new Guid("5ae63cb9-43ba-4993-b30a-43af10046f16"), "Locations" },
                    { new Guid("6c066abc-a1d5-4072-9dbd-41277e60cbbe"), "Sports and Recreation" },
                    { new Guid("cadc3bc7-58db-4b9a-b6a2-5ec79c9ddad8"), "Events" },
                    { new Guid("d12c441b-81ab-4e79-a218-987284307616"), "Food and Drink" },
                    { new Guid("dbee973e-34f6-47f3-ac07-c1921fe157a3"), "Science and Technology" },
                    { new Guid("e035155b-6da3-4c04-83ec-20224a8af4d9"), "Organizations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7"), new Guid("0a8e5d4b-a99e-4ef5-b84c-ad152ccc74ad"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 41, 11, 208, DateTimeKind.Local).AddTicks(6433), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("9e39a89d-c92e-4ad3-8865-846c91078738"), new Guid("22be1c9b-a3e9-4dbf-a95c-0381188b4d8f"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 41, 11, 208, DateTimeKind.Local).AddTicks(6395), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("f3464d25-401c-4276-a117-399e440f6a74"), false, new Guid("5ae63cb9-43ba-4993-b30a-43af10046f16"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 8, 18, 41, 11, 208, DateTimeKind.Local).AddTicks(6566), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0b6bb608-83d5-4da8-8802-6804e5324b20"), "Porro quis odio modi laboriosam et rem quia et. Cum vero eum est est quibusdam quia neque. Ut iure voluptatem ducimus doloremque sint. Odit officia quia rerum fugit omnis tempore repudiandae.\n\nDolor ipsum rerum blanditiis voluptas modi. Qui ipsam tempore voluptatibus maiores qui. Harum itaque sit praesentium veniam est. Blanditiis animi accusamus nobis aut.\n\nMagni eaque et sunt voluptatibus reprehenderit maiores amet ut. Et consequatur laudantium. Est minima corrupti cupiditate. Amet quas enim et eos voluptatem. Ipsum ad blanditiis sunt fugiat sint.\n\nRepudiandae assumenda et qui non error occaecati. Doloribus quia aperiam dicta doloribus ut facilis sunt cum sit. Corrupti voluptatem fuga neque quia soluta quod delectus. Similique esse ab ea maiores ut repellat.\n\nConsequatur doloribus consequatur autem itaque sunt. A voluptatem quis quidem optio et id possimus nemo esse. Tempora ipsam delectus perspiciatis qui id amet eaque. Animi necessitatibus et omnis quam quod temporibus quam blanditiis. Quia dicta alias amet sit delectus excepturi deserunt.\n\nUt quas et ullam in. Aliquam dolorum sapiente molestias. Esse velit dolorem sequi dolore.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("0fad8d66-8e8d-4fd3-86b4-3fd70b69f195"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("f3464d25-401c-4276-a117-399e440f6a74") },
                    { new Guid("1350da13-da00-49a9-a96f-9f6376a1ca79"), "Sit eum corporis. Quis vel quae sit laudantium incidunt recusandae et voluptate illo. Et unde veritatis quidem. Consequuntur placeat enim ab dolorem.\n\nIllo eos ab nobis pariatur. Error corporis itaque odio sed quia voluptas asperiores perferendis. Quia quis maxime cum non sint dicta. Consequuntur sed ad et facere non vero. Quasi tempora voluptatem autem vel recusandae dicta.\n\nNam recusandae sequi consequatur doloremque amet consequatur voluptate. Autem eveniet quas labore exercitationem quo blanditiis et illo. Vel praesentium deserunt minus eligendi. Optio praesentium nesciunt est officiis. Fuga similique soluta maiores ad exercitationem.\n\nEos voluptas quis voluptatem voluptatem. Eveniet porro aut rerum. Amet esse et commodi numquam aut nihil id.\n\nMaxime nulla aut repellendus. Illum autem impedit ea quidem laboriosam animi. Quasi facere corporis pariatur aut voluptatem.\n\nRatione accusantium exercitationem dolorem. Nam rerum quisquam amet id. Tenetur sint dolore vel voluptatum maxime repellat.\n\nDoloribus tempore quas voluptates consequatur enim voluptas perspiciatis dignissimos commodi. Corporis amet aut. Qui perspiciatis cupiditate voluptatem veniam aut est sequi ut. Et libero eos. Ipsam maiores fuga cumque deserunt.\n\nReiciendis error ab id ad sed vitae officia consequatur nihil. Ut laborum veritatis quos nobis animi. Dolores nostrum veniam vel. Illum quasi dicta dolores ad. Recusandae nihil sit accusamus veritatis. Voluptate ratione ut repudiandae quod voluptatibus voluptatum quia sint saepe.\n\nSed repellendus placeat perspiciatis temporibus. Dicta vero nostrum voluptatem culpa tempora est a neque. Sapiente cum exercitationem qui. Dolores eum qui dolor. Qui repellat et autem.", null, null, "Example Page 1 - Paragraph 3", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") },
                    { new Guid("20186a32-3bd6-4b45-ae78-fef552569cf3"), "Accusantium ex accusamus ab ex corrupti dolorum qui. Consequuntur incidunt ut veniam fuga non voluptates eum eum. Exercitationem officia harum eius laboriosam modi sit. Sint fuga temporibus in corrupti nam sunt saepe occaecati. Et non maxime omnis at.\n\nDelectus sequi sint. Dicta enim et et enim ea qui dolores ad consequatur. Dolores asperiores possimus. Molestiae praesentium non vitae sit amet voluptas.\n\nUt voluptatem corporis maiores. Repudiandae nihil at ut esse officiis. Et nulla sunt praesentium est quia deserunt.\n\nEx iste odit ullam qui nobis neque. Tempore voluptas non ea qui nobis. Ad mollitia dignissimos animi voluptas corrupti voluptates quod molestiae sed. Occaecati est pariatur earum esse. Quam facilis ut optio deleniti inventore iusto earum iste delectus.\n\nDignissimos et laborum laudantium omnis qui. Molestiae perferendis voluptas et hic. Inventore et reiciendis soluta perspiciatis.", null, null, "Example Page 1 - Paragraph 5", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") },
                    { new Guid("2bfddf9f-36fb-4e85-b29c-098f63b7559d"), "Rerum ut dolor dolore excepturi et quia quisquam in. Voluptatibus id qui alias aut ut et sunt. Nemo et perferendis omnis sequi.\n\nVoluptate voluptas asperiores est praesentium. Cum pariatur accusamus. Quidem impedit voluptas similique ut nam eum quis cupiditate consequatur.", null, null, "Example Page 2 - Paragraph 5", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("4adcca50-7dd6-453c-967d-5053c52869e9"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("f3464d25-401c-4276-a117-399e440f6a74") },
                    { new Guid("59012168-a717-427b-aa4c-1ad876e6cc2f"), "Praesentium eos eius et ut. Nihil ut autem voluptatem et aut deleniti est. Sed sit ut est laboriosam ut. Vero culpa veritatis perspiciatis doloremque totam. Cupiditate accusamus rerum architecto voluptas esse. Aut aut sunt laudantium voluptatem.\n\nExplicabo omnis esse sunt et illo vero consequatur. Autem et et ut iste itaque nemo. Veniam eius quo vero corporis quidem voluptas. Maiores autem rerum laborum ducimus nihil esse recusandae assumenda. Voluptates officiis illo.\n\nPossimus id iste pariatur ipsum sint vero. Et eum et repudiandae provident tempore explicabo inventore quia. Distinctio id facere ut. Ut alias excepturi magni.\n\nVoluptatem qui est dolores omnis voluptas voluptates voluptas consequuntur quasi. Cupiditate laboriosam nesciunt laudantium delectus. Iusto ut optio a ea itaque delectus ut et. Consequatur voluptatem ea tempora. Asperiores nemo voluptatem qui enim.\n\nMagnam similique rem aperiam perferendis eum blanditiis est. Laboriosam quisquam et ad excepturi sed reiciendis. Praesentium quasi et et. Possimus ipsam similique eaque. Enim ut totam sit amet.\n\nNulla repellat voluptas et. Sed fugiat eos voluptate. Numquam provident et mollitia. Aut blanditiis veniam accusantium ipsam asperiores.", null, null, "Example Page 2 - Paragraph 3", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("5910cdef-a239-4533-88d0-59658ea3e0e0"), "Distinctio dolor non perspiciatis quaerat eligendi. Ab commodi quia suscipit. Illum alias aut ullam officia sed et libero quidem quia. Numquam ipsum non vel sapiente animi ullam voluptate sint.", null, null, "Example Page 2 - Paragraph 4", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("711cd56d-0117-4686-88f6-927708e32797"), "Maiores quaerat reiciendis error error. Illo qui autem. Delectus in illo. Voluptatem ipsum quidem itaque qui eum. Earum ut sint soluta delectus eum aut occaecati dolorem ut.\n\nAtque eum non quos et dolore velit aut. Quos eum ullam. Tempore in praesentium fugiat nostrum. Assumenda autem qui. Consequatur et eos occaecati numquam est dolores dolore excepturi.\n\nAut quo qui ut veniam labore. Nam laudantium quia magnam. Eligendi recusandae quia.\n\nIn libero pariatur repellendus ut ut et. Ullam dolor voluptas illo sint et. Ea id quae. Omnis saepe repellat dolores ut consequatur.\n\nQuia culpa dolorum quae omnis quos laborum quae consequatur fugiat. Earum dolor iusto atque quas ea vel distinctio. Officiis fugit expedita praesentium suscipit repellendus molestiae non odit. Labore quasi consequatur aut sed.\n\nExcepturi debitis saepe doloribus aspernatur. Ut enim voluptatem. Repellendus sunt aperiam nesciunt blanditiis vel expedita et nesciunt dolorem.\n\nEnim et vero aut aut odit illum necessitatibus. Libero placeat eos et. Consequatur neque aliquid voluptates sequi enim dolore voluptatum. Dolor qui voluptas quaerat ut velit reprehenderit. Distinctio autem nostrum accusantium voluptatem maxime.", null, null, "Example Page 2 - Paragraph 6", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("99ad0bde-c8dc-4181-9946-095c504488b7"), "Mollitia cumque aut et. Fugiat quia sunt et ut recusandae alias et esse minus. Enim suscipit perspiciatis error eaque. Consequatur voluptatum praesentium cupiditate doloremque fuga quia. Amet incidunt veniam totam recusandae laboriosam amet eligendi. Quisquam a culpa alias provident quasi debitis tempore quisquam.\n\nSunt eos vitae maiores sapiente rem nulla. Veniam magnam aut laboriosam labore rerum quisquam. Qui est eum eligendi eum tempore. Doloribus eum vel porro fugit.\n\nOdit repudiandae magnam eveniet magni adipisci explicabo ea officia eum. Voluptas illo eum enim aut quae optio et. Aliquid modi assumenda et quia culpa. At architecto nemo in distinctio sunt laudantium soluta excepturi aut.", null, null, "Example Page 1 - Paragraph 4", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") },
                    { new Guid("ec6c11f3-81e4-4f04-a596-2332c5fa71e0"), "Voluptatum consequatur quo corrupti expedita officia. Quidem in rerum eveniet totam. Maiores nisi dolor enim mollitia consequatur ipsa ratione ut.\n\nDolor voluptates harum. Rerum deleniti assumenda. Qui debitis voluptas quas sed nihil dicta et voluptatibus. Ullam dolore et molestiae illum optio. Sapiente aspernatur qui id dolorum ut. Velit distinctio impedit possimus eius.\n\nEt eum et praesentium. Cupiditate quidem sit qui. Occaecati et et doloribus sunt dolor voluptas. Repellendus dolorem accusamus perferendis. Sint mollitia odit occaecati. Amet est officia et dicta consequatur aut non eligendi odio.\n\nAperiam ut sint maxime dolores. Est rerum qui necessitatibus in. Exercitationem libero deleniti qui veniam cupiditate aliquid quod ipsam molestiae. Velit incidunt nisi distinctio quaerat ad voluptate. Aut qui qui non voluptatem nobis quasi mollitia quia. Facilis ut et in et consequatur aut facilis.", null, null, "Example Page 2 - Paragraph 2", new Guid("2b4d5ab5-1777-4e81-8d0e-99ba726cd9b7") },
                    { new Guid("ed004a11-61c8-4971-a113-4397b04303df"), "Quod et vel vel quia porro. Vel non alias cumque est dolorem a. Ut labore itaque enim beatae. Provident quam quia voluptatum aut alias velit.\n\nUt ut ratione. Dolores mollitia dolores sed doloremque. Tempore quam accusamus et dolores.\n\nVoluptatem provident omnis recusandae. Dolorem voluptas voluptates quo. Autem minima aut quaerat mollitia repellendus tempora expedita. Ut rerum rerum voluptatibus eos magnam assumenda eum repudiandae. Suscipit quidem doloremque velit ex.\n\nEt optio nihil et natus aut tempore. Reprehenderit ex provident. Quis ratione perspiciatis natus accusantium quaerat.\n\nQui ut est neque id iure deserunt. Recusandae eum enim beatae nemo cupiditate consequatur unde. Aspernatur explicabo est consequuntur facilis quas molestiae debitis. Sunt harum molestias reprehenderit. Mollitia molestiae numquam qui sunt.\n\nVelit rem ipsum veritatis nihil voluptas tempora rem placeat. Repellat quia earum incidunt eveniet sit. Sed molestiae ea et. Corporis ducimus dolores voluptas quas amet. Eum asperiores enim culpa. Corporis quaerat ut.", null, null, "Example Page 1 - Paragraph 2", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") },
                    { new Guid("f1ccdf42-89bd-4714-b8d7-ef4e1913653c"), "Recusandae ut esse rerum voluptas et et ipsam voluptate qui. At sit exercitationem. Quia qui ut incidunt velit qui. Consequatur ipsum hic sapiente. Sed placeat id odio vitae nesciunt.\n\nVoluptatem provident earum et amet fugiat. Eum laborum dolores aut et dignissimos animi illo. Nisi illum voluptatem voluptas aut ullam. Similique maiores adipisci soluta quas esse numquam qui qui.\n\nItaque voluptatum dolorem qui neque molestiae. Laborum recusandae qui omnis et necessitatibus similique est. Sapiente amet ut dolores repellat.\n\nRepellendus neque consequuntur aspernatur excepturi sed eos similique cum. Ut voluptas eveniet ipsam. Dolor molestiae corporis molestiae. Voluptas fugiat nam delectus debitis. Est eum hic. Autem aut autem et.\n\nAut cum aliquid incidunt et ea. Veniam dolorem reiciendis. Architecto est quidem culpa voluptas soluta odio quas dolor vel. Magnam facilis nisi neque similique cumque iusto. Qui et hic autem aut.\n\nEsse quia voluptatem. Accusantium iste blanditiis enim consequatur tenetur. Quasi quis perspiciatis modi. Soluta non voluptatem consequatur veniam ex est non.\n\nMolestiae ipsum cum optio. Voluptates et corrupti excepturi ab omnis molestiae. Nemo optio aut nemo consequatur. Et qui beatae impedit sint voluptatem quis dignissimos. Voluptas sit distinctio labore sed qui rerum.\n\nEt mollitia nisi aut exercitationem. Natus et consequatur ab consectetur aut. Aut minus corrupti culpa aliquam vel a aut repudiandae.\n\nExplicabo voluptas corrupti reprehenderit incidunt. Blanditiis provident sed aut alias id illo voluptas. Maxime laboriosam voluptatem libero. Voluptate in assumenda nam sit expedita est.\n\nSed excepturi laudantium odit quia cumque necessitatibus ipsam quaerat. Nulla dicta qui enim doloribus aut ab et. Omnis impedit blanditiis alias atque sint velit harum minima.", null, null, "Example Page 1 - Paragraph 6", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") },
                    { new Guid("faecb3d9-254d-4b50-912a-83120af7b634"), "Quis voluptas modi eos sed fugiat. Saepe minima minus est enim non cum id odio quia. Culpa assumenda dignissimos qui enim et. Rerum repudiandae tempore neque tempore suscipit atque id dolorum. Debitis ab cumque nostrum. Est earum ea.\n\nEsse magnam reiciendis iure officia. Et error in hic consequuntur similique aut aut autem. Facere non explicabo sit omnis ducimus ut. Sed dolores blanditiis omnis sit culpa libero. Voluptas nobis consequatur eligendi et et accusantium harum rerum velit. Numquam tenetur officia quia.\n\nSoluta autem necessitatibus placeat a. Et officiis sed soluta itaque occaecati. Ab quae non rerum.\n\nQuas iusto cum nisi eos. Laudantium ipsam minus sunt qui libero consequatur. Placeat odit sed explicabo eveniet id provident. Laborum praesentium totam aut ut.\n\nQuasi hic velit soluta et quae est. Quisquam iusto nulla reiciendis saepe distinctio iste suscipit. Et eveniet ad sint nam accusantium. Rem nihil illum sed illo non porro sint. Ut nesciunt ullam natus delectus aspernatur. Corporis illo iusto voluptatum numquam.\n\nDistinctio et fuga quod voluptatibus placeat repudiandae. In id harum eum molestias molestias deleniti. Nostrum ratione rerum laborum delectus quod vel deserunt rerum molestias. Commodi qui quae saepe quia reprehenderit atque et provident cum. Velit neque eveniet error dignissimos. Laudantium nobis quod maiores qui saepe qui doloremque odit.\n\nPerspiciatis repudiandae eligendi vel itaque placeat esse alias voluptatem et. Laborum fuga eum consequatur tempore et laborum impedit. Ratione laudantium nisi est sequi inventore magnam necessitatibus qui. Nam et ea fugit sit impedit.\n\nQuo sapiente aspernatur beatae. Culpa occaecati at nihil quo. Eveniet esse doloremque id id quia. Ratione asperiores quibusdam alias quis dolores rerum similique culpa dolores.\n\nQui magni fugit dolore officiis. Qui fugit sit ipsam rerum enim. Id distinctio facere molestiae sint error minus. Optio placeat unde est commodi similique numquam fugiat voluptatem dolores. Aliquam aliquid nobis dolorem ipsa harum odit illo fugit. Incidunt quia ullam omnis harum doloremque corporis repellat unde ex.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("6429a241-f6f5-4964-b4c1-a32a7d176f6b"), false, new Guid("cadc3bc7-58db-4b9a-b6a2-5ec79c9ddad8"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 8, 18, 41, 11, 208, DateTimeKind.Local).AddTicks(6570), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("9e39a89d-c92e-4ad3-8865-846c91078738") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("2224f60d-554c-4ea0-98c9-168998737c3a"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("6429a241-f6f5-4964-b4c1-a32a7d176f6b") },
                    { new Guid("2c768fae-72ed-42be-b063-e6f5793eece6"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("6429a241-f6f5-4964-b4c1-a32a7d176f6b") }
                });
        }
    }
}
