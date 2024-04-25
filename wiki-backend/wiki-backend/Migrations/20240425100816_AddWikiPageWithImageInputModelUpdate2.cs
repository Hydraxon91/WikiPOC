using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiPageWithImageInputModelUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
