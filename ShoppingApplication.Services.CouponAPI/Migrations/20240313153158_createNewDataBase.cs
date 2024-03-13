using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingApplication.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class createNewDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_coupons",
                table: "coupons");

            migrationBuilder.RenameTable(
                name: "coupons",
                newName: "Coupons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons",
                column: "CouponId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Coupons",
                table: "Coupons");

            migrationBuilder.RenameTable(
                name: "Coupons",
                newName: "coupons");

            migrationBuilder.AddPrimaryKey(
                name: "PK_coupons",
                table: "coupons",
                column: "CouponId");
        }
    }
}
