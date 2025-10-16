using TicketsForHelp.Domain.DTOs.Ticket;
using TicketsForHelp.Domain.Interfaces.Repositories.Ticket;
using TicketsForHelp.Domain.Interfaces.Services.Ticket;

namespace TicketsForHelp.Service.Services.Ticket;

public class TicketService : ITicketService
{
    private readonly ITicketRepository _repository;

    public TicketService(ITicketRepository repository)
    {
        _repository = repository;
    }


    public async Task<List<TicketTableDto>> GetAllAsync()
    {
        var tickets = await _repository.GetAllAsync();
        var dtos = new List<TicketTableDto>();

        foreach (var ticket in tickets)
        {
            var dto = new TicketTableDto
            {
                Id = ticket.Id,
                Name = ticket.Name,
                IdCustomer = ticket.IdCustomer,
                Status = ticket.Status
            };

            dtos.Add(dto);
        }

        return dtos;
    }

    public async Task<TicketViewDto?> GetByIdAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket is null)
            return null;


        return new TicketViewDto
        {
            Id = ticket.Id,
            Name = ticket.Name,
            Issue = ticket.Issue,
            Status = ticket.Status,
            IdCustomer = ticket.IdCustomer
        };
    }

    public async Task<int> AddAsync(TicketFormInsertDto dto)
    {
        var ticket = new Domain.Entities.Ticket.Ticket()
        {
            Name = dto.Name,
            Issue = dto.Issue,
            Status = dto.Status,
            IdCustomer = dto.IdCustomer
        };

        await _repository.AddAsync(ticket);
        return ticket.Id;
    }

    public async Task UpdateAsync(TicketFormUpdateDto dto)
    {
        var customer = await _repository.GetByIdAsync(dto.Id);
        if (customer is null)
            throw new Exception("Ticket not found");

        customer.Name = dto.Name!;
        customer.Issue = dto.Issue!;
        customer.Status = dto.Status!;
        customer.IdCustomer = dto.IdCustomer!;

        await _repository.UpdateAsync(customer);
    }

    public async Task DeleteAsync(int id)
    {
        var ticket = await _repository.GetByIdAsync(id);
        if (ticket is null)
            throw new Exception("Ticket not found");

        ticket.ActiveRegister = false;

        await _repository.UpdateAsync(ticket);
    }
}