using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.TechsysLog.Migrations
{
    /// <inheritdoc />
    public partial class migra2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "delivery",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNumber = table.Column<long>(type: "bigint", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_delivery", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_OrderNumber",
                table: "order",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_delivery_OrderNumber",
                table: "delivery",
                column: "OrderNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "delivery");

            migrationBuilder.DropIndex(
                name: "IX_order_OrderNumber",
                table: "order");
        }
    }
}
