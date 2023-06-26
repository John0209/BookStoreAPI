using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreAPI.Infracstructure.Migrations
{
    /// <inheritdoc />
    public partial class FixRequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Book_Book_Id",
                table: "Request");

            migrationBuilder.DropForeignKey(
                name: "FK_Request_Importation_Import_Id",
                table: "Request");

            migrationBuilder.DropIndex(
                name: "IX_Request_Import_Id",
                table: "Request");

            migrationBuilder.DropColumn(
                name: "Import_Id",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "Book_Id",
                table: "Request",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Book_Book_Id",
                table: "Request",
                column: "Book_Id",
                principalTable: "Book",
                principalColumn: "Book_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Request_Book_Book_Id",
                table: "Request");

            migrationBuilder.AlterColumn<string>(
                name: "Book_Id",
                table: "Request",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Import_Id",
                table: "Request",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Request_Import_Id",
                table: "Request",
                column: "Import_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Book_Book_Id",
                table: "Request",
                column: "Book_Id",
                principalTable: "Book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Request_Importation_Import_Id",
                table: "Request",
                column: "Import_Id",
                principalTable: "Importation",
                principalColumn: "Import_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
