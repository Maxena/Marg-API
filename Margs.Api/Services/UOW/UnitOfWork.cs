using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.DateTimeProviders;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Interfaces.County;
using Margs.Api.Services.Interfaces.User_Role;
using Margs.Api.Services.Repos.County;
using Margs.Api.Services.Repos.User_Role;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly PgDbContext _context;
    private readonly ILogger _logger;
    public IUserService User { get; private set; }
    public IRoleService Role { get; private set; }
    public IAddressService Address { get; private set; }
    public ICityService City { get; private set; }
    public IProvinceService Province { get; private set; }
    public IUserRoleService UserRole { get; }
    public IDateTimeProvider DateTimeProvider { get; private set; }

    public UnitOfWork(PgDbContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
        User = new UserService(_context, _logger);
        Role = new RoleService(_context, _logger);
        Address = new AddressService(_context, _logger);
        City = new CityService(_context, _logger);
        Province = new ProvincService(_context, _logger);
        UserRole = new UserRoleService(_context, _logger);
        DateTimeProvider = new DateTimeProvider();
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public void Dispose() => _context.Dispose();

}