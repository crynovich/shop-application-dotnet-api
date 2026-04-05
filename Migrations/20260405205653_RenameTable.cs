using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductsApplication.Migrations
{
    /// <inheritdoc />
    public partial class RenameTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_product_feature",
                table: "product_feature");

            migrationBuilder.RenameTable(
                name: "product_feature",
                newName: "ProductFeature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature",
                columns: new[] { "ProductId", "FeatureId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductFeature",
                table: "ProductFeature");

            migrationBuilder.RenameTable(
                name: "ProductFeature",
                newName: "product_feature");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_feature",
                table: "product_feature",
                columns: new[] { "ProductId", "FeatureId" });
        }
    }
}
