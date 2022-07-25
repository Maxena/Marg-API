using Microsoft.EntityFrameworkCore;

namespace Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();
    int SaveChanges(bool acceptAllChangesOnSuccess);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
}