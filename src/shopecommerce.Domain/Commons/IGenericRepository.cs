namespace shopecommerce.Domain.Commons;

public interface IGenericRepository<T> where T : class
{
    IUnitOfWork UnitOfWork { get; }
    Task<T> GetByIdAsync(string id);
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}