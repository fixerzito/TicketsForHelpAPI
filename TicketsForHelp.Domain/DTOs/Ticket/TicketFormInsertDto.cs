namespace TicketsForHelp.Domain.DTOs.Ticket;

public class TicketFormInsertDto
{
    public string Name { get; set; }
    public string Issue { get; set; }
    public bool Status { get; set; }
    public string Criticity { get; set; }
    public int IdCustomer { get; set; }
    public int IdEmployee { get; set; }
}