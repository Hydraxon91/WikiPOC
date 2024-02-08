﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wiki_backend.DatabaseServices;

#nullable disable

namespace wiki_backend.Migrations
{
    [DbContext(typeof(WikiDbContext))]
    [Migration("20240208132257_AddUserSubmittedWikiPage2")]
    partial class AddUserSubmittedWikiPage2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("wiki_backend.Models.Paragraph", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParagraphImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ParagraphImageText")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WikiPageId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WikiPageId");

                    b.ToTable("Paragraphs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "Example content 1",
                            ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                            ParagraphImageText = "Example ParagraphImageText 1",
                            Title = "Example Paragraph 1",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "Example content 2",
                            ParagraphImage = "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg",
                            ParagraphImageText = "<Link to=\"/page/Example%20Page%201\"> This links to Example page 1 </Link>",
                            Title = "Example Paragraph 2",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 3,
                            Content = "Et beatae earum autem. Ad velit vel sed autem nobis nobis inventore. Omnis maiores ipsum in sed totam. Quam nihil sapiente itaque dolore tempore. Ipsam exercitationem ullam nisi eius aut tenetur doloribus est. Qui culpa voluptatibus necessitatibus quisquam.\n\nRepudiandae et repudiandae. Eius beatae odit eos hic quia incidunt voluptatibus. Quia esse velit reprehenderit placeat deserunt esse suscipit.\n\nModi aut velit ut. Minima perferendis voluptatem fugiat consequuntur ex necessitatibus ut voluptatem porro. Itaque architecto fugit reprehenderit cumque eligendi ut ad architecto quo. Ut minus hic fugit. Quae et dolor soluta accusamus nemo animi. Expedita qui nesciunt.\n\nEx vel fuga odit excepturi eum fugit facere iste. Nihil amet ipsam. Temporibus eveniet aliquid porro velit eveniet libero. Et autem et. Vel ut maiores ducimus iste et excepturi in. Quis rerum vero.\n\nSuscipit excepturi at nulla molestiae laborum nam. Ut qui unde aliquam voluptas cupiditate in. Ipsam et ratione vel in.",
                            Title = "Example Paragraph 3",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 4,
                            Content = "Id repellat tempora rem magnam modi fugiat consequuntur omnis exercitationem. Perspiciatis aperiam iusto. Incidunt vel sunt quis ut animi. Commodi non tempore ad aspernatur ipsum consectetur nobis. Vel id dolorem unde quae mollitia.\n\nQuia rerum dolor hic nostrum quasi voluptatem. Soluta assumenda autem aut quos aliquam. Non quam magni omnis quae consequatur asperiores qui hic. Autem quia placeat qui voluptate eos id blanditiis nihil. Labore at veniam iure possimus explicabo.\n\nSint non id excepturi. Praesentium est aut rerum. Dolor eveniet iste dolorem vitae magni.\n\nDeleniti culpa saepe quo modi in delectus omnis asperiores. Explicabo illo harum quaerat a sint aut rerum quibusdam. Nostrum voluptas est ratione quisquam eligendi.\n\nDolores ut pariatur id autem animi officia est quod et. Iure velit ea consectetur id sit. Veniam porro libero et quibusdam non nihil omnis.",
                            Title = "Example Paragraph 4",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "Non dolores tenetur asperiores dolor. Quidem qui eum nisi deserunt ut asperiores totam sed. Nesciunt non ut nulla quae qui magnam.\n\nExplicabo maiores necessitatibus et qui sint et. Quia porro ut ipsum. Quae exercitationem et.\n\nAut et quam quos minima. Sapiente aut maiores fugiat eaque non. Sunt deleniti harum ut aliquam corporis voluptate ut.\n\nSoluta enim et ut optio iure recusandae consequatur dolores cum. Earum voluptatem quia. Earum id aut et ut. Aut enim optio. Molestiae ipsam libero dolorem ducimus occaecati eveniet aut esse voluptatem.\n\nAliquam ut aut in doloribus ipsum dolore qui totam. Perferendis ut qui id non eius voluptatum. Et voluptas dolorem animi et cupiditate ex nemo. Amet aut quos magni temporibus et possimus. Quo in eos sed nostrum consequuntur explicabo aliquid minus.",
                            Title = "Example Paragraph 5",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 6,
                            Content = "Odit excepturi ab sapiente iste sequi dolorem harum harum. Ullam est sit. Dolores laboriosam molestiae voluptas rem exercitationem officia. Optio sed autem atque mollitia minus illo dolorem.\n\nEnim aut vel veritatis dolorem id est aut omnis. Adipisci explicabo reprehenderit aut. Recusandae eos aut facilis vel nemo voluptas voluptas dolor. Ut consequatur reiciendis. Earum error labore tempora est.\n\nId enim ea esse vel quam ut explicabo soluta. Ad quidem eos nostrum hic enim vel et accusantium qui. Aut adipisci atque.\n\nCommodi quia sed. Quas sint et et ut aperiam ut. Magni doloremque adipisci eligendi consequatur est. Aliquid rerum molestias sunt vel. Nulla assumenda quae est dolores.\n\nUt dolores dolorem soluta molestias delectus. Dolores nobis nesciunt autem nihil tempore. Veritatis magni rem repellat. Labore reiciendis corrupti et dolore omnis qui ex quidem. Illum sapiente iure in.",
                            Title = "Example Paragraph 6",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 7,
                            Content = "Quam corrupti aut. Et sit doloribus fugit voluptatem. Qui pariatur voluptatum impedit quia ducimus. Eius est et aut enim in saepe.\n\nUt modi reiciendis explicabo ut officia vero quis. Labore doloremque non quis quasi praesentium ad asperiores mollitia distinctio. Ipsam velit quam ea velit aut explicabo praesentium enim est. Incidunt voluptates ut architecto ut vel molestias et quisquam nobis. Odit animi blanditiis hic. Tenetur ut minus sit natus perspiciatis blanditiis veniam est eaque.\n\nDucimus voluptatem inventore ea qui. Quaerat quibusdam et culpa corrupti provident. Corrupti minima dolorem aut sunt omnis. Nulla ut recusandae distinctio dignissimos et.\n\nAsperiores sit accusamus eaque ut velit occaecati et alias. Adipisci necessitatibus nihil eos architecto laborum quo modi aut. Molestias nihil sit. Suscipit ab quas corrupti quidem tempora sint earum quam.\n\nTotam voluptas necessitatibus minus. Et nam et. Ut est eos dignissimos quos sint exercitationem velit. Sequi deleniti maiores velit aperiam porro.",
                            Title = "Example Paragraph 7",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 8,
                            Content = "Sunt sint sit perferendis consequatur rerum. Dolorem a quisquam rerum assumenda totam ut necessitatibus. Ex delectus saepe sed voluptatem ipsa aut neque quaerat id. Ipsa aut qui sed et rerum sed. Quo autem incidunt quod excepturi voluptas et possimus voluptatem. Deserunt nulla quos rerum ut maiores aut.\n\nEt odio aspernatur. Accusantium quae labore ex. Reiciendis molestiae voluptatem soluta vitae sit debitis. Ut in eaque corrupti pariatur qui eos.\n\nIn totam ex aperiam inventore corrupti voluptatem. Magnam labore sapiente nihil corrupti et. Non enim ipsa et modi consequatur dolores et. Aut est et ut rerum distinctio quibusdam.\n\nTenetur deleniti corporis est non quae cupiditate illum tenetur incidunt. Excepturi magni inventore nam. Voluptatem id accusamus eos odio eos. Quibusdam quaerat vero odit dicta qui. Hic doloribus ipsam rem quidem exercitationem. Ipsa aut repellendus numquam.\n\nUt ut consectetur. Minima nisi repudiandae sed quis veritatis. Sint corporis veritatis non. Dicta non at officiis.",
                            Title = "Example Paragraph 8",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 9,
                            Content = "Architecto commodi voluptates doloribus possimus commodi quibusdam reprehenderit. Ut ut repellendus sed. Consequatur in occaecati cum quia tempore iure perspiciatis laborum incidunt. Ex aut animi voluptatem est optio.\n\nAsperiores accusamus commodi fugit et sequi dignissimos in. Autem numquam qui provident amet neque inventore ipsum est. Minima voluptates quas et corporis libero dolore. Iste quidem id ratione et culpa nobis optio.\n\nVero dolorem mollitia pariatur molestiae quaerat non. Consequuntur neque molestiae officia eligendi dolor error natus provident voluptas. Voluptatem et consequatur optio quisquam vitae libero. Blanditiis illum beatae non doloribus quia. Dolores hic veritatis. Ipsa animi maiores.\n\nRerum nisi est aspernatur iure eaque. Facere dicta rerum et reiciendis qui. Sit qui minus reiciendis et. Qui fuga dicta officiis rerum.\n\nVelit quibusdam tenetur vel alias beatae. Fuga et tempora molestiae sed temporibus qui. Omnis praesentium aut est numquam aut sunt earum sint. Est est aut minima perspiciatis maiores ex quia ut voluptatem.",
                            Title = "Example Paragraph 9",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 10,
                            Content = "Rerum qui magni atque reiciendis. Ut placeat aperiam corporis voluptatibus quaerat laudantium. Facere amet itaque quas cupiditate eos corrupti tenetur et. Vero omnis incidunt earum. Dolorem qui ut impedit cum nostrum.\n\nInventore voluptates repudiandae. Aperiam quod voluptas voluptatibus. Temporibus dolores minus tempore officia.\n\nUt similique aut cupiditate eveniet molestiae voluptas iusto ab sunt. In ipsa reprehenderit architecto eos est. Sint quos enim et voluptatem ipsum sit. Placeat qui dolore saepe nihil amet animi. Rerum velit fugit expedita harum voluptate vel sit nostrum totam. Et doloribus odit quia eveniet veniam non id dolorem at.\n\nQuae ab et quia maiores quo totam repellendus. Magnam occaecati voluptatem doloremque sint minus aut sunt. Et pariatur sit quas repellat necessitatibus. Vel eos blanditiis soluta. Qui tenetur sequi recusandae facilis qui incidunt repellat iure dolor.\n\nDignissimos incidunt et et molestias sed recusandae earum repellat aut. Et rerum et corporis veritatis sed id laborum. Maiores et consequuntur ducimus excepturi labore autem corporis. Autem aliquam tenetur aspernatur enim libero velit sint minus sint. Dignissimos ipsa error officia facere aut. Tempore non dolor ut quaerat.",
                            Title = "Example Paragraph 10",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 11,
                            Content = "Quo vel aperiam quaerat omnis exercitationem at ad totam dolorem. Occaecati repudiandae rerum. Et voluptatibus omnis eos occaecati necessitatibus. Sit aliquam vel repudiandae voluptas incidunt dolor.\n\nAut fugit doloribus. Error qui asperiores quisquam qui voluptas. Molestiae aspernatur libero fugiat est sapiente est aperiam.\n\nIn vero doloremque fuga. Dolorem explicabo molestias ipsam unde vitae atque et. Aut qui quidem fuga non velit aperiam quo occaecati. Sed et eaque facilis expedita et ducimus consequatur dolores officia. Soluta placeat molestias qui aliquid quibusdam natus quos illo doloribus.\n\nAtque et maiores hic molestias. Mollitia doloribus id omnis eos. Modi in nesciunt et. Molestias odio in.\n\nTemporibus rem sed quos repudiandae optio odit a sequi. Neque fugiat sunt autem voluptate magni rerum quam. Cumque maxime blanditiis libero et assumenda et. Inventore neque voluptatem temporibus voluptatem voluptas eum doloremque. Delectus aut ea quia in quos nihil dicta. Exercitationem et quia.",
                            Title = "Example Paragraph 11",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 12,
                            Content = "Illum est sequi maxime aliquid consequuntur. Asperiores et odio. Velit fugit iste odio officiis est quaerat explicabo rem amet. Et aut ipsam aut architecto qui ea eos quibusdam. Nisi aliquid iste sed consectetur dolore. Maxime quidem impedit ut qui quam quia ea magni qui.\n\nArchitecto repellendus rem ut. Accusantium temporibus quos eligendi qui sunt optio rem. Ea tempora rerum. Quis mollitia necessitatibus cum laborum.\n\nNulla qui voluptas non libero mollitia recusandae ipsum. Consectetur et ducimus. Voluptatum iste soluta ipsa mollitia est iste dicta neque asperiores. Nihil rerum quia sed iste omnis in qui molestias. Et recusandae qui cupiditate deserunt in laudantium ut sed illo. Aliquam sunt consectetur neque qui ad inventore.\n\nAmet ex molestias consequatur laborum vero ut atque quo magni. Qui sint unde nesciunt autem placeat officia in veritatis. Nesciunt rerum non quibusdam nam et et ut et reprehenderit. Esse voluptatem id repudiandae quasi velit qui.\n\nQuae quod est. Non asperiores inventore nihil recusandae dolorem eveniet perferendis qui architecto. Amet nulla aut. Molestiae perspiciatis ab est. Tempora temporibus veniam voluptatem cupiditate doloribus minus aut non.",
                            Title = "Example Paragraph 12",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 13,
                            Content = "Quod tenetur voluptas eum dolorum aspernatur vero voluptate itaque. Dolorum ipsa et autem corrupti. Aut ullam mollitia consequatur et quo totam rerum placeat minus. Provident laborum pariatur labore.\n\nIste voluptas corrupti corrupti. Explicabo a explicabo non quisquam ad enim quia. Laborum laudantium at aut. Magnam tenetur voluptates qui repellat est dignissimos dolore. Ab incidunt voluptatem. Ducimus dolores fugit.\n\nConsequatur eligendi eum consequatur maxime. Sit cupiditate et consectetur. Quisquam animi dignissimos dolorem voluptatem delectus.\n\nVeritatis fugiat ut. Voluptatem fuga nihil qui ut pariatur quo iste nesciunt et. Minus et ex voluptatum explicabo minima vitae quia earum sit. Rerum repellat distinctio suscipit minus dolorem. Neque aliquid quos debitis aut quod vero.\n\nVoluptatem et sapiente eveniet molestiae tenetur beatae. Occaecati et aut laudantium inventore. Fuga aut voluptas est autem. Sed omnis ipsum.",
                            Title = "Example Paragraph 13",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 14,
                            Content = "Assumenda quia aut nam fugiat consequatur. Ut tempore corrupti et eos blanditiis totam quas. Laudantium id fugiat modi nihil et doloremque soluta. Debitis laborum dolore molestiae quis. Minima fugiat minus soluta temporibus ducimus at non. Et vitae quis qui dignissimos nulla quis repudiandae qui minus.\n\nMagni qui quod. Magnam dolorem aliquam velit maxime. Rerum debitis veniam autem quod aut qui quidem. Dolore eaque qui. Est voluptas inventore. Nesciunt dolor voluptatem ipsam omnis.\n\nLibero ut maxime non sed nobis. Quis assumenda quidem eveniet ex. Accusantium porro est adipisci ullam. Fugit neque vel velit.\n\nIste consectetur dolor commodi blanditiis. Ullam culpa natus. Dolor pariatur sunt provident. Quis nam quasi corrupti magni quas quia esse eos.\n\nAliquid debitis possimus deleniti omnis voluptate ipsam. Repellendus sapiente incidunt voluptas iusto et aut sed dolorum. Ea qui veniam sit cupiditate. Soluta rem ipsam tenetur error eligendi facilis. Nisi error repudiandae.",
                            Title = "Example Paragraph 14",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 15,
                            Content = "Suscipit minima asperiores pariatur vel iure sed assumenda dolore. Dolor et et facere aut ut vel et. Maxime sint ad. Qui doloremque unde corporis tenetur autem. Ut at a perspiciatis illum.\n\nEa ipsa quod aspernatur voluptatibus nemo dolore esse corrupti sint. Voluptatem nisi a ducimus autem deleniti dolor omnis cupiditate recusandae. Corrupti in a alias ex quidem.\n\nNon fugiat et consectetur non. Quia cupiditate sapiente sequi. Aut culpa sint doloribus corporis expedita facilis rerum odit.\n\nQuasi velit id. Impedit debitis eligendi ut nulla eum deleniti rem. Voluptas aut aut. Qui dicta dolores qui saepe architecto aut ut fugiat quas.\n\nQuia eum est. Minima beatae aspernatur tempore et et. Quasi ut et consequuntur sed animi et. Hic vel quia atque perferendis. Voluptas magni possimus aperiam.",
                            Title = "Example Paragraph 15",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 16,
                            Content = "Voluptatem est dicta quo nisi sint ipsa sed enim. Voluptatum optio dolores quasi saepe fuga. Qui mollitia voluptates qui qui placeat voluptatum autem doloremque. Eveniet et et perspiciatis aliquid qui ipsa est. Ut accusamus totam officiis culpa sint error.\n\nEligendi et cum eum quia sed laborum magni. Architecto in natus et expedita. Placeat libero dolor eos dolorem dolores et occaecati architecto. Ipsa exercitationem inventore blanditiis soluta perferendis ipsum libero non et. Nulla ut quis modi in ea. Mollitia eveniet quia quia fugiat aut maxime.\n\nAut et rerum nam voluptatem iste ducimus enim. Odit voluptatum delectus velit dolor et dolores. Facilis natus libero voluptatem illo provident porro necessitatibus possimus aut. Quibusdam est eligendi.\n\nQui est cum quae consectetur ea quae provident sapiente. Deserunt aut impedit adipisci nam eveniet nesciunt eos exercitationem. Qui possimus veritatis vel et aut facere.\n\nVoluptas voluptatum et sed quos. Enim expedita id aut est. Sit repellat voluptas molestiae quasi quia autem voluptatem et sit. Quae excepturi quasi laborum labore id non optio maiores. Et est dolorem est est temporibus.",
                            Title = "Example Paragraph 16",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 17,
                            Content = "Soluta qui in deserunt. Fuga omnis dolore odit accusamus sapiente sunt inventore illum optio. Et itaque dolores consequatur non. Voluptatem quo dolorum a eaque iste architecto molestias.\n\nQuia quis nesciunt suscipit et quae beatae rem illum. Eligendi eum ut sit. Aut saepe fugit sit. Aut atque velit deleniti id velit et eligendi. Eum in nemo odio aut. Ullam iste libero sint sit neque accusantium error quis.\n\nMagni minima dolor qui magnam rerum odit fugit repellat laboriosam. Qui et vitae et. Laborum magnam sint.\n\nId debitis quo sed. Enim voluptatem est vero. Eveniet ipsa vero ipsum molestiae blanditiis quia sed vitae. Facere incidunt animi sit nisi distinctio suscipit et voluptas et.\n\nOfficia illo aut pariatur. Aut amet non architecto explicabo molestias aut inventore quidem eaque. A dicta dolorem sit mollitia enim quo.",
                            Title = "Example Paragraph 17",
                            WikiPageId = 2
                        });
                });

            modelBuilder.Entity("wiki_backend.Models.StyleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ArticleColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleRightColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArticleRightInnerColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BodyColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterListLinkTextColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FooterListTextColor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WikiName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Styles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ArticleColor = "#526cad",
                            ArticleRightColor = "#3c5fb8",
                            ArticleRightInnerColor = "#2b4ea6",
                            BodyColor = "#507ced",
                            FooterListLinkTextColor = "#1d305e",
                            FooterListTextColor = "#233a71",
                            Logo = "/img/logo.png",
                            WikiName = "Your Wiki"
                        });
                });

            modelBuilder.Entity("wiki_backend.Models.WikiPage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleNote")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SiteSub")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WikiPages");

                    b.HasDiscriminator<string>("Discriminator").HasValue("WikiPage");

                    b.UseTphMappingStrategy();

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleNote = "Example RoleNote 1",
                            SiteSub = "Example SiteSub 1",
                            Title = "Example Page 1"
                        },
                        new
                        {
                            Id = 2,
                            RoleNote = "Example RoleNote 2",
                            SiteSub = "Example SiteSub 2",
                            Title = "Example Page 2"
                        });
                });

            modelBuilder.Entity("wiki_backend.Models.UserSubmittedWikiPage", b =>
                {
                    b.HasBaseType("wiki_backend.Models.WikiPage");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewPage")
                        .HasColumnType("bit");

                    b.Property<string>("SubmittedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("WikiPageId")
                        .HasColumnType("int");

                    b.HasIndex("WikiPageId");

                    b.HasDiscriminator().HasValue("UserSubmittedWikiPage");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("wiki_backend.Models.Paragraph", b =>
                {
                    b.HasOne("wiki_backend.Models.WikiPage", "WikiPage")
                        .WithMany("Paragraphs")
                        .HasForeignKey("WikiPageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WikiPage");
                });

            modelBuilder.Entity("wiki_backend.Models.UserSubmittedWikiPage", b =>
                {
                    b.HasOne("wiki_backend.Models.WikiPage", "WikiPage")
                        .WithMany()
                        .HasForeignKey("WikiPageId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("WikiPage");
                });

            modelBuilder.Entity("wiki_backend.Models.WikiPage", b =>
                {
                    b.Navigation("Paragraphs");
                });
#pragma warning restore 612, 618
        }
    }
}
