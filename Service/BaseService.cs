// public partial class BaseService<T> : IBaseService<T> where T : class
// {
//     private readonly IRepository<T> _repository;
//     public BaseService(IRepository<T> repository)
//     {
//         _repository = repository;
//     }
//     public async Task<IEnumerable<T>> GetAllAsync() => await _repository.GetAllAsync();
//     public async Task<T?> GetByIdAsync(int id) => await _repository.GetByIdAsync(id);
//     public async Task AddAsync(T entity) => await _repository.AddAsync(entity);
//     public async Task DeleteAsync(int id) => await _repository.DeleteAsync(id);
//     public async Task UpdateAsync(T entity) => await _repository.UpdateAsync(entity);
//     public async Task<IEnumerable<T>> GetByConditionAsync(Func<T, bool> predicate) => await _repository.GetByConditionAsync(predicate);
//     public async Task<T?> GetSingleByConditionAsync(Func<T, bool> predicate) => await _repository.GetSingleByConditionAsync(predicate);

// }