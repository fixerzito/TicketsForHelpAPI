using TicketsForHelp.Domain.DTOs.Employee;

namespace TicketsForHelp.Domain.Interfaces.Services.Employee;

public interface IEmployeeService
{
    Task<List<EmployeeTableDto>> GetAllAsync();
    Task<List<EmployeeDropdownDto>> GetAllDropdownAsync();
    Task<EmployeeDto?> GetByIdAsync(int id);
    Task<int> AddAsync(EmployeeFormInsertDto dto);
    Task UpdateAsync(EmployeeFormUpdateDto dto);
    Task DeleteAsync(int id);
}