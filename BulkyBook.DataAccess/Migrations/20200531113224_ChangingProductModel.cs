using Microsoft.EntityFrameworkCore.Migrations;

namespace BulkyBook.DataAccess.Migrations
{
    public partial class ChangingProductModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tbl_Category_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Tbl_CoverType_CoverTypeId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductAuthor",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductISBN",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductListPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPrice",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPrice100",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductPrice50",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductTitle",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Tbl_Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CoverTypeId",
                table: "Tbl_Product",
                newName: "IX_Tbl_Product_CoverTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Tbl_Product",
                newName: "IX_Tbl_Product_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Tbl_Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ISBN",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Tbl_Product",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ListPrice",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price100",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Price50",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Tbl_Product",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tbl_Product",
                table: "Tbl_Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Product_Tbl_Category_CategoryId",
                table: "Tbl_Product",
                column: "CategoryId",
                principalTable: "Tbl_Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tbl_Product_Tbl_CoverType_CoverTypeId",
                table: "Tbl_Product",
                column: "CoverTypeId",
                principalTable: "Tbl_CoverType",
                principalColumn: "CoverTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Product_Tbl_Category_CategoryId",
                table: "Tbl_Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Tbl_Product_Tbl_CoverType_CoverTypeId",
                table: "Tbl_Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tbl_Product",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "ISBN",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "ListPrice",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Price100",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Price50",
                table: "Tbl_Product");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Tbl_Product");

            migrationBuilder.RenameTable(
                name: "Tbl_Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Product_CoverTypeId",
                table: "Products",
                newName: "IX_Products_CoverTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Tbl_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "ProductAuthor",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductISBN",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "ProductListPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice100",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ProductPrice50",
                table: "Products",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "ProductTitle",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tbl_Category_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Tbl_Category",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Tbl_CoverType_CoverTypeId",
                table: "Products",
                column: "CoverTypeId",
                principalTable: "Tbl_CoverType",
                principalColumn: "CoverTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
