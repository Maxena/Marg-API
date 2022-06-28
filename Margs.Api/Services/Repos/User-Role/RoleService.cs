using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.User_Role;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos.User_Role;

public class RoleService : GenericRepo<Role>, IRoleService
{
    public RoleService(PgDbContext context, ILogger logger) : base(context, logger)
    {
    }
}