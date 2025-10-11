namespace TicketsForHelp.Domain.DTOs.Customer;

public class CustomerTableDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? CNPJ { get; set; }
}