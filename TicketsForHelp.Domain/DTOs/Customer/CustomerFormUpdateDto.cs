namespace TicketsForHelp.Domain.DTOs.Customer;

public class CustomerFormUpdateDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CNPJ { get; set; }
}