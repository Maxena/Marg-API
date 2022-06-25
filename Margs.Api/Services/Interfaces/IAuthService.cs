using Margs.Api.Requests.Authentication;
using Margs.Api.Response;

namespace Margs.Api.Services.Interfaces;

public interface IAuthService
{
    Task<RegisterUserRes> Register(RegisterUserReq req);
    Task<LoginUserRes> Login(LoginUserReq req);
}