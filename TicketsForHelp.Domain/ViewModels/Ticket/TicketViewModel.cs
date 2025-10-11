namespace TicketsForHelp.Domain.ViewModels.Ticket;

public class TicketViewModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Issue { get; set; }
    public bool Status { get; set; }
    public int IdCustomer { get; set; }
}