using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Result;
using GeoImagerApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<RegisterResponse> RegisterAsync(RegisterRequest request);
        public Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request);
        public UserPayload GetPayloadById(int id);
    }
}
