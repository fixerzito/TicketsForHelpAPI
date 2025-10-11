using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Interfaces.Repositories.Ticket;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories.Ticket;

public class TicketRepository : BaseRepository<Domain.Entities.Ticket.Ticket>, ITicketRepository
{
    private readonly TicketsForHelpContext _context;
    private readonly DbSet<Domain.Entities.Ticket.Ticket> _dbSet;
    
    public TicketRepository(TicketsForHelpContext contexto) : base(contexto)
    {
        _context = contexto;
        _dbSet = _context.Set<Domain.Entities.Ticket.Ticket>();
    }
}