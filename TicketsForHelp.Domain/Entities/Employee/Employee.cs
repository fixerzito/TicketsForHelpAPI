namespace TicketsForHelp.Domain.Entities.Employee;

public class Employee : EntityBase
{
    public string CPF { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Photo { get; set; }
    public ICollection<Ticket.Ticket> Tickets { get; set; } = new List<Ticket.Ticket>();
}