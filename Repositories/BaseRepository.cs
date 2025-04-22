using System;
using AutostoreProject.DBEntities;
using Microsoft.EntityFrameworkCore;

namespace AutostoreProject.Repositories;

public abstract class BaseRepository<T> : IRepository<T> where T :
class
{
    protected readonly AScaDbContext _DBContext;
    protected readonly DbSet<T> _dbSet;
    public BaseRepository(AScaDbContext DBContext)
    {
        _DBContext=DBContext;
        _dbSet=DBContext.Set<T>();
        
    }
    public virtual async Task<IEnumerable<T>> GetAllAsync()=>await _dbSet.ToListAsync();

    public virtual async Task<T?> GetByIdAsync(int Id)=>await _dbSet.FindAsync(Id);

    public virtual async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
        await _DBContext.SaveChangesAsync();
    }

    public virtual async Task DeleteAsync(int id)
    {
        var entity=await GetByIdAsync(id);
        if(entity != null)
        {
            _dbSet.Remove(entity);
            await _DBContext.SaveChangesAsync();
        }
    }

    public virtual async Task UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _DBContext.SaveChangesAsync();
    }
}
