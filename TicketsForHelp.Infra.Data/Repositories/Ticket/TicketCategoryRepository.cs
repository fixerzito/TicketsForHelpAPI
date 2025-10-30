using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Entities.Ticket;
using TicketsForHelp.Domain.Interfaces.Repositories.Ticket;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories.Ticket;

public class TicketCategoryRepository : BaseRepository<TicketCategory>, ITicketCategoryRepository
{
    private readonly TicketsForHelpContext _context;
    private readonly DbSet<TicketCategory> _dbSet;
    
    public TicketCategoryRepository(TicketsForHelpContext context) : base(context)
    {
        _context = context;
        _dbSet = _context.Set<TicketCategory>();
    }

    public async Task<IList<TicketCategory>> GetAllAsync()
    {
        return await _dbSet
            .Include(x => x.Ticket)   
            .ToListAsync();
    }
    
    public async Task<TicketCategory?> GetByIdAsync(int id)
    {
        return await _dbSet.Include(x => x!.Ticket)
            .FirstOrDefaultAsync(x => x!.Id == id);
    }
}