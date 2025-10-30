using TicketsForHelp.Domain.DTOs.Employee;
using TicketsForHelp.Domain.Interfaces.Repositories.Employee;
using TicketsForHelp.Domain.Interfaces.Services.Employee;

namespace TicketsForHelp.Service.Services.Employee;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _repository;

    public EmployeeService(IEmployeeRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<EmployeeTableDto>> GetAllAsync()
    {
        var employees = await _repository.GetAllAsync();
        var dtos = new List<EmployeeTableDto>();

        foreach (var employee in employees)
        {
            var dto = new EmployeeTableDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Photo = employee.Photo
            };
            dtos.Add(dto);
        }

        return dtos;
    }
    
    public async Task<List<EmployeeDropdownDto>> GetAllDropdownAsync()
    {
        var employees = await _repository.GetAllAsync();
        var dtos = new List<EmployeeDropdownDto>();

        foreach (var employee in employees)
        {
            var dto = new EmployeeDropdownDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Photo = employee.Photo
            };
            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<EmployeeDto?> GetByIdAsync(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee is null)
            return null;


        return new EmployeeDto
        {
            Id = employee.Id,
            Name = employee.Name,
            CPF = employee.CPF,
            Login = employee.Login,
            Email = employee.Email,
            Password = employee.Password,
            Photo = employee.Photo
        };
    }

    public async Task<int> AddAsync(EmployeeFormInsertDto dto)
    {
        var employee = new Domain.Entities.Employee.Employee
        {
            Name = dto.Name,
            CPF = dto.CPF,
            Email = dto.Email,
            Login = dto.Login,
            Password = dto.Password,
            Photo = dto.Photo
        };

        await _repository.AddAsync(employee);
        return employee.Id;
    }

    public async Task UpdateAsync(EmployeeFormUpdateDto dto)
    {
        var employee = await _repository.GetByIdAsync(dto.Id);
        if (employee is null)
            throw new Exception("Employee not found");

        employee.Name = dto.Name!;
        employee.CPF = dto.CPF!;
        employee.Email = dto.Email!;
        employee.Login = dto.Login!;
        employee.Password = dto.Password!;
        employee.Photo = dto.Photo!;

        await _repository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        var employee = await _repository.GetByIdAsync(id);
        if (employee is null)
            throw new Exception("Employee not found");

        employee.ActiveRegister = false;

        await _repository.UpdateAsync(employee);
    }
}