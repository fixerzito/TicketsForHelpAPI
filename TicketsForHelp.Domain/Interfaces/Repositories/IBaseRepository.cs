namespace TicketsForHelp.Domain.Interfaces.Repositories;

public interface IBaseRepository<T>
{
    Task<IList<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}