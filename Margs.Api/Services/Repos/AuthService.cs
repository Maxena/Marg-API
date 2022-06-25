using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Exceptions;
using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Response.Authentication;
using Margs.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Services.Repos;

public class AuthService : IAuthService
{
    private readonly PgDbContext _pg;
    private readonly IDateTimeProvider _date;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly ILogger _logger;

    public AuthService(PgDbContext pg, IDateTimeProvider date, IJwtTokenGenerator jwtTokenGenerator, ILogger logger)
    {
        _pg = pg ?? throw new ArgumentNullException(nameof(pg));
        _date = date ?? throw new ArgumentNullException(nameof(date));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Register a new user.
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="UserAlreadyExistException"></exception>
    /// <exception cref="JwtTokenFailedToRetrieve"></exception>
    public async Task<RegisterUserRes> Register(RegisterUserReq req)
    {
        var isUserAlreadyExist = await _pg.Users.AnyAsync(x => x.Mobile == req.Mobile || x.Email == req.Email);

        if (isUserAlreadyExist)
        {
            _logger.Error("User already exist");
            throw new UserAlreadyExistException();
        }

        var registerNewUser = new User
        {
            FirstName = req.FirstName,
            LastName = req.LastName,
            Mobile = req.Mobile,
            Email = req.Email,
            Password = BCrypt.Net.BCrypt.HashPassword(req.Password),
            Profile = req.Profile,
            IsActive = false,
            Gender = req.Gender,
            CityId = req.CityId,
            CreatedAt = _date.UtcNow,
            UpdatedAt = null,
            DeletedAt = null,
            LastLoginDateTime = _date.UtcNow,
        };

        await _pg.Users.AddAsync(registerNewUser);

        await _pg.SaveChangesAsync();

        var token = _jwtTokenGenerator.GenerateToken(registerNewUser.Id, registerNewUser.Mobile,
            new List<string> { "NewUser", "Newbie" });

        if (token is null)
            throw new JwtTokenFailedToRetrieve();

        return new RegisterUserRes
        {
            UserId = registerNewUser.Id,
            UserName = registerNewUser.Mobile,
            Token = token
        };
    }

    /// <summary>
    /// Login a user.
    /// </summary>
    /// <param name="req"></param>
    /// <returns></returns>
    /// <exception cref="UserNotFoundException"></exception>
    /// <exception cref="IncorrectPasswordException"></exception>
    /// <exception cref="UserIsNotActiveException"></exception>
    public async Task<LoginUserRes> Login(LoginUserReq req)
    {
        var user = await (from
                    users in _pg.Users
                where req.UserName == users.Mobile
                select users)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
        {
            _logger.Error("User with mobile {ReqUserName} not found", req.UserName);
            throw new UserNotFoundException();
        }

        if (!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
        {
            _logger.Error("password is not correct");
            throw new IncorrectPasswordException();
        }

        if (!user.IsActive)
        {
            _logger.Error("user is not active");
            throw new UserIsNotActiveException();
        }

        var token = _jwtTokenGenerator.GenerateToken(user.Id, user.Mobile, new List<string> { "loginUser" });

        user.LastLoginDateTime = _date.UtcNow;

        _pg.Users.Update(user);

        await _pg.SaveChangesAsync();

        return new LoginUserRes
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Profile = user.Profile,
            Email = user.Email,
            CityId = user.CityId,
            IsActive = user.IsActive,
            Token = token,
        };
    }

    /// <summary>
    /// Get List of All Users
    /// </summary>
    /// <returns></returns>
    /// <exception cref="UserFailedToRetriveException"></exception>
    public async Task<List<UsersRes>> GetUsers()
    {
        var users = await (from
                    user in _pg.Users
                select user)
            .AsNoTracking()
            .ToListAsync();

        if (users is null) throw new UserFailedToRetriveException();
        return users.Select(_ =>
            new UsersRes
            {
                UserId = _.Id,
                FirstName = _.FirstName,
                LastName = _.LastName,
                Mobile = _.Mobile,
                Email = _.Email,
                Profile = _.Profile!,
                IsActive = _.IsActive,
                CityId = _.CityId,
                Gender = _.Gender,
                CreatedAt = _.CreatedAt,
                LastLoginDateTime = _.LastLoginDateTime
            }).ToList();
    }

    /// <summary>
    /// Get User By Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<UsersRes> GetUserById(Guid id)
    {
        var user = await (from
                u in _pg.Users
            where u.Id == id
            select u).AsNoTracking().FirstOrDefaultAsync();

        if (user is not null)
            return new UsersRes
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Mobile = user.Mobile,
                Email = user.Email,
                Profile = user.Profile,
                IsActive = user.IsActive,
                CityId = user.CityId,
                Gender = user.Gender,
                CreatedAt = user.CreatedAt,
                LastLoginDateTime = user.LastLoginDateTime
            };

        _logger.Error("User Not Found in Function Get User By ID");
        throw new UserNotFoundException();
    }

    /// <summary>
    /// Add Role To User
    /// </summary>
    /// <param name="roleId"></param>
    /// <param name="userId"></param>
    /// <returns></returns>
    public async Task<string> AddRoleToUser(Guid roleId, Guid userId)
    {
        var add = new UserRole
        {
            UserId = userId,
            RoleId = roleId
        };

        await _pg.UserRoles.AddAsync(add);
        await _pg.SaveChangesAsync();

        return "Role Added To The User Successfully";
    }


    /// <summary>
    /// Get Roles 
    /// </summary>
    /// <returns></returns>
    /// <exception cref="RoleFailedToRetriveException"></exception>
    public async Task<List<RoleRes>> GetRoles()
    {
        var roles = await (from
                role in _pg.Roles
            select role).AsNoTracking().ToListAsync();

        if (roles is null) throw new RoleFailedToRetriveException();

        return roles.Select(x => new RoleRes
        {
            RoleId = x.Id,
            Name = x.Name,
            Description = x.Description
        }).ToList();
    }
}