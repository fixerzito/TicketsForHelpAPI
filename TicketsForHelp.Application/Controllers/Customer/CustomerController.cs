using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TicketsForHelp.Domain.DTOs.Customer;
using TicketsForHelp.Domain.Interfaces.Services.Customer;
using TicketsForHelp.Domain.ViewModels.Customer;

namespace TicketsForHelp.Application.Controllers.Customer;

[Route("api/customers")]
[ApiController]
public class CustomerController : Controller
{
    private readonly ICustomerService _service;
    
    public CustomerController(ICustomerService service)
    {
        _service = service;
    }
    
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var dtos = await _service.GetAllAsync();
            var customers = new List<CustomerViewModel>();

            foreach (var dto in dtos)
            {
                var customer = new CustomerViewModel
                {
                    Id = dto.Id,
                    Name = dto.Name,
                    Email = dto.Email,
                    CNPJ =  dto.CNPJ
                };
                
                customers.Add(customer);
            }

            return Ok(customers);
        }
        
        [HttpGet("dropdown")]
        public async Task<IActionResult> GetAllDropdown()
        {
            var dtos = await _service.GetAllAsync();
            var customers = new List<CustomerDropdownViewModel>();

            foreach (var dto in dtos)
            {
                var customer = new CustomerDropdownViewModel
                {
                    Id = dto.Id,
                    Name = dto.Name
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

            var customer = new CustomerViewModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                CNPJ = dto.CNPJ
            };

            return Ok(customer);
        }
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerFormInsertDto dto)
        {
            var id = await _service.AddAsync(dto);

            var response = new CustomerResponseViewModel
            {
                Id = id,
                Name = dto.Name,
                Email = dto.Email,
                CNPJ = dto.CNPJ
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
        public async Task<IActionResult> Update(int id, CustomerFormUpdateDto dto)
        {
            if (id != dto.Id)
                return BadRequest(new { message = "ID mismatch between URL and body." });

            try
            {
                await _service.UpdateAsync(dto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                // Caso o customer não exista
                return NotFound(new { message = $"Cliente com ID {id} não encontrado." });
            }
            catch (Exception e)
            {
                // Retorna a mensagem real do erro para debugging
                return StatusCode(500, new { message = "Erro ao atualizar cliente.", details = e.Message });
            }
        }

}