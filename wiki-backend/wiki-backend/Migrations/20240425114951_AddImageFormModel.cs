using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddImageFormModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("03356fd5-8697-40e0-8533-5f3843fe7cc6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("17010ede-3705-4f3e-89b2-a26383252cfc"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("17f034f2-ff44-4c85-8f64-85ae56e9f209"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2578ad59-23cb-48ac-8758-3cc2f8a3f148"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("35f144a9-100e-4775-8e50-2e560263fada"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4a972c48-8545-4328-bbd8-94fc6815f802"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6fd16a01-9b1f-4764-8bf0-08e1e6ee338c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("77f4e68e-c0b9-44e4-8fcc-42a7e3b5a930"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7ba9a3e8-e6d4-45b7-9ccd-ce50651bd9a2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7c121d70-e14d-4966-b56f-5d3195eb6a00"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8b38c034-da68-4af0-bdcd-a3465b9919a7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8b442b9a-157c-4f71-9e48-02774f1a5517"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("bac9b0f9-7927-4cc5-8e50-e4e4f71ee38f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c997f107-a4d6-4eff-8775-4662007af7c8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6cfa2e7-6e19-42bc-ba44-38ffb707ed6b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ee30f450-db2b-4b06-abf0-768daeb937df"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0d64abfc-745a-420b-9fd2-6296bbdd3e47"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("643fe2e1-2bc2-478c-8ebd-623648ae1284"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c906c954-d883-45f7-9275-d286f74c68f0"));

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("1fccbf1c-2608-4ebc-bf09-746f30cced1b"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("48d14636-f791-4b99-988e-76daaadea04c"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("57fab91d-9a28-4666-8c5a-239349267d83"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("11972a99-7996-4a80-b131-1d218a4353e8"), "Eius neque eum aut explicabo cum. Harum ratione est repellendus autem eum. Commodi molestiae assumenda omnis in velit magnam exercitationem.\n\nAlias molestias ipsum exercitationem enim facilis modi eveniet dolorem. Voluptates non veniam ex et atque dignissimos ut velit ipsum. Expedita voluptatem reiciendis reprehenderit quia ut. Numquam omnis laudantium deserunt dolor ut. Eligendi eius consequatur eos suscipit ab aut. Dolorem inventore autem veniam placeat iste qui blanditiis.\n\nIn sed minima. Ipsum facilis enim quia quam magnam. Alias odit rerum eius aliquid odit quibusdam totam. Iste enim placeat voluptatem rerum consequuntur. Voluptates dolorum aliquid ullam corporis quibusdam illum molestiae. Eos ut iste cupiditate itaque excepturi.\n\nDebitis rerum excepturi quos et. Ea enim voluptas laboriosam autem explicabo non perferendis veniam sapiente. Atque voluptatibus tempora ut qui ipsum illum alias ut. Voluptatum consequatur et vitae. Et ut temporibus ullam iusto velit.\n\nPlaceat voluptatem dolorem eos nostrum omnis ut temporibus dolorem. Possimus id officiis iure quas qui doloremque nulla. Non tenetur totam aliquam.\n\nAut hic officia nihil facere sapiente quas officiis. Laborum numquam placeat accusamus molestias alias illo. Repudiandae quibusdam aut adipisci praesentium voluptatem nisi sunt exercitationem.\n\nUnde magnam quo nulla et odit. Voluptas quis minima et aliquid saepe qui officia et. Dolor corporis quia dignissimos eum repellat explicabo. Nihil deserunt magnam illo labore. Earum sequi accusantium mollitia quos.\n\nRerum ab vero. Sequi vel vel occaecati consequatur. Est error temporibus aspernatur error ut nulla iure et blanditiis.\n\nMaiores cumque placeat. Mollitia quis est ipsam magni accusantium suscipit aperiam. Tempore hic odit deserunt.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("1a9dc61d-1bb1-4ad1-ad40-6d36b34ba9a8"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("1fccbf1c-2608-4ebc-bf09-746f30cced1b") },
                    { new Guid("1c7adbd7-e1fc-470d-b4c6-8fe2be231ad9"), "Temporibus eum architecto culpa voluptates voluptatibus repudiandae. Perspiciatis ipsam nostrum quas ipsum at ut. Magnam quo unde occaecati quos dignissimos consequatur nisi magni. Tempora eius ut placeat exercitationem rerum veritatis.\n\nDignissimos explicabo ullam tempore iste eos vitae quia. Sapiente aut non doloribus quam. Nihil molestiae provident. Illo quos velit minima totam excepturi voluptatibus dolores distinctio. Voluptatem similique quia ipsa praesentium aut est rerum consequatur. Maiores est sequi pariatur dolorum amet consequatur.\n\nRepellat aut quia commodi. Dolor vero ea. Qui aut quia sit. Rerum harum voluptas dolores laboriosam in officia id minus unde. Omnis illum labore aut ut. Id aut sit laboriosam rerum.\n\nQuibusdam necessitatibus accusamus facere quidem. Harum aut quia voluptas nam odit nesciunt tempora. Et nisi quis.\n\nRerum quisquam eum in. Delectus iure eum corporis. Cumque magnam adipisci voluptates. Quam tempora rerum eos voluptatem eos eligendi occaecati consequatur. Et ipsum nesciunt porro iusto quidem autem.\n\nTempore voluptatem repudiandae et ratione quo ex. Modi vel nam error nihil labore quidem reprehenderit nam quisquam. Aliquam itaque accusamus aut. Veniam iure vel ut nobis sed. Nisi sit rerum est voluptate amet ut quia qui.\n\nEst ut accusantium eum. Et saepe expedita nesciunt laborum. Eligendi ad harum a dolores. Sed ipsum dignissimos. Sit ipsum dolor. Quis soluta assumenda corporis omnis eveniet.\n\nEst consectetur eum nam quis enim sequi. Nobis commodi est quae. Aperiam qui esse minus quibusdam aperiam voluptas sapiente et. Odit excepturi assumenda explicabo. Voluptatum ea aut officiis praesentium sed vero minus voluptatum esse. Minima doloribus quia eos debitis exercitationem consequatur.\n\nQui maxime est nihil dolorum. Quibusdam officiis accusamus consequatur asperiores et magnam iusto. Dolorem ad voluptates tempora vel. Quibusdam ut eius maiores maiores unde accusamus qui et nobis. Commodi blanditiis quidem nemo id.\n\nAb veritatis non temporibus accusamus expedita rerum. Animi molestiae autem esse. Nobis ipsam architecto non dolorem cupiditate nihil. Ab suscipit consequatur fugit. Esse voluptas at totam hic quas. Libero est autem voluptatibus repellat quo veritatis tempore perspiciatis veniam.", null, null, "Example Page 1 - Paragraph 5", new Guid("48d14636-f791-4b99-988e-76daaadea04c") },
                    { new Guid("1fcca079-e55f-4e5b-bd5d-15ec6d6994a3"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("1fccbf1c-2608-4ebc-bf09-746f30cced1b") },
                    { new Guid("205bb7a0-b29c-4910-8d80-5492dda4394f"), "Voluptates sed qui. Sit adipisci dolores enim sed adipisci incidunt. Optio voluptates sit libero. Consequatur inventore modi. Sunt et voluptatem eveniet quisquam.\n\nEt qui temporibus inventore occaecati placeat reprehenderit eum id. Voluptatem sequi omnis omnis quis sint dolore. Fugit optio eligendi error facilis. Voluptas dolores quisquam consequuntur harum in ex quas provident.\n\nNon natus quis consequatur cupiditate. Quae adipisci ut molestiae. Mollitia libero ratione asperiores sit itaque facilis nam et.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("48d14636-f791-4b99-988e-76daaadea04c") },
                    { new Guid("302f13b9-fe4d-42b1-a761-a81b9fa43520"), "Inventore doloribus sapiente est eius velit cum. At quasi aut a minima excepturi. Labore neque eaque quos amet laudantium officiis sed. Nihil ea voluptate facilis labore doloremque nulla voluptates iste.\n\nVitae rerum et autem modi. Aspernatur eos officiis. Labore ea enim officiis perferendis repellat cumque. Vitae numquam quos iusto modi reprehenderit quibusdam.\n\nMolestiae et quis voluptatem laborum. Tempora sit inventore iure qui ex magni eos. Veritatis quaerat est sequi necessitatibus recusandae quia unde sit. Sed dolore aut voluptatem voluptas maxime est aperiam consequatur nisi.\n\nCorrupti ut ipsam perferendis blanditiis facere placeat voluptatum qui. Aliquam quam sit sed sint ut expedita. Expedita enim vel doloribus porro sequi. Non itaque voluptatibus sunt. Et aperiam voluptates culpa.", null, null, "Example Page 2 - Paragraph 2", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("5205dc30-fa92-4bbe-a452-87cc26921346"), "Ut aut quidem dolorum earum. Dignissimos consectetur veniam ab quibusdam harum eum cum at. Ratione voluptas molestiae. Blanditiis culpa et qui corrupti alias. Nisi ullam dolores doloribus officiis repellat aperiam omnis qui. Aut numquam velit quos natus deleniti asperiores.\n\nId aspernatur in quia et at qui illo tempore aut. Commodi vel omnis esse rerum pariatur sed consectetur. Repellendus incidunt animi autem nam voluptatibus dolorum rerum commodi provident. Quod delectus dolores non sint. Fugiat mollitia veniam et laudantium suscipit.", null, null, "Example Page 2 - Paragraph 6", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("52b9bb32-87d4-463d-a6df-d24365be8825"), "Et quo rerum mollitia. Eum nihil autem nihil. Assumenda quibusdam sit. A sapiente est et accusantium voluptatem est officiis. Labore nobis et atque laudantium asperiores.\n\nAtque quasi corporis ipsum adipisci. Qui omnis quam. Ullam sunt commodi non natus laboriosam explicabo accusamus perspiciatis. Impedit autem ut mollitia et et minima sint rerum error. Sapiente perferendis est et nulla. Aspernatur debitis et.\n\nDoloribus sequi natus cumque nam odio ut adipisci natus et. Soluta qui magnam provident tempora et sunt enim nam. Debitis sit repellendus eos. Ad facere corporis voluptatem tempore officia. Id et aliquid nihil quos. Quos quisquam unde quos.\n\nNesciunt eum consectetur tempora quis. Voluptatem doloribus libero. Sequi explicabo et debitis iusto soluta blanditiis.\n\nQuia cumque et accusantium dolor ullam velit quia minima dicta. Rerum incidunt sequi repellat. Temporibus perspiciatis facilis. Cumque quod consequuntur.\n\nEt consequatur dolorum odio id consequuntur delectus vel. Sed quo sit cupiditate. Est aut eveniet inventore sapiente. Ab excepturi voluptatem qui placeat cum facere quasi voluptatem aut. Vitae cum aut reprehenderit iusto.\n\nMagni incidunt perspiciatis eius. Excepturi at tempore hic quisquam qui. Doloremque quia amet magni. Vel asperiores nihil quod dolore rerum modi sint. Non quasi in consectetur laudantium laudantium eius fugit.\n\nEum voluptatem fuga amet ab totam voluptates. Nihil et incidunt. Nesciunt odit est. Quia aut corporis est aut omnis rerum at culpa. Blanditiis reiciendis porro quidem dolore. Harum animi neque voluptates deleniti.\n\nLaboriosam commodi repudiandae pariatur sequi vel. Iusto voluptatem dolorem sed error. At qui aut sunt ut libero delectus quam accusamus porro. Est amet tenetur officiis. Consequatur cumque impedit iure fugiat et est architecto quaerat.\n\nOfficia rerum aut deserunt et perferendis. Cupiditate atque vel quia enim. Exercitationem aperiam cupiditate consequatur laboriosam. Corrupti laborum qui optio. Dolores numquam nostrum voluptatem non aut eum placeat ex aut. Odio velit et consectetur libero sed.", null, null, "Example Page 1 - Paragraph 6", new Guid("48d14636-f791-4b99-988e-76daaadea04c") },
                    { new Guid("5e7df16c-02e0-4b5b-823b-d19c78630d47"), "Doloremque laborum voluptas id numquam ut. Officiis incidunt quidem rerum non omnis. Ut debitis facilis architecto qui. Consequatur illum ad officiis ipsum.\n\nRerum qui voluptate impedit et explicabo iusto. Incidunt facere cumque totam ipsa ut. In autem autem. Ut optio laborum distinctio unde repudiandae alias non. Eum aut ut veniam. Consectetur nostrum consectetur quo ut id et ipsam.\n\nBeatae error tenetur inventore. Recusandae a tempore et provident sunt. Quia minus nemo. Eligendi enim sed blanditiis nihil deserunt nisi.\n\nEt velit repellendus est sapiente sint animi dicta odio. Voluptatem atque distinctio qui doloremque eum explicabo. Eum quas aspernatur repellendus ut consequuntur quisquam vero unde.", null, null, "Example Page 2 - Paragraph 5", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("9434f5d8-01e9-4588-b2ac-2a2d15c472fa"), "Nihil doloremque non magni esse soluta. Non unde perferendis non tempore ratione qui. Veniam libero harum animi placeat. Corporis quasi sapiente vel est voluptatibus distinctio.\n\nRem sint et ullam et natus delectus. Consequatur eos minima nam error alias. Explicabo ratione impedit dolorem eius eius laboriosam mollitia laboriosam. Omnis cupiditate libero dolorem nisi consequatur enim occaecati.", null, null, "Example Page 1 - Paragraph 4", new Guid("48d14636-f791-4b99-988e-76daaadea04c") },
                    { new Guid("d73c20cc-4c2a-4755-9f88-2f9606f8ab9d"), "Optio quia et repudiandae architecto quae dolorem debitis ut. Cupiditate odit aspernatur dolor ea error similique. Est magnam non sunt harum ipsa velit dolor.\n\nDoloremque eum doloribus aut ratione temporibus. Facere eius ratione odio nemo omnis dolorum voluptatem soluta delectus. Enim magnam ducimus. Vel est ut enim aperiam officia. Eum iusto sapiente consectetur ea. Voluptatem omnis aut sit ab et voluptatem unde reiciendis.\n\nAccusantium quod repellendus doloremque veritatis maxime. Sit et saepe veniam fugiat qui rerum. Deleniti maxime occaecati beatae voluptates consequatur. Pariatur quas non accusamus voluptas optio maxime incidunt eos. Sint id ut harum facere impedit.\n\nAutem adipisci qui corporis aut. Sit autem est voluptate necessitatibus dolorem numquam. Aut velit assumenda rerum necessitatibus. Nobis repudiandae earum consequatur eum aut et similique ex.\n\nDolores molestiae necessitatibus aspernatur. Qui illum aspernatur. Vel eligendi aut illo vitae aut quia dolores. Asperiores vel occaecati.\n\nCumque dolores et. Provident tenetur rem assumenda consectetur sit vero qui optio qui. Quam animi non ut nobis consequuntur. Blanditiis dignissimos laborum sit optio dolores qui magnam eum. Quia quia praesentium cumque consequuntur.\n\nVoluptatem velit placeat rerum aliquid sapiente consequatur fuga necessitatibus. Cum omnis tenetur nisi harum repellendus reiciendis dolores. Nisi tempora et rem nihil. Iste nemo inventore blanditiis delectus nam ut dolorum nemo illum. Adipisci quod dolore delectus ut esse quos dolores.", null, null, "Example Page 1 - Paragraph 2", new Guid("48d14636-f791-4b99-988e-76daaadea04c") },
                    { new Guid("daa00c2d-2f5a-4c53-9116-574e5c146597"), "Ad quis voluptas inventore temporibus consequatur unde. Voluptas omnis similique aperiam illum sunt. Est aut ab sit sit sunt ex labore mollitia. Nemo veritatis ea. Velit quo itaque quis.\n\nVoluptas praesentium architecto voluptatum quibusdam minus excepturi quia animi. Nobis alias labore minima quis aperiam. Culpa maxime dicta atque consectetur.\n\nDoloribus qui iste. Quibusdam harum nulla et et beatae. Blanditiis ea sapiente perspiciatis ea dolore et quo. Inventore autem quasi modi adipisci aut corrupti adipisci voluptatem hic. Error eius aliquid nobis et provident. Consequatur dignissimos repellat qui quisquam quasi.\n\nEt quia est ex natus. Ut corrupti aut pariatur incidunt vel unde deleniti aliquid autem. Aut corrupti sit enim voluptas architecto quis placeat quia voluptates.", null, null, "Example Page 2 - Paragraph 4", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("efd35253-d52d-4396-a724-ac9e8b05f84b"), "Temporibus et sit eveniet nostrum. Provident cum doloribus repellendus ducimus sit id. Vero molestiae voluptatem.\n\nAccusantium sint et. Reprehenderit ad adipisci aut sequi vero alias accusantium rerum eos. Tempora cupiditate dignissimos ut dignissimos tenetur nisi non praesentium. Repudiandae non molestiae sed eos dolore amet et eum voluptatibus.\n\nQuod voluptate sunt vitae qui et consequuntur eum. Qui neque aut et amet vel vel laudantium. Dolor occaecati aut molestias ab est. Assumenda quaerat non debitis est dignissimos error est sed.\n\nDolorum natus rerum consequatur totam. Est perferendis distinctio. Qui accusamus fugiat aspernatur reprehenderit omnis nisi. Ut illo odit delectus at.\n\nTotam cum repellat non excepturi qui tenetur ex. Possimus maxime neque ipsa iusto odio molestiae omnis eveniet. Inventore sit dolores animi possimus. Aut optio facere illo et nam voluptas veritatis quis perspiciatis. Est necessitatibus accusantium quae maxime ducimus ad quo.\n\nVoluptates autem qui. Ex commodi voluptatem officiis maiores aut delectus. Officiis adipisci aut dolorem. Ut explicabo et nulla dignissimos laborum id est quia velit. Soluta consequatur sint exercitationem accusantium repellendus voluptatem.\n\nAlias quia assumenda et quidem sit expedita. Unde hic nostrum excepturi facilis provident magni dolores. Distinctio maxime ex non dolor. Cum rerum pariatur alias illum rem incidunt aut molestias.\n\nAperiam vel minima dolores praesentium et veritatis. Dolores quidem veniam quae. Est magnam reiciendis.\n\nAdipisci saepe nemo esse rem provident qui. Optio expedita neque incidunt et. Amet exercitationem velit sunt alias aliquid dolor voluptates quam.", null, null, "Example Page 2 - Paragraph 3", new Guid("57fab91d-9a28-4666-8c5a-239349267d83") },
                    { new Guid("fe76df58-b5ad-42fb-9cdc-4441ca8bf205"), "Quae ipsum exercitationem officiis quae. Corrupti quas ea aut quia quisquam optio dolor doloribus voluptas. Earum rem nihil veniam.", null, null, "Example Page 1 - Paragraph 3", new Guid("48d14636-f791-4b99-988e-76daaadea04c") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("0bcc5275-81ad-4367-948b-fd04cae19609"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("48d14636-f791-4b99-988e-76daaadea04c") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("3a75369d-a093-493e-a11a-c8718573253a"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("0bcc5275-81ad-4367-948b-fd04cae19609") },
                    { new Guid("76c4e4e2-b3f2-4f83-98d6-54516ab15f9c"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("0bcc5275-81ad-4367-948b-fd04cae19609") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("11972a99-7996-4a80-b131-1d218a4353e8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1a9dc61d-1bb1-4ad1-ad40-6d36b34ba9a8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c7adbd7-e1fc-470d-b4c6-8fe2be231ad9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1fcca079-e55f-4e5b-bd5d-15ec6d6994a3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("205bb7a0-b29c-4910-8d80-5492dda4394f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("302f13b9-fe4d-42b1-a761-a81b9fa43520"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3a75369d-a093-493e-a11a-c8718573253a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5205dc30-fa92-4bbe-a452-87cc26921346"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("52b9bb32-87d4-463d-a6df-d24365be8825"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5e7df16c-02e0-4b5b-823b-d19c78630d47"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("76c4e4e2-b3f2-4f83-98d6-54516ab15f9c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9434f5d8-01e9-4588-b2ac-2a2d15c472fa"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d73c20cc-4c2a-4755-9f88-2f9606f8ab9d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("daa00c2d-2f5a-4c53-9116-574e5c146597"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("efd35253-d52d-4396-a724-ac9e8b05f84b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fe76df58-b5ad-42fb-9cdc-4441ca8bf205"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0bcc5275-81ad-4367-948b-fd04cae19609"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1fccbf1c-2608-4ebc-bf09-746f30cced1b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("57fab91d-9a28-4666-8c5a-239349267d83"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("48d14636-f791-4b99-988e-76daaadea04c"));

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("643fe2e1-2bc2-478c-8ebd-623648ae1284"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("c906c954-d883-45f7-9275-d286f74c68f0"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("03356fd5-8697-40e0-8533-5f3843fe7cc6"), "Dicta ducimus id temporibus explicabo laboriosam quidem et culpa eius. Perspiciatis ut saepe omnis et sed quo provident minus aliquid. Velit perferendis voluptatibus aperiam qui debitis. Qui eos deserunt.", null, null, "Example Page 2 - Paragraph 6", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("17010ede-3705-4f3e-89b2-a26383252cfc"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("643fe2e1-2bc2-478c-8ebd-623648ae1284") },
                    { new Guid("2578ad59-23cb-48ac-8758-3cc2f8a3f148"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("643fe2e1-2bc2-478c-8ebd-623648ae1284") },
                    { new Guid("35f144a9-100e-4775-8e50-2e560263fada"), "Quia omnis quis. Nam numquam corrupti pariatur. Praesentium harum sit magnam porro voluptas voluptate. Aut officia minus deleniti qui repudiandae eaque maxime eum. Magni possimus rerum inventore suscipit cupiditate distinctio quas. Id et et veniam.\n\nPerspiciatis voluptas natus vitae id quo dolorum ut nihil. Molestiae exercitationem quis deleniti fugiat. Magni commodi possimus vero voluptatibus. Saepe magni reiciendis laborum sint corporis.\n\nAut nulla libero ex nihil iusto consequatur vitae eaque nisi. Qui fugit facere vitae laudantium. Et eveniet reiciendis a quo ut ut ea hic voluptate.\n\nAliquam voluptatem assumenda quibusdam iste aut. Excepturi assumenda pariatur ut quos est eius. Placeat repellat voluptate eum et quo incidunt animi quod rerum. Expedita hic perferendis dolor. Totam veritatis laborum est unde iusto et error numquam. Eaque suscipit est modi.\n\nEt vitae hic aut nisi autem voluptas alias. Id nisi hic. Adipisci consectetur harum natus aut iusto quaerat ex natus. Enim aspernatur voluptates.", null, null, "Example Page 2 - Paragraph 4", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("4a972c48-8545-4328-bbd8-94fc6815f802"), "Tempora ut rerum maxime veritatis praesentium neque incidunt suscipit. Rerum repellat consequuntur cumque. Consectetur praesentium nesciunt quis vel.\n\nRerum vero est laudantium reprehenderit. Possimus veritatis accusamus at et eos ea. Adipisci quidem molestiae. Saepe repellat sint fugit fugiat doloremque.\n\nIste provident enim est incidunt fugit molestiae culpa. Sunt architecto praesentium est. Voluptatem rem et velit aut omnis eos tempore. At molestias illum quidem et ut magni. Fuga cumque facere voluptatem.\n\nEius nesciunt molestiae repellat nisi qui accusamus occaecati omnis ratione. Eligendi velit consectetur sed neque blanditiis nesciunt maxime. Et eos soluta enim aut debitis neque explicabo at. Quo earum iure consequatur facere reiciendis odio aspernatur. Maxime corrupti excepturi dignissimos.\n\nNon sunt odio dolor dolore repellat et adipisci quas aut. Nihil dolor consequatur voluptatum sint tempore deleniti. Voluptas possimus itaque debitis sunt perferendis impedit cupiditate rerum.\n\nQuia quos velit recusandae similique. Occaecati quasi tenetur saepe earum sit. Facere voluptas blanditiis omnis ea et qui. Et excepturi est qui. Vero amet et earum perferendis adipisci similique omnis ea saepe.\n\nPraesentium ut corrupti laudantium voluptatem qui qui et iusto voluptatum. Animi quia quam et. Qui earum illum omnis laudantium. Delectus qui quo amet alias culpa molestiae.", null, null, "Example Page 2 - Paragraph 5", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("6fd16a01-9b1f-4764-8bf0-08e1e6ee338c"), "Consequuntur possimus eaque voluptatem. Excepturi a perferendis cum. Adipisci voluptas quos ullam vero et quos.\n\nNihil adipisci hic pariatur officia ut aut et. Dolor qui omnis laborum perspiciatis eum. Voluptas sequi sint asperiores. Ipsam natus maxime voluptatem. Omnis consequuntur vel aut voluptates delectus aspernatur omnis iure.\n\nSunt soluta mollitia dolores cum. Doloremque voluptatum qui. Et reiciendis nobis et tempore laboriosam officiis adipisci quasi.\n\nAsperiores omnis delectus ut qui dolorem quia animi. Ut consequatur excepturi iure. Commodi illo cum eveniet ipsam error asperiores. At neque magnam libero. Atque vitae quisquam facilis ex eos. Ut saepe voluptatum inventore consequatur voluptatibus asperiores quam.\n\nAnimi et nostrum soluta aliquid. Fugit dolores quia omnis est placeat. Aut voluptatem veritatis odit dolor deleniti molestias rerum voluptas. Ad consequuntur eum sed quam quia. Rerum aut sunt minus veritatis assumenda dolores dolorem est inventore.\n\nNostrum possimus et. Labore sapiente a aut. Rerum et et reiciendis nulla sunt ullam quae. Autem pariatur quo iure delectus quaerat. Ea voluptates ipsam fuga. Esse nobis sed reiciendis optio nihil reprehenderit vitae mollitia.", null, null, "Example Page 1 - Paragraph 5", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") },
                    { new Guid("77f4e68e-c0b9-44e4-8fcc-42a7e3b5a930"), "Distinctio et id hic quibusdam dolor hic. Nisi recusandae quos soluta. In sunt voluptatem vel ab quibusdam autem quia voluptas. Repellendus sed veniam unde dolores non esse velit earum.", null, null, "Example Page 2 - Paragraph 2", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("7c121d70-e14d-4966-b56f-5d3195eb6a00"), "Quo porro culpa et sit totam maiores repellendus aut voluptates. Non et assumenda illum. Amet omnis nostrum dolore qui et eos corrupti.", null, null, "Example Page 2 - Paragraph 3", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("8b38c034-da68-4af0-bdcd-a3465b9919a7"), "Eum laudantium ab quisquam. Quia ea maiores molestiae qui sit rem aut eligendi. Quis aut error magni neque occaecati consequatur. Vel placeat voluptas sint aut molestias et ut commodi architecto. Accusantium animi ipsa debitis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("5acd2af4-22e5-43f7-9e8d-a249e68d6a56") },
                    { new Guid("8b442b9a-157c-4f71-9e48-02774f1a5517"), "Est corporis tenetur aliquam quasi eum ratione quasi beatae ratione. Natus est in natus rerum praesentium non. Et nemo sint enim et. Voluptatibus vel mollitia cum itaque asperiores recusandae voluptas doloremque. Ut dolor quam aliquid autem est non omnis. In fugit qui voluptatem quidem.\n\nEst perferendis tenetur sequi est accusamus vel voluptate. Autem provident enim dolorem fugiat sit ipsa. Adipisci quo totam occaecati aut praesentium assumenda nam placeat architecto. Vero sint est velit soluta exercitationem. Minima magni odit illo perspiciatis.\n\nIste aut natus est. Suscipit dolorum animi explicabo. Adipisci quam recusandae odit aut ut occaecati. Tenetur architecto et quia quod. Similique ea eaque nam at sunt.\n\nDolorem dolorem mollitia voluptatem dolorem occaecati laudantium rerum. Cupiditate aut voluptatem officia reiciendis veniam nemo vel in ut. Magnam blanditiis excepturi quis et velit. Aut molestiae ipsum. Quia suscipit dolores eos qui.\n\nPlaceat autem ex numquam suscipit. Adipisci culpa ullam ut corporis sed. Possimus optio voluptas et laudantium maiores quod placeat voluptate voluptas.\n\nQui dicta alias est deserunt laudantium voluptatibus non. Eos sunt quis asperiores est enim consequatur. Sint amet quod tempore quae et eos consectetur necessitatibus minus. Et et dolorem expedita.", null, null, "Example Page 1 - Paragraph 2", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") },
                    { new Guid("bac9b0f9-7927-4cc5-8e50-e4e4f71ee38f"), "Consequatur modi et saepe aut veritatis fugit consequuntur dolor. Vel aut eos vitae. Iste sed quaerat illum porro iure qui ad.\n\nOmnis velit corporis voluptatem ad nisi. Praesentium voluptatem aliquid. Alias consequatur exercitationem tempora qui beatae ut rerum consectetur iste. Consequatur et officiis aspernatur voluptas.\n\nIure repudiandae laudantium tempore alias dolores pariatur accusamus. Accusamus ab vero molestiae voluptates excepturi. Non velit est et sit aut laboriosam reprehenderit veritatis. Ut minima tempore earum. Assumenda quia omnis ut alias non nihil quos repudiandae voluptas. Et numquam qui tempore molestiae accusantium nemo repudiandae.\n\nVoluptas vel sed nihil ab rerum. Velit sed recusandae ratione aut autem voluptas qui cumque quas. Nihil sunt voluptatem impedit est. Totam ut eveniet quia rerum optio neque. Nihil rem consequatur ut facere.\n\nEnim itaque ut delectus quidem est et. Non odit voluptatum porro quo totam repellat est. Doloremque expedita ut. Id assumenda optio tempore atque. Non fugiat nesciunt assumenda nam voluptas qui ipsam distinctio expedita. Natus doloremque et quaerat.\n\nConsequuntur doloremque laborum est voluptates mollitia adipisci. Dolores necessitatibus magnam tenetur eveniet fuga occaecati molestias. Quam molestiae quod maiores ut aut pariatur at.\n\nMolestias suscipit veritatis delectus ad architecto sed fugiat consequuntur. A consequatur eos non numquam ea voluptatibus tempore distinctio. Eligendi ullam neque debitis qui magnam voluptatem illo id et. Aut quia est dolores odio enim atque nobis. Debitis dicta sunt fugit commodi cum deleniti reiciendis ipsa.", null, null, "Example Page 1 - Paragraph 3", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") },
                    { new Guid("c997f107-a4d6-4eff-8775-4662007af7c8"), "Aut expedita molestiae quibusdam culpa. Possimus saepe voluptate dolores vero est similique aspernatur ipsam et. Suscipit repellendus impedit itaque vel hic.\n\nAssumenda neque non ut similique voluptatibus quam aut facilis. Non quis quod incidunt quaerat quis nesciunt. Ut nihil quibusdam omnis pariatur.\n\nAlias quasi ratione velit cupiditate porro culpa nam possimus. Et quidem quia sint quia in placeat. Nemo ipsa ullam itaque et.\n\nPerferendis distinctio facilis reprehenderit voluptas. Et dolore odio sit consectetur commodi quam porro. Omnis ipsum eveniet vero est totam est. Explicabo sit voluptatem accusamus voluptatibus delectus aliquid dolor eveniet minus. Possimus alias voluptates temporibus qui ut incidunt eos.\n\nIpsam magnam odit officia odit recusandae. Sit sit aperiam adipisci voluptatem nisi expedita. Est cum consectetur distinctio. Voluptatem cumque sunt harum error modi quod quisquam eius. Vitae labore voluptas est enim nam in. Et explicabo omnis tenetur.\n\nQuo numquam dolor sint enim. Vitae error eum vel aliquam velit eligendi aliquid quos molestiae. Minus sequi commodi. Reprehenderit fugiat ab et non sint qui corrupti. Sed enim reiciendis rerum enim reiciendis quae explicabo quia.\n\nAmet molestiae nihil nam eos debitis nobis eum. Minima ea quia aut praesentium inventore. Repellat debitis suscipit nihil facilis. Maiores aut vitae culpa dolores eum.\n\nFacilis molestiae omnis non laborum nobis aut voluptate debitis. Harum ut et perferendis. Qui reiciendis in. Eligendi ipsa et dicta.\n\nMaiores deserunt est nam in vel ab vero et. Quaerat nemo sit modi alias est aut fuga. Ea omnis corrupti et et sit sit nihil explicabo.\n\nSit quas eveniet ipsum iste dignissimos quibusdam et dolor. Et rerum qui quisquam. Ut maxime in vel necessitatibus error consequuntur et autem laboriosam. Quasi sunt similique. Mollitia libero iusto.", null, null, "Example Page 1 - Paragraph 6", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") },
                    { new Guid("d6cfa2e7-6e19-42bc-ba44-38ffb707ed6b"), "Aliquid nisi error explicabo dicta. Dignissimos in odio voluptatem. Quos porro sit autem. Distinctio enim aliquid veritatis maiores ut blanditiis deserunt.\n\nSint impedit provident sed veritatis dolor quo molestiae unde deleniti. Porro rerum enim dolore. Sit asperiores velit molestiae nihil quae assumenda distinctio. Aut sint reiciendis nisi nostrum reiciendis repudiandae numquam dolorem.\n\nSint perferendis ut omnis. Excepturi quia provident nihil rerum. Ut voluptatem sed et est illo.\n\nVoluptates fugiat molestiae repellendus omnis earum. Voluptas et et error facilis. Natus dolores id et reprehenderit possimus numquam sunt nesciunt. Aut et dicta cupiditate modi optio. Est architecto dolores dolores nulla velit eveniet rerum reiciendis.\n\nTotam temporibus temporibus qui doloribus aliquid atque voluptas et. Ex perspiciatis culpa temporibus veniam nulla. Similique et laudantium consequatur et praesentium.\n\nRem eos vero voluptatem excepturi voluptates molestiae nobis. Dicta sit asperiores molestiae rerum magnam sunt laudantium sit. Soluta provident atque et. Vitae modi nulla nihil quos possimus explicabo.\n\nAlias mollitia placeat non eveniet ipsa molestiae nostrum. Veniam est vel ex veniam mollitia commodi. Maxime sint non fugiat corrupti quam et inventore. Est sunt et quia aut et necessitatibus neque. Numquam necessitatibus amet earum aut cumque. Vitae sunt et minus est molestiae.\n\nOptio voluptatem sint nulla eligendi aliquam. Harum voluptatem deleniti dolor sit dolores dicta nulla aperiam. Quas omnis voluptatem in. Harum tempore quam enim quas odio tenetur et nisi minima. Tempore eum est officiis reprehenderit.", null, null, "Example Page 1 - Paragraph 4", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") },
                    { new Guid("ee30f450-db2b-4b06-abf0-768daeb937df"), "Odit commodi nulla unde laudantium dolore aut non sed. Ut animi qui soluta et consequuntur dignissimos ut animi. Labore fugiat quo qui voluptas voluptates rerum. Quibusdam rem veniam. Ipsam dolore sunt fugiat rerum provident harum autem. Recusandae eum dolor ut cupiditate amet inventore dolores sit rerum.\n\nNumquam qui consectetur ut deleniti eos asperiores numquam qui. Labore est sunt illo et. Dicta nobis suscipit in. Deserunt sequi aut ut.\n\nCommodi similique tempore non ut ut dolorem expedita et. Consequatur voluptate dolorem necessitatibus fuga veniam vel. Veniam soluta laboriosam natus sed et exercitationem veritatis. Voluptatem ullam quia id eos quia. Ut autem ut et ex recusandae ex dolorem eos odit.\n\nEarum blanditiis nisi sequi voluptatum id deserunt. Quas ut ad vel enim sunt accusantium. Et aspernatur possimus et aut molestiae quia voluptas sunt sunt. Rerum consequatur sit quibusdam tempora ea.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("0d64abfc-745a-420b-9fd2-6296bbdd3e47"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("c906c954-d883-45f7-9275-d286f74c68f0") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("17f034f2-ff44-4c85-8f64-85ae56e9f209"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("0d64abfc-745a-420b-9fd2-6296bbdd3e47") },
                    { new Guid("7ba9a3e8-e6d4-45b7-9ccd-ce50651bd9a2"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("0d64abfc-745a-420b-9fd2-6296bbdd3e47") }
                });
        }
    }
}
