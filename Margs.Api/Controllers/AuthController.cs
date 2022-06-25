using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Margs.Api.Exceptions;
using Margs.Api.Requests.Authentication;
using Margs.Api.Response;
using Margs.Api.Services.Interfaces;
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

        [HttpPost]
        public async Task<ActionResult<LoginUserRes>> Login(LoginUserReq req)
        {
            LoginUserRes res = await _auth.Login(req);

            if (res is not null)
                return Ok(res);
            throw new LoginFailedException(req.UserName, req.Password);
        }
    }
}