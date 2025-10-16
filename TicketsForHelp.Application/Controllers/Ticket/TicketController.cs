using Microsoft.AspNetCore.Mvc;
using TicketsForHelp.Domain.DTOs.Ticket;
using TicketsForHelp.Domain.Interfaces.Services.Ticket;
using TicketsForHelp.Domain.ViewModels.Ticket;

namespace TicketsForHelp.Application.Controllers.Ticket;

[Route("api/tickets")]
[ApiController]
public class TicketController : Controller
{
    private readonly ITicketService _service;

    public TicketController(ITicketService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await _service.GetAllAsync();
        var customers = new List<TicketViewModel>();

        foreach (var dto in dtos)
        {
            var customer = new TicketViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Status = dto.Status,
                IdCustomer = dto.IdCustomer
            };

            customers.Add(customer);
        }

        return Ok(customers);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);

        if (dto is null)
        {
            return NotFound();
        }

        var ticket = new TicketViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            Status = dto.Status,
            Issue = dto.Issue,
            IdCustomer = dto.IdCustomer,
        };

        return Ok(ticket);
    }

    [HttpPost]
    public async Task<IActionResult> Add(TicketFormInsertDto dto)
    {
        var id = await _service.AddAsync(dto);

        var response = new TicketResponseViewModel
        {
            Id = id,
            Name = dto.Name,
            Status = dto.Status,
            Issue = dto.Issue,
            IdCustomer = dto.IdCustomer,
        };

        return CreatedAtAction(nameof(GetById), new { id = id }, response);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
        catch
        {
            return BadRequest();
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TicketFormUpdateDto dto)
    {
        if (id != dto.Id)
            return BadRequest("ID mismatch");

        try
        {
            await _service.UpdateAsync(dto);
            return NoContent();
        }
        catch (Exception e)
        {
            throw new Exception("An error ocurred when tried to update customer");
        }
    }
}