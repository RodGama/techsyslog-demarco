using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.TechsysLog.Migrations
{
    /// <inheritdoc />
    public partial class notification : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "delivery",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "notification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryId = table.Column<int>(type: "int", nullable: false),
                    NotifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_notification_delivery_DeliveryId",
                        column: x => x.DeliveryId,
                        principalTable: "delivery",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_notification_DeliveryId",
                table: "notification",
                column: "DeliveryId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "notification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeliveryDate",
                table: "delivery",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
