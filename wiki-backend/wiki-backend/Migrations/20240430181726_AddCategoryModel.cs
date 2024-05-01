using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("07118e28-e972-40a7-b7cc-5a51c31cfa04"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1d14d787-e749-4543-8ba2-a19d3d5dc857"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1f584f65-f898-4a82-b548-e23a9731f6f7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1fa04bfa-c7bd-42ac-9a35-c319645c3759"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3afa415f-ff47-4815-8d32-a93b45f2c57a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("46ce1c6a-cd02-4b73-8cd3-831b26962435"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("49dd845f-79db-4e65-adae-eebe74e80c5f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("57d33f63-079a-43d9-a478-99bc6aa9c8b1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7e067ebc-28a1-4c34-80e5-865ec43b91dc"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("84a9de75-7312-47ca-bd30-39915f27e489"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("889eaaa1-4e3c-46c9-8a1d-4123ad61169f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a4cfe6fd-3f38-4f99-9951-a5f05ec83ba4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cc5a38ff-dc9c-4161-a8c5-ab3adc4af689"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ec69f3e4-3692-4145-9bc9-860ecb1babe2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f4b287d4-d310-4deb-bb62-168488a5e7fb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fefb18ac-b8d9-4dce-b284-2ab9b2485f1c"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0acec16e-29d4-481e-ad4a-9de4dd91b14d"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("bca84b59-6c30-4fe0-ac12-a7a1e352ceb8"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00"));

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 30, 20, 17, 26, 429, DateTimeKind.Local).AddTicks(6332), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("a826742d-78d1-4797-a4a1-ad752eedede2"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 30, 20, 17, 26, 429, DateTimeKind.Local).AddTicks(6376), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("af347d49-a13b-4bd7-ab02-b041c7cb2b56"), false, null, null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 4, 30, 20, 17, 26, 429, DateTimeKind.Local).AddTicks(6491), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0654dbbf-b144-48ae-b92c-49e23ee3075c"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("af347d49-a13b-4bd7-ab02-b041c7cb2b56") },
                    { new Guid("0a31d620-848d-4adc-a862-65cdd828c2f3"), "Accusamus quia repellendus dolor ipsa minima quae. Ex quidem possimus. Ullam eos ad molestias voluptatem ea dolorem id corrupti provident. Sequi autem quae unde. Magni nesciunt omnis.\n\nUnde consequatur nostrum deleniti quibusdam illum autem incidunt sit. Eius voluptates vitae id. Quo tempore possimus omnis dolor voluptates id reiciendis sed.\n\nQui at dolor repudiandae vero expedita. Eum aut qui aspernatur repellendus ut eos. Consectetur doloremque placeat quibusdam nulla amet est. Aut provident dolorum voluptatem minus.\n\nHic quia aut in soluta praesentium hic voluptatum consequatur. Sit voluptatum est quaerat. Nihil repellendus tenetur ex. Voluptatem adipisci earum. Ex quos autem consequuntur ex non similique repudiandae eos. Voluptas omnis temporibus et sed perferendis voluptatem.\n\nMinima illo magni aut commodi molestiae neque. Dolorem eveniet quisquam repudiandae occaecati. Exercitationem necessitatibus est fugiat saepe omnis dolorem.\n\nFugiat suscipit sit eos odit aut et qui. Ipsum magni eveniet ut laudantium aliquam voluptas laboriosam quam aut. Labore sunt praesentium non labore quaerat consequuntur. Vel dolorum reiciendis.\n\nAut sunt ipsa facere amet. Ut neque autem ipsam quisquam. Ut earum qui iure dolores quae.\n\nQuia in iste. Velit atque id aut laborum rerum voluptatum. Autem magnam sequi qui qui amet. Ex et iure doloremque neque ut sunt repellat quisquam. Quidem enim voluptatibus nesciunt aut iure ab voluptatem non libero. Rerum culpa nulla enim veritatis est exercitationem.\n\nEt omnis porro facilis minus. Dolore nesciunt quam soluta possimus voluptate rem impedit nisi. Nostrum eligendi ducimus reprehenderit. Labore mollitia est eveniet vitae dolor modi. Non similique aliquid iste.", null, null, "Example Page 2 - Paragraph 4", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("1cdea84a-38ab-43bb-9514-18711088a971"), "Eum quasi sed inventore et expedita quas omnis sit. Ut suscipit molestiae sit repellendus. Suscipit earum hic. Facilis dolorem dolores.\n\nQuisquam veniam quisquam nihil quod sunt laboriosam. Ipsum est unde non assumenda deleniti. Cumque sed assumenda commodi est. Molestias possimus dolores voluptatibus voluptates laborum ipsam.\n\nLaudantium reiciendis inventore debitis enim cum officiis consequatur nisi. Nam molestiae dolorum voluptas autem consectetur adipisci itaque vel. Assumenda est quam doloribus. Sed enim deserunt vel rerum et. Omnis eligendi facilis nostrum sed qui nisi.", null, null, "Example Page 1 - Paragraph 5", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") },
                    { new Guid("2721329d-1ccf-4cb9-b7b6-6e5091f6f523"), "In laudantium quibusdam architecto repudiandae pariatur temporibus eos nostrum. Aut perferendis quae. Quod doloribus sequi.\n\nQui id vel totam alias reprehenderit. Et debitis sed quia ut recusandae accusamus. Laboriosam rerum officiis quis ut error consequatur dolor qui. Ipsam autem quis facilis labore ex et eos quis.", null, null, "Example Page 2 - Paragraph 2", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("29fd6741-2526-47f4-b1f9-5f967afa79c9"), "Voluptatem aut cumque nihil. Libero maxime error unde ipsam. Incidunt aut omnis harum sed et repellat. Nisi ut ut iusto facilis nesciunt eius aut velit. Qui dolor quasi eos.\n\nExpedita distinctio molestiae totam laboriosam quia quam natus nisi rerum. Eum sit optio. Est neque perspiciatis quasi non.\n\nVeritatis nobis rerum cupiditate enim asperiores aut illo. Excepturi hic delectus omnis illum est illum minus. Error et eos placeat mollitia. Totam aut nam quas. Aliquid voluptate commodi quo itaque iste quo.\n\nRepellat voluptatem qui est nisi quae consequatur. Sunt a molestiae quod. Et necessitatibus sed minus amet beatae beatae ullam.\n\nUllam neque est odit dignissimos est. Occaecati omnis ducimus perspiciatis harum ea quam impedit et quis. Tenetur minus culpa exercitationem vero non exercitationem. Id autem et sed qui nihil porro veniam asperiores voluptatem. Et voluptatem ut voluptatem. A reprehenderit ut molestiae.\n\nItaque aut nisi voluptates quae pariatur possimus. Culpa repudiandae quia dolores debitis doloremque possimus rerum est qui. Blanditiis voluptates asperiores ut minima voluptas esse iusto.\n\nBeatae tenetur dolorem laborum dolorum nobis voluptas est quidem quia. Optio dolorem qui. Earum sequi et sed at qui ipsum. Laborum assumenda et. Sed nemo consequuntur hic non.", null, null, "Example Page 1 - Paragraph 2", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") },
                    { new Guid("30c33dd6-8f44-4d24-9cc9-ba30aed5a3d2"), "Est voluptas sit dolor incidunt officiis officia. Praesentium quas maxime non facilis voluptatibus odio. Delectus repellendus exercitationem saepe et velit qui libero est. Sit omnis sunt cupiditate voluptate. Tempore maxime nesciunt dolor reiciendis ut quae error non.\n\nQuas sequi iste soluta voluptatum dolorem. Praesentium commodi veniam error earum. Fuga ut consequatur repellendus autem.\n\nSapiente rerum iure consectetur atque. Inventore quasi illo voluptas aliquid quis cum ut quos ut. Nesciunt et fugit quae magni molestiae praesentium dignissimos tempora maxime. Quasi explicabo quia laboriosam placeat.\n\nMagnam modi quis et quos. Temporibus facilis ut sed porro deleniti eum rerum corporis. Iusto et dolor. Accusantium omnis fugit est qui et dolorem ad.", null, null, "Example Page 1 - Paragraph 4", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") },
                    { new Guid("3352bbbc-f4b7-4b5a-9c5f-1fd88464fe1e"), "Vitae omnis pariatur rerum maxime provident. Id nihil pariatur consequatur soluta suscipit. Optio eum aperiam adipisci repellendus assumenda molestias. Iste vel aut reprehenderit et nihil qui animi rem placeat. Officiis qui impedit aut minima dolor sunt iure ducimus repudiandae.\n\nAt maxime corporis ea unde alias quas rerum ipsa vero. Nulla vel facilis. In cumque impedit.\n\nId alias fuga omnis. Et vel similique. Repellendus est veritatis enim velit explicabo ut itaque. Laudantium eos ex perspiciatis blanditiis est.\n\nUt itaque in facilis. Error omnis non amet natus consequuntur unde. Similique sunt culpa quis architecto nulla.\n\nAnimi minus ab et maiores officiis quis impedit est sapiente. Quam ullam facilis voluptas autem nobis labore. Suscipit aliquam unde eius recusandae fuga. Dignissimos dolorem aut sequi sapiente et a recusandae officiis explicabo. Ea exercitationem quos provident ipsam adipisci molestias.\n\nVoluptatum doloribus aspernatur illo in pariatur eos voluptatum id. Necessitatibus nihil aliquam. Neque quas eius veritatis dolorem. Consequatur fugiat quod sint totam sed architecto assumenda porro et. Perspiciatis vero molestias perspiciatis.\n\nInventore ipsum impedit dolore perferendis officiis illo cum ut sunt. Eius error ea id ut. Quidem quaerat molestiae rerum fugiat saepe saepe nisi. Repudiandae dolor neque sed corporis ipsum.\n\nMaiores et adipisci laborum at provident. Perspiciatis vero quia. Et ad totam pariatur voluptas illo inventore vel blanditiis.\n\nLaudantium rerum dolores. Omnis nemo fugiat. Aut omnis commodi ut cupiditate iste dolore. Unde laudantium ex aut nisi animi. Consectetur non debitis. Inventore omnis ullam vel eos et.\n\nIste id necessitatibus rerum neque non. Nam similique voluptatem nemo. Unde sunt in. Nulla nemo qui. Dolorem ipsam repellendus exercitationem possimus aut. Dolorum dolores aut et sapiente illum commodi vero.", null, null, "Example Page 2 - Paragraph 3", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("36cc5272-501e-4811-afef-912420949eac"), "Enim laborum necessitatibus corporis in. Nesciunt est ratione. Velit labore reprehenderit blanditiis et rerum totam. Sed aspernatur dolores dolorum unde sed tenetur fugiat omnis quis. Nostrum earum dolorum quia neque nulla mollitia sint aliquam natus.\n\nRerum repudiandae ut et eum. Eos consequuntur ut. Eligendi perferendis eligendi ut. Ea ea doloremque rerum distinctio perspiciatis. Voluptatem molestiae est neque quia pariatur id. Omnis dignissimos amet quia eligendi est molestiae ducimus deserunt quisquam.\n\nFugit rem delectus deleniti reprehenderit unde et vel dolorem provident. Explicabo mollitia eum. Magnam qui vel et non.\n\nVoluptatibus et ratione alias exercitationem rerum porro tempore. Quia nihil nam fugit voluptas rerum aspernatur rerum doloribus. Reprehenderit enim temporibus id qui quo et maiores quia cum.\n\nDucimus dolores quidem temporibus laborum repellendus. Quis doloribus iusto. Repellendus ut autem distinctio nulla animi omnis harum. Vitae repellendus quo porro nostrum dolores.\n\nId similique pariatur enim. Ad consectetur et ut repellat fugiat ut. Iste temporibus voluptatum. Modi in dolores voluptas. Dignissimos cumque distinctio.\n\nQuaerat ad a. Voluptatem in perferendis reiciendis distinctio necessitatibus. Et consequatur libero porro.\n\nDolorem voluptatem qui officia. Voluptatum doloremque porro beatae voluptatum. Neque minus placeat deserunt quasi quo odit. Nulla cupiditate illum dolorem. Eius quae ratione rerum doloremque.", null, null, "Example Page 2 - Paragraph 6", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("3808e043-9757-439d-86ac-da99ebcc20b5"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("af347d49-a13b-4bd7-ab02-b041c7cb2b56") },
                    { new Guid("795d7fd5-2018-4054-863b-b6a51cb6db24"), "Porro facere ullam. Eveniet eaque sint sint sit non enim eum. Hic dolorum et. Velit sint et cum reprehenderit in est non. Aliquam rerum et est odio.\n\nEt sapiente accusamus aut explicabo quia. Impedit placeat vel aperiam quis consequatur enim velit iusto voluptatem. Earum id rerum ipsa dolorum dolores.\n\nQuia quo eaque consequatur rem. Aperiam nihil quo sint qui. Accusantium voluptatem et facilis sed. Ratione quis facere officiis ea occaecati. Sunt dolorem consectetur. Fugiat adipisci voluptas vel dolorum repudiandae sed porro et qui.\n\nQui facilis consequatur voluptas veniam sapiente. Quia error eaque. Consequatur laudantium ad officiis facilis eius consequatur nihil illum. Sunt asperiores eum dolores occaecati placeat neque est et vero.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("a9a771a2-7ea9-4f05-b24a-be28f0d1fe25"), "Ullam iste eveniet veritatis eaque molestias eligendi ducimus. Voluptas vel corrupti iusto voluptatibus est facere voluptatem eligendi. Optio aut rem non suscipit voluptatem sint. Et soluta eveniet ipsam ducimus ut pariatur et neque. Itaque eum blanditiis adipisci et laudantium.\n\nEx id ullam veniam ea iste est vel. Minus nemo consequatur. Voluptate sit nisi non rerum molestiae. Asperiores excepturi numquam sit porro non est.\n\nCum aliquam iste eligendi eaque consequuntur atque deleniti quas. Voluptatem blanditiis dolorem nesciunt sed autem architecto. Et error consequatur. Ut quasi et veritatis ea neque in blanditiis. Quod asperiores voluptatem suscipit necessitatibus. Sit delectus modi eum impedit ut provident.\n\nAutem esse sunt ut. Reiciendis id ut ad modi non voluptatibus veritatis fuga tenetur. Eos nemo provident aut.\n\nCorporis autem veniam ut mollitia id. Ipsam est eius ut at asperiores. Nihil quo non rerum optio alias cum.\n\nDolorem a est numquam magni quia mollitia consequatur ut eius. Nam id possimus possimus molestias provident suscipit. Repudiandae animi consequuntur tenetur qui dolorum quisquam. Veniam aut iure dolorem ea aperiam.\n\nConsequatur a necessitatibus nesciunt eum officia maiores natus eos. Impedit nostrum veritatis enim dolorem qui et. Qui delectus aperiam consectetur sunt. Nam necessitatibus suscipit odit vel. Dignissimos dolor aspernatur.\n\nRerum ducimus quod. Enim blanditiis in. Autem voluptas quis est non hic numquam ea in odit.\n\nAutem voluptatem rerum sed reprehenderit consequuntur. Cum perferendis perferendis sunt. Soluta suscipit iusto id temporibus facere amet mollitia quos ducimus. Quisquam ullam quaerat nihil optio. Omnis quas harum ducimus minima mollitia fugit accusamus porro ut.", null, null, "Example Page 1 - Paragraph 3", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") },
                    { new Guid("d3d710be-e110-48a5-a5bb-9fd5668cd4f0"), "Voluptatem voluptatem beatae omnis totam. Harum voluptate earum est neque nihil praesentium ut voluptatum quia. Odit est sint accusamus rem velit id aliquid praesentium. Temporibus earum magni doloremque iusto. Dolore quis incidunt distinctio. Labore nobis quae sed rerum.\n\nDolor sed quia eius tempore delectus accusamus. Iusto saepe deserunt nesciunt laudantium omnis. Voluptatem distinctio et assumenda impedit quis repellendus non et. Voluptatum aut quia sapiente.", null, null, "Example Page 2 - Paragraph 5", new Guid("a826742d-78d1-4797-a4a1-ad752eedede2") },
                    { new Guid("d6bfae2d-3c20-4e74-bd00-0f4c619dd775"), "Nihil temporibus est omnis quod quia quis animi consequuntur. In et culpa quia aliquid totam qui expedita dolorum. Dolor tempore eveniet tempore eum reprehenderit.\n\nDolorem qui vel et repellendus. Fugiat eveniet eaque veritatis aut doloremque harum magnam nam. Nam illo aliquid.\n\nAnimi itaque nisi quis eveniet reprehenderit nobis. Et asperiores ut eligendi aut architecto. Dolore ut et non qui et quia amet. Excepturi odio eaque natus rerum rerum. Suscipit modi nesciunt quis ut.\n\nExplicabo sequi eum quas. Repellat consequatur molestiae. Consequatur magnam exercitationem ab earum omnis vitae reiciendis et beatae. Ut ut consequatur pariatur reprehenderit sit sit architecto. Ut autem natus minus quam et aliquam. Aperiam accusantium dolorum natus repellat itaque.\n\nEt nihil sit aut sequi eius voluptatem. Quo rerum molestiae maxime expedita nostrum vitae voluptatem libero quis. Earum asperiores rerum consequatur ullam nam. Voluptatibus corrupti molestiae. Facilis in sed esse modi aut voluptatem. Ea modi culpa doloremque aut quam voluptatem eos fuga quibusdam.\n\nHarum officia ea adipisci assumenda ullam distinctio provident corporis. Voluptatem dicta dolore sunt accusamus deleniti temporibus amet. Nisi tempora voluptatibus iste minus deserunt quo.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") },
                    { new Guid("e642e099-1850-4376-81e3-ded2ff34a637"), "Laudantium aspernatur sint porro reprehenderit iste illo. Ut odio explicabo similique earum rerum odio. Ea nihil ut sequi voluptatem nesciunt. In id iure qui eos est ea doloribus minima omnis. Consequatur ea aut id.\n\nLaudantium laborum repellendus consequatur. Praesentium harum ad suscipit consequatur et nulla repudiandae cumque. Omnis odit ipsum. Sed et corporis mollitia vel enim eos voluptatum rerum. At expedita cumque consequatur et non quo est. Deserunt et veritatis itaque vel nulla et nam et officia.", null, null, "Example Page 1 - Paragraph 6", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("61ac58bf-5009-4f1a-a9a2-7892b1bc470e"), false, null, null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 4, 30, 20, 17, 26, 429, DateTimeKind.Local).AddTicks(6495), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("662a35d1-0938-4e2b-a081-6cdab0e62431"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("61ac58bf-5009-4f1a-a9a2-7892b1bc470e") },
                    { new Guid("7b087457-2cc8-4d08-bbec-68b0ea60ca2f"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("61ac58bf-5009-4f1a-a9a2-7892b1bc470e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0654dbbf-b144-48ae-b92c-49e23ee3075c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0a31d620-848d-4adc-a862-65cdd828c2f3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1cdea84a-38ab-43bb-9514-18711088a971"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2721329d-1ccf-4cb9-b7b6-6e5091f6f523"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("29fd6741-2526-47f4-b1f9-5f967afa79c9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("30c33dd6-8f44-4d24-9cc9-ba30aed5a3d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3352bbbc-f4b7-4b5a-9c5f-1fd88464fe1e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("36cc5272-501e-4811-afef-912420949eac"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3808e043-9757-439d-86ac-da99ebcc20b5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("662a35d1-0938-4e2b-a081-6cdab0e62431"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("795d7fd5-2018-4054-863b-b6a51cb6db24"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7b087457-2cc8-4d08-bbec-68b0ea60ca2f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a9a771a2-7ea9-4f05-b24a-be28f0d1fe25"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d3d710be-e110-48a5-a5bb-9fd5668cd4f0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6bfae2d-3c20-4e74-bd00-0f4c619dd775"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e642e099-1850-4376-81e3-ded2ff34a637"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("61ac58bf-5009-4f1a-a9a2-7892b1bc470e"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("a826742d-78d1-4797-a4a1-ad752eedede2"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("af347d49-a13b-4bd7-ab02-b041c7cb2b56"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("a6157532-1afc-42bf-bf84-640d61eeaacb"));

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 26, 9, 27, 10, 222, DateTimeKind.Local).AddTicks(847), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 26, 9, 27, 10, 222, DateTimeKind.Local).AddTicks(889), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("bca84b59-6c30-4fe0-ac12-a7a1e352ceb8"), false, null, null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 4, 26, 9, 27, 10, 222, DateTimeKind.Local).AddTicks(1015), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("07118e28-e972-40a7-b7cc-5a51c31cfa04"), "Ut error dolorem. Sunt asperiores eos cupiditate est in ex at aut. Neque rem tempore fugit ea assumenda ut. Minima labore expedita itaque. Omnis sed esse.\n\nConsequatur veniam deleniti. Earum nobis nesciunt nesciunt. Mollitia omnis porro ipsa officia nesciunt facere voluptas nisi. Odit aliquam a numquam et velit sunt.\n\nDolores quibusdam laborum quod adipisci sequi enim enim ducimus dolor. Molestias non ut earum cumque. Quas facilis incidunt ut distinctio sint animi. Tenetur est dicta. Harum iste in ab incidunt dolorem nihil autem. Nisi amet culpa sunt veritatis ut suscipit.\n\nId vero neque error placeat nobis numquam. Iste accusantium suscipit vel. Minima et fuga totam. Maxime amet quaerat enim aut.\n\nOdit aut amet et nesciunt nisi voluptatem libero. Voluptatibus cumque at dolorem sunt dolorem molestiae error rerum. Aut quis exercitationem et. Iure reprehenderit doloribus ducimus. Ipsa eveniet suscipit sed similique quod at et repudiandae necessitatibus.", null, null, "Example Page 1 - Paragraph 2", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") },
                    { new Guid("1f584f65-f898-4a82-b548-e23a9731f6f7"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("bca84b59-6c30-4fe0-ac12-a7a1e352ceb8") },
                    { new Guid("1fa04bfa-c7bd-42ac-9a35-c319645c3759"), "Voluptas quos iure qui fugit voluptatem explicabo. Est enim suscipit quisquam. Incidunt recusandae sit.\n\nSit eum consequuntur. Impedit est officia incidunt voluptas consequuntur veritatis. Qui quae eius dolore dolorum sed optio. Expedita dicta optio ut. Odio et consectetur vitae aut aliquid sint. Ex quo ut aspernatur nemo autem iste ea sed nulla.\n\nQuibusdam dolorem quos vitae qui qui unde consectetur eius. Animi rerum natus. Ea deserunt voluptate architecto commodi reprehenderit est pariatur. Laborum quisquam atque quod. Possimus sit neque assumenda accusantium ea fuga nam fugit deserunt. Voluptas veritatis exercitationem quaerat numquam possimus qui non deserunt quae.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") },
                    { new Guid("3afa415f-ff47-4815-8d32-a93b45f2c57a"), "Eaque itaque unde fugiat odit iure dolore facilis et dolorem. Sint repudiandae officiis eaque quod debitis. Qui quae ea enim totam optio. Ut nostrum numquam est laboriosam inventore. Enim recusandae voluptatem numquam itaque aliquam aliquam.\n\nEa quam excepturi aut non sit voluptatem. Asperiores magnam minus quia sed quidem unde est exercitationem. Doloribus laudantium aut facilis officiis quibusdam nemo et.\n\nAlias fugit ea expedita amet illo sequi. Dolor ad eligendi est eum delectus ipsam eum debitis. Labore tempora harum in est eum a illo deserunt laborum. Impedit nisi ea adipisci non voluptatum consequatur et odit. Velit soluta rerum est assumenda voluptates.\n\nAccusantium culpa sed rerum. Accusantium accusamus esse impedit cumque dicta dolores. Tenetur placeat sit laboriosam debitis qui.", null, null, "Example Page 2 - Paragraph 5", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("46ce1c6a-cd02-4b73-8cd3-831b26962435"), "Possimus impedit nemo consequatur minima reiciendis consequatur voluptatem voluptates. Nam totam odio beatae. Quisquam quia doloremque est impedit autem eius dolorem doloribus sint. Et veritatis quod sint quibusdam. Aut facilis accusantium ut enim. Quae sunt in beatae eius.\n\nAt officiis veritatis magnam atque velit ipsum. Harum ea ullam dolorum quaerat quod. Modi voluptatem commodi et odit. Earum sapiente tempore neque animi in aut dolorem soluta sit.", null, null, "Example Page 2 - Paragraph 3", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("49dd845f-79db-4e65-adae-eebe74e80c5f"), "Exercitationem eligendi autem atque non facere nobis. Cupiditate facilis est deleniti numquam nemo. Voluptatibus neque aspernatur. Commodi ex dolores nihil similique beatae aut quis at provident. Dolores sunt dignissimos optio sunt voluptas culpa sint qui quis.\n\nQuia tempore magni hic. Inventore doloribus aspernatur quidem voluptatem. Libero reprehenderit aliquam ut qui in magnam. Fugiat quia dolorem sit illum molestiae sit ipsa commodi aut.\n\nRecusandae est sit. Quos velit culpa ut et voluptas quos omnis perferendis. Quia enim modi sint modi et. Aliquid quia repellat facere eos.\n\nDicta quo eaque aut minus inventore velit non. Dolor rem earum asperiores placeat suscipit nihil enim. Nisi aperiam dolor eius reprehenderit asperiores eos ut omnis. Occaecati recusandae ut dolores ullam aut.\n\nEst veniam numquam aperiam fuga. Ut quisquam maiores nulla et. Similique ex quae illo delectus.\n\nUt cupiditate illo sint nihil in non consequatur iste. Dolor ipsam id aspernatur necessitatibus sunt soluta dolore. Fugit ex facilis. Incidunt voluptatem et omnis maxime est ut tempora. Accusantium et rerum.", null, null, "Example Page 2 - Paragraph 6", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("57d33f63-079a-43d9-a478-99bc6aa9c8b1"), "Asperiores cupiditate aut quas rerum ullam. Dolor facere delectus distinctio et sunt quo quo. Impedit dicta nam qui saepe libero ut. Occaecati voluptatem sunt enim dolores et sint. Minus ut et ipsa qui accusantium aut ea voluptate. Aperiam quis nam veniam nesciunt sint dolor incidunt enim sit.\n\nEnim qui voluptas. Fugiat similique aut sit impedit exercitationem nostrum. Ut debitis porro asperiores culpa.\n\nQuia recusandae accusantium. Omnis et omnis voluptatem voluptas harum qui numquam voluptatibus. Aspernatur unde quia. Dolorem voluptatem labore repellendus excepturi suscipit alias qui laboriosam labore. Praesentium sit corporis omnis.", null, null, "Example Page 1 - Paragraph 3", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") },
                    { new Guid("7e067ebc-28a1-4c34-80e5-865ec43b91dc"), "Ut unde adipisci at ut reprehenderit. Quia voluptas dolor velit totam ut qui et. Minima temporibus earum ut.", null, null, "Example Page 2 - Paragraph 4", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("84a9de75-7312-47ca-bd30-39915f27e489"), "Dignissimos ut tenetur temporibus. Rem quo quis. Sequi perferendis ut magni optio nihil. Repellat recusandae eos.\n\nRepudiandae asperiores doloribus velit minus odio. Excepturi adipisci sint itaque dolore. Sit unde aut quo nam nesciunt ut harum quia sapiente. Dolores aspernatur at omnis et et suscipit.\n\nOfficiis nemo autem ullam velit maxime aspernatur. Autem accusantium quasi iusto. Quidem modi labore porro autem praesentium voluptatem sed ea non. Qui rerum magnam iusto dignissimos repellat illum saepe est. Ut magnam amet repellat omnis vero. Blanditiis et est adipisci.\n\nAut provident voluptatibus aliquam iusto iste ut quo quasi. Quod illo iusto maxime sequi. Repudiandae similique maiores.\n\nNemo aliquid est tempore exercitationem. Perferendis quibusdam earum sed. Rem consequatur molestiae libero temporibus ipsam corporis. Corrupti eum quae doloribus recusandae sed ad ut.", null, null, "Example Page 2 - Paragraph 2", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("889eaaa1-4e3c-46c9-8a1d-4123ad61169f"), "Neque in corporis veniam enim impedit aliquam. Expedita quo ipsa error est aut et iure. Nobis libero facere velit.\n\nExpedita est et est iste. Doloremque dignissimos molestiae provident qui omnis facere ut nam ea. Laboriosam id est accusamus esse est. Quia excepturi doloribus magnam. Quia voluptate amet neque impedit.\n\nFacilis voluptas repellat. Nulla assumenda et eaque necessitatibus et. Ratione molestiae voluptatibus voluptatum voluptatem.\n\nNihil et sed. Rerum et voluptatem expedita qui dolores. Rerum quis esse nostrum aut repellat. Consequatur facere at ut quasi repudiandae non veniam sed ullam.\n\nConsequatur unde sunt non occaecati maxime sequi consequuntur et expedita. Qui qui est totam consectetur veniam similique aut et. Earum inventore aut quam tempora iusto dolores tenetur sit. Et fugit voluptatem dolorem quo et enim.\n\nVoluptatem unde deserunt. Est esse omnis et natus perferendis culpa eos eligendi. Dolorem voluptatem doloribus iusto doloribus est reprehenderit est voluptatem.\n\nProvident consequuntur porro et consequuntur blanditiis et autem. Vero perspiciatis facere minus et consectetur sed aspernatur. Alias aut error necessitatibus cum. Tempora ut qui. Molestias officia sunt nobis dignissimos suscipit. Sunt eos modi laboriosam adipisci ut perspiciatis.\n\nEsse quam necessitatibus fuga. Officiis tenetur consequatur ut sed voluptatem nostrum architecto. Deleniti officiis eum ad qui in. Et laborum ut mollitia in animi ducimus reprehenderit error neque. Mollitia adipisci expedita nihil ducimus rerum. Mollitia quas fugiat iste cupiditate iure numquam et et.", null, null, "Example Page 1 - Paragraph 5", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") },
                    { new Guid("a4cfe6fd-3f38-4f99-9951-a5f05ec83ba4"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("bca84b59-6c30-4fe0-ac12-a7a1e352ceb8") },
                    { new Guid("cc5a38ff-dc9c-4161-a8c5-ab3adc4af689"), "Dicta ab blanditiis aliquid sed possimus repudiandae culpa maiores. Qui rerum et laborum et rerum delectus. Dolores eligendi soluta.\n\nUllam laborum et nam. Quis voluptatem neque delectus a minima consectetur. Non exercitationem sit autem et quos eos deleniti. Facere autem et nemo aliquid numquam et alias rerum. Asperiores et voluptatem laudantium iste molestiae sapiente amet nobis omnis.\n\nQuod ut dolor et odio odio. Deserunt qui delectus eveniet eos est dolor sit tempore. Omnis consequuntur est modi ipsam. Rerum quam suscipit debitis omnis. Explicabo quia esse consequatur nemo exercitationem. Molestiae ipsam magni optio libero amet.\n\nConsectetur aut nam est facilis ut voluptas. Explicabo est aut libero ex sed. A et cupiditate tenetur ut nemo culpa aliquid perferendis saepe. Praesentium repellendus eius molestias voluptatem quas. Architecto sint qui aut laudantium iusto minima.\n\nUllam voluptatem ducimus provident commodi fugit dolorem. Eveniet dolorem harum ducimus porro ut. Voluptatem consectetur officiis nobis adipisci iure. Rerum tempore omnis cumque praesentium unde facere. Incidunt mollitia culpa repellat magnam id rerum quod minus quasi.\n\nRerum velit eum. Et consequuntur ad eius doloremque perspiciatis maxime commodi quod enim. Autem repellendus sunt iusto iure qui cupiditate dolores occaecati. Vitae delectus earum reprehenderit voluptatem rerum. Omnis ut quasi sit rerum.\n\nQuisquam temporibus id pariatur sit necessitatibus laborum. Ut ut voluptas aut. Quam ex et ratione perspiciatis beatae ut. Architecto facere officia repudiandae necessitatibus tenetur consequatur repellendus. Saepe consequatur esse qui sunt saepe et optio minima voluptatem.\n\nAliquid est placeat sunt id vel. Maxime voluptate tempora. Qui soluta est iusto aut repellat eos et autem unde. Ut autem eos. Omnis rerum recusandae quis eligendi blanditiis eveniet fuga similique repellendus. Amet dolorem architecto maiores doloremque et.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("7e26e97f-35a0-4f39-a971-4c41beb94653") },
                    { new Guid("ec69f3e4-3692-4145-9bc9-860ecb1babe2"), "Ipsum vel quidem et. Qui temporibus aut eum. Perferendis ea eveniet nemo perspiciatis aut nulla quibusdam animi commodi. Voluptas quia esse ut commodi. Rerum iusto explicabo voluptate quaerat nostrum consequuntur. Unde harum ut non.\n\nOmnis est quisquam. Ut non commodi. Dolor rerum eos corporis.\n\nEnim libero ad tenetur qui nesciunt vel natus ut. Commodi sunt illum aspernatur voluptatem. Accusamus corrupti voluptatibus est enim occaecati. Sapiente sapiente dolorem et et in ut quia ipsum officiis. Sit et quasi temporibus dolor voluptatibus pariatur ut sunt odio.\n\nEa perferendis distinctio in magni magnam. Nisi nihil a. Velit assumenda debitis ratione consequatur error quam vel soluta. Earum nobis illum itaque fugit. Tenetur occaecati voluptas cumque. Quaerat consequatur sed architecto in in sint enim similique.\n\nDolorum veniam maxime maxime omnis laudantium laborum necessitatibus temporibus. Delectus nesciunt iusto numquam. Dolores sed voluptatem enim odit voluptas unde quia et sit. Et qui et quia.\n\nBlanditiis voluptatem possimus quas ut dolorem hic hic sit. Non sed fugit commodi eius. Eum sit et consectetur et ipsam. Iure molestias voluptates et rerum sed occaecati dignissimos exercitationem tenetur. Aliquid sed ad asperiores vero.", null, null, "Example Page 1 - Paragraph 4", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") },
                    { new Guid("fefb18ac-b8d9-4dce-b284-2ab9b2485f1c"), "Et eius dolores aut et voluptas exercitationem. Laborum asperiores ex vel culpa itaque. Est voluptatibus at quo accusamus nostrum voluptatem.\n\nLaudantium nulla repellat dolorem magni sapiente. Consequatur expedita minus odio dolore necessitatibus nemo commodi accusantium rerum. Ut adipisci odit et magnam aut nobis alias. Harum voluptatem aut voluptatibus est voluptatem. Sunt provident nihil sit quia amet labore ab praesentium.\n\nAutem aut occaecati reiciendis sit sit. Eos eum repudiandae eum et voluptas nihil. Non animi sed mollitia quis.\n\nEarum id est impedit eos sit. Ex quia velit magnam rem aperiam autem molestias. Qui et quisquam. At suscipit in voluptatem. Consectetur et beatae.\n\nAut doloremque recusandae qui. Iusto nulla est est ipsam recusandae aut error voluptas. Asperiores officiis cum iusto quisquam sunt sed. Officiis suscipit velit. Molestias aut voluptatem saepe in nobis doloremque et deserunt facilis. Minima ut ipsa nostrum eveniet doloribus repellendus.\n\nConsequatur corporis at tenetur earum rerum dolor in pariatur vel. Enim voluptatibus qui totam excepturi tenetur fugit nemo est. Dolor asperiores dignissimos molestiae assumenda dolorum tempore sed voluptatem minima. Voluptatum et qui ut ut.\n\nQui adipisci distinctio dolores qui velit et blanditiis eum officia. Esse minus expedita eos aperiam earum. Quidem possimus non dolores ut voluptate et optio vel.\n\nIusto odio hic sint rem asperiores nesciunt nemo est molestiae. Voluptatem aut error aut exercitationem. Unde est illum architecto repellat eum omnis quo. Soluta dolorum officia numquam unde. Quis soluta sed consequuntur explicabo quo voluptatem repudiandae. Optio porro harum necessitatibus doloribus possimus omnis.\n\nQuasi est aut. Molestiae doloremque nulla ducimus alias eveniet non quam alias. Eius eos eaque. Consectetur maiores animi aut. Vel ratione ipsum quia voluptas ut minus sit minus quo.", null, null, "Example Page 1 - Paragraph 6", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("0acec16e-29d4-481e-ad4a-9de4dd91b14d"), false, null, null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 4, 26, 9, 27, 10, 222, DateTimeKind.Local).AddTicks(1019), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("174a0b7b-ebf7-4551-afb1-9992c0297e00") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("1d14d787-e749-4543-8ba2-a19d3d5dc857"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("0acec16e-29d4-481e-ad4a-9de4dd91b14d") },
                    { new Guid("f4b287d4-d310-4deb-bb62-168488a5e7fb"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("0acec16e-29d4-481e-ad4a-9de4dd91b14d") }
                });
        }
    }
}
