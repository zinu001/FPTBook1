using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FPTLibrary.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Roles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Author = table.Column<string>(maxLength: 100, nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Published_Date = table.Column<DateTime>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<int>(nullable: false),
                    Payment = table.Column<int>(nullable: false),
                    Order_Date = table.Column<DateTime>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    AspNetUsersId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AspNetUsersId",
                        column: x => x.AspNetUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orders_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "HN", "f155fbb1-aaa6-4427-b27a-b82e1d1407eb", "Admin", "ADMIN" },
                    { "HCM", "615f078e-354f-4f17-bb78-73c3d1951ce3", "Store Owner", "STORE OWNER" },
                    { "DN", "20743741-15df-420c-8a5e-c651521dd73b", "Customer", "CUSTOMER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Image", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "Roles", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "4f2f500a-06aa-4f7a-9e3c-f515a2f8ef8d", 0, "90b35f85-5319-400d-a6dc-6d09801af057", "admin@gmail.com", false, "https://guantanamocity.org/wp-content/uploads/2020/12/huong-dan-tao-anh-dai-dien-hoat-hinh-tren-facebook-cach-tao-avatar-facebook-1.png", false, null, "Admin", null, null, null, "0321169923", false, "Admin", "182c1b09-224f-413b-ba99-e369895f0222", false, null },
                    { "e0f7ea8b-b553-4df1-9473-c825759b7c64", 0, "b15dc43b-5657-4fe9-b69b-94660a20702c", "customer@gmail.com", false, "https://guantanamocity.org/wp-content/uploads/2020/12/huong-dan-tao-anh-dai-dien-hoat-hinh-tren-facebook-cach-tao-avatar-facebook-1.png", false, null, "Customer", null, null, null, "0321333923", false, "Customer", "fb0b52ed-70ac-4a14-91b4-fd2face609d9", false, null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryId", "Image", "Name" },
                values: new object[,]
                {
                    { 1, null, "https://cdn-amz.fadoglobal.io/images/I/81o791tFXeS.jpg", "Politics" },
                    { 2, null, "https://cdn2.f-cdn.com/contestentries/1121968/17989453/59a8471fb17b9_thumb900.jpg", "Horror" },
                    { 3, null, "https://www.inquirer.com/resizer/rJ2GQrjd5GR5ruMdmhLbBdJesCY=/filters:format(webp)/cloudfront-us-east-1.images.arcpublishing.com/pmn/SRCJLCGZVBBPTJSRAFMSX34GOM.jpg", "Romance" },
                    { 4, null, "https://cdn0.fahasa.com/media/catalog/product/t/h/the_science_book_big_ideas_simply_explained_1_2021_08_28_12_21_00.jpg", "Science" },
                    { 5, null, "https://m.media-amazon.com/images/I/41m0T7VZwAL.jpg", "Science fiction & mystery" },
                    { 6, null, "https://www.casino.org/news/wp-content/uploads/2021/06/Screen-Shot-2021-06-24-at-11.57.05-AM.png", "Sport" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Image", "Name", "Price", "Published_Date", "Quantity" },
                values: new object[,]
                {
                    { 3, "Rosalind S. Helderman", 1, "One of the most urgent and important investigations ever conducted, the Mueller inquiry focuses on Donald Trump, his presidential campaign, and Russian interference in the 2016 election, and draws on the testimony of dozens of witnesses and the work of some of the country’s most seasoned prosecutors.", "https://m.media-amazon.com/images/P/B07PB76691.01._SCLZZZZZZZ_SX500_.jpg", "The Mueller Report", 300.0, new DateTime(2013, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 2, "Bram Stoker", 2, "The novel has no single protagonist, but opens with solicitor Jonathan Harker taking a business trip to stay at the castle of a Transylvanian noble, Count Dracula. Harker escapes the castle after discovering that Dracula is a vampire, and the Count moves to England and plagues the seaside town of Whitby. A small group, led by Abraham Van Helsing, hunt Dracula and, in the end, kill him.", "https://thebookmarketng.com/wp-content/uploads/2020/08/dracula.jpg", "Dracula", 700.0, new DateTime(1897, 9, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 4, "Stephen King", 2, "IT tells the story of seven friends who face an evil shape shifting entity that feeds on the fears of children. One of IT’s favorite disguises is a circus clown called Pennywise, otherwise known as 'Bob Gray'.", "https://d28hgpri8am2if.cloudfront.net/book_images/onix/cvr9781982127794/it-9781982127794_hr.jpg", "IT", 800.0, new DateTime(1986, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 60 },
                    { 1, "Makoto Shinkai", 3, "A comet appears and mysteriously affects and connects the lives of two teenagers of the same age, a boy in the big, bustling city of Tokyo and a girl in a country village where life is slow but idyllic. They find for unknown reasons, they wake up in each other's bodies for weeks at a time. At first, they both think these experiences are just vivid dreams, but when the reality of their situations sinks in, they learn to adjust and even enjoy it. Soon they start to communicate and try to leave notes about who they are and what they are doing. But as they discover more about each other and the other's life, they uncover some disturbing hints that their distance is more than just physical and tragedy haunts them.", "https://upload.wikimedia.org/wikipedia/vi/b/b3/Your_Name_novel.jpg", "Your Name", 500.0, new DateTime(2016, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 5, "Dan Simmons", 4, "On the world called Hyperion, beyond the reach of galactic law, waits a creature called the Shrike. There are those who worship it. There are those who fear it. And there are those who have vowed to destroy it. In the Valley of the Time Tombs, where huge, brooding structures move backward through time, the Shrike waits for them all. On the eve of Armageddon, with the entire galaxy at war, seven pilgrims set forth on a final voyage to Hyperion seeking the answers to the unsolved riddles of their lives. Each carries a desperate hope—and a terrible secret. And one may hold the fate of humanity in his hands.", "https://m.media-amazon.com/images/P/0399178619.01._SCLZZZZZZZ_SX500_.jpg", "Hyperion", 400.0, new DateTime(1990, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 6, "Orson Scott Card", 4, "In order to develop a secure defense against a hostile alien race's next attack, government agencies breed child geniuses and train them as soldiers. A brilliant young boy, Andrew Ender Wiggin lives with his kind but distant parents, his sadistic brother Peter, and the person he loves more than anyone else, his sister Valentine. Peter and Valentine were candidates for the soldier-training program but didn't make the cut--young Ender is the Wiggin drafted to the orbiting Battle School for rigorous military training. Ender's skills make him a leader in school and respected in the Battle Room, where children play at mock battles in zero gravity. Yet growing up in an artificial community of young soldiers, Ender suffers greatly from isolation, rivalry from his peers, pressure from the adult teachers, and an unsettling fear of the alien invaders. His psychological battles include loneliness, fear that he is becoming like the cruel brother he remembers, and fanning the flames of devotion to his beloved sister. Is Ender the general Earth needs? But Ender is not the only result of the genetic experiments. The war with the Buggers has been raging for a hundred years, and the quest for the perfect general has been underway for almost as long. Ender's two older siblings are every bit as unusual as he is, but in very different ways. Between the three of them lie the abilities to remake a world. If the world survives, that is. ", "https://images-na.ssl-images-amazon.com/images/I/81+IUsYtGTL.jpg", "Ender's Game", 350.0, new DateTime(1994, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 30 },
                    { 7, "Jeff Goldberg", 6, "The main subject of the book is the Big East Tournament championship game of 2001, although the book intersperses play by play coverage of the game with background information on the entire season, as well as commentary on the players, coaches and other aspects of the two programs. The game featured in the book was neither the first nor the last meeting of the two teams in the season.[3] In January, UConn played Notre Dame at Notre Dame. The UConn team was undefeated, and ranked number one in the country at the start of the game. Notre Dame won 92–76, remained undefeated, and moved from third to the number one ranking at the next poll.[4] Both teams would also meet in the semifinals of the NCAA Tournament, with Notre Dame prevailing and then going on to win the national championship. All of the meetings between the two teams that year were important games for each team, but the game in March had multiple story lines—a tournament championship at stake, a close game in which neither team led by more than eight points at any time, a devastating injury to one of the game's best players, and finally, a game that was decided by a single basket scored in the final moments, by one of the best players in the sport, Sue Bird.", "https://upload.wikimedia.org/wikipedia/en/a/a3/Bird_at_the_Buzzer_cover.jpg", "Bird at the Buzzer", 200.0, new DateTime(2011, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AspNetUsersId", "BookId", "Order_Date", "Payment", "Quantity" },
                values: new object[] { 2, null, 2, new DateTime(2022, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 20 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AspNetUsersId", "BookId", "Order_Date", "Payment", "Quantity" },
                values: new object[] { 1, null, 1, new DateTime(2021, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 2 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "AspNetUsersId", "BookId", "Order_Date", "Payment", "Quantity" },
                values: new object[] { 3, null, 5, new DateTime(2022, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 30 });

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
                name: "IX_Books_CategoryId",
                table: "Books",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_CategoryId",
                table: "Categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AspNetUsersId",
                table: "Orders",
                column: "AspNetUsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BookId",
                table: "Orders",
                column: "BookId");
        }

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
                name: "Orders");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
