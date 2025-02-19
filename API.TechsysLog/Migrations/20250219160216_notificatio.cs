using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.TechsysLog.Migrations
{
    /// <inheritdoc />
    public partial class notificatio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "order",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order",
                column: "DeliveryId",
                principalTable: "delivery",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order");

            migrationBuilder.AlterColumn<int>(
                name: "DeliveryId",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order",
                column: "DeliveryId",
                principalTable: "delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
