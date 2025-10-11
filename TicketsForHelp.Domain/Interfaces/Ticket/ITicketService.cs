using System.Collections.Generic;
using System.Threading.Tasks;
using TicketsForHelp.Domain.DTOs.Ticket;

namespace TicketsForHelp.Domain.Interfaces.Ticket;

public interface ITicketService
{
    Task<List<TicketTableDto>> GetAllAsync();
    Task<TicketViewDto?> GetByIdAsync(int id);
    Task<int> AddAsync(TicketFormInsertDto dto);
    Task UpdateAsync(TicketFormUpdateDto dto);
    Task DeleteAsync(int id);
}