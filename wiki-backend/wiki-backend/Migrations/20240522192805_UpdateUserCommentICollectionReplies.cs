using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserCommentICollectionReplies : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ReplayToCommentId",
                table: "UserComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("486701d7-6bca-41de-be5c-d6c873d62259"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("82ccea41-e762-4fbf-b9f4-09eb25519acc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("83f79cb4-dd66-42a7-bcfe-9bf16bd61b27"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("886394c5-2f7f-4a25-8ff9-21906b59bb34"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaf73d15-6397-4936-9c21-4efc5847ac81"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d7b8ced5-b422-4abb-8fac-140df15144a1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f20d2a44-a862-4737-844c-7e76cdbc32dd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f8189b87-75b2-4c54-99a9-8d8b402cd33f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("13949710-f2f8-40d1-ad32-15c7f70ab5c9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("14845805-d893-4a40-a873-560744a1638f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1f0f4c62-2dba-4a96-ac57-e8981ccb9ef8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("263361fd-cb7a-4adb-835d-5bae8c5dc651"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4ab5b349-82d6-432d-a81b-42b1d61e8811"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("641c424f-3c5a-4208-9345-32e1340d40eb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6aaceea7-0b9b-4ff0-8261-4cdb509301a2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6e2f4279-f84b-48c7-900d-0404985c250a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7d602037-172d-4052-a3ce-b8d2c9aebbf3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9ceda3b1-66df-46a2-a56d-049c51a263b4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("aea3f3c2-4697-4546-8303-ff1294cec207"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b9fd1f40-41bc-4575-bcb6-1bd682bf199a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d5eb17ba-196b-46b9-b45d-450dc7f9abcc"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("eadf5602-8dcf-4deb-835f-c4339fc8816c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("eddd231f-92c3-4acd-82fd-b96cc60ef7aa"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f3eb5529-a37a-4f34-a9b5-7e10efc1ece1"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("05b74aa9-0495-4155-acc1-f9a054314937"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("9b71ea34-4813-4372-9213-2157884e6a66"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("ce5c9452-ce09-4725-8fbb-42228fc87c5b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1f520ff3-3ad8-44a0-9d3e-c5f1c5226531"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("210839bd-2c14-47f4-9a42-728d3a84da72"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c9fbbb7-86f9-4e1d-a8e3-c8d3b9864140"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f5e96ebc-8905-44c7-8750-ac516bcc9ee2"));

            migrationBuilder.DropColumn(
                name: "IsReply",
                table: "UserComments");

            migrationBuilder.RenameColumn(
                name: "ReplayToCommentId",
                table: "UserComments",
                newName: "ReplyToCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_ReplayToCommentId",
                table: "UserComments",
                newName: "IX_UserComments_ReplyToCommentId");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("08333e40-af8d-412d-b2da-663e9355954f"), "Science and Technology" },
                    { new Guid("266e46e8-42c6-4751-98bb-f8b216692aaf"), "Food and Drink" },
                    { new Guid("32210ee1-3db3-47e9-9513-250af46c243d"), "Sports and Recreation" },
                    { new Guid("412a6b07-479e-4973-9bc7-e7a5070b1a9c"), "Arts and Entertainment" },
                    { new Guid("47fa806b-4324-4bea-be54-5771bbe6ab2b"), "Locations" },
                    { new Guid("698c635b-efb7-48f5-9776-4b671b49b41b"), "Concepts" },
                    { new Guid("6c655e2a-3639-4f05-914e-30e5b253378f"), "Events" },
                    { new Guid("9d7c3daf-03d4-415f-913d-0dd60a1a1d02"), "Technologies" },
                    { new Guid("9f8127ef-de08-4fc7-af49-fd3d8f181bb2"), "History and Culture" },
                    { new Guid("b8a91816-0463-4eb7-b079-3f30bff7f60f"), "Stories" },
                    { new Guid("ec3b51e9-8eee-403a-9b49-41cc801363cd"), "Organizations" },
                    { new Guid("ff6c5f6a-aeb5-4a8a-88df-9bebe463e136"), "Characters" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("1c9cf25b-7958-4807-92ec-432640994f0c"), new Guid("b8a91816-0463-4eb7-b079-3f30bff7f60f"), null, "WikiPage", null, true, new DateTime(2024, 5, 22, 21, 28, 5, 705, DateTimeKind.Local).AddTicks(941), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c"), new Guid("ff6c5f6a-aeb5-4a8a-88df-9bebe463e136"), null, "WikiPage", null, true, new DateTime(2024, 5, 22, 21, 28, 5, 705, DateTimeKind.Local).AddTicks(879), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("e782cd19-84ec-4304-b12c-f25d27fb304b"), false, new Guid("47fa806b-4324-4bea-be54-5771bbe6ab2b"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 22, 21, 28, 5, 705, DateTimeKind.Local).AddTicks(1238), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("1903eb36-5111-401b-8bb6-1ac806954152"), "Ut aut et dolor consequuntur in nostrum. Sunt quos reiciendis quod sed provident voluptas. Sit facilis earum impedit. Corporis odit veniam labore tempora voluptates. Consequatur voluptatibus nulla veritatis architecto vitae facilis. Quidem ipsum quia dolor non itaque.", null, null, "Example Page 1 - Paragraph 4", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("1af6c5c3-45df-482d-811f-6bc76163bff9"), "Perferendis doloremque beatae. Commodi laborum similique et voluptatem veritatis quisquam atque id. Sit et ipsam facilis debitis in. Sunt maxime eum est quis ea. At quibusdam perferendis quo et consectetur eum id totam quia.\n\nQuibusdam quam nulla totam autem aut unde. Natus qui sit quibusdam nemo ipsam quis qui omnis. Beatae nulla quibusdam. Necessitatibus omnis ea qui qui quod. Et autem ea.\n\nNeque molestias sit eos reiciendis in blanditiis. Quae ducimus eius officiis omnis. Omnis velit blanditiis autem quo aut. At distinctio provident ut id molestiae placeat eveniet eveniet adipisci.\n\nDoloremque et cum expedita accusamus nobis. Rerum deserunt ab. Quasi eveniet dolorem voluptas et itaque.\n\nEligendi et vel. Doloribus repudiandae incidunt eligendi blanditiis est. Qui quae doloribus ea dolorem possimus exercitationem. Vel et qui occaecati blanditiis. Distinctio ut ad occaecati suscipit.\n\nRem aliquam sit odit dignissimos nihil inventore. Adipisci laudantium ratione soluta debitis et unde amet dolorem hic. Dignissimos qui et. Beatae animi nihil eligendi qui.\n\nEius officia voluptatem sequi earum optio. Ratione quam aut aut ut impedit error nulla voluptas ullam. Eum et est. Officiis assumenda sunt labore minima expedita facilis aperiam expedita nobis. Sint et expedita sit quis ab. Voluptate incidunt sint est pariatur sit enim ut.\n\nMinus dolorem nisi doloribus quis magnam. Quia sunt culpa quia quia est repellat est consectetur. Ut voluptas est autem rem quos aut. Nihil sed unde dignissimos omnis autem vero est. Corrupti illum nisi pariatur hic voluptas id alias qui tenetur.\n\nExplicabo odit eos sed qui quas reiciendis et nemo. Omnis et minus rerum qui. Veritatis velit eaque maxime nulla. Sit eaque ea et. Repellendus modi voluptas atque eos quibusdam et. Id eos nesciunt dolor unde non molestias non.\n\nOmnis et quas atque totam dolor. Earum molestias aut. Asperiores et porro. Sit sint non ut accusamus doloremque natus nulla.", null, null, "Example Page 2 - Paragraph 5", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") },
                    { new Guid("1c26dbd1-4c0a-485e-b1cd-a58ad61d8546"), "Repudiandae iste rerum quis ut reprehenderit quaerat iusto iste. Fugiat aspernatur vel provident dolorem ipsam est omnis. Quis vel excepturi nesciunt ut laudantium harum cumque ut.\n\nEx saepe distinctio nam soluta mollitia tempore dolores. Eveniet sint est. Ipsum omnis blanditiis soluta aut sit blanditiis. In nisi labore facilis error. Aut sunt sunt est quia iusto eveniet ullam non.\n\nIn optio omnis vel exercitationem doloribus aut eos. Laboriosam eaque harum in tempore. Quaerat dolorum reprehenderit aut modi porro soluta distinctio et.\n\nAtque illo et provident. Est necessitatibus totam et ratione. Provident qui occaecati vel officiis cumque fuga.\n\nEnim autem aut et qui molestias magnam laudantium. Iure commodi modi aut similique quam consequatur quo. Nihil sit ea voluptas repellat necessitatibus voluptatem et.\n\nEos omnis vero est. Numquam occaecati consequatur unde qui corporis. Consequuntur quos optio qui repudiandae tempora excepturi. Corporis repellendus dolores enim.", null, null, "Example Page 2 - Paragraph 4", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") },
                    { new Guid("1dacc715-02cf-461f-a597-a87bca5d162a"), "Voluptas eius quasi accusamus vel. Quod omnis esse non earum et voluptatibus voluptas natus. Sint neque omnis iste perferendis accusantium aut harum vero. Ipsam dolore totam rerum quisquam alias aperiam sunt. Nulla tenetur ea.", null, null, "Example Page 1 - Paragraph 6", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("1fad3ac9-7cc4-4db3-870a-9783b59acb55"), "Consequatur totam nostrum praesentium et et explicabo quis corporis voluptatem. Saepe id soluta. Magnam perferendis natus quo aut. Quidem eveniet qui qui vero debitis dolores vitae nobis sed.\n\nEt minus mollitia quasi eaque quas dolores voluptatum consequatur quia. Asperiores et adipisci nostrum dolorem culpa laborum id. Ipsum iste voluptas laboriosam. Est deleniti illo ad cupiditate voluptate illum eligendi eum. Porro voluptas veritatis aut pariatur occaecati consequuntur.\n\nSit nulla a voluptatem voluptates. Dignissimos commodi perspiciatis distinctio doloribus cum accusantium dignissimos. Ullam maxime consequatur pariatur officia eum.\n\nNobis quasi voluptatem nulla. Dolor ut voluptates dolorem magnam eligendi alias ducimus optio. Aut mollitia sed. Perferendis modi sed sed ut vel et ut inventore officia.\n\nAssumenda at libero aut ipsum qui quos ipsa. Incidunt eius ad sit. Illum quo molestias aut facilis et harum. Illo fuga dolor harum error occaecati quos cumque explicabo. Quas et aperiam. Est voluptatem voluptates.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") },
                    { new Guid("6f52cffb-37f5-453b-a0ab-88a2317d4d3e"), "Suscipit labore fuga optio facere doloribus deserunt. Ipsam sapiente deserunt voluptatem dignissimos vel nihil accusantium voluptatem aperiam. Nulla quo repudiandae omnis laborum. Sed et alias. Ipsum dolor molestias occaecati quia aut vel id rerum aut.\n\nRerum et aut dolorem aliquam voluptatem sapiente. Excepturi quam in. Quae qui aut dolorum vero inventore impedit voluptatem odit accusantium. Quo voluptatem itaque rerum minima repellendus. Aspernatur inventore sint hic officiis asperiores suscipit.\n\nExercitationem est inventore rerum commodi omnis est non quam est. Quis debitis quas est atque corporis dolorem qui ut sed. Qui perferendis laborum occaecati ut culpa. Enim harum maiores illum voluptatem enim ullam. Et omnis ad ut ut. Rem corrupti officiis.\n\nTemporibus enim debitis beatae esse quia odit. Quos et necessitatibus. Est debitis cum aut qui velit sit architecto perspiciatis et.\n\nSint aut occaecati ducimus et. Magnam deleniti ut consequatur qui. Nulla aspernatur sit cupiditate iusto eius hic et vitae recusandae. Accusantium quia ducimus maiores dolor. Velit autem nisi sit omnis et est aut sed aut. Ut nisi voluptatem qui.\n\nQuia nemo sit voluptatem accusamus omnis voluptate facilis in. Ut facere fugit quis ipsa qui dolorem. Asperiores voluptatibus labore vel voluptatem delectus est. Quia voluptas qui eum illum commodi dolore totam veniam omnis.", null, null, "Example Page 2 - Paragraph 2", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") },
                    { new Guid("7202da56-9c7f-4f3f-be31-57bf1823cdce"), "Voluptatem temporibus enim ut ipsum sed voluptatem rerum nisi voluptas. Modi mollitia quas eligendi distinctio sapiente esse. Earum tempora voluptas ut. Adipisci fugit illo tempora nam voluptatem accusantium vel dicta. Provident labore est repellat. Beatae praesentium consequatur.\n\nAt repellendus doloribus doloremque sit earum excepturi. Omnis saepe cumque dolorem non possimus illum ut numquam. Mollitia ab numquam dolores.\n\nQuasi non aliquid tempore minima est et. Maxime facilis beatae odio. Amet voluptate eveniet et ex.\n\nQuo dolorem illum rerum. Quia debitis voluptatum. In accusantium est possimus. Fugit aut consequatur ut architecto voluptatum eaque officia inventore.\n\nOfficiis iure architecto blanditiis sed laborum accusantium. At eum minus atque sed beatae nesciunt. Repellat laudantium et. Delectus adipisci quasi. Corrupti tenetur nobis voluptas et esse. Deleniti cum rerum ut fugiat.\n\nFugiat ut est repellendus. Vel qui assumenda delectus blanditiis deleniti perferendis ut qui quia. Cum non et eaque qui modi. Exercitationem rerum atque ut voluptatibus. Saepe et repellendus omnis nihil aut aut. Libero aut nobis ad optio est consequuntur possimus.\n\nTempora autem debitis sed nihil eveniet est aut consequuntur sapiente. Nostrum ut minima nemo rem quia quia. Rerum enim earum ad veniam dolores hic accusamus. Qui nesciunt doloremque autem et. Non et velit vel sit. Veritatis qui possimus.\n\nMollitia quod incidunt a sit nemo adipisci. Laboriosam natus tempora ullam asperiores. Rerum provident recusandae rerum ut qui. Vel molestiae sit necessitatibus eum distinctio est voluptatibus cum. Accusantium qui voluptates. Perspiciatis a eveniet atque.", null, null, "Example Page 2 - Paragraph 3", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") },
                    { new Guid("78b67dfd-8228-43e5-9d82-601e58b3e7f9"), "Temporibus esse soluta. Labore et aperiam assumenda vel et consequatur et. Necessitatibus corrupti eos magnam soluta quasi fuga veritatis accusantium nihil. Voluptate quibusdam officia. Praesentium aut libero voluptas et corrupti sit eos officiis.\n\nSequi rerum harum fuga. Maxime aut perferendis molestiae placeat qui quas consectetur vitae. Doloribus ducimus neque qui animi dolorem. Nam sed molestiae. Incidunt illum voluptatibus consequuntur alias tempore aut et. Ad nam at expedita possimus accusantium.\n\nSapiente sed tenetur perspiciatis quia quia quia quae dolores. Eum libero veritatis est placeat natus. Tenetur sit iure autem laborum ratione.\n\nEx aut tempore praesentium. In ad quia omnis consequuntur repellat distinctio consequatur. Sapiente fugit illo. Aut hic omnis et porro autem.\n\nEx tenetur aliquid nihil quaerat sit. Excepturi et dolorem. Aliquid eaque quis qui. Et ut eum non quo quo cum qui.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("850a94c8-08e7-4d50-9b7e-0c867f6b0625"), "Fugit vel quia quae ut. Sed voluptatem at. Quasi est reiciendis laborum. Et hic dicta commodi. Temporibus fuga placeat voluptatibus ipsa quam et et. Rerum similique aliquid eius aut beatae nesciunt repudiandae cupiditate sunt.\n\nFuga eaque voluptatem dolores. Eum quo et autem. Eos possimus ipsa esse. Quae ab ut perspiciatis nam laboriosam rerum. Quos esse non in veniam omnis odio dignissimos est.\n\nAut esse recusandae fugit aut repellat. Quae rerum dicta facere et accusantium ad mollitia. Doloremque optio consectetur sunt rerum rerum ea et earum.\n\nOmnis est dignissimos et non eligendi quis. Facere quos consequatur consequatur occaecati quidem. Voluptatem aperiam illum quibusdam inventore exercitationem molestiae. Nobis excepturi non reiciendis quos repellat cumque qui est et. Molestias accusamus quas quidem iusto sit quisquam dolorem.\n\nEum rerum adipisci est est. Hic aut aliquam delectus. Ut provident ad quae et non dolorem qui laudantium debitis. Molestiae quidem expedita ut.\n\nAperiam a exercitationem ab natus similique voluptatem. Asperiores dolores molestiae ut molestias. Aspernatur similique molestiae incidunt minus ea. Autem rerum at numquam velit voluptas aut. Maxime ut ut quasi incidunt quod enim. A ex facere repellendus quo cupiditate voluptas.", null, null, "Example Page 1 - Paragraph 2", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("9c3e48fe-cf6e-48e1-a40f-cacd5f04adb0"), "Alias autem non nesciunt qui iusto officiis dolores voluptatem. Commodi repellat provident earum enim est officiis qui enim velit. Et placeat eligendi dolor a omnis. Quis molestias repellat sint est blanditiis.\n\nMaiores sint dolor ut rem repellat facere porro. Voluptatem vel modi ut velit et debitis voluptatem cupiditate delectus. Aut ut rerum quos hic. Sunt aut minima expedita.\n\nLabore unde modi qui accusamus totam facilis porro officiis. Recusandae ut delectus officia est aspernatur eum iste. Optio non quia enim et rerum praesentium. Laborum nihil nam molestiae culpa labore totam.\n\nCupiditate tempora quo dolor molestias ab. Quis magnam aperiam pariatur saepe et id. Cumque omnis ut. Dolorum repellendus dicta.\n\nSapiente facilis exercitationem reprehenderit. Deserunt accusantium omnis labore aperiam ea deserunt nihil incidunt corporis. Quia neque quod cupiditate. Ea dolorem et optio ea commodi.", null, null, "Example Page 1 - Paragraph 5", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("cdb78f01-92cc-43ac-9a5e-a0f775093e68"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("e782cd19-84ec-4304-b12c-f25d27fb304b") },
                    { new Guid("d4f1b8c7-a2b7-4d46-9064-cf48bd548019"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("e782cd19-84ec-4304-b12c-f25d27fb304b") },
                    { new Guid("e3b5cdfa-cbea-4bb7-aa07-434f4b780945"), "Quae dolore aliquid necessitatibus nulla tempora rerum. Unde voluptates autem consequatur. Non consectetur et. Fuga temporibus et. Est voluptatibus voluptatibus minus rerum delectus.\n\nDoloribus ut debitis aperiam nulla. Rerum dolor corrupti nemo voluptatibus veritatis quia accusamus tempore illo. Occaecati culpa et eligendi eius culpa vel. Provident ea cupiditate voluptatem perspiciatis quia accusantium. Debitis aut veniam. Odio est nobis iusto.\n\nCupiditate sint qui non quia excepturi nemo omnis. Exercitationem asperiores sit. Vel rerum sint ea dicta animi error natus earum. Nesciunt in molestias occaecati reprehenderit fugit et laudantium.\n\nTotam doloribus quia veniam ducimus totam asperiores. Illum porro iusto incidunt quia rerum sed suscipit. Deserunt libero earum dolores dolorem quia voluptas dolore. Deserunt dolor repellendus nam laudantium incidunt beatae ea. Dolorum placeat sint dolorem pariatur eum esse explicabo.\n\nOmnis deleniti voluptatem et nisi odio animi neque eligendi. Tenetur aspernatur nihil et. Aut necessitatibus dolor. Illo tenetur in unde sed est fugiat asperiores est. Et suscipit vel. Modi quia fugiat error nesciunt voluptatibus praesentium laboriosam quaerat amet.", null, null, "Example Page 1 - Paragraph 3", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") },
                    { new Guid("f69370b4-d603-4ab1-a807-4fb0300496e1"), "Culpa facere minima. Excepturi voluptatibus sapiente neque. Voluptatem tempora recusandae amet nemo. Est molestiae sed nulla repellat. Et culpa natus facere harum explicabo commodi aliquam perferendis facilis. Ut ullam quasi.\n\nDeserunt voluptas optio repudiandae velit quae nostrum quia hic qui. Reprehenderit aut quisquam sit non. Iusto sequi ducimus dolorem enim sapiente dolor velit. Earum saepe voluptatibus.\n\nQuam occaecati enim porro laboriosam voluptas doloremque. Qui tenetur quo temporibus sit et reiciendis culpa id. Expedita sit perspiciatis et sapiente numquam est sit voluptas recusandae. Ipsam commodi est nostrum dolorem. Iusto tenetur ut at amet qui veniam voluptatem inventore.\n\nBeatae ad est sit eligendi. Eligendi nulla rerum error. Mollitia et laborum ab. Quis iste beatae magnam ab est nemo enim. Corporis temporibus distinctio tempore corporis ratione minima. Nam laborum sed et.\n\nDistinctio velit tempore ea voluptates aut dignissimos culpa unde repellat. Aut aperiam provident nihil id sit voluptatibus quae unde. Eos et nam. Qui deleniti necessitatibus iste qui sed. Id maiores nisi quia aspernatur fuga. Qui vel architecto minima ut.\n\nRerum est neque rerum aut. Aut recusandae ad aut minus. Temporibus sint aspernatur.\n\nAut pariatur quo qui. Sit molestiae fugiat quia nesciunt at hic. Ea neque aut accusamus molestiae molestiae laborum sequi. Porro veniam in. Iure sint corrupti quo voluptatem. Est atque sit quas quaerat consequatur omnis molestiae.\n\nOdit quae non voluptates blanditiis. Qui odio iure omnis rerum eos. Qui quas nisi doloribus incidunt molestiae sequi necessitatibus. Ut assumenda qui sint ut sed doloribus odit et illum. Aut nesciunt perspiciatis fugit.\n\nSuscipit placeat voluptatem deserunt odio explicabo ut debitis et cum. Necessitatibus eaque velit qui soluta veritatis enim vel dicta excepturi. Optio et velit vel vero. Non incidunt assumenda odio ipsa. Sed consequuntur est. Vel id aut quis aut est ab.\n\nRecusandae ut doloribus asperiores minus doloribus quod eligendi qui. Nobis fugiat eos laudantium non voluptatem fugiat quo at. Provident fuga dignissimos quaerat voluptate voluptas perspiciatis eius. Deleniti repellat natus aut rerum autem provident est quasi dolorem.", null, null, "Example Page 2 - Paragraph 6", new Guid("1c9cf25b-7958-4807-92ec-432640994f0c") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("5de36ea0-59ff-4986-8fc7-f4d7d08bdffc"), false, new Guid("6c655e2a-3639-4f05-914e-30e5b253378f"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 22, 21, 28, 5, 705, DateTimeKind.Local).AddTicks(1248), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("27212c70-3234-4698-93b0-e00a5b10f7a3"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("5de36ea0-59ff-4986-8fc7-f4d7d08bdffc") },
                    { new Guid("8b569117-378d-42d4-a052-d274d19174a1"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("5de36ea0-59ff-4986-8fc7-f4d7d08bdffc") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments",
                column: "ReplyToCommentId",
                principalTable: "UserComments",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("08333e40-af8d-412d-b2da-663e9355954f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("266e46e8-42c6-4751-98bb-f8b216692aaf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("32210ee1-3db3-47e9-9513-250af46c243d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("412a6b07-479e-4973-9bc7-e7a5070b1a9c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("698c635b-efb7-48f5-9776-4b671b49b41b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9d7c3daf-03d4-415f-913d-0dd60a1a1d02"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9f8127ef-de08-4fc7-af49-fd3d8f181bb2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ec3b51e9-8eee-403a-9b49-41cc801363cd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1903eb36-5111-401b-8bb6-1ac806954152"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1af6c5c3-45df-482d-811f-6bc76163bff9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c26dbd1-4c0a-485e-b1cd-a58ad61d8546"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1dacc715-02cf-461f-a597-a87bca5d162a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1fad3ac9-7cc4-4db3-870a-9783b59acb55"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("27212c70-3234-4698-93b0-e00a5b10f7a3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6f52cffb-37f5-453b-a0ab-88a2317d4d3e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7202da56-9c7f-4f3f-be31-57bf1823cdce"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("78b67dfd-8228-43e5-9d82-601e58b3e7f9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("850a94c8-08e7-4d50-9b7e-0c867f6b0625"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8b569117-378d-42d4-a052-d274d19174a1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9c3e48fe-cf6e-48e1-a40f-cacd5f04adb0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cdb78f01-92cc-43ac-9a5e-a0f775093e68"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d4f1b8c7-a2b7-4d46-9064-cf48bd548019"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e3b5cdfa-cbea-4bb7-aa07-434f4b780945"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f69370b4-d603-4ab1-a807-4fb0300496e1"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1c9cf25b-7958-4807-92ec-432640994f0c"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("5de36ea0-59ff-4986-8fc7-f4d7d08bdffc"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e782cd19-84ec-4304-b12c-f25d27fb304b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("47fa806b-4324-4bea-be54-5771bbe6ab2b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6c655e2a-3639-4f05-914e-30e5b253378f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b8a91816-0463-4eb7-b079-3f30bff7f60f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("7982bd1c-f21d-4439-9034-0f03fc6ada8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ff6c5f6a-aeb5-4a8a-88df-9bebe463e136"));

            migrationBuilder.RenameColumn(
                name: "ReplyToCommentId",
                table: "UserComments",
                newName: "ReplayToCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_ReplyToCommentId",
                table: "UserComments",
                newName: "IX_UserComments_ReplayToCommentId");

            migrationBuilder.AddColumn<bool>(
                name: "IsReply",
                table: "UserComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("1f520ff3-3ad8-44a0-9d3e-c5f1c5226531"), "Stories" },
                    { new Guid("210839bd-2c14-47f4-9a42-728d3a84da72"), "Events" },
                    { new Guid("486701d7-6bca-41de-be5c-d6c873d62259"), "Organizations" },
                    { new Guid("6c9fbbb7-86f9-4e1d-a8e3-c8d3b9864140"), "Locations" },
                    { new Guid("82ccea41-e762-4fbf-b9f4-09eb25519acc"), "History and Culture" },
                    { new Guid("83f79cb4-dd66-42a7-bcfe-9bf16bd61b27"), "Food and Drink" },
                    { new Guid("886394c5-2f7f-4a25-8ff9-21906b59bb34"), "Concepts" },
                    { new Guid("aaf73d15-6397-4936-9c21-4efc5847ac81"), "Sports and Recreation" },
                    { new Guid("d7b8ced5-b422-4abb-8fac-140df15144a1"), "Arts and Entertainment" },
                    { new Guid("f20d2a44-a862-4737-844c-7e76cdbc32dd"), "Technologies" },
                    { new Guid("f5e96ebc-8905-44c7-8750-ac516bcc9ee2"), "Characters" },
                    { new Guid("f8189b87-75b2-4c54-99a9-8d8b402cd33f"), "Science and Technology" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("05b74aa9-0495-4155-acc1-f9a054314937"), new Guid("1f520ff3-3ad8-44a0-9d3e-c5f1c5226531"), null, "WikiPage", null, true, new DateTime(2024, 5, 15, 9, 34, 39, 800, DateTimeKind.Local).AddTicks(1821), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("9b71ea34-4813-4372-9213-2157884e6a66"), false, new Guid("6c9fbbb7-86f9-4e1d-a8e3-c8d3b9864140"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 15, 9, 34, 39, 800, DateTimeKind.Local).AddTicks(1984), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8"), new Guid("f5e96ebc-8905-44c7-8750-ac516bcc9ee2"), null, "WikiPage", null, true, new DateTime(2024, 5, 15, 9, 34, 39, 800, DateTimeKind.Local).AddTicks(1772), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("13949710-f2f8-40d1-ad32-15c7f70ab5c9"), "Veritatis consequatur consequatur voluptatem ab. Quod dolor enim voluptatum ad libero voluptas omnis. Qui voluptates nulla dolorum magni facere qui. Sunt error impedit doloremque maxime aut voluptatum.\n\nCupiditate voluptatem amet est praesentium aut id eveniet corrupti. Qui est deleniti voluptatem dolore debitis quibusdam tempore. Saepe quae voluptatum.\n\nQuidem qui nisi maxime. Esse aut natus aut eaque sed. Doloremque fugiat et suscipit aperiam cupiditate fugit est harum et. Quos accusantium dolorum culpa est iste aut ducimus. Temporibus autem voluptas voluptates voluptate quas ea.\n\nCulpa omnis ipsam eveniet dicta. Aut deleniti sit quidem exercitationem est quisquam. Aut provident eum numquam architecto sunt eius. Dolorem id atque velit officia ullam. Est suscipit odit. Eos et ipsa blanditiis nemo voluptatem quisquam perspiciatis pariatur.\n\nEa dicta in sed. Et tenetur eos libero excepturi. Modi veniam qui earum et ab eligendi qui reiciendis.\n\nEst ut ut et culpa magni ut praesentium quibusdam. Autem itaque a harum. Quia cupiditate et suscipit. Placeat cupiditate molestiae eum dolor suscipit.\n\nNihil praesentium aspernatur ut sit magnam libero harum. Beatae molestias eius quos aut architecto in. Omnis ducimus dolores sed necessitatibus velit cupiditate expedita saepe at. Dolores nam quisquam aliquam est ipsa illum eos. Rem voluptatum corrupti quisquam doloribus ad similique vero rerum. Dolor qui ut ipsam a ut.\n\nFacilis doloribus dolorem. Accusamus aperiam sunt. Quis quis reiciendis incidunt. Ut vitae aspernatur suscipit laudantium. Aut qui sed.\n\nEt voluptates beatae odio distinctio et quisquam. Et veniam nihil. Enim qui voluptas iusto animi necessitatibus corporis voluptas molestias velit.\n\nEt nihil sed adipisci iure eum quam consequuntur. Aperiam molestias reiciendis ut nihil. Eligendi assumenda error. Assumenda sit qui delectus voluptatem rerum dolorem. Maxime sed sit ipsa et minima et occaecati. Nemo minima similique labore dolores est.", null, null, "Example Page 2 - Paragraph 2", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") },
                    { new Guid("14845805-d893-4a40-a873-560744a1638f"), "Eligendi aperiam dolorem eos autem ea voluptatem sequi quo. Dolorum omnis veritatis culpa excepturi est. Est voluptatem ducimus quo quasi corrupti dignissimos laborum. Quis dolor suscipit eum ducimus consequatur. Assumenda delectus quisquam aut tenetur eius. Nisi dolores veniam nisi ipsum.\n\nVoluptatum aut saepe ex nulla quis dolores explicabo non laudantium. Molestiae rerum repellat. Voluptatem velit quibusdam sequi enim ut rem. Dolores nisi quidem eos officia.\n\nQuaerat rerum voluptate vitae reprehenderit dolorem nesciunt et est dolor. Doloremque aut deserunt enim atque et. Nemo reiciendis tempore.\n\nNemo dicta nostrum magni. Est ipsam et expedita sunt aperiam. Repellat architecto et et. Rerum voluptatem vel est natus eum tenetur nihil veritatis.\n\nEt fugit corporis. Mollitia reiciendis vel. Voluptatum repellendus autem voluptas corporis culpa. Molestiae natus ea ut. Iure dolor beatae consequatur. Eum aut a aliquid ab doloremque ea et ut in.\n\nNihil deserunt qui ad. Quisquam ullam distinctio quo est. Sed asperiores mollitia aut eos necessitatibus ratione aut dolores dolorem. Tenetur cum quia aliquam. A sapiente tempore illo. Necessitatibus possimus doloremque eos numquam.\n\nExpedita et et. Voluptas officia voluptas harum et mollitia deleniti mollitia eveniet. Pariatur quia qui est rerum sint animi consequatur id. Et culpa modi nesciunt est atque sunt ex impedit. Ratione unde et id aut assumenda.\n\nAsperiores numquam doloribus culpa eos et qui rerum fugit rerum. Adipisci recusandae earum culpa aut est minima sint quis ullam. Doloribus illum odio dignissimos.\n\nSed explicabo quo sunt. Suscipit sed maiores amet quae nostrum sint sapiente vel exercitationem. Fugit excepturi nihil dolorem at facilis. Eum consequatur incidunt vero ut beatae aperiam dolorum dicta suscipit. Sunt eveniet vel dolor non repellat veritatis.\n\nAperiam non sint ut beatae quia fuga. Voluptate quia amet et dignissimos. Dolores molestiae nisi pariatur. Velit quae occaecati odio. Repudiandae sunt molestiae nam illum suscipit corporis nobis perspiciatis voluptatibus. Qui voluptas amet omnis distinctio commodi.", null, null, "Example Page 2 - Paragraph 5", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") },
                    { new Guid("1f0f4c62-2dba-4a96-ac57-e8981ccb9ef8"), "Molestias sit mollitia. Sapiente voluptatem id quibusdam nemo cumque. At mollitia voluptas repudiandae minus illo cum officia pariatur.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("4ab5b349-82d6-432d-a81b-42b1d61e8811"), "Laudantium beatae iusto quia. Velit sunt fugit delectus illum voluptatem et suscipit sed. Accusantium inventore rerum quia pariatur quam expedita. Iste officiis dolore asperiores.\n\nQuis eos assumenda voluptatem animi. Velit nihil pariatur autem laudantium quis ex dolores ut deserunt. Voluptas mollitia sunt dolorem totam amet ipsum nostrum. Corrupti quod rerum fugit aspernatur et sunt non quo. Dignissimos nobis consequatur. Facilis suscipit corrupti quia voluptatem ipsa qui omnis sit reprehenderit.\n\nVero est modi voluptatem distinctio. Modi quibusdam et minima voluptatum. Quaerat harum ut enim. Est quibusdam et occaecati. Recusandae eos consequatur nobis sed et vero deleniti.\n\nNon quos dicta soluta veritatis magnam possimus eos optio. Quasi recusandae adipisci voluptas nesciunt consequatur quibusdam ullam iure beatae. Libero fugit id non aut. Modi asperiores nihil et fuga nesciunt. In maxime accusamus aut adipisci.\n\nSit distinctio debitis. Sit sed fuga modi velit architecto cupiditate sequi. Laborum ut iste eum ea asperiores aliquam sapiente vitae. Ipsam adipisci est sequi facilis quae soluta ea. Quis perferendis provident. Impedit quis quis debitis impedit.\n\nQuidem incidunt vel expedita architecto ut fugiat eveniet officiis. Enim quisquam necessitatibus dolorem atque officiis autem. Enim atque ad adipisci necessitatibus. Et saepe soluta nulla qui quam alias.", null, null, "Example Page 1 - Paragraph 5", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("641c424f-3c5a-4208-9345-32e1340d40eb"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("9b71ea34-4813-4372-9213-2157884e6a66") },
                    { new Guid("6aaceea7-0b9b-4ff0-8261-4cdb509301a2"), "Numquam sed ducimus quia accusantium. Mollitia corrupti quo ipsam excepturi a. Non temporibus in atque et. Molestiae iusto eveniet consequatur est. Et non aut ut necessitatibus culpa eius. Mollitia placeat unde suscipit nostrum et.\n\nOdit animi ea rem dicta omnis ea corporis. Delectus sit nam quibusdam voluptatem quae laudantium. Quasi autem nobis est quo vel sapiente.\n\nSint ipsa ipsum error accusamus. Adipisci eum rerum consequatur consectetur voluptate fugit accusamus error et. Aut ut iusto maxime. Voluptas quidem rem voluptas sint quos est perspiciatis et.\n\nDelectus at nobis et natus quia illo inventore suscipit. Quo sed assumenda ea. Et non voluptatem. Repellat et aut repellendus dolores aliquam quas.\n\nQui aperiam fugit saepe voluptatem. Beatae laboriosam ut sit id dolor officia. Doloribus sed earum culpa occaecati omnis quia dolor vitae.\n\nAt temporibus molestias dolores. Et saepe ducimus nemo quis perspiciatis. Exercitationem quod voluptas necessitatibus at qui voluptatem odit quasi. Eaque est qui ducimus voluptatem ratione ipsam et fugit nihil. Et et ut quae quae quam. Libero facere molestiae ut dignissimos hic tempora harum qui.\n\nTotam voluptates neque dolores alias natus. Ratione nobis nobis. Quaerat quia deleniti voluptatem consectetur. Rerum et odit modi qui. Ipsam voluptatem cumque blanditiis et nesciunt quia.", null, null, "Example Page 1 - Paragraph 3", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("6e2f4279-f84b-48c7-900d-0404985c250a"), "Minima quasi rerum odio. Similique est soluta. Nesciunt qui iusto corrupti in dolorum.\n\nEst qui non dolorum. Culpa voluptas officiis. Eveniet voluptatem commodi illo. Culpa illum voluptate rem vel ullam non.\n\nCum sit quo. Ipsa placeat maiores mollitia hic magnam. Ea molestiae ad tempora nihil. Accusantium tempore ipsam facilis maiores voluptatibus voluptate aperiam iste. Facere optio dolores.", null, null, "Example Page 2 - Paragraph 6", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") },
                    { new Guid("7d602037-172d-4052-a3ce-b8d2c9aebbf3"), "Facere error iure quia ut voluptas exercitationem et. Et est a nemo molestiae et. Et quia inventore quia. Ut tempora numquam nemo sed odit. Doloribus et officia aliquid. Atque hic quibusdam dolore illo et deleniti excepturi ea voluptatem.\n\nItaque quibusdam ipsa iure voluptates vel exercitationem. Est ipsam quaerat velit dolorum. Aliquid deleniti quidem minima provident consequatur.\n\nDolor eum reprehenderit voluptatem accusamus. Labore architecto ullam aut quisquam. Et in minus alias quae. Delectus et minus et recusandae harum non maxime est qui. Ut et ut. Vitae omnis quis deserunt vel aut.\n\nSunt sint quis amet animi dolore sint expedita. Nemo est omnis suscipit ut voluptatibus quidem. Quis qui aut ullam assumenda reiciendis velit. Ex laudantium porro rerum quae deserunt repellat adipisci unde quia.", null, null, "Example Page 2 - Paragraph 4", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") },
                    { new Guid("aea3f3c2-4697-4546-8303-ff1294cec207"), "Et dolorum et amet sed at. Quia eum tenetur quam dolorem tempore quia dolorem perspiciatis. Laudantium totam repellat qui.\n\nEst et suscipit voluptas atque. Sapiente eum eum nisi consequatur autem est eum. Nobis hic autem laborum. Minima nobis et corporis cupiditate quia aut ea atque.\n\nSunt aut reiciendis illo velit molestiae tempora eos. Explicabo animi consequatur quod deleniti nostrum dignissimos deleniti est quibusdam. Laborum repudiandae eveniet corporis. Enim velit rerum odio eius sint omnis aliquam voluptate.\n\nIusto eos exercitationem totam non debitis error vero debitis illo. Vitae officia dolorem qui. Iste deserunt saepe necessitatibus pariatur dolores.\n\nVel minima ut ut accusamus. Quia fugit ut corrupti a voluptatum aut. Quis quae perspiciatis dolorem. Sit corrupti dignissimos odit in sapiente cum explicabo. Eligendi repellendus blanditiis asperiores quia culpa ullam est animi.\n\nEst quisquam sit. Nulla eos enim dignissimos molestiae dolorem. Ea ipsum tempore quo. At facere dolor veritatis sunt id saepe magni et ut. A excepturi molestias et aut quod ut.\n\nVelit cum tempore doloremque sunt sapiente adipisci officia quis. Ut quam velit. Velit voluptatem quo animi quis sit consequatur cum. Quia dolorum consectetur reiciendis ea cum quasi. Sint facere ut sint tempora ratione quia.", null, null, "Example Page 1 - Paragraph 2", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("b9fd1f40-41bc-4575-bcb6-1bd682bf199a"), "Sed est aut unde quibusdam assumenda laboriosam. Fugiat voluptate quis facere sed voluptas. Eos amet et dolor enim voluptas et qui.\n\nNemo asperiores velit consequatur nam itaque. Quia qui tenetur eum itaque aspernatur. Enim consequatur deleniti rerum velit aut qui minima unde. Ut expedita illum eum est temporibus architecto occaecati.\n\nAtque autem animi ea occaecati qui dolorum voluptatem sint excepturi. Expedita deserunt et aspernatur consequuntur at molestiae dolorum. Alias sed molestias maxime magni hic quam maxime animi. Hic aliquid molestiae ipsum quis. Quo veritatis repudiandae veritatis.\n\nBlanditiis atque doloremque necessitatibus est perferendis. Fugiat dicta sunt illo id corporis rerum. Dolor adipisci amet vero pariatur at quis. Est dolore vel aut odio quae harum. Odio provident nesciunt rerum similique omnis.\n\nPorro assumenda eum sint rerum et eaque animi mollitia rerum. Delectus sunt omnis eos consequatur iure voluptatem. Fugiat et sint laborum esse sit. Expedita neque tempora repudiandae sint occaecati nesciunt est consequatur. Voluptatem et aut porro necessitatibus.", null, null, "Example Page 1 - Paragraph 6", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("d5eb17ba-196b-46b9-b45d-450dc7f9abcc"), "Inventore atque autem id libero iste molestias quibusdam dicta. Explicabo beatae dolores. Optio rerum pariatur dolores iure voluptatem quas fugiat sapiente.\n\nAut aut quia dignissimos suscipit illum quia et fugit. Repudiandae et aspernatur. Distinctio non delectus ut cumque.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") },
                    { new Guid("eadf5602-8dcf-4deb-835f-c4339fc8816c"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("9b71ea34-4813-4372-9213-2157884e6a66") },
                    { new Guid("eddd231f-92c3-4acd-82fd-b96cc60ef7aa"), "Velit magnam quis dolorem possimus ullam culpa aut saepe reprehenderit. Molestiae id voluptas dolorum aut amet quis. Libero similique asperiores odit ut. Quo cumque voluptas recusandae necessitatibus vel nobis eius veritatis. Voluptas ea unde ducimus maxime quam iste optio blanditiis vel.\n\nNemo sint doloremque voluptates reiciendis dolorum. Nobis debitis quos minima nisi tempora repellat. Earum sint deleniti est fugiat maiores debitis ducimus officiis officia. Earum placeat aut sit eos sint culpa repellendus voluptatem. Soluta dolor aut amet rerum esse expedita.\n\nQui necessitatibus voluptatum ipsa hic neque nihil eos. Id dolores pariatur est alias. Molestiae doloremque sint modi amet eius expedita.\n\nQuia molestiae corrupti occaecati. Nisi architecto delectus neque numquam. Adipisci et assumenda magnam in totam.\n\nUllam dolor consectetur laudantium nesciunt aperiam voluptatibus. Dolorem voluptatem dolorum ratione non laboriosam blanditiis atque. Rem necessitatibus tempore aliquam assumenda.", null, null, "Example Page 1 - Paragraph 4", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") },
                    { new Guid("f3eb5529-a37a-4f34-a9b5-7e10efc1ece1"), "Accusantium qui molestiae non. Saepe enim perferendis quia aut. Perspiciatis consequatur nisi. Dolorem nihil aut enim aperiam quos. Et temporibus est doloremque est unde aut quis aperiam.\n\nNobis provident occaecati impedit sapiente deserunt repellendus voluptas sit tenetur. Et iure aut omnis nemo. Aliquam iure labore ipsum aperiam sint. Aut occaecati officiis eos qui dolorem et quae ea expedita. Qui ut ab nesciunt molestiae et est quod magni.\n\nTempora facere aliquid in earum ad. Minus modi dolores qui non esse veritatis qui. Necessitatibus aliquid est. Ut dolor fuga aperiam excepturi ut dolorem illo. Aut sequi ad.\n\nLaborum dolorem eligendi. Non ut dolorem et et eum. Maiores natus voluptas occaecati et ipsum. Mollitia consequatur ad rerum quae error perspiciatis earum.\n\nReprehenderit sed tempora adipisci laboriosam fuga. Dolor facilis id voluptates cumque rerum praesentium eum. Voluptas impedit asperiores iure in.\n\nCorrupti quis officiis et quam qui. Nihil quod animi iure consectetur numquam ut nulla aut autem. At dolor unde nemo ipsum labore.\n\nOmnis sed quis et molestiae necessitatibus est id omnis a. Ut molestiae aliquam consequuntur rerum. In quis minima. Labore ad doloremque sapiente assumenda quisquam.\n\nEius iure placeat dolorem eius reprehenderit. Quibusdam minima laboriosam accusamus possimus sed id voluptatum libero qui. Et aliquid perspiciatis assumenda consectetur consequatur nemo aut totam tempore. Expedita dolore totam sed qui pariatur dolorem impedit. Laudantium molestiae eveniet ad cupiditate laboriosam.\n\nNumquam sint qui aut laudantium delectus non doloremque. Neque non facere quia consequatur omnis quam voluptatum. Temporibus earum ut occaecati magnam dolore quo eum dolorum aspernatur. Perspiciatis molestiae est voluptatum minus. Nobis enim cum ab veniam ad libero labore.", null, null, "Example Page 2 - Paragraph 3", new Guid("05b74aa9-0495-4155-acc1-f9a054314937") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("ce5c9452-ce09-4725-8fbb-42228fc87c5b"), false, new Guid("210839bd-2c14-47f4-9a42-728d3a84da72"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 15, 9, 34, 39, 800, DateTimeKind.Local).AddTicks(1988), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("b6c57b98-5fb2-4c08-9eb7-e80a5aa1a3d8") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("263361fd-cb7a-4adb-835d-5bae8c5dc651"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("ce5c9452-ce09-4725-8fbb-42228fc87c5b") },
                    { new Guid("9ceda3b1-66df-46a2-a56d-049c51a263b4"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("ce5c9452-ce09-4725-8fbb-42228fc87c5b") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ReplayToCommentId",
                table: "UserComments",
                column: "ReplayToCommentId",
                principalTable: "UserComments",
                principalColumn: "Id");
        }
    }
}
