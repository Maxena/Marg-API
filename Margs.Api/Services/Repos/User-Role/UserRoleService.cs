using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Services.Interfaces.User_Role;
using Margs.Api.Services.UOW;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos.User_Role;

public class UserRoleService : GenericRepo<UserRole>, IUserRoleService
{
    private readonly PgDbContext _context;

    private readonly IUnitOfWork _uow;

    public UserRoleService(PgDbContext context, ILogger logger) : base(context, logger)
    {
        _context = context;
    }

    public async Task AddRoleToUser(Guid roleId, Guid userId)
    {
        var isUserExist = await _uow.User.GetByIdAsync(userId);

        var isRoleExist = await _uow.Role.GetByIdAsync(roleId);

        if (isUserExist is null)
            throw new ArgumentNullException($"No such user with id {userId} exist");

        if (isRoleExist is null)
            throw new ArgumentNullException($"No such role with id {roleId} exist");

        var userRole = new UserRole
        {
            UserId = userId,
            RoleId = roleId,
            CreatedAt = _uow.DateTimeProvider.UtcNow,
        };

        await _uow.UserRole.InsertAsync(userRole);
        
        await _uow.SaveChangesAsync();
    }
}