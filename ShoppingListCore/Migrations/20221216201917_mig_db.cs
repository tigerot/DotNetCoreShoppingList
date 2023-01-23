using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListCore.Migrations
{
    public partial class mig_db : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserMail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAdminStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    ListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ListName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.ListId);
                    table.ForeignKey(
                        name: "FK_Lists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListDetails_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "ListId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[,]
                {
                    { 1, "Meyve&Sebze" },
                    { 2, "Et&Tavuk&Balık" },
                    { 3, "Temel Gıda" },
                    { 4, "Kahvaltılık" },
                    { 5, "İçecek" },
                    { 6, "Fırın" },
                    { 7, "Atıştırmalık" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "UserAdminStatus", "UserMail", "UserName", "UserPassword", "UserSurname" },
                values: new object[] { 1, true, "admin@mail.com", "Administrator", "Admin123+-", "Admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Image", "ProductName" },
                values: new object[,]
                {
                    { 1, 4, "yumurta.jpeg", "Yumurta" },
                    { 2, 4, "zeytin.jpg", "Zeytin" },
                    { 3, 3, "salca.jpg", "Salça" },
                    { 4, 6, "ekmek.jpg", "Ekmek" },
                    { 5, 1, "muz.jpg", "Muz" },
                    { 6, 1, "elma.jpg", "Elma" },
                    { 7, 1, "domates.jpg", "Domates" },
                    { 8, 7, "cikolata.jpg", "Çikolata" },
                    { 9, 2, "balik.jpg", "Balık" },
                    { 10, 2, "tavuk.jpg", "Tavuk" },
                    { 11, 4, "peynir.jpg", "Peynir" },
                    { 12, 1, "kabak.jpg", "Kabak" },
                    { 13, 2, "kavurmalıket.jpg", "Kavurmalık Et" },
                    { 14, 3, "un.jpg", "Un" },
                    { 15, 5, "su.jpg", "Su" },
                    { 16, 5, "süt.jpg", "Süt" },
                    { 17, 5, "soda.jpg", "Maden Suyu" },
                    { 18, 5, "meyvesuyu.jpg", "Meyve Suyu" },
                    { 19, 4, "sucuk.jpg", "Sucuk" },
                    { 20, 3, "makarna.jpg", "Makarna" },
                    { 21, 7, "cips.jpg", "Cips" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ListDetails_ListId",
                table: "ListDetails",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ListDetails_ProductId",
                table: "ListDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Lists_UserId",
                table: "Lists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ListDetails");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
