using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutomaticInfotch_Assignment.Migrations
{
    /// <inheritdoc />
    public partial class thirdnew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ShortText = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LongText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ReorderLevel = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MinOrderQuantity = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseOrders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Vendor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrderValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseOrders", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "Vendors",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ValidTillDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendors", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "LineItem",
                columns: table => new
                {
                    LineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UOM = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Rate = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExpectedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PurchaseOrderOrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItem", x => x.LineId);
                    table.ForeignKey(
                        name: "FK_LineItem_PurchaseOrders_PurchaseOrderOrderId",
                        column: x => x.PurchaseOrderOrderId,
                        principalTable: "PurchaseOrders",
                        principalColumn: "OrderId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LineItem_PurchaseOrderOrderId",
                table: "LineItem",
                column: "PurchaseOrderOrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItem");

            migrationBuilder.DropTable(
                name: "Materials");

            migrationBuilder.DropTable(
                name: "Vendors");

            migrationBuilder.DropTable(
                name: "PurchaseOrders");
        }
    }
}
