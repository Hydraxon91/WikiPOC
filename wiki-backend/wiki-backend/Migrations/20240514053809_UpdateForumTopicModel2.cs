using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumTopicModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47477724-2ec2-4ac2-b9bd-70b4e656df66"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4d1ee620-249a-4629-99a2-cb9ef0a80ca2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("59b9b220-9b41-40ef-8ae0-a384224d29d3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d129891-4f62-4a43-90e2-e8007dea5d63"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bdb0d5a7-7668-4724-9fe5-6179e411024a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0ea92af-4611-4f8e-9b7f-2a1de45c984c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d3fec8c7-997a-4f4e-80e9-f56c38bbac3b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e904a4db-a725-48eb-9167-e44fb6377a78"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("15cda6a3-d675-4a73-8127-11dfd852049b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("200596f9-3ff7-4739-88c5-e596425ca55a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3a7e9904-00dc-4780-b474-b30837cda84e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5015fc6c-0f6f-4df5-b2a9-e89cebfcb629"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("57cc0c5c-8ca6-4eab-bc7c-db1e44f5875b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("631d45d7-9883-411f-921a-cfc303eaa4f7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6e7f3340-b4e0-478a-b992-903b906662c3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8268259d-f713-41fd-89dc-e529d248c5d1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("848d1696-cdac-4d61-829c-10bb347c5646"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8acf9f90-a137-43ee-9db6-3d111857163e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a95a437a-cf58-4b12-a264-263217a370d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("dd7bc6dd-2cf2-4b9e-980b-8b3e8f041dec"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e05b41c5-50d4-44c8-a7cd-0da5699c142b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f43af813-b1fe-40aa-b8e8-d4721c32eaca"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fba5cecb-201e-4c2d-a36a-1953a47ad96f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fe760cd7-631c-4794-9463-f750315525ba"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1b9ec1da-131d-4319-88da-4d518c5731c4"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3f0df0db-53ef-4987-8f52-7da3cc7efc99"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("483bafb0-6a8a-46e1-814c-de81b4ad9e3a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7c74d058-b536-4b1d-aae9-0db322f74bd3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d67918b2-9737-4293-8e54-35f3d8d50ce3"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ebc9b078-1a2c-43ce-ac31-0c73a68b15e9"));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "ForumTopics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("01eb0061-015e-439f-bf89-18f51527afeb"), "Locations" },
                    { new Guid("095f39f2-c260-4636-92b8-ee52825054a8"), "Technologies" },
                    { new Guid("0b711e6c-dfc7-499a-9337-b691b59a6304"), "Sports and Recreation" },
                    { new Guid("104a8c3c-1de1-45d3-9046-314d359a69ba"), "Food and Drink" },
                    { new Guid("112ca28d-ab27-423a-b9b9-eb8b29f7441f"), "History and Culture" },
                    { new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"), "Characters" },
                    { new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"), "Stories" },
                    { new Guid("5cf70538-8516-4bd6-88ba-003786293ecf"), "Organizations" },
                    { new Guid("6f5741e9-6b6f-4e86-96fa-8666a96b1513"), "Science and Technology" },
                    { new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"), "Events" },
                    { new Guid("9c03ae43-36c3-447f-851d-28183910429b"), "Concepts" },
                    { new Guid("b741c637-e822-4457-9560-dc8740c10af3"), "Arts and Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("503b4921-68af-404d-bc41-9cd87c24892a"), new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9800), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655"), new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9757), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0"), false, new Guid("01eb0061-015e-439f-bf89-18f51527afeb"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9933), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0e03a79f-1d19-4690-b808-4375df2a6487"), "Ducimus facilis itaque rerum. Sed omnis laboriosam. Sapiente necessitatibus quis odio harum dolores maiores sapiente. Numquam aut aut vel voluptatem nobis. Est a necessitatibus harum at consectetur dicta incidunt excepturi.\n\nSed et sit molestiae quia inventore veniam. Dolor illo quaerat sunt quia repellendus. Nesciunt ducimus perspiciatis. Corporis impedit rerum dolores pariatur ratione exercitationem iste qui deleniti.\n\nEt pariatur tenetur deleniti. Sed quidem nam voluptates est id dignissimos. Voluptatibus ipsam nulla ratione veniam sequi dignissimos ut a dolores. Voluptatem aut fugiat dolores vel delectus modi fugiat quos.\n\nEt omnis consectetur sint dolores necessitatibus. Reprehenderit quidem rerum enim nisi. Laudantium dolorem rem ut. Aperiam in deserunt maiores error et facere vitae. Est maiores facilis et quae autem inventore atque.\n\nEnim nobis sit eius. Rerum necessitatibus qui aut non omnis esse aut. Error consequatur voluptatem magnam quia. Accusamus consequuntur odit voluptatem et. Iusto voluptas et sit consequuntur aliquam voluptatem.\n\nConsectetur libero in ut. Repellat enim autem rerum assumenda. Est omnis est quasi iste ipsam esse. Ab odit ex nostrum aliquid. Delectus dolorem reiciendis rerum ut.\n\nSit eos suscipit vel eum voluptatibus. Non vero itaque non animi. Numquam facilis enim non et aut quo. Totam accusamus hic enim enim quis velit sunt. Impedit quod impedit quasi eos eos.\n\nEt et vitae sequi ut repudiandae. Quis odio adipisci. Repellendus ut impedit voluptas veritatis aut consequatur porro cupiditate. Laborum perferendis culpa. Eos id et dolorum sunt aut repellat veritatis.\n\nUt repellendus voluptatum culpa. Et corporis quo in praesentium. Sequi et saepe magni error eos. Suscipit officia libero numquam expedita ut modi. Quia nobis sed.\n\nFacere quis expedita nemo et iure recusandae similique quia. Et voluptatem distinctio dolores sunt eligendi est quis quas error. Aut velit dolorem quam. Voluptatibus possimus aut magni et ipsa nihil. Quis beatae est nihil illum debitis ducimus rem numquam.", null, null, "Example Page 2 - Paragraph 4", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("1ee0275f-783b-4f30-a392-9587d0fb4f4c"), "Neque qui et quia quibusdam adipisci nulla. Est nam illo libero ipsam nostrum ea in aut libero. Quam error est deserunt perferendis vel aut exercitationem totam.\n\nAmet commodi itaque accusamus voluptas. Magni ea ratione dolor. Illo sapiente consequatur velit. Vitae esse placeat in excepturi quidem voluptate.\n\nUt saepe sed omnis voluptatum. Reiciendis consequatur reiciendis explicabo suscipit ipsa. Quod aut vel qui corporis blanditiis. Vel consequatur omnis quam.\n\nOccaecati illo consequatur quo. Dolores numquam omnis officia possimus quaerat reprehenderit ab officia. Minima ipsam laborum quibusdam perferendis. Quia ad et quo expedita omnis culpa fugiat. Laudantium blanditiis in architecto expedita recusandae exercitationem deleniti sed. Dolores perspiciatis qui vitae ipsam ut sunt et.\n\nVoluptatibus ullam sunt laudantium qui tempore aspernatur quia eos dolorem. Sed inventore voluptatem enim consequatur enim porro facilis. Tempore eligendi reiciendis delectus fugiat praesentium totam. Laudantium perferendis nemo deleniti eos animi sapiente. Modi exercitationem quisquam odit in nihil ipsa iure eum fugit.\n\nAmet incidunt tempore at tempore fugit quaerat doloremque illo voluptatem. Sed blanditiis aspernatur. Corrupti omnis et voluptatibus sed eos. Tenetur nostrum repellat odio. Sed tenetur nihil rerum sit. Quaerat et eos possimus.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("5455545c-5560-4bd0-a17c-df90fd631e4f"), "Beatae quisquam maiores ut quis sapiente temporibus sunt velit. Ut aperiam consectetur quos. Dolorum perferendis alias alias et mollitia quod. Harum accusantium veniam aut et esse accusamus vel sunt dicta. Rem et molestiae quae esse accusantium.\n\nUllam et labore quam minus. Ea quia quis alias quia est. Quo minima nostrum ut et et dolore voluptate.\n\nIn voluptas excepturi eligendi similique molestias. Et officiis ea sint. Iste dolor dolorum nam dolor iure officia.\n\nInventore mollitia autem quaerat in dolores doloremque illo ipsum. Ad exercitationem officiis eius sapiente. Velit voluptate voluptatibus illo inventore dolor. Assumenda cumque modi iste corporis quis occaecati tempora. Excepturi voluptatem sed blanditiis corporis minima.\n\nLibero corporis maiores recusandae nisi sed commodi qui. Sit consequuntur veniam est fugit libero et explicabo dicta ut. Illum et reprehenderit quae eius.\n\nDolore ipsum voluptatem porro assumenda mollitia repellendus. Repudiandae quia nobis perferendis. Iusto dolorem magnam id beatae maxime velit nemo est. Vero excepturi et optio aut. Ex sit repellat harum quia temporibus. Voluptas voluptas sint.", null, null, "Example Page 2 - Paragraph 2", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("5d3bc25e-7b73-499b-b0e8-4535879e3973"), "Laborum voluptates labore saepe. Dolor nihil eaque. Eveniet molestiae quis quas consequatur voluptatem laborum tempore.\n\nId facere voluptates ullam error eum esse. Est ut aut ducimus soluta id similique est. Quis praesentium nulla aliquid ipsum aperiam.\n\nVelit sint ad perferendis dolorum et provident hic. Tempore nobis cupiditate non minus ipsum quia accusamus in voluptatem. Veritatis corporis quia illo culpa cupiditate aut eligendi deserunt. Est non animi. Qui exercitationem eius voluptatem facilis.\n\nMinima consequatur nisi. Accusamus et aut et non. Dolores dolores aliquid omnis ut.\n\nSed iste earum odit ab qui officiis error. Error in qui dolorum eos qui explicabo et eveniet dolore. Dolor consequatur numquam dolor.\n\nEt autem omnis eos iusto eaque. Dignissimos perferendis hic atque temporibus nihil maiores. Iste voluptatem cupiditate consequatur quibusdam praesentium aut culpa dolores aut.\n\nError cumque aut. Cupiditate et et fugiat quis. Explicabo ut dolor nemo ullam maxime et est. Accusantium sapiente et. Facere excepturi aut ut sequi ad autem facilis sint.", null, null, "Example Page 1 - Paragraph 4", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("642a5509-4d6f-472b-b449-6239850fa718"), "Doloremque tempora sunt delectus. Est sed et non. Quas ex vitae voluptatem. Dolore officia est perspiciatis porro. Maxime omnis fuga facere qui illo.\n\nMolestias esse nulla ea est quo accusantium autem deserunt. Saepe ad officia voluptas doloremque alias. Odio voluptas nostrum delectus. Eum ratione quos explicabo et. Sint voluptatem dolorem beatae magni magnam pariatur sapiente.\n\nOdio magnam iusto omnis mollitia enim. Aut exercitationem ullam odio consequatur. Natus doloribus veniam illum qui cupiditate qui. Nihil ratione quibusdam maiores tempore excepturi cupiditate. Reiciendis dolorem fugiat possimus quidem eos provident. Rem aut sit et non rem quaerat quasi tempora rerum.\n\nEnim voluptas amet quae deserunt ea aspernatur repudiandae voluptatem est. Et esse fugit tempore rerum et ut. Nulla excepturi voluptas iste sunt aut error impedit. Illo voluptas maiores. Incidunt veritatis quibusdam in.\n\nIure repudiandae deleniti itaque sequi quisquam. Sit vel laudantium ut repellendus magni ipsam non. Sit tempora expedita.", null, null, "Example Page 2 - Paragraph 6", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("69817e7b-db78-4f18-86a5-26bb6c7d3bdf"), "Molestiae assumenda saepe repudiandae veniam consequatur. Quasi amet doloremque dolorum. Quia pariatur dicta asperiores temporibus.\n\nDucimus voluptate ut. Doloremque aut deleniti tempore in cumque. Rem quibusdam recusandae dolor nam.\n\nVoluptatem doloribus veritatis voluptatem eligendi nobis deleniti qui sunt delectus. Voluptate unde quam eaque est sunt ipsa quo. Illum dolor quis ducimus modi id.", null, null, "Example Page 2 - Paragraph 5", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("6982ef85-c11e-4e3f-b8e3-53a49c0bb266"), "Molestias omnis voluptatem provident fugit dolor. Eum non qui earum pariatur maxime. Sit ipsa numquam iure ipsa nam. Nisi harum ut a temporibus eaque commodi.\n\nDicta ut quae. Sit nihil laudantium hic asperiores in. Omnis incidunt et occaecati perferendis consequatur ipsum. Velit deserunt eveniet aliquid eos sunt unde explicabo.\n\nNisi sunt sed sint quos nulla quis consequatur repellat. Quidem dicta quia. Et ratione et officiis voluptate consequatur velit. Aut minima qui sapiente.\n\nSit neque sed autem in. Iste nihil voluptatem repellat consequatur est provident impedit nemo. Aliquam rerum labore ad blanditiis. Et eius nobis aut aut et et.\n\nQuisquam ducimus repudiandae molestiae suscipit. Dolore molestias aspernatur non. Mollitia et id aut quod voluptate quia. Eveniet et facilis.\n\nOmnis omnis placeat quasi earum quis. Est numquam tenetur omnis in. Expedita qui occaecati nemo quia autem at qui aut.\n\nMagni suscipit porro non ab sed. Eos impedit quisquam qui culpa rerum incidunt voluptatem. Placeat provident ut non esse nostrum perspiciatis labore delectus rem. Neque expedita nulla eaque dolores. Consequatur architecto quia maiores.", null, null, "Example Page 1 - Paragraph 2", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("92c80242-b379-426d-b0c1-00ba71826803"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0") },
                    { new Guid("9d0aef9a-e1f2-4197-a06a-a6b23d85fccd"), "Aut possimus rerum non minus. Expedita repudiandae aut. Hic id recusandae soluta id. Ut omnis aut harum et et nesciunt sapiente.\n\nVelit vel voluptatem ea rem inventore nostrum earum. Voluptates nostrum voluptatibus odio dicta iure quas hic sapiente. Perferendis blanditiis ratione saepe expedita et dolores.", null, null, "Example Page 1 - Paragraph 3", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("b3cf4572-0105-4700-bdf1-489d935fc3d2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0") },
                    { new Guid("c5905114-ba5b-4a91-be54-e5dbbfcd8438"), "Accusamus voluptate facere dolorem molestias quisquam aliquam sint. Voluptatibus qui quod omnis. Nihil dolores voluptatem libero aliquid unde laudantium eos. Consequatur molestiae et eius iusto natus nesciunt. Vel unde facere. Nulla eveniet commodi voluptatem rerum nobis sint.\n\nQui possimus sit voluptates eum. Alias voluptates ullam cupiditate sit beatae veniam rerum quis. Explicabo amet ratione et illum accusantium expedita aut.\n\nEt sit quam voluptates quasi possimus. Cumque et quas incidunt. Molestias nihil incidunt. Qui nobis neque nulla et quis eaque odit assumenda. Animi sit ut modi.\n\nCommodi dolorum similique eveniet aliquid ipsam quia qui. Dicta quisquam voluptatem odit ad eligendi dolor et. Consequatur quaerat et est praesentium autem et ut eligendi optio.\n\nVel voluptas harum. Voluptas ipsa quo. Impedit et enim amet illo atque consequatur. Earum repellat numquam unde nesciunt.\n\nVelit velit debitis est tempora atque. Facilis iste nemo necessitatibus sunt accusantium voluptatem. Repellendus dignissimos est iusto est laborum quos repellat ex voluptatem.\n\nArchitecto eveniet sed nesciunt repudiandae nemo vel dolore quia. Molestiae quis vitae ullam eaque reprehenderit est. Sit rerum molestias qui velit fuga magni fugit odio. Quae recusandae sequi. Enim molestias tempore impedit expedita consequatur consectetur deleniti harum illo. Dolore adipisci sit reprehenderit.\n\nRatione ex commodi et quia eaque magni. Numquam maiores exercitationem porro nemo nulla alias totam sit velit. Necessitatibus rem et distinctio ipsam. Hic molestiae sed.", null, null, "Example Page 1 - Paragraph 5", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("c5e70262-4b09-46bf-b2b3-3dba5d6d0ef0"), "Sapiente tenetur voluptates in in qui animi nemo aut. Ratione accusantium cum ex. Ipsum assumenda dolorem deserunt quaerat nesciunt rerum. Nobis pariatur eligendi hic officiis vel. Vel numquam animi et eos at quaerat.\n\nHarum voluptas et rerum. Ipsum fugiat dolor quo voluptas enim temporibus. Et impedit facere neque blanditiis commodi natus. Impedit molestias et.\n\nProvident aut aliquam nesciunt tempora aliquam sed. Repudiandae inventore placeat sit excepturi ut porro. Non eaque ipsum.\n\nQui velit aliquam at. Nisi officia numquam. Nobis sit qui similique ab vitae autem nihil. Deleniti quam occaecati repellat recusandae asperiores delectus qui omnis facere. Tempore doloribus sint illum consequatur beatae magni voluptas reprehenderit. Incidunt animi pariatur aspernatur.\n\nMolestias neque porro maiores eveniet et nemo ea. Natus dolorum enim qui eos nostrum. Ea unde tenetur magni molestiae minima et nostrum reprehenderit sed. Maxime temporibus molestias.\n\nQuo sint fugit ad soluta porro illo voluptatibus maiores. Cupiditate molestiae ab. Odit non officiis.", null, null, "Example Page 1 - Paragraph 6", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("c8c5ad13-44cc-4125-8541-0191168384f8"), "Earum exercitationem deserunt. Laudantium dolor autem voluptatem natus. Omnis facilis reiciendis temporibus eius sed ipsum sint sunt explicabo. Id aut voluptatem ut ea. Magni quaerat eligendi voluptatibus ut autem veritatis iste. Recusandae assumenda porro iusto quos enim maxime qui.\n\nAutem maxime odit est ut ut. Assumenda vero ea voluptas quia earum nobis. Veniam voluptatem doloribus. Aut non vel rerum eum ut. Dolorem tempore tempore voluptatum.\n\nModi qui sit rem et et rem quis consequatur. Facilis aperiam et numquam quo inventore aut atque. Labore delectus maiores accusamus voluptatem aut et rerum nam. Repudiandae cumque amet vel est error et. Dicta blanditiis eaque soluta numquam.\n\nSit aut nisi. Aut molestiae suscipit dolorum ex quia unde. Voluptates dignissimos culpa dicta est consequatur perspiciatis nisi. Temporibus nostrum facilis qui doloribus pariatur esse sint ullam. Necessitatibus vel at.\n\nEarum quo nulla et sed earum vel distinctio fuga. Dolor aut incidunt. Dicta magni in provident corporis velit. Beatae occaecati modi fuga blanditiis explicabo quia ab officia ratione. Qui sint perferendis odio saepe. Nihil voluptas exercitationem dolores quam rerum labore.\n\nAssumenda quis repudiandae fugiat consectetur consequuntur natus labore ipsum. Dolor qui eos veritatis harum. Ullam facilis illo omnis nobis ut recusandae quia culpa. Cupiditate est earum voluptas consectetur repellendus ipsam et. Incidunt quo aperiam et. Illum voluptatem maxime tempora et eum.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("ff93d442-a4f7-408b-836a-f32aac08c8f3"), "Aut nostrum reiciendis eaque deleniti temporibus voluptate officia doloribus aperiam. Id voluptas ut perferendis sed. Enim velit fuga ut ut aut enim omnis alias animi. Blanditiis ipsam ea consequatur. Consequatur nihil quasi quo sed. Soluta eveniet nobis velit explicabo.\n\nTempore et rerum. Dolorem libero molestiae quis est qui nam doloribus. Ut necessitatibus dolorem. Asperiores excepturi quam voluptatem beatae aut aut excepturi et. Veritatis illum amet magni aut sit qui nulla dolorem maiores.\n\nQui expedita assumenda distinctio quia. Nemo omnis voluptatibus voluptate consequuntur cumque temporibus. Deserunt vero dolor quisquam sed. A quia iure ut rerum quo eaque tempore sit debitis. Incidunt quia molestiae quam.\n\nAnimi eius accusantium. Pariatur aperiam libero quisquam autem sit illo velit doloremque. Quod eligendi animi esse consequatur in ad aut voluptas.\n\nMinima est atque rerum pariatur provident pariatur et nulla. Quod sunt voluptas iusto. Ex sed blanditiis quo qui beatae accusamus et.\n\nRecusandae provident est iusto. Alias voluptas adipisci veniam ipsa nemo iusto eum a. Et qui possimus incidunt numquam nulla. Aliquam nam reprehenderit quo perspiciatis voluptatem molestiae. Consectetur officia explicabo ab quia tempora voluptatibus ullam. In sit qui recusandae ratione itaque aliquam ea minima.", null, null, "Example Page 2 - Paragraph 3", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e"), false, new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9938), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("a30a1f07-98d6-4709-8ff4-5c92657aaafb"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e") },
                    { new Guid("d580eec7-26e3-48ca-bdef-5141cf4766e4"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("095f39f2-c260-4636-92b8-ee52825054a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b711e6c-dfc7-499a-9337-b691b59a6304"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("104a8c3c-1de1-45d3-9046-314d359a69ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("112ca28d-ab27-423a-b9b9-eb8b29f7441f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cf70538-8516-4bd6-88ba-003786293ecf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f5741e9-6b6f-4e86-96fa-8666a96b1513"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9c03ae43-36c3-447f-851d-28183910429b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b741c637-e822-4457-9560-dc8740c10af3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0e03a79f-1d19-4690-b808-4375df2a6487"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1ee0275f-783b-4f30-a392-9587d0fb4f4c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5455545c-5560-4bd0-a17c-df90fd631e4f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5d3bc25e-7b73-499b-b0e8-4535879e3973"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("642a5509-4d6f-472b-b449-6239850fa718"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("69817e7b-db78-4f18-86a5-26bb6c7d3bdf"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6982ef85-c11e-4e3f-b8e3-53a49c0bb266"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("92c80242-b379-426d-b0c1-00ba71826803"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9d0aef9a-e1f2-4197-a06a-a6b23d85fccd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a30a1f07-98d6-4709-8ff4-5c92657aaafb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b3cf4572-0105-4700-bdf1-489d935fc3d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c5905114-ba5b-4a91-be54-e5dbbfcd8438"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c5e70262-4b09-46bf-b2b3-3dba5d6d0ef0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c8c5ad13-44cc-4125-8541-0191168384f8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d580eec7-26e3-48ca-bdef-5141cf4766e4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ff93d442-a4f7-408b-836a-f32aac08c8f3"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("503b4921-68af-404d-bc41-9cd87c24892a"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("01eb0061-015e-439f-bf89-18f51527afeb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"));

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "ForumTopics");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("47477724-2ec2-4ac2-b9bd-70b4e656df66"), "Science and Technology" },
                    { new Guid("483bafb0-6a8a-46e1-814c-de81b4ad9e3a"), "Locations" },
                    { new Guid("4d1ee620-249a-4629-99a2-cb9ef0a80ca2"), "Food and Drink" },
                    { new Guid("59b9b220-9b41-40ef-8ae0-a384224d29d3"), "History and Culture" },
                    { new Guid("7c74d058-b536-4b1d-aae9-0db322f74bd3"), "Events" },
                    { new Guid("7d129891-4f62-4a43-90e2-e8007dea5d63"), "Technologies" },
                    { new Guid("bdb0d5a7-7668-4724-9fe5-6179e411024a"), "Organizations" },
                    { new Guid("c0ea92af-4611-4f8e-9b7f-2a1de45c984c"), "Concepts" },
                    { new Guid("d3fec8c7-997a-4f4e-80e9-f56c38bbac3b"), "Arts and Entertainment" },
                    { new Guid("d67918b2-9737-4293-8e54-35f3d8d50ce3"), "Stories" },
                    { new Guid("e904a4db-a725-48eb-9167-e44fb6377a78"), "Sports and Recreation" },
                    { new Guid("ebc9b078-1a2c-43ce-ac31-0c73a68b15e9"), "Characters" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("1b9ec1da-131d-4319-88da-4d518c5731c4"), false, new Guid("483bafb0-6a8a-46e1-814c-de81b4ad9e3a"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 13, 18, 6, 37, 236, DateTimeKind.Local).AddTicks(6761), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6"), new Guid("ebc9b078-1a2c-43ce-ac31-0c73a68b15e9"), null, "WikiPage", null, true, new DateTime(2024, 5, 13, 18, 6, 37, 236, DateTimeKind.Local).AddTicks(6583), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30"), new Guid("d67918b2-9737-4293-8e54-35f3d8d50ce3"), null, "WikiPage", null, true, new DateTime(2024, 5, 13, 18, 6, 37, 236, DateTimeKind.Local).AddTicks(6625), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("15cda6a3-d675-4a73-8127-11dfd852049b"), "Ut soluta iusto soluta assumenda. Fugiat ea delectus perspiciatis ut eveniet quibusdam enim. Magnam voluptatem unde ut facere impedit. Voluptas saepe amet similique adipisci ut beatae.", null, null, "Example Page 1 - Paragraph 3", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") },
                    { new Guid("200596f9-3ff7-4739-88c5-e596425ca55a"), "Sapiente corporis illum aut. Blanditiis sed sed error cupiditate quia et ut. Consequatur autem voluptas nihil vel quaerat qui ut enim dolorem.\n\nQui quis natus quibusdam explicabo vel vero consectetur nihil quisquam. Unde delectus minus possimus. Recusandae consequatur sequi.\n\nQui enim illo id. Mollitia quisquam aspernatur quis. Sit ea iusto ab adipisci. Illo quia facere ratione ipsam est autem repudiandae.\n\nBlanditiis occaecati qui qui sed. Repellendus repellendus eos. Voluptas quas temporibus similique doloribus in qui saepe in dolorum.\n\nA et laborum fugit. Et dolorum omnis voluptas corrupti. Ea explicabo fugit. Error architecto quaerat consequuntur aut fugit animi sit tempore sit.\n\nAb aut est ad quia magni id voluptatibus architecto iure. Facere ab possimus neque qui quaerat molestiae omnis inventore. Temporibus quaerat eum molestias quaerat molestiae.\n\nAb excepturi repellendus ut veritatis tempora velit. Sunt sit est ad voluptas. Quia non ab quia temporibus tempore maiores ut voluptas ipsa. Cumque laborum ut. Rerum aut natus a.\n\nQuam tempore quasi sapiente. Accusantium nostrum quam quo dolore necessitatibus. Tenetur ut non ut qui qui.\n\nQuis doloribus labore fugiat. Et voluptatem nulla aut quod distinctio. Sit non accusantium impedit et nisi nesciunt. Omnis ratione rerum optio quasi ea facere ea voluptatum vitae. Est aut recusandae quam consequatur qui accusantium.", null, null, "Example Page 2 - Paragraph 4", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("3a7e9904-00dc-4780-b474-b30837cda84e"), "Laboriosam laudantium qui eligendi error sit consectetur laborum. Qui reiciendis ipsam quod qui repellat aut itaque animi laudantium. Aut voluptas ducimus dolores. Veritatis aut error tempora qui. Non natus dolorem eum esse architecto sit hic.\n\nQuos laboriosam voluptatem dolorem voluptate optio. Hic eum voluptatem molestias nisi omnis ratione. Quae nihil velit maiores nisi. Autem ut officiis omnis assumenda sit.\n\nRerum et nihil sapiente beatae aut rerum qui. Et labore saepe praesentium facere qui ea iusto quia. Sit corrupti occaecati soluta culpa qui magnam. Vitae omnis nesciunt qui reprehenderit autem.\n\nIure distinctio et quo mollitia. Iure non non voluptatum sed quo est. Omnis dolorem in quas voluptatibus neque culpa qui.\n\nVel quo possimus fugit in aliquid hic dignissimos. Adipisci quasi dolorem quia recusandae quia deserunt et minus alias. Ad voluptas odit ipsam.", null, null, "Example Page 1 - Paragraph 2", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") },
                    { new Guid("5015fc6c-0f6f-4df5-b2a9-e89cebfcb629"), "Possimus corporis perspiciatis quisquam rerum est eos eaque. Nostrum perferendis neque distinctio sit et molestias sit. Qui molestias sint earum vel facilis aliquid esse a.\n\nEst perferendis non soluta alias aut necessitatibus sed. Alias amet quos. Veniam sed dolor nemo tenetur. Aliquid ea cum repudiandae laboriosam omnis alias. Illum est eum inventore.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") },
                    { new Guid("57cc0c5c-8ca6-4eab-bc7c-db1e44f5875b"), "Est velit eos sunt nemo repudiandae. Sint eum amet omnis ut illum quo veniam. Officia et eum rem eos.\n\nAccusantium ea corrupti molestiae voluptatum iste qui et ut aut. Veniam dolores minima molestiae ut velit. Cupiditate eligendi saepe eligendi. Quis quos velit aliquid officia aspernatur consequatur molestiae ea corrupti. Eum et saepe mollitia. Est quo illo officia dignissimos.\n\nMagnam velit nulla atque recusandae. Sunt officiis quisquam enim natus. Rerum impedit porro sit amet architecto incidunt minus. Tenetur magni ea et blanditiis recusandae quia perspiciatis sit atque. Accusantium dignissimos odio quo deleniti delectus voluptatem ipsa. Reprehenderit ipsa iure enim similique et.\n\nDucimus non sint numquam atque. Officiis et non consequatur ut expedita quod distinctio. Maxime aut voluptatibus. Cumque ut officiis aliquid magni eos id aut provident. Consectetur et amet repellat culpa porro. Ea beatae autem aliquid repellat eveniet error asperiores dolores.\n\nOmnis culpa debitis voluptatibus praesentium tempora sequi dicta. Dolorem esse ullam magni maxime optio suscipit eius. Est quaerat et. Consequatur fugit optio cumque minus est eos totam vitae beatae.\n\nQui aliquid ut est facere odio magni. Voluptatem alias in magni repellendus corrupti voluptates. Nam ducimus rem ex exercitationem dolore enim corrupti et qui. Eveniet expedita aliquid facilis aut accusantium. Perferendis reiciendis itaque et. Quasi id perferendis eos dolores repellendus sed qui.", null, null, "Example Page 1 - Paragraph 4", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") },
                    { new Guid("6e7f3340-b4e0-478a-b992-903b906662c3"), "Doloribus omnis ea id dicta. Neque quis doloremque vel beatae fuga. Soluta fugit quaerat officia eaque hic nihil cupiditate.\n\nMagni rerum deleniti dignissimos enim. Perspiciatis temporibus error in molestiae enim doloribus alias fuga animi. Assumenda iure et animi fugiat atque.", null, null, "Example Page 2 - Paragraph 5", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("848d1696-cdac-4d61-829c-10bb347c5646"), "Impedit autem repellendus molestias consectetur quia ut. Dolorum dolorem natus cupiditate sed sint voluptas sint fugit ab. Voluptas quam odit aut magni deserunt. Accusamus deserunt labore quis qui ratione natus sed. Nostrum qui libero error quis ipsum.\n\nHarum vel et consequuntur rerum corrupti cupiditate. Expedita inventore modi enim rerum quas aut tempore in. Est quas nisi iure distinctio eveniet voluptatem odit aliquid possimus. Provident accusantium ut id fugiat. Distinctio autem possimus qui voluptates nostrum minus nisi quia fugit. Non aut laborum porro labore.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("8acf9f90-a137-43ee-9db6-3d111857163e"), "Accusantium non vitae tempore amet aperiam. Modi dolore quis quis odit eius aperiam. Maxime ut consectetur consectetur aliquid animi non eius ab. Voluptas quidem earum beatae placeat totam eum. Deserunt consequatur repudiandae non neque tempore dolor quasi.\n\nMinima eligendi minus voluptatibus sed molestiae. Explicabo tenetur dicta voluptatum nisi optio repudiandae a sint laboriosam. Non voluptates ab molestiae facilis. Ut qui sed rem dolore iste.\n\nVel culpa sed voluptas sapiente incidunt consectetur deleniti est. Cumque numquam incidunt qui qui omnis autem ab excepturi est. Fuga officiis in ratione. Esse consequatur omnis eum voluptas tempora et. Molestiae porro illo vero pariatur.\n\nMolestiae perferendis repellat repellendus accusantium illum. Dolores rerum sunt. Sapiente tempore ut vero praesentium magnam. Quos in quia id dignissimos voluptatem aut unde. A totam provident.", null, null, "Example Page 2 - Paragraph 6", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("a95a437a-cf58-4b12-a264-263217a370d2"), "Consequatur quo similique assumenda adipisci pariatur et rerum. Saepe qui natus aut. Exercitationem molestiae quos. Libero assumenda praesentium repudiandae inventore. Saepe iure quam sint maiores reprehenderit. Quo ad at dolor temporibus distinctio.", null, null, "Example Page 1 - Paragraph 5", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") },
                    { new Guid("dd7bc6dd-2cf2-4b9e-980b-8b3e8f041dec"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("1b9ec1da-131d-4319-88da-4d518c5731c4") },
                    { new Guid("e05b41c5-50d4-44c8-a7cd-0da5699c142b"), "Aut id qui ipsum laborum nesciunt necessitatibus delectus. Quaerat tenetur perspiciatis. Dolores modi qui eos perspiciatis debitis atque modi. Rerum quia dolores harum voluptas et est nobis delectus. Ut porro rerum. Ipsa neque aut rerum magni consectetur.\n\nA doloremque vel aut aspernatur itaque similique voluptatem omnis occaecati. Totam nihil sint. Perferendis voluptatem ea harum et exercitationem veritatis voluptate corporis. Sit odit ut aut velit neque at voluptas ducimus ea. Nisi eaque tempore nostrum ratione minus. Quia error ut officiis et praesentium nobis.\n\nExplicabo id est iusto placeat fuga ea culpa aut quis. Reiciendis unde eos aperiam in nulla magni sapiente sit. Dolorem qui repudiandae rerum nihil.", null, null, "Example Page 2 - Paragraph 3", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("f43af813-b1fe-40aa-b8e8-d4721c32eaca"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("1b9ec1da-131d-4319-88da-4d518c5731c4") },
                    { new Guid("fba5cecb-201e-4c2d-a36a-1953a47ad96f"), "In et quasi dicta voluptate expedita nihil eum. Quas dolores quam eaque voluptatem harum. Et animi cupiditate rerum rerum odio. Suscipit dolor sit et quam. Suscipit omnis nemo maxime hic distinctio rem. Consectetur voluptates recusandae magnam eaque reprehenderit cum totam nobis.\n\nConsequatur et voluptate et dolorem sequi voluptatem ducimus eum. Eaque ut velit expedita saepe dolorem nulla minus inventore aut. Repellat reiciendis ut. Atque et deserunt quas repudiandae. Earum sapiente voluptatem expedita consequatur molestiae. Aut nostrum magnam maiores voluptates nam molestiae.", null, null, "Example Page 2 - Paragraph 2", new Guid("d0afb429-ec0d-422c-8765-66baeca9fe30") },
                    { new Guid("fe760cd7-631c-4794-9463-f750315525ba"), "Numquam molestiae temporibus et aut. Velit et consequuntur voluptas consequuntur ut vel vel. Explicabo quam illo nihil. Animi adipisci quis. Dignissimos totam aut expedita architecto laudantium occaecati libero sed aspernatur. Eum autem iste.\n\nVel maxime consequatur. Quisquam explicabo et officiis facere impedit omnis. Cupiditate omnis aut laborum omnis voluptatem repellendus. Veritatis fuga sint possimus id hic labore excepturi harum consequuntur. Adipisci excepturi blanditiis possimus pariatur ducimus et nulla.\n\nUt quia voluptatibus. Necessitatibus provident omnis hic omnis eum aut veritatis. Voluptatum eum ab officiis aut. Sequi voluptates repellendus deserunt possimus voluptates architecto dolore in sed. Consequatur quos sapiente labore.\n\nArchitecto et quo quam beatae id. Rem minus ut harum et ea vero molestiae. Corporis laborum dolorum officiis facilis harum qui. Rem vel adipisci laborum doloremque harum deleniti magnam. Ea quo assumenda ea molestiae eveniet rerum reprehenderit laboriosam.", null, null, "Example Page 1 - Paragraph 6", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("3f0df0db-53ef-4987-8f52-7da3cc7efc99"), false, new Guid("7c74d058-b536-4b1d-aae9-0db322f74bd3"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 13, 18, 6, 37, 236, DateTimeKind.Local).AddTicks(6765), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("4030010b-4ab1-4a2f-a550-8fc8ff053ac6") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("631d45d7-9883-411f-921a-cfc303eaa4f7"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("3f0df0db-53ef-4987-8f52-7da3cc7efc99") },
                    { new Guid("8268259d-f713-41fd-89dc-e529d248c5d1"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("3f0df0db-53ef-4987-8f52-7da3cc7efc99") }
                });
        }
    }
}
