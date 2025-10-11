namespace TicketsForHelp.Domain.DTOs.Ticket;

public class TicketTableDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int IdCustomer { get; set; }
    public bool Status { get; set; }
}