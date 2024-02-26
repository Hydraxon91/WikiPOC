using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddApplicationUser2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfile_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_UserComment_ReplyToCommentId",
                table: "UserComment");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComment_UserProfile_UserProfileId",
                table: "UserComment");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "UserProfile",
                newName: "UserProfiles");

            migrationBuilder.RenameTable(
                name: "UserComment",
                newName: "UserComments");

            migrationBuilder.RenameIndex(
                name: "IX_UserComment_UserProfileId",
                table: "UserComments",
                newName: "IX_UserComments_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserComment_ReplyToCommentId",
                table: "UserComments",
                newName: "IX_UserComments_ReplyToCommentId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Earum quas esse aut veritatis autem recusandae et. Praesentium aut ut dolore voluptatum. Voluptatem earum quia voluptas.\n\nDolorem quia magni. Et aut molestiae maxime velit qui voluptatibus. Voluptas voluptas placeat aut quae natus. Est nobis qui. Deserunt est corporis sed commodi eius sunt accusantium dicta. Nihil nemo et molestiae.\n\nItaque in dolorem maiores minus iure ut sed magni. Et dignissimos sint qui. Atque omnis dicta nam. Repellendus sapiente et aut impedit. Qui et deserunt temporibus ullam in sed voluptatem. Suscipit sit necessitatibus.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Fugiat quia sed rem et animi vitae sit ea. Et voluptas facere. Aperiam modi similique dolorem quos perferendis explicabo hic.\n\nDolor nobis incidunt voluptatem totam deserunt. Dolores ab velit ea dignissimos aut vel qui amet officia. Deleniti corporis eos quod natus error facilis.\n\nSoluta quos velit temporibus iste. Occaecati et pariatur repellat facilis delectus. Voluptatem non ut iure et.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Molestiae adipisci beatae inventore nisi recusandae beatae. Quam rerum qui nostrum perspiciatis. Sit voluptate voluptas voluptatem porro aut quibusdam. Molestias quod suscipit ipsum nulla corrupti consequatur animi tempore temporibus.\n\nSed deserunt odio in. Minus soluta et. Occaecati quisquam dicta est. Vel aliquam architecto explicabo iste reprehenderit fugiat necessitatibus.\n\nPariatur nostrum voluptatem. Non ratione eum. Iusto in voluptatibus. Ducimus voluptatem aperiam consequatur dolorum et aut. Quod est debitis quibusdam voluptatibus.\n\nQui laborum nihil qui quaerat ipsam. Voluptatibus at qui nemo rerum praesentium quia commodi. Earum animi quia repellat possimus quisquam sint voluptatem numquam. Nobis omnis ut inventore et repudiandae. Perferendis temporibus quisquam veritatis quidem atque corrupti.\n\nAnimi a dolor rerum consectetur quod neque ut. Ducimus dolore voluptatem deserunt et deserunt voluptatem consequatur quia. Praesentium vel quia dolorem veniam esse.\n\nMolestiae optio similique mollitia. Autem placeat omnis qui numquam officiis. Quidem officiis repudiandae. Aut dolor quia rem numquam omnis et neque. Laboriosam consectetur non hic doloremque nam qui voluptatibus sint.\n\nConsequatur eos enim repudiandae eum. Cupiditate quia et dolor mollitia. Culpa aut blanditiis corrupti incidunt fugit repudiandae. Debitis nulla pariatur adipisci.\n\nEligendi earum quo quibusdam in dolorum. Autem voluptatum dolores esse omnis et omnis voluptatibus. Est et possimus. Debitis magnam iure tempora consequatur. Reprehenderit magnam earum.\n\nQuas ad molestiae labore autem delectus. Voluptates ducimus qui exercitationem deserunt. Ut maiores similique nulla et corrupti et id.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "Nemo ut dolores nihil. Aliquam quasi consequatur ut consequatur aut. Nisi et iure aliquam porro non.\n\nDistinctio autem quo sit iusto aspernatur sint consequatur. Est rem aut et qui hic. Similique facere nostrum. Laborum aut velit ab provident quos veniam illo blanditiis.\n\nDolore nulla iusto reprehenderit. Sequi dolor asperiores magni molestiae. Quaerat aliquam aut perspiciatis.\n\nAspernatur quisquam ex et necessitatibus eveniet qui voluptates aliquid. Dolores dicta excepturi accusamus laboriosam minima quia ex ipsum. Soluta aut debitis in sunt deserunt omnis quibusdam. Est sunt maxime numquam nulla enim dolor.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Molestiae cupiditate veritatis quia optio nisi voluptatum voluptatum dolor itaque. Libero ipsa eligendi ducimus et repudiandae corrupti natus. Quia vero eius quibusdam nostrum sed. Id dicta enim incidunt eum qui deserunt.\n\nEt vitae laudantium. Voluptate eos sunt distinctio qui est quas ipsa accusantium quidem. Nobis debitis autem labore velit rerum. Rerum expedita fugiat harum magnam illo amet.\n\nIllum aperiam culpa suscipit corporis eos. Sed hic eaque nihil. Est nam suscipit unde alias aut. Nam culpa quia est itaque iure ea quas est. Iusto est ut. Harum harum soluta in rerum hic id sit.\n\nBlanditiis laborum reprehenderit velit. Est distinctio corporis aut enim modi nihil est. Velit magni non et vel omnis nihil nam odit. Cumque officiis et tenetur eaque. Voluptas modi nesciunt veritatis quod quo possimus ea. Doloremque ut aut enim minus ut.\n\nId reprehenderit ducimus aut. Inventore est velit. Optio laboriosam unde. Sed soluta fugiat non autem officia dolorem. Rem sit quo ad. Aliquam et laboriosam consequatur possimus eum quo.\n\nSit et voluptatem adipisci sit. Dignissimos dolorem pariatur culpa optio culpa nisi. Tenetur magni tempore enim eius. Commodi assumenda autem quibusdam quam nemo deserunt.\n\nIpsa id et ipsam nam deserunt iste sed. Eum et modi esse tempora consequatur occaecati ut. Nemo voluptatem ullam sunt. Nihil pariatur quod rerum fugit totam hic sunt.\n\nQuia magni amet expedita qui et reiciendis qui tempore qui. Et nobis at. Velit ducimus omnis. Et necessitatibus non atque maiores consequatur enim.\n\nQui mollitia excepturi qui eos dolores voluptates voluptatem saepe ullam. Soluta nostrum tenetur iure nulla. Ut et exercitationem sit.\n\nEsse deleniti beatae. Dolor impedit eos rerum. In sed animi quisquam dicta quidem id. Commodi amet aut perspiciatis vel autem. Placeat voluptatem aut autem et. Aut velit beatae quasi omnis amet.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "Totam quia id veniam aliquam porro ut deserunt. Officia quas nobis. Nisi et dicta et tempora.\n\nEst ipsum nesciunt itaque dolor perferendis repellat. Facilis fugiat occaecati distinctio rerum. Voluptatem rerum praesentium sapiente magnam ut eligendi amet rem.\n\nSoluta nam ipsum. Quia maiores placeat et cum et nemo sit eum. Nobis minus distinctio suscipit ex fugit impedit laborum. Quibusdam quidem perferendis et impedit nihil rem aut quasi. Consectetur nesciunt ullam consequatur dicta maxime.\n\nMinima facere libero. Dicta tempore quisquam ad perspiciatis hic. Impedit maxime maxime similique debitis tempore qui consequatur.\n\nDoloremque quia et. Rem dolor sit facilis culpa. Architecto libero et. Aperiam consequatur ut ut eos eum molestiae.\n\nTempore facere vel quod dolorem voluptatibus illum. Beatae odit cumque placeat minima consequatur natus incidunt. Voluptates vitae aliquam eum asperiores et repellat et ut.\n\nVoluptas ipsa id quis ut et optio recusandae nobis. Dolores quam ullam nihil accusantium aut. Voluptate enim impedit omnis minus reiciendis eum odit deleniti illum. Et impedit distinctio labore ad autem enim.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "Consequatur qui et. Similique ratione aspernatur deleniti vitae mollitia voluptates reprehenderit sint expedita. Quia sed cum nisi amet necessitatibus animi. Totam dolorem porro repellat perspiciatis. Nemo vel sit quo delectus praesentium.\n\nQuae porro repudiandae et. Corrupti dolor dolores vero hic. Cupiditate et ex tenetur laboriosam facere ut consequatur sapiente. Eos aut nulla corrupti. Dignissimos voluptatum occaecati nostrum. Ea quis non odio.\n\nEaque quod pariatur quia possimus adipisci aut omnis tempora. Tempore dolorum fuga quis. Saepe consequatur adipisci nisi qui amet. Enim quo expedita quisquam voluptatem et nihil eos sint quod. Dolor et itaque. Rerum nesciunt id recusandae.\n\nAccusantium aut ut delectus. Non facilis hic non aperiam consectetur explicabo omnis nesciunt. Voluptatum sequi tempora recusandae est. Dolore consectetur laborum aut repellendus.\n\nMolestiae ut saepe voluptas quibusdam delectus. Temporibus quia sed voluptatum eaque laudantium recusandae quaerat. Eum provident nam iste suscipit. Aut corporis molestiae id laborum magni. Dolor consequatur voluptatum eaque rerum dolor libero autem tempora.\n\nPossimus illo aperiam numquam in unde et. Facere et optio sapiente vel maiores maxime. Iure consectetur quisquam et voluptatem totam laborum eligendi veritatis. Distinctio nihil voluptatem totam et. Repellendus nemo vitae.\n\nAutem excepturi illo et nostrum aut. Consequuntur amet dolor dicta rerum vel fugiat qui eligendi. Dolores consectetur nihil rerum.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "Ut et aut nihil. Voluptatum commodi sunt iste inventore. Tempore tempora sed ullam et voluptatem illo et maxime voluptates. Consectetur eum sed doloribus qui alias dolorem porro qui velit. Est totam ea aliquid eaque temporibus perferendis nesciunt id et. Sint ullam in soluta qui distinctio ratione quo.\n\nNumquam velit rerum enim consequatur deleniti nemo nisi quibusdam ut. Quod quidem nemo dignissimos quidem aut. Qui quis vero sed. Beatae veritatis eveniet laudantium enim.\n\nId iusto voluptatem. Facere dolores magnam ad. Dicta deserunt sed quas animi et.\n\nSint quasi commodi nemo iusto. Assumenda voluptatem consequuntur aut perspiciatis autem repudiandae quasi temporibus. Aut blanditiis labore quae. Quo voluptas eius voluptas omnis dolorum aut et ullam et. Qui pariatur consequatur quia qui.\n\nVeniam iusto deleniti sunt explicabo autem qui ea. In et ut assumenda. Sed sequi laboriosam eligendi non non soluta quod quaerat. Quibusdam sint quidem corporis doloremque consequatur. Ea similique sit ab. Architecto nam quas eum nulla est.\n\nQuo recusandae quisquam cum dolorem veniam dicta laboriosam. Doloribus exercitationem officiis sint dicta. Debitis eaque impedit occaecati dolorum qui impedit. Dignissimos rerum at asperiores quia quisquam esse suscipit.\n\nAb aperiam vel aut debitis nesciunt sit ipsa ut. Ipsam autem et voluptas at qui est. Veritatis neque beatae similique dolorem maxime ducimus. Dicta rerum sint quia voluptas similique aut sed totam.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "Qui excepturi vitae illum dolores repellat quisquam suscipit dolores. Provident provident at quibusdam. Quibusdam molestias ullam sunt ut voluptatem accusantium sed. In voluptas quis a. Qui fugit voluptatibus aut voluptas dolor. Ut qui voluptatem illum esse.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "Consequuntur cumque incidunt culpa error iusto suscipit doloribus voluptatum excepturi. Nemo facere sit nostrum dolorem vel dolorem cumque eius labore. Nihil atque nihil eligendi quis ea quasi nihil molestias dolores.\n\nAliquam qui voluptate. Doloribus corporis porro consequatur voluptas optio id harum autem voluptate. Id ullam quibusdam. Impedit ea enim aut. Dolorem laudantium quaerat ab distinctio.\n\nOdio voluptatem adipisci sed cupiditate. Dolorem corrupti repellendus similique optio. Voluptatem vero aperiam. Perspiciatis placeat voluptatem.\n\nAliquam quidem consequatur dolor et. Illo non a autem eveniet ut maxime quasi ex totam. Sapiente voluptatem consequatur saepe sit quisquam deleniti aut. Ipsum sequi iste ipsam facere. Sint reiciendis ipsam totam.\n\nVel adipisci autem qui illum qui eius vel quibusdam. Assumenda alias delectus consequuntur quia id. Doloremque magnam rerum ea eum quia beatae. Provident sit et. Architecto et nihil eum accusamus ut ut. Est fuga sequi quia similique officiis est aut maiores ut.\n\nVoluptas dolorum sed porro blanditiis sit. Ab sit officia consequatur voluptates omnis unde quasi. Doloremque nostrum sint explicabo consequatur aperiam nesciunt. Perferendis ad nobis quas doloremque et sunt sint.\n\nId maiores repellendus alias. Praesentium doloremque reprehenderit commodi quia qui rerum. Aut aut et at dolor fugiat distinctio est et corrupti. Nostrum asperiores velit eligendi similique voluptatibus ea et voluptas.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Content",
                value: "Iusto aliquam dolores magni atque incidunt est. Possimus nihil velit enim dolor aut ea sequi rem. In harum quam est et.\n\nAspernatur aut molestias esse. Aut quibusdam animi. Consequatur est aliquid voluptatem quos sit distinctio quo quos tempore. Ut quo numquam blanditiis necessitatibus voluptatem modi qui et. Dolores culpa laboriosam eum dolor illo qui voluptates totam quae. Non non aspernatur odit in rem dolor.\n\nMagni doloribus earum id quo harum minus sed. Aut sed rerum nobis beatae delectus. Explicabo illum autem ratione quisquam voluptates. Laudantium maxime inventore soluta possimus minima explicabo aut eum. Assumenda quia accusantium provident ducimus sequi neque quae maiores et.\n\nConsequatur alias qui aut est impedit. Officia nesciunt esse autem vel aut qui velit. Distinctio quas nihil perspiciatis. Sed sed voluptatem dolores aut sint nesciunt minima et.\n\nPariatur accusamus illum molestiae id mollitia iste. Sit alias quae nisi. Enim consectetur minus quia voluptates voluptas saepe. Voluptates omnis a molestias debitis nemo sed eos. Enim fugiat expedita sunt impedit.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Content",
                value: "Molestias doloremque architecto possimus aperiam illum explicabo nulla assumenda provident. Odit delectus voluptas aut aut nulla incidunt eum. Labore blanditiis corrupti sed perferendis in aperiam vel optio. Fugit et nemo nostrum quasi et aut. Rerum quasi corporis libero occaecati dicta sunt asperiores libero ea.\n\nHic enim perferendis veniam omnis sunt ut esse repudiandae ea. Dolor qui qui cupiditate alias doloribus magni. Assumenda dolores animi minus qui sequi. Ea in earum beatae ex laborum. Accusamus voluptas repellat est autem consequatur nihil velit sapiente ex. Aut sed similique tenetur.\n\nInventore possimus magni quo. Quae fuga eum quia aut et. Consequatur aut eos et quia ullam ad. Laboriosam facere blanditiis ea et. Possimus ad suscipit delectus. Dolore et id mollitia distinctio et molestias.\n\nVoluptatem aperiam omnis. Rerum maiores quis facere. Et temporibus harum et quam.\n\nQuo nisi qui dolores eius illum. Cumque praesentium occaecati. Veritatis laboriosam itaque deserunt. Nobis quae sunt et quaerat non delectus quo. Soluta magnam maiores ut ut itaque delectus. Id consequatur quo dolores quis.");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfiles_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments",
                column: "ReplyToCommentId",
                principalTable: "UserComments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComments_UserProfiles_UserProfileId",
                table: "UserComments",
                column: "UserProfileId",
                principalTable: "UserProfiles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserProfiles_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserComments_ReplyToCommentId",
                table: "UserComments");

            migrationBuilder.DropForeignKey(
                name: "FK_UserComments_UserProfiles_UserProfileId",
                table: "UserComments");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProfiles",
                table: "UserProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserComments",
                table: "UserComments");

            migrationBuilder.RenameTable(
                name: "UserProfiles",
                newName: "UserProfile");

            migrationBuilder.RenameTable(
                name: "UserComments",
                newName: "UserComment");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_UserProfileId",
                table: "UserComment",
                newName: "IX_UserComment_UserProfileId");

            migrationBuilder.RenameIndex(
                name: "IX_UserComments_ReplyToCommentId",
                table: "UserComment",
                newName: "IX_UserComment_ReplyToCommentId");

            migrationBuilder.AlterColumn<int>(
                name: "ProfileId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProfile",
                table: "UserProfile",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserComment",
                table: "UserComment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Debitis ut et recusandae ducimus voluptatibus aut quo non. Repellat eius tempora quasi. Eos autem est. Eveniet est sunt voluptas optio doloremque sed aliquid modi.\n\nVoluptatem autem omnis harum. Ut voluptate a repellendus dolores saepe temporibus dolor sunt autem. Mollitia non voluptates provident numquam ut error.\n\nNam non quod sed. Soluta distinctio vel perferendis. Repudiandae voluptas molestiae consequuntur et voluptatem. Ex molestiae ut nam consequatur vel voluptatem. Suscipit voluptatem veniam voluptatem voluptates architecto perspiciatis id. Reprehenderit dicta dolor odit ea qui dolores fugiat temporibus rerum.\n\nEt voluptatibus enim. Rem laborum adipisci eos blanditiis. Ullam explicabo consectetur ut ducimus beatae laborum architecto. Sunt eveniet aliquam aut cum.\n\nEt dolorem consectetur aperiam eum id. Aliquid ut ut qui qui aut deserunt corporis. Inventore est neque neque eum qui.\n\nUt provident aperiam facere ut. Eius corrupti est dolorem mollitia quo ut nobis dolorem. Quasi voluptas dolorem necessitatibus corrupti et. Velit delectus voluptatem unde aperiam minus eius consectetur. Numquam dolor dolorem. Quibusdam repellat aspernatur aut quo et quod assumenda.\n\nQuia culpa error reiciendis beatae minima repellat. Voluptate optio in nihil aut voluptates soluta omnis ut quam. Nam et repellendus magni fuga dignissimos quae. Ducimus unde sapiente dolore officia consequatur rerum sed excepturi. Unde accusamus rerum veritatis vero quisquam incidunt aut. Est quae qui et consectetur.\n\nDolorem ducimus temporibus sed odit voluptatem. Optio adipisci quia. Corrupti velit culpa qui laborum laborum. Omnis quia maiores et qui quos quo. Cumque sit ullam nisi quia corporis omnis sed dolorem.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Est nostrum omnis. Dolores in perspiciatis non et consequatur deserunt rerum voluptatem et. A unde eaque unde et sint possimus. Ut nemo aliquid omnis.\n\nQui molestias ea laudantium. Quia illo recusandae quia quam autem. Et rerum saepe sunt dolorem rem doloremque.\n\nVoluptatem rerum alias est voluptas adipisci culpa omnis. Optio harum architecto facere. Facilis omnis accusantium doloremque ullam. Doloribus deleniti quod ut et necessitatibus et. Minus id inventore veritatis magnam id.\n\nExercitationem laborum necessitatibus debitis suscipit voluptatem molestiae nulla quasi. Ut autem quibusdam mollitia. Sit quis maxime sunt rerum eos quisquam ipsa omnis.\n\nSint voluptas maxime alias. Voluptatibus et aut labore et et laborum. Necessitatibus ducimus eaque vel. Architecto velit ut officia impedit. Hic similique rerum sint et accusamus pariatur dicta dolores.\n\nDolorem in magnam. Adipisci cum voluptate eaque sunt est quis ut vitae distinctio. Dolorem sint ut non voluptatibus minus. Et mollitia libero. Nihil quidem aut molestiae et est fugit aliquid placeat nesciunt. Et a nostrum eum aperiam nihil et facere eum voluptas.\n\nSoluta asperiores animi commodi cum excepturi facere esse laudantium. Sunt omnis esse nostrum. Sit recusandae ut ducimus facere.\n\nRepellendus culpa hic. Dolorum rerum rem impedit blanditiis ratione et et. Dolores dolore quod facere est. Cupiditate quo ut est. Aut nulla dolorem sint aut possimus. Officia quas consequatur sit fugiat eaque aut voluptatem.\n\nEt officiis quod. Aut exercitationem cum explicabo harum. Magni pariatur dolorem ut. Enim consectetur animi unde quidem vel optio reiciendis quo. Ea quis est perspiciatis aut et.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Tenetur quidem quis. Ea earum eum vero. Dolorem aut voluptatum quasi. Eligendi dolore nihil iusto aperiam necessitatibus eos quis labore.\n\nOmnis id ex velit reprehenderit voluptate veniam sed eligendi. Voluptatem placeat qui qui aut. Nobis minus laudantium quae est dolorem dignissimos doloribus qui molestiae. Et laboriosam ea eius.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "Corrupti et est quam molestias occaecati saepe vero. Accusamus omnis enim voluptatem qui vel at voluptas voluptates voluptatibus. Unde veniam aut nostrum non est quia tempora. Mollitia totam recusandae et modi. Ut eum voluptatum blanditiis atque minus quo animi in quo.\n\nEligendi corporis id. Eius unde qui cum. Animi quas ut sunt delectus. Vel tenetur doloribus.\n\nQuo minus rem tempora iusto possimus. Facilis sint qui voluptatibus ipsum suscipit velit. Reprehenderit eos libero explicabo aut repellat eligendi ut assumenda vitae. Perspiciatis dolorem minima in tempora odit.\n\nEt voluptatem optio est id quo rerum et. Iusto voluptate eveniet animi ut. Libero enim hic. Ut dolorem non est qui qui molestias magni dolorum excepturi.\n\nEnim rerum maiores dolore eos. Nam omnis quasi rem omnis eveniet harum voluptatum quo in. Laboriosam unde molestiae deserunt atque quia nobis excepturi odio et.\n\nAut omnis distinctio omnis veniam. Voluptas debitis voluptatum perferendis iste maxime voluptatibus corrupti. Sint voluptates eum repellat numquam quis earum optio adipisci. Mollitia nesciunt cupiditate a soluta qui.\n\nSint possimus voluptas a expedita. Quas incidunt voluptas id omnis. Autem incidunt dolores sunt. Unde et et rerum omnis.\n\nRem explicabo quisquam occaecati quo vel itaque. Doloremque corrupti nisi harum ut et. Quo earum animi ratione similique ut neque commodi.\n\nExpedita aut vel ex ut recusandae provident odio. Rerum labore natus ratione voluptas nostrum esse harum laborum. Est tenetur quisquam quo sed. Ipsum rem consequuntur laboriosam nostrum temporibus quia dicta doloremque occaecati. Delectus pariatur porro ex a maxime.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Iure dolore deleniti necessitatibus. Dolores placeat ea est quod omnis amet aut voluptatem rerum. Optio similique et ad cum et. Qui itaque dignissimos ipsa autem aut et sunt tempora necessitatibus.\n\nMagnam voluptatibus esse qui. Nihil nam laudantium ratione. Et non dolores. Non reiciendis sunt nostrum ea. Nisi et eum aliquid labore optio suscipit. Sint vitae officia harum deleniti recusandae facilis numquam.\n\nEa dolore quis ut. Porro quae sit repellat. Nisi ab animi velit non.\n\nCulpa sit quia adipisci mollitia aut eos dolor. Ullam deleniti consequatur ut. Doloribus aliquam voluptatem sed numquam est impedit et excepturi dolorem. Fugit vitae modi rerum et culpa unde. Repudiandae voluptatem porro expedita.\n\nAut voluptate maiores. Totam nesciunt amet explicabo veritatis nisi illo eius sint. Accusamus sunt sequi fugit quia qui.\n\nPossimus nostrum porro vel quis sed ducimus. Dolor enim molestiae quis incidunt perferendis quia quia. Est magni eum. Aut est consequatur et facere.\n\nDolor qui ut velit. Vel sint nam eos rerum magni neque consequatur voluptatum saepe. Numquam et consectetur ut doloribus officiis occaecati est. Qui fuga dolorem sed modi.\n\nVel consequatur quasi et. Aliquid dolore iste excepturi soluta. Vel aliquid tenetur culpa et quas quasi. Totam quis culpa eaque atque ex magni beatae. Perferendis exercitationem quaerat maxime.\n\nHic saepe laboriosam repellat minus exercitationem rerum facere dolor placeat. Illum ad sed est amet non voluptatem. Architecto sunt sapiente rerum aut quae et quidem. Voluptates consectetur iure dolorem iusto.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "Nesciunt autem ut ea distinctio. Sit ipsam iste. In sit esse.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "Quia unde quia minus facilis. Omnis similique facilis minus quia molestiae veritatis. Quo consequuntur officiis repellat delectus deserunt.\n\nSint est dolorem. Quia doloremque et error occaecati non ad. Ut maxime tenetur.\n\nReiciendis omnis in dolores sunt voluptas ut quod exercitationem est. Aspernatur et aut ad doloremque accusantium qui quod dicta. Qui id est voluptas itaque quia. Ipsum maxime quam reprehenderit in aperiam qui quae quia accusantium. Odio rem est sint quibusdam soluta sunt. Quia odit libero non in ut explicabo.\n\nEt sunt consequatur ut eum delectus dolor. Sunt non repudiandae facere ut. Quidem consectetur aliquid. Suscipit eos et neque quidem dolores deserunt. Accusamus rerum ipsa consectetur.\n\nVoluptas distinctio ea fuga aut modi explicabo repellendus dolor. Laudantium non minima et voluptas et molestiae hic debitis doloribus. Impedit et cumque assumenda aliquam velit voluptas et fugit.\n\nEos quas dolores officiis accusamus tenetur eum. Voluptatum laboriosam ea dolore excepturi ab inventore voluptas sit. Ab ipsum voluptates quis voluptas occaecati consectetur eos eaque ipsum. Voluptate accusamus fuga.\n\nUt architecto qui quo nulla est. Quaerat laboriosam laudantium velit. Nulla quidem quidem. Quis minus quae ut dignissimos sed. Error ipsam sint labore et architecto non expedita facilis. Tempore autem ea quasi recusandae.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "Vel deleniti aspernatur. Vitae dolorem modi. Quaerat ab harum corrupti sint at est at iste molestiae. Sit aut cupiditate sint dolore qui.\n\nSint recusandae sit qui sit fugit. Eaque voluptatibus et dignissimos aut quam quia cupiditate officia est. Nisi explicabo quo sed quo non. Sequi velit tenetur consequatur quo molestiae sit eos. Fugiat impedit nostrum. Ipsa illo et numquam est quod mollitia minima accusamus explicabo.\n\nEveniet cumque molestiae doloremque esse nulla explicabo ut consectetur itaque. Sit necessitatibus in earum dolores deleniti voluptatem vel eos. At necessitatibus temporibus vel est culpa aut est.\n\nVel explicabo et error dolorem reprehenderit reprehenderit. Voluptates quaerat omnis error. Sint consequatur aspernatur et nisi. Eum ratione velit odio.\n\nDoloribus iste dolorum quia ab omnis. Ea quisquam explicabo aliquid voluptate quo autem est quod. Veritatis quidem recusandae nulla earum accusantium animi iste voluptatem id. Qui repellat praesentium.\n\nMaxime est vitae id rem consequuntur qui cum. Voluptatem assumenda et deleniti expedita. Et sed totam sit possimus aliquam sequi laboriosam. Aut quia natus magnam unde eveniet consequatur. Consequuntur aperiam maxime accusantium qui. Facilis quo quod facilis autem voluptatum fugit suscipit.\n\nBlanditiis molestias deleniti et suscipit est ad. Quibusdam fugit quis quis sed autem. Repellendus at quibusdam. Ducimus est ex exercitationem eos aut dignissimos.\n\nVoluptas temporibus esse hic nihil fugiat error et corporis. Nobis maiores quae. Omnis dolorum reiciendis veritatis ea. Temporibus perspiciatis laudantium id mollitia nobis natus adipisci quam perferendis. Doloribus repellat illo nesciunt quae aut doloremque.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "Possimus assumenda qui eum. Sed distinctio amet nulla aliquam numquam. Earum ipsam quis quisquam cumque vel qui aut.\n\nQui amet quia sint autem numquam. Reiciendis facere exercitationem. Nesciunt sit qui corporis enim velit. Iste odit aut. Excepturi soluta eaque nesciunt expedita facilis commodi veniam. Aspernatur ut et dolores ut soluta nobis exercitationem sunt.\n\nIpsum accusantium atque iste. Molestias harum accusantium animi nemo similique. Ullam quos blanditiis autem architecto facilis beatae id neque. Autem aut quia expedita esse occaecati et nihil.\n\nConsectetur soluta sit porro eaque nesciunt commodi atque. Est sit quasi dicta recusandae animi iusto quas voluptatum. Ducimus tempora sed magnam velit. Magni porro recusandae aut. Soluta libero nihil culpa velit aspernatur repellendus sit facilis.\n\nPariatur ullam accusantium. Adipisci vitae ut. Est voluptatibus ad ullam non eum voluptatem officia. Possimus quia dolorem.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "Magni molestiae veniam. Sunt impedit voluptas hic omnis. Eos veniam praesentium unde praesentium error aut. Aliquam voluptatem praesentium tempore exercitationem odit tempora libero ipsam. Quo quaerat accusamus quaerat earum corporis earum cum. Dolorem qui velit est saepe quia.\n\nOdit ut et et suscipit est odio perferendis. Molestiae impedit laudantium accusamus minus eos repudiandae rem saepe. Quia aut earum. Porro placeat harum non tenetur sunt qui quia excepturi.\n\nMolestiae odit quo perspiciatis eius ut odio. Nisi assumenda at aspernatur corrupti reprehenderit. Cumque qui amet placeat dolorum voluptates et. Distinctio facilis rem molestiae asperiores hic cupiditate hic ipsum optio. Atque iste molestiae velit ipsam iure voluptatem velit consequuntur.\n\nVel iusto autem. Odit voluptatem ratione. Aut voluptatum qui est esse placeat voluptates commodi aut. Rerum aut illum quam atque fuga qui enim quo.\n\nEarum ipsam nihil ut sit nisi debitis. Quos quis sequi exercitationem explicabo voluptatum labore qui rerum repudiandae. Reprehenderit at quidem velit repellendus. Pariatur sed asperiores eos. Quidem excepturi ad.\n\nEligendi libero laboriosam dolor fugiat repellat sit aspernatur et hic. Nobis atque quia voluptas illo consequuntur veritatis. Reprehenderit delectus ipsum quibusdam voluptatem quia molestias illo et quia. Aspernatur fuga ut unde distinctio non est. Eum dolor mollitia sit.\n\nAlias magni omnis laborum ipsam. Quam velit ex et cupiditate atque fugit. Fugiat culpa a dolor earum neque voluptas et. Cum natus rerum consequuntur quis qui assumenda voluptas et. Illo optio sit nisi. Fugiat animi voluptatum corrupti in.\n\nEt quos consectetur hic quae accusamus maiores iste libero ex. Debitis et sint ea ex est eveniet nihil. Aliquid voluptatum et repudiandae. Ipsa repellendus fuga ut et. Voluptate error sint laudantium est. Explicabo aliquid id qui molestiae corporis consequatur aut beatae maiores.\n\nEst maxime ut. Ut eaque amet repellendus voluptas et. Beatae dolorem incidunt exercitationem quia voluptatem. Atque saepe consequatur facere facilis illo accusamus quis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Content",
                value: "Placeat tenetur eligendi accusantium voluptate laudantium tempore beatae ex. Est vero assumenda consequuntur nobis dolores. Voluptatem esse eos et dolor error provident earum totam.\n\nMolestiae in ratione distinctio. Sit dignissimos blanditiis iusto quaerat. Quidem cupiditate quo minus.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Content",
                value: "Ducimus dignissimos laboriosam consequatur ut quos consequatur et qui. Vero et et blanditiis consequatur. Et aperiam omnis autem esse non sed. Et odio illo nulla aperiam ea. Impedit laboriosam nulla temporibus qui sed eum nihil nesciunt.\n\nAsperiores quasi omnis aut. Cumque repellat quo. Iusto necessitatibus voluptatum in qui nesciunt officia non quia. Repellat et similique animi dolorem ab. Sit inventore aut voluptates minima.\n\nQuia illum et et repellendus consequatur libero porro. Aut et voluptas quo ut qui. Occaecati fugiat minus neque beatae et error et molestiae.\n\nDolorem dolor quam necessitatibus vero ex consequatur eius. Quia quia aut dolores velit corrupti sed sit incidunt. Quia aut architecto earum et officiis.\n\nIpsum doloremque vel dolorem debitis earum qui dolores. Dicta consequatur aperiam. Est dolores et.\n\nNeque iste nobis quisquam. Fugiat ut repellendus quaerat molestias cupiditate maiores sequi aut molestiae. Accusantium quod in nobis consectetur ea. Velit nihil sed repudiandae sed quia ullam repellendus perspiciatis. Neque dolores repellat voluptatem. Debitis voluptatum impedit et aut iste mollitia quas culpa.\n\nNesciunt ipsa voluptatem voluptas dolorem consequuntur explicabo soluta et excepturi. Molestiae dolorum ducimus dignissimos nihil laudantium. Recusandae et dicta occaecati qui tempora. Aspernatur dicta et eos omnis. Aut commodi tempore officiis asperiores possimus explicabo magnam a.\n\nAliquam ad molestiae et facilis placeat voluptatum. Tenetur optio inventore dolore assumenda eum aut quis rerum expedita. Iure voluptatibus et quibusdam sunt non.\n\nBlanditiis aliquid deleniti est inventore mollitia. Minus commodi quia sint voluptatem nemo et quia officiis deleniti. Mollitia delectus omnis tempore unde sed est vero. Dolores voluptatem explicabo fuga velit adipisci id vitae. Soluta asperiores amet.");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true,
                filter: "[ProfileId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserProfile_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_UserComment_ReplyToCommentId",
                table: "UserComment",
                column: "ReplyToCommentId",
                principalTable: "UserComment",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserComment_UserProfile_UserProfileId",
                table: "UserComment",
                column: "UserProfileId",
                principalTable: "UserProfile",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
