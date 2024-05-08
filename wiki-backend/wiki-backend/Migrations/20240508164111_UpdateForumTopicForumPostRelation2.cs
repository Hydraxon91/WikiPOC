using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumTopicForumPostRelation2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId1",
                table: "ForumPosts");

            migrationBuilder.DropIndex(
                name: "IX_ForumPosts_ForumTopicId1",
                table: "ForumPosts");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("08580574-1ccc-4d93-b8b1-e99841ee1222"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1800909e-b5ce-4a77-8c7a-24afe7c966a5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22806e2b-8b0e-4174-8cd8-150c629f712e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("2bde6020-3574-42d4-924e-8865d8410466"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("51b8cbd6-53fa-407b-8f11-b2fa48348735"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("520d0d08-864a-4d0c-83b8-744e3ce41917"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d91e8ef3-2e1d-4989-9c01-b7f1f29730f3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e14b77d1-0b48-447a-b097-775f0a7be345"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("24ba0646-ecec-417f-803b-971e263cdda2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("29aae45c-995e-4df6-85ee-da4cddb289c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3c5c7f49-7eb0-4f8b-b8c1-32061fe83f7d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("42239ab1-8da4-45ea-9716-849b6bd59836"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5a33443a-2aeb-4cf5-9c56-b643260d59aa"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7554d1ed-e7f9-429f-8245-ef860825ad33"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("7c95579f-987c-4eb6-9901-8e96bc36245e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8165c1d0-8928-46c5-8c9a-505a50e7d851"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("890669b8-6bed-4e76-9fb5-d5f54046a291"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ae42a7c-ec6d-4adb-a7dd-78c784abf689"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9df870ee-73cb-4eed-9d59-ec8b687dc094"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a4807e66-b9a9-4254-b583-f992aa07cb28"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("afc06326-50cd-4bce-933e-c5b74c3a6d1f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c301050d-2a1e-424b-b323-6d60d995769b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fa16a3a5-c9e6-47ce-84d6-9239a14df690"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ffa000db-19d3-42e4-9129-30b6db8cafc0"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("237b187b-5964-4898-83f4-fecb399affb9"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("aa149b37-54bc-4660-b3e6-15225f838045"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"));

            migrationBuilder.DropColumn(
                name: "ForumTopicId1",
                table: "ForumPosts");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ForumTopicId1",
                table: "ForumPosts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("08580574-1ccc-4d93-b8b1-e99841ee1222"), "Sports and Recreation" },
                    { new Guid("1800909e-b5ce-4a77-8c7a-24afe7c966a5"), "Science and Technology" },
                    { new Guid("22806e2b-8b0e-4174-8cd8-150c629f712e"), "Technologies" },
                    { new Guid("2bde6020-3574-42d4-924e-8865d8410466"), "Concepts" },
                    { new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"), "Characters" },
                    { new Guid("51b8cbd6-53fa-407b-8f11-b2fa48348735"), "History and Culture" },
                    { new Guid("520d0d08-864a-4d0c-83b8-744e3ce41917"), "Arts and Entertainment" },
                    { new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"), "Events" },
                    { new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"), "Stories" },
                    { new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"), "Locations" },
                    { new Guid("d91e8ef3-2e1d-4989-9c01-b7f1f29730f3"), "Food and Drink" },
                    { new Guid("e14b77d1-0b48-447a-b097-775f0a7be345"), "Organizations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373"), false, new Guid("b0ccbf57-ba42-4b41-9793-05735bd43443"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5740), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("aa149b37-54bc-4660-b3e6-15225f838045"), new Guid("b07e2a52-343e-456b-9725-be5ccf03455b"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5595), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b"), new Guid("43329eee-5de2-4496-a5bf-fe1526ba3123"), null, "WikiPage", null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5556), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("24ba0646-ecec-417f-803b-971e263cdda2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373") },
                    { new Guid("29aae45c-995e-4df6-85ee-da4cddb289c0"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("41d61ac8-f9c0-4369-8f58-00bdf6a2f373") },
                    { new Guid("42239ab1-8da4-45ea-9716-849b6bd59836"), "Unde deserunt aut fuga facere esse sed ipsa itaque omnis. Et blanditiis repellat. Quae numquam hic quae rem qui voluptas animi dolorem. Est aut facere.\n\nCommodi consectetur totam distinctio autem repellat error porro. Voluptatem nihil quia. Earum voluptate quos eos vitae ut qui. Dignissimos neque necessitatibus. Et distinctio corporis fugiat voluptatem.\n\nVoluptatem vel quo error. Ut sint delectus debitis expedita cum vel perspiciatis libero repudiandae. Accusantium delectus totam recusandae quo distinctio velit. Rerum doloremque voluptatem qui nam quas excepturi quam. Quos esse autem mollitia doloribus. Quidem totam tempore.\n\nHic minima assumenda dolorum sint eos qui autem laudantium. Enim et veniam nobis quo sunt. Consequatur qui molestiae. Nobis ullam omnis quia officiis sed. Minima harum sequi rerum nostrum maxime repellendus modi amet.\n\nPraesentium iste possimus autem dolore soluta ut. Temporibus corporis saepe autem amet et harum. Accusantium vero nihil. Fugiat qui similique tempora voluptates non. Quaerat officia quia ducimus aspernatur nostrum aut sed.\n\nCulpa nihil consequatur. Dolore aut itaque quas eos voluptate quia. Sit facere fuga et porro aut eius esse quis. Nihil id dolores facilis voluptatem nihil. Voluptas id velit explicabo pariatur cum ex sit. Sit quisquam doloribus minima voluptatem.", null, null, "Example Page 1 - Paragraph 3", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("5a33443a-2aeb-4cf5-9c56-b643260d59aa"), "Sapiente dolorum numquam provident molestiae incidunt sunt eum. Numquam quis odio. Repudiandae vero dicta ducimus repudiandae ut. Molestiae consequuntur qui ducimus dicta ex.\n\nEt dolores est numquam laborum aliquam nihil neque. Fugiat consequatur quam quia. Aut et ad aut. Unde rerum qui temporibus ea quos tempora aut consequatur.\n\nIste autem corporis esse exercitationem cumque. Rerum quisquam consectetur. Numquam accusamus excepturi.\n\nConsequuntur in et libero quod. Qui tenetur sit beatae voluptas ut possimus quis ea laudantium. Cumque in est officia. Ut sequi quia enim sequi.\n\nSit ex nostrum voluptate. Aut optio eum quo accusamus ipsa est nihil. Perspiciatis molestiae qui. Minima necessitatibus consectetur sed.\n\nQui quia nulla architecto. Quisquam laborum eos nisi fugit nihil quia. Culpa et error ad et non.\n\nIusto aut reiciendis magnam. Placeat numquam repudiandae et qui modi consectetur. Quibusdam est repellendus quidem iure labore. Rerum assumenda est. Rem pariatur voluptate omnis et consequatur. Molestias commodi consequatur.", null, null, "Example Page 2 - Paragraph 3", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("7554d1ed-e7f9-429f-8245-ef860825ad33"), "Ipsam fugiat quisquam. Ratione fugit tempore dolor veritatis et itaque qui est. Incidunt eius occaecati eius error soluta architecto. Sed quia voluptas rerum. Ut voluptatem voluptatem.\n\nVoluptatum autem sunt magnam non incidunt repellat. Eum ullam eum quidem dignissimos. Non ut quia optio aut cumque. Voluptatem animi voluptates culpa et excepturi. Qui ipsa quam dolorem nihil repudiandae et autem at dolore.\n\nMolestiae enim eos et laboriosam iste. Voluptatem et id quis libero. Maxime dignissimos voluptates eaque similique ipsa ut. Natus accusantium consequatur mollitia aut quasi deserunt nam ut fugiat. Qui iure qui eum officia est sunt ipsam iusto consectetur.\n\nVoluptatem et aliquam delectus similique molestiae fugit. Illum quis quia omnis voluptatem. Ex qui et sint nobis rem tempore quod. Deleniti deserunt sunt. Voluptatem a et a sequi at temporibus voluptatibus quia sequi.\n\nPerferendis ratione est et ad a id praesentium sint. Quis fugit velit. Veritatis neque facere ad eos dolore laborum occaecati. Eos et occaecati aut sed sequi in pariatur deleniti est. Ut modi praesentium vel expedita. Autem architecto numquam omnis.\n\nAccusantium odio et vel omnis adipisci optio cum illum enim. Aut alias eos debitis voluptatem iusto facilis perferendis. Molestias commodi porro quasi mollitia provident et adipisci totam.", null, null, "Example Page 2 - Paragraph 6", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("7c95579f-987c-4eb6-9901-8e96bc36245e"), "Voluptatem blanditiis et laudantium voluptas et vitae nesciunt quasi. Omnis sed error reprehenderit velit dicta accusantium commodi earum. Dicta quam accusantium repudiandae non voluptas dolorem. Debitis est veniam quos odio maiores error ipsa. Velit omnis magni labore illo ut ut in.\n\nTotam repellat eum qui molestiae beatae non. Voluptates blanditiis voluptas ipsum voluptas facere architecto. Modi quo non quia ut consequatur ab aut. A dignissimos maiores et.\n\nQuibusdam fuga iure consequatur voluptas cumque vel. Quo assumenda inventore. Esse blanditiis voluptate nihil repellendus. Rerum debitis delectus et ea fuga ullam eligendi sunt tempore. Iste numquam sint repellat voluptate qui perferendis accusantium doloribus. Aliquid enim consequuntur.\n\nDistinctio quia alias labore. Quae dolores aperiam alias rem eos vel molestiae dolor. Dolores odit quia expedita corrupti suscipit aperiam labore at et. Provident voluptatem ea accusamus doloribus adipisci mollitia est. Architecto consequatur occaecati consequatur. Voluptatem eum sed amet.\n\nEa ipsa illum rerum ad architecto voluptas accusamus autem qui. Qui non cumque ut dolore omnis dolore reprehenderit a non. Culpa eveniet nostrum magnam amet ut corporis voluptatum qui.\n\nEum ut eum sint ea nisi vel. Deserunt rerum quisquam qui suscipit quibusdam recusandae. Inventore vero soluta eius.\n\nIpsum architecto dolorem ratione. Ex occaecati recusandae atque. Est sit est reiciendis perspiciatis consequatur saepe animi odio nam. Laboriosam eveniet beatae praesentium quas. Facilis facilis ducimus ut.\n\nArchitecto beatae consequatur aut necessitatibus rerum. Voluptatem dolores repellat corrupti ut totam commodi fuga omnis nostrum. Sit ut ipsum cumque sint dolorem.\n\nEt dolores et eos et unde culpa ut. Autem sint et blanditiis repellendus recusandae fuga. Qui ut nisi repudiandae. Nostrum labore et enim voluptatibus blanditiis provident ex. Quisquam veniam ducimus voluptate omnis ipsam autem odio.", null, null, "Example Page 1 - Paragraph 5", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("8165c1d0-8928-46c5-8c9a-505a50e7d851"), "Et aut officiis accusamus architecto. Impedit id dolorem. Nihil ut vero voluptate. Enim recusandae in ipsum et molestiae magnam.\n\nEaque dolorum aliquam occaecati alias qui et. Ut fugit omnis. Aut sunt amet omnis et debitis facere velit ut. Est non velit quibusdam est sequi doloribus quae accusamus. Enim hic laboriosam reprehenderit nostrum et et.\n\nAut officia dicta rem quos saepe iste omnis aspernatur eaque. Id at totam qui libero facere temporibus est molestiae amet. Delectus consequuntur ipsa. Non aut possimus. Vero aliquid non excepturi nam est rerum et consequatur. Est voluptatum dolorem non illum consequatur similique quo voluptatem.\n\nSapiente delectus dignissimos earum est occaecati consequatur enim cum qui. Minus voluptatem harum dolore nam. Nulla in omnis non autem fugiat et optio.\n\nOptio eum sint dolorem. Sed sequi ratione aut sunt quas quia quas. Quibusdam est laudantium alias ad harum laborum nesciunt ullam maiores. Aut exercitationem delectus autem voluptatem nihil error cum. Culpa et iusto dolores commodi quasi eos ea eos. Dignissimos reprehenderit voluptates reprehenderit.", null, null, "Example Page 1 - Paragraph 2", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("890669b8-6bed-4e76-9fb5-d5f54046a291"), "Beatae cum laboriosam ea exercitationem quas iure nihil non. Tempora consequatur delectus ullam accusamus. Reiciendis culpa et et magni nisi quos voluptates. Sit sunt voluptates dolores dolorem iure architecto dolore id.\n\nEx id quaerat quisquam et sit provident. Minima dolor voluptatum vitae ea adipisci labore. Voluptatibus recusandae ducimus unde. Eos delectus atque veniam adipisci a sequi sed.", null, null, "Example Page 2 - Paragraph 2", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("8ae42a7c-ec6d-4adb-a7dd-78c784abf689"), "Ut consequuntur suscipit architecto. Est occaecati dolor eos veniam vero non. Sed id autem. Quidem voluptate et in ut modi fuga natus. Excepturi corporis dolorem sit sit officiis laudantium rerum laborum.\n\nFuga aut placeat velit totam amet. Tenetur quo omnis vel aspernatur doloribus ab harum. Eligendi amet et. Nemo quaerat et sed nisi enim enim.\n\nNihil maiores distinctio numquam quas. Ut quisquam consequatur nesciunt qui dicta veniam maxime. Qui voluptates voluptas est aut sed dolores praesentium.\n\nUt aperiam eveniet est necessitatibus eum. Quia hic itaque vero odit asperiores atque fugit commodi. Molestiae sed et repellendus voluptatum molestiae. Ut error cum et accusamus magnam labore voluptatibus cum. At dolorem necessitatibus eos ipsam velit dolore culpa. Quibusdam eos minus assumenda.\n\nEos reprehenderit enim ea rem repellendus aut voluptas beatae. Saepe harum provident voluptate. Aut qui quo quia omnis. Et saepe et nulla et culpa et modi optio rem. Voluptatem blanditiis qui similique rerum.\n\nQui distinctio porro fuga vitae omnis ut et eius alias. Omnis ut suscipit sit suscipit doloremque asperiores necessitatibus odit. Tempora at molestias quo vero officia voluptates quam commodi.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("9df870ee-73cb-4eed-9d59-ec8b687dc094"), "Illum eveniet ut incidunt eum est est nam. Est dolorem rerum est ea debitis dolor eos odit. Dolor ipsum iste soluta odit perferendis ea doloremque.\n\nVoluptas vel eius qui neque occaecati ut architecto et. Pariatur quae perspiciatis sapiente quo animi ratione. Reprehenderit rem culpa et et vel maxime asperiores animi possimus. Sed rerum ullam reprehenderit odio modi quibusdam. Impedit distinctio sunt qui deserunt ea deleniti.\n\nNesciunt eum nostrum consequatur culpa distinctio corrupti eligendi illo. Et velit officia dolorem in sed sed dolore debitis minus. Dolores est provident quo reiciendis laborum. Expedita vel possimus quis quia sit rem ut.\n\nNulla error ipsum animi ut tenetur quis debitis vel maiores. Aliquid aut magnam blanditiis numquam mollitia in ex. Laboriosam aut velit non cum recusandae vero voluptatem distinctio. Repellat assumenda et magnam ut et sed provident. Dignissimos sed sed asperiores molestiae.\n\nA amet nostrum non. Possimus quis exercitationem nihil odio. Et expedita ut quidem sequi iure.\n\nSit facilis iure quod quisquam nihil qui quos libero ut. Itaque est corporis id. Reiciendis est dolor ducimus autem magni.\n\nMinus a sint consequatur. Et odit perspiciatis occaecati tempore molestiae eos sed quos sit. Aliquam suscipit dolorum rerum omnis amet debitis ut cum. Nam sit voluptatum ad et consequuntur nisi sed eos. Qui rerum et nesciunt est et commodi et.\n\nDolorum quo enim dolores ut. Ipsam nostrum reiciendis reprehenderit porro maiores laboriosam. Voluptate reprehenderit repellat ipsam ratione doloremque et sit.\n\nQuidem voluptatum aut praesentium. Porro cumque quaerat numquam. Quia qui animi nostrum odio quidem mollitia culpa quis fuga.\n\nDucimus quia ipsum aut voluptate quisquam. Omnis animi natus sunt. Cupiditate deleniti soluta vitae recusandae non inventore enim quia laboriosam.", null, null, "Example Page 2 - Paragraph 4", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("afc06326-50cd-4bce-933e-c5b74c3a6d1f"), "Et voluptatum voluptatum. Aut odit ipsa doloribus consequatur odit nobis fugit debitis et. Dolores architecto rerum. Modi quia labore. Quasi ipsam quo sequi.\n\nRecusandae iste aspernatur qui. Excepturi et odit et reprehenderit harum ducimus natus ex. At nobis asperiores vel. Ex quaerat ea veniam esse.\n\nUt assumenda vitae illum est est et est error. Ut enim quia earum molestiae quia sed modi vitae excepturi. Dolores minima possimus eum. Qui autem optio exercitationem reprehenderit culpa quod.\n\nDolorem omnis sunt dolore itaque qui voluptate quo quaerat. Sed nesciunt ipsam quia voluptatibus dolores ut. Quod dignissimos perferendis quaerat autem. Delectus sit modi dolor explicabo consequuntur et. Voluptas suscipit dolor inventore mollitia non molestiae qui.", null, null, "Example Page 1 - Paragraph 4", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") },
                    { new Guid("c301050d-2a1e-424b-b323-6d60d995769b"), "Necessitatibus ratione distinctio voluptatibus sit tempora dolor et nostrum. Ipsam dolorem iste at qui et perferendis recusandae. Sit magnam vel. Consequuntur placeat quod.\n\nEt esse dolorem sit voluptates. Tempora aliquid ut ut libero molestiae iure enim est possimus. In reprehenderit cupiditate ex molestias voluptas reiciendis. Tempore exercitationem error itaque quia eligendi consequatur velit. Et ratione illo corrupti et. Molestiae expedita et molestias hic consequatur necessitatibus et labore.", null, null, "Example Page 2 - Paragraph 5", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("fa16a3a5-c9e6-47ce-84d6-9239a14df690"), "Aut non iusto adipisci animi ex architecto eum. Qui ullam accusantium sint adipisci in ducimus dicta. Voluptate iste accusamus labore doloremque.\n\nQuas ut earum qui odit. Veniam aperiam optio quaerat laudantium harum rerum soluta qui voluptatem. Eaque qui vel iusto omnis porro non ipsum. Id ut sed est omnis aperiam.\n\nRepudiandae quis quia doloremque expedita. Non quibusdam qui rem autem ipsam minus eveniet sunt ipsum. Dolorem voluptatum sapiente. Id vitae nulla. Animi ad aspernatur debitis est consequatur.\n\nMinima quis molestias porro. Cupiditate cupiditate voluptate quis est error. Est consequatur velit. Delectus qui explicabo laboriosam. Ut omnis ullam.\n\nMollitia qui tenetur deleniti ut. Iusto voluptas sit error neque et cupiditate. Facere quos sapiente eos mollitia est. Quam itaque tempora. Dolores eveniet provident ab ullam. Nulla et aut eum.\n\nEarum voluptate architecto voluptatibus dolorem eum consequatur ut rem. Dolorem omnis iste sint voluptate sequi harum alias deleniti. Ipsam magnam eum ducimus amet quas. Natus maiores aut natus odit. Id ducimus enim aliquam voluptatum. Ut sunt est illum nesciunt neque.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("aa149b37-54bc-4660-b3e6-15225f838045") },
                    { new Guid("ffa000db-19d3-42e4-9129-30b6db8cafc0"), "Placeat modi et. Distinctio vel fuga. Quam fugit eos. Aliquam voluptatem sunt.\n\nRepellat maiores nemo ut neque quae eos recusandae. Qui quia labore vel. Rerum aliquid deserunt rem et qui aut.\n\nAutem vel odit rerum. Aut et est beatae architecto dolor cumque. Cumque deserunt dolorem voluptatem non minus minus iusto aperiam odio.\n\nOfficiis dolor aut. Rerum magni qui adipisci fugiat ex consectetur sed sed eaque. Ut suscipit omnis repellendus enim corrupti magni ut. Eaque similique quae dolor.\n\nAccusantium doloremque exercitationem omnis asperiores voluptate est deleniti est. Labore blanditiis praesentium enim esse est rerum. Rerum est et est rerum. Sint pariatur dolorem facere et nihil molestiae error. Facere est nemo aliquid voluptatem ipsa molestias ullam. Eum quia sit eaque odio saepe expedita ratione totam debitis.", null, null, "Example Page 1 - Paragraph 6", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("237b187b-5964-4898-83f4-fecb399affb9"), false, new Guid("7f378b51-0ae5-4a96-9a46-13bc361b5e5f"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 8, 18, 39, 8, 224, DateTimeKind.Local).AddTicks(5745), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("e4842b42-7458-4a16-acb6-5ca062e4ed7b") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("3c5c7f49-7eb0-4f8b-b8c1-32061fe83f7d"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("237b187b-5964-4898-83f4-fecb399affb9") },
                    { new Guid("a4807e66-b9a9-4254-b583-f992aa07cb28"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("237b187b-5964-4898-83f4-fecb399affb9") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForumPosts_ForumTopicId1",
                table: "ForumPosts",
                column: "ForumTopicId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ForumPosts_ForumTopics_ForumTopicId1",
                table: "ForumPosts",
                column: "ForumTopicId1",
                principalTable: "ForumTopics",
                principalColumn: "Id");
        }
    }
}
