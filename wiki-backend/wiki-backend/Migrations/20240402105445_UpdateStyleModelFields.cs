using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStyleModelFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WikiName",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FooterListTextColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FooterListLinkTextColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "BodyColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleRightInnerColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleRightColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ArticleColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Repellat odit sed itaque animi minus. Quia eos similique. Voluptatem aut sit officia illo non error. Et doloremque et ut. Maiores error minima qui quod asperiores perspiciatis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Labore omnis provident ut natus. Aut fuga officiis quia qui deserunt. Hic et id dolorem tenetur explicabo repudiandae ipsam in.\n\nDoloremque non ut. Voluptates accusamus voluptatibus similique. Ad fugiat consequatur esse quia totam. Et quas ipsa. Nulla consequatur doloribus perferendis placeat maiores natus.\n\nDelectus est odit et ut sapiente est perferendis. Sit dolore labore. Et cupiditate nulla eos aut in et.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Sed sunt id quod doloremque natus consectetur eaque. Nulla voluptates maiores vel qui voluptatum omnis et. Unde similique vero. Quo repudiandae corrupti doloribus.\n\nQuia sed nisi ut. Et qui dolores. Ut eveniet dolores impedit maiores. Numquam ut esse quae. Id officiis architecto. Suscipit repellendus minus sequi non ad fugiat.\n\nVel molestias aut. Et assumenda dolore et quae sint mollitia ut aut. Sint qui eveniet quibusdam soluta quas est expedita voluptatibus. Error et iusto.\n\nNulla est accusantium consectetur. Voluptatem non animi minus fuga voluptatem. Sit et qui quia impedit autem et numquam earum. Quo deleniti aspernatur exercitationem aut aliquam illum dignissimos et maiores. Aut nostrum provident. Beatae eum similique sed numquam numquam et.\n\nTempore dolore cumque. Nemo nulla animi hic ea quisquam. Ipsam vel alias adipisci aliquid ut et temporibus aut.\n\nVoluptate sit minima autem voluptate. Quaerat ex est qui aut. Numquam cupiditate fugiat. Minus inventore consectetur sapiente alias autem. Quod sed voluptatibus quia. Debitis facilis aperiam provident possimus aspernatur et reiciendis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "Veritatis repellat magnam delectus quo omnis aut ut recusandae. Quam est molestiae fugiat et sit vel. Labore debitis id inventore et dicta ullam deleniti. Ducimus soluta tenetur aut nesciunt velit nam. Qui dolores odit iure doloribus ut harum sit consequatur labore. Molestiae ea voluptatem et necessitatibus veritatis accusamus non neque eius.\n\nAt perferendis voluptatem illo expedita veritatis laudantium sapiente est recusandae. Qui sint porro earum ullam quia et inventore et. Velit qui voluptas veniam libero nulla.\n\nMinus id sit exercitationem quam magnam numquam quis quos autem. Maiores neque ex fuga cupiditate enim ipsam nihil illum. Dolores et ea pariatur doloribus. Vel enim est. Odio id ut sapiente et et voluptatem. Nam velit non dolorem facilis unde blanditiis.\n\nEveniet aperiam officia est aut delectus iure consequatur repellendus. Reiciendis fuga tempora odit totam. Eos omnis aliquid quaerat qui sunt. Assumenda quis eveniet. Perspiciatis facilis corrupti quam ut facere qui. Provident beatae qui.\n\nRerum sunt necessitatibus optio rerum. Quod itaque nemo laudantium sit. Placeat illum quaerat repudiandae perspiciatis. Nesciunt aut quia est excepturi. Ex velit tenetur iure voluptatem illum. A voluptas vero in nisi quia accusamus ut deserunt.\n\nAccusantium fugit corporis. Molestiae culpa dolores dolorem nam est earum aut eos. Cum consectetur quas. Aliquam in ut quia dolorem libero et magni est. Nostrum nam modi fuga sapiente sit. Earum reiciendis tempora.\n\nPlaceat nulla nulla reprehenderit id asperiores facere repellendus. Nihil magni molestias tempora sed praesentium itaque neque. Optio qui et voluptas aperiam molestiae. Doloribus rerum deserunt eaque quos est doloribus tempore labore aut.\n\nSed tempore nulla. Quia saepe in iure maiores ut. Nostrum debitis aspernatur est omnis voluptatem.\n\nError laudantium voluptatum soluta earum sed est ipsa autem. Qui perspiciatis et atque odit accusantium velit quae odit. Quas animi laborum iure sed ipsam dicta. Rerum qui quos consequatur numquam deleniti asperiores necessitatibus voluptatibus. Ea perferendis et nam doloremque ea fugit quod vel quidem. Saepe tenetur in illo numquam quia omnis nihil voluptatem.\n\nExercitationem vitae optio rerum commodi praesentium id dolor aliquid nisi. Similique in eligendi voluptas molestias molestiae ducimus dolorum voluptatem. Quia et consequatur expedita voluptatibus omnis. Voluptas magni ut. Earum non corporis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Voluptatibus explicabo neque. Velit odio repellat. Quasi et perferendis qui. Culpa reiciendis porro libero. Et voluptatem dolor voluptatem quo quo et veniam.\n\nEst excepturi eaque officiis. Velit eos fugiat rerum illum. Magni velit enim deleniti sit voluptatem.\n\nAperiam et ullam fugit commodi quo. Hic consequatur voluptate quo corporis consequuntur quidem. Quae vero non. Et odio rem laborum ipsum laborum.\n\nIusto qui id. Animi saepe nobis cupiditate sit. Libero iure rem quam perferendis fugit odit fuga. Aut quaerat facilis iusto ipsa eum. Accusamus ut delectus consequatur ut voluptates quos voluptatem aut distinctio.\n\nEst ut est consequatur. Nisi quia distinctio blanditiis iusto iusto aut excepturi cum. Et doloribus vel fugiat adipisci rerum.\n\nCum molestiae eos eius officiis rerum porro. Et eum sapiente neque et quo ratione. Quidem quaerat assumenda quisquam adipisci et ab. Perspiciatis quia molestias minus eos excepturi aliquid omnis autem doloribus.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "Soluta aperiam facilis a et est accusantium qui impedit et. Cupiditate numquam aperiam quidem at libero labore voluptatem aut vero. Quasi iure aspernatur tenetur repudiandae velit rerum. Quia eum enim rerum consequatur commodi. Voluptate adipisci natus ut. Suscipit sed ipsum est est assumenda.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "Quaerat expedita omnis nam unde minima. Ut et neque et aliquam magni impedit consectetur blanditiis minus. Quis eligendi numquam voluptatem est sint dicta odit aut adipisci. Earum quo harum id excepturi tempore magni occaecati et. Possimus dolorum deleniti totam et et.\n\nPariatur vel et tempora at esse dolor id et. Atque necessitatibus maiores aspernatur consequatur illum ducimus. Culpa velit et praesentium inventore pariatur recusandae quia. Voluptas et quam inventore. Voluptatibus aut et assumenda qui id ipsa distinctio omnis in.\n\nNobis et possimus. Dolores molestiae soluta doloribus maxime fugit aut quidem necessitatibus. Quia distinctio alias similique velit.\n\nAssumenda quis quibusdam quasi. Repudiandae velit sit voluptate fugiat. Aut rerum dolorum ipsum quia.\n\nQuibusdam qui quod omnis harum. Rerum autem deleniti fuga iste explicabo officia consequuntur aut. Asperiores mollitia molestiae et blanditiis. Et hic a unde. Impedit incidunt omnis et magni error ea nihil. Ex qui dolor officiis et voluptas.\n\nVero suscipit nulla ducimus dignissimos delectus voluptatem. Quo aut natus ab ut distinctio in placeat quo. Ut sed et et sunt. Ullam tempore consequatur qui quidem aut.\n\nDolorum qui et ut beatae voluptas tenetur laboriosam quam repellat. Earum omnis accusamus. Doloribus blanditiis et similique. Eum ut ut consectetur. Sapiente ut corrupti architecto modi eligendi porro aperiam eaque magnam.\n\nAperiam iure velit blanditiis quo distinctio. Excepturi mollitia repellat reprehenderit et aut. Quia iure explicabo et qui deleniti qui dolores. Sapiente nostrum odio explicabo et atque non eligendi cum.\n\nUnde ut ut id et. Quo deleniti temporibus maiores quod maiores eum. Nam ut veniam. Est aspernatur enim ut aut animi earum fuga. Animi omnis provident quas autem omnis voluptatem vel quo.\n\nHarum illo occaecati ea velit dignissimos provident eum neque. Vero officiis laborum. Sit officia sed odit rem voluptas provident molestiae delectus illum. Quas sit numquam hic soluta.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "Occaecati reprehenderit sit. Ratione alias quia esse aliquam. Blanditiis repudiandae neque et libero aperiam nemo velit molestiae. Et quia beatae culpa expedita qui qui distinctio. Minima consequatur voluptates exercitationem cumque molestias nulla. Qui deserunt praesentium reprehenderit cumque quas omnis facere.\n\nModi consequuntur quasi nisi impedit quasi debitis ratione numquam. Laboriosam consequatur minus enim dolor. Fugiat ratione consequatur. Tempore molestiae dolores dicta porro sit voluptatibus consequatur ipsa. Nisi et iure. Sunt sit sint temporibus.\n\nEt dolore aut id quasi qui. Est aut est. Enim eos quam necessitatibus aspernatur fugiat non.\n\nAut est mollitia provident itaque autem libero. Aspernatur enim sed eveniet. Laboriosam dolorem ut qui laboriosam neque omnis.\n\nVitae nemo harum sint qui sint cumque inventore et dolor. Atque similique illo. Et et dignissimos quod.\n\nMagni id doloremque architecto voluptatem ullam. Deleniti omnis reprehenderit cupiditate quia reiciendis blanditiis ratione incidunt. Consequatur omnis nobis sapiente dolores repellat. Rerum vero recusandae esse adipisci corrupti ut voluptas quis a. Et sed aperiam aspernatur distinctio aliquid adipisci blanditiis. Atque illo aut mollitia velit minus molestias illo qui.\n\nVoluptatem accusantium expedita et. Laborum blanditiis nisi ipsum accusamus. Optio nihil qui et et consequatur sapiente maiores et doloribus.\n\nNon impedit ratione delectus dolor recusandae facere provident et. Qui aut in libero fuga laboriosam delectus necessitatibus laborum officia. Dolor similique quo fugit occaecati voluptas blanditiis architecto eos adipisci.\n\nDolorum magnam quis error fuga labore repudiandae mollitia sunt. Occaecati aliquid qui dolorem nostrum rerum. Qui eaque dolorem. Reiciendis voluptas aut doloribus molestias animi harum aut doloribus. Sunt consectetur sapiente quia dolore deserunt quis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "Veritatis dolores numquam. Commodi natus expedita unde voluptatem omnis sunt at id fugiat. Excepturi ut nihil sunt explicabo est eos. Sed recusandae rerum deleniti corrupti repudiandae pariatur fugit illum ad. Totam sit itaque. Ipsum doloremque nemo.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "Nemo incidunt occaecati deserunt in. Delectus ut fuga ea aut est ut libero autem. Recusandae deleniti qui alias omnis vel qui omnis quia. Aliquid ex ut.\n\nEsse ducimus placeat quam excepturi ut rerum et expedita adipisci. Voluptates non voluptate. Laudantium ea vitae. Tempora accusantium sint sed aperiam laborum dolore nesciunt esse eum.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Content",
                value: "Odit excepturi deleniti explicabo nesciunt quae magni aliquam. Consequatur minima vel aut consequatur aut labore dolores. Itaque eligendi et.\n\nCorporis corrupti itaque architecto ab quos. Consequatur numquam ut. Soluta ducimus veritatis laborum eveniet ipsum vel. Eligendi earum expedita similique doloremque qui.\n\nEius officiis nihil. Qui deleniti molestiae. Possimus reprehenderit et error aut facilis est aspernatur. Fuga doloremque unde et quos.\n\nQuia vel quia quasi voluptatibus amet maxime odio. Quam consequatur nam qui est. Aperiam maxime sed aut. Modi odio maxime sit perspiciatis recusandae eos. Voluptatem aut iste quas quas.\n\nAut voluptatibus sint non a. Nobis ut repellendus quos et ut ut perspiciatis. Quibusdam sequi voluptatum velit totam et ea. Corporis illo adipisci. Voluptatibus sunt explicabo voluptas nam illum et eius accusamus.\n\nEa cumque id error quos voluptates accusantium molestiae consectetur. Repellendus illo inventore natus nobis nulla ad explicabo. Illo illo eius hic corporis voluptatem mollitia eligendi quia. Sit consequuntur consequatur dolores necessitatibus voluptatem. Rerum molestias eum est optio fugit ut aperiam.\n\nFugit voluptatem sit quia animi aliquid voluptatibus sit. Sequi eveniet accusamus et qui est soluta. Incidunt nostrum odit error. Molestiae consectetur soluta consequuntur veniam aut cumque accusamus eum. A libero saepe aliquid voluptatem quis et dolor non.\n\nPariatur laudantium in a porro. Voluptatum fuga consequatur exercitationem eos repudiandae officiis aliquam voluptatum corrupti. Distinctio in ipsum quae ut adipisci quis voluptatum harum amet. Sit qui a consequatur molestiae et qui vel quo. Nihil qui sit vitae doloribus quasi eum animi voluptatem corrupti.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Content",
                value: "Accusamus nulla aliquid ut porro hic non ut quam natus. Non qui aliquam porro. Totam facere aperiam et placeat. Aut architecto aliquam.\n\nMolestiae doloremque ducimus sed est error illo officia voluptatibus minus. Aliquid aut rerum dolore ut in maiores quaerat accusantium aliquid. Est ut molestiae quas sapiente sapiente omnis enim. Mollitia odio beatae maxime et tempora. Ea est ratione.\n\nQuis nobis quos quisquam alias corrupti. Eos accusamus deserunt eius suscipit et. Fugiat aut nobis. Enim quis porro ducimus ut modi rerum quaerat eveniet voluptatem.\n\nAut optio ut perferendis. Et accusamus sed. Tempore eos necessitatibus. Quo excepturi unde. Enim pariatur ut doloribus voluptatibus omnis corrupti quae.\n\nVel rerum ipsam. Molestias consequatur autem omnis porro omnis possimus atque provident. Eveniet et perferendis id architecto. Excepturi alias est tempora.\n\nIn labore placeat voluptatem tempore facilis quos aut eum. Corrupti similique molestiae aperiam. Nam non reiciendis nesciunt quibusdam. Voluptatibus est aliquid aliquam deleniti dicta repellat ipsam libero. Nesciunt debitis tempore magnam sit temporibus. Repellendus cupiditate officia quis quo.\n\nEt tenetur voluptatum culpa commodi accusantium adipisci dolorum eligendi sed. Doloribus in atque dolorem doloremque. Quos vel optio et voluptatem maiores ipsa tenetur deserunt. Voluptas eaque aliquam tempore rem. Ea doloribus ea aspernatur nihil molestias dolore porro. Molestiae commodi quidem est est aut corrupti suscipit fugiat dolor.\n\nBlanditiis aliquid qui ut laboriosam earum aut. Dolor quis et provident cum porro dignissimos. Voluptatem earum incidunt eligendi voluptate et. Sit temporibus repellat ut expedita nobis deleniti.\n\nNecessitatibus aut omnis beatae est earum recusandae. Soluta laborum ea quos nam facere quo maxime. Ut rerum velit omnis velit. Quia quos laudantium similique consequatur.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WikiName",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logo",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FooterListTextColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FooterListLinkTextColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FontFamily",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BodyColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleRightInnerColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleRightColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ArticleColor",
                table: "Styles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Content",
                value: "Dolore magni aut voluptatem dolor architecto est rem quia. Provident maxime quia qui et maiores rerum impedit. Dolorem sed explicabo et perspiciatis rem rerum sint. Tempora vero quaerat fuga incidunt nobis nam sequi rem quasi.\n\nRatione at quia qui. Consequatur occaecati iste occaecati consequatur occaecati. Minus ullam reiciendis voluptatem facilis consectetur veritatis eos id. Delectus sapiente accusamus beatae ea inventore.\n\nUt sapiente porro soluta aliquid sit sequi est. Laboriosam velit itaque qui ea aut a et blanditiis. Sunt autem omnis occaecati ex illo est non voluptas odit. Ex quo vitae sed rerum sapiente. Deleniti est dolorem.\n\nDistinctio possimus odit cupiditate culpa excepturi autem. Expedita ipsam voluptatem est eum deserunt sequi. Qui sit quia eum doloribus nobis inventore qui officiis magni.\n\nMolestiae unde ipsum vel vero nihil cumque ut quia. Cupiditate cumque eius iure eum blanditiis consequatur. Aliquid veritatis autem qui est. Ut quia libero vero distinctio suscipit.\n\nAb sapiente in. Soluta perferendis aut deserunt quam qui autem quas ducimus. Temporibus vel rerum molestias aspernatur ea. Tempora sit enim rem quis modi. Veritatis ex natus eum in dolor et nihil modi vel.\n\nIllum blanditiis reiciendis error aut nisi. Expedita rem adipisci aliquam fugit voluptatem. Quasi temporibus veniam nihil et rerum recusandae reiciendis pariatur. Quia assumenda rerum. Velit porro quia aut quibusdam nisi eum totam est enim. Autem cupiditate sit autem.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Content",
                value: "Velit fugit et. Ullam exercitationem aut earum delectus perspiciatis itaque aut perferendis. Voluptatem quia molestiae perspiciatis et totam optio. Molestiae non optio veritatis nihil ducimus. Vel qui at voluptate quo quia quisquam et pariatur.\n\nItaque qui vel harum illo dolore. Cupiditate vitae non alias id accusantium. Distinctio aut quis quos. Quia omnis quam. Quos doloremque ipsam aliquid.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                column: "Content",
                value: "Unde optio a et alias quia qui. Voluptas repellendus quia incidunt. Quo sint et voluptas modi.\n\nAtque adipisci voluptatum occaecati. Possimus labore quisquam eum exercitationem voluptatem est. Est amet minus alias qui facilis sint. Ab beatae placeat et voluptates qui deserunt veniam. A ut explicabo sed et mollitia libero. Cumque perferendis eaque ut.\n\nVitae ab rerum ab minima sit fuga nostrum iure. Sed animi nostrum modi mollitia facilis ea aut. Temporibus dolor cum assumenda quo. Consequuntur voluptates reiciendis nobis et est possimus repudiandae et.\n\nAutem omnis ipsam corrupti exercitationem dolor porro magnam. Quasi dolores beatae eos molestias accusamus soluta. Neque tenetur quos sint aut ad blanditiis atque dicta.\n\nQuos sit consectetur iusto aliquam. Optio molestiae sunt eum autem et eos. Rem omnis autem fugiat minima quia porro.\n\nPossimus eum dolorem. Et maxime voluptatem unde architecto et. Alias distinctio beatae qui.\n\nAut temporibus dolorem. Molestiae et veniam aut repellat et ipsum. Aut quo non dolor magni sit. Dicta ducimus molestiae adipisci enim dolores aspernatur totam provident nobis. Quis qui est officia minus voluptatibus molestiae magnam.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Content",
                value: "Illum iure ut exercitationem dolores repudiandae consequatur fuga. Voluptatem totam quisquam ratione dolorum aperiam quasi facere ut. Voluptatum molestiae qui consequatur sapiente fugiat et voluptas. Accusantium et voluptas ut rerum fuga voluptas beatae ut.\n\nEos animi error maxime rerum modi incidunt non consequatur dolorem. Tempore illum est non et amet. Aut nostrum nesciunt nostrum. Quo exercitationem dignissimos deserunt ut ut provident dolorem qui. Non atque soluta dolore rem beatae expedita aliquid nobis. Molestias eum tenetur consequuntur aperiam tenetur in similique dolorem.\n\nIllo minus accusantium placeat assumenda quisquam tenetur error voluptatum repellendus. Officiis est ipsa quia id. Nesciunt veritatis est sunt amet laborum voluptatibus in. Magni porro et deleniti magnam temporibus. Hic ipsa est.\n\nMolestias natus ratione ipsam harum. Accusantium nemo error sunt. Molestiae nesciunt quaerat aut dolorum sequi dolore debitis vel. Quo dolorem molestiae optio. Eum eligendi ipsa aut facere.\n\nSapiente laudantium quia facilis perferendis vel nesciunt ut dolore. Qui non beatae hic hic laboriosam ullam voluptas earum. Doloribus cum enim hic rerum nam quo deserunt sed.\n\nExcepturi placeat itaque tempore. Aut quo animi nam dicta velit. Ratione quos quia possimus adipisci nam non voluptatem iure.\n\nConsequatur magnam aspernatur voluptatem fugit expedita aut. Sunt non cupiditate ea officiis autem voluptas impedit exercitationem. Sint soluta aut quidem consequuntur nemo sit earum. Non veritatis similique mollitia iste. Soluta et distinctio reiciendis rerum provident et facere. Nostrum quisquam quia explicabo.\n\nItaque quaerat nulla. Blanditiis animi fuga dolor expedita. Et perspiciatis ut omnis quas beatae officiis commodi ut rerum. Hic dignissimos est porro corporis. Est vel quis delectus et est veniam dolorem. Autem debitis inventore nostrum quia distinctio.\n\nEst vel architecto soluta. Molestiae error optio provident rerum facilis aut. Eos et iste aut aut similique fugiat ut mollitia. Id dignissimos asperiores et quae et eius qui magnam veritatis. Tenetur aut velit et qui. Rerum sunt ullam impedit labore non autem.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Content",
                value: "Vel ex ipsam iure. Ipsam enim sit. Voluptatum quibusdam iste repellat et deleniti voluptatem ipsum officia laboriosam.\n\nUt ducimus optio asperiores veniam est at voluptatem. Doloribus molestiae in minima vitae. Alias vel repellat culpa aut iure. Odit sed ullam enim corporis veritatis numquam. Veritatis enim fuga officia.\n\nMinima accusamus qui. Eius unde ut omnis commodi. Eos in incidunt pariatur ipsa soluta.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6,
                column: "Content",
                value: "Voluptas sint reprehenderit. Consectetur nam fugit enim ab officia explicabo fuga. Illum et id nobis iure odio voluptates qui velit aut.\n\nRepellendus iure doloribus officiis. Maxime voluptatem veritatis qui ex explicabo aperiam. Magni hic omnis laudantium minima quis placeat. Dolorum et reprehenderit necessitatibus sed necessitatibus. Deserunt accusantium suscipit omnis vitae repudiandae pariatur ut provident sunt. Rem consequuntur in qui quisquam possimus ut fugit iste aut.\n\nEnim sit quibusdam consequatur exercitationem temporibus tempore magni totam. Esse eaque voluptatem. Dignissimos adipisci et. Dicta omnis voluptatibus impedit a numquam cupiditate ut. Blanditiis perferendis laboriosam illo fugit nemo ipsa quia ullam eum.\n\nNihil dolor distinctio ut sunt modi delectus. Et laboriosam magni aperiam quod molestiae culpa qui eius. Molestiae consequuntur est facilis error nemo et sint. Placeat corporis quaerat ullam nesciunt sed sint. Ut enim corporis. Ut est quae aut.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7,
                column: "Content",
                value: "Officiis delectus numquam. Id odit voluptas et necessitatibus. A vel perferendis sed omnis aspernatur.\n\nDistinctio reprehenderit et nihil placeat rerum facere. Minima aliquam consequatur nesciunt qui eum magni velit. Voluptas praesentium et quaerat maiores earum voluptatem optio voluptas odio.\n\nNesciunt voluptatem nulla voluptatum debitis voluptate. Asperiores et voluptatum enim dolore consequatur eum sapiente labore est. Non repudiandae maxime adipisci. Itaque et sint quis. Voluptas neque sint voluptas minima a itaque. Et amet enim delectus odio nostrum et ut vel.\n\nCum porro molestias rerum architecto consequuntur expedita. Et et qui necessitatibus. Voluptatem tempora minus cupiditate asperiores aperiam doloremque illum. Aut et illum quia ullam cumque et. Et et excepturi voluptates aut in et ex. Quidem consequatur nihil repudiandae sed.\n\nUt deleniti repellendus illo corrupti blanditiis quibusdam. Doloremque voluptatem officiis incidunt non. Rerum commodi perspiciatis cupiditate velit unde. Et dolorum aut voluptas rerum impedit commodi veniam. Et facilis possimus ipsa omnis omnis ut et omnis totam.\n\nLibero dolorum nihil dolorum et dignissimos eos dolorem blanditiis possimus. Consequatur veniam at ipsa. Debitis nostrum ratione nihil. Ut id et. Est at eius voluptates.\n\nLibero sed velit. Quia consequatur illo. Atque dolor enim. Voluptas molestiae tempore quia pariatur placeat amet voluptate. Molestiae assumenda delectus ut.\n\nQuas veniam ex ipsam. Et corporis ducimus mollitia molestiae harum. Id est et. Explicabo non dolorem et quis et doloremque et.\n\nBlanditiis mollitia ab similique amet. Nihil voluptas magnam ad corrupti eaque. Velit fuga reprehenderit ratione quidem.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8,
                column: "Content",
                value: "Est est illum saepe aut accusantium fugiat. Reprehenderit exercitationem quasi corporis tempora. Quo adipisci blanditiis recusandae possimus veritatis reiciendis unde at.\n\nVoluptates iusto soluta ut tempora quidem impedit repellat amet tempore. Eos delectus quaerat est omnis iste voluptates facere et. Qui maiores dolorem et. Rerum facilis et dolor earum a. Fugit nobis sint et sit fuga.\n\nMolestiae molestias ipsam qui. Corrupti voluptatem voluptatem quo. Ea dicta et ratione voluptatem quasi sit natus hic. Eaque sapiente nostrum et quisquam quas maxime accusamus qui. Reprehenderit autem occaecati. Eum odit ea tempore pariatur non.\n\nAccusamus nisi occaecati earum et et soluta ut. Cumque et repellendus iste laboriosam labore eos. Quia esse maxime ex aliquid.\n\nNulla repellendus vitae consequuntur. Officia eos nobis ut facere. Magni in consectetur exercitationem ipsum sapiente exercitationem et laborum voluptate. Culpa et nulla. Natus odit corrupti dolorum doloribus odit ipsa blanditiis itaque voluptatem. Perferendis labore eum cupiditate aut aut sit occaecati.\n\nId facere sapiente. Doloremque aut est. Quia laborum facere laudantium aut eos minima quas cum aperiam. Exercitationem earum dolores eum odit tempore nemo occaecati.\n\nEt doloremque quam commodi suscipit quia modi odio id. Minima esse placeat totam est. Alias dolores commodi iure voluptatem alias ut voluptatem. Omnis dolorum laboriosam ex quasi.\n\nSed eligendi architecto reprehenderit sunt. Itaque praesentium molestiae voluptate facilis beatae. Delectus omnis cum harum laborum voluptate quo fugiat. Ratione excepturi nostrum nesciunt quidem laborum sed id ut. Veniam voluptate natus ipsa laudantium quidem nam quas.\n\nEt corporis soluta est fugit odit eos quia. Nihil non voluptatem fuga voluptates. Qui dolores architecto dolore quae repellat quam saepe. Ut exercitationem unde. Consectetur esse quod voluptas doloremque autem. Esse laudantium consequatur eos unde.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9,
                column: "Content",
                value: "Corporis ducimus excepturi magnam sint illo ullam sit animi. Veritatis earum nobis saepe ullam quo voluptatem consequuntur ipsam rerum. Veniam autem molestias similique sit dolor corporis. Rerum ad quis error aperiam ratione nisi ea non.\n\nInventore cupiditate sunt qui accusantium. Rerum distinctio sunt sit maiores assumenda. Explicabo est culpa dolorem necessitatibus veritatis nulla et.\n\nQuo placeat et fugiat tempora. Et dolores magnam rerum vel. Recusandae omnis provident eligendi cumque minima ratione est voluptas.\n\nQuia eum eum voluptatem qui dignissimos. Explicabo iste sapiente. Hic et iure et labore aut id optio tenetur provident. Eligendi delectus magnam et consequuntur soluta officia. Cum quae est similique ut exercitationem vel sint quo. Id dolor dolor aut assumenda nisi laudantium dolorem enim non.\n\nQui velit dolore fuga et voluptatum. Blanditiis similique exercitationem eos incidunt commodi vitae similique. Et non aliquid sit. Animi dolor sint enim. Alias sunt aliquid velit eaque. Voluptatum nulla eveniet voluptas dignissimos repudiandae veniam rem illo quia.\n\nIpsa et repellendus ducimus commodi voluptatem cumque a dicta. Autem rerum blanditiis quis hic. Vero quia tenetur quo porro quisquam molestiae et. Omnis tempora minima voluptatem iusto dicta quod.\n\nCumque optio officia dignissimos sit aut id velit. Quibusdam incidunt architecto beatae sint. Et et illo doloribus. Delectus enim similique quos quo non sit fuga. Provident ea et voluptatum.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10,
                column: "Content",
                value: "Nulla vero debitis veritatis omnis. Omnis harum quis et quis exercitationem accusamus esse incidunt et. Quasi quia magnam incidunt. Amet aspernatur maiores vel magni.\n\nSed suscipit quod at. Sit est enim in repellendus quo. Atque qui non a unde est sequi repellat non doloremque. Nesciunt accusantium et quis harum optio accusantium perferendis.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 11,
                column: "Content",
                value: "Perspiciatis quia molestiae placeat ducimus ea est minima. Eos quam libero dolor nisi saepe et ducimus nobis. Laborum magni quam itaque eveniet distinctio assumenda id ratione dolores. Magni rerum illo ad. Veniam tempora rem placeat sint eaque quia non vero. Accusantium laudantium ut est maiores voluptatem totam nisi.\n\nRerum libero perferendis. Qui minima dolorum delectus laborum qui. Sunt ab non qui. Molestiae iste consequatur qui esse perferendis qui. Iure hic adipisci consequatur illum sunt laboriosam. Aut numquam doloremque quidem nihil repellendus vero veritatis.\n\nCorporis dolorum in. Neque alias dolores qui distinctio ipsa. Dolore error consequatur dolore et eos sunt qui.\n\nLaudantium architecto dignissimos ut. Et dolorum soluta tempore magni quasi accusantium. Perspiciatis est nam tenetur et accusamus. Quisquam culpa ad consequuntur in id praesentium sed quo.\n\nSapiente omnis sapiente assumenda eos in laboriosam commodi ut maiores. Voluptas fugiat rerum dolore aliquid in officia. Repudiandae qui velit.\n\nEt eos sit qui molestiae et explicabo nobis quos. Id iusto nostrum harum harum doloribus. Ut consequatur sit et fugiat temporibus autem. Non non nam optio laudantium culpa harum mollitia esse. Qui aperiam quia non labore iure reprehenderit occaecati ut praesentium. Ratione et atque.");

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 12,
                column: "Content",
                value: "Iusto beatae nesciunt et aut quibusdam debitis vel dolores nihil. Ullam accusamus corrupti est quaerat. Possimus ut sit quis officia commodi sint et ut nesciunt.\n\nVoluptatem aut a. Beatae quo et quis. Blanditiis vel et. Rerum laboriosam est deleniti est eos distinctio ipsum vel. Amet qui laborum voluptas illum ullam. Ipsum ipsa et eaque pariatur omnis delectus inventore nihil enim.\n\nAut neque eos repellat alias est possimus et et. Adipisci animi itaque occaecati quos enim. Eligendi aut aperiam aut ea et quia rerum. Nihil eligendi nesciunt mollitia delectus deserunt aut. Placeat ipsum nihil blanditiis eius facilis.\n\nQuibusdam impedit impedit vitae eius perferendis. Accusantium quisquam sit unde iusto iste. Quis voluptatem pariatur quidem iure aperiam. Earum architecto quam. Et quia quia numquam rerum dignissimos consequuntur.\n\nIpsa cumque eligendi. Facere eius maxime dolores. Eos fugiat necessitatibus adipisci eos omnis sed officiis et. Perspiciatis minima vel dolor.\n\nImpedit accusamus architecto deserunt eveniet quod. Et occaecati voluptatem magni ut. Sed odit quae in incidunt corporis assumenda et rerum.\n\nQuaerat minus ut in aut autem quam itaque non quod. Magnam ut veritatis eum maiores fugit non est laboriosam omnis. Et occaecati et. Culpa ipsa minus laboriosam eius ipsam ipsum officiis. Velit voluptatem assumenda inventore perspiciatis eum. Incidunt et ut neque iure et debitis recusandae.\n\nIpsam et odio voluptate sunt. Aut voluptatem aut voluptatibus laborum ipsa assumenda reiciendis. Ex dolore cumque necessitatibus recusandae. Nobis quos architecto quis quisquam recusandae ipsum id omnis provident.\n\nQui cupiditate et et soluta. Quibusdam omnis et sunt labore corrupti ut. Blanditiis accusamus voluptatem pariatur vitae omnis asperiores ullam commodi rerum. Labore dolore autem quod. Nulla qui dolores cupiditate dolor molestiae illo consequuntur.\n\nA harum velit nihil soluta maiores reprehenderit. Suscipit sit corporis quis doloribus qui. Molestiae aut aut facilis commodi.");
        }
    }
}
