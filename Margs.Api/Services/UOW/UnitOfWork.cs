using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Interfaces.County;
using Margs.Api.Services.Interfaces.User_Role;
using Margs.Api.Services.Repos.County;
using Margs.Api.Services.Repos.User_Role;

namespace Margs.Api.Services.UOW;

public class UnitOfWork : IUnitOfWork
{
    private readonly PgDbContext _context;

    public IUserService User { get; private set; }
    public IRoleService Role { get; private set; }
    public IAddressService Address { get; private set; }
    public ICityService City { get; private set; }
    public IProvinceService Province { get; private set; }

    public UnitOfWork(PgDbContext context)
    {
        _context = context;
        User = new UserService(context);
        Role = new RoleService(context);
        Address = new AddressService(context);
        City = new CityService(context);
        Province = new ProvincService(context);
    }

    public void Dispose() => _context.Dispose();

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    
}