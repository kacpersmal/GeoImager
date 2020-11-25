using GeoImagerApi.Data;
using GeoImagerApi.Data.Models;
using GeoImagerApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Implementations
{
    public class UserProfileService : IUserProfileService
    {
        private readonly AppDbContext _dbContext;

        public UserProfileService(AppDbContext context)
        {
            _dbContext = context;
        }

        public Task<UserProfileModel> CreateUserProfile()
        {
            throw new NotImplementedException();
        }
    }
}
