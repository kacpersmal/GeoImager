using GeoImagerApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IUserProfileService
    {
        public Task<UserProfileModel> CreateUserProfile();
    }
}
