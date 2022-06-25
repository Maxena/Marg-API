using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Response.Authentication;

namespace Margs.Api.Services.Interfaces;

public interface IAuthService
{
    Task<RegisterUserRes> Register(RegisterUserReq req);
    Task<LoginUserRes> Login(LoginUserReq req);
    Task<List<UsersRes>> GetUsers();
    Task<UsersRes> GetUserById(Guid id);
    Task<string> AddRoleToUser(Guid roleId, Guid userId);
    Task<List<RoleRes>> GetRoles();
}