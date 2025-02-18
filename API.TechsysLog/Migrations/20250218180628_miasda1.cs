using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.TechsysLog.Migrations
{
    /// <inheritdoc />
    public partial class miasda1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeliveryId",
                table: "order",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_order_DeliveryId",
                table: "order",
                column: "DeliveryId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order",
                column: "DeliveryId",
                principalTable: "delivery",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_delivery_DeliveryId",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_DeliveryId",
                table: "order");

            migrationBuilder.DropColumn(
                name: "DeliveryId",
                table: "order");
        }
    }
}
