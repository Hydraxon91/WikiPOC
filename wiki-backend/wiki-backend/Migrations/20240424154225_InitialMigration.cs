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
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BodyColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleRightColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleRightInnerColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ArticleColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterListLinkTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FooterListTextColor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FontFamily = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WikiPages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SiteSub = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleNote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LegacyWikiPage = table.Column<bool>(type: "bit", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WikiPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_AspNetUsers_UserProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Paragraphs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WikiPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WikiPageId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    ReplayToCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_UserComments_ReplayToCommentId",
                        column: x => x.ReplayToCommentId,
                        principalTable: "UserComments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserComments_UserProfiles_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserComments_WikiPages_WikiPageId",
                        column: x => x.WikiPageId,
                        principalTable: "WikiPages",
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

            migrationBuilder.InsertData(
                table: "Styles",
                columns: new[] { "Id", "ArticleColor", "ArticleRightColor", "ArticleRightInnerColor", "BodyColor", "FontFamily", "FooterListLinkTextColor", "FooterListTextColor", "Logo", "WikiName" },
                values: new object[] { 1, "#526cad", "#3c5fb8", "#2b4ea6", "#507ced", "Arial, sans-serif", "#1d305e", "#233a71", "logo/logo_pfp.png", "Your Wiki" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5"), null, "WikiPage", null, false, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("c347206a-8624-43be-a6f8-e0d919b21c59"), false, null, "UserSubmittedWikiPage", true, null, false, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[] { new Guid("e1f8e464-9845-4211-b637-9c2fe038b528"), null, "WikiPage", null, false, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("151154a1-fc85-402a-aee0-bdb883ba72b7"), "Nihil ab nulla laborum asperiores consequatur delectus ratione ab. Modi voluptas accusamus nihil eos. Qui esse porro. Provident itaque laudantium.\n\nRerum error incidunt et molestiae animi ad qui. Ea voluptatibus hic. Repudiandae et distinctio rem amet. Dolores atque tempora cumque velit similique expedita expedita ipsam.\n\nMolestiae quod ducimus non fugiat. Sapiente iste dolores illo. Illo eos soluta autem. Temporibus velit qui. Facilis modi quia nobis ex autem eum omnis. Iste quia possimus porro molestias autem iusto.\n\nVelit blanditiis deleniti. Recusandae ex et dolorem accusamus doloribus. Optio qui sunt hic voluptatem dicta quam ipsa accusantium eaque.\n\nAut libero aut omnis non vel nesciunt quidem. Eum similique illo rem impedit error id alias dicta. Rem mollitia consectetur amet dolor. Nisi quos exercitationem.\n\nA aperiam distinctio aspernatur voluptates a. Natus explicabo accusamus voluptatem. Maiores sint voluptatem minima sunt sed quaerat aut est. Qui assumenda ipsa totam et porro quasi rerum quo.\n\nEius ipsum voluptatibus mollitia qui maiores voluptas. Dignissimos dolores consequatur modi vel quia voluptas. Quidem quo et aut odit. Doloremque deserunt et in incidunt enim.", null, null, "Example Page 2 - Paragraph 2", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("27e21529-90dd-4ee6-a7ab-d3c2c9feabb4"), "Rerum reprehenderit aut consequatur in quod saepe assumenda nulla aut. Nemo ut voluptas exercitationem velit delectus neque qui unde temporibus. Voluptatibus eveniet consectetur.\n\nVoluptatem dolorum vero. Esse illo et vel voluptas voluptatem aspernatur. Sed quis et in voluptate. Culpa minus quas ut.\n\nCum est dolores perspiciatis. Fuga qui quas sit voluptates et voluptas assumenda. Soluta ducimus in beatae eligendi eos quas consequatur sint repellendus.\n\nNihil quia id sunt sit eum nulla. Assumenda et earum neque ex asperiores. Minima et non minus in eaque sed. Sapiente possimus magni similique. Qui error placeat soluta saepe. Fugiat voluptas consectetur molestiae excepturi.\n\nCorporis et perferendis. Qui iusto suscipit aut omnis. Libero soluta quidem eos. Voluptatum iste non ut labore aliquid et rerum. Libero cupiditate dolorem perferendis.\n\nDelectus autem dolor. Recusandae sit a. Nostrum possimus consequatur et quis pariatur accusamus vel. Qui incidunt consectetur et sint temporibus eos ut sint. Enim officiis et eveniet vero laudantium ut molestiae est. Accusantium quis perferendis.\n\nOfficiis tempora vero. Veritatis deleniti quidem vel qui ut eveniet at quisquam. In dolores minus at quaerat.\n\nEt error non illo quia eos ratione quos architecto. Sed et aut totam a quaerat ullam vel illum. Beatae inventore sequi nisi autem minus explicabo neque. Ratione quod qui voluptas eos est distinctio.\n\nEsse pariatur amet natus et voluptatem. Laborum tenetur quisquam debitis. Culpa animi praesentium velit laborum excepturi. Ex explicabo dicta mollitia. Deserunt deleniti natus quas dolorem aliquam nostrum.\n\nTemporibus quas excepturi aperiam enim sapiente eaque qui dolorem. Error corrupti aut accusamus fuga fugit velit. Odit maiores ipsa sit quo. Sed corporis temporibus ut. Eligendi ut tenetur magni molestiae praesentium inventore placeat. Soluta provident at facilis.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("466a5f54-f096-41fa-8235-20389310b3f8"), "Aut numquam soluta soluta suscipit laborum laudantium ipsa consequatur. Voluptatem culpa esse delectus temporibus delectus neque delectus nostrum quaerat. Vero est et. Odio laboriosam cum. Ab soluta consequatur nisi expedita. Enim sed est earum eos minus.\n\nOdio ullam nam ut adipisci provident et labore. Voluptatem aliquid eum quibusdam cumque ut et ipsa cumque. Veniam quibusdam animi inventore dolor omnis eum.", null, null, "Example Page 1 - Paragraph 4", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("62a0ad9a-61d7-4d3c-90c4-64ed6b7623d2"), "Sint dolorum nihil asperiores atque repellat non ipsam. Quia esse iusto et quae distinctio est. Aut quia ad praesentium unde odio esse. Quam sed dolorem dolores voluptas cum delectus incidunt qui rem. Eum dolores eveniet omnis. Deserunt perspiciatis veritatis voluptatem porro.\n\nOptio magni et sunt vel iusto nam aliquam impedit repellendus. Repellendus facilis libero. Sequi debitis aut dolor sapiente. Est quidem sit veritatis. Perferendis vel non voluptatum unde. Dolore nulla labore earum exercitationem sequi quo impedit corporis.\n\nTempore inventore asperiores qui occaecati dolores sed ullam eos. Nisi cum minus corrupti tempora quia molestiae autem. Dolor eum eos a. Alias omnis similique ipsa rerum qui similique qui tenetur tenetur.\n\nBlanditiis commodi consequatur asperiores ab. Et veritatis et expedita et quaerat at aliquid sit eum. Laborum ut aut odio debitis est quo et libero.\n\nPerferendis reiciendis deserunt minus ipsa modi sunt odio ipsum. Eligendi a rem repellat corrupti quis. Ea in molestiae neque quo et laborum consectetur. Sit corrupti eius doloribus porro alias. Iure nisi occaecati facilis quam quia cupiditate neque cumque.\n\nAut numquam voluptatum voluptatem qui. Et voluptas consequatur in blanditiis error voluptatem neque. Unde corrupti et modi tempora quasi.\n\nAccusantium itaque laudantium laudantium id laudantium minus recusandae. Aliquam soluta repellat esse nulla eligendi enim. Inventore excepturi laboriosam animi.\n\nDolorum dignissimos molestiae iste accusantium enim harum omnis sapiente est. Consequatur a amet expedita dolorem eveniet. Molestiae totam sapiente molestias ut ut aut aliquam iste. Animi quia distinctio sit facilis corrupti omnis aut. Facilis necessitatibus quod incidunt cupiditate quis. Culpa cumque sapiente perspiciatis ut ea.", null, null, "Example Page 1 - Paragraph 6", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("6cfbf0e0-93d6-407e-97f9-4cb2f5c0909d"), "Praesentium consectetur quo. Recusandae fugit facilis dolorum illo ut ipsam saepe eum repudiandae. Nam animi ratione qui maxime aperiam.\n\nAut aut ipsam laborum impedit quasi dicta animi quasi. Sint reiciendis sed est et adipisci. Non eum aut quasi sunt rem. Voluptates nulla voluptatem laboriosam omnis non sunt tempore quis. Illo culpa consequuntur expedita ratione ab qui reiciendis occaecati. Reiciendis distinctio totam est natus dolorem iste excepturi consectetur sed.\n\nAssumenda excepturi perferendis aperiam officia sit ut saepe delectus. Qui quidem iste est asperiores quia qui est consequatur est. Alias ea dicta id repellendus in qui voluptatum qui. Aperiam unde qui maxime est et dolorem sit qui nisi.\n\nEst commodi et quis placeat est harum dolor molestiae perferendis. Tempore vero est nihil et sapiente enim id. Et est provident. Labore dolores ipsam ex quibusdam cumque.\n\nVoluptatibus dolores repellat ipsa. Quia amet et exercitationem occaecati dolore unde qui. Aut nam aliquid vitae harum ipsum dolores in.\n\nEt consequatur non qui eos. Eum temporibus soluta. Quidem ea rerum id molestias ipsam. Commodi nobis omnis repellat modi eveniet voluptatibus rerum nihil tenetur. Corrupti et ut delectus reprehenderit asperiores. Atque placeat explicabo itaque ea architecto.\n\nOfficiis sed soluta ipsum et aperiam assumenda magnam. Aut autem iure velit qui at. Quis quo blanditiis id doloribus consequatur qui omnis. Ex quia deleniti aut.\n\nAutem mollitia inventore. Voluptas et dolores officia ea. Qui earum voluptatem repudiandae aut ut labore nihil reprehenderit.\n\nProvident qui et enim odio eius expedita porro. Qui consequatur eaque debitis. Omnis nisi maiores sit unde illo aut maxime ut perferendis. Soluta aspernatur voluptatem suscipit quasi.", null, null, "Example Page 2 - Paragraph 6", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("75cf41f2-2481-466d-b4fc-b3a66282892b"), "Tenetur nam ut odit doloribus fuga debitis sit qui. Numquam aperiam quas sit qui dolores et commodi. Inventore explicabo voluptas dolore et quasi illo amet. Odio dicta repellendus enim sed sit. Quia nobis facilis. Eius placeat provident dolorem voluptate illum.\n\nTempore sit et numquam vel alias autem exercitationem totam quia. Voluptas voluptatem distinctio sint ea. Sunt enim amet. Corrupti esse id et. Esse in sint aut sit velit atque magnam est. Sunt porro molestiae explicabo quia repudiandae.\n\nPossimus consequuntur dolore eaque. Omnis voluptatem sequi animi. Et vitae dolorum quod aut et dolorum sed officiis enim. Voluptas veritatis laborum fugit ea sunt dolore sint nisi. Consequuntur doloremque culpa.", null, null, "Example Page 1 - Paragraph 3", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("7ad64171-6741-4a11-b397-059943d22f48"), "Mollitia asperiores eaque ullam quas sapiente maiores rerum quod. Officia veritatis repellendus ipsa. Consequatur quia id officia officiis quidem et deserunt. Et voluptatem qui deserunt numquam aspernatur consectetur. Consectetur corrupti et aliquid officia est et. Aspernatur officia modi sit error architecto nihil fugit ut.\n\nExpedita omnis molestiae et provident neque. Eos vel aut quo aut magni. Autem quod similique sed ipsa quaerat. Modi ipsa animi qui illo sit aut vitae.", null, null, "Example Page 1 - Paragraph 5", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") },
                    { new Guid("8df9f4c2-9928-43e6-867f-78f4a3eaef28"), "Reiciendis temporibus aut id ut. Consequatur eum necessitatibus facere. Sed maiores id vero laboriosam autem. Tenetur est deserunt animi ea omnis qui quae exercitationem molestiae.\n\nVel est dolores sed sit maxime ipsa cupiditate suscipit eos. Laboriosam dolorem natus similique quae et. Voluptas assumenda eaque alias nesciunt odio quia. Quasi possimus qui exercitationem iste aut.\n\nAutem optio ipsa ipsam. Blanditiis et et. Consequatur quo velit inventore voluptatem natus. Ut sint praesentium aut voluptatem commodi at aut qui. Similique consectetur qui voluptatem molestias id. Itaque officia eaque eius sunt quo quod.\n\nBlanditiis qui consequatur. Nesciunt eum voluptates eius. Velit labore alias et autem quod laudantium. Qui quisquam dolor ut quaerat et nostrum. A voluptatem non dolores porro ut. Quis in nemo doloremque nobis.\n\nAutem aut doloremque nesciunt omnis quam et enim. Voluptas voluptatibus tenetur nemo numquam enim deserunt. Optio enim doloribus est ut quae et optio est. Modi iusto illum quo at ipsum nobis perspiciatis.\n\nEx et voluptatibus aliquid. Recusandae architecto tempore blanditiis magni. Recusandae quia ut ab optio voluptatem quaerat. Placeat nulla error voluptate. Dolore excepturi eligendi ab a ut. Aperiam aut doloremque quidem.", null, null, "Example Page 2 - Paragraph 3", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("ac56ad23-9a4e-42dc-ba7e-679e8ecd0af4"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("c347206a-8624-43be-a6f8-e0d919b21c59") },
                    { new Guid("cf8f3d15-b006-4661-8e07-6b859d32a71a"), "Maiores suscipit voluptatem voluptas inventore. Deleniti et quasi voluptas minus. Incidunt et labore. Voluptatem ad provident.\n\nQuam tenetur et odit non ea accusamus occaecati nam. Exercitationem molestias et. Nostrum expedita sed harum dolores. Dignissimos amet tempora. Repellat suscipit aut corporis quia dolorem ratione nemo qui.\n\nAut libero aut blanditiis quidem reprehenderit quia aut enim architecto. Possimus rem delectus ipsam quo libero et et. Non minima nisi perferendis atque. Qui et sit quisquam quaerat. Consequatur commodi corrupti.\n\nHarum iste exercitationem eos laboriosam quas nesciunt. Minima quibusdam eos natus harum et excepturi. Expedita qui error maxime nostrum ullam ut eum ratione. Maiores soluta et qui natus delectus sit voluptatum quidem neque.\n\nDolorum eos beatae qui quia aut. Dolores maiores alias numquam expedita. Nisi aspernatur sunt. Excepturi earum ut. Assumenda aut expedita maiores repudiandae dolorem sit modi.\n\nEt soluta nam quisquam quia nemo maxime fuga aliquam. Rerum sed ea fuga esse. Voluptate velit sequi tempora aut dolor quae rerum labore repellendus. Nisi quaerat impedit. Cum et quo vel. Temporibus est eum aut voluptas nam architecto a ad autem.", null, null, "Example Page 2 - Paragraph 5", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("d14aeeff-0cff-46b6-a1d3-e92d49e6a7c0"), "Et aut dolore voluptatibus fugit aliquam. Corporis blanditiis libero. Rerum quia voluptatem quas. Enim rem doloribus omnis minus magnam alias quia modi repudiandae. Alias quidem a enim voluptatum est voluptate nobis aliquam repellat.\n\nFugiat sint voluptatem molestiae similique. Asperiores repellendus rem iusto dolore sit doloribus. Ut culpa saepe est quia. Corporis est expedita expedita. Est sed dolorem sunt molestiae repudiandae placeat repellendus repellendus.\n\nLaboriosam nihil qui aperiam similique voluptatem sint et. Sed vel minima necessitatibus voluptate vel voluptatem facere dignissimos. Sequi adipisci est mollitia in debitis voluptas qui omnis odit. Repellendus assumenda est quod pariatur.", null, null, "Example Page 2 - Paragraph 4", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("d48cdea2-13e6-43d3-b383-426b3cb226b5"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("c347206a-8624-43be-a6f8-e0d919b21c59") },
                    { new Guid("e8b5d234-f16d-4796-b2b9-a1a830eb2c4f"), "Commodi similique fugit sapiente repellendus sunt qui sunt quis quod. Consequuntur doloribus ad numquam voluptatem enim temporibus voluptas. Magni et aut ducimus officia.\n\nAut iste molestias. Quasi ad vitae et. Ratione laboriosam libero.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("74b27c7f-ffe0-4593-bd04-634321002cc5") },
                    { new Guid("ee94ff3a-7674-447b-9094-21f63d33f1f1"), "Et aut quos rem porro asperiores. Sit deleniti eligendi aspernatur iste cum et ad amet. Asperiores temporibus eveniet qui. Culpa et iure excepturi inventore non qui qui sunt nobis. Natus tempore cumque exercitationem eum reprehenderit et omnis quam ipsa.\n\nIncidunt dolorem id sit vel officiis magnam quia perferendis voluptas. Illum odit dolor impedit veniam voluptatum. Nam cumque quidem qui eos. Qui in modi sapiente. Velit inventore voluptatem omnis deleniti ipsam.\n\nNam ipsa commodi excepturi necessitatibus sapiente nobis sit. Sint et voluptatem sit voluptates voluptatum. Vel atque molestias qui molestias dolores architecto veniam id reprehenderit. Consequatur adipisci pariatur est voluptas. Vel commodi ab.\n\nVel aut non ut fugiat distinctio nesciunt sunt reiciendis. Laudantium ut amet commodi eum expedita sed quidem. Adipisci sequi voluptatum nesciunt vel sapiente rerum dolores et.\n\nMinima illo doloribus labore est veniam labore. Quo aut saepe nulla omnis tempore cumque assumenda pariatur. Velit eos recusandae eos porro. Error voluptatum placeat corrupti et voluptates dicta. Quia qui autem eum illum velit in quas consequatur. Nihil culpa eius omnis sunt modi vel.\n\nIusto excepturi aut et eaque exercitationem quibusdam omnis. Doloremque consequatur magnam aliquam nostrum et. Error voluptatem quasi vel eveniet nihil nulla inventore. At vitae debitis eos. Et est dicta aut ipsa.\n\nEx soluta quam non. Minus dicta porro nihil labore eum rerum. A a eaque quas omnis iusto. Eum occaecati est et adipisci et quo suscipit.\n\nInventore itaque eveniet rem blanditiis. Adipisci praesentium accusantium illum sit. Maxime vitae aut nihil.\n\nOmnis quo dolorem quos qui. Explicabo dignissimos aperiam officia. Ut eligendi dolores cum nihil. Molestiae eum reiciendis vitae perspiciatis qui nihil. Minima vel et est.", null, null, "Example Page 1 - Paragraph 2", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f"), false, null, "UserSubmittedWikiPage", false, null, false, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("e1f8e464-9845-4211-b637-9c2fe038b528") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("2a87a6e8-dd49-466f-aff6-1e4997fa77ff"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f") },
                    { new Guid("b2f6b699-348e-4f7b-be74-94e7ce444734"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("b56f5798-ca3d-43f1-81a1-1d97f0dd449f") }
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
                name: "IX_AspNetUsers_ProfileId",
                table: "AspNetUsers",
                column: "ProfileId",
                unique: true);

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
                name: "IX_UserComments_ReplayToCommentId",
                table: "UserComments",
                column: "ReplayToCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserProfileId",
                table: "UserComments",
                column: "UserProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_WikiPageId",
                table: "UserComments",
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
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "WikiPages");

            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
