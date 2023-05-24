using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealingAndHealthCareSystem.Migrations
{
    /// <inheritdoc />
    public partial class hehlocalv17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    paymentID = table.Column<Guid>(type: "uuid", nullable: false),
                    orderID = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<int>(type: "integer", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    vnpTmnCode = table.Column<string>(name: "vnp_TmnCode", type: "text", nullable: false),
                    vnpAmount = table.Column<string>(name: "vnp_Amount", type: "text", nullable: false),
                    vnpBankCode = table.Column<string>(name: "vnp_BankCode", type: "text", nullable: false),
                    vnpBankTranNo = table.Column<string>(name: "vnp_BankTranNo", type: "text", nullable: false),
                    vnpCardType = table.Column<string>(name: "vnp_CardType", type: "text", nullable: false),
                    vnpPayDate = table.Column<string>(name: "vnp_PayDate", type: "text", nullable: false),
                    vnpOrderInfo = table.Column<string>(name: "vnp_OrderInfo", type: "text", nullable: false),
                    vnpTransactionNo = table.Column<string>(name: "vnp_TransactionNo", type: "text", nullable: false),
                    vnpResponseCode = table.Column<string>(name: "vnp_ResponseCode", type: "text", nullable: false),
                    vnpTransactionStatus = table.Column<string>(name: "vnp_TransactionStatus", type: "text", nullable: false),
                    vnpTxnRef = table.Column<string>(name: "vnp_TxnRef", type: "text", nullable: false),
                    vnpSecureHashType = table.Column<string>(name: "vnp_SecureHashType", type: "text", nullable: false),
                    vnpSecureHash = table.Column<string>(name: "vnp_SecureHash", type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.paymentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");
        }
    }
}
