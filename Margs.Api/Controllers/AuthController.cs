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

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult<RegisterUserRes>> Register(RegisterUserReq req)
        {
            try
            {
                var res = await _auth.Register(req);

                if (res is not null)
                    return Ok(res);

                _logger.Error($"Register new user failed with req: {req} and the respone is null");

                throw new RegisterFailedException("Register Failed");
            }
            catch (Exception e)
            {
                _logger.Error($"Register Failed With Exception: {e}");
                throw new RegisterFailedException();
            }
        }
    }
}