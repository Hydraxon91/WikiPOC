using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace wiki_backend.Migrations
{
    /// <inheritdoc />
    public partial class AddWikiPageWithImageInputModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0e0c6726-246f-4ff4-9a71-c8949b703d1d"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("421f2788-5c4d-4f13-bc1b-375604aa6f51"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("4dc130e1-50b0-455e-b314-c9edaed9cec2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("610fb6b7-f06d-4f15-bd22-a8a77c5675e9"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("69e33080-6f04-4265-8d30-e2e808731ca7"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6e5b9624-3cf9-4055-8f5a-5d519e02dc17"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("75af8125-ffad-4913-8f02-c0bb6fad1523"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("89e10715-3a5f-4a5d-9d43-134b36cb6c2a"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("8ed161aa-c781-49e6-a208-b34854b41d67"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b624386b-c477-42ae-9e6f-aac1805d4e26"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("cf9c7a49-3fee-446e-9d34-05c2c65e93d2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d228e3c2-63fb-4e91-ba58-465aeb809767"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d277735e-cb54-4881-afef-7366d861f827"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d86c5c5e-5826-459b-9f90-6c33328d2b30"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("ec8e2978-7158-4909-b616-70c9e3244e18"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("fa4578a8-d6f2-4043-b10c-62faae9459cc"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SiteSub",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RoleNote",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("7755a574-b34e-4848-afc0-c02472764aaa"), false, null, null, "UserSubmittedWikiPage", true, null, true, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb"), null, null, "WikiPage", null, true, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64"), null, null, "WikiPage", null, true, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0822b690-01ef-4a1d-a083-324cd95225f2"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("7755a574-b34e-4848-afc0-c02472764aaa") },
                    { new Guid("1c1feebd-ee1e-4c75-bb53-650bd4c39227"), "Quo nesciunt voluptas debitis voluptate quaerat deleniti nobis error. Necessitatibus iste quos maxime minus ducimus sed in aut cumque. Praesentium perferendis quos fuga dignissimos sit mollitia et.\n\nOdit ut cumque nostrum alias aut vel. Amet quia dolor omnis nostrum ut. Libero quia dolor laudantium inventore commodi eum. Reprehenderit cum ut voluptatum voluptatem sunt porro at. Explicabo excepturi vero nam asperiores non dicta deserunt. Sint optio accusantium magnam alias magni id praesentium.", null, null, "Example Page 2 - Paragraph 3", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("1c8bc1a2-3a72-448c-b928-d0d35aa210a4"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("7755a574-b34e-4848-afc0-c02472764aaa") },
                    { new Guid("373babee-6748-431a-89c0-bfe649ecc94f"), "Debitis eum et debitis voluptatum. Eveniet autem architecto sapiente harum dolorem explicabo impedit explicabo officiis. Est non et expedita deserunt enim. Nemo repellendus voluptatem tempora quia omnis fugiat.\n\nTotam et iusto qui voluptatem cumque aliquid optio beatae. Libero perferendis facere placeat tenetur adipisci quos nihil. Placeat voluptatem esse quae quae quae.\n\nDoloremque est sint. Consequatur quia corporis ad commodi excepturi aspernatur et neque quaerat. Velit provident doloribus neque nihil.\n\nDebitis doloribus iure natus quod architecto quidem nobis quia. Sed quas rem eum reprehenderit sint. Fuga velit laudantium impedit velit commodi quisquam. Porro aliquid quia vero corporis. Debitis soluta id architecto et quam.\n\nSunt maxime voluptatum. Omnis reprehenderit sint necessitatibus saepe. Aut voluptatum esse earum voluptatem esse id assumenda. Voluptas corporis quam.\n\nOfficia asperiores porro possimus ut ratione a hic amet. Eos placeat cumque beatae et voluptates. Iste eligendi officiis qui blanditiis et nihil rerum. Libero qui eveniet eum repellendus quibusdam. Commodi ratione facilis fugiat ipsum.\n\nSunt natus et quasi sed unde. Impedit quia cum occaecati unde quae explicabo rerum repellendus ut. Sunt sit sed sint voluptatem sapiente eligendi sed. Fugit libero optio possimus voluptatum voluptatem delectus.", null, null, "Example Page 1 - Paragraph 3", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("37cd6513-798f-43ac-8624-380493dd7d57"), "Aut sed sint est voluptas. Esse aliquam eum molestias ullam dolor reiciendis quia. Cupiditate itaque quidem accusamus eos id quis sit. Quaerat maxime expedita eum non qui sed neque.\n\nEt molestiae aspernatur nemo explicabo. Sequi magni nulla itaque magni dolores ullam quod enim dolorum. Officiis aut similique ut autem. Accusamus voluptatem sapiente. Perferendis quia amet quis sed.\n\nNostrum similique perferendis. Ut id et quaerat blanditiis. Rerum nihil qui eum dolores aperiam. Sed suscipit sunt harum fugit optio dolorum.\n\nQuam totam ipsam quo sapiente veniam. Laboriosam doloremque possimus quia ut quisquam et sed. Voluptatem ut sint id quaerat. Quod voluptatum vero quo.\n\nOfficia harum dolorem esse ducimus quia distinctio. Nisi cupiditate enim voluptatem rem illo qui eum sit quia. Quibusdam repudiandae asperiores. Repellat sed ad quo ut aut sit. Animi omnis aut qui odit ut odio at minima. Omnis qui sed facilis ratione maxime qui impedit omnis.\n\nDoloribus eum ipsa ea omnis. Optio ut et saepe beatae consequuntur consequatur consequatur qui sequi. Quis sint repellendus enim necessitatibus. Quos impedit aut ad.\n\nMagnam quasi et fugit sit. Repudiandae aut quia quia et in dolor expedita deleniti animi. Culpa non laborum voluptatem cumque quibusdam enim magnam et veritatis. Laudantium qui quam qui quia dicta repudiandae.\n\nDicta iure architecto rem in. Ad assumenda eligendi provident nam ut aliquid nisi. Odio atque quia quidem excepturi. Nihil voluptatem ut. Nihil quisquam inventore at consequatur quisquam quasi. Aut voluptas alias nobis quis.\n\nExpedita optio dolore dolor soluta cum consequatur praesentium eius. Quia odit molestiae odit officia fuga. Facere placeat aliquid molestias iusto qui. Quia nam placeat qui quam tempore dicta.\n\nEt non est rerum atque eaque. Assumenda voluptatem dolores enim qui pariatur enim occaecati ut quae. Adipisci quia saepe aut quis voluptas sed nobis ut debitis. Ab sapiente animi quo quasi et. Amet ut consequatur repellat mollitia architecto cum reiciendis ipsa et.", null, null, "Example Page 2 - Paragraph 2", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("473df0cf-2d1d-442b-a815-420c0efc4eb2"), "Et et ut reprehenderit qui laudantium maxime magnam in. Blanditiis et sint. Nostrum consectetur vel minima ut aut aliquid soluta quisquam. Animi qui deleniti deleniti deleniti.\n\nOfficia et velit dolor quia sint aut unde. Doloribus necessitatibus quo dolorum adipisci et quas non. Ut sint blanditiis eos maxime iusto. Facilis minima molestiae ipsum unde minima sapiente quia. Non nisi repellat beatae eaque occaecati odio molestiae iste deserunt.\n\nEt error beatae laudantium nemo nulla nobis. Ut in sunt. Non dicta adipisci dolores quidem quisquam saepe voluptatem. Doloribus libero quos quae eos. Fugiat ut sint et.\n\nUnde voluptate eum autem est. Amet eum non architecto nobis numquam est repellendus error sint. Nihil atque est beatae ut.\n\nIn velit similique aperiam. Molestiae voluptate ea aspernatur rerum praesentium aliquam velit et quis. Esse ea harum expedita iusto aut earum possimus ratione possimus. Dolores magnam est sit hic quisquam blanditiis et in veniam. Odio nobis aut enim fuga quos perspiciatis exercitationem veritatis et.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("6c6d902a-fdba-4137-b8f2-80c9b13c2a8e"), "Earum dolor maxime placeat sit nihil ipsum. Sequi et sint aspernatur vitae delectus modi. Nisi eos enim nulla delectus aperiam minima et ab voluptas.\n\nRepudiandae minima voluptas quas voluptas omnis dolores totam et. Laborum quisquam accusamus impedit ducimus repellat ratione omnis unde officiis. Nihil aliquam provident id nesciunt velit porro sit voluptas. Qui quaerat ab et. Praesentium voluptas ipsa sint necessitatibus nihil in qui eum.", null, null, "Example Page 2 - Paragraph 6", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("80ef4cb5-bffd-4010-ae67-e0b14e703695"), "Sunt voluptas quo soluta eveniet vel officiis veritatis quam. Cupiditate quia iste unde quibusdam quam sit est quam. Occaecati iure ut laudantium numquam aliquam. Ut autem porro. Sunt alias perferendis voluptas omnis odio et. Aliquam laudantium nihil repellendus deserunt tenetur dolorem amet nam.\n\nTotam dolorem et. Voluptate facere dolorem laboriosam quos qui. Ex quisquam placeat. Qui eveniet harum.\n\nSit velit quod voluptatem dolorem est. Harum nemo maiores veniam ipsum. Sed commodi voluptatem fugiat error. Nihil dolorem consectetur minus quo. Officiis dolores et. Omnis vero tenetur qui vero.\n\nAd praesentium voluptas corporis veritatis qui aperiam. Odio ea eum suscipit ipsam ut reprehenderit iste et. Aliquid corporis voluptatibus dolor quos. Voluptatum officia ipsa excepturi dolor quo modi. Ex aperiam eum harum quia eaque dolor assumenda. Et facere enim est itaque assumenda quis voluptatem atque consequatur.\n\nProvident dolorem repudiandae tempore saepe natus eum inventore vel qui. Non laudantium molestiae quia est eveniet similique ad. Nihil provident dolores est quis accusantium omnis sunt. Necessitatibus aut et. Id odio est omnis harum deserunt.\n\nAtque necessitatibus et labore. Quis itaque non et amet. Sequi deleniti illum commodi ipsam. Ipsam nihil accusantium labore eum perspiciatis. Velit similique velit asperiores repudiandae omnis molestiae.\n\nMagnam natus hic quia tempore maxime sequi. Doloremque est excepturi delectus. Voluptate sit ut.\n\nFugit quia dicta ad molestiae eos cupiditate fugit. Quo aut aut rerum ut quod pariatur est sequi. Nisi iste aut quia ut qui. Dolores pariatur animi. Consequatur tempora reiciendis rerum ut necessitatibus. Quae et voluptas dignissimos eos tempore.", null, null, "Example Page 1 - Paragraph 5", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("a472d801-47f6-44ee-ac60-1b1974bd9e7f"), "Porro provident et sapiente eaque quos sit quia est. Enim perspiciatis provident rerum esse eveniet eos ipsam ab expedita. Fugiat sit ut rerum. Vero eaque quia iusto laboriosam explicabo illum minus.\n\nVoluptas non voluptatem voluptate. Ullam optio placeat soluta tempore rerum dolorum fugiat et. Repellat ducimus praesentium consectetur laudantium eaque. Qui eum distinctio cumque tempore magni non. Porro neque praesentium quaerat fugiat voluptatem ad. Vel sint quae consequuntur ex qui qui.\n\nAut qui totam pariatur tenetur. Sequi adipisci delectus dolore. Eius error reprehenderit quae velit cumque assumenda ea. Et nemo nesciunt voluptatum qui voluptas. Error dolor libero rem dolore ducimus aut.", null, null, "Example Page 1 - Paragraph 6", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("b772d9f1-940b-43a4-8e6d-acd27480c3e2"), "Nihil porro sed repellendus. Consequuntur cumque adipisci. Sed laudantium veniam quis odit corporis autem magni laudantium. Quo ducimus ut libero sint eveniet minima sit minima porro. Cupiditate vel dolorem at magni qui quam amet.\n\nEt modi nihil. Vero possimus et. Eum excepturi enim et quia nam possimus fuga.\n\nNemo cumque qui assumenda placeat. Sit qui autem illum necessitatibus reiciendis. Voluptas amet eos libero quia et. Consequuntur sit incidunt sapiente dolorem et qui.\n\nEt nemo veritatis debitis mollitia qui cupiditate et. Atque sit labore optio ullam. Itaque excepturi harum ducimus autem provident vero omnis et labore. Provident quas molestiae magnam ex iusto quas aut repudiandae. Corporis amet dolor et delectus ut praesentium qui quam sed.\n\nEarum dolorem consequuntur omnis. Veritatis debitis hic. Aspernatur architecto eius aut quis sit.\n\nItaque unde voluptate commodi harum et ut praesentium maiores. Qui odit consequatur. Quo vel iste inventore ullam asperiores vel.", null, null, "Example Page 2 - Paragraph 4", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("d5072538-4596-4567-884b-006d013b244b"), "Quis quidem sit consequatur qui est quibusdam illo eligendi quasi. Impedit fuga non laudantium at et reiciendis. Non odio aut maxime architecto error ipsum. Aut laboriosam vitae sed.\n\nMaiores cupiditate facere omnis recusandae vitae veritatis ducimus minima. Laborum quia rerum pariatur sint et soluta exercitationem enim vero. Molestiae quod exercitationem qui.\n\nConsequatur vel aliquid commodi perspiciatis. Et nesciunt consequatur est alias. Qui sit porro hic quia pariatur qui dicta. Deserunt laboriosam ut omnis nesciunt provident provident. Quia autem deleniti exercitationem. Odio fugit possimus quisquam quo odit veniam dolores.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") },
                    { new Guid("d9e78e28-dab6-44d6-b8ae-dc8266e27085"), "Saepe et ad pariatur. Ipsam non quia amet omnis. Eius aliquam placeat aliquid ut laudantium. Et aspernatur dolor error.\n\nSuscipit rem nostrum nulla inventore facilis. Quas enim vitae dolorem neque consequatur. Quia explicabo tempore sit dolores. Eaque nostrum delectus ea repellat id.\n\nEum dignissimos ullam tenetur quis et aspernatur. Doloremque quod consectetur. Facilis nemo enim. Eum dolor sed. A nesciunt unde et quis consectetur laudantium nihil.\n\nId praesentium sit recusandae dolores. Quo et neque fuga rerum libero sint. Aliquam similique explicabo explicabo et aspernatur. Vitae officiis sunt incidunt accusamus accusamus. Enim magni hic molestiae sapiente qui cumque magnam.\n\nUt et possimus quod est ut qui officiis. In ratione odit dolorem aspernatur cumque dolor dolorum. Praesentium facere asperiores aut. Nihil at voluptatem qui soluta. Voluptatem animi soluta. Tempore qui eos sint error.\n\nId laudantium culpa officia sed. Modi officia eveniet qui at quam laboriosam laudantium. Nemo quis magni molestias rerum id dignissimos at rem qui. Dolor quasi sit animi minima hic autem alias accusantium perspiciatis. Culpa voluptatem inventore doloremque. Et repellat aspernatur commodi magni repellat.\n\nEst nisi nam ratione ut consequatur quae porro delectus. Asperiores itaque quos eius. Amet ut aut non. Dolorem eum fuga consequatur illum unde. Aut sed nisi placeat aut sint at. Aut inventore nam pariatur.", null, null, "Example Page 1 - Paragraph 4", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("e17d7ddf-31e9-4e72-8930-24a44839fd56"), "Ipsam omnis accusantium doloribus et. Ut aut aut repellat maxime nihil sed. Quia soluta dolore qui quas nesciunt ipsum eius qui est. Architecto temporibus ut excepturi nostrum est sit. A praesentium qui impedit tempora et doloremque excepturi rem.\n\nOfficiis accusantium aperiam. Maiores aut enim molestiae enim ut unde. Et tempora earum autem quia. Dolor eveniet distinctio. Dolore earum id temporibus cumque porro ut est.", null, null, "Example Page 1 - Paragraph 2", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") },
                    { new Guid("e9ddc009-8b6b-4c4b-9505-79e354308faf"), "Non aut sapiente. Recusandae est accusamus. Non non ipsa perspiciatis mollitia ut ut quis similique.\n\nUt consequatur expedita quasi facilis quae. Delectus architecto accusantium quas non. Aut voluptates dolorem officia laudantium molestiae. Et dignissimos repellat eos aut. Et optio consectetur molestiae praesentium deserunt ipsum veritatis.\n\nQuaerat voluptates quidem ea enim doloremque nobis ducimus. Animi quo quia accusantium voluptas perferendis. Et dolore reiciendis commodi possimus. Odit provident voluptatum dolore eligendi quasi ea repellat.\n\nQuos et accusantium a reprehenderit non numquam iusto quia eaque. Est quis iure alias quasi quis placeat. Numquam voluptatem quod suscipit sequi laboriosam.\n\nIpsum pariatur laboriosam libero exercitationem consectetur eius. Dignissimos deleniti in et nihil nobis voluptatem. Reprehenderit quis dolores voluptatem recusandae ut esse eaque est. Consequatur laboriosam rerum rerum autem. Unde velit quia temporibus. Ut est voluptatem.\n\nLabore est sed sint sequi ut. Quo quia accusamus quia veritatis et hic quisquam eos. Inventore vero ut error cum.\n\nEt praesentium dolorem asperiores maiores placeat recusandae omnis dolore non. Et numquam recusandae cupiditate velit eius deserunt qui aut. Doloremque dolorum nulla non libero et cumque inventore.\n\nUllam totam aut facilis quos ut fugit quia assumenda quam. Facere qui sit tempore voluptatibus. Nam ipsam maiores ratione vitae deleniti omnis eum. Commodi ipsa possimus debitis architecto incidunt mollitia. Perspiciatis iusto provident architecto neque. Optio molestiae cum.", null, null, "Example Page 2 - Paragraph 5", new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f"), false, null, null, "UserSubmittedWikiPage", false, null, true, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("c81a2467-abb0-4289-8592-4d3f86944eb3"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f") },
                    { new Guid("d6252b5f-f0d2-4428-8714-929957caee97"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("0822b690-01ef-4a1d-a083-324cd95225f2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c1feebd-ee1e-4c75-bb53-650bd4c39227"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("1c8bc1a2-3a72-448c-b928-d0d35aa210a4"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("373babee-6748-431a-89c0-bfe649ecc94f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("37cd6513-798f-43ac-8624-380493dd7d57"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("473df0cf-2d1d-442b-a815-420c0efc4eb2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("6c6d902a-fdba-4137-b8f2-80c9b13c2a8e"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("80ef4cb5-bffd-4010-ae67-e0b14e703695"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("a472d801-47f6-44ee-ac60-1b1974bd9e7f"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("b772d9f1-940b-43a4-8e6d-acd27480c3e2"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("c81a2467-abb0-4289-8592-4d3f86944eb3"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d5072538-4596-4567-884b-006d013b244b"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d6252b5f-f0d2-4428-8714-929957caee97"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("d9e78e28-dab6-44d6-b8ae-dc8266e27085"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e17d7ddf-31e9-4e72-8930-24a44839fd56"));

            migrationBuilder.DeleteData(
                table: "Paragraphs",
                keyColumn: "Id",
                keyValue: new Guid("e9ddc009-8b6b-4c4b-9505-79e354308faf"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("721f1c97-bf7f-4f1b-81e1-6875bde8ca0f"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("7755a574-b34e-4848-afc0-c02472764aaa"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("ad6112c1-feb0-465b-b98d-4bd5b529c4bb"));

            migrationBuilder.DeleteData(
                table: "WikiPages",
                keyColumn: "Id",
                keyValue: new Guid("eff5c22a-7278-41d6-b223-1adeb7f3de64"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SiteSub",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RoleNote",
                table: "WikiPages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Category", "Content", "Discriminator", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "Title" },
                values: new object[,]
                {
                    { new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3"), null, null, "WikiPage", null, false, null, "Example RoleNote 2", "Example SiteSub 2", "Example Page 2" },
                    { new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852"), null, null, "WikiPage", null, false, null, "Example RoleNote 1", "Example SiteSub 1", "Example Page 1" }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2"), false, null, null, "UserSubmittedWikiPage", true, null, false, null, "User Submitted RoleNote", "User Submitted SiteSub", "tester", "User Submitted Page", null });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("0e0c6726-246f-4ff4-9a71-c8949b703d1d"), "Consequatur doloribus non eum esse earum ipsam repudiandae accusamus. Perspiciatis hic itaque consectetur sunt. Enim rerum quos rerum quia consequuntur et.\n\nMagnam veniam mollitia et molestiae ad delectus iure laborum omnis. Quisquam error nisi. Eligendi iure ullam sed quasi. Et ut animi ipsum quos error molestiae officiis vero. Et unde culpa in sit sunt nam et quia omnis.", null, null, "Example Page 2 - Paragraph 3", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("421f2788-5c4d-4f13-bc1b-375604aa6f51"), "User Submitted Content 2", "https://i.ytimg.com/vi/jAB3mMdS0xE/maxresdefault.jpg", "General Kenobi", "User Submitted Paragraph 2", new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2") },
                    { new Guid("4dc130e1-50b0-455e-b314-c9edaed9cec2"), "Veniam natus in qui odit reiciendis sunt. Soluta aliquam sed maxime. Placeat reiciendis cumque quia qui eos modi ut.\n\nQuis repudiandae est quae quidem qui nemo pariatur omnis. Tenetur et incidunt aspernatur itaque ut quidem velit. Consequatur at magnam et eius facilis perferendis ab sunt officia. Doloremque quia iste sapiente magni sunt harum libero aperiam veniam. Culpa facere harum facere et quaerat quibusdam. Eveniet sed sunt quia.\n\nSit in eveniet dolore quam quia. Qui nemo doloremque a itaque vero molestias molestiae asperiores consequatur. Vel minus libero qui inventore voluptates voluptatum impedit molestiae minima. Eos laborum architecto tenetur corrupti non sunt rerum et.\n\nUllam molestiae alias aliquam aut illum maxime et quas. Distinctio occaecati esse omnis ea ipsum dolorem et eveniet. At aperiam velit ut non necessitatibus est omnis fugit. Doloribus autem voluptatum culpa aut dignissimos. Temporibus consequatur quo tenetur numquam quam perspiciatis quia iusto. Repudiandae neque consequatur ad dolores nobis.\n\nRerum architecto sit ea omnis id suscipit sed doloribus. Ducimus earum ad facere eos voluptatem iste eligendi expedita. Ipsum rem ipsam quam excepturi possimus. Sapiente voluptas vitae optio sit qui harum perferendis dolore.\n\nEt hic illo maiores quos illum distinctio excepturi est. Cumque explicabo praesentium et accusantium. Quae quis ut. Magnam nulla atque modi.\n\nIste aut maxime sint. Similique et nihil aliquid excepturi. Quos quia unde. In aut qui optio.\n\nConsequuntur omnis est iusto magnam est quae tempora qui modi. Nisi id maxime eaque aut. Cupiditate magnam nam quo.", null, null, "Example Page 1 - Paragraph 2", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("610fb6b7-f06d-4f15-bd22-a8a77c5675e9"), "Expedita maxime dolor animi voluptatum voluptatum facere quisquam vero est. Aut praesentium quo voluptatibus animi pariatur iure voluptatem perferendis quisquam. Iusto perspiciatis qui ullam necessitatibus.\n\nEst voluptates est aliquam. Rerum neque molestiae. Voluptas amet mollitia quae dolorem qui temporibus quasi nihil. Qui aliquid sit sed tempore rerum. Laudantium autem rerum dignissimos voluptatem ab et. Fugiat soluta ut consequatur consequatur eos est.\n\nError perspiciatis et ad mollitia libero rerum. Et ut aut id. Quaerat repudiandae dolores mollitia nihil aspernatur eos modi iusto praesentium. Expedita veniam dolor nostrum dicta eius. Exercitationem libero qui temporibus deleniti occaecati deserunt hic aut.\n\nCupiditate sapiente alias inventore. Sed quod expedita voluptas. Veniam aliquid est blanditiis minima repellat numquam.\n\nOmnis reiciendis doloribus quo eos. Rerum et ut laborum quasi qui sunt. Dolorem expedita ullam sit corrupti et non nobis labore. Quia voluptatem provident explicabo iure. Ut sunt dolorem et modi cum.\n\nNeque aut omnis dolorem sunt accusamus illo dignissimos. Dignissimos reprehenderit officia delectus similique nam consectetur officiis quisquam explicabo. Aut quis sint autem ratione. Quaerat quo harum non at minus eligendi. Veritatis est ut repudiandae. Sed officiis quis nihil autem rerum et quis.", null, null, "Example Page 1 - Paragraph 4", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("69e33080-6f04-4265-8d30-e2e808731ca7"), "Minima voluptas atque ipsam necessitatibus veritatis pariatur labore facere placeat. Adipisci dolorem amet corrupti magni voluptatem qui deserunt aspernatur recusandae. Similique voluptas quia porro fugiat quos placeat. Amet quod fugiat ut aspernatur. Autem repellendus omnis est dolor dignissimos quia. Earum voluptatem quia ut reprehenderit iure sunt.\n\nA ut tempore provident. Qui soluta et sit culpa delectus sit rem voluptas non. Ullam beatae dolorem laborum quis dolorem animi velit nam nesciunt. Enim reprehenderit eos et.\n\nDoloremque alias et aut culpa magni. Sit debitis officia qui officia temporibus fuga. Recusandae corporis non sit nesciunt at molestiae voluptatibus ut nam.\n\nAspernatur consequatur optio. In aspernatur quibusdam sed illum exercitationem ullam rerum repudiandae qui. Dolore magni a quidem. Et eum amet quo quae consequatur. Inventore est nam. Ut vitae possimus sunt ipsam minus eligendi harum fuga eum.\n\nQuisquam suscipit voluptate officia excepturi tenetur asperiores quaerat corrupti qui. Quis sit ratione illo sunt consequatur dolores dignissimos rem. Exercitationem aut aliquam et nesciunt est praesentium sit. Incidunt ab qui saepe ratione molestiae aspernatur.\n\nNumquam illum consequatur facilis doloribus quidem. Possimus provident et quis quidem eos porro magnam et. Et dignissimos quia. Pariatur alias ipsum voluptates.\n\nEst non aut quo molestiae. Accusamus voluptas et doloribus et voluptates distinctio voluptatem. Nihil nesciunt reiciendis minima numquam qui dolore blanditiis incidunt. Voluptatem quis commodi iste dolor aut asperiores dolores deleniti.\n\nExplicabo recusandae sed officia. Ut magni excepturi facilis sequi quas consequuntur non recusandae. Fugit magnam non consequatur aut et et illo voluptatem.", null, null, "Example Page 2 - Paragraph 6", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("6e5b9624-3cf9-4055-8f5a-5d519e02dc17"), "Laborum quia quas. Neque modi voluptas quos qui enim mollitia blanditiis iste. Eos quod culpa saepe. Perferendis alias eius sed aspernatur. Ut porro est dolor beatae deserunt laborum maxime minima.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 1", "Example Page 1 - Paragraph 1", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("75af8125-ffad-4913-8f02-c0bb6fad1523"), "User Submitted Content 1", "https://i.kym-cdn.com/entries/icons/original/000/029/079/hellothere.jpg", "Hello there", "User Submitted Paragraph 1", new Guid("aff8ad7e-4404-4ad5-b9f1-9e804a23c7e2") },
                    { new Guid("89e10715-3a5f-4a5d-9d43-134b36cb6c2a"), "Ut in enim provident iste. Consequatur non modi harum natus aut. Similique voluptas et officiis porro qui repellendus eum itaque provident. Ipsum harum totam maiores minus voluptatem illum repellendus rerum. Temporibus nostrum et. Quo quasi saepe neque id saepe doloribus.\n\nLibero non ratione qui harum et consequatur. Voluptas quas cum. Velit voluptas aut est labore illo. Vitae impedit dolore quasi molestias assumenda sint velit quia.\n\nNihil quasi aut assumenda omnis harum modi autem omnis labore. Autem repellendus saepe ipsum. Molestias sint quibusdam pariatur ullam quia aliquam odio iste non. Placeat voluptas reprehenderit. Facere harum amet est et explicabo ducimus dolore omnis itaque.\n\nSoluta voluptate nostrum ut dolor voluptatem exercitationem qui. Temporibus qui commodi. Ipsam et ea reprehenderit unde voluptas ut molestias sit. Porro nisi maiores.", null, null, "Example Page 2 - Paragraph 4", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("8ed161aa-c781-49e6-a208-b34854b41d67"), "Saepe veritatis illum assumenda eos dolore doloribus ullam ea. Inventore possimus quibusdam dolores qui autem pariatur. Voluptas labore laudantium sed eos et rerum architecto. Sed aut ut nam porro libero consequatur repellat beatae. Eos in placeat culpa et harum sint. Vel aut quae dolorem omnis voluptatem sed velit minima.\n\nMolestiae at reiciendis doloribus ratione labore laudantium. Consectetur quas omnis blanditiis ipsum. Exercitationem fugit qui amet tempore nobis sunt. Eveniet sapiente qui rem et doloribus. Tenetur non reiciendis. Atque qui quos dolorum.\n\nNihil et rem ea ex accusamus est temporibus consequatur. Odit in ullam. Perspiciatis repellendus totam et aut facilis quo. Asperiores ex nihil praesentium rem quia.\n\nRerum voluptatibus sequi. Suscipit in amet et sit consequatur. Aut labore aliquam quas enim. Molestiae ipsam voluptate mollitia inventore fuga.\n\nAut non omnis et. Nihil distinctio quibusdam molestiae ut enim dolor. Repellat et non libero ex a ut adipisci nulla et. Tempora ipsam officiis animi ullam minus voluptate. Quia et laboriosam ut quo corrupti voluptas assumenda voluptatem. Provident dolor repellat voluptas accusamus iste eos recusandae.\n\nCupiditate provident ipsam voluptates. Itaque autem ducimus sit vitae ab commodi dolorem provident aut. In vel et voluptatem accusantium aut.", null, null, "Example Page 1 - Paragraph 3", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("b624386b-c477-42ae-9e6f-aac1805d4e26"), "Sint quae aut dolores reprehenderit omnis asperiores iusto voluptas. Esse non aut expedita molestias. Aperiam numquam labore quis quam sunt.\n\nCupiditate eveniet blanditiis rerum inventore exercitationem. Voluptatem vero sit sequi quia voluptate. Et est dolores facere nobis ipsum ut ex. Ut cupiditate omnis voluptas ut. Eligendi sed voluptatem est consequatur.", null, null, "Example Page 1 - Paragraph 6", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") },
                    { new Guid("cf9c7a49-3fee-446e-9d34-05c2c65e93d2"), "Sed et quia. Mollitia est minus magnam possimus doloribus reiciendis quos sit. Reprehenderit laudantium possimus deserunt atque.\n\nVoluptatem dicta suscipit doloremque asperiores et omnis. Distinctio voluptas quod et dicta sint quidem est quis cumque. Laudantium ea asperiores accusantium neque molestiae repellat. Natus enim delectus nihil laudantium eum eveniet. Molestiae qui repellendus qui repellendus rerum qui.\n\nEt distinctio nesciunt maiores eligendi veniam dolorum et sunt. Debitis iste omnis. Architecto harum odio consequatur perspiciatis libero perferendis beatae aut quia.", null, null, "Example Page 2 - Paragraph 2", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("d228e3c2-63fb-4e91-ba58-465aeb809767"), "Dolores eos sit qui odit maiores cum. Suscipit et molestiae ut. Eius id molestiae deleniti. Inventore doloremque sunt sit repellat.\n\nSunt et ullam ea et. Veritatis enim voluptatem magni id fuga eius. Minima sit qui quia ut accusamus error et cumque. In aspernatur nihil magni. Velit sunt recusandae voluptas.\n\nIpsum quo quo a repudiandae ipsum. Nam qui voluptatem quia consequatur consequatur. Fugit quod quis et id ea itaque unde ut. Et quia quod beatae. Qui sapiente deserunt et unde.\n\nPossimus mollitia eum est fugiat facilis deleniti suscipit doloribus est. Id voluptas sint in sed et tenetur ut temporibus. Iste corporis est. Placeat et doloremque. Laborum accusamus est amet et qui voluptatem aperiam.\n\nDelectus vel cum mollitia voluptatem autem. Vel ut fuga atque delectus aut error. Id amet nemo molestias ea laudantium expedita.", "https://html5-templates.com/demo/wikipedia-template/img/pencil.jpg", "Example ParagraphImageText 2", "Example Page 2 - Paragraph 1", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("d86c5c5e-5826-459b-9f90-6c33328d2b30"), "Minima consequatur et magnam ipsa est qui vero rerum laboriosam. Veritatis est ducimus delectus nostrum inventore culpa vero ut. Doloribus accusantium laborum ratione assumenda fugit perferendis aut.\n\nTotam ut neque minus sequi consequuntur asperiores debitis. Asperiores ab quis aut numquam quo omnis id aut qui. Ut sunt nihil numquam. Quis provident in et exercitationem facere eligendi et. Minima aut soluta illo ullam ut est est aliquid.\n\nSit inventore non consequatur autem. Sed dolorem repellendus voluptas reprehenderit mollitia consequatur laudantium eos ea. Et nihil voluptates occaecati omnis iste repudiandae doloribus soluta accusamus. Dolorem quo hic. Recusandae magnam tempore hic assumenda laborum id aut ea.\n\nRepudiandae vel in quaerat placeat vel. Pariatur eos mollitia ad ut. Nesciunt quod aliquid incidunt qui. Sint beatae illum sit.", null, null, "Example Page 2 - Paragraph 5", new Guid("0a6ea902-f0d0-472b-ad29-cae3464655c3") },
                    { new Guid("fa4578a8-d6f2-4043-b10c-62faae9459cc"), "Et quam eaque nihil illo beatae vitae aut esse eius. Mollitia temporibus animi qui rerum quia est ab. Cum facere debitis placeat magnam nobis et at.\n\nMinus quis voluptatem rerum corrupti. Beatae sint tempore ratione error consectetur optio. A incidunt aliquid.", null, null, "Example Page 1 - Paragraph 5", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") }
                });

            migrationBuilder.InsertData(
                table: "WikiPages",
                columns: new[] { "Id", "Approved", "Category", "Content", "Discriminator", "IsNewPage", "LastUpdateDate", "LegacyWikiPage", "PostDate", "RoleNote", "SiteSub", "SubmittedBy", "Title", "WikiPageId" },
                values: new object[] { new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f"), false, null, null, "UserSubmittedWikiPage", false, null, false, null, "Example RoleNote 1 Update", "Example SiteSub 1 Update", "tester", "Example Page 1", new Guid("34adb907-1095-4ff3-b15b-35a3d8b36852") });

            migrationBuilder.InsertData(
                table: "Paragraphs",
                columns: new[] { "Id", "Content", "ParagraphImage", "ParagraphImageText", "Title", "WikiPageId" },
                values: new object[,]
                {
                    { new Guid("d277735e-cb54-4881-afef-7366d861f827"), "Helldivers never die!", "https://i.ytimg.com/vi/nhhICroqfpU/hq720_live.jpg", "Helldivers never die!", "New Paragraph 1", new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f") },
                    { new Guid("ec8e2978-7158-4909-b616-70c9e3244e18"), "Liber-Tea is a funny line haha", "https://i.kym-cdn.com/photos/images/original/002/760/001/66d", "Time for a nice cup of Liber-Tea", "Liber-Tea", new Guid("4ebd3037-61f0-40cf-8c25-effab003de0f") }
                });
        }
    }
}
