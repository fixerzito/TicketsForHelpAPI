using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Interfaces.Repositories.Customer;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories.Customer;

public class CustomerRepository : BaseRepository<Domain.Entities.Customers.Customer>, ICustomerRepository 
{
    private readonly TicketsForHelpContext _context;
    private readonly DbSet<Domain.Entities.Customers.Customer> _dbSet;
    
    public CustomerRepository(TicketsForHelpContext contexto) : base(contexto)
    {
        _context = contexto;
        _dbSet = _context.Set<Domain.Entities.Customers.Customer>();
    }
}