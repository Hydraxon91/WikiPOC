using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddCategorySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
