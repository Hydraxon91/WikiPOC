using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddForumcommentModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("110f12c6-ff22-4bfa-957d-263647d694ff"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e214b9a-d844-4b19-8746-a3e0d8ab092f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45c103d5-e4e2-42a6-b2e2-5c7ab00b8b0d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("548f3468-e506-44d6-9b2f-d31154f76d01"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5d4277e6-d9a3-4798-8ff0-6605fdcb5f84"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("84ff1ff6-75c8-4ef4-80dd-bf1d353ee56e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("a0184cf6-bb20-40be-ac48-359c42ee4d7f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("aaecda94-0ca1-48bc-8eef-c7f12b5d6f19"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("00ec6c8d-8632-449a-b9d9-2dab8d597e57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0805951f-90b1-457b-85ef-7c8f39996d88"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1bfaf53d-0130-4713-a132-1045e6b72f3d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2f7f430c-e1ed-4b12-b3eb-e6ba96327206"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("471d27b8-b7b4-40dd-a594-644d0bb07dc2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("846abb6a-adb7-45ee-b850-9e27afb0849c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("852ac18a-7c71-4317-b502-344d01edceab"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("908209b8-7c27-4781-80d2-34066f150aed"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("975a93b7-f3f1-4485-b46f-6e09fec883fb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9821227c-5345-41a5-b6ad-7e636a9b2b1c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a27c0532-92c5-4b39-a897-bd2ce00f2c6f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b2a39f1a-b60b-4f0e-af27-82886d305e57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b59a74e2-6f6c-4715-b26d-229c3f5cae1c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c1e98e1a-b8ec-4d9d-a5e4-0f5402863f2d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("dad5179d-ee12-46f7-8e81-cd8a5bb41b14"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e849bed8-972e-4c8e-bc8f-61f46ff292d6"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c87ac71d-1af4-4635-9c34-def734e10438"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("0bfa32f7-1e80-4071-a187-a2ff9f347f2f"), "Sports and Recreation" },
                    { new Guid("100c5552-cb69-4f07-8873-ea6db4b2b818"), "Technologies" },
                    { new Guid("22fce5ec-0b94-4f8a-856e-876492f2f801"), "Food and Drink" },
                    { new Guid("432d1f6b-c4ea-41d3-818b-ac1c8b778279"), "Characters" },
                    { new Guid("4f47ed28-8451-43ff-aa15-a029b11d0046"), "Locations" },
                    { new Guid("5a1c0781-6844-44de-a6a3-14f25f271744"), "Concepts" },
                    { new Guid("5f3de8fc-c5bb-4566-9485-7c1f14f0115b"), "Organizations" },
                    { new Guid("6d68349e-4be3-4248-9065-806001724cc8"), "Science and Technology" },
                    { new Guid("75b44cd4-1af2-46c8-a6ab-9eb5cb11b430"), "Events" },
                    { new Guid("794afeab-35f8-4c70-a539-eb332aa5c99f"), "History and Culture" },
                    { new Guid("9e2baedd-2d5c-40c3-ad3d-24af13fe02b9"), "Arts and Entertainment" },
                    { new Guid("b219656b-46d4-4c4b-a151-4f4e2cea2947"), "Stories" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da"), new Guid("b219656b-46d4-4c4b-a151-4f4e2cea2947"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 13, 52, 53, 562, DateTimeKind.Local).AddTicks(251), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("6d286c60-8d03-4ef7-8b1a-47aa9f73772c"), false, new Guid("4f47ed28-8451-43ff-aa15-a029b11d0046"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 13, 52, 53, 562, DateTimeKind.Local).AddTicks(383), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f"), new Guid("432d1f6b-c4ea-41d3-818b-ac1c8b778279"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 13, 52, 53, 562, DateTimeKind.Local).AddTicks(213), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0b8b81de-b30c-4a8d-8807-e0e73c349b06"), "Quia nulla beatae tempora molestiae voluptatem laudantium. Sint vel amet delectus esse quia quae culpa. Quod aut vero quos laboriosam dignissimos.\n\nId iste fugiat numquam illo est aliquid et voluptatibus atque. Hic doloremque esse qui eos placeat quia id sit. Maiores necessitatibus minus suscipit maiores et. Et quod velit. Distinctio adipisci labore vel consectetur ipsa illum saepe.\n\nRerum inventore ducimus ab voluptatem consequatur qui. Qui possimus iste voluptatem fuga at eos nulla. Veniam consectetur fuga fugit. Nisi unde libero non. Incidunt rerum id in qui tenetur consequatur tempore. Et illum totam et quidem molestiae officiis fuga dolorem.\n\nEt autem voluptatem. Atque similique provident. Velit consequatur nemo non voluptas natus enim praesentium exercitationem rem. Blanditiis sequi dolorem sint cum esse ipsum. Architecto voluptas laudantium laborum explicabo consequatur ipsum ipsam rerum.\n\nAsperiores sit recusandae sint illum. Voluptas dicta omnis totam esse sequi quam deleniti. Ut culpa et et dicta dolore eveniet atque suscipit et. Necessitatibus odio accusantium doloremque libero quos facilis ea. Possimus minus natus blanditiis perferendis rerum.\n\nEt aut voluptatem reprehenderit vitae sapiente sequi numquam. Velit occaecati nobis esse est. Fugiat est est corrupti. Eum expedita rem fugit sed aspernatur.\n\nOdit occaecati soluta tempora assumenda vero sapiente dolorem. Nihil eaque maxime et qui odit. Omnis libero blanditiis vitae ut nulla vero. Aut harum exercitationem quis ut voluptate repellendus laboriosam ullam. Numquam soluta nostrum et nihil. Perferendis ullam rem reprehenderit.", null, null, "Example Page 2 - Paragraph 3", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("20fc12b6-1673-4547-a7a9-328795c01ff4"), "Nihil praesentium dolor. Illum tempora sit atque. Ipsa voluptatem ut eligendi velit incidunt quia ut est dolorem.", null, null, "Example Page 2 - Paragraph 5", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("23aa4115-53dd-422f-84c4-c2114be51fea"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("6d286c60-8d03-4ef7-8b1a-47aa9f73772c") },
                    { new Guid("523a9f2b-3b4d-4a1f-9f50-b7abcda4d6cd"), "Recusandae beatae vel sapiente molestiae vero. Rem a qui aut eveniet consequatur. Autem consequatur esse consequatur.\n\nAut magni expedita rerum voluptatem commodi qui adipisci deserunt. Sit iure dolores est asperiores omnis ducimus tempore dolor voluptatem. Omnis maxime cupiditate exercitationem rem nam incidunt. Adipisci necessitatibus velit ut quae sed cumque consequatur rerum id. Aut incidunt est delectus rerum numquam sequi reprehenderit.\n\nQuis aspernatur officia id harum laborum autem atque vel. Voluptatibus vitae dolores vero eveniet numquam qui dicta necessitatibus. Omnis et dolorem. Laudantium cumque aut necessitatibus quo velit. Nobis excepturi est.\n\nNam error qui excepturi quo totam consequatur minima. Placeat qui officia quidem expedita laborum odit. Iure tempora quia ratione distinctio. Voluptates cum ullam est expedita sequi in.\n\nQuia nostrum tempore velit nobis voluptas vero ut quia quaerat. Qui dignissimos laudantium dolore. Unde enim fugiat ipsum asperiores totam aperiam in quo veritatis. Id nostrum accusantium mollitia. Optio maiores repudiandae eos quae minus. Odio tempora quis quis commodi fugiat aut consectetur.\n\nAccusantium qui qui enim vel eos debitis. Eligendi beatae nesciunt accusantium voluptatum voluptas est necessitatibus consequuntur voluptatem. Error beatae praesentium debitis minima quod.\n\nQuas autem quas atque non sed reiciendis sed ipsa architecto. Sunt inventore dolores. Veritatis praesentium reprehenderit minima praesentium ipsam sit. Sit temporibus nesciunt enim et totam dicta dolor minima. Sunt culpa ipsum ducimus id.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("58d281a1-8517-4c2d-ba96-57b0afa9fb2f"), "Labore soluta doloribus rerum numquam inventore est et natus voluptas. Et harum porro eos a saepe aspernatur laborum explicabo. Sunt ipsa non minima illo dolor. Doloribus est eligendi provident excepturi et. Amet et deserunt et dolor corrupti et vero. Eligendi voluptates vero repellendus laborum repellat rerum perspiciatis voluptate ut.\n\nAutem quo cum expedita eveniet dicta qui. Enim consequatur suscipit alias ullam velit et nostrum dolorem. Eos ratione enim natus.\n\nDistinctio excepturi quas eum est maiores eligendi qui reprehenderit. Sint ex accusamus dolores ut tenetur. Magnam laboriosam dicta rerum. Atque quae debitis laboriosam ut est molestias id. Molestias minima ipsum laborum similique voluptatem deserunt ipsa et. Dolore modi nihil reprehenderit officia nesciunt in repudiandae.\n\nIste est laboriosam dolorem aut sunt et. Et accusantium tenetur iusto qui provident culpa harum ab. Nesciunt eius qui sequi quia et voluptatum laboriosam vel repellendus. Voluptatum quis rem. Voluptates eius culpa est dolorem assumenda in.\n\nEt aperiam vel blanditiis nihil est. Corporis iure autem. In vel aspernatur recusandae. Magnam quis fuga. Iste sed quos pariatur recusandae placeat quia dolores voluptatem. At molestiae voluptatibus.\n\nSaepe perferendis animi cum nemo ratione laborum maiores sint. Autem sint nisi illo pariatur et nobis. Facere ea quasi. Qui neque consectetur qui totam dolorum a deserunt numquam. Nihil aut commodi omnis. Aut laboriosam ad quaerat placeat.\n\nCommodi facilis officia. Reprehenderit eaque voluptatum dolores. Quia ab harum iusto dolor nemo. Deserunt voluptatem voluptatem eos. Minus soluta doloremque aut doloribus quos.\n\nAperiam eveniet sapiente non. Dolorem hic id voluptatem libero rerum cumque qui. Eius quibusdam similique delectus in ea eos quis. Sint incidunt et at id.", null, null, "Example Page 2 - Paragraph 2", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("68bcb6b4-e3b6-4199-af2f-f3a4ec04613c"), "Error velit quis. Exercitationem eveniet blanditiis ducimus est et. Tempore perspiciatis voluptas. Ex vero provident nulla sapiente. Sit cupiditate voluptates adipisci aut explicabo magnam.\n\nDolor illum vitae quam. Eum nisi enim minus. Dolorem eaque possimus.\n\nIllum reiciendis laboriosam id illum repellat id et reiciendis quod. Aliquid dolorem et esse explicabo et qui minima. Voluptatem maiores ipsam ut aut voluptatem. Magnam numquam suscipit laudantium magnam iusto voluptate. Mollitia natus aspernatur. Est est voluptatem rerum dignissimos unde ut aut.\n\nDolorem enim natus debitis. Officia facilis possimus nobis odit nostrum. Minima suscipit nam quo et reprehenderit iusto autem sed vel.", null, null, "Example Page 2 - Paragraph 6", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("74d781aa-e4a5-4900-984e-36de00afd696"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("6d286c60-8d03-4ef7-8b1a-47aa9f73772c") },
                    { new Guid("78cfd652-f4e5-455d-820c-54ad29f213f2"), "Tempore modi doloremque molestias qui est voluptas. Atque nihil et autem quisquam. Et dicta quo error minus. Omnis quo reiciendis vitae veritatis velit quisquam culpa possimus voluptates. Dolor blanditiis quaerat est.\n\nQuaerat maxime delectus veritatis tempore accusamus. Suscipit libero qui quis est nam porro est. Id nesciunt quidem dolores dolor repellat modi rem deserunt. Cumque accusamus ratione. Est voluptate laborum natus est sed.\n\nLaborum est sit iure excepturi nemo. Non consequatur ab dicta quia harum distinctio totam corporis non. Possimus voluptatem dignissimos quas voluptatem consectetur voluptas placeat.\n\nEum sit officia. Et unde eveniet magnam cupiditate. Quos ab labore id dolore id commodi non. Et nemo molestias natus eligendi.\n\nCumque quis in dolorem ab rerum quia saepe molestias quia. Autem sed voluptatibus. Vel praesentium molestiae voluptatem eum quaerat eius. Voluptas cupiditate quas aspernatur voluptates nisi atque qui excepturi. Est est est magnam. Ad voluptatum consequatur magni est laudantium itaque.\n\nProvident voluptas sint ab tenetur sapiente dolorum sunt in. Iure modi explicabo necessitatibus illo provident dolorum deleniti libero non. Dolores dolorum modi ipsum veniam id.\n\nDeserunt fugit magni debitis et sed. Laudantium aut tempore adipisci reprehenderit provident. Dolorem id animi odit. Repellendus est facilis recusandae officiis commodi est.\n\nQuibusdam qui sint ullam repellendus dolorem atque quisquam laudantium. Corrupti odio voluptas qui alias dolores consequatur excepturi consequuntur iure. Quidem repudiandae iusto perspiciatis. Adipisci sit minima soluta ea accusantium. Commodi rerum similique. Assumenda fugiat et molestiae mollitia est nisi hic illum adipisci.", null, null, "Example Page 1 - Paragraph 2", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") },
                    { new Guid("8b62fbd0-9a76-4547-b1a6-cc3fff9fa313"), "A est molestiae nihil quidem. Vitae quia fugit consectetur aut. Voluptas nihil eum facere nesciunt ea quod qui animi. Voluptatem animi facere possimus neque inventore eius temporibus. Maxime soluta eaque vero. Omnis sed voluptatum esse corrupti harum voluptas ea.", null, null, "Example Page 1 - Paragraph 5", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") },
                    { new Guid("afca9c5f-0194-4ae1-97f2-aec878e71ee8"), "Consequatur et laboriosam asperiores aut cum sunt. Nihil laboriosam aut autem. Et dolore voluptatem inventore fugit aliquam ex et. Minima in voluptas vel placeat vitae voluptatem similique aliquid vitae. Ab voluptas doloremque autem ullam tenetur. Mollitia nihil repudiandae.\n\nRerum expedita architecto ex distinctio vel quia quos molestiae qui. Magnam quae id voluptatem quae adipisci. Molestiae vero consequuntur consequatur porro dolorum amet molestiae. Consequuntur inventore recusandae quis modi eveniet delectus. Inventore reiciendis sapiente id et amet rerum veritatis dolor. Delectus et est est non et.\n\nIncidunt alias enim consequuntur sequi. Similique est aut ut. Tempora quibusdam ut officia facere exercitationem vero qui minus. Et minima aperiam architecto. Beatae explicabo ex. Modi ullam accusantium aliquid.", null, null, "Example Page 1 - Paragraph 4", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") },
                    { new Guid("ccbddc69-ee6e-4267-89c3-313057dc11f6"), "Modi pariatur quae nihil necessitatibus hic aut dolor quae odio. Tempore nobis aperiam quis nobis. Autem est modi nemo est. Sed ex eaque tenetur earum et vero sequi voluptas delectus.\n\nAut magni vitae doloremque tenetur. Et odio dolores explicabo vitae rerum cum. Maxime autem voluptatem sint autem ut. Sit eum voluptatibus eligendi sint at minus.\n\nEa cumque animi et molestiae harum nihil expedita quia. Aut voluptatum rerum odio ex sed et quo. Doloribus perferendis delectus ratione deserunt. Atque dolorem nobis. Et molestiae enim ea sapiente deleniti.\n\nPariatur unde enim aperiam. Dolores culpa et eum dolores numquam nulla et dicta. Iusto voluptatibus est. Nam in occaecati nemo ut ut deserunt sequi. Deserunt amet non neque nihil impedit.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") },
                    { new Guid("e04c587a-535f-46df-9722-cd1a30337839"), "Id totam nemo corporis sit fugiat et aperiam est. Iure ipsum ex quo rerum quia. Laborum consequatur natus. Est ex ducimus perferendis impedit. Voluptates minus temporibus. Consequatur quia earum.\n\nOfficia consequatur temporibus quod inventore quas at ipsam. Rerum voluptatem eum odio eveniet necessitatibus doloribus. Veritatis omnis quia dignissimos. Et et sapiente. Sint nulla suscipit reprehenderit labore fugiat non adipisci et sint.\n\nQuas incidunt labore recusandae ut aspernatur quos corrupti saepe. Id eveniet quasi. Similique recusandae praesentium facilis velit veritatis quas amet.\n\nEt veniam sunt sit consequuntur odio. Enim perferendis repellendus laboriosam fugiat ut fugiat. Rem totam culpa.", null, null, "Example Page 1 - Paragraph 3", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") },
                    { new Guid("e18e536e-d1aa-4c28-a8c2-6b9344286be0"), "Sit optio architecto ducimus ut beatae a. Nam non iusto quo qui illo magnam qui error. Vel sit facere quis maiores quis labore non tempore in. Assumenda consequuntur voluptatem sunt autem et fuga sit. Qui consectetur hic ex id tenetur vitae et.\n\nDebitis quisquam officia sint amet. Quo voluptatibus ea ut minus occaecati est. Aperiam qui repudiandae cum porro. Dolor magnam nisi similique laboriosam. Et in iste aliquid aspernatur.\n\nQuas voluptas odit minus eaque a illo numquam occaecati delectus. Ut enim cumque ex consequatur sunt autem voluptatem. Velit sunt omnis sed inventore. Sint nostrum reprehenderit. Est deleniti incidunt facilis dicta.\n\nMolestiae tenetur error. Doloremque sed quisquam assumenda delectus perferendis voluptatem ratione qui architecto. Dolor in quam quis doloribus non laudantium in porro. Autem qui molestiae. Ab minima laborum ut ut aliquid et explicabo et. Expedita porro corrupti quaerat doloremque adipisci animi.", null, null, "Example Page 2 - Paragraph 4", new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da") },
                    { new Guid("f8ee178b-0636-4147-bdb9-b8157c05f319"), "In optio asperiores totam sit nihil sint voluptatum optio laudantium. Voluptatem nulla officiis unde voluptas odio. Ratione laboriosam quo voluptatum qui. Earum quis cum commodi similique distinctio nemo eum atque doloribus. Omnis sed excepturi quas nulla ut et debitis sed.\n\nDucimus officia nemo quasi sint esse beatae rerum. Consequatur voluptas voluptate accusamus. Non voluptatem non qui voluptas sed qui fuga reprehenderit vitae.\n\nNeque eos reiciendis quis repellat totam recusandae sint qui. Iusto quam voluptate et eius. Quis iusto quia cum accusamus et minus quos delectus rerum. Culpa veritatis est similique accusantium ducimus officia ut. Maiores fugit deserunt nemo a aspernatur molestiae eum iusto quod.\n\nCupiditate libero placeat error. Error debitis architecto sed. Et est omnis. Sed consequatur dolorem commodi. Voluptas at quo expedita eius provident placeat et sunt.\n\nConsequatur libero dicta eligendi optio culpa. Autem at accusantium voluptas voluptatibus. Quos deserunt exercitationem quasi nam eaque dicta qui laudantium omnis. Provident non perspiciatis officia omnis aut velit id voluptatum. Qui nam culpa officia possimus.", null, null, "Example Page 1 - Paragraph 6", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("0f366336-96a8-4f47-aa1e-63eec29e78e5"), false, new Guid("75b44cd4-1af2-46c8-a6ab-9eb5cb11b430"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 13, 52, 53, 562, DateTimeKind.Local).AddTicks(387), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("6379b70d-ce6d-4fe3-a19c-4a5c0d5edfb9"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("0f366336-96a8-4f47-aa1e-63eec29e78e5") },
                    { new Guid("b3c50bfb-4481-4976-bbc7-9387c6c038d7"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("0f366336-96a8-4f47-aa1e-63eec29e78e5") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0bfa32f7-1e80-4071-a187-a2ff9f347f2f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("100c5552-cb69-4f07-8873-ea6db4b2b818"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("22fce5ec-0b94-4f8a-856e-876492f2f801"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5a1c0781-6844-44de-a6a3-14f25f271744"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5f3de8fc-c5bb-4566-9485-7c1f14f0115b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6d68349e-4be3-4248-9065-806001724cc8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("794afeab-35f8-4c70-a539-eb332aa5c99f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9e2baedd-2d5c-40c3-ad3d-24af13fe02b9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0b8b81de-b30c-4a8d-8807-e0e73c349b06"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("20fc12b6-1673-4547-a7a9-328795c01ff4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("23aa4115-53dd-422f-84c4-c2114be51fea"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("523a9f2b-3b4d-4a1f-9f50-b7abcda4d6cd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("58d281a1-8517-4c2d-ba96-57b0afa9fb2f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6379b70d-ce6d-4fe3-a19c-4a5c0d5edfb9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("68bcb6b4-e3b6-4199-af2f-f3a4ec04613c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("74d781aa-e4a5-4900-984e-36de00afd696"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("78cfd652-f4e5-455d-820c-54ad29f213f2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8b62fbd0-9a76-4547-b1a6-cc3fff9fa313"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("afca9c5f-0194-4ae1-97f2-aec878e71ee8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b3c50bfb-4481-4976-bbc7-9387c6c038d7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ccbddc69-ee6e-4267-89c3-313057dc11f6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e04c587a-535f-46df-9722-cd1a30337839"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e18e536e-d1aa-4c28-a8c2-6b9344286be0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f8ee178b-0636-4147-bdb9-b8157c05f319"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0f366336-96a8-4f47-aa1e-63eec29e78e5"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3e46d808-4abd-495a-ae7f-554bc82cb3da"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("6d286c60-8d03-4ef7-8b1a-47aa9f73772c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4f47ed28-8451-43ff-aa15-a029b11d0046"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("75b44cd4-1af2-46c8-a6ab-9eb5cb11b430"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b219656b-46d4-4c4b-a151-4f4e2cea2947"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d29cb33b-857d-454d-88c3-6d1cbbe1245f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("432d1f6b-c4ea-41d3-818b-ac1c8b778279"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("110f12c6-ff22-4bfa-957d-263647d694ff"), "Science and Technology" },
                    { new Guid("1e214b9a-d844-4b19-8746-a3e0d8ab092f"), "Food and Drink" },
                    { new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"), "Characters" },
                    { new Guid("45c103d5-e4e2-42a6-b2e2-5c7ab00b8b0d"), "History and Culture" },
                    { new Guid("548f3468-e506-44d6-9b2f-d31154f76d01"), "Organizations" },
                    { new Guid("5d4277e6-d9a3-4798-8ff0-6605fdcb5f84"), "Sports and Recreation" },
                    { new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"), "Events" },
                    { new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"), "Stories" },
                    { new Guid("84ff1ff6-75c8-4ef4-80dd-bf1d353ee56e"), "Concepts" },
                    { new Guid("a0184cf6-bb20-40be-ac48-359c42ee4d7f"), "Arts and Entertainment" },
                    { new Guid("aaecda94-0ca1-48bc-8eef-c7f12b5d6f19"), "Technologies" },
                    { new Guid("c87ac71d-1af4-4635-9c34-def734e10438"), "Locations" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7"), new Guid("21e251a9-4a74-4bf5-9f3c-5814284bacb0"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6339), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9"), false, new Guid("c87ac71d-1af4-4635-9c34-def734e10438"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6524), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4"), new Guid("847a5a61-63c4-40eb-825e-a598d14e85d1"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6383), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("00ec6c8d-8632-449a-b9d9-2dab8d597e57"), "Iusto quod similique ad debitis ducimus qui reprehenderit quam. Nobis voluptas sint. Placeat porro ad ipsam in molestiae. Laborum consectetur quia mollitia sed sequi tempora repellat ea.\n\nEt deleniti vel voluptates earum maxime aut temporibus sint velit. Omnis et minus aut maiores rerum alias. Modi in est omnis ad ut ut quae rerum. Consequatur ullam vero incidunt ducimus quod aliquid eum maiores est.", null, null, "Example Page 2 - Paragraph 5", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("1bfaf53d-0130-4713-a132-1045e6b72f3d"), "Eveniet maiores sunt autem. Est atque quam. Quas quia facere quisquam ratione ut aliquid est corporis. Voluptatem fugit aspernatur quia perspiciatis repudiandae cupiditate quia sint accusantium.", null, null, "Example Page 2 - Paragraph 6", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("2f7f430c-e1ed-4b12-b3eb-e6ba96327206"), "Nulla vero consectetur est a eos voluptates. Pariatur nobis eum. In enim non. Non consequatur qui reprehenderit quis aut dignissimos. Fugiat reprehenderit sed perspiciatis consectetur id ut. Rem molestias omnis sed.\n\nVoluptas placeat sit officiis officiis. Quo qui officia. Commodi quia rem sed repellendus ex voluptas. Rerum nam nemo aliquid.\n\nDebitis itaque molestias aut odit voluptatem fugit et consequatur. Repellat et debitis perspiciatis aliquam autem et non. Voluptatem sapiente architecto ut. Sit adipisci animi et molestias consequatur. Eum quia assumenda. Tempora tenetur consequatur consectetur vitae tempore.\n\nEst numquam natus nulla sequi voluptate in doloremque. Ut qui rem delectus itaque fuga itaque eum ea. Est aut error est suscipit. Est necessitatibus id et modi incidunt suscipit nulla asperiores voluptatum. Voluptatem dolorum itaque nesciunt.\n\nDolor facere fugiat omnis excepturi ut alias perspiciatis quos. Veniam perferendis ullam dolores aliquid sunt laboriosam. Quidem nobis quo eius expedita. Veniam enim ratione quas repudiandae. Et odit et.\n\nAutem et voluptates sapiente officiis sit autem qui omnis. Magnam tempore excepturi minus. Natus mollitia rerum voluptate placeat hic culpa consequatur.\n\nRerum nam molestiae qui iusto earum quae possimus consequatur. Ab sed porro mollitia. Quis deserunt nam nihil. Quae sit consectetur quos et ut.", null, null, "Example Page 1 - Paragraph 4", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("471d27b8-b7b4-40dd-a594-644d0bb07dc2"), "Qui esse cupiditate consequatur molestias. Voluptatum ea quam. Et saepe dolor autem a modi rerum laborum.\n\nSimilique ratione beatae velit suscipit eius voluptatibus in minus. Esse dicta doloremque hic corporis nam temporibus repellendus recusandae in. Distinctio et minus dolore.\n\nQuia voluptatem vel odit non eligendi. Ab molestiae deserunt explicabo autem fuga amet accusamus. Aperiam sit praesentium aut tempora voluptas temporibus aut optio. Illum laboriosam laboriosam vero perspiciatis officia et consequuntur odio ea. Suscipit vitae velit repudiandae asperiores. Totam voluptatum officia aspernatur.\n\nMagni est ut velit minima. Sed deserunt quae et ex quidem tempora. Expedita est et eos consectetur eum doloremque quia. Numquam itaque repudiandae. Quas aliquam non odit hic placeat autem. Quos harum iste.\n\nAb rerum facere excepturi consequuntur. Ut voluptatum sunt ut. Ut vitae id est facilis. Similique dicta est nesciunt veniam accusantium ipsum consequuntur quas est.\n\nEt consequatur recusandae. Et ut cupiditate accusantium reiciendis sunt beatae vel officia. Quibusdam et nam fugiat et quo recusandae id ut.\n\nExercitationem non nesciunt. Unde possimus odio quia iste et. Nostrum asperiores ex corporis quo a unde ea.\n\nSuscipit amet reprehenderit tenetur ut incidunt. Esse temporibus repellendus qui ipsum. Et id cum aperiam explicabo aliquid laudantium quia adipisci. Voluptas iusto reiciendis necessitatibus sit.", null, null, "Example Page 1 - Paragraph 5", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("846abb6a-adb7-45ee-b850-9e27afb0849c"), "Autem id impedit molestiae vero nesciunt. Qui assumenda dignissimos. Quam et suscipit qui. Sit ut aut suscipit labore error rerum voluptatem voluptate facere.\n\nNobis eligendi consequatur omnis ut dolorem exercitationem eum. Et atque qui rem explicabo libero eaque occaecati. Minima labore repellendus nihil repudiandae aliquam dolorum unde ut distinctio. Necessitatibus in sed veniam ut.", null, null, "Example Page 2 - Paragraph 4", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("908209b8-7c27-4781-80d2-34066f150aed"), "Minus a qui in reiciendis eum sed vel occaecati nihil. Ducimus molestias velit molestias nostrum sint et soluta. Nihil et sed nihil impedit incidunt. Quasi ab et maiores non inventore quos. Laboriosam eum natus eaque fuga reiciendis. Eveniet quod quidem.\n\nNihil velit esse ipsam rerum voluptatem ullam sequi aut consequatur. Natus cum eaque voluptates qui molestiae aut dolor corporis. Sed veniam quisquam ut at est iure amet.\n\nConsequatur impedit totam. Harum neque quisquam saepe consectetur ipsa. Qui praesentium voluptatem quae voluptas optio expedita. Nihil consequatur debitis hic ut ducimus unde illum.\n\nDicta itaque et eaque. Saepe at assumenda commodi praesentium consequuntur voluptates distinctio perferendis possimus. Delectus iusto ea a facere et.", null, null, "Example Page 1 - Paragraph 2", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("975a93b7-f3f1-4485-b46f-6e09fec883fb"), "Dignissimos nemo porro dignissimos est accusamus aperiam accusantium et eligendi. Ut incidunt nihil dicta aut. Quia facilis tenetur aliquid rerum eligendi sapiente debitis qui cumque.\n\nMolestias esse perspiciatis reiciendis sed sunt velit distinctio consequuntur. Iure sapiente fugit veniam sequi praesentium soluta. Quo hic minus quia id itaque sint molestiae. Neque enim natus ducimus ut voluptatem nam repellat nihil illo.\n\nEx sit veritatis rerum repellendus libero repudiandae iusto atque illo. Non sint necessitatibus optio. Optio totam molestias ullam placeat id blanditiis ut in beatae. Alias quibusdam mollitia sed est quibusdam aliquid dignissimos nihil. Dolor inventore alias eligendi quia accusamus blanditiis ut totam. Et eligendi ut in fugit rerum adipisci rerum in sapiente.\n\nId et facilis dolorum nulla sed magnam. Sed dolorem recusandae similique aut odio necessitatibus dolorem. Aperiam quia nihil eligendi eveniet exercitationem quas. Cupiditate nihil omnis voluptatum in labore.\n\nSint fugit ut et nihil quas voluptas minima. Qui doloribus at ut eum quaerat omnis reprehenderit ipsam. Exercitationem veniam et vitae sit quas ea nobis placeat. Et ea sed perferendis est omnis.\n\nNam est quam et. Dolorem odio rem sint qui. Sit ab velit. Voluptatem eaque qui et id voluptatem iure quia. Eum excepturi amet ipsa voluptas veritatis esse beatae. Voluptatem aut dolorem magnam aut laboriosam est similique commodi molestiae.", null, null, "Example Page 1 - Paragraph 3", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("9821227c-5345-41a5-b6ad-7e636a9b2b1c"), "Quia odit illo qui qui quia adipisci laboriosam. Assumenda commodi magni quis provident rerum hic accusamus voluptas. Natus enim quo expedita eveniet. Explicabo odit sequi qui voluptatem.\n\nSed quas perspiciatis et velit. Ipsum placeat nostrum cupiditate sint. Rerum exercitationem nam. Provident quos vel voluptatem sit aliquam. Deserunt vel porro odio rem impedit quia accusantium ipsam sapiente. Inventore perferendis laboriosam ullam ut dolor quis cum maiores placeat.\n\nConsequatur distinctio numquam recusandae. Sequi omnis ipsa. Debitis nam eveniet corrupti quod. Est et dolorem et inventore architecto iste rerum perferendis quo. Odit sed quidem voluptate tempora sunt.\n\nSit sit magnam repellat. Ab sed autem. Voluptas laborum totam sed officiis quasi consectetur consequatur.\n\nSit et soluta doloremque maiores minus eum. Occaecati blanditiis delectus excepturi qui sed. Facilis nam nesciunt aut commodi quod ab officiis fugit. Ut enim delectus. Corrupti ipsum qui et dolorum saepe laboriosam dolor reprehenderit.\n\nAt odit natus aut. Magni voluptatem et voluptate omnis odit. Aut et dolores repellat.\n\nQuae cupiditate beatae eos est voluptatem. Et voluptates eaque. Reiciendis rerum quam voluptates laudantium dignissimos. Autem inventore eos sunt occaecati reprehenderit nisi nemo et voluptatem. Odio sed incidunt laudantium expedita quis eligendi enim enim et. Dignissimos culpa hic cumque in.", null, null, "Example Page 2 - Paragraph 3", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("a27c0532-92c5-4b39-a897-bd2ce00f2c6f"), "Voluptatem a itaque laboriosam mollitia aliquam eos perspiciatis. Debitis incidunt sit quidem quasi qui voluptate iusto eum. Ipsa deserunt vel labore eius. Natus eum sint et veritatis explicabo unde. Aut et officiis placeat. Rerum eum est doloribus.\n\nEt blanditiis velit et voluptatem autem. Voluptatem modi quibusdam doloribus voluptatem odit ut cupiditate unde. Architecto delectus eligendi dolores occaecati aspernatur. Molestiae voluptatem non molestias enim doloribus explicabo corporis id.\n\nSunt et natus. Et vero consectetur quis veritatis. Consequatur incidunt et consequatur nemo dolorem.\n\nVelit perspiciatis nesciunt voluptate velit ratione itaque perspiciatis. Aspernatur neque aut nobis iste voluptatem ex. Voluptatem unde libero rem aut. Enim saepe excepturi veritatis voluptatibus. Ullam occaecati perspiciatis illum dolor ut eius qui.\n\nVoluptas ullam deleniti nobis quis et similique voluptatem. Voluptate et dolor non. Nihil optio est dicta ducimus qui consequuntur sit velit.\n\nConsectetur aut dolorem rerum. Eaque et eveniet doloremque deleniti maxime aliquid et a non. Soluta deserunt inventore sunt commodi consectetur.", null, null, "Example Page 2 - Paragraph 2", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("b2a39f1a-b60b-4f0e-af27-82886d305e57"), "Maiores quis impedit. Omnis hic quia voluptatem commodi repellendus minus. Est doloremque quos. Et culpa rem. Dolor aliquam occaecati est. Ipsum nam sapiente iusto.\n\nEt quos culpa et. Quam eveniet officiis adipisci illo rerum et temporibus. Consectetur alias corporis voluptas alias nulla. Velit dolor hic necessitatibus quos harum officiis et. Reiciendis voluptatem voluptatem sunt. Consequuntur dolor qui quia consequatur officia placeat maxime.\n\nNihil deserunt molestiae distinctio velit dolores iste et commodi. Dolorum fugit dolores dignissimos maiores. Beatae et velit. Possimus in provident vel.\n\nCupiditate reprehenderit vero ipsa. Facere placeat et recusandae. Incidunt qui saepe. Sequi aut dicta sit perferendis.\n\nHic et et mollitia recusandae ut fugiat earum exercitationem est. Dolorum qui molestiae quidem molestiae rem molestias explicabo. Velit corrupti delectus. Et ipsa sapiente.\n\nConsectetur totam sit. Ab perferendis quas est optio suscipit vel voluptas id. Suscipit fuga voluptatem iure aperiam tenetur perferendis.\n\nA non molestiae possimus impedit id aliquid quibusdam velit. Impedit qui voluptatibus quas vero molestiae. Voluptas ea quaerat minus nulla. Rem quos inventore nemo. Autem eligendi aut harum molestias quis veniam numquam. Id ipsa maxime deserunt et aut dolor culpa.\n\nEt quia id eos. Tenetur laudantium autem quo. Quo quisquam et. Rerum quidem provident consectetur quae. Voluptatem itaque ea ea eaque ullam officiis.\n\nQuaerat quas qui sunt architecto sint. Tenetur dolorem praesentium fugit dolores. Quia voluptatem nostrum. Corrupti ab vitae harum id repudiandae voluptatibus. Odio laborum in fugit aspernatur exercitationem blanditiis quia quasi.", null, null, "Example Page 1 - Paragraph 6", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("b59a74e2-6f6c-4715-b26d-229c3f5cae1c"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9") },
                    { new Guid("c1e98e1a-b8ec-4d9d-a5e4-0f5402863f2d"), "Ad incidunt odit eveniet et voluptatum a labore. Eveniet assumenda in consequatur voluptas porro odio sint explicabo placeat. Perspiciatis reiciendis similique blanditiis voluptas consequatur quaerat.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("d8fe95ef-1b31-404e-990a-556f690ed2a4") },
                    { new Guid("dad5179d-ee12-46f7-8e81-cd8a5bb41b14"), "Impedit vero nesciunt dicta. Dicta sint voluptates nisi voluptatum dolorem accusamus eum libero velit. Autem officiis consequatur numquam sapiente. Perferendis ipsum voluptas aliquam facere illo similique consequatur ut repellat.\n\nIn rerum deleniti et. Occaecati ab omnis omnis impedit distinctio ut ipsam et dolor. Et nihil harum saepe dolor facilis. Minus reprehenderit eos velit.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") },
                    { new Guid("e849bed8-972e-4c8e-bc8f-61f46ff292d6"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("d661ab2f-5d63-40bc-8522-1c4b92ef4cd9") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b"), false, new Guid("7dc38e0a-0767-49f8-bea2-95051f0fbaed"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 12, 25, 15, 911, DateTimeKind.Local).AddTicks(6528), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("c19f04b9-55af-40ab-9388-57af87b2e7a7") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0805951f-90b1-457b-85ef-7c8f39996d88"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b") },
                    { new Guid("852ac18a-7c71-4317-b502-344d01edceab"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("c144326f-b151-4ebd-a6ff-87b0def3f30b") }
                });
        }
    }
}
