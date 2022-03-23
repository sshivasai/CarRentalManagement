using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRentalManagement___DataAccessLayer.Migrations
{
    public partial class DataBaseFiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdminDtos",
                columns: table => new
                {
                    AdminId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDtos", x => x.AdminId);
                });

            migrationBuilder.CreateTable(
                name: "Condition",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    conditionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Condition", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "IDProof",
                columns: table => new
                {
                    IDNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Verification = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IDProof", x => x.IDNumber);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    IsPending = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryStatus = table.Column<bool>(type: "bit", nullable: false),
                    ReturnStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.IsPending);
                });

            migrationBuilder.CreateTable(
                name: "Transmition",
                columns: table => new
                {
                    CarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GearType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transmition", x => x.CarID);
                });

            migrationBuilder.CreateTable(
                name: "UserDtos",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    LName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KycDetailsIDNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDtos", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserDtos_IDProof_KycDetailsIDNumber",
                        column: x => x.KycDetailsIDNumber,
                        principalTable: "IDProof",
                        principalColumn: "IDNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarTypeDto",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gears = table.Column<int>(type: "int", nullable: false),
                    transmitionCarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarTypeDto", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarTypeDto_Transmition_transmitionCarID",
                        column: x => x.transmitionCarID,
                        principalTable: "Transmition",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    PaymentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.PaymentId);
                    table.ForeignKey(
                        name: "FK_Payment_UserDtos_UserId",
                        column: x => x.UserId,
                        principalTable: "UserDtos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarDto",
                columns: table => new
                {
                    CarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    year = table.Column<int>(type: "int", nullable: false),
                    CarTypeCarId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    DailyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DayDelayPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConditionCarID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarDto", x => x.CarId);
                    table.ForeignKey(
                        name: "FK_CarDto_CarTypeDto_CarTypeCarId",
                        column: x => x.CarTypeCarId,
                        principalTable: "CarTypeDto",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarDto_Condition_ConditionCarID",
                        column: x => x.ConditionCarID,
                        principalTable: "Condition",
                        principalColumn: "CarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderedByUserId = table.Column<int>(type: "int", nullable: false),
                    CarDetailsCarId = table.Column<int>(type: "int", nullable: false),
                    PaymentDetailsPaymentId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    OrderStatusIsPending = table.Column<bool>(type: "bit", nullable: false),
                    AdminDtoAdminId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Order_AdminDtos_AdminDtoAdminId",
                        column: x => x.AdminDtoAdminId,
                        principalTable: "AdminDtos",
                        principalColumn: "AdminId");
                    table.ForeignKey(
                        name: "FK_Order_CarDto_CarDetailsCarId",
                        column: x => x.CarDetailsCarId,
                        principalTable: "CarDto",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Payment_PaymentDetailsPaymentId",
                        column: x => x.PaymentDetailsPaymentId,
                        principalTable: "Payment",
                        principalColumn: "PaymentId");
                    table.ForeignKey(
                        name: "FK_Order_Status_OrderStatusIsPending",
                        column: x => x.OrderStatusIsPending,
                        principalTable: "Status",
                        principalColumn: "IsPending",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_UserDtos_OrderedByUserId",
                        column: x => x.OrderedByUserId,
                        principalTable: "UserDtos",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarDto_CarTypeCarId",
                table: "CarDto",
                column: "CarTypeCarId");

            migrationBuilder.CreateIndex(
                name: "IX_CarDto_ConditionCarID",
                table: "CarDto",
                column: "ConditionCarID");

            migrationBuilder.CreateIndex(
                name: "IX_CarTypeDto_transmitionCarID",
                table: "CarTypeDto",
                column: "transmitionCarID");

            migrationBuilder.CreateIndex(
                name: "IX_Order_AdminDtoAdminId",
                table: "Order",
                column: "AdminDtoAdminId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_CarDetailsCarId",
                table: "Order",
                column: "CarDetailsCarId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderedByUserId",
                table: "Order",
                column: "OrderedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusIsPending",
                table: "Order",
                column: "OrderStatusIsPending");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PaymentDetailsPaymentId",
                table: "Order",
                column: "PaymentDetailsPaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_UserId",
                table: "Payment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDtos_KycDetailsIDNumber",
                table: "UserDtos",
                column: "KycDetailsIDNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "AdminDtos");

            migrationBuilder.DropTable(
                name: "CarDto");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "CarTypeDto");

            migrationBuilder.DropTable(
                name: "Condition");

            migrationBuilder.DropTable(
                name: "UserDtos");

            migrationBuilder.DropTable(
                name: "Transmition");

            migrationBuilder.DropTable(
                name: "IDProof");
        }
    }
}
