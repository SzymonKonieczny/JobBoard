using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    /// <inheritdoc />
    public partial class OfferToAccuntRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
