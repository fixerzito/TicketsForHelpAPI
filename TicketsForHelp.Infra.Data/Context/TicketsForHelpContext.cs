using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Entities.Customers;
using TicketsForHelp.Domain.Entities.Employee;
using TicketsForHelp.Domain.Entities.Ticket;
using TicketsForHelp.Infra.Data.Mapping.Customer;
using TicketsForHelp.Infra.Data.Mapping.Employee;
using TicketsForHelp.Infra.Data.Mapping.Ticket;

namespace TicketsForHelp.Infra.Data.Context;

public class TicketsForHelpContext : DbContext
{
    public TicketsForHelpContext(DbContextOptions<TicketsForHelpContext> options) : base(options) {}    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new CustomerMapping());
        modelBuilder.ApplyConfiguration(new TicketMapping());
        modelBuilder.ApplyConfiguration(new EmployeeMapping());

        modelBuilder.Entity<Customer>()
            .HasQueryFilter(e => e.ActiveRegister);
        modelBuilder.Entity<Ticket>()
            .HasQueryFilter(e => e.ActiveRegister);
        modelBuilder.Entity<Employee>()
            .HasQueryFilter(e => e.ActiveRegister);
    }
}