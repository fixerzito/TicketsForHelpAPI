namespace TicketsForHelp.Domain.DTOs.Employee;

public class EmployeeFormInsertDto
{
    public string Name { get; set; }
    public string CPF { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Photo { get; set; }
}