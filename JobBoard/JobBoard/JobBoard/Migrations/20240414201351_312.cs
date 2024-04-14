using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JobBoard.Migrations
{
    /// <inheritdoc />
    public partial class _312 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApplication_Offers_JobOfferId",
                table: "UserApplication");

            migrationBuilder.AlterColumn<int>(
                name: "JobOfferId",
                table: "UserApplication",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplication_Offers_JobOfferId",
                table: "UserApplication",
                column: "JobOfferId",
                principalTable: "Offers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserApplication_Offers_JobOfferId",
                table: "UserApplication");

            migrationBuilder.AlterColumn<int>(
                name: "JobOfferId",
                table: "UserApplication",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserApplication_Offers_JobOfferId",
                table: "UserApplication",
                column: "JobOfferId",
                principalTable: "Offers",
                principalColumn: "Id");
        }
    }
}
