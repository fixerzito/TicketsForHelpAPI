namespace TicketsForHelp.Domain.Entities.Ticket;

public class TicketCategory : EntityBase
{
    public int IdTicket { get; set; }
    public virtual Ticket Ticket { get; set; }
}