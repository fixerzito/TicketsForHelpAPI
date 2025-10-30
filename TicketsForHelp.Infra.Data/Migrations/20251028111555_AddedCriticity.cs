using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsForHelp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedCriticity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Criticity",
                table: "ticket",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Criticity",
                table: "ticket");
        }
    }
}
