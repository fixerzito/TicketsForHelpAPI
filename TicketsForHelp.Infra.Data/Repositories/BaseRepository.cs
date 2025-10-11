using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TicketsForHelp.Domain.Entities;
using TicketsForHelp.Domain.Interfaces.Repositories;
using TicketsForHelp.Infra.Data.Context;

namespace TicketsForHelp.Infra.Data.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
{
    private readonly TicketsForHelpContext _context;
    private readonly DbSet<T> _dbSet;
    
    public BaseRepository(TicketsForHelpContext contexto)
    {
        _context = contexto;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<IList<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task DeleteAsync(T entity)
    {
        var entityExist = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (entityExist != null)
        {
            entityExist.ActiveRegister = false;
            _dbSet.Update(entityExist);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(T entity)
    {
        var entityExist = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (entityExist != null)
        {
            _dbSet.Update(entityExist);
            await _context.SaveChangesAsync();
        }
    }
}