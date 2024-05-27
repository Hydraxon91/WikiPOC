using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumPostModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ForumPosts",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ForumPosts");

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
    }
}
