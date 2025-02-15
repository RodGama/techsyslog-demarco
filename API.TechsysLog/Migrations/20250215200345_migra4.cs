using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.TechsysLog.Migrations
{
    /// <inheritdoc />
    public partial class migra4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder");

            migrationBuilder.RenameTable(
                name: "UserOrder",
                newName: "user_order");

            migrationBuilder.RenameIndex(
                name: "IX_UserOrder_OrderNumber_UserId",
                table: "user_order",
                newName: "IX_user_order_OrderNumber_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_order",
                table: "user_order",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_user_order",
                table: "user_order");

            migrationBuilder.RenameTable(
                name: "user_order",
                newName: "UserOrder");

            migrationBuilder.RenameIndex(
                name: "IX_user_order_OrderNumber_UserId",
                table: "UserOrder",
                newName: "IX_UserOrder_OrderNumber_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOrder",
                table: "UserOrder",
                column: "Id");
        }
    }
}
