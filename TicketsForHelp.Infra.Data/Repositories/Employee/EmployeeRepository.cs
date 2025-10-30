using TicketsForHelp.Domain.Interfaces.Repositories.Employee;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories.Employee;

public class EmployeeRepository : BaseRepository<Domain.Entities.Employee.Employee>, IEmployeeRepository
{
    public EmployeeRepository(TicketsForHelpContext contexto) : base(contexto)
    {
    }
}