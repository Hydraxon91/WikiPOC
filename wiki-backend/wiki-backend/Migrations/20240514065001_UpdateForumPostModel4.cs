using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumPostModel4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0c1d8192-e38f-42e4-9b3f-9359242ea91d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("326c792e-8eb6-4bca-b40c-06405787006a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("50f23462-416a-4206-83c3-ad98b325e6f2"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("558defcf-825f-4502-865f-ae3ba1db2ab1"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("7d9c1756-b5f8-4695-be84-23326cf6209a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ac8a87d0-6eac-44c6-86d2-755795ba9036"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7597dfb-328a-41c6-9e3f-011de7f1bcd3"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ddc90441-a3d5-43a0-84fc-451ba8b79db1"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0a12e83f-4915-4461-aef5-ea4d0a9af45a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0a8958b7-11a3-4245-8d62-e8bbe12cdc74"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1e8db77f-36e0-4e78-8826-c7928b787169"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("20aa0750-b505-4099-999c-827738754a84"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("27b19251-3f5f-4f02-8315-26d3d27db222"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("290faa52-0e20-4905-b4c2-8c644463d031"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("2c34b260-7ed3-4c5b-861f-180d8133b37b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("3f4dad67-cf23-488c-9038-705777765ef6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5860eeae-3390-420f-8e1a-0e21dbf994e6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("604abaf7-ea57-468e-a4f3-e6c93b94d35f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("76f7e781-a560-49e7-bfd1-7f6488885352"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8db2e0f3-4145-49c6-a982-ea39f93a52df"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8e11b0e6-24b9-4edd-b9d4-1b0130bfd0fc"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a0b87223-8b59-4982-b759-0d3ae0d8f4cb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c8064592-4805-43eb-b9ff-992cabcb696f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e810157f-1f02-4479-9334-0f0059669b9f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("37847a24-8884-48e5-b2fc-84257cc0bad6"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("8d45c457-fd89-4757-ab4b-b99e4a06902c"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("b51a8575-1673-4266-a821-e2e843b0f587"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8428d8c0-cd80-42d0-9e90-cc525c54e60b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e58ae848-bbc8-4d52-8813-c3a034bc23f7"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("fb18e73b-32ca-410b-bfc2-ef7c541d6d4d"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("57d45f9f-ff0a-4ac6-9a41-4bea7c8f0a31"));

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("010769ea-556e-404b-80c3-224d8a6b07c6"), "Sports and Recreation" },
                    { new Guid("35b9abd1-a90b-4937-954d-0f85878280eb"), "Organizations" },
                    { new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"), "Events" },
                    { new Guid("4806b03d-98ee-4165-8735-4869da345e4b"), "Science and Technology" },
                    { new Guid("485dbdb3-e99d-4b98-b6a9-9304f9e6dedf"), "Technologies" },
                    { new Guid("4ad443ff-eaeb-4a6d-88c6-40e1f068a1ec"), "Concepts" },
                    { new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"), "Stories" },
                    { new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"), "Locations" },
                    { new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"), "Characters" },
                    { new Guid("b59976ed-8541-467d-8597-197313c1e157"), "History and Culture" },
                    { new Guid("bcc1e2d6-72d7-4134-b3d2-35883fb1d231"), "Arts and Entertainment" },
                    { new Guid("f355aa0a-fdde-4fdd-9ae8-a0bfec415ae7"), "Food and Drink" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091"), new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6216), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8"), new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6264), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("3010d17b-550e-45fd-b081-1d10f60af13b"), false, new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6494), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0f6695c3-ca31-4259-b71e-735ff20dd52d"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("3010d17b-550e-45fd-b081-1d10f60af13b") },
                    { new Guid("23b34c79-d9d2-45fa-b7e3-8c9d0faf08a2"), "Explicabo in est earum in et sunt maxime. Excepturi excepturi occaecati et non est aut. Asperiores unde est ut quasi ad in iusto quidem quaerat. Voluptatem numquam quo quas. Facere corporis facilis ullam et. Quia et eum in quis incidunt expedita dolorum.\n\nEnim sit aut quasi earum molestiae. Officia error aut. Ut aperiam earum consequatur eum officiis iure suscipit est qui. Neque delectus est facilis fugit sunt at nemo quam. Aut ut consequatur iure voluptates commodi non.\n\nVoluptas itaque velit consequatur repudiandae repellendus. Sed repellat beatae. Necessitatibus assumenda pariatur ab sit fugiat minus.", null, null, "Example Page 1 - Paragraph 2", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("297cb09d-fd05-48ff-bf1a-fc5041ce191d"), "Iusto iste officiis mollitia voluptatibus voluptates dignissimos. Aut aut facere vitae dolorem libero illum beatae. Repellendus impedit aspernatur non nostrum in tenetur aut quasi. Vitae maiores aliquam.\n\nSed magni cumque tempora ut eligendi ad odio alias nihil. Natus id autem consectetur aspernatur. Qui nihil quis quis.\n\nUnde incidunt sint inventore ad exercitationem repellat ut. Nisi voluptatem dolores consequatur dolor libero. Quia aut earum nam et cumque ipsa et. Nobis qui enim natus aut dolores. Voluptatem est enim iusto sit rerum est molestias itaque quis.\n\nQuia facilis dolore adipisci qui dolor cumque tempora. Quia quia sunt soluta sint reiciendis. Reprehenderit et quisquam animi enim tenetur quis.\n\nQui eos et ut ut fugiat et. Voluptas rem aliquam quidem doloribus assumenda. Quibusdam consequatur inventore odio tempora esse. Voluptas est quaerat sunt maxime est totam et. Odit minima quia nihil culpa porro nulla laudantium sed.\n\nSit nihil harum quia debitis occaecati numquam similique quisquam. Et provident nulla occaecati voluptatem rerum asperiores esse. Laborum vero sed aut non facere laboriosam consequatur optio. Quos quia accusamus harum consequatur et dolores. Cupiditate fuga harum reiciendis aut odio et ex nulla tempore. Non sunt dolore ipsa.\n\nQui fugiat at illo. Ut possimus qui at fugit. Atque non architecto cumque. Sint veniam porro. Ea in unde natus nulla. Omnis veniam qui sunt porro ut ipsam quo magnam nemo.\n\nFacilis nesciunt aut omnis rerum facere quia. Et asperiores dolorum sed sit et omnis qui vero. Accusamus eveniet velit consequatur enim et consequatur voluptatem sunt.\n\nAccusamus rerum id. Sapiente atque velit mollitia tempora ut voluptas. Deserunt rerum et amet ipsum sint et.", null, null, "Example Page 1 - Paragraph 4", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("646d80ef-119f-46ec-91f5-da85835053c0"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("3010d17b-550e-45fd-b081-1d10f60af13b") },
                    { new Guid("73bd4cb3-140c-4ea5-8ecc-f0d1c9fa4b90"), "Eum quis atque nemo quod. Vel sit et repellendus. Earum velit rem a molestias ut voluptatem officiis dolore. Est praesentium ab ut delectus amet architecto hic voluptas est. Aliquam occaecati saepe veritatis autem laboriosam perferendis nostrum ut quam.\n\nVoluptas qui est pariatur soluta amet incidunt aut ad. Consequatur eius quia autem et. Neque aut commodi libero odio perspiciatis omnis est sed. Animi quia pariatur enim animi sint.", null, null, "Example Page 1 - Paragraph 6", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("802e90c8-2cef-4aff-8f0a-58b65587b501"), "Hic quam numquam odio labore aut quo. A iste et est officiis aut alias natus voluptas et. Ea recusandae laboriosam voluptatem iusto non ad saepe. Eius quos sunt blanditiis minima vitae fugiat sit. Facere est numquam. Facilis sed quod inventore dolor corrupti dolore est accusantium eius.\n\nNihil voluptatem autem et. Perferendis fugiat vero deserunt nostrum quo. Sunt delectus nostrum. Non deleniti culpa sequi incidunt voluptate enim. Aut enim possimus qui nulla. Necessitatibus saepe nihil est eveniet commodi nemo laboriosam voluptates voluptatum.", null, null, "Example Page 2 - Paragraph 4", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("865063f5-849b-4c5a-8f3c-d01c5d268ce3"), "Aut reiciendis est earum maiores totam. Odio sint doloribus autem et autem dolorem aut quos. Eaque tempore voluptatem fugiat maiores in explicabo dolorum.\n\nPlaceat autem omnis libero eligendi cum sequi eligendi doloribus ullam. Repudiandae ab veniam. Dolore illum tempore rerum cum aliquam voluptates animi omnis. Cupiditate veritatis quia adipisci quisquam nemo incidunt tempora ab.\n\nConsequatur eligendi blanditiis. Consectetur id quaerat qui omnis quo rerum quos molestiae id. Doloribus nostrum id voluptas voluptates non modi fuga.\n\nPorro consequatur illum tempora deleniti dolores voluptate officiis. Veniam quaerat expedita aut natus eum suscipit. Quisquam quis id soluta. Omnis velit esse quo quia quae earum eius suscipit nam.\n\nIure illo beatae nihil possimus illo. Reiciendis voluptas animi aut. Consequatur doloribus amet pariatur voluptatem necessitatibus ut nisi. Eaque dolores aliquid excepturi.\n\nNobis non accusantium voluptas voluptatem rerum ea provident quia minima. Nesciunt iure voluptas sed qui. Deserunt omnis id vel fugit veniam accusamus ex atque voluptatem.\n\nEst tenetur asperiores quibusdam molestias. Inventore occaecati excepturi possimus. Illo magnam quia.\n\nSuscipit voluptatibus cum. Autem veritatis dolor reprehenderit amet eligendi quia ea eum provident. Et consequuntur dolorem.", null, null, "Example Page 1 - Paragraph 3", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("8ab6fc0a-1285-43dd-b207-84b0c96eaf56"), "Quae ut quod. Quam asperiores et et maiores temporibus enim dicta expedita. Quis consequatur ad. Unde rerum dolorem error animi et ea dolorum. Earum accusamus et ex et. Ea corrupti est nisi ullam ea illum temporibus.\n\nVelit nesciunt eos molestiae voluptatem sint ab soluta voluptate. Cumque rerum explicabo vel. In molestias ut beatae recusandae nisi ex saepe. Ipsam animi non architecto facere. Inventore aperiam nihil.\n\nId laboriosam ut occaecati doloremque omnis quibusdam facilis. Sit veniam earum at occaecati cum. Culpa molestiae voluptas. Delectus mollitia pariatur corporis ut rerum earum aliquam. Explicabo facere sit et quos. Rerum architecto modi quas molestiae harum quia aut itaque.\n\nEt accusantium illum mollitia est et perferendis doloribus vel. Sit ut fugiat vel animi ipsam voluptas aut. Quibusdam labore temporibus.\n\nSunt et quia ipsum est inventore non molestiae reiciendis nisi. Inventore porro beatae repellat illo qui temporibus eligendi. Voluptas aliquam ea dolore odio id consequatur vel tenetur.\n\nLaudantium sit fugit similique fugit nihil eius ea itaque. Exercitationem sunt rerum repellat officia est vero asperiores. Ratione nihil error incidunt et minima ratione ut adipisci est.\n\nEius et ut ut. Ullam et et itaque consectetur. Id at sed. Vero labore at soluta.\n\nAliquam natus commodi minus et repudiandae. Minima amet officiis et expedita quia quis quia eos. Ut et aliquam sit et quidem perferendis quam dolore quo.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("8d960016-a7e8-4d33-a76f-2a9a9d0efcf9"), "Explicabo temporibus facere qui numquam consectetur error. In consectetur aut. Rem et reprehenderit corporis voluptas repudiandae assumenda optio reiciendis. Eius ea atque ut corrupti. Consectetur aliquid veritatis vero beatae quia voluptatem aliquid iure.\n\nAut autem aliquid ad velit corporis possimus repudiandae. Labore repudiandae rerum ab perferendis consequatur possimus est. Et libero non quo nesciunt dolorem rerum accusantium. Necessitatibus autem alias doloribus dignissimos magnam ut. Explicabo aut quia ratione omnis. Inventore ullam ut dicta distinctio temporibus itaque.", null, null, "Example Page 1 - Paragraph 5", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") },
                    { new Guid("a055dceb-15cc-416b-8ea5-772755b6543a"), "Voluptas dignissimos quam deserunt maiores dignissimos explicabo cupiditate rem voluptatibus. Porro ipsam ea culpa. Placeat id eum omnis velit fuga voluptatem et maxime. Impedit quaerat quod quos et qui sed.\n\nMinima quia corrupti odio officiis. Nisi saepe qui. Laudantium reprehenderit rerum qui porro consectetur. Ipsa distinctio perferendis optio repellendus libero. Voluptatem nemo accusantium voluptatum ut.\n\nEt dolorum voluptates et cumque. Est ut ipsam itaque sit et officia occaecati. Fugiat consequatur alias placeat laboriosam ut quia corrupti sunt id. Ipsam et consectetur maxime veritatis voluptatem repellendus ut.\n\nEst at sit iste maxime deserunt facere voluptatem. Iste quia minima temporibus perspiciatis voluptatibus voluptatum doloremque. Architecto omnis nostrum voluptatibus. Voluptas eius voluptates est quia quis nemo.\n\nDucimus nemo voluptatem. Provident blanditiis maxime. Ut repellat ratione voluptatem occaecati. Delectus qui dolor aut tempora ex veniam et dolores sunt.\n\nQuo fugit molestiae repudiandae consequatur veritatis qui harum. Commodi voluptatibus saepe ipsa nemo placeat soluta itaque laboriosam. Ratione ad expedita omnis. Atque aspernatur et voluptatem sequi asperiores veniam.\n\nPariatur quam culpa eos et. Enim rem earum inventore et quaerat consequatur et. Odio omnis esse rem. Cumque voluptas qui est quo. Id harum exercitationem rem accusamus dolorem quam deleniti in. Commodi aliquam soluta ducimus repellendus at iure iure odio.", null, null, "Example Page 2 - Paragraph 6", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("c30d6625-7089-4ccd-9003-5f42189b3910"), "Ipsum iure optio accusamus quam. Quo cumque delectus facilis voluptatem aut perspiciatis. Eligendi assumenda ut et. Dolores qui molestiae.\n\nCum aut rerum et. Perspiciatis veritatis et. Cum qui odit delectus est ad quibusdam cumque quia aliquid. Recusandae hic dolorem ut minima praesentium a nostrum assumenda dolor. Blanditiis quidem exercitationem non similique repudiandae quia. Voluptas voluptas quis voluptatem.\n\nHarum aut id facere excepturi quia et et. Rerum id eligendi totam nemo temporibus eum quia. Et rem odit. Delectus sint reiciendis. Nihil reprehenderit sed ad sed eius consequatur amet mollitia rerum. Sunt maiores ipsam maxime ad occaecati quas.\n\nNon accusamus soluta ut quia harum a ut voluptates. Aut aut non reiciendis. Tempore voluptatum qui natus eos minus nobis laborum.\n\nDolorem porro illum quibusdam. Temporibus accusantium non laudantium. Est vel numquam distinctio tenetur accusamus consequatur. Autem voluptatem aperiam.\n\nAut corrupti magni iure eos nisi voluptatem nisi sint. Culpa laudantium molestiae nostrum error deserunt nam dolor qui inventore. Placeat porro et aut. Consectetur ipsa aperiam. Rerum dolores neque omnis iusto consequuntur quos.\n\nA consectetur delectus aut qui. Sed ut sed in quidem. Ea explicabo earum. Laboriosam sit veniam voluptates exercitationem ipsum dicta quia quia fugiat. Aperiam provident veritatis doloribus.", null, null, "Example Page 2 - Paragraph 2", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("e09e6c36-f0ed-4c9b-8e33-9a21c0e405a5"), "Unde veritatis saepe voluptate non libero accusantium. Possimus libero repellat sed autem et. Autem inventore quisquam.\n\nEa esse et placeat. Nam velit et praesentium. Nam voluptas veniam quisquam.\n\nCumque ea repellat qui voluptas illum. Labore ut aut atque vitae. Quaerat nobis accusamus atque.\n\nLabore non ipsa aut nihil dolorem molestiae aliquid. Aut mollitia repellendus unde voluptas voluptas voluptas modi. Aliquid est id ut porro qui error occaecati. Necessitatibus nobis rerum similique libero laborum aspernatur ipsam ex. Quia est voluptatem quo error molestiae. Tempora libero voluptatibus.\n\nItaque sit distinctio aut quia voluptatum magnam laboriosam illo. Culpa distinctio consequatur. Iusto alias consequatur. Fugiat nisi velit nihil. Est non dolor maiores qui adipisci et.\n\nCulpa explicabo consequatur voluptatem quo harum necessitatibus odio. Est voluptatem omnis nulla libero quis voluptate. Et voluptate culpa assumenda asperiores molestias a non. Rerum numquam velit adipisci enim animi molestias.\n\nAsperiores impedit in tenetur sequi earum. Eos doloremque et est molestias veniam delectus id dolores soluta. Incidunt magnam error reprehenderit aliquam esse totam a eius odit. Et non aperiam et aut consectetur. Recusandae et rem earum est modi. Nesciunt at facilis beatae aliquid.\n\nQuaerat occaecati sequi rerum consequatur. Eaque quod non sed nemo odio eos eos autem. Voluptates repellat error culpa consequatur. Rerum et aut sequi laudantium sed minima quia temporibus quis.\n\nNisi id alias qui. Et odit cum porro eligendi pariatur deserunt ratione minima. Nisi fugit reprehenderit. Ab deleniti ea. Odit a corrupti sed voluptas aut.", null, null, "Example Page 2 - Paragraph 3", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("e8bcbc63-d15a-4017-842a-8c105cbaa344"), "Tempore quia autem voluptatibus exercitationem architecto nulla. Enim reiciendis dolorum. Cumque sunt dolores molestiae molestiae. Maxime nesciunt et animi nihil totam omnis est delectus.\n\nSaepe aut quia fugiat. Molestiae illum autem quas eos exercitationem rem dolores. Ut maxime enim maiores exercitationem distinctio eaque porro occaecati sit. In et doloremque quia. Non nostrum culpa illo aperiam facere unde ipsum. Nobis non explicabo quia et aut ducimus perferendis.\n\nHarum consectetur necessitatibus. Error rerum hic voluptates harum harum inventore. Aperiam sapiente excepturi doloremque placeat voluptatibus quos.\n\nQui laboriosam consequatur explicabo ut id voluptas. Consequatur voluptatibus odio in quia. Non dolor quaerat facere tempora atque officiis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") },
                    { new Guid("f14363a4-fb3f-40a6-9013-24b01665b994"), "Quo dolorum architecto nihil dolorem est ducimus maiores voluptatem. Quos laboriosam molestiae consequatur magnam. Vitae atque molestiae sed aspernatur similique porro enim.\n\nVoluptatem voluptates nostrum aspernatur id ut perspiciatis. Dolorem quia numquam sapiente. Non reiciendis ea vel eum dolorum possimus autem. Nesciunt voluptatem iste sed sit sunt est ex.\n\nVel delectus id voluptatem fuga. Quia vitae cumque maxime praesentium sunt sint consequuntur sit officiis. Laudantium ullam perferendis repellendus sint similique odio.\n\nAutem est repellat quibusdam dolore sed. Ducimus unde quis assumenda nihil. Vero et rem voluptatem neque molestiae sed.", null, null, "Example Page 2 - Paragraph 5", new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585"), false, new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 8, 50, 1, 429, DateTimeKind.Local).AddTicks(6500), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("6b66515a-c3d3-4f1d-b663-13cf3831e1d3"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585") },
                    { new Guid("9c4523dc-78bb-47b9-8ab8-9ddcb7f34ff6"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("010769ea-556e-404b-80c3-224d8a6b07c6"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35b9abd1-a90b-4937-954d-0f85878280eb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4806b03d-98ee-4165-8735-4869da345e4b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("485dbdb3-e99d-4b98-b6a9-9304f9e6dedf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4ad443ff-eaeb-4a6d-88c6-40e1f068a1ec"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b59976ed-8541-467d-8597-197313c1e157"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("bcc1e2d6-72d7-4134-b3d2-35883fb1d231"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("f355aa0a-fdde-4fdd-9ae8-a0bfec415ae7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0f6695c3-ca31-4259-b71e-735ff20dd52d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("23b34c79-d9d2-45fa-b7e3-8c9d0faf08a2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("297cb09d-fd05-48ff-bf1a-fc5041ce191d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("646d80ef-119f-46ec-91f5-da85835053c0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6b66515a-c3d3-4f1d-b663-13cf3831e1d3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("73bd4cb3-140c-4ea5-8ecc-f0d1c9fa4b90"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("802e90c8-2cef-4aff-8f0a-58b65587b501"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("865063f5-849b-4c5a-8f3c-d01c5d268ce3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ab6fc0a-1285-43dd-b207-84b0c96eaf56"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8d960016-a7e8-4d33-a76f-2a9a9d0efcf9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9c4523dc-78bb-47b9-8ab8-9ddcb7f34ff6"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a055dceb-15cc-416b-8ea5-772755b6543a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c30d6625-7089-4ccd-9003-5f42189b3910"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e09e6c36-f0ed-4c9b-8e33-9a21c0e405a5"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e8bcbc63-d15a-4017-842a-8c105cbaa344"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("f14363a4-fb3f-40a6-9013-24b01665b994"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("1ef3842c-a0f6-4ae3-a0eb-0f5b26a0ccf8"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("3010d17b-550e-45fd-b081-1d10f60af13b"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("e95f7d37-f9b0-4d6a-a0f5-bd3ee7d58585"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("35ed3c23-f25a-42b5-9222-de70eeeb98fd"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("4fd67d4c-0a6e-4b21-838a-568a545d9057"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("522ff39f-edf2-4661-bb15-2b1b45e693b2"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0e39cf89-3702-4ed9-a8f1-20a468a6a091"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("63efb064-1b9e-4158-bd89-63dc2b443192"));

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "ForumPosts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("0c1d8192-e38f-42e4-9b3f-9359242ea91d"), "Organizations" },
                    { new Guid("326c792e-8eb6-4bca-b40c-06405787006a"), "Arts and Entertainment" },
                    { new Guid("50f23462-416a-4206-83c3-ad98b325e6f2"), "Sports and Recreation" },
                    { new Guid("558defcf-825f-4502-865f-ae3ba1db2ab1"), "Food and Drink" },
                    { new Guid("57d45f9f-ff0a-4ac6-9a41-4bea7c8f0a31"), "Characters" },
                    { new Guid("7d9c1756-b5f8-4695-be84-23326cf6209a"), "Technologies" },
                    { new Guid("8428d8c0-cd80-42d0-9e90-cc525c54e60b"), "Events" },
                    { new Guid("ac8a87d0-6eac-44c6-86d2-755795ba9036"), "History and Culture" },
                    { new Guid("c7597dfb-328a-41c6-9e3f-011de7f1bcd3"), "Science and Technology" },
                    { new Guid("ddc90441-a3d5-43a0-84fc-451ba8b79db1"), "Concepts" },
                    { new Guid("e58ae848-bbc8-4d52-8813-c3a034bc23f7"), "Locations" },
                    { new Guid("fb18e73b-32ca-410b-bfc2-ef7c541d6d4d"), "Stories" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("8d45c457-fd89-4757-ab4b-b99e4a06902c"), false, new Guid("e58ae848-bbc8-4d52-8813-c3a034bc23f7"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 7, 59, 11, 759, DateTimeKind.Local).AddTicks(6908), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("b51a8575-1673-4266-a821-e2e843b0f587"), new Guid("fb18e73b-32ca-410b-bfc2-ef7c541d6d4d"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 59, 11, 759, DateTimeKind.Local).AddTicks(6740), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc"), new Guid("57d45f9f-ff0a-4ac6-9a41-4bea7c8f0a31"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 59, 11, 759, DateTimeKind.Local).AddTicks(6697), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0a12e83f-4915-4461-aef5-ea4d0a9af45a"), "Eligendi provident consequatur consectetur ex ab assumenda asperiores enim. Dolores aliquid fugiat et. Aut ullam at aut. Enim itaque optio inventore soluta alias est aut. Error ea et omnis laborum unde sit quisquam et. Culpa enim accusamus qui illum temporibus.\n\nEligendi facere dolores dolorem. Deleniti ut voluptates repellendus est omnis. Vel deserunt nobis molestiae vero. Molestias voluptate voluptas quae voluptas. Voluptates ut aperiam exercitationem non dolor harum. Necessitatibus et hic ad temporibus dolor est neque odit voluptatem.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("0a8958b7-11a3-4245-8d62-e8bbe12cdc74"), "Quia nisi et. Voluptatem pariatur eum accusamus qui sint et molestias. Itaque veritatis officia quae eum totam. Id provident exercitationem et ipsam aperiam facere molestiae eius. Sequi optio esse est illo culpa nisi.\n\nSapiente commodi laudantium cumque officia aut. Et odit facere magnam sed voluptate mollitia velit non veniam. Fugiat velit maxime pariatur quasi ex in sequi. Voluptas et et quod quis ratione sint nemo tenetur sint. Distinctio sed debitis veniam quia voluptas et minima sit.", null, null, "Example Page 2 - Paragraph 5", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("1e8db77f-36e0-4e78-8826-c7928b787169"), "Quam voluptatem ea. Esse ex et soluta quibusdam dolorem. Delectus voluptates dicta. Consequatur eveniet repellendus voluptatem amet maiores quia et aut fugit. Nam nemo voluptatum.\n\nCupiditate dolore id voluptas. Consequatur nesciunt voluptas voluptas nobis sunt enim officia. Sapiente voluptatum odit alias iure est. Reiciendis eum ea ea exercitationem exercitationem quo aut est. Quia nostrum cupiditate ex omnis neque ullam quia.\n\nAnimi est magni velit numquam deserunt consequatur repellendus officia dicta. Odit accusantium itaque aut id. Qui id optio labore vero repellat unde amet similique.\n\nVoluptatum quis iusto quasi beatae quia eum aut ut possimus. Doloremque rem magnam vel aut officiis eos nobis. Corrupti sunt eveniet inventore et suscipit voluptatem eaque. Quam qui officiis reprehenderit autem magnam voluptas aliquam.\n\nTemporibus vero quis minus reprehenderit. Consequatur rem aut ea molestias. Nihil doloremque exercitationem pariatur voluptas eligendi qui nulla. Illo veritatis ut delectus doloribus minima.\n\nDolorum a nulla ratione est sed eligendi ullam. Doloremque recusandae non repellendus maxime deleniti ad. Aut tempora eius omnis qui in aut officia nostrum ad.\n\nAccusamus deserunt ut voluptate aut sit id iusto. Ut qui aliquam odit ea expedita fuga sint. Cum incidunt at explicabo eum ipsa rerum facere perspiciatis.\n\nVoluptas et provident hic praesentium. Autem aliquam enim optio exercitationem non sequi quibusdam. Nihil fugit sint aperiam id rerum deleniti ipsum est asperiores. Esse nemo voluptatem dolores explicabo modi facilis consequatur excepturi sapiente. Cumque expedita totam neque consequatur illo sed.\n\nAdipisci sit optio suscipit molestias. Qui ut saepe qui. Expedita veniam quae cumque reprehenderit. Delectus quasi laudantium aut soluta dolor quibusdam deleniti quo consequatur.", null, null, "Example Page 1 - Paragraph 4", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("20aa0750-b505-4099-999c-827738754a84"), "Sunt asperiores corrupti voluptate officiis quis. Magnam tenetur expedita doloribus deserunt. Sit deleniti pariatur rerum eos ut. Soluta accusantium sed. Quod expedita ea impedit repellendus explicabo officiis atque sapiente.\n\nAmet eligendi sint reiciendis aspernatur ipsam. Ipsum vitae iusto vel ducimus dicta reiciendis modi dolor. Repudiandae consequatur sit blanditiis sint labore natus corporis qui. Nobis nobis amet nihil quia vel excepturi harum. Et qui dolorem. Occaecati est ea ipsa nesciunt nostrum quaerat sequi quia.\n\nConsequatur voluptates rem aperiam et. Amet explicabo provident. Non sunt aliquid rerum exercitationem ut. Error corporis incidunt sit a quis omnis. Et veritatis illum quam nam velit ut iste et. Ratione occaecati aut fuga id sed rerum consequuntur est maiores.\n\nVoluptates voluptas ut illum. Dolores distinctio beatae in. Eveniet facere molestiae similique numquam voluptatum magnam.\n\nError id voluptatem officia dolores delectus. Sit eum veniam et eum sit veniam. Rerum molestiae ut. Quas animi totam qui aut. Nesciunt doloremque saepe sint nam commodi qui blanditiis. Dolorem fugiat sit sequi eaque veritatis ex consectetur repudiandae.\n\nPlaceat rerum ullam beatae aut. Omnis commodi eveniet omnis odio culpa qui et aut quod. Aliquam velit exercitationem iusto accusamus excepturi autem. Tempora deserunt odit numquam. Est qui sit accusantium pariatur.\n\nPossimus ad autem sapiente dolor veniam voluptatum eum ut. Quod corrupti asperiores eveniet rem et veniam natus omnis. Earum nihil quas sed dolor dignissimos. Est tempore voluptas. Repellat doloremque cumque aut iusto consequatur aliquid reprehenderit quia.\n\nUt est vero eligendi ducimus accusamus praesentium. Aut voluptate molestiae est odio explicabo nam laudantium non maxime. Sit rerum quas voluptatem voluptas amet tempora. Deleniti at explicabo dicta. Fuga dolorem sunt quae est placeat eligendi eum. Enim non et est saepe debitis voluptatem rerum.\n\nCorporis et minima quo ipsam at molestiae asperiores quia nihil. Quaerat corrupti sunt dignissimos magnam ipsam et repudiandae nobis. Soluta occaecati eius. Modi dolorum consequatur et. Omnis aspernatur non ut vitae eveniet tempora cum dicta ut. Perferendis quibusdam exercitationem quo consequuntur.", null, null, "Example Page 1 - Paragraph 2", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("27b19251-3f5f-4f02-8315-26d3d27db222"), "Voluptatem et id dolorem non voluptatem. In architecto ut error. Possimus rem ab soluta. Dignissimos ea esse id.\n\nHic tenetur veniam consequuntur tempora qui ipsum. Sint consequatur atque velit nemo sunt nisi quia nesciunt. Ea fuga rerum sed voluptatem sint aliquid iure. Delectus eum suscipit omnis reprehenderit labore consequuntur reiciendis facere qui.\n\nVoluptatum quibusdam animi. Et tempora ut minus dolorum. Minus et asperiores ut blanditiis minima.\n\nDolores atque illum. Ut mollitia sit non libero fugit consectetur velit consectetur ut. Ducimus dolor omnis omnis architecto vitae fuga quia cupiditate. Omnis illo ab impedit odio quia quod autem tempore.\n\nVoluptatem rerum dolores aperiam ut reiciendis rem ut. Inventore tempore maxime laboriosam qui quam. Perspiciatis placeat quas nam nesciunt sit aut similique magni. Qui enim et velit facilis aut sit dolorem inventore magni.", null, null, "Example Page 2 - Paragraph 2", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("290faa52-0e20-4905-b4c2-8c644463d031"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("8d45c457-fd89-4757-ab4b-b99e4a06902c") },
                    { new Guid("2c34b260-7ed3-4c5b-861f-180d8133b37b"), "Labore reprehenderit aut est. Laborum non ut accusantium et. Perspiciatis est error qui est aspernatur sint facilis illum aspernatur. Qui enim in.\n\nCupiditate enim incidunt aut. Quia aperiam enim quia qui ut. Sunt dolores quod illo. Rerum magnam quas voluptatibus dolorem dolores. Ea ut aliquid cum quis ducimus voluptas. Accusamus fuga facere qui aperiam dolore.\n\nTenetur fugit aliquid error voluptate. Recusandae in cum earum suscipit odio rerum saepe quis porro. Quisquam facilis aut maiores ducimus expedita quas. Nam placeat dolorem earum omnis qui vero. Eos inventore voluptatem est aut ex doloremque vitae eveniet qui. Saepe suscipit et rerum sed.\n\nItaque eius consectetur ducimus ut velit fugit quibusdam. Aut veritatis voluptates dolores nihil esse. Quibusdam sed a voluptates dolores voluptatem. Distinctio dolorum soluta sint id. Odit ad ratione autem ducimus culpa. Sit quidem cumque quia.", null, null, "Example Page 1 - Paragraph 3", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("3f4dad67-cf23-488c-9038-705777765ef6"), "Quod animi temporibus veniam consequatur omnis explicabo. Amet consectetur sed. Unde dolor neque quisquam deserunt voluptatem maiores. Voluptatibus fuga doloribus earum omnis sapiente. Voluptates sit fuga fugit. Et qui et et sequi.\n\nCorrupti mollitia est eligendi et deserunt est. Est nostrum qui placeat. Omnis velit ad soluta. Dolorem nam molestias autem deserunt id eum perspiciatis iure. Culpa a temporibus ad sed illo ut quia. Commodi voluptas omnis minus neque similique rem culpa architecto.\n\nDistinctio maxime laborum optio saepe tempora rerum sint eum facere. Repudiandae magnam laudantium fugit. Porro soluta et velit cum. Commodi temporibus quia vel animi et reprehenderit rerum unde iusto.\n\nMinima ipsum ducimus molestias quia accusantium temporibus quaerat. Et laudantium enim eos deserunt ea sed. Quia praesentium sint quos unde voluptas eos ducimus ad. Quia maiores magni est quaerat neque assumenda. Molestiae minus omnis rem eos beatae. Consequuntur repellendus sit unde qui earum.\n\nQui eos quis vel nostrum laboriosam. Voluptatem qui perspiciatis dolores. Fugit non tenetur sit.\n\nUnde qui quo rerum ut. Voluptates soluta enim enim eveniet hic nemo optio facilis eos. Quas mollitia reiciendis asperiores harum nisi sed alias non. Voluptatem qui sit illum ut natus accusantium enim dolor. Natus vel perspiciatis doloribus.\n\nQuaerat soluta qui nam nostrum cum aut quo. Soluta provident voluptatem illo nihil eum architecto laborum. Voluptas maiores dolor illo velit sunt et ullam.", null, null, "Example Page 2 - Paragraph 6", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("76f7e781-a560-49e7-bfd1-7f6488885352"), "Nobis molestiae voluptas est porro. Eius at officiis non atque est illum dolorem. Quisquam dicta et ut. Modi quia ipsa. Veritatis qui minus et quasi nulla.\n\nSuscipit pariatur aperiam consequatur alias commodi modi praesentium sint sed. Corporis repudiandae suscipit qui aut quibusdam ullam sunt sequi. At et et corrupti ut nulla nisi iusto et. Ab excepturi quam exercitationem. Repellat dolorem velit nostrum placeat beatae voluptas eos.\n\nIllo veritatis eveniet sed ducimus assumenda distinctio laudantium enim. Dolorem atque repudiandae deserunt dolores accusantium ut iure quam numquam. Autem eos ut doloremque inventore qui aut minima aspernatur.\n\nImpedit natus et. Deleniti non deserunt est. Inventore ut quae. Tempora in dolor dolorem corporis.\n\nQui eum quibusdam vero natus consequatur. Mollitia sit nihil consequatur ducimus temporibus rerum excepturi consequatur id. Numquam praesentium est.", null, null, "Example Page 1 - Paragraph 6", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("8db2e0f3-4145-49c6-a982-ea39f93a52df"), "Iusto minima iste temporibus. Ipsa quae et. Eum nihil molestias. Voluptatibus debitis minus eveniet quidem voluptatem vel pariatur praesentium iure. Omnis qui qui ea voluptatem qui quibusdam assumenda maiores. Qui cupiditate corporis voluptas cupiditate quasi vero.", null, null, "Example Page 2 - Paragraph 4", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("8e11b0e6-24b9-4edd-b9d4-1b0130bfd0fc"), "Omnis asperiores adipisci. Amet doloribus impedit autem molestiae omnis. Est ut et quas vel deserunt delectus voluptates id aut. Et sit impedit error voluptatem voluptates et alias occaecati. Dolorem iste non quibusdam perspiciatis pariatur.\n\nDolorem ut quaerat nesciunt illum quo. Odio ut sunt. Repellat rem at distinctio. Laboriosam est aliquam ut sint occaecati nam ratione quis. Illum rem temporibus sunt veniam laborum quibusdam officia corrupti.\n\nFacere a cumque. Eligendi velit qui dolores. Saepe sit inventore et ut eos optio et. Molestiae et fugiat porro autem. Dolorem modi voluptas possimus ad. Quam tenetur eum.", null, null, "Example Page 1 - Paragraph 5", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") },
                    { new Guid("a0b87223-8b59-4982-b759-0d3ae0d8f4cb"), "Voluptatem perspiciatis molestiae voluptate et necessitatibus. Maxime qui eius ut et. Corrupti et cum ullam eum veniam necessitatibus cum.\n\nEveniet delectus vel rerum nostrum odit asperiores. Est architecto aut ipsa odit iste amet vel. Autem velit provident non libero et voluptatibus magnam repellendus explicabo. Fuga sequi totam veritatis magnam eveniet nobis eveniet quo aperiam. Consequatur eligendi cumque rerum est facilis et deserunt tempora qui. Et eos deserunt veniam nobis officiis.\n\nConsectetur est et. Reprehenderit eos et modi. Iure atque voluptatem aut iste ea. Voluptas provident cum esse quia est dignissimos numquam reiciendis et. Repudiandae voluptatem cumque culpa a iste temporibus tenetur illum exercitationem.\n\nCommodi praesentium facere voluptatem impedit omnis esse aut dolorem. Soluta id provident omnis autem illum voluptatem quis. Vitae deserunt enim facilis nesciunt iusto nihil quis repellendus.\n\nError quo at saepe eum beatae consectetur. Aliquam et possimus. Impedit enim impedit voluptatibus modi minus voluptatem velit dolorem.\n\nVoluptatem deserunt voluptates aut exercitationem sequi inventore et ab aut. Dolores voluptas nulla est dignissimos recusandae quae optio. Aliquam ipsum corporis aut dolores. Magnam rem at libero esse quibusdam repudiandae enim. Error iste non explicabo aut natus laborum. Praesentium amet earum corporis nam iusto aut.", null, null, "Example Page 2 - Paragraph 3", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("c8064592-4805-43eb-b9ff-992cabcb696f"), "Ea unde commodi voluptatem reprehenderit animi voluptas quibusdam alias. Voluptatem magni sed velit. Voluptatem sint qui nostrum odio ex debitis. Provident laborum mollitia aliquam delectus illum maxime cupiditate laboriosam. Nulla qui id veritatis et et quia rerum vero.\n\nAtque ipsa voluptatem quae maiores quo. Vel omnis perferendis architecto blanditiis omnis consectetur. Tenetur sed enim non. Iste est occaecati natus assumenda facere. Sed ab iure temporibus occaecati est.\n\nOfficiis sed quibusdam deleniti perferendis quam debitis sed error. Amet reiciendis voluptatem facere quos tenetur similique. Quo odit qui facilis ea. Maiores nisi numquam magni deserunt ut dolorum accusantium. Cupiditate rem blanditiis illum. Ea dolor cumque ut voluptas.\n\nOptio sint provident et alias facere aut. Non incidunt labore. Deleniti voluptatem tenetur ut nihil eos.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("b51a8575-1673-4266-a821-e2e843b0f587") },
                    { new Guid("e810157f-1f02-4479-9334-0f0059669b9f"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("8d45c457-fd89-4757-ab4b-b99e4a06902c") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("37847a24-8884-48e5-b2fc-84257cc0bad6"), false, new Guid("8428d8c0-cd80-42d0-9e90-cc525c54e60b"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 7, 59, 11, 759, DateTimeKind.Local).AddTicks(6913), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("bbf5e390-d1a9-4379-8696-52bb48e0abfc") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("5860eeae-3390-420f-8e1a-0e21dbf994e6"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("37847a24-8884-48e5-b2fc-84257cc0bad6") },
                    { new Guid("604abaf7-ea57-468e-a4f3-e6c93b94d35f"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("37847a24-8884-48e5-b2fc-84257cc0bad6") }
                });
        }
    }
}
