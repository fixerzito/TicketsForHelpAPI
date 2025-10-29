namespace TicketsForHelp.Domain.DTOs.Ticket;

public class TicketTableDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Criticity { get; set; }
    public string Customer { get; set; }
    public string? Employee { get; set; }
    public bool Status { get; set; }
}