namespace TicketsForHelp.Domain.DTOs.Ticket;

public class TicketViewDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Issue { get; set; }
    public bool Status { get; set; }
    public int IdCustomer { get; set; }
    public string Customer { get; set; }
    public int? IdEmployee { get; set; }
    public string? Employee { get; set; }
}