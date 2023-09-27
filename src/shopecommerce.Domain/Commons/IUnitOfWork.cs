namespace shopecommerce.Domain.Commons;

public interface IUnitOfWork : IDisposable
{
    Task<bool> SaveEntitiesChangeAsync(CancellationToken cancellationToken = default);
}