using Microsoft.EntityFrameworkCore.Migrations;

namespace ClarieTheme.Migrations
{
    public partial class CreatedProductType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Products_ProductId",
                table: "ProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_Types_TypeId",
                table: "ProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVendor_Vendor_VendorId",
                table: "ProductVendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType");

            migrationBuilder.RenameTable(
                name: "Vendor",
                newName: "Vendors");

            migrationBuilder.RenameTable(
                name: "ProductType",
                newName: "ProductTypes");

            migrationBuilder.RenameIndex(
                name: "IX_ProductType_TypeId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductType_ProductId",
                table: "ProductTypes",
                newName: "IX_ProductTypes_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Products_ProductId",
                table: "ProductTypes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductTypes_Types_TypeId",
                table: "ProductTypes",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVendor_Vendors_VendorId",
                table: "ProductVendor",
                column: "VendorId",
                principalTable: "Vendors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Products_ProductId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductTypes_Types_TypeId",
                table: "ProductTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductVendor_Vendors_VendorId",
                table: "ProductVendor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Vendors",
                table: "Vendors");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductTypes",
                table: "ProductTypes");

            migrationBuilder.RenameTable(
                name: "Vendors",
                newName: "Vendor");

            migrationBuilder.RenameTable(
                name: "ProductTypes",
                newName: "ProductType");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_TypeId",
                table: "ProductType",
                newName: "IX_ProductType_TypeId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductTypes_ProductId",
                table: "ProductType",
                newName: "IX_ProductType_ProductId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Vendor",
                table: "Vendor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductType",
                table: "ProductType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Products_ProductId",
                table: "ProductType",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_Types_TypeId",
                table: "ProductType",
                column: "TypeId",
                principalTable: "Types",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductVendor_Vendor_VendorId",
                table: "ProductVendor",
                column: "VendorId",
                principalTable: "Vendor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
