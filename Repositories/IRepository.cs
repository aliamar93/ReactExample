using System;
using System.Collections.Generic;

namespace AutostoreProject.Repositories;

public interface IRepository<T> where T:class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int Id);
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);


}
