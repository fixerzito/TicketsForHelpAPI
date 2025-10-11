namespace TicketsForHelp.Domain.DTOs.Ticket;

public class TicketViewDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Issue { get; set; }
    public bool Status { get; set; }
    public int IdCustomer { get; set; }
}