using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiPageWithImageInputModelUpdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0822b690-01ef-4a1d-a083-324cd95225f2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c1feebd-ee1e-4c75-bb53-650bd4c39227"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c8bc1a2-3a72-448c-b928-d0d35aa210a4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("373babee-6748-431a-89c0-bfe649ecc94f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("37cd6513-798f-43ac-8624-380493dd7d57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("473df0cf-2d1d-442b-a815-420c0efc4eb2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6c6d902a-fdba-4137-b8f2-80c9b13c2a8e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("80ef4cb5-bffd-4010-ae67-e0b14e703695"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a472d801-47f6-44ee-ac60-1b1974bd9e7f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b772d9f1-940b-43a4-8e6d-acd27480c3e2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c81a2467-abb0-4289-8592-4d3f86944eb3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d5072538-4596-4567-884b-006d013b244b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6252b5f-f0d2-4428-8714-929957caee97"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d9e78e28-dab6-44d6-b8ae-dc8266e27085"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e17d7ddf-31e9-4e72-8930-24a44839fd56"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e9ddc009-8b6b-4c4b-9505-79e354308faf"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("7755a574-b34e-4848-afc0-c02472764aaa"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64"));

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("8e988ccd-fe30-4bb1-ab76-4436cda23467"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0a07bb14-14c9-4540-adfc-6accd093fbff"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("8e988ccd-fe30-4bb1-ab76-4436cda23467") },
                    { new Guid("284c171d-cab6-49f2-908c-0f80c216c6c2"), "Dolores id aut consequatur molestias enim. Ipsum tempora impedit est perferendis temporibus non. Perferendis voluptas eligendi tempora. Accusamus voluptatem asperiores necessitatibus molestiae numquam. Provident ut quam quam eum doloremque. Vero eius est dolore magnam voluptatum.", null, null, "Example Page 1 - Paragraph 5", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("5d8df614-760a-42bc-a62b-d95ca16f6359"), "In eos reiciendis illum ut. Porro error alias laboriosam maxime illum quis quos neque. Sed assumenda ipsa reiciendis ex non beatae eos voluptatum. Dolorem iusto et.\n\nAut labore aut exercitationem et nisi magni voluptas. Et ex amet. Sunt nostrum repudiandae.", null, null, "Example Page 1 - Paragraph 6", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("5e7cbdcb-57b1-4e74-8339-39f0b580b5f3"), "Ullam reprehenderit consequatur accusamus eligendi odio sunt. Id cum doloribus est porro ex ea dolore eveniet. Officiis culpa rerum. Doloribus temporibus qui. Natus debitis sit possimus aliquid illum illo ducimus. Harum dignissimos illo veritatis reprehenderit qui sequi eius eaque.", null, null, "Example Page 2 - Paragraph 4", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") },
                    { new Guid("6ef68cca-f0c1-4571-a87f-e968d5e38539"), "Velit est quibusdam quo a fuga numquam ut quasi. Atque voluptas provident sint. Non assumenda sit magnam. Impedit nemo vitae. Corporis magni pariatur voluptas in autem.\n\nSint laborum autem qui et. Quo rerum omnis praesentium incidunt quas nihil quos voluptatem. Nihil qui omnis.\n\nQuasi aperiam eveniet. Maxime inventore iste qui iusto fuga facere vel recusandae. Quos molestiae sit eligendi quas. Officia eum iste et iusto omnis est earum eveniet.\n\nUt accusamus consequatur sapiente molestiae hic. Laborum exercitationem consequatur ut earum nam dignissimos in. Qui nesciunt consequatur exercitationem aut consequatur dolore. Sit laboriosam dolor velit dolores omnis in animi perspiciatis.", null, null, "Example Page 2 - Paragraph 5", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") },
                    { new Guid("713291b6-b791-4aee-93d0-f7afcd409936"), "Voluptas aut non quae expedita sed nobis dolorem. Quos aut saepe unde veniam sit et voluptatem. Possimus minima voluptatem vel aut sapiente hic. Consequatur distinctio repudiandae a sunt magnam. Ipsum qui qui ipsa.", null, null, "Example Page 1 - Paragraph 4", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("80d03e63-080c-4a4e-a071-c399721e4b57"), "Consequuntur tempora laudantium ratione laborum. Id et sunt eius temporibus nihil consequatur omnis. Voluptas minima quas sint omnis.\n\nQuo modi voluptas. Corrupti minus earum architecto distinctio rerum accusamus consectetur et. Est rerum omnis velit omnis voluptatem.\n\nDistinctio distinctio atque non voluptatem. Quam eos dolorem corporis deleniti quia. Illum quia sit quibusdam asperiores id consequatur. Consequatur quae voluptatibus. Omnis ratione doloremque eveniet sapiente facilis.\n\nQuia dolores necessitatibus voluptatem pariatur illo dolore eos. Est amet aperiam quasi necessitatibus voluptatibus id provident labore. Qui sed cupiditate earum sit. Quia accusamus optio saepe est cum. Officiis nostrum labore nisi reprehenderit inventore.\n\nEst et quae maiores sed similique cupiditate accusantium cupiditate esse. Natus commodi rerum debitis quia odit perferendis. Aut consequuntur est soluta itaque autem enim rem placeat sed. Voluptas autem at facilis sint sit. Repellendus sit exercitationem deserunt adipisci.\n\nVoluptatem nulla minima. Quo reiciendis et necessitatibus aut cum expedita excepturi. Quia laboriosam officia quia perferendis. Commodi dolorem commodi.\n\nAdipisci ratione quam aut est natus omnis. Animi qui quia sunt quia similique occaecati expedita. Ut quae sit distinctio error et officiis voluptatem.\n\nDolorem facere est omnis nemo cumque. Blanditiis doloribus nisi quos velit. Dolorem qui cumque. Corrupti non eius sed ut eum illum culpa. Voluptas nam soluta et eius quae vitae maxime vero amet. Vel sit quo possimus sequi cum minus velit et.\n\nNon ut deserunt sunt fuga nihil molestiae dicta molestiae. Sit dolores repellat dolorem. Voluptate amet tenetur architecto excepturi quas asperiores veritatis hic tempore. Officia eum nisi. Eius ut maxime et eveniet optio.\n\nPerferendis quis est corrupti odio voluptates et dolor rerum. Dolores deleniti porro dolore velit quia adipisci vero et. Rerum earum illo et. Est quaerat consectetur saepe sed expedita placeat ipsa rerum perferendis. Qui ex eum rerum enim incidunt distinctio expedita laborum. Nulla possimus sit molestias fuga vero omnis repellendus quia.", null, null, "Example Page 1 - Paragraph 2", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("a5b4f37a-a22b-496c-be7b-f62664ca51aa"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("8e988ccd-fe30-4bb1-ab76-4436cda23467") },
                    { new Guid("ac361ee0-8712-464b-82f3-cfbb01b5e827"), "Culpa laboriosam pariatur ducimus. Sit hic ut eos cum nostrum ut natus commodi. Omnis quo eum ut aliquid delectus quia molestiae cupiditate maxime. Atque illum nesciunt dolore aut. Deserunt animi veniam nam id.\n\nSed ea tempore deserunt rem incidunt officia. Voluptatem qui excepturi non est repudiandae incidunt quis accusamus minus. Sed sapiente nemo et velit minima cum. Rerum magnam enim omnis aut quidem quam cupiditate iure. Aut voluptatum id tenetur enim. Fuga architecto modi iusto omnis.\n\nOccaecati aliquid voluptatibus ut est saepe necessitatibus temporibus aut nihil. Vitae unde incidunt mollitia officia. Et quis at velit corrupti. Rerum voluptas ut vel in illo sunt quam.\n\nQuibusdam perspiciatis numquam aliquam est ducimus quisquam quibusdam. Dolorum ad labore vero quis ea. Excepturi non optio et laboriosam sit.\n\nEt iste soluta. Dolores ex cumque enim sunt id maxime sapiente quo quis. Non enim optio soluta consequatur quia iusto labore qui. Distinctio fugit ad beatae tenetur qui deleniti sed qui provident.\n\nCorrupti est quod laudantium vero eos similique quia. Qui omnis ea earum ex. In nostrum commodi et sint laborum. Molestias ut rerum consectetur totam sint consequatur vitae nulla quos. Harum modi incidunt.\n\nSed voluptate in at quia voluptatem reiciendis. Quasi quo minus. Mollitia voluptatem aut impedit est illo. Doloribus occaecati quidem consequuntur iusto nesciunt quae ipsam velit. Quasi ipsam totam temporibus corporis sapiente perferendis. Ipsam commodi et sequi sed aut et non.\n\nEt quaerat aut enim qui autem. Laborum rerum dolorem omnis qui sequi excepturi. Et consequatur magni tempora odit alias eveniet enim exercitationem. Neque quidem dicta et. Nulla ipsum saepe.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") },
                    { new Guid("acb65d33-502f-43b9-b01c-b97220f00546"), "Doloribus est magnam iste nam veritatis velit alias ut omnis. Consequatur in sint voluptatem nobis occaecati consequuntur alias corrupti. Commodi quam necessitatibus quisquam eaque dolores. Deserunt dolores dolorem magnam.\n\nSimilique velit doloremque alias et nihil provident sit. Quod consequatur et cupiditate omnis. Quis quos vel aut aut. Dolorum placeat inventore animi ipsam nisi.\n\nTempora illum vel. Nisi deserunt optio molestiae tempore aut accusamus. Minus voluptatem neque inventore sed quae est.\n\nNon sed expedita sed. Molestias eaque reprehenderit quis cum neque. Incidunt non magnam. Sed possimus qui laboriosam. Quibusdam ipsam ducimus beatae nulla. Recusandae et sed vitae nihil odio.\n\nAutem expedita voluptatem expedita minus odio omnis fuga ut. Unde atque sed corrupti itaque consectetur. Perspiciatis iusto est consequatur iure sapiente esse qui voluptas. Delectus neque quibusdam rerum voluptatem quaerat. Et id vel illo omnis. Blanditiis facilis velit deserunt eius sint aut mollitia vel.", null, null, "Example Page 2 - Paragraph 6", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") },
                    { new Guid("af66dea5-c5e9-421b-a668-2b0282d4f655"), "Voluptates ipsum officia sint quisquam nesciunt. Vel placeat eveniet quidem sit tempora. Inventore facilis non cupiditate tempore repellat alias a ipsa. Enim culpa eius asperiores. Sit dolor possimus est.\n\nSit repellat quam qui eos. Alias autem aut dolores sed error qui maxime sed. Quidem qui animi assumenda omnis nihil ullam quisquam molestiae sequi. Maxime occaecati provident nulla aut sunt sit consequuntur et minus. Deserunt sed quia saepe. Numquam itaque quidem esse consectetur.\n\nNobis enim molestiae amet placeat repellat rerum. Fugiat totam quas nobis fugit corporis maxime eos tempora eveniet. Omnis cumque cumque cumque cum vero ut illum.\n\nAdipisci voluptas mollitia. Ut qui architecto inventore aut sapiente ea ex. Quia veritatis quo laborum est molestiae voluptas vel eaque. Provident sit similique tempore dolor non tenetur praesentium et. Est voluptatem natus non rerum aut voluptatibus. Modi voluptatum dicta ipsa quia labore nihil voluptatibus commodi.\n\nQuia et voluptates illo doloribus neque fugiat et et id. Recusandae porro expedita id odit explicabo quis. Facilis dicta quasi expedita deleniti consequatur nulla et nobis. Eos et corrupti omnis accusantium id illo.\n\nDeserunt quis quasi dicta. Tempore magni ipsa et velit consequatur cum. Aut iusto dolorem qui possimus facilis. Harum voluptate aliquid laudantium.", null, null, "Example Page 2 - Paragraph 3", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") },
                    { new Guid("c1b30a46-5505-4da1-9d08-6a5cd8e3ef44"), "Soluta non vitae ipsam asperiores at ut. Magnam ratione iste. Reprehenderit voluptatibus rerum sint repudiandae eius veritatis nobis. Blanditiis numquam molestiae aut quia. Natus aut ea qui inventore esse error quis. Sed cumque veritatis asperiores nesciunt dolor quia eum ab debitis.\n\nQuia non quod reiciendis veritatis. Temporibus ratione nemo qui delectus quos dolor dolor perferendis provident. Eveniet sint ut ratione non. Recusandae quia cumque fuga corrupti itaque ex dolores est. Ducimus nulla quia sit sit et distinctio natus ab eum.\n\nAut sapiente ducimus quis molestiae. Qui laudantium autem qui minus est et voluptatem sit. Eos voluptatem non aperiam dolores. Ipsa laborum tenetur dolores sint et et.\n\nExcepturi mollitia a omnis. Laudantium nisi consectetur maxime recusandae sunt ut laboriosam eos nihil. Quos est maiores. Soluta ab et molestias facilis ducimus fugit. Corrupti illum dicta repudiandae magnam voluptatum quaerat. Laudantium provident laudantium facilis ut aut consequuntur amet quasi.\n\nModi illum dolorem voluptatem ipsam et quo. Ea in dolor error eum earum. Dolorum reprehenderit aliquid aperiam iste. Autem aliquid fugit possimus fugiat accusamus itaque.\n\nUt iste minus delectus aut incidunt et animi. Nulla sapiente voluptatem. Ut est perferendis tenetur repellat quidem quidem cumque ex. A totam vel.\n\nIllo quis possimus. Pariatur ut voluptates omnis optio voluptates quisquam rerum voluptatem. Quia a ut culpa nobis libero iure dolores.", null, null, "Example Page 1 - Paragraph 3", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("f1424003-bc4f-48d2-bf30-ebc8c5c5212a"), "Rerum veritatis maxime. Soluta labore dolores est possimus rerum non. Rerum beatae vitae qui suscipit aperiam est repudiandae omnis.\n\nOmnis praesentium nesciunt ex aut reprehenderit et qui. Ut ut non quos facere aut totam natus ut fugit. Quo impedit ipsa consectetur recusandae magni suscipit quis. Repellendus veniam vel veritatis reprehenderit est.\n\nVoluptas quo accusantium quisquam soluta eum id tempore. Voluptatem aliquam quaerat ab id sed. Facere esse totam aspernatur explicabo aut enim dolore eveniet.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") },
                    { new Guid("f90751f3-81e9-4677-b156-8c19d1a7a964"), "Magni ut quia. Maxime corrupti laborum ad sint non quasi dicta. Unde repellendus aliquam aut ad voluptatem.\n\nLabore veritatis aut at ea deserunt quis vel. Sit pariatur alias. Natus quia corrupti natus ipsam itaque recusandae. Nulla beatae at.\n\nReiciendis aperiam et eius assumenda occaecati qui vitae. Neque incidunt aut molestiae facilis consectetur quae accusantium. Atque deleniti ipsum laboriosam accusantium accusamus magnam. Deleniti porro tempore qui sed quos. Enim mollitia corporis illum voluptate corrupti quo.\n\nQuidem est voluptatibus quam. Dolor aut sequi eaque sit. Porro laboriosam quia ratione adipisci facere. Deleniti ullam est nihil aut eligendi. Optio nihil nostrum asperiores vel aut quia quasi officia. Aut eos amet eveniet consequuntur suscipit nulla.", null, null, "Example Page 2 - Paragraph 2", new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("f306c3f1-8910-4929-ae4d-cde0e87e6451"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("2d8d7ff6-e97d-438d-a379-1c192351ea9e"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("f306c3f1-8910-4929-ae4d-cde0e87e6451") },
                    { new Guid("dc5dccc1-b2cb-4af7-be62-ca2d4b876c40"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("f306c3f1-8910-4929-ae4d-cde0e87e6451") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0a07bb14-14c9-4540-adfc-6accd093fbff"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("284c171d-cab6-49f2-908c-0f80c216c6c2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2d8d7ff6-e97d-438d-a379-1c192351ea9e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5d8df614-760a-42bc-a62b-d95ca16f6359"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5e7cbdcb-57b1-4e74-8339-39f0b580b5f3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6ef68cca-f0c1-4571-a87f-e968d5e38539"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("713291b6-b791-4aee-93d0-f7afcd409936"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("80d03e63-080c-4a4e-a071-c399721e4b57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a5b4f37a-a22b-496c-be7b-f62664ca51aa"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ac361ee0-8712-464b-82f3-cfbb01b5e827"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("acb65d33-502f-43b9-b01c-b97220f00546"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("af66dea5-c5e9-421b-a668-2b0282d4f655"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c1b30a46-5505-4da1-9d08-6a5cd8e3ef44"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("dc5dccc1-b2cb-4af7-be62-ca2d4b876c40"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f1424003-bc4f-48d2-bf30-ebc8c5c5212a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f90751f3-81e9-4677-b156-8c19d1a7a964"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("7ce43b65-d073-4f9a-aaa0-15978b1a2465"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("8e988ccd-fe30-4bb1-ab76-4436cda23467"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("f306c3f1-8910-4929-ae4d-cde0e87e6451"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3488cef7-6cd1-4f6c-aed0-f1515cd3a9e2"));

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("7755a574-b34e-4848-afc0-c02472764aaa"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0822b690-01ef-4a1d-a083-324cd95225f2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("7755a574-b34e-4848-afc0-c02472764aaa") },
                    { new Guid("1c1feebd-ee1e-4c75-bb53-650bd4c39227"), "Quo nesciunt voluptas debitis voluptate quaerat deleniti nobis error. Necessitatibus iste quos maxime minus ducimus sed in aut cumque. Praesentium perferendis quos fuga dignissimos sit mollitia et.\n\nOdit ut cumque nostrum alias aut vel. Amet quia dolor omnis nostrum ut. Libero quia dolor laudantium inventore commodi eum. Reprehenderit cum ut voluptatum voluptatem sunt porro at. Explicabo excepturi vero nam asperiores non dicta deserunt. Sint optio accusantium magnam alias magni id praesentium.", null, null, "Example Page 2 - Paragraph 3", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("1c8bc1a2-3a72-448c-b928-d0d35aa210a4"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("7755a574-b34e-4848-afc0-c02472764aaa") },
                    { new Guid("373babee-6748-431a-89c0-bfe649ecc94f"), "Debitis eum et debitis voluptatum. Eveniet autem architecto sapiente harum dolorem explicabo impedit explicabo officiis. Est non et expedita deserunt enim. Nemo repellendus voluptatem tempora quia omnis fugiat.\n\nTotam et iusto qui voluptatem cumque aliquid optio beatae. Libero perferendis facere placeat tenetur adipisci quos nihil. Placeat voluptatem esse quae quae quae.\n\nDoloremque est sint. Consequatur quia corporis ad commodi excepturi aspernatur et neque quaerat. Velit provident doloribus neque nihil.\n\nDebitis doloribus iure natus quod architecto quidem nobis quia. Sed quas rem eum reprehenderit sint. Fuga velit laudantium impedit velit commodi quisquam. Porro aliquid quia vero corporis. Debitis soluta id architecto et quam.\n\nSunt maxime voluptatum. Omnis reprehenderit sint necessitatibus saepe. Aut voluptatum esse earum voluptatem esse id assumenda. Voluptas corporis quam.\n\nOfficia asperiores porro possimus ut ratione a hic amet. Eos placeat cumque beatae et voluptates. Iste eligendi officiis qui blanditiis et nihil rerum. Libero qui eveniet eum repellendus quibusdam. Commodi ratione facilis fugiat ipsum.\n\nSunt natus et quasi sed unde. Impedit quia cum occaecati unde quae explicabo rerum repellendus ut. Sunt sit sed sint voluptatem sapiente eligendi sed. Fugit libero optio possimus voluptatum voluptatem delectus.", null, null, "Example Page 1 - Paragraph 3", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("37cd6513-798f-43ac-8624-380493dd7d57"), "Aut sed sint est voluptas. Esse aliquam eum molestias ullam dolor reiciendis quia. Cupiditate itaque quidem accusamus eos id quis sit. Quaerat maxime expedita eum non qui sed neque.\n\nEt molestiae aspernatur nemo explicabo. Sequi magni nulla itaque magni dolores ullam quod enim dolorum. Officiis aut similique ut autem. Accusamus voluptatem sapiente. Perferendis quia amet quis sed.\n\nNostrum similique perferendis. Ut id et quaerat blanditiis. Rerum nihil qui eum dolores aperiam. Sed suscipit sunt harum fugit optio dolorum.\n\nQuam totam ipsam quo sapiente veniam. Laboriosam doloremque possimus quia ut quisquam et sed. Voluptatem ut sint id quaerat. Quod voluptatum vero quo.\n\nOfficia harum dolorem esse ducimus quia distinctio. Nisi cupiditate enim voluptatem rem illo qui eum sit quia. Quibusdam repudiandae asperiores. Repellat sed ad quo ut aut sit. Animi omnis aut qui odit ut odio at minima. Omnis qui sed facilis ratione maxime qui impedit omnis.\n\nDoloribus eum ipsa ea omnis. Optio ut et saepe beatae consequuntur consequatur consequatur qui sequi. Quis sint repellendus enim necessitatibus. Quos impedit aut ad.\n\nMagnam quasi et fugit sit. Repudiandae aut quia quia et in dolor expedita deleniti animi. Culpa non laborum voluptatem cumque quibusdam enim magnam et veritatis. Laudantium qui quam qui quia dicta repudiandae.\n\nDicta iure architecto rem in. Ad assumenda eligendi provident nam ut aliquid nisi. Odio atque quia quidem excepturi. Nihil voluptatem ut. Nihil quisquam inventore at consequatur quisquam quasi. Aut voluptas alias nobis quis.\n\nExpedita optio dolore dolor soluta cum consequatur praesentium eius. Quia odit molestiae odit officia fuga. Facere placeat aliquid molestias iusto qui. Quia nam placeat qui quam tempore dicta.\n\nEt non est rerum atque eaque. Assumenda voluptatem dolores enim qui pariatur enim occaecati ut quae. Adipisci quia saepe aut quis voluptas sed nobis ut debitis. Ab sapiente animi quo quasi et. Amet ut consequatur repellat mollitia architecto cum reiciendis ipsa et.", null, null, "Example Page 2 - Paragraph 2", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("473df0cf-2d1d-442b-a815-420c0efc4eb2"), "Et et ut reprehenderit qui laudantium maxime magnam in. Blanditiis et sint. Nostrum consectetur vel minima ut aut aliquid soluta quisquam. Animi qui deleniti deleniti deleniti.\n\nOfficia et velit dolor quia sint aut unde. Doloribus necessitatibus quo dolorum adipisci et quas non. Ut sint blanditiis eos maxime iusto. Facilis minima molestiae ipsum unde minima sapiente quia. Non nisi repellat beatae eaque occaecati odio molestiae iste deserunt.\n\nEt error beatae laudantium nemo nulla nobis. Ut in sunt. Non dicta adipisci dolores quidem quisquam saepe voluptatem. Doloribus libero quos quae eos. Fugiat ut sint et.\n\nUnde voluptate eum autem est. Amet eum non architecto nobis numquam est repellendus error sint. Nihil atque est beatae ut.\n\nIn velit similique aperiam. Molestiae voluptate ea aspernatur rerum praesentium aliquam velit et quis. Esse ea harum expedita iusto aut earum possimus ratione possimus. Dolores magnam est sit hic quisquam blanditiis et in veniam. Odio nobis aut enim fuga quos perspiciatis exercitationem veritatis et.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("6c6d902a-fdba-4137-b8f2-80c9b13c2a8e"), "Earum dolor maxime placeat sit nihil ipsum. Sequi et sint aspernatur vitae delectus modi. Nisi eos enim nulla delectus aperiam minima et ab voluptas.\n\nRepudiandae minima voluptas quas voluptas omnis dolores totam et. Laborum quisquam accusamus impedit ducimus repellat ratione omnis unde officiis. Nihil aliquam provident id nesciunt velit porro sit voluptas. Qui quaerat ab et. Praesentium voluptas ipsa sint necessitatibus nihil in qui eum.", null, null, "Example Page 2 - Paragraph 6", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("80ef4cb5-bffd-4010-ae67-e0b14e703695"), "Sunt voluptas quo soluta eveniet vel officiis veritatis quam. Cupiditate quia iste unde quibusdam quam sit est quam. Occaecati iure ut laudantium numquam aliquam. Ut autem porro. Sunt alias perferendis voluptas omnis odio et. Aliquam laudantium nihil repellendus deserunt tenetur dolorem amet nam.\n\nTotam dolorem et. Voluptate facere dolorem laboriosam quos qui. Ex quisquam placeat. Qui eveniet harum.\n\nSit velit quod voluptatem dolorem est. Harum nemo maiores veniam ipsum. Sed commodi voluptatem fugiat error. Nihil dolorem consectetur minus quo. Officiis dolores et. Omnis vero tenetur qui vero.\n\nAd praesentium voluptas corporis veritatis qui aperiam. Odio ea eum suscipit ipsam ut reprehenderit iste et. Aliquid corporis voluptatibus dolor quos. Voluptatum officia ipsa excepturi dolor quo modi. Ex aperiam eum harum quia eaque dolor assumenda. Et facere enim est itaque assumenda quis voluptatem atque consequatur.\n\nProvident dolorem repudiandae tempore saepe natus eum inventore vel qui. Non laudantium molestiae quia est eveniet similique ad. Nihil provident dolores est quis accusantium omnis sunt. Necessitatibus aut et. Id odio est omnis harum deserunt.\n\nAtque necessitatibus et labore. Quis itaque non et amet. Sequi deleniti illum commodi ipsam. Ipsam nihil accusantium labore eum perspiciatis. Velit similique velit asperiores repudiandae omnis molestiae.\n\nMagnam natus hic quia tempore maxime sequi. Doloremque est excepturi delectus. Voluptate sit ut.\n\nFugit quia dicta ad molestiae eos cupiditate fugit. Quo aut aut rerum ut quod pariatur est sequi. Nisi iste aut quia ut qui. Dolores pariatur animi. Consequatur tempora reiciendis rerum ut necessitatibus. Quae et voluptas dignissimos eos tempore.", null, null, "Example Page 1 - Paragraph 5", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("a472d801-47f6-44ee-ac60-1b1974bd9e7f"), "Porro provident et sapiente eaque quos sit quia est. Enim perspiciatis provident rerum esse eveniet eos ipsam ab expedita. Fugiat sit ut rerum. Vero eaque quia iusto laboriosam explicabo illum minus.\n\nVoluptas non voluptatem voluptate. Ullam optio placeat soluta tempore rerum dolorum fugiat et. Repellat ducimus praesentium consectetur laudantium eaque. Qui eum distinctio cumque tempore magni non. Porro neque praesentium quaerat fugiat voluptatem ad. Vel sint quae consequuntur ex qui qui.\n\nAut qui totam pariatur tenetur. Sequi adipisci delectus dolore. Eius error reprehenderit quae velit cumque assumenda ea. Et nemo nesciunt voluptatum qui voluptas. Error dolor libero rem dolore ducimus aut.", null, null, "Example Page 1 - Paragraph 6", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("b772d9f1-940b-43a4-8e6d-acd27480c3e2"), "Nihil porro sed repellendus. Consequuntur cumque adipisci. Sed laudantium veniam quis odit corporis autem magni laudantium. Quo ducimus ut libero sint eveniet minima sit minima porro. Cupiditate vel dolorem at magni qui quam amet.\n\nEt modi nihil. Vero possimus et. Eum excepturi enim et quia nam possimus fuga.\n\nNemo cumque qui assumenda placeat. Sit qui autem illum necessitatibus reiciendis. Voluptas amet eos libero quia et. Consequuntur sit incidunt sapiente dolorem et qui.\n\nEt nemo veritatis debitis mollitia qui cupiditate et. Atque sit labore optio ullam. Itaque excepturi harum ducimus autem provident vero omnis et labore. Provident quas molestiae magnam ex iusto quas aut repudiandae. Corporis amet dolor et delectus ut praesentium qui quam sed.\n\nEarum dolorem consequuntur omnis. Veritatis debitis hic. Aspernatur architecto eius aut quis sit.\n\nItaque unde voluptate commodi harum et ut praesentium maiores. Qui odit consequatur. Quo vel iste inventore ullam asperiores vel.", null, null, "Example Page 2 - Paragraph 4", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("d5072538-4596-4567-884b-006d013b244b"), "Quis quidem sit consequatur qui est quibusdam illo eligendi quasi. Impedit fuga non laudantium at et reiciendis. Non odio aut maxime architecto error ipsum. Aut laboriosam vitae sed.\n\nMaiores cupiditate facere omnis recusandae vitae veritatis ducimus minima. Laborum quia rerum pariatur sint et soluta exercitationem enim vero. Molestiae quod exercitationem qui.\n\nConsequatur vel aliquid commodi perspiciatis. Et nesciunt consequatur est alias. Qui sit porro hic quia pariatur qui dicta. Deserunt laboriosam ut omnis nesciunt provident provident. Quia autem deleniti exercitationem. Odio fugit possimus quisquam quo odit veniam dolores.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("d9e78e28-dab6-44d6-b8ae-dc8266e27085"), "Saepe et ad pariatur. Ipsam non quia amet omnis. Eius aliquam placeat aliquid ut laudantium. Et aspernatur dolor error.\n\nSuscipit rem nostrum nulla inventore facilis. Quas enim vitae dolorem neque consequatur. Quia explicabo tempore sit dolores. Eaque nostrum delectus ea repellat id.\n\nEum dignissimos ullam tenetur quis et aspernatur. Doloremque quod consectetur. Facilis nemo enim. Eum dolor sed. A nesciunt unde et quis consectetur laudantium nihil.\n\nId praesentium sit recusandae dolores. Quo et neque fuga rerum libero sint. Aliquam similique explicabo explicabo et aspernatur. Vitae officiis sunt incidunt accusamus accusamus. Enim magni hic molestiae sapiente qui cumque magnam.\n\nUt et possimus quod est ut qui officiis. In ratione odit dolorem aspernatur cumque dolor dolorum. Praesentium facere asperiores aut. Nihil at voluptatem qui soluta. Voluptatem animi soluta. Tempore qui eos sint error.\n\nId laudantium culpa officia sed. Modi officia eveniet qui at quam laboriosam laudantium. Nemo quis magni molestias rerum id dignissimos at rem qui. Dolor quasi sit animi minima hic autem alias accusantium perspiciatis. Culpa voluptatem inventore doloremque. Et repellat aspernatur commodi magni repellat.\n\nEst nisi nam ratione ut consequatur quae porro delectus. Asperiores itaque quos eius. Amet ut aut non. Dolorem eum fuga consequatur illum unde. Aut sed nisi placeat aut sint at. Aut inventore nam pariatur.", null, null, "Example Page 1 - Paragraph 4", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("e17d7ddf-31e9-4e72-8930-24a44839fd56"), "Ipsam omnis accusantium doloribus et. Ut aut aut repellat maxime nihil sed. Quia soluta dolore qui quas nesciunt ipsum eius qui est. Architecto temporibus ut excepturi nostrum est sit. A praesentium qui impedit tempora et doloremque excepturi rem.\n\nOfficiis accusantium aperiam. Maiores aut enim molestiae enim ut unde. Et tempora earum autem quia. Dolor eveniet distinctio. Dolore earum id temporibus cumque porro ut est.", null, null, "Example Page 1 - Paragraph 2", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("e9ddc009-8b6b-4c4b-9505-79e354308faf"), "Non aut sapiente. Recusandae est accusamus. Non non ipsa perspiciatis mollitia ut ut quis similique.\n\nUt consequatur expedita quasi facilis quae. Delectus architecto accusantium quas non. Aut voluptates dolorem officia laudantium molestiae. Et dignissimos repellat eos aut. Et optio consectetur molestiae praesentium deserunt ipsum veritatis.\n\nQuaerat voluptates quidem ea enim doloremque nobis ducimus. Animi quo quia accusantium voluptas perferendis. Et dolore reiciendis commodi possimus. Odit provident voluptatum dolore eligendi quasi ea repellat.\n\nQuos et accusantium a reprehenderit non numquam iusto quia eaque. Est quis iure alias quasi quis placeat. Numquam voluptatem quod suscipit sequi laboriosam.\n\nIpsum pariatur laboriosam libero exercitationem consectetur eius. Dignissimos deleniti in et nihil nobis voluptatem. Reprehenderit quis dolores voluptatem recusandae ut esse eaque est. Consequatur laboriosam rerum rerum autem. Unde velit quia temporibus. Ut est voluptatem.\n\nLabore est sed sint sequi ut. Quo quia accusamus quia veritatis et hic quisquam eos. Inventore vero ut error cum.\n\nEt praesentium dolorem asperiores maiores placeat recusandae omnis dolore non. Et numquam recusandae cupiditate velit eius deserunt qui aut. Doloremque dolorum nulla non libero et cumque inventore.\n\nUllam totam aut facilis quos ut fugit quia assumenda quam. Facere qui sit tempore voluptatibus. Nam ipsam maiores ratione vitae deleniti omnis eum. Commodi ipsa possimus debitis architecto incidunt mollitia. Perspiciatis iusto provident architecto neque. Optio molestiae cum.", null, null, "Example Page 2 - Paragraph 5", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("c81a2467-abb0-4289-8592-4d3f86944eb3"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f") },
                    { new Guid("d6252b5f-f0d2-4428-8714-929957caee97"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f") }
                });
        }
    }
}
