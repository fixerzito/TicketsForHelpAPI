using TicketsForHelp.Domain.Entities.Customers;

namespace TicketsForHelp.Domain.Entities.Ticket;

public class Ticket : EntityBase
{
    public string Issue { get; set; }
    public bool Status { get; set; }
    public int IdCustomer { get; set; }
    public int? IdEmployee { get; set; }
    public virtual Customer Customer { get; set; }
    public virtual Employee.Employee Employee { get; set; }
}