using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySeeding2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1c98ac51-192c-413d-9f0a-c2898599b151"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4bf92abf-bcc6-486e-8188-73be45522602"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("523d7db5-d6a3-4677-9a64-f8e189651f6c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82244d21-a880-43c2-affd-ad1d5f0f5009"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83624968-0f97-4954-a952-a4dc92731c3c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("87a69cd8-9689-4ec1-b9bb-00e84eee06d2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8cf75655-bf3a-4082-b8c9-18b7353191db"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a1e3257-f680-45ce-ac90-e30ea73d88df"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9eb498f8-cd4d-48e1-946a-121907da30b8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c6912188-e198-40a9-b448-da052a5a02ea"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddbad4c2-10ae-4ec3-bdee-dc4d584c5cba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec849a0b-3580-47a4-98ce-25a485f4e6bd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("050301e6-2360-480c-b0ed-a108f8cd82bb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("190fc036-e11e-4ec3-aa98-9e8d4b44afea"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3aaa614a-8a51-4c5f-9f67-e1a7ae2d243e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("453e2ede-957c-49bc-b518-749efa2d6a6a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4cacc6a7-001d-4404-960e-dd2b1183537f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("72f573da-b322-4a60-8152-064e6de4cd23"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7d527010-9b5e-416a-808c-74f80767a2f1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("82ac5776-0447-408c-a9df-97d426a6d0ff"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("82c2d12d-ee60-4fa8-b456-ae09de6bd032"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8eb0c849-4b46-4064-9609-eade689467f5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8fcb009a-e309-499e-9649-642528b404ed"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9d1a985f-73d1-4d4c-9087-624106526577"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b4926123-a196-42bd-9485-7b6ecfbb536e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d0573a31-9a57-4698-9841-28b0c23e5c3f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d4fc4989-b4b4-4cee-a846-92327577afcb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f88395b5-4490-43e7-8419-97c8afc380cb"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("8b76f0b0-01ba-4fe5-b8f1-48718c2be071"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("b6225881-7982-403b-9876-a4fbbd221acd"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("cc222847-863e-4712-9b08-02835a0c43f4"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5"));

            migrationBuilder.DropColumn(
                name: "Category",
                table: "WikiPages");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "WikiPages",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_WikiPages_CategoryId",
                table: "WikiPages",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_WikiPages_Categories_CategoryId",
                table: "WikiPages",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WikiPages_Categories_CategoryId",
                table: "WikiPages");

            migrationBuilder.DropIndex(
                name: "IX_WikiPages_CategoryId",
                table: "WikiPages");

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

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "WikiPages");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1c98ac51-192c-413d-9f0a-c2898599b151"), "Stories" },
                    { new Guid("4bf92abf-bcc6-486e-8188-73be45522602"), "Arts and Entertainment" },
                    { new Guid("523d7db5-d6a3-4677-9a64-f8e189651f6c"), "Concepts" },
                    { new Guid("82244d21-a880-43c2-affd-ad1d5f0f5009"), "Sports and Recreation" },
                    { new Guid("83624968-0f97-4954-a952-a4dc92731c3c"), "Locations" },
                    { new Guid("87a69cd8-9689-4ec1-b9bb-00e84eee06d2"), "Food and Drink" },
                    { new Guid("8cf75655-bf3a-4082-b8c9-18b7353191db"), "Technologies" },
                    { new Guid("9a1e3257-f680-45ce-ac90-e30ea73d88df"), "History and Culture" },
                    { new Guid("9eb498f8-cd4d-48e1-946a-121907da30b8"), "Events" },
                    { new Guid("c6912188-e198-40a9-b448-da052a5a02ea"), "Science and Technology" },
                    { new Guid("ddbad4c2-10ae-4ec3-bdee-dc4d584c5cba"), "Characters" },
                    { new Guid("ec849a0b-3580-47a4-98ce-25a485f4e6bd"), "Organizations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("b6225881-7982-403b-9876-a4fbbd221acd"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 30, 20, 27, 50, 435, DateTimeKind.Local).AddTicks(6501), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("cc222847-863e-4712-9b08-02835a0c43f4"), false, null, null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 4, 30, 20, 27, 50, 435, DateTimeKind.Local).AddTicks(6607), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5"), null, null, "WikiPage", null, true, new DateTime(2024, 4, 30, 20, 27, 50, 435, DateTimeKind.Local).AddTicks(6464), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("050301e6-2360-480c-b0ed-a108f8cd82bb"), "Pariatur qui repellat dolorem repellat omnis illum. Voluptas impedit illum ducimus magnam architecto nam qui dolore sunt. Est eius voluptates.\n\nDolor omnis voluptate nisi quo eos in dolor molestiae aperiam. Harum velit perferendis debitis iusto mollitia. Harum culpa voluptatem est nulla consequuntur blanditiis recusandae explicabo incidunt.\n\nIn autem totam ipsa consequatur recusandae et enim soluta dolore. Doloribus dignissimos quaerat occaecati ut sint. Eum et nihil ut eius iusto quisquam. Dolorem optio iste. Nemo nam mollitia et voluptatibus inventore nobis doloribus modi alias.", null, null, "Example Page 2 - Paragraph 2", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("190fc036-e11e-4ec3-aa98-9e8d4b44afea"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("cc222847-863e-4712-9b08-02835a0c43f4") },
                    { new Guid("453e2ede-957c-49bc-b518-749efa2d6a6a"), "Dolores voluptatem harum enim et consectetur corporis quasi est temporibus. In voluptatibus expedita quis quia eum ut. Natus vitae id ut quae suscipit. Sit sunt maiores aliquid.\n\nPlaceat libero repellendus ab adipisci repudiandae possimus tempore voluptates nemo. Rerum ipsa autem esse explicabo. Doloribus nesciunt aliquid illo dolorem at explicabo. Odio mollitia magnam est dolor dolores sequi ut ex expedita. Ut et ducimus cupiditate nesciunt consequatur nesciunt iure omnis.\n\nDignissimos dolor reprehenderit nisi iusto. Reiciendis itaque quam quasi ad. Quo dolor voluptatum laboriosam est necessitatibus voluptatum dignissimos aliquid. Omnis sunt est et nobis explicabo exercitationem accusamus. Et tempore suscipit aut.\n\nAssumenda optio est ut. Nisi aliquid eligendi. Velit reiciendis dolorem eligendi voluptatem tempore minus quasi. Dicta aut explicabo repudiandae unde nesciunt fuga sunt. Omnis exercitationem ad ut.\n\nCum ex facere earum. Eveniet doloribus consequuntur sed ipsam doloremque et. Natus iste qui consequuntur nihil qui. Dolor sed et eaque nobis voluptatem fuga vel perspiciatis ea.\n\nAut dolores dicta minima et doloremque. Commodi voluptatem animi architecto. Ut quisquam harum. Sunt quia reprehenderit ipsam cum qui. Totam eum rerum molestiae aut ullam.\n\nIn sint quia qui aut. Aut quos quia nemo. Cumque quae voluptatem animi perspiciatis sunt error sunt provident incidunt. Asperiores ut magnam ullam libero laudantium.\n\nTenetur harum maiores ratione fugit deserunt. Quas ut enim tenetur sed ut impedit voluptates rerum ipsa. Est perspiciatis voluptatibus alias occaecati voluptates maxime sequi molestiae. Expedita adipisci tempora. Sit deserunt enim est eum.\n\nTempora facere dolor natus. Ratione dolor consectetur. Ducimus cumque debitis cumque rerum. Non atque et quisquam tempore recusandae quisquam maxime dicta et.", null, null, "Example Page 2 - Paragraph 5", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("72f573da-b322-4a60-8152-064e6de4cd23"), "Incidunt soluta labore. Rerum expedita amet delectus sed asperiores dolorem adipisci est quasi. Aut quas vel consectetur. Et est vitae. Qui architecto repellendus consequuntur. Incidunt rerum aut illum totam accusamus sit mollitia natus.\n\nQuia ad architecto magnam est veniam optio fugiat. Eos non fugiat doloremque eius voluptates voluptas voluptas ad. Illo dolores consectetur et labore animi consectetur. Architecto eveniet consequuntur debitis.\n\nUllam delectus quia veniam nemo. Voluptas temporibus quae voluptates qui minima dignissimos. Quasi et in quia. Quia aut ut sit nesciunt et explicabo aut. A occaecati nemo quos aliquam laboriosam harum nemo suscipit ea.\n\nId illo iusto quam consequuntur et. Doloribus quia iure natus recusandae sint assumenda fuga. Accusantium est saepe voluptates consequuntur ratione doloremque. Autem praesentium ut minima dolorum atque. Consequuntur culpa nemo totam et expedita.\n\nConsectetur enim officia adipisci et qui nostrum vero. Reprehenderit reprehenderit vel sint fugiat praesentium alias. Occaecati dignissimos occaecati ipsum. Sunt corrupti quas qui nihil et. Debitis vitae soluta voluptatem ut et nam est voluptas et.\n\nLibero quasi molestiae odio assumenda suscipit animi et doloribus facilis. Itaque sed fugit rerum voluptatum sunt. Voluptates reiciendis tempore corporis ratione. Mollitia voluptatem ducimus at voluptatum et. Molestias quibusdam aspernatur consequatur rerum molestiae praesentium et sequi et. Dolores numquam voluptates.", null, null, "Example Page 2 - Paragraph 4", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("7d527010-9b5e-416a-808c-74f80767a2f1"), "Quas veniam ducimus consequatur molestiae corporis adipisci odit. Eaque quam fugiat qui. Excepturi ad nulla. Deleniti quaerat earum labore praesentium tempore doloribus.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("82ac5776-0447-408c-a9df-97d426a6d0ff"), "Maxime aperiam quam maiores odio aut vitae. Tempore et velit iure incidunt. Itaque assumenda aut et mollitia sequi et exercitationem dolores. Quos odio eaque. Accusantium et voluptatem.\n\nIpsa hic assumenda magnam suscipit consequuntur temporibus. Repellat et mollitia sed est et natus saepe nisi. Sit dolorem earum tempora. Quia ad magnam reprehenderit omnis ex culpa. Illum nobis velit quo.", null, null, "Example Page 2 - Paragraph 6", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("82c2d12d-ee60-4fa8-b456-ae09de6bd032"), "Provident rerum quae cumque sint. Deleniti eaque sit accusamus laboriosam corrupti explicabo eos et cupiditate. Ut qui nisi. Voluptas id nemo ea aut nisi.\n\nCommodi quo voluptatibus nostrum at error voluptas esse sit. Ullam excepturi quia. Enim non assumenda expedita.\n\nEt molestiae rerum unde neque delectus quia impedit fugit architecto. Incidunt aut architecto nemo nihil deserunt asperiores facilis accusantium. Qui tempora id accusantium id est. Quia quibusdam iste. Laboriosam laboriosam dolor rerum quae perspiciatis sit quae ipsum. Ipsa ducimus ut repellendus magnam quos vel temporibus quasi.\n\nRem et praesentium unde rerum rerum placeat. Esse similique nihil neque nulla. Nemo consequuntur dolorem. Magni aliquid delectus molestiae dignissimos ea ex optio assumenda ea.\n\nOmnis magnam dolores odio nemo quia libero dolor totam quia. Consectetur unde occaecati qui et. Consequatur quo voluptas libero vel quasi.\n\nOmnis voluptatem voluptatem. Omnis magni id labore hic. Quibusdam ut ab qui minus aut quis vel nihil et. Nam incidunt tempora placeat voluptatibus vitae aut. Cum impedit architecto quia neque.\n\nFuga qui sint explicabo eligendi enim architecto cumque harum. Aut ut quisquam corrupti qui tempore nostrum. Nesciunt quibusdam recusandae impedit reiciendis. Voluptas esse facere qui magnam est et non corporis. Laborum et eaque laudantium molestiae ut facere. Ut voluptatem aut laboriosam aspernatur explicabo eum aut.\n\nVitae amet voluptatum nostrum. Quia natus aspernatur maiores. Dolorem et consequatur molestiae. Eos possimus molestiae.\n\nDoloribus fugiat facilis a et. Quia ipsam quod et ipsum voluptatem. Dolores ut consequatur assumenda quo expedita voluptates voluptas velit. Reprehenderit corrupti vitae dolorem. Voluptate voluptatem molestias commodi. Qui tempore a sint accusamus.\n\nVoluptates magni eum sunt earum illo est fugit fuga. Consequatur a dolorem qui itaque commodi itaque. Saepe culpa laborum.", null, null, "Example Page 1 - Paragraph 2", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") },
                    { new Guid("8eb0c849-4b46-4064-9609-eade689467f5"), "Consequatur libero rem qui qui sunt provident error consequuntur. Neque laborum modi mollitia. Pariatur cumque sequi.\n\nAt velit ex velit facilis aperiam recusandae dignissimos. Tempore ut iusto praesentium. Aut voluptatem impedit animi. Harum qui quis veritatis.\n\nBeatae et illum voluptates non tempore quis consequatur cumque ab. Recusandae dicta non facilis quas sit laborum vitae consectetur itaque. Sunt ea qui non nobis voluptate aut quia.\n\nMaiores ratione iure dicta corrupti sapiente aut asperiores est eos. Ut qui aut est est exercitationem non porro sit illum. Nisi provident et. Repellat omnis voluptatem est minima quod quidem veniam.\n\nRerum modi assumenda iste consectetur beatae et. Ab facilis reprehenderit quisquam officiis delectus. Est provident qui eveniet blanditiis explicabo qui. Animi occaecati omnis et blanditiis aperiam. Voluptatum excepturi iusto qui. Voluptatem nisi sunt ratione dolorem maiores enim consequatur.\n\nConsequatur repudiandae necessitatibus expedita voluptas ut id dolore aliquid. Tempora ut voluptatem odio nisi sapiente pariatur. Aut voluptatem similique aut rem ut et harum blanditiis dicta.", null, null, "Example Page 1 - Paragraph 5", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") },
                    { new Guid("8fcb009a-e309-499e-9649-642528b404ed"), "Et ullam est dolorum repudiandae ipsa. Ut vitae in. Sint eveniet et aut quia laudantium quo quia. Quis et molestias officiis aliquid ea ratione et unde. Nisi voluptatibus occaecati voluptatem ut delectus dolores ullam.\n\nQuaerat ut eveniet. Deleniti explicabo laboriosam in labore illum recusandae eius. Delectus dolor voluptatibus voluptatibus est.\n\nVoluptas qui facilis occaecati harum consequuntur voluptatum quis qui. Expedita saepe quia consequatur. Eum quia at aut quisquam. Inventore saepe enim velit deserunt. In velit similique. Tempora dolores labore mollitia esse nesciunt quia.\n\nOfficiis sint sit enim voluptas nulla quo ducimus et esse. Nobis doloribus nihil. Consequatur accusamus perferendis maiores quibusdam enim sed id. Quisquam rerum et qui. Et qui nesciunt eos eos necessitatibus. Enim est tempora facilis exercitationem corrupti occaecati earum enim.", null, null, "Example Page 1 - Paragraph 4", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") },
                    { new Guid("9d1a985f-73d1-4d4c-9087-624106526577"), "Et sit quae unde est quae autem fuga. Numquam accusamus quia modi rem magnam eligendi eos libero. Rerum velit deleniti. Beatae iure facilis at iste tenetur vitae omnis sunt laudantium. Et voluptatem et accusantium porro.\n\nDolor vero non ab qui nobis est quod iste eos. Aut vel quas tempore odit ut minima velit qui. Nam et tempora adipisci distinctio quam ipsum eius. Corrupti aliquid velit nesciunt.\n\nSed expedita vel. Aut fuga qui provident corporis aliquam totam perferendis in est. Repellat dolor rerum sunt dolores maiores vero ducimus deserunt placeat. Non quas suscipit voluptate incidunt quo. Quia beatae tempora sapiente quibusdam.\n\nOccaecati consequatur et ipsam qui et illo reiciendis necessitatibus. Aut qui voluptatem minus voluptatem. Sunt amet eligendi modi quis ad dolore natus odio. Libero nemo itaque inventore.\n\nAsperiores et omnis sed quis et est minima eaque. Velit qui architecto ducimus ea repellat dolorem officiis. Voluptate inventore dignissimos ad non nihil est. Et asperiores delectus commodi minima velit omnis perferendis. Necessitatibus natus in nulla veniam.\n\nMolestias expedita cumque recusandae nihil deserunt praesentium. Quas laudantium ad. Et tempora consequatur qui voluptatem.\n\nPariatur nihil laudantium sint sit cumque voluptatem. Perferendis voluptas consectetur provident nihil consequatur. Quisquam velit harum quaerat autem. Qui non est. Perspiciatis quam ipsam esse amet quos enim sunt. Ducimus sapiente ipsum.\n\nQuod tempore doloremque nostrum tempora veniam eaque. Omnis harum temporibus beatae possimus. Veritatis ex consectetur. Rerum expedita error earum cupiditate laudantium.\n\nAut veritatis sunt tempora ratione deserunt et. Aut commodi sed molestiae accusamus sed qui ut aliquid. Ratione corrupti at voluptate qui nesciunt.", null, null, "Example Page 1 - Paragraph 6", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") },
                    { new Guid("b4926123-a196-42bd-9485-7b6ecfbb536e"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("cc222847-863e-4712-9b08-02835a0c43f4") },
                    { new Guid("d0573a31-9a57-4698-9841-28b0c23e5c3f"), "Tempora quidem animi aliquam expedita et. Totam possimus et. Id nisi iste odio. Commodi perferendis laboriosam blanditiis qui corrupti exercitationem. Voluptates ipsa iste. Temporibus dolorem iste aut tempore nulla eos aperiam quia tenetur.\n\nNon placeat pariatur. Ut hic rem nihil maiores laudantium sit distinctio. Libero distinctio nihil officia porro suscipit quas est placeat enim. Ut veritatis beatae voluptatem voluptatem et voluptatem aspernatur et molestiae.\n\nEt in est et est temporibus et quis. Nihil autem temporibus mollitia animi cumque. Nulla qui aut accusamus et unde.\n\nDeserunt et dolorum assumenda sed magnam. Fugiat dolor odio odio reiciendis fugit nemo quis deserunt. Quis voluptas voluptatem ipsam assumenda. Veniam occaecati vero reprehenderit explicabo minima. Unde omnis recusandae est quis aut culpa.\n\nEa delectus fugit est reiciendis praesentium incidunt odio quibusdam eveniet. Vel reiciendis est. Vitae dicta officiis inventore expedita mollitia adipisci.\n\nSint sit et iste pariatur totam autem. Aut facilis et aut. Architecto praesentium consequatur laboriosam corrupti ea. Corrupti quia velit ab dignissimos repellat.\n\nVelit magni tempore quas atque esse. Eaque et molestias vero reprehenderit. Velit quo est ut et atque similique aperiam temporibus. Dolor voluptas cum et assumenda fugit iste expedita fugiat. Quam aut voluptates recusandae vel reiciendis et illum. Facere quia libero laboriosam optio.", null, null, "Example Page 2 - Paragraph 3", new Guid("b6225881-7982-403b-9876-a4fbbd221acd") },
                    { new Guid("d4fc4989-b4b4-4cee-a846-92327577afcb"), "Optio provident voluptas eveniet autem. Sit maxime reprehenderit assumenda in qui modi labore. Doloremque sit nam dicta pariatur. Iusto reiciendis omnis magnam. Provident voluptatem maxime numquam. Id delectus nulla omnis unde.\n\nTempore ut nihil facilis eius rerum fugiat magnam possimus. Ullam earum deleniti natus beatae saepe et. Velit et nam non.\n\nQui et quia porro fugiat aut eligendi quo. In aut et eaque nihil neque iure ex. Vel officia reprehenderit qui consequatur eaque aliquid aut deleniti. Occaecati eveniet quibusdam recusandae. Aliquam veritatis laudantium qui ipsum ut soluta. Quis vel vel totam perferendis veniam dolore soluta blanditiis.\n\nEst sed ut est. Vero rerum soluta culpa quo. Dignissimos animi nesciunt. Dignissimos eveniet harum voluptate quod sit laborum.\n\nEaque aliquid odio nam suscipit cum. Optio nihil voluptates sit enim dolores qui et rerum. Doloremque omnis culpa tempora consequuntur enim a ea sint minima. Nesciunt vel id nihil deserunt quis et adipisci dolores praesentium. Repellat voluptas deleniti a qui. Quae aut praesentium hic voluptas reiciendis iste quibusdam molestias.\n\nEx et soluta ab dolores quia enim qui consequatur. Aut sapiente et molestiae cum dolore modi quaerat illo hic. Accusantium voluptas vero voluptatum et enim corporis est amet autem.\n\nQui rerum vel culpa quo qui enim accusantium. Et magnam voluptatem tempore. Saepe iure repellendus non velit molestiae nesciunt sunt. Et omnis tempora officia quas eligendi quos rerum reprehenderit autem.\n\nDolorem quia recusandae ut eius et voluptatem eaque dolores ducimus. Quisquam dicta minus aliquid est. Minus earum deserunt voluptatem qui minima qui animi quo ipsam. Rem quibusdam adipisci similique. Necessitatibus amet aut distinctio sunt ipsam tempora sed cupiditate consequuntur. Fuga voluptate dicta.", null, null, "Example Page 1 - Paragraph 3", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") },
                    { new Guid("f88395b5-4490-43e7-8419-97c8afc380cb"), "Ea voluptate quasi voluptas eveniet. Laboriosam in nisi officia aut. Voluptatum adipisci laudantium occaecati omnis incidunt hic fugiat est. Vel cupiditate numquam nulla dolorem perferendis aut voluptatem est. In excepturi qui iste.\n\nDeleniti pariatur id ex ut vel velit. Aut qui quaerat eius blanditiis numquam error deleniti fugit. Quia odio tempora cupiditate repudiandae aut tempore autem cumque. Fuga illo sapiente vitae eius et.\n\nCorporis ratione officiis ducimus eveniet molestiae tempore. Sequi incidunt error ea molestiae ratione a. Et ex eum.\n\nQui ut fugiat odio quis recusandae dolor velit qui. Eum placeat dolorum illo eligendi repellendus nulla. Culpa enim ab assumenda. Unde ullam omnis perferendis non.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("8b76f0b0-01ba-4fe5-b8f1-48718c2be071"), false, null, null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 4, 30, 20, 27, 50, 435, DateTimeKind.Local).AddTicks(6636), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("d36fc95c-1d8c-457d-894f-31b54ca9f1f5") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("3aaa614a-8a51-4c5f-9f67-e1a7ae2d243e"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("8b76f0b0-01ba-4fe5-b8f1-48718c2be071") },
                    { new Guid("4cacc6a7-001d-4404-960e-dd2b1183537f"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("8b76f0b0-01ba-4fe5-b8f1-48718c2be071") }
                });
        }
    }
}
