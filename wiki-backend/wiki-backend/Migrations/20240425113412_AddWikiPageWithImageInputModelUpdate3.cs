using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiPageWithImageInputModelUpdate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0213668d-8df1-4fb3-86b3-447efffd2828"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0c7739e0-45b9-4604-9a2a-4971ac213e01"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("109a6c23-5b38-45ea-acde-3a7f21a77f06"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1be10ed3-9f50-44d1-b78e-e3791907ab2b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3d12de9a-0260-4bb3-af8f-ac855ce85b23"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("54ce0817-e855-4662-81be-130d94de7be1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5c7b2dc2-6f97-4c4d-9dec-0b7e0b364401"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("62873b50-e2e0-41bf-967c-8da52c2e3df2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("65941ff2-e26b-4bb2-b564-2eb433100b8c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7245b760-0290-4cba-81f6-c54f3ea5cc32"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("911326a2-894d-48b6-9991-2e77bf5ce3c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("acf61efe-b136-42fe-bc5a-00a8b8bbc791"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cd7f5800-8658-4009-84e4-27a272fa912b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6c6653d-b47d-41f6-bd4e-003409e30707"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f47098da-9e17-44b9-ab1f-cbb22e4d13be"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fc1107c2-df19-45a6-b220-16be47a96a90"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0879302a-4c3e-4e1d-a605-fd0fa7c0c52b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e89156f3-6b1d-4cb6-b409-aa2ad52b9a14"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3"));

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("e89156f3-6b1d-4cb6-b409-aa2ad52b9a14"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0213668d-8df1-4fb3-86b3-447efffd2828"), "Repellat atque architecto. Voluptatem delectus autem rerum et quia quisquam optio totam illo. Non quae aliquam ratione sapiente maxime doloribus.\n\nSaepe rem atque. Quia aliquam reprehenderit voluptas. Praesentium dolore porro itaque blanditiis voluptates qui aut magnam quo.\n\nEst quis non unde asperiores voluptatibus cupiditate voluptate harum laudantium. Consequatur sit culpa quis expedita pariatur aut impedit sunt. Neque voluptatem voluptatum necessitatibus.\n\nVelit est eos esse voluptatem earum libero iure. Odio eligendi animi assumenda sapiente eaque maxime omnis distinctio. Ut labore debitis rerum. Dolores quae a. Culpa quis nihil qui sunt ipsa consequatur ex reiciendis. Libero repellendus tenetur.\n\nVoluptatem assumenda laboriosam dolor ratione id voluptas illum. Fuga nostrum non. Quae ex et dignissimos ut alias eius. Et voluptas magnam ut earum. Ut at atque ut expedita ipsa. Voluptas aliquid soluta porro explicabo omnis voluptatem.\n\nCumque ipsa veniam quia ut porro est alias modi cumque. Quos ex asperiores id. Omnis amet qui rerum qui. Dicta quia reiciendis qui. Reiciendis repudiandae amet et incidunt optio numquam dignissimos consectetur.\n\nVitae similique quae ipsum omnis nesciunt voluptatem aliquid sed ipsam. Et consequatur eius amet facere qui optio. Quia vel qui sint ex quo. Dolores omnis neque et ut voluptatem consequatur.\n\nVoluptas numquam quis excepturi. Aut dolore velit sit porro et tenetur corrupti architecto. Ducimus dolor ducimus quis ut impedit eos vero. Sunt eligendi explicabo aperiam eos. Nobis temporibus laborum expedita eligendi impedit consequatur facilis quasi et.\n\nEt ipsam eos. Quam quod qui sed quis. Unde et recusandae neque corrupti aliquid similique. Blanditiis laudantium modi. Qui provident quo nihil enim officiis deserunt aliquam omnis aspernatur. Debitis accusantium ducimus alias.", null, null, "Example Page 2 - Paragraph 3", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") },
                    { new Guid("0c7739e0-45b9-4604-9a2a-4971ac213e01"), "Ut quas voluptatem officia architecto ullam tenetur ea non explicabo. Et autem reprehenderit quia saepe rerum. Officiis illum eaque unde animi.\n\nEt voluptate iste sed aut dolores dolores. Excepturi excepturi omnis eveniet dolores. Ea expedita et vel. Labore incidunt doloremque.\n\nRepellat ea est et assumenda eligendi. Voluptatem doloribus et autem sit animi. Dolor neque eos id in suscipit nobis. Velit tempora nostrum.\n\nDelectus dolorem sit quas ipsum natus nostrum doloremque ut. Ipsum eveniet quod velit quis aut error aliquid quasi voluptatem. Ab et assumenda a odit veniam ut.\n\nEt similique id aut iusto dolorum at magni molestiae. Nesciunt ut consequatur ut. Consequuntur laborum sed molestias saepe in nemo. Dolores officia sequi nihil.\n\nConsectetur quia eligendi. Adipisci animi hic quo alias dolorum. Porro in officiis rem aut dolorem dolorum necessitatibus consequatur. Molestiae sint dolorem rerum dolor nihil necessitatibus fugit. Mollitia ut sit inventore officia sunt.\n\nAsperiores eos tenetur porro et dolor. Sint velit illo aut rerum animi magni dolorem nostrum vel. Animi exercitationem aut officiis ullam similique. Eaque soluta sunt fugiat sit sed.\n\nAut natus neque. Nihil non eveniet facilis occaecati ea dolorem eum voluptas in. Nihil animi enim non accusantium esse sequi. Sed voluptas qui sed nobis maxime eaque qui. Dolor sed dolorem aliquam laboriosam cupiditate iure dolorem.\n\nRecusandae beatae aut voluptatum et nam consequuntur omnis deserunt. Nihil tempora autem et dicta. Incidunt officia quis. Culpa vel voluptate repellat et illum provident debitis. Doloribus aut impedit est nulla.\n\nReprehenderit deserunt fugit quo sequi et est tempora. Iusto quibusdam voluptatibus molestiae repellat. Aut voluptatibus voluptatem atque enim error qui. Est est aut corporis dolorem. Porro totam molestiae delectus quia earum ut aspernatur est.", null, null, "Example Page 2 - Paragraph 6", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") },
                    { new Guid("109a6c23-5b38-45ea-acde-3a7f21a77f06"), "Ut blanditiis nemo libero incidunt molestias sed voluptatem aperiam. Modi et recusandae est maxime magnam sint in quod. Dolorem et magnam autem.\n\nRerum laboriosam nemo dolorem ipsa. Et necessitatibus ipsum porro nihil amet quaerat reiciendis. Quia optio incidunt. Est enim explicabo dolorem dolore saepe nisi dolorum. Enim at ut et. Quia ut voluptas enim sed.\n\nRepellendus officia iure nesciunt aut facilis. Et officia dolores aut nostrum sit est. Nihil est laudantium exercitationem assumenda voluptatem quasi. Fugit vel in aut sequi eius omnis. Magnam officia quis nihil nesciunt ex.\n\nHarum sint ipsa velit error veniam dolore. Aut quas consectetur est et autem libero laudantium sint. Et cumque maxime dignissimos. Sequi incidunt provident dignissimos laudantium. Ducimus neque nemo ullam rerum occaecati sed occaecati.\n\nCorporis ipsam possimus ut sed natus vel aut. Perspiciatis quam dignissimos. Similique iure occaecati sequi. Est est animi vitae sed voluptatem ratione. Odit inventore amet enim.\n\nAmet tempore quia distinctio aut dolorem facilis nesciunt aut officia. Autem et minus. Velit pariatur et voluptatum aut. Velit nisi impedit ad voluptatibus. Minima debitis dolore eum et modi temporibus nulla aut ut. Cupiditate ut eum voluptatem vel quibusdam praesentium est.\n\nFugiat provident iste consequatur. Nemo harum repellat et quia maxime tempore itaque quibusdam. Delectus fugit et.\n\nNisi harum porro rem perferendis fugiat sapiente. Sunt itaque et quae minus expedita laborum reprehenderit ut. Nesciunt repudiandae pariatur aut cum maiores. Est optio consequatur optio deleniti optio.\n\nError deleniti rem quo quia cum autem. Illo quisquam eius blanditiis assumenda. Rerum quos inventore illum quas ut ea optio. Earum quia debitis eum est omnis. Rerum possimus sit delectus id aut et. Rerum vel odit adipisci voluptas ex veritatis non deserunt sed.\n\nQuia ipsa aut facere neque. Eligendi excepturi quisquam. Culpa dolor qui sint hic qui numquam. Nesciunt expedita eveniet aut similique ea iure ex. Nihil laboriosam laboriosam totam autem qui doloribus repellat sint.", null, null, "Example Page 2 - Paragraph 2", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") },
                    { new Guid("1be10ed3-9f50-44d1-b78e-e3791907ab2b"), "Ex quos assumenda at ducimus asperiores eum libero provident quia. Quis tempore est. Blanditiis ea quas doloribus qui non. Quisquam sed laudantium nulla aut cum ab ipsam necessitatibus in. Sint iusto voluptas. Totam sequi maiores est atque et non.\n\nLaborum sunt enim laboriosam natus porro eius aut. Quaerat quia dolorem at quidem vel consectetur inventore in reprehenderit. Placeat recusandae voluptas. Ut blanditiis velit voluptas.\n\nReprehenderit commodi optio vel voluptatem dignissimos. Asperiores nihil voluptatibus a. Ea perferendis aut autem. Natus dolorum quae architecto laudantium nesciunt occaecati enim consequuntur numquam. Recusandae dolores non ut sunt. Rerum voluptas facere ullam voluptatem asperiores.\n\nEt omnis cupiditate eum reprehenderit. Nostrum accusantium iusto fuga voluptatem autem suscipit. Praesentium qui voluptatem aut. Quia iure voluptatibus.\n\nEt qui enim aperiam nesciunt accusamus. Iure et odit harum quisquam ad et reprehenderit rerum saepe. Quia culpa provident debitis nostrum distinctio quibusdam explicabo voluptatem exercitationem. Distinctio ut sunt est architecto. Recusandae saepe corporis in quo nostrum culpa.\n\nVelit natus consequatur. Sit velit et est repudiandae assumenda nisi tempore. Veniam reiciendis aliquid ut non dolorum qui quod et quaerat.\n\nDicta blanditiis iste ut reiciendis necessitatibus magni. Iusto at vel placeat. Placeat iusto itaque eligendi autem et odio nam est. Amet unde nobis enim placeat similique officia iure aut. Consequuntur a ratione voluptatem assumenda. Quia odio sapiente.\n\nVoluptate autem est id maxime. Cumque architecto est repellat iure sit ad veritatis. Commodi alias facilis temporibus illo asperiores at est. Modi modi ipsam dolor.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("54ce0817-e855-4662-81be-130d94de7be1"), "Maiores minima est optio natus esse. Velit aut ipsum velit autem magni voluptatem deserunt. Eum cum expedita. Dolore facilis optio.\n\nNemo iure assumenda. Labore odio placeat occaecati. Quos pariatur delectus. Eum aliquam dignissimos fugiat sit dolor aut. Iusto quisquam quos ratione ut beatae a voluptas eius. Voluptatem sed magni exercitationem ut rerum suscipit commodi.\n\nAmet dolores quisquam ex error qui dolorum mollitia dolores esse. Ipsum necessitatibus aperiam. Incidunt aperiam saepe porro ipsum. Ullam repudiandae sequi est aliquid doloremque ea dolore cum ducimus. Repellat consectetur error debitis porro.\n\nQui et asperiores culpa non accusamus rerum saepe fugiat quas. Ab non rem aut est velit ipsam reprehenderit illum. Voluptas aperiam omnis accusantium rem aliquam.\n\nReprehenderit assumenda ut ullam eos dicta sed. Aut maxime pariatur quos. Sint laborum delectus voluptatibus qui. Aspernatur accusantium unde corporis quam facere inventore. Et et deserunt magni nostrum aut blanditiis dicta voluptatem ab.\n\nExplicabo necessitatibus sed nihil praesentium id eos minima consequuntur unde. Quo et et fugit labore ad et. Ipsum rerum autem et mollitia impedit.", null, null, "Example Page 2 - Paragraph 4", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") },
                    { new Guid("5c7b2dc2-6f97-4c4d-9dec-0b7e0b364401"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("e89156f3-6b1d-4cb6-b409-aa2ad52b9a14") },
                    { new Guid("62873b50-e2e0-41bf-967c-8da52c2e3df2"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("e89156f3-6b1d-4cb6-b409-aa2ad52b9a14") },
                    { new Guid("65941ff2-e26b-4bb2-b564-2eb433100b8c"), "Neque tenetur molestias explicabo quia ut assumenda impedit repellendus voluptas. Quia assumenda quam est ut. Occaecati fugiat cupiditate.\n\nAut voluptates et commodi. Dignissimos non provident. Et adipisci dolorum praesentium aut molestiae aut perspiciatis nesciunt repellendus. Reiciendis est quaerat. Ut nostrum et cumque nobis numquam esse cum enim ea. Praesentium exercitationem illum dolor aliquam veniam ipsa.\n\nCorrupti autem omnis eos tenetur repellendus est doloremque dolorum. Minima reprehenderit quisquam quia. Explicabo quia minima qui est odit iste tempore porro. Voluptatibus culpa voluptatem vero est ducimus in soluta ipsa non. Id atque aliquid sed at saepe et at porro velit.\n\nSit totam quisquam modi id non. In harum sint nostrum. Aut iusto sapiente in qui. Velit voluptatum sed esse. Tempore inventore ducimus ex voluptates sequi ea ut in placeat.\n\nEst vel hic vitae excepturi perspiciatis corporis illum quis eos. Aut reprehenderit nemo voluptatum. Repellat illo id quos fugiat porro hic. Sit neque explicabo veniam sit quos unde nesciunt aut ea. Recusandae qui blanditiis mollitia quia non incidunt eius.\n\nVoluptas nesciunt laboriosam. Tempore enim minima ad. Ut dolorem eius amet sed natus voluptate dignissimos dolorum.", null, null, "Example Page 2 - Paragraph 5", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") },
                    { new Guid("7245b760-0290-4cba-81f6-c54f3ea5cc32"), "Doloribus dolorum tempora ipsa. Deserunt dolorum id. In est harum. Et ad eaque aliquam.\n\nEt in nisi. Explicabo dicta molestiae aut et non aut illo. Esse est id. Id optio non et enim optio.\n\nPraesentium fuga velit expedita quae ab quos consequuntur. Neque repellendus repellendus. Reiciendis tenetur minus et aspernatur neque ut.\n\nIure quas et et vel voluptatibus quisquam repellat. Exercitationem dolorum veniam voluptatem quibusdam numquam eos. Provident aspernatur harum sint recusandae. Id ipsam libero quia velit odit totam inventore. At sed quibusdam.\n\nBlanditiis animi at minima eum. Exercitationem dolorem adipisci quo ex minus dolorum ducimus. Sit soluta nam eos possimus consequatur id. Dolor repellendus nisi molestiae et cupiditate magnam earum. Mollitia quod ea aperiam iure voluptas assumenda hic eum placeat. Aut magni quae libero magni architecto illo ut.\n\nQui excepturi commodi qui occaecati voluptate sint rerum temporibus maxime. Nostrum nisi sit autem et quibusdam qui possimus ducimus. Unde ea et numquam aut quos voluptate nulla ab autem.\n\nFuga magnam in sit voluptates dolor. Laboriosam sunt corrupti voluptatem. Ut non molestias illo. Dolor excepturi eum quis a.\n\nVoluptas veniam tenetur quis fugit dignissimos ea. Vel non voluptatem sed nihil aut distinctio non. Suscipit ratione et cum ut ut itaque.", null, null, "Example Page 1 - Paragraph 2", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("911326a2-894d-48b6-9991-2e77bf5ce3c0"), "Dolorem excepturi sit nisi labore dolorem dolore ducimus. Id vel commodi. Optio officiis ut odit vel temporibus quos eaque.\n\nAd tenetur est architecto a. Eum exercitationem ut similique sit autem id quo est facilis. Quia perferendis voluptatem quia placeat sed. Illo quaerat iste qui quibusdam. Voluptatem est autem magni illum laudantium nam nihil qui quam. Dicta sapiente iusto velit.", null, null, "Example Page 1 - Paragraph 6", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("acf61efe-b136-42fe-bc5a-00a8b8bbc791"), "Sed maiores libero. Vero est minus qui aspernatur qui et nemo et. In dignissimos dolore dolores qui occaecati. Dolores inventore voluptas id autem sint in esse atque. Quia ad voluptas debitis non qui.\n\nDolorum deserunt saepe omnis quod aut praesentium odio omnis dicta. Est rem odit repudiandae non quis sunt maiores dignissimos pariatur. Ut labore voluptatem neque eaque. Quam et est totam.", null, null, "Example Page 1 - Paragraph 5", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("cd7f5800-8658-4009-84e4-27a272fa912b"), "Quam aut et sed nesciunt. Eveniet nihil asperiores. Quas nihil et cumque fuga. Eius et ex voluptatem et quo. Facilis quae non. Suscipit quas et quod et quasi.\n\nInventore voluptatem nemo iure accusantium iure est fugit numquam. Rem fugit corrupti. Placeat error facilis accusantium. Inventore qui error quia voluptatibus qui tempore. Nesciunt aut quia nisi ea. Voluptatum vitae ut sit qui enim sed ut ab est.\n\nDelectus eligendi in aut. Beatae tempore qui in adipisci illum laboriosam autem consequatur. Ducimus quo repellat. Aut placeat voluptatem qui odio qui. Assumenda voluptatum minima libero repellat sequi fugiat itaque minima.\n\nOccaecati quia similique quisquam aut velit neque amet. Enim voluptate qui deserunt architecto et reprehenderit mollitia. Autem accusamus et magni commodi id dolor labore dicta.\n\nEveniet illo aut nihil perspiciatis ipsa quaerat. Quasi asperiores voluptatibus quos repellendus dicta aut. Sed hic eum possimus et occaecati laborum dolores aliquid et. Quis mollitia et ea voluptas. Et libero ut excepturi voluptatum qui ipsam aut et.\n\nTempore similique alias sunt. Incidunt doloremque quasi. Debitis aut cupiditate. Aut dolorem quis quae ut. Magni ut ab ex nostrum itaque doloribus.\n\nEt quis sint at dolorem. Nostrum facere est voluptate aut ullam tenetur. Iusto qui ab vero esse. Qui ut in id fugit quo. Quis nostrum et. Quos iusto qui ut ipsa cum.\n\nQuo consectetur quo ut in reprehenderit in nesciunt id. Quod enim et. In excepturi omnis quibusdam voluptatibus earum omnis numquam optio.\n\nNobis in at mollitia architecto omnis asperiores ab amet. Sed et quia temporibus distinctio veniam consequatur ut ut esse. Minus culpa ea quae amet. Distinctio in aut odit quam rem tenetur. In voluptates quis ut saepe est sequi doloremque. Occaecati omnis voluptates ratione.", null, null, "Example Page 1 - Paragraph 4", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("f47098da-9e17-44b9-ab1f-cbb22e4d13be"), "Ipsa alias numquam adipisci culpa. Aperiam perspiciatis corrupti occaecati sed natus. Vitae est beatae quam occaecati hic ratione.", null, null, "Example Page 1 - Paragraph 3", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") },
                    { new Guid("fc1107c2-df19-45a6-b220-16be47a96a90"), "Quasi aut unde placeat nulla. Eligendi perspiciatis quo quisquam quod et consequatur. Ex odit sapiente architecto sint sed alias porro quam et. Aut quia ut fugit recusandae id eveniet animi ab. Maiores sapiente consequatur non porro alias aut maiores fugiat. Et magnam in deserunt dolorum officiis rerum hic.\n\nFacere fugiat aut quos distinctio dolores maiores expedita maiores. Tempore ut officiis ut distinctio distinctio quasi. Commodi repellat vitae et reprehenderit. Deserunt repellendus molestias labore exercitationem et autem non voluptate aut. Repudiandae eveniet iusto autem in aut eum voluptatum voluptas ex. Ducimus illum porro eaque nulla ut error dolore non autem.\n\nEt cupiditate quaerat aut sed eaque impedit libero soluta. Tenetur quasi quos voluptate quia et voluptates et. Corrupti vero eveniet nostrum.\n\nDolorem harum eaque eligendi exercitationem aut assumenda aut. Voluptatibus velit commodi minima nemo aliquam porro consequuntur quas. Quo autem hic nobis expedita optio est. Vero voluptates in veritatis beatae. Sed eum voluptatum.\n\nAmet quibusdam eligendi accusamus molestiae dolorem et. Labore ut eligendi vero eaque quis aut et aut. Non sunt expedita quidem qui veritatis aperiam architecto sequi omnis. Velit culpa debitis quasi animi totam omnis.\n\nDolores rerum fuga. Quidem et aperiam fuga. Qui similique non non debitis atque. Velit illum est iure enim et. Reprehenderit harum qui et occaecati.\n\nDignissimos excepturi aliquam consequuntur possimus. Possimus assumenda dolorem. Est cum et eveniet natus molestias dolor. Sit nisi sed quis aut optio modi in. Ut impedit qui maiores. Dicta temporibus aut at enim.\n\nVoluptatem ad autem. Voluptatum aut in non aut quasi est et aut et. Eveniet minima omnis nemo.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("02ac3a82-937d-44ae-a079-a12acd5fbfba") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("0879302a-4c3e-4e1d-a605-fd0fa7c0c52b"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("26f07f82-8e80-480d-84b6-7d03c7d356b3") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("3d12de9a-0260-4bb3-af8f-ac855ce85b23"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("0879302a-4c3e-4e1d-a605-fd0fa7c0c52b") },
                    { new Guid("d6c6653d-b47d-41f6-bd4e-003409e30707"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("0879302a-4c3e-4e1d-a605-fd0fa7c0c52b") }
                });
        }
    }
}
