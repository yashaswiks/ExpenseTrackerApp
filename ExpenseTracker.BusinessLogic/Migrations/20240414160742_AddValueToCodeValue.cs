using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExpenseTracker.BusinessLogic.Migrations
{
    /// <inheritdoc />
    public partial class AddValueToCodeValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "CodeValues",
                type: "varchar(200)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "CodeValues");
        }
    }
}
