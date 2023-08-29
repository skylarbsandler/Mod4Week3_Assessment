using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CommerceMvc.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "merchants",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_merchants", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    category = table.Column<string>(type: "text", nullable: false),
                    stock_quantity = table.Column<int>(type: "integer", nullable: false),
                    release_date = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    merchant_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_products", x => x.id);
                    table.ForeignKey(
                        name: "fk_products_merchants_merchant_id",
                        column: x => x.merchant_id,
                        principalTable: "merchants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "merchants",
                columns: new[] { "id", "category", "name" },
                values: new object[,]
                {
                    { 1, "Restaurant", "Biker Jim's" },
                    { 2, "Outdoor", "REI" },
                    { 3, "Restaurant", "Walter's 303" }
                });

            migrationBuilder.InsertData(
                table: "products",
                columns: new[] { "id", "category", "description", "merchant_id", "name", "release_date", "stock_quantity" },
                values: new object[,]
                {
                    { 1, "Food", "A yummy hotdog", 1, "Elk Jalapeno Cheddar", new DateTimeOffset(new DateTime(2023, 1, 25, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2140), new TimeSpan(0, -6, 0, 0, 0)), 52 },
                    { 2, "Food", "A pretty yummy hotdog", 1, "Chicken Peach Chipotle", new DateTimeOffset(new DateTime(2023, 8, 20, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2241), new TimeSpan(0, -6, 0, 0, 0)), 91 },
                    { 3, "Food", "A hotdog", 1, "Vegan Dog", new DateTimeOffset(new DateTime(2023, 8, 3, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2246), new TimeSpan(0, -6, 0, 0, 0)), 15 },
                    { 4, "Shoes", "Comfy shoes", 2, "Teva Slip-ons", new DateTimeOffset(new DateTime(2022, 9, 4, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2250), new TimeSpan(0, -6, 0, 0, 0)), 43 },
                    { 5, "Camping", "Rain heaters", 2, "Waterproof Matches", new DateTimeOffset(new DateTime(2023, 5, 30, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2255), new TimeSpan(0, -6, 0, 0, 0)), 40 },
                    { 6, "Apparel", "Great wearable blanket", 2, "Nano Puff Jacket", new DateTimeOffset(new DateTime(2023, 1, 14, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2260), new TimeSpan(0, -6, 0, 0, 0)), 60 },
                    { 7, "Food", "Not a hotdog", 3, "Cheesy Breadsticks", new DateTimeOffset(new DateTime(2023, 1, 21, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2265), new TimeSpan(0, -6, 0, 0, 0)), 14 },
                    { 8, "Food", "Definitely not a hotdog", 3, "Cheese Cake", new DateTimeOffset(new DateTime(2023, 6, 8, 14, 13, 50, 325, DateTimeKind.Unspecified).AddTicks(2269), new TimeSpan(0, -6, 0, 0, 0)), 30 }
                });

            migrationBuilder.CreateIndex(
                name: "ix_products_merchant_id",
                table: "products",
                column: "merchant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "merchants");
        }
    }
}
