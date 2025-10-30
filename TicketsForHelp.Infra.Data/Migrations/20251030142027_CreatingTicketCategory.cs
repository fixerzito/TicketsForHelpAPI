using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketsForHelp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreatingTicketCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ticket_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdTicket = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(150)", nullable: false),
                    active_register = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket_category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ticket_category_ticket_IdTicket",
                        column: x => x.IdTicket,
                        principalTable: "ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ticket_category_IdTicket",
                table: "ticket_category",
                column: "IdTicket");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket_category");
        }
    }
}
