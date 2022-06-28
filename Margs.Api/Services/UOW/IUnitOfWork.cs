using Margs.Api.Entities;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.Interfaces.County;
using Margs.Api.Services.Interfaces.User_Role;

namespace Margs.Api.Services.UOW;

public interface IUnitOfWork : IDisposable
{
    public IUserService User { get; }
    public IRoleService Role { get; }
    public IAddressService Address { get; }
    public ICityService City { get; }
    public IProvinceService Province { get; }
    public IUserRoleService UserRole { get; }
    public IDateTimeProvider DateTimeProvider { get; }
    Task<int> SaveChangesAsync();
}