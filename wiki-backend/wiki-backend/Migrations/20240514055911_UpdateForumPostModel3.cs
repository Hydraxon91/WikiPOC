using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateForumPostModel3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("095f39f2-c260-4636-92b8-ee52825054a8"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0b711e6c-dfc7-499a-9337-b691b59a6304"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("104a8c3c-1de1-45d3-9046-314d359a69ba"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("112ca28d-ab27-423a-b9b9-eb8b29f7441f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("5cf70538-8516-4bd6-88ba-003786293ecf"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("6f5741e9-6b6f-4e86-96fa-8666a96b1513"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9c03ae43-36c3-447f-851d-28183910429b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b741c637-e822-4457-9560-dc8740c10af3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0e03a79f-1d19-4690-b808-4375df2a6487"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1ee0275f-783b-4f30-a392-9587d0fb4f4c"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5455545c-5560-4bd0-a17c-df90fd631e4f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("5d3bc25e-7b73-499b-b0e8-4535879e3973"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("642a5509-4d6f-472b-b449-6239850fa718"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("69817e7b-db78-4f18-86a5-26bb6c7d3bdf"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6982ef85-c11e-4e3f-b8e3-53a49c0bb266"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("92c80242-b379-426d-b0c1-00ba71826803"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("9d0aef9a-e1f2-4197-a06a-a6b23d85fccd"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a30a1f07-98d6-4709-8ff4-5c92657aaafb"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b3cf4572-0105-4700-bdf1-489d935fc3d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c5905114-ba5b-4a91-be54-e5dbbfcd8438"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c5e70262-4b09-46bf-b2b3-3dba5d6d0ef0"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c8c5ad13-44cc-4125-8541-0191168384f8"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d580eec7-26e3-48ca-bdef-5141cf4766e4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ff93d442-a4f7-408b-836a-f32aac08c8f3"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("503b4921-68af-404d-bc41-9cd87c24892a"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("01eb0061-015e-439f-bf89-18f51527afeb"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"));

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "ForumPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "ForumPosts");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[,]
                {
                    { new Guid("01eb0061-015e-439f-bf89-18f51527afeb"), "Locations" },
                    { new Guid("095f39f2-c260-4636-92b8-ee52825054a8"), "Technologies" },
                    { new Guid("0b711e6c-dfc7-499a-9337-b691b59a6304"), "Sports and Recreation" },
                    { new Guid("104a8c3c-1de1-45d3-9046-314d359a69ba"), "Food and Drink" },
                    { new Guid("112ca28d-ab27-423a-b9b9-eb8b29f7441f"), "History and Culture" },
                    { new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"), "Characters" },
                    { new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"), "Stories" },
                    { new Guid("5cf70538-8516-4bd6-88ba-003786293ecf"), "Organizations" },
                    { new Guid("6f5741e9-6b6f-4e86-96fa-8666a96b1513"), "Science and Technology" },
                    { new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"), "Events" },
                    { new Guid("9c03ae43-36c3-447f-851d-28183910429b"), "Concepts" },
                    { new Guid("b741c637-e822-4457-9560-dc8740c10af3"), "Arts and Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "CategoryId", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("503b4921-68af-404d-bc41-9cd87c24892a"), new Guid("45bc8c15-c4bc-43e7-b357-5c5a0a9999ac"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9800), "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655"), new Guid("38b14cea-13cd-4689-8f59-3e3acd42b7e5"), null, "WikiPage", null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9757), "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0"), false, new Guid("01eb0061-015e-439f-bf89-18f51527afeb"), null, "UserSubmittedWikiPage", true, null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9933), "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0e03a79f-1d19-4690-b808-4375df2a6487"), "Ducimus facilis itaque rerum. Sed omnis laboriosam. Sapiente necessitatibus quis odio harum dolores maiores sapiente. Numquam aut aut vel voluptatem nobis. Est a necessitatibus harum at consectetur dicta incidunt excepturi.\n\nSed et sit molestiae quia inventore veniam. Dolor illo quaerat sunt quia repellendus. Nesciunt ducimus perspiciatis. Corporis impedit rerum dolores pariatur ratione exercitationem iste qui deleniti.\n\nEt pariatur tenetur deleniti. Sed quidem nam voluptates est id dignissimos. Voluptatibus ipsam nulla ratione veniam sequi dignissimos ut a dolores. Voluptatem aut fugiat dolores vel delectus modi fugiat quos.\n\nEt omnis consectetur sint dolores necessitatibus. Reprehenderit quidem rerum enim nisi. Laudantium dolorem rem ut. Aperiam in deserunt maiores error et facere vitae. Est maiores facilis et quae autem inventore atque.\n\nEnim nobis sit eius. Rerum necessitatibus qui aut non omnis esse aut. Error consequatur voluptatem magnam quia. Accusamus consequuntur odit voluptatem et. Iusto voluptas et sit consequuntur aliquam voluptatem.\n\nConsectetur libero in ut. Repellat enim autem rerum assumenda. Est omnis est quasi iste ipsam esse. Ab odit ex nostrum aliquid. Delectus dolorem reiciendis rerum ut.\n\nSit eos suscipit vel eum voluptatibus. Non vero itaque non animi. Numquam facilis enim non et aut quo. Totam accusamus hic enim enim quis velit sunt. Impedit quod impedit quasi eos eos.\n\nEt et vitae sequi ut repudiandae. Quis odio adipisci. Repellendus ut impedit voluptas veritatis aut consequatur porro cupiditate. Laborum perferendis culpa. Eos id et dolorum sunt aut repellat veritatis.\n\nUt repellendus voluptatum culpa. Et corporis quo in praesentium. Sequi et saepe magni error eos. Suscipit officia libero numquam expedita ut modi. Quia nobis sed.\n\nFacere quis expedita nemo et iure recusandae similique quia. Et voluptatem distinctio dolores sunt eligendi est quis quas error. Aut velit dolorem quam. Voluptatibus possimus aut magni et ipsa nihil. Quis beatae est nihil illum debitis ducimus rem numquam.", null, null, "Example Page 2 - Paragraph 4", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("1ee0275f-783b-4f30-a392-9587d0fb4f4c"), "Neque qui et quia quibusdam adipisci nulla. Est nam illo libero ipsam nostrum ea in aut libero. Quam error est deserunt perferendis vel aut exercitationem totam.\n\nAmet commodi itaque accusamus voluptas. Magni ea ratione dolor. Illo sapiente consequatur velit. Vitae esse placeat in excepturi quidem voluptate.\n\nUt saepe sed omnis voluptatum. Reiciendis consequatur reiciendis explicabo suscipit ipsa. Quod aut vel qui corporis blanditiis. Vel consequatur omnis quam.\n\nOccaecati illo consequatur quo. Dolores numquam omnis officia possimus quaerat reprehenderit ab officia. Minima ipsam laborum quibusdam perferendis. Quia ad et quo expedita omnis culpa fugiat. Laudantium blanditiis in architecto expedita recusandae exercitationem deleniti sed. Dolores perspiciatis qui vitae ipsam ut sunt et.\n\nVoluptatibus ullam sunt laudantium qui tempore aspernatur quia eos dolorem. Sed inventore voluptatem enim consequatur enim porro facilis. Tempore eligendi reiciendis delectus fugiat praesentium totam. Laudantium perferendis nemo deleniti eos animi sapiente. Modi exercitationem quisquam odit in nihil ipsa iure eum fugit.\n\nAmet incidunt tempore at tempore fugit quaerat doloremque illo voluptatem. Sed blanditiis aspernatur. Corrupti omnis et voluptatibus sed eos. Tenetur nostrum repellat odio. Sed tenetur nihil rerum sit. Quaerat et eos possimus.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("5455545c-5560-4bd0-a17c-df90fd631e4f"), "Beatae quisquam maiores ut quis sapiente temporibus sunt velit. Ut aperiam consectetur quos. Dolorum perferendis alias alias et mollitia quod. Harum accusantium veniam aut et esse accusamus vel sunt dicta. Rem et molestiae quae esse accusantium.\n\nUllam et labore quam minus. Ea quia quis alias quia est. Quo minima nostrum ut et et dolore voluptate.\n\nIn voluptas excepturi eligendi similique molestias. Et officiis ea sint. Iste dolor dolorum nam dolor iure officia.\n\nInventore mollitia autem quaerat in dolores doloremque illo ipsum. Ad exercitationem officiis eius sapiente. Velit voluptate voluptatibus illo inventore dolor. Assumenda cumque modi iste corporis quis occaecati tempora. Excepturi voluptatem sed blanditiis corporis minima.\n\nLibero corporis maiores recusandae nisi sed commodi qui. Sit consequuntur veniam est fugit libero et explicabo dicta ut. Illum et reprehenderit quae eius.\n\nDolore ipsum voluptatem porro assumenda mollitia repellendus. Repudiandae quia nobis perferendis. Iusto dolorem magnam id beatae maxime velit nemo est. Vero excepturi et optio aut. Ex sit repellat harum quia temporibus. Voluptas voluptas sint.", null, null, "Example Page 2 - Paragraph 2", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("5d3bc25e-7b73-499b-b0e8-4535879e3973"), "Laborum voluptates labore saepe. Dolor nihil eaque. Eveniet molestiae quis quas consequatur voluptatem laborum tempore.\n\nId facere voluptates ullam error eum esse. Est ut aut ducimus soluta id similique est. Quis praesentium nulla aliquid ipsum aperiam.\n\nVelit sint ad perferendis dolorum et provident hic. Tempore nobis cupiditate non minus ipsum quia accusamus in voluptatem. Veritatis corporis quia illo culpa cupiditate aut eligendi deserunt. Est non animi. Qui exercitationem eius voluptatem facilis.\n\nMinima consequatur nisi. Accusamus et aut et non. Dolores dolores aliquid omnis ut.\n\nSed iste earum odit ab qui officiis error. Error in qui dolorum eos qui explicabo et eveniet dolore. Dolor consequatur numquam dolor.\n\nEt autem omnis eos iusto eaque. Dignissimos perferendis hic atque temporibus nihil maiores. Iste voluptatem cupiditate consequatur quibusdam praesentium aut culpa dolores aut.\n\nError cumque aut. Cupiditate et et fugiat quis. Explicabo ut dolor nemo ullam maxime et est. Accusantium sapiente et. Facere excepturi aut ut sequi ad autem facilis sint.", null, null, "Example Page 1 - Paragraph 4", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("642a5509-4d6f-472b-b449-6239850fa718"), "Doloremque tempora sunt delectus. Est sed et non. Quas ex vitae voluptatem. Dolore officia est perspiciatis porro. Maxime omnis fuga facere qui illo.\n\nMolestias esse nulla ea est quo accusantium autem deserunt. Saepe ad officia voluptas doloremque alias. Odio voluptas nostrum delectus. Eum ratione quos explicabo et. Sint voluptatem dolorem beatae magni magnam pariatur sapiente.\n\nOdio magnam iusto omnis mollitia enim. Aut exercitationem ullam odio consequatur. Natus doloribus veniam illum qui cupiditate qui. Nihil ratione quibusdam maiores tempore excepturi cupiditate. Reiciendis dolorem fugiat possimus quidem eos provident. Rem aut sit et non rem quaerat quasi tempora rerum.\n\nEnim voluptas amet quae deserunt ea aspernatur repudiandae voluptatem est. Et esse fugit tempore rerum et ut. Nulla excepturi voluptas iste sunt aut error impedit. Illo voluptas maiores. Incidunt veritatis quibusdam in.\n\nIure repudiandae deleniti itaque sequi quisquam. Sit vel laudantium ut repellendus magni ipsam non. Sit tempora expedita.", null, null, "Example Page 2 - Paragraph 6", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("69817e7b-db78-4f18-86a5-26bb6c7d3bdf"), "Molestiae assumenda saepe repudiandae veniam consequatur. Quasi amet doloremque dolorum. Quia pariatur dicta asperiores temporibus.\n\nDucimus voluptate ut. Doloremque aut deleniti tempore in cumque. Rem quibusdam recusandae dolor nam.\n\nVoluptatem doloribus veritatis voluptatem eligendi nobis deleniti qui sunt delectus. Voluptate unde quam eaque est sunt ipsa quo. Illum dolor quis ducimus modi id.", null, null, "Example Page 2 - Paragraph 5", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") },
                    { new Guid("6982ef85-c11e-4e3f-b8e3-53a49c0bb266"), "Molestias omnis voluptatem provident fugit dolor. Eum non qui earum pariatur maxime. Sit ipsa numquam iure ipsa nam. Nisi harum ut a temporibus eaque commodi.\n\nDicta ut quae. Sit nihil laudantium hic asperiores in. Omnis incidunt et occaecati perferendis consequatur ipsum. Velit deserunt eveniet aliquid eos sunt unde explicabo.\n\nNisi sunt sed sint quos nulla quis consequatur repellat. Quidem dicta quia. Et ratione et officiis voluptate consequatur velit. Aut minima qui sapiente.\n\nSit neque sed autem in. Iste nihil voluptatem repellat consequatur est provident impedit nemo. Aliquam rerum labore ad blanditiis. Et eius nobis aut aut et et.\n\nQuisquam ducimus repudiandae molestiae suscipit. Dolore molestias aspernatur non. Mollitia et id aut quod voluptate quia. Eveniet et facilis.\n\nOmnis omnis placeat quasi earum quis. Est numquam tenetur omnis in. Expedita qui occaecati nemo quia autem at qui aut.\n\nMagni suscipit porro non ab sed. Eos impedit quisquam qui culpa rerum incidunt voluptatem. Placeat provident ut non esse nostrum perspiciatis labore delectus rem. Neque expedita nulla eaque dolores. Consequatur architecto quia maiores.", null, null, "Example Page 1 - Paragraph 2", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("92c80242-b379-426d-b0c1-00ba71826803"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0") },
                    { new Guid("9d0aef9a-e1f2-4197-a06a-a6b23d85fccd"), "Aut possimus rerum non minus. Expedita repudiandae aut. Hic id recusandae soluta id. Ut omnis aut harum et et nesciunt sapiente.\n\nVelit vel voluptatem ea rem inventore nostrum earum. Voluptates nostrum voluptatibus odio dicta iure quas hic sapiente. Perferendis blanditiis ratione saepe expedita et dolores.", null, null, "Example Page 1 - Paragraph 3", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("b3cf4572-0105-4700-bdf1-489d935fc3d2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("77cd46cc-5887-4d4f-9f48-cb8ade4ab4c0") },
                    { new Guid("c5905114-ba5b-4a91-be54-e5dbbfcd8438"), "Accusamus voluptate facere dolorem molestias quisquam aliquam sint. Voluptatibus qui quod omnis. Nihil dolores voluptatem libero aliquid unde laudantium eos. Consequatur molestiae et eius iusto natus nesciunt. Vel unde facere. Nulla eveniet commodi voluptatem rerum nobis sint.\n\nQui possimus sit voluptates eum. Alias voluptates ullam cupiditate sit beatae veniam rerum quis. Explicabo amet ratione et illum accusantium expedita aut.\n\nEt sit quam voluptates quasi possimus. Cumque et quas incidunt. Molestias nihil incidunt. Qui nobis neque nulla et quis eaque odit assumenda. Animi sit ut modi.\n\nCommodi dolorum similique eveniet aliquid ipsam quia qui. Dicta quisquam voluptatem odit ad eligendi dolor et. Consequatur quaerat et est praesentium autem et ut eligendi optio.\n\nVel voluptas harum. Voluptas ipsa quo. Impedit et enim amet illo atque consequatur. Earum repellat numquam unde nesciunt.\n\nVelit velit debitis est tempora atque. Facilis iste nemo necessitatibus sunt accusantium voluptatem. Repellendus dignissimos est iusto est laborum quos repellat ex voluptatem.\n\nArchitecto eveniet sed nesciunt repudiandae nemo vel dolore quia. Molestiae quis vitae ullam eaque reprehenderit est. Sit rerum molestias qui velit fuga magni fugit odio. Quae recusandae sequi. Enim molestias tempore impedit expedita consequatur consectetur deleniti harum illo. Dolore adipisci sit reprehenderit.\n\nRatione ex commodi et quia eaque magni. Numquam maiores exercitationem porro nemo nulla alias totam sit velit. Necessitatibus rem et distinctio ipsam. Hic molestiae sed.", null, null, "Example Page 1 - Paragraph 5", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("c5e70262-4b09-46bf-b2b3-3dba5d6d0ef0"), "Sapiente tenetur voluptates in in qui animi nemo aut. Ratione accusantium cum ex. Ipsum assumenda dolorem deserunt quaerat nesciunt rerum. Nobis pariatur eligendi hic officiis vel. Vel numquam animi et eos at quaerat.\n\nHarum voluptas et rerum. Ipsum fugiat dolor quo voluptas enim temporibus. Et impedit facere neque blanditiis commodi natus. Impedit molestias et.\n\nProvident aut aliquam nesciunt tempora aliquam sed. Repudiandae inventore placeat sit excepturi ut porro. Non eaque ipsum.\n\nQui velit aliquam at. Nisi officia numquam. Nobis sit qui similique ab vitae autem nihil. Deleniti quam occaecati repellat recusandae asperiores delectus qui omnis facere. Tempore doloribus sint illum consequatur beatae magni voluptas reprehenderit. Incidunt animi pariatur aspernatur.\n\nMolestias neque porro maiores eveniet et nemo ea. Natus dolorum enim qui eos nostrum. Ea unde tenetur magni molestiae minima et nostrum reprehenderit sed. Maxime temporibus molestias.\n\nQuo sint fugit ad soluta porro illo voluptatibus maiores. Cupiditate molestiae ab. Odit non officiis.", null, null, "Example Page 1 - Paragraph 6", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("c8c5ad13-44cc-4125-8541-0191168384f8"), "Earum exercitationem deserunt. Laudantium dolor autem voluptatem natus. Omnis facilis reiciendis temporibus eius sed ipsum sint sunt explicabo. Id aut voluptatem ut ea. Magni quaerat eligendi voluptatibus ut autem veritatis iste. Recusandae assumenda porro iusto quos enim maxime qui.\n\nAutem maxime odit est ut ut. Assumenda vero ea voluptas quia earum nobis. Veniam voluptatem doloribus. Aut non vel rerum eum ut. Dolorem tempore tempore voluptatum.\n\nModi qui sit rem et et rem quis consequatur. Facilis aperiam et numquam quo inventore aut atque. Labore delectus maiores accusamus voluptatem aut et rerum nam. Repudiandae cumque amet vel est error et. Dicta blanditiis eaque soluta numquam.\n\nSit aut nisi. Aut molestiae suscipit dolorum ex quia unde. Voluptates dignissimos culpa dicta est consequatur perspiciatis nisi. Temporibus nostrum facilis qui doloribus pariatur esse sint ullam. Necessitatibus vel at.\n\nEarum quo nulla et sed earum vel distinctio fuga. Dolor aut incidunt. Dicta magni in provident corporis velit. Beatae occaecati modi fuga blanditiis explicabo quia ab officia ratione. Qui sint perferendis odio saepe. Nihil voluptas exercitationem dolores quam rerum labore.\n\nAssumenda quis repudiandae fugiat consectetur consequuntur natus labore ipsum. Dolor qui eos veritatis harum. Ullam facilis illo omnis nobis ut recusandae quia culpa. Cupiditate est earum voluptas consectetur repellendus ipsam et. Incidunt quo aperiam et. Illum voluptatem maxime tempora et eum.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") },
                    { new Guid("ff93d442-a4f7-408b-836a-f32aac08c8f3"), "Aut nostrum reiciendis eaque deleniti temporibus voluptate officia doloribus aperiam. Id voluptas ut perferendis sed. Enim velit fuga ut ut aut enim omnis alias animi. Blanditiis ipsam ea consequatur. Consequatur nihil quasi quo sed. Soluta eveniet nobis velit explicabo.\n\nTempore et rerum. Dolorem libero molestiae quis est qui nam doloribus. Ut necessitatibus dolorem. Asperiores excepturi quam voluptatem beatae aut aut excepturi et. Veritatis illum amet magni aut sit qui nulla dolorem maiores.\n\nQui expedita assumenda distinctio quia. Nemo omnis voluptatibus voluptate consequuntur cumque temporibus. Deserunt vero dolor quisquam sed. A quia iure ut rerum quo eaque tempore sit debitis. Incidunt quia molestiae quam.\n\nAnimi eius accusantium. Pariatur aperiam libero quisquam autem sit illo velit doloremque. Quod eligendi animi esse consequatur in ad aut voluptas.\n\nMinima est atque rerum pariatur provident pariatur et nulla. Quod sunt voluptas iusto. Ex sed blanditiis quo qui beatae accusamus et.\n\nRecusandae provident est iusto. Alias voluptas adipisci veniam ipsa nemo iusto eum a. Et qui possimus incidunt numquam nulla. Aliquam nam reprehenderit quo perspiciatis voluptatem molestiae. Consectetur officia explicabo ab quia tempora voluptatibus ullam. In sit qui recusandae ratione itaque aliquam ea minima.", null, null, "Example Page 2 - Paragraph 3", new Guid("503b4921-68af-404d-bc41-9cd87c24892a") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "CategoryId", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e"), false, new Guid("983c8dc4-552d-48c9-8ddd-4a6f3b4f8353"), null, "UserSubmittedWikiPage", false, null, true, new DateTime(2024, 5, 14, 7, 38, 9, 495, DateTimeKind.Local).AddTicks(9938), "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("54d1e955-5ecb-492e-9cc6-74f89909d655") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("a30a1f07-98d6-4709-8ff4-5c92657aaafb"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e") },
                    { new Guid("d580eec7-26e3-48ca-bdef-5141cf4766e4"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("d32b50da-e6b2-4cf6-bd8a-befd88b3331e") }
                });
        }
    }
}
