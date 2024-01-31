using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class BogusParagraphs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "IntroductionParagraph", "ParagraphImage", "ParagraphImageText", "Title" },
                values: new object[] { "Debitis est quia quisquam ea. Et dolorem numquam dignissimos. Consequatur ea similique qui excepturi est. Aliquam doloribus quod ex nulla omnis eos voluptas qui possimus.\n\nEum aut dolore est eveniet ducimus. Voluptate velit est quia. Recusandae magnam ullam in perferendis est ea ipsa doloremque et. Assumenda magni aspernatur expedita amet rerum ipsum.\n\nEt suscipit ut ipsum quisquam assumenda. Et et iste occaecati nobis ipsam neque dicta. Accusantium maxime at sed sit cum illo nemo magni incidunt. Laboriosam beatae porro eos provident odit tempore eveniet fuga labore.\n\nAlias cumque sint. Non quasi impedit commodi totam quos. Voluptatum quos ea architecto delectus vero totam reiciendis.\n\nNecessitatibus culpa sapiente ducimus molestiae explicabo quasi voluptas. Quam corrupti soluta enim ut sed placeat velit et est. Exercitationem qui sed delectus fugiat commodi. Et rerum qui et omnis est. Eos fugiat cupiditate tenetur vel repudiandae quidem. Ad labore officiis aut voluptas illo et reprehenderit dolor.", false, null, null, "Example Paragraph 1" });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "WikiPageId" },
                values: new object[] { "Est ut distinctio sit vitae molestias vel recusandae. Commodi eum repudiandae numquam excepturi harum non vitae. Magnam dolorem velit eos maiores qui mollitia.\n\nVoluptas dolor sit quisquam laudantium eveniet accusantium esse cum. Blanditiis maxime quae neque. Molestiae est aut recusandae. At voluptate et commodi omnis eos omnis.\n\nSed magnam est debitis consequuntur qui laudantium. Voluptatem vero dolor at quisquam molestias et libero et expedita. Similique dolorem et eos doloribus repellendus quibusdam recusandae. Ipsa quisquam officiis aut cumque sed velit debitis vel non.\n\nIusto deserunt facere ea consequuntur omnis nostrum tempore fuga aut. Facere aut necessitatibus. Fugit officia amet et qui quibusdam. Quidem omnis autem possimus qui voluptas iure aut aliquid.\n\nEst doloremque vero laudantium asperiores laborum est deleniti consequatur doloribus. Est soluta nihil ullam animi aliquid incidunt nisi dolorem aut. Et quo magni quia consequatur fugit quo repellendus. Officiis quo mollitia ab dolorem. Qui delectus voluptatem blanditiis.", 2 });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "ParagraphImage", "ParagraphImageText" },
                values: new object[] { "Id est excepturi. Ipsam et omnis quae ipsa dolorum architecto quia qui corporis. Amet accusamus qui qui eum perspiciatis. Necessitatibus occaecati adipisci ut nulla repellat quia.\n\nSoluta eum deserunt. Voluptate cupiditate quo. Ipsum est officia ipsa provident debitis ut enim.\n\nTempore cum a ipsa rem. Accusamus corrupti aliquid nesciunt occaecati officiis. Aut laudantium dolorem. Modi eius fugit autem nobis. Nobis distinctio officia voluptas facilis vitae et odio excepturi maxime.\n\nAut quasi perferendis vel aspernatur repellat ut repudiandae. Nam explicabo sint suscipit error earum facilis a cupiditate. Accusantium fugit quo voluptatibus quasi est magnam aut eius voluptatem. Voluptatibus quod doloremque quibusdam expedita facilis sed rerum rem omnis. Placeat non mollitia odio corrupti. Eum qui ipsam ipsa et ratione commodi.\n\nSed corporis voluptatum iusto qui dicta iusto debitis exercitationem sed. Sapiente voluptates facere in impedit. Aut enim magnam qui atque libero aliquam. Veritatis eligendi similique hic odit commodi qui cum voluptas alias.", null, null });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "WikiPageId" },
                values: new object[] { "Ipsam et cum rerum et. Aperiam cumque consequatur eveniet perferendis veritatis saepe expedita fugiat deleniti. Quisquam reprehenderit quae eos soluta explicabo corrupti provident.\n\nEt tenetur ullam labore eius. Facilis recusandae sint. Mollitia sed et libero. Quia omnis fuga eveniet exercitationem et ipsum ut praesentium hic. Ut nihil eveniet repellendus amet beatae dolorem cum voluptas aspernatur.\n\nRatione atque reprehenderit quia quia eum sit dolorem reprehenderit. Incidunt aut quis. Amet hic iusto sed pariatur fugiat sint consequuntur consectetur.\n\nOccaecati alias odio molestias aliquid veritatis quia iure. Sunt maiores ullam cum consequatur optio vero et. Qui vitae autem voluptas molestiae et ut non ipsam. Natus consequatur magnam eligendi et voluptatem qui aliquid ea. Consequatur et assumenda ad.\n\nAssumenda ratione aperiam odit voluptatem. Quam debitis quia dolore ut voluptate laborum dolorem sequi cum. Sed distinctio amet perferendis qui ea neque et. Omnis fuga culpa. Culpa rem dolores atque natus tenetur aut dignissimos sapiente. Omnis id ipsa rerum aspernatur maiores dolorem dolor consectetur.", 1 });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "IntroductionParagraph", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { 5, "Provident non deleniti perferendis ad natus quae sed odit quia. Laudantium maxime magni omnis iure fugit aliquam aliquam. Ut qui nam quis praesentium voluptas mollitia. Veritatis voluptate optio sed. Molestias modi est.\n\nDolores explicabo animi. Consequatur ut eos quod ad. Sint debitis quis vero dolor quia quo consequatur est impedit.\n\nQui autem quo at ipsam nobis quibusdam. Quia aliquid minus iste possimus recusandae id. Ad aspernatur corrupti dolorem autem aut beatae ut. Excepturi et rerum laudantium voluptas quas aliquid voluptatem odio vero. Nostrum nihil dolorem qui rem maxime commodi voluptatem consectetur commodi.\n\nOfficiis ab rerum vel ut rerum vitae. Facere quia aliquam. Necessitatibus in eveniet eius ut id. Id rem modi impedit hic odio natus.\n\nPariatur rerum quibusdam quam qui aut velit impedit exercitationem. Doloribus quo consequatur velit est. Sint autem beatae soluta veritatis placeat non vero velit dolorum. Hic atque sint vel minima veniam facere enim nihil.", false, null, null, "Example Paragraph 5", 1 },
                    { 6, "Similique non quaerat natus. Quo odit nostrum modi eum. Est vero facere magni dolorum. Excepturi et totam officiis ullam corrupti quidem. Soluta sint et eos officia. Sapiente molestiae et eum ex ea.\n\nEos reprehenderit reprehenderit. Atque vel magnam sed nam aut aliquam. Quia est alias laudantium aut voluptas asperiores ut sit. Ipsa architecto vitae saepe ullam.\n\nOfficia quibusdam non tempore iure laborum dolor. Est voluptatem excepturi qui mollitia fuga voluptatum est. Earum nemo quis ratione facere porro explicabo velit molestiae. Eos harum consectetur ad facilis totam et ut. Et natus quibusdam cumque consequatur dolore hic. Natus exercitationem repellendus est eos itaque harum dolor aut.\n\nEst velit ad libero totam autem. Qui natus fuga alias facilis quod unde enim sunt totam. Et tenetur excepturi reiciendis odio odit accusantium neque illo. Magnam nam ex. Qui rerum amet. Temporibus nobis praesentium autem eum omnis consequatur et.\n\nPossimus reiciendis corporis a cupiditate et quibusdam aspernatur sequi iure. Magnam dolores rerum aut eos aut. Veritatis ducimus porro neque id rerum. Laudantium doloremque aut.", false, null, null, "Example Paragraph 6", 1 },
                    { 7, "Assumenda nulla rem vel quo fuga ratione dolor dolorum. Amet quasi nihil perspiciatis quas voluptas qui commodi quas. Odit odio natus. Voluptatibus dolor dolores quod eos rem harum. Dolor possimus aut eveniet occaecati qui.\n\nIn error officiis iusto ipsum fugiat non autem ratione dignissimos. Voluptas architecto ad sed officia sunt rerum dolore quod. Earum odit nisi. Non fugit aut doloribus dolores dolorem.\n\nSit sed animi aut quisquam voluptatem commodi ipsa et illum. Quam cumque non et ut. Velit sed suscipit debitis quia porro accusantium. Occaecati non dolor porro veritatis nesciunt quia. Quidem natus nam quia voluptate aut ea est at. Doloremque et quis.\n\nDignissimos et minima maiores nihil non ipsa omnis sunt omnis. Temporibus neque laboriosam veniam doloribus quisquam. Et ex et a expedita error dignissimos.\n\nMagnam architecto dolores corrupti. Ipsum assumenda culpa reprehenderit at cumque. Ab voluptas repellendus similique molestias. Sed est praesentium est accusamus commodi. Sit quo ipsa maiores nobis voluptates voluptatem.", false, null, null, "Example Paragraph 7", 1 },
                    { 8, "Ex consequatur saepe provident cumque ad repellendus fuga non. Blanditiis ut illum aliquam perferendis natus. Aut id eos illo dolorem harum voluptas officiis. Assumenda vel eligendi.\n\nPraesentium voluptates cum et debitis omnis dolor alias distinctio quod. Rem animi eos perferendis quia unde fugiat velit ut nulla. Eligendi est incidunt expedita. Aut commodi repellat laudantium ut.\n\nHic similique et sint fuga. Sequi voluptatibus dolor. Id officiis veritatis ratione vitae dolore sit quibusdam qui rerum. Animi ab ut esse esse corrupti eligendi. Aliquam blanditiis distinctio est eos aut dolore.\n\nDolorem fugiat in voluptate et pariatur laborum. Adipisci deserunt at qui qui blanditiis officiis expedita cumque. Esse beatae molestiae. Omnis modi optio a nihil odio ut ullam nisi vero.\n\nBeatae ea ipsum recusandae animi recusandae. Voluptatem facilis autem similique ut asperiores est. Voluptatem quia autem qui qui voluptatibus ut aut. Omnis doloribus earum fugiat. Voluptatibus quasi consectetur cupiditate maxime consectetur a et.", false, null, null, "Example Paragraph 8", 2 },
                    { 9, "Veritatis consectetur sit reprehenderit architecto vero. Velit veniam saepe aliquid officia. Error expedita facere.\n\nOmnis voluptatem et nam et qui. Sunt repudiandae sint. Nesciunt consequatur incidunt quas qui aliquid accusantium.\n\nExcepturi omnis ad expedita. Aperiam quia eligendi tenetur dignissimos non eius voluptatibus assumenda ipsa. Vitae occaecati ab eum et quam qui enim adipisci voluptatem. Veniam ut ab.\n\nMagnam possimus nisi ab illo ut ea consequatur dolor. Sapiente expedita voluptate autem. Qui architecto ab voluptas amet fugiat qui aut. Est sint consequatur et ex et eum. Et ut vitae voluptatibus voluptatem rerum nihil.\n\nEius enim reprehenderit iusto sit ut eius qui. In aut quibusdam aliquam. Ratione assumenda fuga. Vel provident doloremque. Repudiandae repellat dolor et necessitatibus quis. Aliquid qui voluptates quaerat aliquid alias fugiat eum maiores.", false, null, null, "Example Paragraph 9", 1 },
                    { 10, "Repellendus consequuntur animi deleniti voluptate maxime enim asperiores. Voluptatum quo nemo ut cupiditate cum rerum laborum. Officiis odio neque aspernatur officiis natus voluptatem odit assumenda asperiores. Fuga deleniti omnis aut eum velit aspernatur sit.\n\nOdio laboriosam voluptatum fuga numquam asperiores debitis commodi cupiditate. Voluptatum asperiores omnis deleniti dolore aliquam. Deleniti aut enim sit dolorem. Quo qui ipsam.\n\nDolorum et consequatur facere est numquam. Dolores et quia dolores asperiores. Magnam laborum omnis quisquam ut.\n\nDolores ipsa sit est placeat aut beatae ipsam quas quaerat. Cupiditate rerum voluptatum nobis eos minima. Qui aut eum voluptas sed dolorem blanditiis rerum qui.\n\nEt laudantium debitis autem id et. Ipsa illum libero iusto. Porro id quod animi qui. Natus laboriosam corrupti et ut deleniti aut sit. Dolor voluptatum officia alias aut iure qui nulla voluptatem. Et eos inventore et accusamus.", false, null, null, "Example Paragraph 10", 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Content", "IntroductionParagraph", "ParagraphImage", "ParagraphImageText", "Title" },
                values: new object[] { "Example content 1", true, "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", null });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Content", "WikiPageId" },
                values: new object[] { "Example content 2", 1 });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Content", "ParagraphImage", "ParagraphImageText" },
                values: new object[] { "Example content 3", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText3" });

            migrationBuilder.UpdateData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Content", "WikiPageId" },
                values: new object[] { "Example content 4", 2 });
        }
    }
}
