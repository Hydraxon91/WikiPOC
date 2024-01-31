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
    [Migration("20240131104703_UpdateSeedingControlledParagraphs")]
    partial class UpdateSeedingControlledParagraphs
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
                            Content = "Quia aut labore. Enim aut impedit. Deserunt qui voluptas autem est culpa neque magni at. Perspiciatis et ad officiis dolor qui quo voluptatibus. At molestias voluptatem id veritatis quae ut.\n\nAtque et quo et. Pariatur omnis dolore odio quae dolor. Et consequuntur et saepe est labore ut ut doloribus nam. Maiores qui minima praesentium voluptatibus recusandae.\n\nEnim in odit iure magnam veniam corporis facilis dignissimos et. Dolores quod facere. Laudantium sed ea sed repudiandae non quo. Aut ad rerum odio dicta.\n\nIllo autem exercitationem incidunt et voluptates et. Maiores ut enim sint qui dicta enim rerum. Similique suscipit commodi nihil assumenda et dolorem vel. Aut totam magni reprehenderit quis nemo.\n\nOmnis tenetur qui explicabo sequi aperiam perferendis et sunt officiis. Laudantium iste delectus. Magnam ullam occaecati voluptas molestiae maxime et dolorem.",
                            Title = "Example Paragraph 3",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "Explicabo qui placeat. Omnis voluptatem fuga cupiditate. Quo dolor quidem quis voluptatem ea. Qui assumenda impedit iure velit in eum sunt provident et. Consequatur vitae et cum suscipit et ut explicabo occaecati.\n\nIpsum sit adipisci quis aut impedit ducimus ea rerum. Omnis libero qui qui sit odit et est autem. Est sit nam laborum eveniet soluta. Atque qui ipsam consequuntur est accusantium aspernatur culpa praesentium. Sint et illum nobis ipsam iure molestiae enim voluptatibus. Voluptates in illum itaque magnam sequi aut iusto.\n\nSit ut minima et accusantium magnam voluptatem porro. Sapiente atque beatae optio saepe quia harum. Eius et pariatur dicta placeat voluptate necessitatibus tempora. Expedita pariatur iure nesciunt quas aut dolorem. Esse officiis incidunt doloremque enim beatae necessitatibus magni porro amet.\n\nTemporibus optio minus et eum perspiciatis tempore soluta. Incidunt ex nihil ratione et tempora. Sapiente similique dolorem temporibus. Amet inventore et natus perferendis earum.\n\nAt ea quasi. Nulla aut ipsum quia perferendis animi dicta. Quaerat tempore aut. Sunt quam minima tenetur sit dolores ut cumque non consequuntur. Harum praesentium et sit commodi voluptatum nisi quaerat. Adipisci fugiat et nesciunt dignissimos voluptatem molestiae quibusdam quaerat autem.",
                            Title = "Example Paragraph 4",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "Corporis distinctio consectetur eaque ipsum atque vitae rerum. Molestiae voluptas consequatur harum rerum cupiditate. Molestias occaecati provident eos ad quia est sunt enim et. Omnis repudiandae id id et tempora quaerat in ut tempora. Corrupti magni accusamus.\n\nDistinctio molestiae necessitatibus. Labore aliquid cumque laudantium explicabo nihil. Alias perspiciatis ut modi quae consequatur earum. Harum veritatis esse iste quo quaerat. Quia rerum enim veniam sit in nemo sed ipsam voluptatum.\n\nMinima quod quas sint et neque nemo iure omnis ducimus. Repudiandae est pariatur voluptatem maxime. Ut perferendis recusandae nam voluptatem debitis harum dolore id facere. Alias similique sit non repudiandae suscipit. Qui recusandae fugit dolorum dolores et eveniet voluptate quidem. Adipisci provident explicabo deserunt ipsa.\n\nAutem veniam voluptatem est. Error ad amet. Similique voluptas quidem rerum iure vel deleniti. Enim excepturi qui molestias adipisci aspernatur. Odit sit explicabo quos delectus quos qui voluptate deleniti.\n\nQuia commodi repudiandae vero aliquam beatae optio. Natus sed nihil voluptatem debitis labore et odio at. Ducimus fuga at officiis qui. Reprehenderit aliquid ratione fugit enim molestias.",
                            Title = "Example Paragraph 5",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 6,
                            Content = "Voluptate consequatur error molestias qui non. Magnam quia unde. Voluptatem non rem id.\n\nDeserunt atque nisi dolores est dolor nemo perferendis quia. Minus voluptate nam consequuntur excepturi consectetur eveniet. Aut aperiam quibusdam nam doloremque magni labore eum.\n\nDucimus laudantium fuga a. Possimus veritatis voluptate itaque aut necessitatibus nemo atque. Recusandae repudiandae a fugiat deleniti architecto cupiditate tempore et. Autem at quos eaque qui quidem ut rem voluptatem vel.\n\nVeritatis accusamus quas quis provident et omnis vel aspernatur. Dolorem a et expedita. Non quam maiores nisi in. Nihil quos dolores minus qui placeat voluptatem vero dicta. Enim reiciendis totam consequatur. Quia expedita dolorem.\n\nVoluptas dolor rerum nihil dolor voluptatem dolor id. Quis est vel qui qui autem porro labore beatae non. Autem et vitae enim laborum quas dolorum dolore debitis quia. Dicta ipsa eum sed adipisci iusto qui est vero cumque.",
                            Title = "Example Paragraph 6",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 7,
                            Content = "Magnam beatae rerum adipisci iusto et voluptate quod in. Amet ut et accusamus dolor culpa et in. Quia odit sequi quo incidunt perspiciatis deserunt sapiente. In aspernatur tempora nam et natus quae necessitatibus. Sed sit quae aspernatur soluta ipsum voluptates vel officia incidunt. Sed tenetur omnis assumenda atque repellendus ipsa.\n\nCommodi et distinctio magni culpa. Quasi neque consequatur sit aut. Facilis similique excepturi dignissimos quos maxime molestias soluta. Et in dolorum deleniti. Excepturi dolorem impedit animi omnis perferendis ullam quidem est.\n\nIn quo voluptatem et eum est. Praesentium aut maxime eum ut iure sint. Vel animi optio ut et. Facilis porro sunt id cupiditate sint. Architecto quo omnis.\n\nEt rerum velit quos amet vero provident omnis nihil distinctio. Omnis et expedita in illum non deserunt reprehenderit in cumque. Ea esse illo eos sapiente. Sed doloribus eveniet nulla eius recusandae tempora sunt est est.\n\nLabore in esse. Quas nihil illo ducimus laborum voluptas sunt voluptas. Eaque est dicta ut.",
                            Title = "Example Paragraph 7",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 8,
                            Content = "Consequatur rerum quis id quae amet autem quibusdam recusandae. Qui id quos minima nostrum. Dignissimos fuga necessitatibus quia. Magnam fuga sequi consectetur dolores et. Necessitatibus iste consequuntur.\n\nMolestiae ea voluptatem dolores adipisci rerum magnam et est consectetur. Facilis incidunt sequi eum enim et non qui odit quis. Dolores possimus aut et expedita et magni. Voluptatum aut voluptatibus laudantium voluptas in natus fugiat laboriosam et.\n\nMollitia et numquam sed excepturi sit enim reprehenderit eveniet. Eaque laudantium illo saepe praesentium inventore consequatur libero. Voluptas ipsum reiciendis eaque eum inventore voluptas est mollitia doloribus. Et quasi aut quam voluptas animi. Eum saepe quo velit sit ut et. Odio asperiores autem in et.\n\nUllam occaecati iusto ut aut perspiciatis velit dicta consectetur. Quisquam sed ad facilis cupiditate rerum perferendis veniam. Aliquid distinctio harum sunt. Voluptates error voluptas eos et voluptas aspernatur error veniam et. Aperiam qui rerum asperiores non iure natus consectetur voluptatem. Aut itaque beatae nobis provident officia earum et.\n\nRerum sed et eaque qui nostrum consequatur. Reiciendis quia temporibus consequatur qui quia nemo et quis et. Aliquid quae voluptatibus omnis. Facere cum est.",
                            Title = "Example Paragraph 8",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 9,
                            Content = "Deserunt sunt quaerat quo exercitationem quod. Aperiam laborum nisi fuga ex numquam. Voluptatem veritatis architecto quae reiciendis quaerat adipisci laudantium. Aut voluptas inventore.\n\nVoluptates aperiam magnam omnis aut nemo. Ut iure ullam sint aut consequuntur voluptatum similique. Dolorem sit similique qui est unde et animi ut.\n\nUllam sunt quo nihil praesentium alias saepe ab omnis. Porro consectetur est impedit amet doloremque. Similique corporis et quo. Expedita consequatur vero aspernatur.\n\nVel velit itaque molestias quisquam quis esse. Delectus iure cupiditate corrupti ratione est distinctio et porro. Vitae in aspernatur totam. Id et non aspernatur dolores consequatur. Ipsam exercitationem quia maiores sequi enim.\n\nRerum alias totam mollitia. Culpa itaque velit nisi iusto praesentium. Nemo et quis in nihil asperiores id quos quasi.",
                            Title = "Example Paragraph 9",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 10,
                            Content = "Adipisci sint officia dolor illo aliquid. Fuga soluta suscipit qui tempore. Sit delectus eos sed. Aliquam aliquid laudantium illum eos voluptas tempora est.\n\nUt ea natus provident. Necessitatibus amet illo. Exercitationem exercitationem est odio temporibus officiis. Quos reiciendis id officiis sequi. Quo sint quam. Qui esse quam ex enim.\n\nA laboriosam nulla. Consequatur aperiam suscipit. Unde reiciendis in similique ut quas ullam.\n\nNatus et in ea sit sed exercitationem veniam et qui. Sint dignissimos sapiente sint nostrum eos cumque esse asperiores. Labore est iste dignissimos earum consequatur et. Illum reiciendis veritatis occaecati dolores praesentium sed amet. Sapiente id porro eum unde doloribus officia ut nostrum.\n\nIllo impedit nihil architecto accusantium laboriosam earum qui. Voluptas tenetur fugiat rerum est a. Non tempora non est placeat accusamus architecto rem quia. Aut omnis eum adipisci quibusdam.",
                            Title = "Example Paragraph 10",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 11,
                            Content = "Qui aut qui recusandae explicabo enim. Tempore odit doloribus quidem et recusandae quis nostrum optio. Reiciendis excepturi debitis impedit quia ab repellendus.\n\nVero enim praesentium. Non molestiae ut ducimus nam doloremque. Est ut enim dicta et voluptatum voluptatibus est architecto molestiae. Eligendi aspernatur ut asperiores blanditiis ab. Nulla fuga non. Ratione adipisci possimus dolor.\n\nConsequatur molestias beatae voluptate error. Quia itaque et veritatis. Harum qui quam explicabo omnis sit. Id dicta ad natus.\n\nNisi nulla ut et. Voluptate consequatur nostrum iusto et vero. Et et voluptas quasi dolores et et ab. Ut et accusamus ad incidunt non et quia corrupti. Doloribus quis corporis enim ut. Sunt distinctio adipisci hic voluptates.\n\nPossimus illo velit quaerat dolorem rerum ut. Ut ad earum harum iusto nihil et amet eius. Accusantium est dolorum eos velit consequuntur deleniti voluptates. Facere molestias aut nihil excepturi vel.",
                            Title = "Example Paragraph 11",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 12,
                            Content = "Quae repellat et autem. Reiciendis eum nisi iste laboriosam. Tenetur inventore tempore alias voluptas nisi.\n\nFugiat itaque qui voluptatem. Est ut sed eligendi dolorem inventore suscipit dolorem ut. In eaque velit et. Consequuntur ullam voluptatem ullam velit qui. Eligendi earum magnam a nisi non. Est cumque illum temporibus.\n\nQuod facilis nostrum exercitationem atque. Atque illo quae sequi. A laborum assumenda aut ea. Et nisi incidunt non.\n\nAt maxime quas qui voluptates aut. Rerum animi ducimus voluptas tenetur. Nisi commodi omnis hic veniam nostrum autem animi est illo. Qui unde reiciendis qui id minima velit. Sequi doloremque aut. Impedit laborum ea libero eius.\n\nRatione vitae tempore aspernatur debitis. Id voluptas recusandae. Et accusamus suscipit.",
                            Title = "Example Paragraph 12",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 13,
                            Content = "Molestiae doloremque repellat in in id ut illo fuga qui. Suscipit nihil animi iusto laborum saepe quae illo iure eum. Nulla consequatur sit aut nihil et accusantium. Officia qui at modi aut.\n\nEveniet enim eius expedita quaerat animi velit dolores eius. Enim laboriosam sequi quaerat quisquam incidunt recusandae et neque. Earum repellat et. Architecto aut dolor. Pariatur earum officiis laborum veniam animi vero amet. Quidem alias consequatur error sapiente adipisci iste quo.\n\nVoluptatibus et non unde veniam sit quas. Libero doloribus adipisci. Labore ut enim voluptates voluptatem magni est commodi non.\n\nAut voluptas aspernatur commodi consequatur veritatis quia minima quae corporis. Repellendus suscipit id molestias. Dignissimos quasi et voluptatem eligendi repellendus non animi amet. Neque quisquam nemo fugiat qui dolores. Et et molestias autem voluptas consequatur ut et qui et.\n\nEaque non dolores dolorem et temporibus sed tenetur fuga et. Harum provident magnam dolor dolorem. Iste similique quas perferendis. Quod earum asperiores sit rerum et ratione temporibus et. Et possimus corrupti dolores aut aut aut enim laboriosam officiis.",
                            Title = "Example Paragraph 13",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 14,
                            Content = "Earum ut sed magnam ea molestiae porro error excepturi. Rem saepe quia soluta aperiam dicta et. Molestiae dolores facere sint rerum dolorem esse mollitia. Eius non et delectus ab dolorem sit. Maiores molestiae accusamus qui ut labore saepe quo.\n\nId adipisci minima deserunt quo rem in sint qui. Eum nisi quas quisquam. Dolor nesciunt laborum at quos eum nisi iste. Quidem maiores nihil illo magni vitae blanditiis rem. Sequi est labore qui et tempore ipsum neque.\n\nUt dolorem accusantium velit nobis autem nihil enim. Fuga labore laborum iste voluptatum excepturi et. Optio sit voluptatum. Nemo quibusdam vero aperiam suscipit eos commodi consectetur.\n\nMollitia unde impedit ducimus omnis consequuntur soluta voluptatum amet molestias. Veritatis labore voluptates distinctio necessitatibus sapiente quo et. Necessitatibus sed nam ducimus. Quibusdam omnis autem fugiat debitis expedita fugiat aut. Veritatis quia sed dolores quia ullam aut aut. Sunt quod voluptatem quaerat aut libero culpa omnis et vitae.\n\nOdio aperiam beatae autem sunt sit aliquam. Velit quibusdam expedita voluptate sit nisi adipisci. Odio enim maiores totam qui enim rem. Provident sit placeat maiores.",
                            Title = "Example Paragraph 14",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 15,
                            Content = "Sit accusantium voluptatibus dolorem sed dolorum nulla rerum ex. Quod voluptas perspiciatis non voluptatem odit reprehenderit ullam ut omnis. Eius et aliquam non tenetur laudantium commodi aut et. Sapiente ipsam voluptates. Est aut minus praesentium. Aut voluptatibus temporibus est vel laudantium.\n\nExercitationem officiis facilis repellendus qui est. Libero eaque distinctio rerum nobis. Sit quo delectus vero voluptate. Sit provident nobis soluta in. Atque sunt aut vitae blanditiis dolor id. A quis neque vero molestias et neque sapiente.\n\nOfficiis omnis vitae dolores similique hic. Eveniet itaque quia. Nihil quis est cumque sequi id quam dolorum. Et iste libero modi repellendus. Sequi omnis quisquam aut.\n\nAnimi facilis incidunt recusandae qui est. Assumenda cum voluptas in aliquam. Qui magnam laborum beatae autem mollitia. Ut unde ipsum. Qui vel autem porro. Est facilis cum possimus perferendis ut atque.\n\nTenetur iure reiciendis quaerat deleniti dolore repudiandae similique veritatis. Blanditiis dolorem sed. Similique est et ut qui officia repudiandae hic quibusdam.",
                            Title = "Example Paragraph 15",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 16,
                            Content = "Amet qui temporibus nam voluptates hic est. Omnis beatae quo assumenda accusamus adipisci blanditiis quibusdam in veniam. Mollitia molestiae impedit aut perspiciatis ipsum dicta ducimus suscipit. Facilis autem nesciunt quia aspernatur magni. Dolores incidunt qui minima dolore ea aut qui qui.\n\nDicta soluta sint debitis assumenda provident quibusdam error. Illo est repudiandae explicabo aliquid odit. Consequuntur vitae ipsum quis laboriosam et. Quia error beatae eum id. Amet et eligendi sequi quidem asperiores molestiae voluptate eum fuga.\n\nEa esse libero corporis quasi ab est maiores dolorem. Veniam vitae accusamus voluptatem facere officiis magnam ut impedit. Aliquam qui veritatis rem ipsa dolorem et. Provident similique et voluptatem. Et facere adipisci.\n\nAt ut pariatur cupiditate impedit molestiae fugit soluta quia saepe. Voluptates mollitia aut quis natus. Et accusantium sit ullam. Fugit quos aliquam voluptatibus tenetur eius. Molestias consectetur cumque commodi earum vero est sunt ut.\n\nOdio et qui saepe fuga eos minima nam provident. Quasi in quos autem tempora similique nobis pariatur animi officiis. Ut suscipit praesentium temporibus sit incidunt ut consequatur.",
                            Title = "Example Paragraph 16",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 17,
                            Content = "Sit velit consequatur pariatur similique. Quo et dicta reiciendis magni est sed et. Sunt laborum est.\n\nExplicabo est dolorem. Corporis praesentium placeat totam rerum et molestiae debitis. Autem tempora quam optio. Sint est provident inventore soluta consectetur. Mollitia omnis deserunt voluptate quo optio dolorum impedit et quis.\n\nMaxime consequuntur voluptatem ratione quia placeat corrupti maiores et. Omnis sit dolores et ex rerum blanditiis. Tempora sed eos laboriosam ratione minima vero nisi non asperiores. Eius ad quis pariatur ad quo ut voluptatem. Quia qui in eaque esse dolores. Omnis et modi.\n\nTenetur et nemo. Itaque qui ipsam. Ex nemo est et unde repudiandae omnis repudiandae pariatur ut. Reiciendis unde labore cupiditate quae molestiae qui blanditiis. Eum iste sunt eligendi sit repudiandae dicta unde dolorum. Possimus quidem doloremque quia itaque aspernatur expedita fugit.\n\nOmnis nulla sed. Vel iusto culpa quia. Dicta quo minus nemo voluptates dolor a quo. Assumenda aut quos quas facere et. Ut itaque dicta aut placeat facilis. Quia quia vero non id eos.",
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

            modelBuilder.Entity("wiki_backend.Models.WikiPage", b =>
                {
                    b.Navigation("Paragraphs");
                });
#pragma warning restore 612, 618
        }
    }
}
