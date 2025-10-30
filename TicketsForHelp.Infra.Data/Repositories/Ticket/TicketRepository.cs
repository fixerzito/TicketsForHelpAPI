using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Interfaces.Repositories.Ticket;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories.Ticket;

public class TicketRepository : BaseRepository<Domain.Entities.Ticket.Ticket>, ITicketRepository
{
    private readonly TicketsForHelpContext _context;
    private readonly DbSet<Domain.Entities.Ticket.Ticket> _dbSet;
    
    public TicketRepository(TicketsForHelpContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<Domain.Entities.Ticket.Ticket>();
    }

    public async Task<IList<Domain.Entities.Ticket.Ticket>> GetAllAsync()
    {
        return await _dbSet
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .ToListAsync();
    }
    
    public async Task<Domain.Entities.Ticket.Ticket?> GetByIdAsync(int id)
    {
        return (await _dbSet
            .Include(x => x.Employee)
            .Include(x => x.Customer)
            .FirstOrDefaultAsync(x => x.Id == id))!;
    }
    
}