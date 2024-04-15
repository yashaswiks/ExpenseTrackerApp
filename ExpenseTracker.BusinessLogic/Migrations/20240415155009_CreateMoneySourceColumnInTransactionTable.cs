using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class CreateMoneySourceColumnInTransactionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MoneySourceId",
                table: "Transactions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MoneySourceId",
                table: "Transactions",
                column: "MoneySourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_CodeValues_MoneySourceId",
                table: "Transactions",
                column: "MoneySourceId",
                principalTable: "CodeValues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_CodeValues_MoneySourceId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_MoneySourceId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "MoneySourceId",
                table: "Transactions");
        }
    }
}
