using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Result;
using GeoImagerApi.DataTransferObjects.Validation;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GeoImagerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<RegisterResponse> Register([FromBody] RegisterRequest request)
        {
            var result = new RegisterResponse { Succeed = false, Errors = new List<string>() };

            var validator = new RegisterRequestValidator();
            var validationResult = validator.Validate(request);

            if (validationResult.IsValid)
            {
                result = await _authService.RegisterAsync(request);
            }else
            {
                result.Errors.Add("Invalid data!");
            }

            return result;
        }

        [HttpPost("authenticate")]
        public async Task<AuthenticateResponse> Authenticate([FromBody] AuthenticateRequest request)
        {
            var validator = new AuthenticateRequestValidator();
            var validationResult = validator.Validate(request);
            var result = new AuthenticateResponse { Authenticated = false, Errors = new List<string>() };

            if (validationResult.IsValid)
            {
                result = await _authService.AuthenticateAsync(request);
            }else
            {
                result.Errors.Add("Invalid data!");
            }

            return result;
        }

    }
}
