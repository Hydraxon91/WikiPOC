using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUserSubmittedWPToWPwithImagesOutputModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
