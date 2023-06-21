using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixInventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryDetail");

            migrationBuilder.AddColumn<string>(
                name: "Book_Id",
                table: "Inventory",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Inventory_Note",
                table: "Inventory",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Inventory_Quantity",
                table: "Inventory",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_Book_Id",
                table: "Inventory",
                column: "Book_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Book_Book_Id",
                table: "Inventory",
                column: "Book_Id",
                principalTable: "Book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Book_Book_Id",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_Book_Id",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Inventory_Note",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Inventory_Quantity",
                table: "Inventory");

            migrationBuilder.CreateTable(
                name: "InventoryDetail",
                columns: table => new
                {
                    Inventory_Detail_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Book_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Inventory_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Inventory_Detail_Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Inventory_Detail_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryDetail", x => x.Inventory_Detail_Id);
                    table.ForeignKey(
                        name: "FK_InventoryDetail_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryDetail_Inventory_Inventory_Id",
                        column: x => x.Inventory_Id,
                        principalTable: "Inventory",
                        principalColumn: "Inventory_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_Book_Id",
                table: "InventoryDetail",
                column: "Book_Id");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryDetail_Inventory_Id",
                table: "InventoryDetail",
                column: "Inventory_Id");
        }
    }
}
