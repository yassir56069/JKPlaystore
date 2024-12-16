using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JKPlaystore.Migrations
{
    /// <inheritdoc />
    public partial class InitialConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BCO_Users",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserPass = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BCO_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CustomerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerNote = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                    table.UniqueConstraint("AK_Customers_CustomerKey", x => x.CustomerKey);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    DeviceID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DeviceModel = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.DeviceID);
                    table.UniqueConstraint("AK_Devices_DeviceCode", x => x.DeviceCode);
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    TokenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TokenInitDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.TokenID);
                    table.UniqueConstraint("AK_Tokens_TokenValue", x => x.TokenValue);
                    table.ForeignKey(
                        name: "FK_Tokens_Customers_CustomerKey",
                        column: x => x.CustomerKey,
                        principalTable: "Customers",
                        principalColumn: "CustomerKey",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDevices",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    DeviceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDevices", x => new { x.CustomerID, x.DeviceID });
                    table.ForeignKey(
                        name: "FK_CustomerDevices_Customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "Customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerDevices_Devices_DeviceID",
                        column: x => x.DeviceID,
                        principalTable: "Devices",
                        principalColumn: "DeviceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "APKInfos",
                columns: table => new
                {
                    APKID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    APKName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    APKPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ApkVerNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeviceCode = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TokenValue = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_APKInfos", x => x.APKID);
                    table.ForeignKey(
                        name: "FK_APKInfos_Devices_DeviceCode",
                        column: x => x.DeviceCode,
                        principalTable: "Devices",
                        principalColumn: "DeviceCode",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_APKInfos_Tokens_TokenValue",
                        column: x => x.TokenValue,
                        principalTable: "Tokens",
                        principalColumn: "TokenValue",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_APKInfos_DeviceCode",
                table: "APKInfos",
                column: "DeviceCode");

            migrationBuilder.CreateIndex(
                name: "IX_APKInfos_TokenValue",
                table: "APKInfos",
                column: "TokenValue");

            migrationBuilder.CreateIndex(
                name: "IX_BCO_Users_UserName",
                table: "BCO_Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerDevices_DeviceID",
                table: "CustomerDevices",
                column: "DeviceID");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CustomerKey",
                table: "Customers",
                column: "CustomerKey",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Devices_DeviceCode",
                table: "Devices",
                column: "DeviceCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_CustomerKey",
                table: "Tokens",
                column: "CustomerKey");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_TokenValue",
                table: "Tokens",
                column: "TokenValue",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "APKInfos");

            migrationBuilder.DropTable(
                name: "BCO_Users");

            migrationBuilder.DropTable(
                name: "CustomerDevices");

            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "Devices");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
