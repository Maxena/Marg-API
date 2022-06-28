using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Margs.Api.Exceptions;
using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Response.Authentication;
using Margs.Api.Services.Interfaces;
using Margs.Api.Services.UOW;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using Serilog.Debugging;
using Serilog.Events;
using ILogger = Serilog.ILogger;

namespace Margs.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUnitOfWork _uow;
        private readonly IAuthService _auth;
        private readonly ICoreServices _core;

        public AuthController(ILogger logger, IAuthService auth, ICoreServices core, IUnitOfWork unitOfWork)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
            _core = core ?? throw new ArgumentNullException(nameof(core));
            _uow = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }


        [HttpGet("Test")]
        [AllowAnonymous]
        public IActionResult index()
        {
            var guid = _core.GenerateImagePid("1.webp");

            _logger.Fatal("Fetal Test For Autofac Register Service");
            if (_logger.IsEnabled(LogEventLevel.Fatal))
                return Ok(guid);

            return BadRequest();
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <remarks>
        /// Sample Request:
        /// 
        /// 
        ///     Post /Register
        ///     {
        ///         "firstName" : "Amirhossein",
        ///         "lastName"  : "sami",
        ///         "mobile"    : "09028538715",
        ///         "profile"   : "" can be null
        ///         "gender"    : "Male",
        ///         "cityId"    : 440 Hammedan CityID,
        ///         "password"  : "some password that u want",
        ///         "email"     : "some email that u want"
        ///     }
        /// </remarks>
        /// <param name="req"></param>
        /// <param name="ct"></param>
        /// <returns></returns>
        /// <exception cref="RegisterFailedException"></exception>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterUserRes>> Register([FromForm] RegisterUserReq req, CancellationToken ct)
        {
            try
            {
                var res = await _auth.Register(req, ct);

                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Error("Register Failed With Exception: {E}", e.ToString());
                throw new RegisterFailedException();
            }
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <remarks>
        /// Sample Request :
        ///
        /// 
        ///     Post /Login
        ///     {
        ///         "userName" : "09028538715", UserName Is Your Mobile Phone 
        ///         "password" : "Your Password"
        ///     }
        /// </remarks>
        /// <param name="req"></param>
        /// <returns>Return Token and UserName For User Who Login now</returns>
        /// <exception cref="LoginFailedException"></exception>
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginUserRes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LoginUserRes), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginUserRes>> Login([FromForm] LoginUserReq req)
        {
            try
            {
                var res = await _auth.Login(req);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Fatal("Login Failed With Exception: {E}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Get List of All Users
        /// </summary>
        /// <returns></returns>
        [HttpGet("User")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<List<UsersRes>>> GetUsers()
        {
            try
            {
                var res = await _auth.GetUsers();
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Error("GetUsers Failed With Exception: {E}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Get User By ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("User/{id:guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<UsersRes>> GetUserById(Guid id)
        {
            try
            {
                var res = await _auth.GetUserById(id);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Error("GetUserById Failed With Exception: {E}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// GetRoles
        /// </summary>
        /// <returns></returns>
        [HttpGet("Role")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<List<RoleRes>>> Roles()
        {
            try
            {
                var res = await _auth.GetRoles();
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Error("GetRoles Failed With Exception: {E}", e.ToString());
                throw;
            }
        }

        /// <summary>
        /// AddRoleToUser
        /// </summary>
        /// <remarks>
        /// Sample Request:
        ///
        ///     Post /AddRoleToUser
        ///     {
        ///         "roleId": 7774cb6f-6fc4-4faa-ac00-40461cf62a91
        ///         "userId": 7774cb6f-6fc4-4faa-ac00-40461cf62a91
        ///     }
        /// </remarks>
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <response code="200">Return Ok Status Code</response>
        /// <response code="401">if the request is unauthorized</response>
        /// <response code="403">if the request is forbidden</response>
        /// <returns>string if the operations will complete successfully</returns>
        [HttpPost("Role/{roleId:guid}/User/{userId:guid}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<ActionResult<string>> AddRoleToUser(Guid roleId, Guid userId)
        {
            try
            {
                var res = await _auth.AddRoleToUser(roleId, userId);
                return Ok(res);
            }
            catch (Exception e)
            {
                _logger.Error("AddRoleToUser Failed With Exception {E}", e.ToString());
                throw;
            }
        }
    }
}