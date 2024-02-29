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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProfileId = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserProfileId = table.Column<int>(type: "int", nullable: false),
                    WikiPageId = table.Column<int>(type: "int", nullable: false),
                    PostDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReply = table.Column<bool>(type: "bit", nullable: false),
                    ReplyToCommentId = table.Column<int>(type: "int", nullable: true),
                    IsEdited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComments_UserComments_ReplyToCommentId",
                        column: x => x.ReplyToCommentId,
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
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Discriminator", "IsNewPage", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { 3, false, "UserSubmittedWikiPage", true, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 1, "Animi nesciunt iste similique possimus. Aut numquam facilis ratione tenetur. Occaecati quo ipsum in earum est earum reiciendis quasi autem. Sit sed quam magnam et aliquam rerum ad sint velit. Et et similique repellat provident autem fuga at.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", 1 },
                    { 2, "Velit debitis totam qui id nobis. Quis omnis nam nemo distinctio eligendi laborum. Laborum iste quia.\n\nQuibusdam nam repellat eum. Possimus ratione numquam. Necessitatibus consequatur tempore. Neque error nihil sint praesentium quae. Rerum veniam aspernatur.\n\nPlaceat tenetur dolor voluptates nulla qui fugiat. Est qui facilis voluptates vel vitae dolores. Fugit aut cumque.\n\nQuas laboriosam soluta est magni porro. Ex vitae quaerat distinctio voluptatem molestias deserunt provident. Non sit delectus repellendus quod voluptatem temporibus. Tenetur alias voluptatem quo voluptate occaecati. Nihil sunt debitis exercitationem deleniti numquam suscipit corporis. Omnis consequatur facere.\n\nEa quidem minus laboriosam iure ipsum alias incidunt quos. Praesentium fugiat architecto quam aut quam sit minus enim. Perferendis laboriosam est velit qui nihil beatae nisi deleniti. Magnam cum est deleniti officiis vel aliquid quo. Voluptatem iure deleniti id ab ratione eius quos sapiente id. Impedit similique rerum sed omnis eos adipisci voluptatem qui eos.\n\nRerum ut dolorem. Atque ea velit placeat natus ut. Aperiam odio praesentium. Veniam laborum cumque quaerat expedita perspiciatis quo.", null, null, "Example Page 1 - Paragraph 2", 1 },
                    { 3, "Voluptatum quasi ex illum est aut. Aut nobis quia ea numquam laboriosam aliquam alias libero sapiente. Ut aut et voluptatum nostrum veritatis libero facilis.", null, null, "Example Page 1 - Paragraph 3", 1 },
                    { 4, "Officia id dolore est voluptate velit voluptatem ipsam. Qui praesentium ullam quod corporis molestias dolor. Atque quasi fugiat sed odio rerum eos. Unde aliquid tempora vero aut. Odit sint alias rerum nulla ea voluptas possimus velit. Eligendi harum fuga dolores.\n\nDebitis velit rerum tempore tempora aut quo id. Quasi deleniti odio vitae eligendi inventore iste autem repellendus. Libero quia nulla eveniet optio nam hic. Aperiam minus et praesentium dolores dolorem a magnam amet tempore. Ea excepturi delectus et cum reiciendis aperiam omnis deserunt minima.\n\nAut libero vel eligendi nisi optio sit perferendis recusandae qui. Debitis autem est aut consequatur libero assumenda. Molestiae hic molestiae veritatis eum quia non tempora laudantium dolorem. Voluptatem nulla dolores pariatur.\n\nQuis magnam optio doloremque eum neque numquam totam ab. Placeat debitis facere quibusdam. Magnam qui possimus soluta eveniet corporis minus consectetur amet. Cupiditate recusandae qui debitis nobis dolore.\n\nQuis non recusandae distinctio eius dolore quidem vitae. Voluptas quis error esse. Nihil rerum adipisci recusandae eius dolores numquam autem. Qui ullam tempore architecto.\n\nAspernatur rerum asperiores ea. Vel adipisci totam sint sit quia porro. Pariatur recusandae aperiam dolorem rem voluptatem rerum temporibus. Voluptatem quibusdam et dolor omnis enim dolores et aut. Iste velit voluptas ut architecto qui rerum laboriosam. Voluptates ipsum animi sunt.\n\nIn rerum aperiam beatae tenetur aperiam id. Quas possimus reprehenderit architecto. Impedit inventore deleniti recusandae id voluptatibus enim. Vel assumenda quasi omnis quia natus quasi officia deleniti.\n\nLaboriosam sunt ab rerum ipsam. Doloremque atque possimus totam repudiandae praesentium. Et qui eum. Dolorum fugit delectus quidem illo. In praesentium voluptatem alias et et quas. Id est aut dolores non maiores.\n\nDicta porro saepe. Impedit debitis beatae possimus cumque quo vel consequatur. Est et recusandae beatae.\n\nQuos quos consequatur exercitationem temporibus enim aut sit accusamus. Nam natus saepe. Quam dignissimos aut ad enim iste minima.", null, null, "Example Page 1 - Paragraph 4", 1 },
                    { 5, "Eos iusto in quae accusamus ipsum et. Nostrum ut sequi neque. Omnis soluta vero delectus quam natus harum et sapiente. Tenetur mollitia voluptate magni facilis sed eaque voluptatem doloribus error.\n\nCulpa earum qui sed eveniet animi consequatur nesciunt numquam. Commodi enim qui. Ut dolor cum. Aut non tempore sed eum error saepe.\n\nUt velit qui aut. Minima aut dolore impedit adipisci voluptatum quis omnis. Eaque et qui fugit sit. Placeat sit beatae non ea voluptate ipsum.\n\nOptio est numquam nisi autem tenetur. Quia vitae quae facilis. Harum id placeat aut. Ut architecto odio sit quis aut sit repellendus.\n\nUt est rerum maxime nemo voluptates. Nobis et excepturi eligendi aliquid neque ex corrupti. Rem voluptatem et accusamus unde ratione sequi. Quia qui voluptatem fugiat. Nihil unde ut explicabo.\n\nVoluptatibus aut aut quidem autem placeat quidem deleniti. Eligendi qui atque dicta. Sit qui minima repellat non facilis itaque.\n\nAmet sunt voluptatem reprehenderit rerum rerum alias aut laudantium ut. Reiciendis est sed repudiandae sequi consequatur ea dolorem temporibus. Quasi sit deleniti sapiente. Architecto at inventore autem magnam. Aut quia inventore modi tempore.\n\nOdit rerum omnis qui aliquam et vel. Ducimus quidem soluta non sed possimus cupiditate. Aut perferendis perferendis exercitationem inventore id quis autem in quia. Reprehenderit sunt voluptatibus nesciunt. Vel temporibus perferendis dolor officiis est eveniet culpa.", null, null, "Example Page 1 - Paragraph 5", 1 },
                    { 6, "Quisquam reprehenderit minima. Consectetur sit est ipsa et ab voluptas. Ducimus aspernatur neque. Aliquid eaque dolorum quos nesciunt. Qui culpa odit quasi culpa blanditiis rerum vero. Sunt earum et doloremque a omnis corrupti sed.\n\nDeserunt eum laborum. Perferendis sed neque excepturi ad voluptas non amet ratione. Aut cupiditate qui. Asperiores eveniet dolore molestiae error saepe ducimus reiciendis odio ab. Assumenda quia illum ea adipisci. Totam laudantium sit aut accusamus ipsum voluptatem perspiciatis voluptatum dolores.\n\nVoluptatibus consequatur omnis voluptas. Sit sit voluptas perferendis autem voluptas. Facilis sunt ratione quasi ducimus fugiat autem ut. Temporibus odit numquam unde error beatae dolorem placeat. Consequatur voluptatem eos similique porro et nostrum consequatur impedit. Sint et quis eum aliquid numquam.\n\nDeserunt et quia quis et exercitationem perspiciatis. Mollitia a et libero. Culpa sint reiciendis ipsam.\n\nNesciunt quo culpa tempora et sunt aut recusandae et recusandae. Sit iusto molestiae pariatur qui eum esse odit. Dolor quis adipisci dolorum deleniti rerum quo sint. Ut et et voluptas eos velit consequuntur ut dolores. Dolorem impedit alias architecto architecto. Ad aliquid in ipsam.\n\nIpsum quis in. Doloribus consequatur sunt quia voluptas. Totam vitae et aliquid quos et possimus facilis. Optio eveniet accusamus itaque. Molestiae culpa ut qui labore excepturi qui qui perferendis.\n\nSed molestias est quidem culpa soluta sit sapiente dicta. Dolore officiis impedit ipsam et voluptatem dolorem ipsam est consequatur. Blanditiis enim earum. Omnis voluptas quae amet eveniet impedit.\n\nAdipisci quasi consequatur doloremque quis accusantium ut reprehenderit. Deleniti corrupti pariatur tempora fugiat corrupti enim quod libero. Aut aut similique iste.\n\nSimilique facere nam aut id odit non veniam. Amet vitae aspernatur dolor soluta non. Sint et quis libero maxime molestiae voluptatem. Aut culpa consequuntur perspiciatis. Magnam quae tenetur at sunt architecto est. Reprehenderit doloribus nobis assumenda.", null, null, "Example Page 1 - Paragraph 6", 1 },
                    { 7, "Reiciendis ex totam sed. Enim id in culpa deleniti sit dolores nemo ea. Vel aut facilis optio magnam soluta quibusdam. Voluptate nesciunt rerum quia in voluptas voluptates asperiores consequatur quas. Itaque quae molestiae sed.\n\nOmnis assumenda exercitationem magni dolore exercitationem rem et sed et. Qui assumenda nesciunt numquam quia vel eaque. Amet qui voluptatum. Libero et aut odio ut iste aperiam ut aliquid. Repellat est ut exercitationem molestias nesciunt.\n\nArchitecto enim est recusandae odit velit. Unde quasi voluptate odio et eum fuga in eos et. Eaque enim sunt neque dolorum. Sint delectus ut harum distinctio natus aspernatur voluptatem dolor architecto.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", 2 },
                    { 8, "Ut voluptatem totam molestiae quia sint qui debitis. Vel quod eum. Rerum soluta rerum quia eum error quos quo.\n\nRem hic necessitatibus perspiciatis qui ut esse aspernatur consectetur culpa. Et deserunt iure est eveniet qui. Debitis et labore magni vel. Voluptatem accusantium culpa blanditiis voluptas animi. Et sed necessitatibus quibusdam dolorum omnis.\n\nVoluptas numquam repellat est autem accusantium iure omnis itaque. Fugit et sed molestiae consequatur id eaque quidem animi est. Eum et corporis id quia enim.\n\nQuidem repellendus adipisci tempore repellat ex repudiandae rerum. Magni et officia et eum id cupiditate doloremque ea voluptatem. Eaque eos et quam ut id consectetur repudiandae ut. Hic et neque ipsum praesentium necessitatibus. Natus possimus minima accusantium aut consequuntur adipisci itaque aut.\n\nDicta enim alias necessitatibus sit in. Sed sunt aut qui occaecati eligendi quis expedita consequatur quos. Dolore eveniet asperiores voluptates.", null, null, "Example Page 2 - Paragraph 2", 2 },
                    { 9, "Natus ad id nihil occaecati porro. Quis rerum deleniti dolor velit sapiente. Molestias placeat aspernatur. Velit modi consequatur.\n\nOfficia explicabo velit aut et tempora id fugit id. Libero praesentium non. Rerum eos voluptatibus placeat assumenda quia.\n\nFacere adipisci aut aliquam dolorum libero quas quasi amet ipsum. Sed dignissimos tempore. Sint commodi sequi dolores eum numquam. Possimus qui ratione et amet optio qui. Aut nam quia eaque et totam rerum necessitatibus.\n\nPerferendis iure aspernatur autem incidunt cum. Rerum rem similique commodi sunt maiores commodi totam. Officia occaecati id deleniti aspernatur sunt. Et dicta saepe illo porro eveniet sit in.\n\nConsequatur earum ut enim iste. Ut voluptatem corporis omnis quibusdam. Vitae ipsa est ipsum aut explicabo nam. Necessitatibus rerum voluptates ut nulla. Voluptatibus vitae tempore quas voluptas in est harum quisquam. Facilis modi nisi fugiat voluptas harum.\n\nNon in ut optio beatae est. Rerum sapiente iusto. Modi quis quia blanditiis pariatur.\n\nEt libero iusto quo impedit et unde. Aliquam molestiae dolores nihil nesciunt. Eos odio et ab dolores sequi quis fugiat libero. Quis sed omnis ab officia.\n\nEos eos id illum officia accusantium. Possimus libero nulla nobis sed est velit vel aut consequatur. Voluptate deleniti cupiditate aliquam blanditiis architecto est eaque quia est. Doloribus quis id. Dignissimos corporis quisquam rerum laudantium quisquam aut consectetur cupiditate.", null, null, "Example Page 2 - Paragraph 3", 2 },
                    { 10, "Deleniti id commodi provident inventore in laboriosam. Dicta cupiditate labore laborum ut. Beatae qui dolor unde reprehenderit aut soluta cumque fugiat asperiores. Voluptatem quisquam ratione aut voluptatem nisi facere. Ex explicabo ducimus autem est. Est omnis et sunt.\n\nMagnam ea error et explicabo sed voluptatem. Ut et recusandae illo voluptatem tenetur harum. Ullam molestias earum atque reprehenderit sapiente voluptatibus sed eius tenetur.", null, null, "Example Page 2 - Paragraph 4", 2 },
                    { 11, "Deleniti eveniet possimus omnis voluptate facilis reprehenderit. Ratione velit perferendis suscipit ut. Eos sit vel odio. In eum voluptatibus molestiae nam iste natus libero unde. Officiis deserunt dolorum veritatis adipisci animi.\n\nEt doloremque rerum id voluptatem. Commodi illum animi. Odit consequatur incidunt ratione vitae.\n\nEa beatae quam asperiores aut facere aut molestias animi sed. Aut quibusdam voluptate. Harum fuga quasi consequatur. Est aut est voluptas architecto repellendus dolores corporis. Quia est ut doloremque aperiam praesentium sapiente culpa.\n\nSunt et fugit rerum voluptate voluptates sint dolores et est. Perferendis doloribus voluptates qui unde. Molestiae quaerat odio. Ea iusto ut.\n\nUllam ex molestiae. Corrupti itaque asperiores. Odit repellendus officiis.\n\nHarum deleniti quia sit. Velit repellendus sapiente. Sed soluta autem quis deleniti voluptas expedita rerum. Aperiam eos repellendus est porro.", null, null, "Example Page 2 - Paragraph 5", 2 },
                    { 12, "Non perspiciatis quaerat sit. Error neque aut est tempora odio omnis. Sed molestiae enim rerum autem officia dignissimos consectetur aut. Aut magni est aut vitae reprehenderit eius.", null, null, "Example Page 2 - Paragraph 6", 2 },
                    { 13, "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", 3 },
                    { 14, "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", 3 }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Discriminator", "IsNewPage", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { 4, false, "UserSubmittedWikiPage", false, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", 1 });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 15, "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", 4 },
                    { 16, "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", 4 }
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
                name: "IX_UserComments_ReplyToCommentId",
                table: "UserComments",
                column: "ReplyToCommentId");

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
