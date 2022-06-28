using Margs.Api.Entities;

namespace Margs.Api.Services.Interfaces.User_Role;

public interface IUserRoleService : IGenericRepo<UserRole>
{
    Task AddRoleToUser(Guid roleId, Guid userId);
}