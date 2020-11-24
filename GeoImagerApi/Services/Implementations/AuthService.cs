using AutoMapper;
using GeoImagerApi.Data;
using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Result;
using GeoImagerApi.Helpers;
using GeoImagerApi.Services.Interfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Implementations
{
    public class AuthService : IAuthService
    {

        private AppDbContext _dbContext;
        private IMapper _mapper;
        private IConfiguration _config;

        public AuthService(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            _dbContext = context;
            _mapper = mapper;
            _config = config;
        }

        public async Task<AuthenticateResponse> AuthenticateAsync(AuthenticateRequest request)
        {
            var response = new AuthenticateResponse { Authenticated = false, Errors = new List<string>() };
            var hashedPassword = HashPassword(request.Password);
            var user = await _dbContext.Users.FirstOrDefaultAsync(mod => mod.Email == request.Email && mod.HashedPassword == hashedPassword) ;

            if (user != null)
            {
                response.Authenticated = true;
                response.Payload = new UserPayload { Mail = user.Email, Username = user.Username, Token = generateJwtToken(user), Id = user.Id };
            }else
            {
                response.Errors.Add("User does not exist or bad credentials!");
            }

            return response;
        }

        public async Task<RegisterResponse> RegisterAsync(RegisterRequest request)
        {
            var result = new RegisterResponse { Errors = new List<string>() , Succeed = false};
            var userExists = await _dbContext.Users.FirstOrDefaultAsync(mod => mod.Username == request.Username || mod.Email == request.Email) != null ;
            if (userExists)
            {
                result.Errors.Add("User arleady exists!");
                return result;
            }

            var model = new UserModel { CreationDate = DateTime.UtcNow, Email = request.Email, Username = request.Username, Verified = false, HashedPassword = HashPassword(request.Password) };

            _dbContext.Users.Add(model);
            _dbContext.SaveChanges();
            result.Succeed = true;

            return result;
        }

        public UserPayload GetPayloadById(int id)
        {
            var payload = new UserPayload { Mail = "", Token = "", Username = "" };
            var userModel = _dbContext.Users.FirstOrDefault(x => x.Id == id);
            if(userModel != null)
            {
                payload.Mail = userModel.Email;
                payload.Username = userModel.Username;
                payload.Id = userModel.Id;
            }

            return payload;
        }

        private string generateJwtToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_config["JwtSecret"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private String HashPassword(String pass)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: pass,
            salt: Encoding.ASCII.GetBytes(_config["Salt"]),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));

            return hashed;
        }

    }
}
