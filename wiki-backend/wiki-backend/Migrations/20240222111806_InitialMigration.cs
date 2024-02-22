using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WikiName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BodyColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleRightColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleRightInnerColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArticleColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterListLinkTextColor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FooterListTextColor = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WikiPages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteSub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WikiPageId = table.Column<int>(type: "int", nullable: true),
                    SubmittedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Approved = table.Column<bool>(type: "bit", nullable: true),
                    IsNewPage = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WikiPages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WikiPages_WikiPages_WikiPageId",
                        column: x => x.WikiPageId,
                        principalTable: "WikiPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WikiPageId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParagraphImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ParagraphImageText = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paragraphs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Paragraphs_WikiPages_WikiPageId",
                        column: x => x.WikiPageId,
                        principalTable: "WikiPages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "ArticleColor", "ArticleRightColor", "ArticleRightInnerColor", "BodyColor", "FooterListLinkTextColor", "FooterListTextColor", "Logo", "WikiName" },
                values: new object[] { 1, "#526cad", "#3c5fb8", "#2b4ea6", "#507ced", "#1d305e", "#233a71", "/img/logo.png", "Your Wiki" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Discriminator", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { 1, "WikiPage", "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" },
                    { 2, "WikiPage", "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { -12, "Soluta qui et aut aut vel ea neque. Libero placeat eos. Voluptatum maxime maiores quod aut eos molestias. Qui qui ea voluptas aspernatur in aut architecto ad. Vitae debitis veritatis quis. Aut rerum perspiciatis earum ut ratione quo reprehenderit.", null, null, "Example Page 2 - Paragraph 6", 2 },
                    { -11, "Aspernatur ipsum quas. Eligendi qui consectetur deserunt pariatur tenetur non rerum. Maiores doloremque doloribus aut expedita voluptate modi animi. Fuga similique fugit veniam maxime id mollitia nemo dolorum et. Recusandae placeat quidem. Quae eos cum veritatis voluptas tenetur natus.", null, null, "Example Page 2 - Paragraph 5", 2 },
                    { -10, "Ad fuga quia ad. Amet nostrum fugit quos corrupti doloremque non consequatur. Iure omnis ut blanditiis. Rerum vitae nulla eos autem aut iste dolorem. Similique et libero.\n\nAut veritatis ipsam perspiciatis nam et accusantium qui vero. Voluptatem laudantium tempore quo ea velit. Molestiae sed autem voluptas molestiae nihil error quidem aspernatur. Qui non est magni facere et numquam. Quo veniam et delectus delectus consequatur sunt nobis.\n\nVoluptate incidunt qui ad et. Perspiciatis fugiat debitis esse. Occaecati officia praesentium amet iste. Enim dolor corporis exercitationem dolorem adipisci adipisci sit cumque sit. Non quidem est eos enim non omnis aliquam est.\n\nMollitia quis in deleniti enim tempora amet labore. Autem voluptatem ut adipisci deleniti ex id porro. Blanditiis sit sapiente accusantium incidunt non eaque consequatur iure iusto. Et quod alias consectetur autem optio ipsum earum sit voluptas. Rerum similique ut vitae autem placeat quam.\n\nOmnis debitis alias occaecati. Temporibus voluptate et aliquam sequi dolor sed est nulla. Molestias corporis officiis blanditiis.\n\nMagnam labore totam. Adipisci fugiat optio maxime ipsam quia in. Aut nesciunt assumenda natus odit. Illo qui earum non asperiores molestiae repudiandae ab mollitia tempora. Corrupti qui aliquid occaecati nobis voluptatem ea quia quae. Velit sit molestiae perspiciatis corrupti aut sequi.\n\nAut aut ea sint vel molestiae et. Accusantium suscipit dolor aliquam blanditiis laudantium laudantium vitae laborum. Omnis dolorum accusamus veritatis reprehenderit quis.\n\nAut iste qui aliquam autem amet autem dolor harum rerum. Ad cum quia quibusdam. Ea excepturi amet minima voluptas. Vitae qui consequatur aut hic perferendis consequuntur eum labore.\n\nSed cumque ut quis est necessitatibus corrupti vitae. Maxime quia amet. Facere sapiente est qui aut aperiam. Quod aliquid quis quasi porro vel sit natus quisquam sint.\n\nRem sed quibusdam necessitatibus vero consectetur et ipsum voluptatibus consequatur. Provident enim sint. Debitis vel eum eaque veritatis perspiciatis quia cum.", null, null, "Example Page 2 - Paragraph 4", 2 },
                    { -9, "Et quae blanditiis eveniet ut voluptatem. Illum eum perspiciatis ea magnam laboriosam voluptatem. Vel aliquid qui eum velit et sunt magni consectetur.\n\nEum facere dolor dolorem ut architecto nemo nam adipisci. Non eius iusto aspernatur culpa. Dicta ratione veritatis velit sed voluptas. Consequatur laudantium dolorem. Quibusdam autem recusandae nemo est nam natus.\n\nDebitis ea et. Esse libero tempora minima nihil dignissimos iure laborum officia. Id omnis cumque. Recusandae velit et est fugit cumque voluptas.\n\nNon consectetur rerum vero perferendis. Placeat atque magni nostrum minus odio voluptas. Sequi sed ad nostrum illo dolore. Omnis libero in voluptates ea nobis ut. Facilis sit id dignissimos omnis eum at mollitia. Eos voluptatibus molestias temporibus rerum placeat occaecati officiis inventore.\n\nEst at quia iste. Quo nam recusandae molestias. Corporis dolorem et sed excepturi dolor ea ut sit.", null, null, "Example Page 2 - Paragraph 3", 2 },
                    { -8, "Et repudiandae quidem voluptas. Provident et consequatur voluptas aliquam nihil ipsam ut. Optio porro in vel.\n\nVoluptatibus dolorum possimus harum magni optio suscipit velit. Deserunt blanditiis accusantium qui itaque in. Tenetur a dolore quasi numquam animi qui est.\n\nVoluptatem sed nobis sed illum occaecati porro et nulla. Qui dolor inventore deserunt. Consequuntur ipsa animi quod. Maiores pariatur natus aliquam assumenda et dolorem quo. Occaecati assumenda natus.\n\nAperiam totam commodi qui quidem quia est recusandae in. Repudiandae esse et. Laudantium necessitatibus dolorum numquam quia quasi aut aut inventore. Qui nostrum nam dolorum. Ut dolores beatae ea. Ab iste ad fugit consequatur enim nobis.\n\nUt esse non delectus delectus. Ratione fugit quibusdam atque. Nihil corrupti quae voluptatem quia voluptatibus aut voluptatem ut id.\n\nDeserunt laudantium numquam possimus laborum rem rerum deserunt aut quos. Praesentium corporis error repudiandae similique veniam et aspernatur natus doloribus. Necessitatibus fugiat quidem. Aut hic et hic possimus in et.", null, null, "Example Page 2 - Paragraph 2", 2 },
                    { -7, "Eos deserunt laudantium repellendus est itaque ut. Qui voluptas voluptas sint. Quaerat iste libero et dicta voluptatem nam est.\n\nCorrupti exercitationem vel eum tempore suscipit quia eveniet. Et quia cupiditate ab voluptates. Qui fugiat ratione impedit non. Molestiae dignissimos animi esse enim at ab eum.\n\nNesciunt rerum aut ea. Natus atque sint repellendus voluptatem. Amet harum corporis quia ullam ad molestiae eum et est. Ducimus facilis dignissimos minima doloribus officia.\n\nMollitia tempore dolores cupiditate dolore. Aut accusantium commodi error. Est suscipit ut velit non sunt culpa consequatur. Assumenda at sit ea odit. Repellat distinctio eaque quod inventore voluptatem eveniet recusandae.\n\nMaxime ut et architecto ullam aut quisquam. Ea hic debitis et qui quis temporibus necessitatibus nemo. Fuga est non omnis. Accusantium ex veniam et reprehenderit repellat voluptatibus. Sit velit velit incidunt fugit ea veritatis voluptate. Molestias esse similique quas qui iste quia qui commodi.\n\nEos accusamus eligendi consequatur cupiditate consequatur et voluptatem. Nam laborum dignissimos. Dicta et voluptatem ex aut aspernatur sed.\n\nUt sit quis sit. Dolorem animi atque provident. Alias ut ut molestias illum velit architecto. Vel minima velit explicabo. Quia in laborum. Et deserunt qui.\n\nBeatae aut aut cupiditate iste placeat praesentium unde cum debitis. Et sed nulla autem. Pariatur qui unde natus impedit veritatis voluptas. Vel quia et quia corrupti officia. Corporis est quo.\n\nPorro inventore maxime ratione nesciunt ut nihil inventore eaque. Ab occaecati quas. Molestiae debitis minus voluptates qui soluta.\n\nOdio dolorem dolorem suscipit sit. Mollitia et voluptatem. Autem quia vitae aut numquam voluptas incidunt pariatur. Necessitatibus sed autem est et deleniti. Dicta occaecati et natus et voluptatem temporibus fuga sunt.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", 2 },
                    { -6, "Atque laboriosam quo. Corporis suscipit aut ut nostrum. Veniam recusandae voluptas repellat itaque. Iste dolor blanditiis hic numquam omnis qui esse.\n\nQuod est et. Iure minus sed ullam aspernatur est voluptas quae. Sit quisquam ut. Eos minus rem qui. Ut velit et nostrum qui ipsam velit consectetur. Sapiente distinctio voluptatibus asperiores voluptatem quas magnam.", null, null, "Example Page 1 - Paragraph 6", 1 },
                    { -5, "Quia libero iusto. Voluptate non asperiores maxime soluta impedit. Alias ut labore iste aut eligendi veniam eum id dolorum. Iusto nam distinctio exercitationem. Quaerat et dolorum. Atque nobis nam alias magni.\n\nMagnam illo qui dolore eligendi dolores expedita sequi itaque. Nesciunt non voluptatem neque vel doloribus eos. Sit soluta alias est tempore molestiae distinctio.\n\nRepellendus excepturi quisquam. Magni sunt accusantium. Molestias consequatur omnis sunt. Est adipisci enim laudantium laudantium aliquam. Dolores rerum maxime cum esse consequuntur aut ut pariatur.\n\nVeritatis tempore ut nisi ea occaecati. Dolorem omnis neque eius laudantium quod. Rerum veniam eveniet ullam ducimus et.\n\nAccusantium in nesciunt et natus quas eos quas odit sit. Temporibus et omnis odio. Non dicta exercitationem ipsam quae sed autem ut et. Deleniti nobis voluptate porro aliquam commodi. Ut quia ut corrupti est molestiae voluptatem deserunt quam quo. Dolore eius accusamus eos et mollitia dolorem ullam.", null, null, "Example Page 1 - Paragraph 5", 1 },
                    { -4, "Ab aut distinctio porro ipsa sequi ducimus. Repellendus perferendis libero ut at ea laboriosam fugiat. Molestiae architecto aliquam mollitia. Ipsum sit amet eos similique dolor qui sapiente. Debitis numquam distinctio.\n\nEarum tempora sit molestiae autem autem qui. Aut et ipsum aperiam quia. Facere vel voluptates. Ratione ut et quia assumenda magnam numquam hic. Ipsam est quia ipsa recusandae quia placeat excepturi. Sed totam facere debitis qui expedita magnam est.\n\nQuas est quasi non voluptatem doloribus. Aliquam dolor voluptatem ad aliquam ex quod nulla. Id harum cum eveniet inventore. Ut assumenda aut delectus nemo aut enim.\n\nDolorem eveniet ad ipsam est dolorum. Dolorem cum quas asperiores optio rerum deserunt sint quidem. Dolor rerum nam qui. Cumque aliquid qui sit.", null, null, "Example Page 1 - Paragraph 4", 1 },
                    { -3, "Est culpa laboriosam nihil architecto at voluptatum. Soluta cumque voluptatem. Qui voluptatibus exercitationem. Deserunt aut sint in molestias praesentium aliquid ut est alias.\n\nPossimus eligendi exercitationem illum. Ratione quas ullam rerum doloribus labore animi quo. Corporis alias et.\n\nArchitecto maxime id voluptatem. Magni tempore fuga doloremque cumque nam iure. Enim ullam qui enim esse ipsa debitis delectus atque ut. Cum qui quia omnis vero omnis vitae voluptatem pariatur.\n\nOmnis placeat aut ipsum. Porro fugit quae dolorem id molestiae fugiat. Aut cumque molestiae architecto molestiae omnis. Ut corporis dolores velit occaecati maiores at.\n\nConsequuntur laboriosam repellendus dolorem temporibus eum quas. Quo itaque repellendus commodi corporis facere aut et tempora. Fugiat unde natus odio. Doloremque adipisci qui labore ullam. Sint rerum cupiditate alias nulla culpa exercitationem eos cupiditate soluta.\n\nQui fugiat et et aut cum alias. Quisquam neque alias quas possimus quos quis id consequatur. Ut eos voluptatum cum reprehenderit ad. Et quod pariatur consequuntur cupiditate sed deleniti dicta perferendis. Tenetur quidem qui repellat. Doloremque dignissimos fugiat natus soluta quo aut ipsa non.", null, null, "Example Page 1 - Paragraph 3", 1 },
                    { -2, "Odit fugit velit voluptatem odio labore dolorem et vero. Sapiente error expedita voluptatem ut et et animi officia. Autem quas minima aliquid omnis cumque quaerat.\n\nNon est nihil maiores voluptatem dolores accusamus voluptatem quia sequi. Velit est quia aspernatur ipsa est saepe error quis. Nobis reprehenderit eos non architecto. Ducimus molestiae placeat pariatur exercitationem odio ut corrupti illum. Quas vel fugit repudiandae vel fugit cupiditate commodi. Dolorum ex minus laborum praesentium aut voluptatem.\n\nDolore amet ipsam quos ea aliquid. Minima mollitia ut. Libero ab qui quo.\n\nEsse nemo fuga. Et eius eos. Perspiciatis dolores possimus veritatis dolorum deserunt error. Assumenda vitae culpa non sunt quo nobis praesentium tenetur minus.\n\nConsequatur et nihil et sed eum illo labore quia. Et et a temporibus. Ducimus voluptas quae dolore temporibus culpa.\n\nNatus nulla sit voluptatem ut nam aut similique sed illum. Libero cupiditate mollitia et voluptatem error quia. Voluptates quam quo nisi. Placeat quia nihil voluptatem ut aut quo id est. Aut id tenetur iusto in consectetur esse laudantium aut error. Nisi velit et voluptas saepe.\n\nConsectetur illo iusto. Illo ut enim sint. Cum facilis aut at quidem nesciunt et officia. Officiis ut cupiditate iste non. Accusantium quo blanditiis. Et omnis ratione id eligendi sunt omnis perspiciatis distinctio reprehenderit.\n\nA vel ad qui voluptas veritatis. Quia deleniti magnam sit explicabo vel accusantium repellat commodi. Sed dolorem pariatur repudiandae iusto voluptate ut. Eligendi dolorum iure perspiciatis velit iure atque facere dolorem ut. Totam nobis eum odit molestiae.\n\nNulla tempora placeat enim occaecati quidem similique eius sint. Autem modi asperiores mollitia non. Eius aut eos repellendus sed sit numquam ea debitis.", null, null, "Example Page 1 - Paragraph 2", 1 },
                    { -1, "Est consequuntur voluptate vel libero repudiandae reiciendis. Reprehenderit quia tenetur accusamus ut similique nihil voluptatem veritatis. Et labore reprehenderit ducimus placeat illo ipsum animi nemo atque.\n\nSimilique voluptatibus et doloremque neque laborum ut quas consequatur sed. Repellendus asperiores ut consequuntur voluptas illo eius dignissimos ad dolore. Optio quasi optio quas aut. Totam velit reprehenderit. Alias ipsum sunt dolorem exercitationem.\n\nNon sequi laborum facere. Adipisci aut quae cumque vel ut in. Porro recusandae autem explicabo. Placeat consequuntur omnis ad rerum nostrum vel voluptatem voluptas adipisci. Omnis sequi quasi. Quibusdam sequi architecto consectetur dolor est deleniti aliquid.\n\nIllo odit dignissimos fuga. Eligendi et et aut harum odit libero aut quidem quo. Non eos sunt illum atque pariatur quaerat. Aut culpa architecto laboriosam nihil perferendis. Enim nisi eum modi porro expedita. Qui impedit voluptas sed iste exercitationem adipisci maiores illo.\n\nVeniam optio impedit consequatur quia et et aliquid. Molestias illo adipisci autem repellat quidem est quisquam. Hic ab cum. Et sapiente delectus at voluptas. Cupiditate rerum quia.\n\nConsequatur odio est est. Nihil error numquam molestias pariatur excepturi. Occaecati esse laborum sunt voluptatem vel et animi consectetur. Autem aliquam quae dignissimos sint voluptas quis. Numquam necessitatibus expedita nulla.\n\nNulla illo unde repudiandae nulla. Rerum earum cupiditate ut. Pariatur est eaque porro atque sed natus ut. Recusandae quis esse optio minus consequatur ut delectus.\n\nProvident dolores qui qui. Voluptates nemo facilis aspernatur cumque vel quas porro. Eveniet eum asperiores inventore accusamus repellendus ut tenetur. Aliquam et voluptas qui sit.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paragraphs_WikiPageId",
                table: "Paragraphs",
                column: "WikiPageId");

            migrationBuilder.CreateIndex(
                name: "IX_WikiPages_WikiPageId",
                table: "WikiPages",
                column: "WikiPageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Paragraphs");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WikiPages");
        }
    }
}
