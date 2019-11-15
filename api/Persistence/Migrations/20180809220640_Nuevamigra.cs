using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class Nuevamigra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Client",
                table: "Sold");

            migrationBuilder.DropColumn(
                name: "Product",
                table: "Sold");

            migrationBuilder.DropColumn(
                name: "Seller",
                table: "Sold");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Sold",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SellerId",
                table: "Sold",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VentaProducto2",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SoldId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProducto2", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaProducto2_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VentaProducto2_Sold_SoldId",
                        column: x => x.SoldId,
                        principalTable: "Sold",
                        principalColumn: "SoldId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sold_ClientId",
                table: "Sold",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Sold_SellerId",
                table: "Sold",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto2_ProductId",
                table: "VentaProducto2",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProducto2_SoldId",
                table: "VentaProducto2",
                column: "SoldId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sold_Client_ClientId",
                table: "Sold",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sold_Seller_SellerId",
                table: "Sold",
                column: "SellerId",
                principalTable: "Seller",
                principalColumn: "SellerId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sold_Client_ClientId",
                table: "Sold");

            migrationBuilder.DropForeignKey(
                name: "FK_Sold_Seller_SellerId",
                table: "Sold");

            migrationBuilder.DropTable(
                name: "VentaProducto2");

            migrationBuilder.DropIndex(
                name: "IX_Sold_ClientId",
                table: "Sold");

            migrationBuilder.DropIndex(
                name: "IX_Sold_SellerId",
                table: "Sold");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Sold");

            migrationBuilder.DropColumn(
                name: "SellerId",
                table: "Sold");

            migrationBuilder.AddColumn<string>(
                name: "Client",
                table: "Sold",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Product",
                table: "Sold",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Seller",
                table: "Sold",
                nullable: true);
        }
    }
}
