using System.Linq.Expressions;
using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos;

public class GenericRepo<T> : IGenericRepo<T> where T : BaseEntity<Guid>
{
    private readonly PgDbContext _context;

    private readonly DbSet<T> _entities;
    private readonly ILogger _logger;

    public GenericRepo(PgDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        _entities = context.Set<T>();
    }

    public int GetTotalRecordsCount()
        =>
            _entities.Count();

    public async Task<List<T>> GetAllAsync()
        =>
            await (from e in _entities
                select e).AsNoTracking().ToListAsync();


    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> where)
        =>
            await (from e in _entities
                where @where.GetType() == typeof(T)
                select e).AsNoTracking().ToListAsync();

    public async Task<T> GetByIdAsync(Guid id)
        =>
            (await (from e in _entities
                where e.Id == id
                select e).AsNoTracking().FirstOrDefaultAsync())!;

    public async Task InsertAsync(T entity)
        =>
            await _entities.AddAsync(entity);

    public async Task BulkInsertAsync(IEnumerable<T> entity)
        =>
            await _entities.AddRangeAsync(entity);

    public Task DeleteAsync(T entity)
        =>
            Task.FromResult(_entities.Remove(entity));

    public IQueryable<T> Query(params Expression<Func<T, object>>[] navigationProperties)
        =>
            navigationProperties.Aggregate<Expression<System.Func<T, object>>?, System.Linq.IQueryable<T>>(_entities,
                (current, navigationProperty) => current.Include(navigationProperty!));

    public async Task<List<T>> QueryAsync(Expression<Func<T, bool>> where,
        params Expression<Func<T, object>>[] navigationProperties)
    {
        var dbQuery = navigationProperties.Aggregate<Expression<Func<T, object>>, IQueryable<T>>
            (_entities, (current, navigationProperty) => current.Include(navigationProperty));
        return await dbQuery.Where(where).ToListAsync();
    }
}