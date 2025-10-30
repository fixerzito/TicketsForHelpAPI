namespace TicketsForHelp.Domain.Interfaces.Services.Ticket;

public interface ITicketCategoryService
{
    Task<List<TicketCategoryTableDto>> GetAllAsync();
    Task<TicketCategoryViewDto?> GetByIdAsync(int id);
    Task<int> AddAsync(TicketCategoryFormInsertDto dto);
    Task UpdateAsync(TicketCategoryFormUpdateDto dto);
    Task DeleteAsync(int id);
}