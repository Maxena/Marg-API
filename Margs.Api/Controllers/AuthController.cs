using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Margs.Api.Exceptions;
using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Response.Authentication;
using Margs.Api.Services.Interfaces;
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
        private readonly IAuthService _auth;

        public AuthController(ILogger logger, IAuthService auth)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _auth = auth ?? throw new ArgumentNullException(nameof(auth));
        }

        [HttpGet("Test")]
        [AllowAnonymous]
        public IActionResult index()
        {
            _logger.Fatal("Fetal Test For Autofac Register Service");
            if (_logger.IsEnabled(LogEventLevel.Fatal))
                return Ok();

            return BadRequest();
        }

        /// <summary>
        /// Register
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="RegisterFailedException"></exception>
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterUserRes>> Register(RegisterUserReq req)
        {
            try
            {
                var res = await _auth.Register(req);

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
        /// <param name="req"></param>
        /// <returns></returns>
        /// <exception cref="LoginFailedException"></exception>
        [HttpPost("Login")]
        [AllowAnonymous]
        [ProducesResponseType(typeof(LoginUserRes), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(LoginUserRes), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginUserRes>> Login(LoginUserReq req)
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
        /// <param name="roleId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
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