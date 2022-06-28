using System.Linq.Expressions;
using Margs.Api.Entities;

namespace Margs.Api.Services.Interfaces;

public interface IGenericRepo<T> where T : BaseEntity<Guid>
{
    int GetTotalRecordsCount();

    Task<List<T>> GetAllAsync();

    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where);

    Task<T> GetByIdAsync(Guid id);

    Task InsertAsync(T entity);

    Task BulkInsertAsync(IEnumerable<T> entity);

    Task DeleteAsync(T entity);

    IQueryable<T> Query(params Expression<Func<T, object>>[] navigationProperties);

    Task<List<T>> QueryAsync(Expression<Func<T, bool>> where,
        params Expression<Func<T, object>>[] navigationProperties);
}