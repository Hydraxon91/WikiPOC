using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddOrderToForumTopic : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "ForumTopics",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "Order",
                table: "ForumTopics");

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
    }
}
