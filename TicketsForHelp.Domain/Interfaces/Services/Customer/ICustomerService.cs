using TicketsForHelp.Domain.DTOs.Customer;

namespace TicketsForHelp.Domain.Interfaces.Services.Customer;

public interface ICustomerService
{
    Task<List<CustomerTableDto>> GetAllAsync();
    Task<List<CustomerDropdownDto>> GetAllDropdownAsync();
    Task<CustomerViewDto?> GetByIdAsync(int id);
    Task<int> AddAsync(CustomerFormInsertDto dto);
    Task UpdateAsync(CustomerFormUpdateDto dto);
    Task DeleteAsync(int id);
}