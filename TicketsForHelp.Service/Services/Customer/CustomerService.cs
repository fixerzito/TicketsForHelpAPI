using TicketsForHelp.Domain.DTOs.Customer;
using TicketsForHelp.Domain.Interfaces.Repositories.Customer;
using TicketsForHelp.Domain.Interfaces.Services.Customer;

namespace TicketsForHelp.Service.Services.Customer;

public class CustomerService : ICustomerService
{
    private readonly ICustomerRepository _repository;

    public CustomerService(ICustomerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<CustomerTableDto>> GetAllAsync()
    {
        var customers = await _repository.GetAllAsync();
        var dtos = new List<CustomerTableDto>();

        foreach (var customer in customers)
        {
            var dto = new CustomerTableDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Email = customer.Email,
                CNPJ = customer.CNPJ
            };

            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<List<CustomerDropdownDto>> GetAllDropdownAsync()
    {
        var customers = await _repository.GetAllAsync();
        var dtos = new List<CustomerDropdownDto>();

        foreach (var customer in customers)
        {
            var dto = new CustomerDropdownDto
            {
                Id = customer.Id,
                Name = customer.Name,
            };

            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<CustomerViewDto?> GetByIdAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            return null;


        return new CustomerViewDto
        {
            Id = customer.Id,
            Name = customer.Name,
            Email = customer.Email,
            CNPJ = customer.CNPJ
        };
    }

    public async Task<int> AddAsync(CustomerFormInsertDto dto)
    {
        var customer = new Domain.Entities.Customers.Customer()
        {
            Name = dto.Name!,
            Email = dto.Email!,
            CNPJ = dto.CNPJ!
        };

        await _repository.AddAsync(customer);
        return customer.Id;
    }

    public async Task UpdateAsync(CustomerFormUpdateDto dto)
    {
        var customer = await _repository.GetByIdAsync(dto.Id);
        if (customer is null)
            throw new Exception("Customer not found");

        customer.Name = dto.Name!;
        customer.Email = dto.Email!;
        customer.CNPJ = dto.CNPJ!;

        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        var customer = await _repository.GetByIdAsync(id);
        if (customer is null)
            throw new Exception("Customer not found");

        customer.ActiveRegister = false;

        await _repository.UpdateAsync(customer);
    }
}