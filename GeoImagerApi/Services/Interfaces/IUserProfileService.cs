using GeoImagerApi.Data.Models;
using GeoImagerApi.DataTransferObjects.Request;
using GeoImagerApi.DataTransferObjects.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeoImagerApi.Services.Interfaces
{
    public interface IUserProfileService
    {
        public Task<UserProfileResponse> ChangeAvatar(ChangeAvatarRequest req,int userId);
        public Task<UserProfileResponse> EditUserProfileAsync(EditUserProfileRequest req);
        public Task<UserProfileResponse> GetUserProfileByUserNameAsync(String name);
        public UserProfileFollowersResponse GetUserProfileFollowers(GetUserProfileFollowersRequest req);
        public UserProfileFollowingResponse GetUserProfileFollowing(GetUserProfileFollowingRequest req);
        public Task<UserImageResponse> GetUserProfilePicture(String username);
        public Task<UserImageResponse> GetUserBackgroundPicture(String username);


    }
}
