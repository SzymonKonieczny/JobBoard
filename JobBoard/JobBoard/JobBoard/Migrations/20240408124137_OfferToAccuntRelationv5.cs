using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    /// <inheritdoc />
    public partial class OfferToAccuntRelationv5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_OwnedById",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_OwnedById",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "OwnedById",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "CompanyID",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Offers_CompanyID",
                table: "Offers",
                column: "CompanyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_CompanyID",
                table: "Offers",
                column: "CompanyID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_AspNetUsers_CompanyID",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_CompanyID",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "CompanyID",
                table: "Offers");

            migrationBuilder.AddColumn<string>(
                name: "OwnedById",
                table: "Offers",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_OwnedById",
                table: "Offers",
                column: "OwnedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_AspNetUsers_OwnedById",
                table: "Offers",
                column: "OwnedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
