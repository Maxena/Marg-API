using Margs.Api.Database.Context;
using Margs.Api.Entities;
using Margs.Api.Exceptions;
using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Margs.Api.Services.Repos;

public class AuthService : IAuthService
{
    private readonly PgDbContext _pg;
    private readonly IDateTimeProvider _date;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public AuthService(PgDbContext pg, IDateTimeProvider date, IJwtTokenGenerator jwtTokenGenerator)
    {
        _pg = pg ?? throw new ArgumentNullException(nameof(pg));
        _date = date ?? throw new ArgumentNullException(nameof(date));
        _jwtTokenGenerator = jwtTokenGenerator ?? throw new ArgumentNullException(nameof(jwtTokenGenerator));
    }

    public async Task<RegisterUserRes> Register(RegisterUserReq req)
    {
        var isUserAlreadyExist = await _pg.Users.AnyAsync(x => x.Mobile == req.Mobile || x.Email == req.Email);

        if (isUserAlreadyExist)
            throw new UserAlreadyExistException();

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

    public async Task<LoginUserRes> Login(LoginUserReq req)
    {
        var user = await (from
                    users in _pg.Users
                where req.UserName == users.Mobile
                select users)
            .AsNoTracking()
            .FirstOrDefaultAsync();

        if (user is null)
            throw new UserNotFoundException();

        if (!BCrypt.Net.BCrypt.Verify(req.Password, user.Password))
            throw new IncorrectPasswordException();

        if (!user.IsActive)
            throw new UserIsNotActiveException();

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
}