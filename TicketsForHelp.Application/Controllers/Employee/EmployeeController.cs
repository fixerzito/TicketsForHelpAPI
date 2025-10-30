using Microsoft.AspNetCore.Mvc;
using TicketsForHelp.Domain.DTOs.Employee;
using TicketsForHelp.Domain.Interfaces.Services.Employee;
using TicketsForHelp.Domain.ViewModels.Employee;

namespace TicketsForHelp.Application.Controllers.Employee;

[Route("api/employees")]
[ApiController]
public class EmployeeController : Controller
{
    private readonly IEmployeeService _service;
    private ILogger<EmployeeController> _logger;

    public EmployeeController(IEmployeeService service, ILogger<EmployeeController> logger)
    {
        _service = service;
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var dtos = await _service.GetAllAsync();
        var customers = new List<EmployeeTableViewModel>();

        foreach (var dto in dtos)
        {
            var customer = new EmployeeTableViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Photo = dto.Photo
            };

            customers.Add(customer);
        }

        return Ok(customers);
    }
    
    [HttpGet("dropdown")]
    public async Task<IActionResult> GetAllDropdown()
    {
        var dtos = await _service.GetAllDropdownAsync();
        var employees = new List<EmployeeDropdownViewModel>();

        foreach (var dto in dtos)
        {
            var customer = new EmployeeDropdownViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Photo = dto.Photo
            };

            employees.Add(customer);
        }

        return Ok(employees);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var dto = await _service.GetByIdAsync(id);

        if (dto is null)
        {
            return NotFound();
        }

        var employee = new EmployeeViewModel
        {
            Id = dto.Id,
            Name = dto.Name,
            CPF = dto.CPF,
            Login = dto.Login,
            Email = dto.Email,
            Password = dto.Password,
            Photo = dto.Photo
        };

        return Ok(employee);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(EmployeeFormInsertDto dto)
    {
        var id = await _service.AddAsync(dto);

        var response = new EmployeeFormInsertDto
        {
            Name = dto.Name,
            CPF = dto.CPF,
            Login = dto.Login,
            Email = dto.Email,
            Password = dto.Password,
            Photo = dto.Photo
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
    public async Task<IActionResult> Update(int id, EmployeeFormUpdateDto dto)
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
            _logger.LogError(e, "Erro ao atualizar funcionário com ID {EmployeeId}", id);
            return StatusCode(500, new { message = e.Message });
        }
    }

}