using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFCoreDemo.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbSetUp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "100, 1"),
                    categoryname = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryid);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    productid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productname = table.Column<string>(type: "varchar(50)", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    productdesc = table.Column<string>(type: "varchar(max)", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.productid);
                    table.ForeignKey(
                        name: "FK_products_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "categoryid");
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "categoryid", "categoryname" },
                values: new object[,]
                {
                    { -3, "book" },
                    { -2, "mobile" },
                    { -1, "laptop" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "productid", "CategoryId", "productdesc", "price", "productname" },
                values: new object[,]
                {
                    { -3, null, "new book from Paul Cohelo", 700.00m, "the alchemist" },
                    { -2, null, "new mobile from one plus", 56000.00m, "one plus 13" },
                    { -1, null, "new laptop from dell", 120000.00m, "dell xps" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryId",
                table: "products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
