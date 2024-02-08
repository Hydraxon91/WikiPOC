﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using wiki_backend.DatabaseServices;

#nullable disable

namespace wiki_backend.Migrations
{
    [DbContext(typeof(WikiDbContext))]
    partial class WikiDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Content = "Velit unde non eos. Cupiditate delectus perferendis culpa. Amet sequi odit eveniet.\n\nNon iure laboriosam dolore a dolorum vero. Eaque qui numquam rerum sit ut nemo. Et beatae explicabo molestiae quo placeat et.\n\nQuo sit ad asperiores sint deserunt blanditiis. Aperiam aperiam aut quam voluptas aut id sapiente. Neque soluta voluptatem a sed nobis in minima soluta. Nesciunt ut alias id voluptas voluptas nihil dicta est aspernatur. Aperiam illo voluptatibus rerum non dolorem et est maxime. Animi vel dolores.\n\nLaudantium repudiandae temporibus porro nulla unde aut molestiae. Accusantium consequatur veniam odio rerum vitae necessitatibus. Corporis molestias voluptatum autem ad quos voluptas et eligendi quis.\n\nQuia architecto laudantium. Ut voluptatem fugit doloribus ex. Beatae nihil qui nobis veritatis voluptates similique ut inventore. Alias aut alias adipisci qui deleniti et consequatur soluta autem.",
                            Title = "Example Paragraph 3",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "Nulla nihil minima. Enim quia enim minus corporis eius corrupti eius. Pariatur quisquam omnis praesentium at.\n\nPorro optio qui. Necessitatibus quis veritatis recusandae qui praesentium. Nam ad asperiores nisi incidunt est molestias aut nesciunt quas. A perspiciatis perferendis beatae eos est soluta aliquid aut minus. Vitae nostrum cupiditate.\n\nNulla nesciunt magnam maiores velit porro suscipit dolore. Nesciunt quis veniam molestiae molestiae perspiciatis. Nihil quibusdam quisquam enim cupiditate amet eum. Consequuntur est asperiores ducimus eligendi rerum facere reprehenderit quibusdam earum. Deserunt vel ad eos corrupti aliquam dolores eaque ipsa id. Sint et sunt laboriosam quo architecto.\n\nNisi dolorem voluptatem qui temporibus quasi. Repellendus id nesciunt iure dignissimos. Veniam quo reprehenderit dolores. Voluptatem aliquid rerum. Sed veniam fugit. Facilis numquam nulla necessitatibus labore enim omnis officia.\n\nConsequuntur incidunt qui. Necessitatibus est nihil dicta impedit. Sequi molestias quae blanditiis et.",
                            Title = "Example Paragraph 4",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 5,
                            Content = "Veritatis accusamus perferendis earum iusto sunt praesentium occaecati reiciendis. Illum a vel rerum id. Dolor velit in quam qui commodi odit optio ab voluptatem. Harum quia minima ut sed.\n\nArchitecto non sit aut tenetur accusamus voluptates et soluta et. Eligendi est ipsum saepe nostrum reprehenderit nam culpa asperiores. Facere ut possimus aut ea excepturi soluta voluptatem molestiae nobis. Est repellat optio.\n\nEt qui possimus adipisci praesentium itaque ut dolorem deleniti voluptas. Quidem sapiente tempore provident quaerat. Quis officia blanditiis iste consequatur sit velit facilis. Id deserunt saepe rerum non ex odit est atque recusandae. Voluptatum saepe ad totam fuga in delectus aut.\n\nTotam voluptas voluptatum corrupti commodi ut illo non. Ad rem qui nostrum a odio dolorem commodi recusandae sint. Nostrum sequi quisquam mollitia autem. Nobis qui et aspernatur. Et sed a. Consequuntur minima quia.\n\nAccusantium architecto explicabo rerum voluptatum accusantium est eos accusamus saepe. Modi voluptatem deserunt autem qui. Atque debitis enim delectus ab delectus et. Voluptas in aut et.",
                            Title = "Example Paragraph 5",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 6,
                            Content = "Quo ut in asperiores facilis ratione est quaerat accusamus aperiam. Ex quam labore. Ab voluptatibus eos inventore cum laborum voluptates quos nobis eius. Rerum eos corporis in et nobis sapiente sint aut optio.\n\nDolores et fuga laboriosam aperiam voluptas. Optio et eius dolores qui omnis suscipit possimus asperiores eaque. Distinctio doloremque facilis corrupti. Sapiente nostrum nesciunt rerum saepe ipsa molestiae praesentium praesentium. Officia distinctio quibusdam cum ut vero sint doloribus sed illo.\n\nInventore ipsam et. Atque non voluptatibus suscipit aliquid amet maiores dolor ad. Ipsam explicabo nemo voluptates nobis animi porro expedita nesciunt.\n\nEos tempore et. Quo et sed labore quod a tenetur inventore. Rem aspernatur inventore ut voluptatum qui necessitatibus est laborum. Quidem consequuntur quia tenetur.\n\nReprehenderit dolorem inventore at qui excepturi iure. Sed reiciendis asperiores minus autem alias rem. Expedita quae corporis placeat magnam dolor eos animi odit. Et nihil repellat corrupti soluta voluptas. Est ea voluptas voluptatum praesentium vitae repellendus et. Quia non ullam eaque eos omnis qui fugit sequi qui.",
                            Title = "Example Paragraph 6",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 7,
                            Content = "Ad et vitae. Cupiditate nobis occaecati quis. Beatae inventore recusandae sit est atque.\n\nDoloremque ducimus non quis facilis. Qui a asperiores. Alias assumenda sed consequatur. Ullam quasi veniam exercitationem asperiores dolorem consequatur.\n\nVoluptatibus omnis sunt. Accusantium aut aut voluptatem libero et aut unde quisquam. Perspiciatis voluptatem ut qui nihil dolorem amet. Molestias explicabo placeat minima iste aut sit nesciunt totam omnis. Earum qui tempora amet accusantium quas et minus voluptatem ipsum. Illum eos cumque in dicta non vel.\n\nUnde doloremque aliquid quia ipsa similique et nulla iste explicabo. Sequi voluptatum nulla occaecati sit asperiores et temporibus eum cum. Minus eius est possimus asperiores labore illum fuga voluptatibus. Est et suscipit ut.\n\nReiciendis voluptas ut nisi excepturi sed. Sit error ullam distinctio suscipit consequatur doloremque et. Enim modi consequuntur. Non quia sit ut. Adipisci iusto sunt et perspiciatis voluptates eum suscipit mollitia. Qui fuga ullam animi quo deleniti.",
                            Title = "Example Paragraph 7",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 8,
                            Content = "Autem possimus quisquam molestiae omnis quibusdam totam. Minus tenetur rerum est at dolorem soluta. Consequuntur et et.\n\nQui magni ut odio soluta ut aut. Ut ducimus occaecati atque. Aperiam amet atque fuga repellat et et id aperiam minus.\n\nEt hic doloribus modi exercitationem eum ut ut quia. Cum ut vitae beatae rerum incidunt. Atque et quidem quis non tenetur sit dignissimos molestias sint.\n\nEsse non quas reprehenderit. Ea et et et in molestiae et possimus. Laudantium et est voluptas neque ad natus possimus voluptatem.\n\nQuia autem dolorem ipsam nihil et autem pariatur fugiat. Facilis aut et natus consequatur nihil quod ducimus quam consequatur. Eveniet et pariatur consequatur ullam delectus minus inventore aliquid.",
                            Title = "Example Paragraph 8",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 9,
                            Content = "Non fugiat consequatur quia atque excepturi quo illum natus iste. Consectetur eaque maxime accusamus. Commodi dolores rerum omnis cumque nihil. Sed praesentium a adipisci beatae id placeat cumque accusantium qui. Illo exercitationem qui architecto fuga iure.\n\nEius voluptatem cupiditate officiis laborum qui. Quia fugit ex non in est et quam. Omnis rerum exercitationem odit soluta quisquam corrupti. Et voluptas beatae labore labore eos ipsam natus. Ut ratione dignissimos atque mollitia sed corporis unde consequuntur consequatur. Rerum et debitis qui mollitia quia saepe perferendis aliquam.\n\nCommodi illo numquam ipsam qui occaecati hic nostrum. Veniam maxime cum ratione dolore perspiciatis. Ad fugit quis quia voluptatem culpa ipsa beatae omnis assumenda.\n\nModi aut commodi assumenda. Quidem atque totam unde ab et natus reprehenderit hic. Dolores omnis et. Odit aliquid quo et qui voluptate ab corrupti. A molestiae ea sed ut iusto nihil maiores excepturi. Tempore eius sit dolorem.\n\nDeleniti aut voluptas. Amet repellat velit optio vel voluptatem accusamus dolorum et. Qui a nihil qui eveniet aut quia et.",
                            Title = "Example Paragraph 9",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 10,
                            Content = "Qui ratione distinctio voluptatibus corrupti dolore esse occaecati. Fugiat tempore ea autem nihil autem nam. Aut consequatur autem molestiae. Et et ullam.\n\nHarum et qui cum voluptas quia dicta nulla eius. Ullam non sit quidem quos ut aperiam sunt quia. Officiis consequuntur quam et cupiditate voluptas et excepturi et doloremque. Cupiditate asperiores at voluptatibus maxime expedita qui ipsa delectus. Neque non sit quia quam voluptas. Et repudiandae rerum eveniet est sunt sit sequi.\n\nEx consequatur alias provident ipsa rem minima recusandae autem dolore. Expedita illum commodi nulla explicabo odit maiores temporibus. Consequatur non tempore dicta mollitia incidunt fugit nihil. Possimus autem sed nostrum ut occaecati rerum id. Ab eaque ut. Aut quibusdam in.\n\nLaudantium aliquid aut et voluptas provident harum quisquam. Itaque ut vero. Officia labore est recusandae rem qui dignissimos sed et. Dolores dolorem quidem enim nam inventore repellat. Quasi ut aut eos voluptatem dolor. Id magnam dolor nobis ad.\n\nPlaceat distinctio quis. Eligendi nulla ut optio. Nam aliquam sit et hic. Quaerat incidunt rerum nobis enim eos neque numquam repellat. Assumenda consequatur eius nulla ut voluptatibus et minima repellat aut.",
                            Title = "Example Paragraph 10",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 11,
                            Content = "Et esse a nulla eos et necessitatibus. Harum sapiente magni excepturi quidem tempora dolores. Rerum aut reprehenderit asperiores voluptatem distinctio quia voluptas quo reprehenderit. Ut deserunt consequuntur qui praesentium neque ullam magnam dolores. Qui et in omnis magnam illum deleniti incidunt modi.\n\nVelit quaerat quaerat sed qui. Asperiores modi quasi sit eum. Quo hic odio. Maxime nemo consequatur consectetur delectus labore. Non quo ad mollitia fugiat eos velit quae. Temporibus optio et fugit sit explicabo.\n\nRepellat et quo aut iusto asperiores earum debitis dolores. Illo optio veritatis rerum minus eum laudantium. Est cumque in. Labore eum est totam deserunt iste.\n\nMollitia sit quasi. Nihil doloremque voluptas sed dicta quis fuga iure eius. Aperiam incidunt necessitatibus quia perferendis qui est doloribus.\n\nNon tempora occaecati fugit est quia qui vero. Et reprehenderit quam. Maxime aut amet consequatur libero ipsam fugit voluptas. Minima molestiae dolor quia sit ipsa voluptatem. Voluptatem qui in quis quis qui quod. Veniam a illo consequatur quis reiciendis atque quo molestias.",
                            Title = "Example Paragraph 11",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 12,
                            Content = "Ut doloremque mollitia sequi doloremque in. Delectus dolorem illum amet labore quas ut. Iste quo hic rerum at quaerat officiis ut voluptas. Sit ipsam necessitatibus ad quos.\n\nSapiente veritatis tempore maiores. Omnis ut vero rem nisi consectetur. Earum excepturi qui consequatur corporis quos amet vel. Molestiae aliquam iure ab nisi. Rerum aut quae aspernatur non.\n\nAssumenda modi hic temporibus doloremque unde. Neque sunt ipsum rem sunt quis asperiores. In in nihil commodi blanditiis. Debitis et rem unde hic et et dicta. Expedita minus asperiores necessitatibus error omnis labore. Culpa officia eum aspernatur.\n\nOdit porro et harum. Consequatur assumenda aperiam tempora tenetur autem quam. Eligendi culpa consequatur assumenda dignissimos ullam dignissimos ut.\n\nAlias maiores qui earum ea recusandae veniam explicabo excepturi. Et id officiis. Voluptatem porro rerum quia eveniet nihil. In nisi quas quos pariatur rerum.",
                            Title = "Example Paragraph 12",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 13,
                            Content = "Nisi qui asperiores. Illum inventore qui rerum quos porro cupiditate vitae. Architecto voluptas quod placeat accusamus aspernatur quod.\n\nFacere a iure quis id officiis voluptatibus. Voluptatem amet et quia a. Modi occaecati sit at sed quidem maxime. Magnam debitis aut dolore facere harum asperiores. Quas distinctio officia laudantium id. Voluptatum in nam aut nam et qui culpa eos.\n\nNesciunt at modi voluptate et repudiandae quo placeat. Voluptate aliquam ea. Velit explicabo dolore vel delectus mollitia ad.\n\nIn ut provident omnis laudantium nesciunt sed nisi provident. Sit maiores omnis ratione vel accusamus unde veritatis. Itaque quae aut reprehenderit eos suscipit aut id. Sit temporibus rerum ducimus nobis ratione harum ut.\n\nIllo odit dolore et esse quia laudantium repellat. Alias reprehenderit libero sint dolor doloribus sint. Totam vel perferendis impedit quis. Ut similique id animi sed laboriosam nostrum.",
                            Title = "Example Paragraph 13",
                            WikiPageId = 1
                        },
                        new
                        {
                            Id = 14,
                            Content = "Neque temporibus non officia nisi explicabo et. Consequatur amet eos et vitae hic rerum et inventore. Eaque et atque atque. Quis officiis id asperiores in velit est. Doloremque quidem dolorem vitae molestias fugit nobis a mollitia. Dolorum voluptate quis eligendi voluptatem itaque voluptas dolorem ut.\n\nQuod qui laudantium aspernatur. Vero autem quos iusto corporis quia voluptatem amet dolor ab. Omnis et voluptate pariatur eligendi neque accusamus.\n\nVoluptatibus id repellat similique id asperiores harum animi incidunt et. Harum tempore autem repudiandae assumenda consectetur et aut nesciunt laudantium. Harum non aut illum ex nihil. Autem nesciunt tempore a. Necessitatibus enim laudantium accusamus expedita laudantium voluptas.\n\nIste modi est. Ut in officia officiis dolor qui. Asperiores architecto qui animi at voluptatem et. Libero molestiae alias excepturi mollitia.\n\nAdipisci earum autem quo. Rerum at laboriosam. Rerum dignissimos est sed voluptate ratione praesentium itaque. Quis ab suscipit velit ut quis rerum enim voluptas occaecati.",
                            Title = "Example Paragraph 14",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 15,
                            Content = "Soluta rerum tempora omnis distinctio ea tempore. Excepturi sit suscipit neque occaecati quisquam. Non eligendi consequatur velit neque sed ut consequatur provident repellat. Atque saepe tenetur omnis quo occaecati dolores doloremque ut. Molestias vel est tempora repudiandae nesciunt sint sit omnis eius. Assumenda illo repellat id et ratione vel ea.\n\nDoloremque iusto nobis. Quia culpa aut necessitatibus doloribus veniam totam ut nihil incidunt. Et amet vero perferendis.\n\nIllum molestiae consequuntur laborum suscipit voluptatum est. Voluptatem et ratione. Voluptatum tenetur soluta placeat voluptatem rem odio dolorem asperiores. Modi aut voluptatem consequatur quis. Totam suscipit et sed porro suscipit veritatis. Vel sit autem nulla non at.\n\nQuisquam in magnam optio voluptatem consequuntur quis rerum culpa culpa. Accusantium hic odit ut labore et pariatur quisquam eius iusto. Aut odio magnam eos quam ab. Quo quia quia. Et eveniet alias quasi harum voluptatum excepturi quis itaque repellendus. Iusto qui nemo.\n\nVeritatis itaque ipsam odio. Neque ipsum est soluta recusandae delectus. Dolor nihil hic aut fugiat ullam ut corporis fugit. Provident eius quos. Quibusdam accusamus rerum vero quis laudantium et ut placeat ut. A vero sed sunt esse nesciunt hic et et.",
                            Title = "Example Paragraph 15",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 16,
                            Content = "Libero quia placeat veniam officia eos hic. Consequatur sit rerum corporis tempora possimus ullam doloribus dolorum. Et quae et et quam rerum. Vel fuga eum accusamus tempora voluptas.\n\nRepudiandae assumenda voluptatem ad voluptas saepe error. Iste totam voluptas repudiandae aliquid atque. Nulla voluptas dolor non velit. Maxime rem modi et non.\n\nEnim veritatis molestiae ut minima sint ut libero inventore. Distinctio aspernatur est debitis qui tenetur distinctio. Magnam vero veniam voluptatum est in.\n\nRerum qui illo suscipit. Incidunt expedita architecto et tenetur et. Molestiae magnam voluptatem sunt placeat eos quo ipsam accusantium iste. Consequatur impedit sed optio facilis et earum odio. Fuga earum aut blanditiis quis recusandae facere eum cumque architecto.\n\nVel sint neque aut nihil libero totam laboriosam pariatur earum. Corporis impedit soluta dicta facilis. Earum dolor cum optio natus. Enim non similique veritatis qui delectus occaecati error est. Vitae ut est vero veniam id. Dolorum ipsum velit esse quae inventore voluptatibus omnis.",
                            Title = "Example Paragraph 16",
                            WikiPageId = 2
                        },
                        new
                        {
                            Id = 17,
                            Content = "Mollitia voluptatem accusamus minima doloribus. Quibusdam corrupti vel optio harum veniam et exercitationem ratione. Minus voluptatem non vel adipisci doloribus earum voluptas excepturi. Reiciendis libero dolores dolor in voluptatem at in.\n\nVoluptas est ea et blanditiis magnam aliquam. Doloribus optio officiis nulla est hic ea animi vero. Et aperiam sint consequatur.\n\nQui vitae nostrum. Natus at temporibus reiciendis. Voluptates quas est ut ea aut. Sunt temporibus autem id officiis quia exercitationem inventore ipsa praesentium.\n\nCulpa qui provident culpa sunt delectus architecto tenetur sunt numquam. Harum et ullam. Eum voluptatem autem architecto delectus dolorem. Magni est vel ipsam provident assumenda voluptatem.\n\nQuos enim ut natus ipsum voluptas. Voluptas ut corporis rerum. Aperiam occaecati labore cum in veniam quam. Voluptatem distinctio natus doloremque nihil sit qui velit. Quam ipsam rerum dignissimos dolores ut enim voluptatem esse. Molestiae mollitia magnam iure expedita.",
                            Title = "Example Paragraph 17",
                            WikiPageId = 1
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
                        .HasColumnType("nvarchar(max)");

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
