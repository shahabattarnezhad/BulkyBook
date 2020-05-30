﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class AddProductToDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductTitle = table.Column<string>(nullable: true),
                    ProductAuthor = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductISBN = table.Column<string>(nullable: true),
                    ProductListPrice = table.Column<double>(nullable: false),
                    ProductPrice = table.Column<double>(nullable: false),
                    ProductPrice50 = table.Column<double>(nullable: false),
                    ProductPrice100 = table.Column<double>(nullable: false),
                    ProductImage = table.Column<string>(nullable: true),
                    CategoryId = table.Column<int>(nullable: false),
                    CoverTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Tbl_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Tbl_Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_Tbl_CoverType_CoverTypeId",
                        column: x => x.CoverTypeId,
                        principalTable: "Tbl_CoverType",
                        principalColumn: "CoverTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CoverTypeId",
                table: "Products",
                column: "CoverTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
